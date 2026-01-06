using NotificationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Domain.Repository
{
    public interface IWriteNotificationRepository
    {
        Task Add(Notification notification, CancellationToken cancellationToken);

        Task AddRange(List<Notification> notifications, CancellationToken cancellationToken);
        Task IncreamentNotificationCount(Guid profileId, CancellationToken cancellationToken);
        Task IncrementNotificationCountBatch(Dictionary<Guid, int> keys, CancellationToken cancellation);
        Task ResetNotificationsCount(Guid profileId, CancellationToken cancellationToken);
        Task AddNewNotificationCount(NotificationActiveCount notificationActiveCount, CancellationToken cancellationToken);
    }
}
