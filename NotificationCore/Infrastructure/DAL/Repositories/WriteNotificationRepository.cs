using Microsoft.EntityFrameworkCore;
using NotificationCore.Domain.Entities;
using NotificationCore.Domain.Repository;
using Npgsql;
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

        public async Task AddNewNotificationCount(NotificationActiveCount notificationActiveCount, CancellationToken cancellationToken)
        {
            await _context.NotificationActiveCounts.AddAsync(notificationActiveCount, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AddRange(List<Notification> notifications, CancellationToken cancellationToken)
        {
            await _context.Notifications.AddRangeAsync(notifications, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task IncreamentNotificationCount(Guid profileId, CancellationToken cancellationToken)
        {
            await _context.NotificationActiveCounts
                .Where(x => x.ProfileId == profileId)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(y => y.ActiveNotificationCount, z => z.ActiveNotificationCount + 1), cancellationToken);
        }

        public async Task IncrementNotificationCountBatch(Dictionary<Guid, int> keys, CancellationToken cancellation)
        {
            var parameters = new List<NpgsqlParameter>();
            var valuesBuilder = new StringBuilder();

            int i = 0;

            foreach (var kvp in keys)
            {
                string guidId = $"id{i}";
                string increment = $"inc{i}";

                valuesBuilder.Append($"(@{guidId}, @{increment}),");

                parameters.Add(new NpgsqlParameter(guidId, kvp.Key));
                parameters.Add(new NpgsqlParameter(increment, kvp.Value));

                i++;
            }
            valuesBuilder.Length--;

            string sql = $@"
                                UPDATE notify.""NotificationActiveCounts"" AS b
                                SET ""ActiveNotificationCount"" = b.""ActiveNotificationCount"" + v.""Inc""
                                FROM (VALUES 
                                    {valuesBuilder}
                                ) AS v(""Id"", ""Inc"")
                                WHERE b.""ProfileId"" = v.""Id"";";

            await _context.Database.ExecuteSqlRawAsync(sql, parameters.ToArray(), cancellation);
        }

        public async Task ResetNotificationsCount(Guid profileId, CancellationToken cancellationToken)
        {
            await _context.NotificationActiveCounts
                .Where(x => x.ProfileId == profileId)
                .ExecuteUpdateAsync(x => x.SetProperty(y => y.ActiveNotificationCount, 0), cancellationToken);
        }
    }
}
