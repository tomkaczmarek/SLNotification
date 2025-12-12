using NotificationCore.Domain.Entities;
using NotificationCore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Infrastructure.DAL.Repositories
{
    public class WriteStatisticRepository : IWriteStatisticRepository
    {
        private NotificationDbContext _context;

        public WriteStatisticRepository(NotificationDbContext context)
        {
            _context = context;
        }

        public async Task AddWatch(WatchStatistic watchStatistic, CancellationToken cancellationToken)
        {
            await _context.Watches.AddAsync(watchStatistic, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
