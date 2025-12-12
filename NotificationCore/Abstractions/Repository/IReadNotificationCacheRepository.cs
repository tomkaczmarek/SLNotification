using NotificationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Abstractions.Repository
{
    public interface IReadNotificationCacheRepository
    {
        Task<List<NotificationObjectCache>> GetFromCache(List<Guid> sourcesIds, CancellationToken cancellationToken);
    }
}
