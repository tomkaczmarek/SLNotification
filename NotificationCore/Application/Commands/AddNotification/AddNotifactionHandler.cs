using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Response;
using NotificationCore.Domain.Entities;
using NotificationCore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.AddNotification
{
    public class AddNotifactionHandler : ICommandHandler<AddNotificationCommand>
    {
        private IWriteNotificationRepository _notificationRepository;

        public AddNotifactionHandler(IWriteNotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<ApiResponse> HandleAsync(AddNotificationCommand command, CancellationToken cancellationToken)
        {
            var notification = new Notification(command.RecipientId, command.Key, command.NoticationBody, command.IsActive);

            await _notificationRepository.Add(notification, cancellationToken);

            return new ApiResponse();
        }
    }
}
