using NotificationCore.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.Events.AddNotificationEventMemberCache
{
    public class AddNotificationEventMemberCacheCommand : ICommand
    {
        public Guid EventId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid SourceId { get; set; }
    }
}
