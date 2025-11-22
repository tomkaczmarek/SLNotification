using NotificationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Abstractions.Repository
{
    public interface IReadNotificationRepository
    {
        Task<List<Notification>> GetActiveNotifications(Guid sourceId, int skipOffset, CancellationToken cancellationToken);
    }
}
