using Microsoft.EntityFrameworkCore;
using NotificationCore.Abstractions.Repository;
using NotificationCore.Domain.Entities;
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

        public async Task<List<Notification>> GetActiveNotifications(Guid sourceId, int skipOffset, CancellationToken cancellationToken)
        {
            return await _context.Notifications
                .AsNoTracking()
                .Where(x => x.RecipientId == new Domain.ValueObject.GuidId(sourceId))
                .OrderByDescending(x => x.CreatedAt)
                .Skip(skipOffset)
                .Take(10)
                .ToListAsync(cancellationToken);
        }
    }
}
