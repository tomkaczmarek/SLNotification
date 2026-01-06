using NotificationCore.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.AddActiveNotificationCount
{
    public class AddActiveNotificationCountCommand : ICommand
    {
        public Guid ProfileId { get; set; }
    }
}
