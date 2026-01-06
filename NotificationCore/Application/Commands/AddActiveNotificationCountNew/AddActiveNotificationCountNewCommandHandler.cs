using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Response;
using NotificationCore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.AddActiveNotificationCountNew
{
    public class AddActiveNotificationCountNewCommandHandler : ICommandHandler<AddActiveNotificationCountNewCommand>
    {
        IWriteNotificationRepository _notificationRepository;

        public AddActiveNotificationCountNewCommandHandler(IWriteNotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<ApiResponse> HandleAsync(AddActiveNotificationCountNewCommand command, CancellationToken cancellationToken)
        {

            await _notificationRepository.AddNewNotificationCount(new Domain.Entities.NotificationActiveCount() 
            { 
                ActiveNotificationCount = 0, 
                ProfileId = command.ProfileId, 
                UpdateAt = DateTime.UtcNow 
            }, 
                cancellationToken);

            return new ApiResponse();
        }
    }
}
