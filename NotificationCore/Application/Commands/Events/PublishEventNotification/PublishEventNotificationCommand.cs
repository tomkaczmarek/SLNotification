using NotificationCore.Abstractions.Commands;
using NotificationCore.Application.Commands.AddNotification;
using NotificationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.Events.PublishEventNotification
{
    public class PublishEventNotificationCommand : BaseNotification, ICommand
    {
        public Guid PublisherId { get; set; }
        public Guid EventId { get; set; }
    }
}
