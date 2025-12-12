using NotificationCore.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.UpdateNotificationCache
{
    public class UpdateNotificationCacheCommand : ICommand
    {
        public Guid SourceId { get; set; }
        public Guid? AvatarId { get; set; }
        public string Name { get; set; }
    }
}
