using NotificationCore.Abstractions.Commands;
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
        public Guid? AvatarId { get; set; }
        public string Name { get; set; }
    }
}
