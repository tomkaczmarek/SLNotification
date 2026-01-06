using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Repository;
using NotificationCore.Abstractions.Response;
using NotificationCore.Abstractions.Works;
using NotificationCore.Application.Queries.GetActiveNotifications;
using NotificationCore.Domain.Entities;
using NotificationCore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.Events.PublishEventNotification
{
    public class PublishEventNotificationCommandHandler : ICommandHandler<PublishEventNotificationCommand>
    {
        private IReadNotificationCacheRepository _readNotificationCacheRepository;
        private IWriteNotificationRepository _writeNotificationRepository;
        private IUnitOfWork _unitOfWork;

        public PublishEventNotificationCommandHandler(IReadNotificationCacheRepository readNotificationCacheRepository, IWriteNotificationRepository writeNotificationRepository, IUnitOfWork unitOfWork)
        {
            _readNotificationCacheRepository = readNotificationCacheRepository;
            _writeNotificationRepository = writeNotificationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> HandleAsync(PublishEventNotificationCommand command, CancellationToken cancellationToken)
        {
            var members = await _readNotificationCacheRepository.GetEventMemberFromCache(command.EventId, null, cancellationToken);

            if (members.Any())
            {
                List<Guid> profilesId = members.Select(x=>x.ProfileId).Distinct().ToList();

                var notifications = profilesId.Select(member =>
                {
                    var body = JsonSerializer.Serialize(new NotificationPayload
                    {
                        CoordinatorId = command.PublisherId,
                        DestinationId = member,
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
