using Microsoft.EntityFrameworkCore;
using NotificationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Infrastructure.DAL
{
    public class NotificationDbContext : DbContext
    {
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Watcher> Watches { get; set; }
        public DbSet<NotificationObjectCache> NotificationObjectCaches { get; set; }
        public DbSet<NotificationEventMemberCache> NotificationEventMemberCaches { get; set; }
        public DbSet<NotificationActiveCount> NotificationActiveCounts { get; set; }

        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("notify");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
