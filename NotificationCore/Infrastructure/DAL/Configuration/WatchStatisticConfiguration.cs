using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationCore.Domain.Entities;
using NotificationCore.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Infrastructure.DAL.Configuration
{
    public class WatchStatisticConfiguration : IEntityTypeConfiguration<WatchStatistic>
    {
        public void Configure(EntityTypeBuilder<WatchStatistic> builder)
        {
            builder.Metadata.SetSchema("statistic");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.SourceId).HasConversion(x => x.Value, y => new GuidId(y));
            builder.Property(x => x.TargetId).HasConversion(x => x.Value, y => new GuidId(y));
        }
    }
}
