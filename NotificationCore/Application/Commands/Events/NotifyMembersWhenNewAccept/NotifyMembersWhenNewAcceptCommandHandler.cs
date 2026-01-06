using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Repository;
using NotificationCore.Abstractions.Response;
using NotificationCore.Abstractions.Works;
using NotificationCore.Application.Queries.GetActiveNotifications;
using NotificationCore.Domain.Entities;
using NotificationCore.Domain.Repository;
using NotificationCore.Infrastructure.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.Events.NotifyMembersWhenNewAccept
{
    public class NotifyMembersWhenNewAcceptCommandHandler : ICommandHandler<NotifyMembersWhenNewAcceptCommand>
    {
        private IReadNotificationCacheRepository _notificationRepository;
        private IWriteNotificationRepository _writeNotificationRepository;
        private IUnitOfWork _unitOfWork;

        public NotifyMembersWhenNewAcceptCommandHandler(IReadNotificationCacheRepository notificationRepository, IWriteNotificationRepository writeNotificationRepository, IUnitOfWork unitOfWork)
        {
            _notificationRepository = notificationRepository;
            _writeNotificationRepository = writeNotificationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> HandleAsync(NotifyMembersWhenNewAcceptCommand command, CancellationToken cancellationToken)
        {
            var members = await _notificationRepository.GetEventMemberFromCache(command.EventId, command.ExcludedFromNotifySourceId, cancellationToken);

            if (members.Any())
            {
                List<Guid> profilesId = members.Select(x => x.ProfileId).Distinct().ToList();

                var notifications = profilesId.Select(member =>
                {
                    var body = JsonSerializer.Serialize(new NotificationPayload
                    {
                        DestinationId = command.SourceId,
                        SourceId = command.EventId
                    });
                    return new Notification(member, command.NotificationType, body, true);

                }).ToList();

                await _unitOfWork.Execute(async () =>
                {
                    await _writeNotificationRepository.AddRange(notifications, cancellationToken);

                    var membersActiveNotifications = profilesId.ToDictionary(x => x, y => 1);
                    await _writeNotificationRepository.IncrementNotificationCountBatch(membersActiveNotifications, cancellationToken);

                }, cancellationToken);
            }

            return new ApiResponse();
        }
    }
}
