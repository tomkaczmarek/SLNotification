using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Response;
using NotificationCore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.AddActiveNotificationCount
{
    public class AddActiveNotificationCountCommandHandler : ICommandHandler<AddActiveNotificationCountCommand>
    {
        private IWriteNotificationRepository _notificationRepository;

        public AddActiveNotificationCountCommandHandler(IWriteNotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<ApiResponse> HandleAsync(AddActiveNotificationCountCommand command, CancellationToken cancellationToken)
        {
            await _notificationRepository.IncreamentNotificationCount(command.ProfileId, cancellationToken);
            return new ApiResponse();
        }
    }
}
