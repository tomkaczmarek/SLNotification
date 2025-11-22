using NotificationCore.Domain.Entities;
using NotificationCore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Infrastructure.DAL.Repositories
{
    public class WriteNotificationRepository : IWriteNotificationRepository
    {
        private NotificationDbContext _context;

        public WriteNotificationRepository(NotificationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Notification notification, CancellationToken cancellationToken)
        {
            await _context.Notifications.AddAsync(notification, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
