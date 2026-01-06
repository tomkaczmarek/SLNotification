using NotificationCore.Abstractions.Commands;
using NotificationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.AddNotificationCache
{
    public class AddNotificationCacheCommand : ICommand
    {
        public Guid SourceId { get; set; }
        public string Name { get; set; }
        public DomainObjectsType DomainObjectType { get; set; }
    }
}
