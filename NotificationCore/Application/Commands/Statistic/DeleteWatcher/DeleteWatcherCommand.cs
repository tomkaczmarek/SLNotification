using NotificationCore.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.Statistic.DeleteWatcher
{
    public class DeleteWatcherCommand : ICommand
    {
        public Guid SourceId { get; set; }
        public Guid TargetId { get; set; }
    }
}
