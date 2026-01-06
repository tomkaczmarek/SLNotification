using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Response;
using NotificationCore.Domain.Entities;
using NotificationCore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.UpdateNotificationCache
{
    public class UpdateNotificationCacheCommandHandler : ICommandHandler<UpdateNotificationCacheCommand>
    {
        private IWriteNotificationCacheRepository _notificationCacheRepository;

        public UpdateNotificationCacheCommandHandler(IWriteNotificationCacheRepository notificationCacheRepository)
        {
            _notificationCacheRepository = notificationCacheRepository;
        }

        public async Task<ApiResponse> HandleAsync(UpdateNotificationCacheCommand command, CancellationToken cancellationToken)
        {
            var cache = new NotificationObjectCache(command.SourceId, command.Name, command.DomainObjectType);
            await _notificationCacheRepository.Update(cache, cancellationToken);
            return new ApiResponse();
        }
    }
}
