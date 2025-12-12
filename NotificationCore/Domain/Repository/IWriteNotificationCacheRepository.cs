using NotificationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Domain.Repository
{
    public interface IWriteNotificationCacheRepository
    {
        Task Add(NotificationObjectCache notification, CancellationToken cancellationToken);
        Task Update(NotificationObjectCache notification, CancellationToken cancellationToken);
    }
}
