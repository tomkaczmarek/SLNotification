using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Infrastructure.DAL.Configuration
{
    public class NotificationEventMemberCacheConfiguration : IEntityTypeConfiguration<NotificationEventMemberCache>
    {
        public void Configure(EntityTypeBuilder<NotificationEventMemberCache> builder)
        {
            builder.HasKey(x => new { x.EventId, x.ProfileId, x.SourceId });
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("NOW()");
        }
    }
}
