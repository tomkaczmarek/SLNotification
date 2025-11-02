using NotificationCore.Abstractions.Commands;
using NotificationCore.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.AddNotification
{
    public class AddNotificationCommand : ICommand
    {
        public Guid SourceId { get; set; }
        public string Key { get; set; }
        public string NoticationBody { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
