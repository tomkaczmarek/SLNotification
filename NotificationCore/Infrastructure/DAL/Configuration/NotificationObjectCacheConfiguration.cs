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
    public class NotificationObjectCacheConfiguration : IEntityTypeConfiguration<NotificationObjectCache>
    {
        public void Configure(EntityTypeBuilder<NotificationObjectCache> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DomainObjectsType).HasConversion<string>();
        }
    }
}
