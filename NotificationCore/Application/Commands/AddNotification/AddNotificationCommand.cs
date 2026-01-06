using NotificationCore.Abstractions.Commands;
using NotificationCore.Domain.Entities;
using NotificationCore.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.AddNotification
{
    public class AddNotificationCommand : BaseNotification, ICommand
    {
        public Guid RecipientId { get; set; }       
        public string NoticationBody { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class BaseNotification
    {
        public NotificationTypes NotificationType { get; set; }
    }
}
