using NotificationCore.Abstractions.Commands;
using NotificationCore.Application.Commands.AddNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.Events.NotifyMembersWhenNewAccept
{
    public class NotifyMembersWhenNewAcceptCommand : BaseNotification, ICommand
    {
        public Guid EventId { get; set; }
        public Guid SourceId { get; set; }
        public Guid ExcludedFromNotifySourceId { get; set; }
    }
}
