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
    public class ReadNotificationRepository : IReadNotificationRepository
    {
        private NotificationDbContext _context;

        public ReadNotificationRepository(NotificationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Notification>> GetActiveNotifications(Guid sourceId, CancellationToken cancellationToken)
        {
            return await _context.Notifications
                .AsNoTracking()
                .Where(x => x.RecipientId == new Domain.ValueObject.GuidId(sourceId))
                .OrderBy(x => x.CreatedAt)
                .ToListAsync(cancellationToken);
        }
    }
}
