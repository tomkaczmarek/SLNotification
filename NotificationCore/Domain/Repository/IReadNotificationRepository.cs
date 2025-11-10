using NotificationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Domain.Repository
{
    public interface IReadNotificationRepository
    {
        Task<List<Notification>> GetActiveNotifications(Guid sourceId, CancellationToken cancellationToken);
    }
}
