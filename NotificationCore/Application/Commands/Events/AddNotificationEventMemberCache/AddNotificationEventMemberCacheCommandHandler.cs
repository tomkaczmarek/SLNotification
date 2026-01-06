using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Response;
using NotificationCore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.Events.AddNotificationEventMemberCache
{
    public class AddNotificationEventMemberCacheCommandHandler : ICommandHandler<AddNotificationEventMemberCacheCommand>
    {
        private IWriteNotificationCacheRepository _writeNotificationCacheRepository;

        public AddNotificationEventMemberCacheCommandHandler(IWriteNotificationCacheRepository writeNotificationCacheRepository)
        {
            _writeNotificationCacheRepository = writeNotificationCacheRepository;
        }

        public async Task<ApiResponse> HandleAsync(AddNotificationEventMemberCacheCommand command, CancellationToken cancellationToken)
        {
            await _writeNotificationCacheRepository.AddEventMemberCache(new Domain.Entities.NotificationEventMemberCache()
            {
                CreatedAt = DateTime.UtcNow,
                EventId = command.EventId,
                ProfileId = command.ProfileId,
                SourceId = command.SourceId
            }, cancellationToken);
            return new ApiResponse();
        }
    }
}
