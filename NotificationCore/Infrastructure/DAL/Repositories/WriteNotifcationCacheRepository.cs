using Microsoft.EntityFrameworkCore;
using NotificationCore.Domain.Entities;
using NotificationCore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Infrastructure.DAL.Repositories
{
    public class WriteNotifcationCacheRepository : IWriteNotificationCacheRepository
    {
        private NotificationDbContext _notificationDbContext;

        public WriteNotifcationCacheRepository(NotificationDbContext notificationDbContext)
        {
            _notificationDbContext = notificationDbContext;
        }

        public async Task Add(NotificationObjectCache notification, CancellationToken cancellationToken)
        {
            await _notificationDbContext.NotificationObjectCaches.AddAsync(notification, cancellationToken);
            await _notificationDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(NotificationObjectCache notification, CancellationToken cancellationToken)
        {
            await _notificationDbContext.NotificationObjectCaches
                .Where(x => x.SourceId == notification.SourceId)
                .ExecuteUpdateAsync(
                x => x
                .SetProperty(x => x.AvatarId, y => notification.AvatarId)
                .SetProperty(x=>x.Name, y=>notification.Name)
                , cancellationToken);
        }
    }
}
