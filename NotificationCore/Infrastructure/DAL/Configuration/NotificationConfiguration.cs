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
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.HasIndex(x => x.RecipientId);
            builder.Property(x => x.Id).HasConversion(x => x.Value, y => new IntId(y)).ValueGeneratedOnAdd();
            builder.Property(x => x.IsActive).HasConversion(x => x.Value, y => new BoolField(y));
            builder.Property(x => x.RecipientId).HasConversion(x => x.Value, y => new GuidId(y));
            builder.Property(x => x.Key).HasConversion(x => x.Value, y => new NotificationKey(y));
            builder.Property(x => x.NoticationBody).HasConversion(x => x.Value, y => new Body(y));
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("NOW()");
        }
    }
}
