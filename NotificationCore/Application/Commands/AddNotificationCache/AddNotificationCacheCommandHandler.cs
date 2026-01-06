using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Response;
using NotificationCore.Domain.Entities;
using NotificationCore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.AddNotificationCache
{
    public class AddNotificationCacheCommandHandler : ICommandHandler<AddNotificationCacheCommand>
    {
        private IWriteNotificationCacheRepository _notificationCacheRepository;

        public AddNotificationCacheCommandHandler(IWriteNotificationCacheRepository notificationCacheRepository)
        {
            _notificationCacheRepository = notificationCacheRepository;
        }

        public async Task<ApiResponse> HandleAsync(AddNotificationCacheCommand command, CancellationToken cancellationToken)
        {
            var cache = new NotificationObjectCache(command.SourceId, command.Name, command.DomainObjectType);

            await _notificationCacheRepository.Add(cache, cancellationToken);

            return new ApiResponse();
        }
    }
}
