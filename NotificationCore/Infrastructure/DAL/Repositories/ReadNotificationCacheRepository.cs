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
    public class ReadNotificationCacheRepository : IReadNotificationCacheRepository
    {
        private NotificationDbContext _context;

        public ReadNotificationCacheRepository(NotificationDbContext context)
        {
            _context = context;
        }

        public async Task<List<NotificationObjectCache>> GetFromCache(List<Guid> sourcesIds, CancellationToken cancellationToken)
        {
            return await _context.NotificationObjectCaches
                .AsNoTracking()
                .Where(x => sourcesIds
                .Contains(x.SourceId))
                .ToListAsync(cancellationToken);
        }
    }
}
