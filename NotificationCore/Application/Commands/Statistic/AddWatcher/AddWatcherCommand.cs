using NotificationCore.Abstractions.Commands;
using NotificationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NotificationCore.Application.Commands.Statistic.AddWatcher
{
    public class AddWatcherCommand : ICommand
    {
        public Guid SourceId { get; set; }
        public DomainObjectsType SourceDomainObject { get; set; }
        public Guid TargetId { get; set; }
        public DomainObjectsType TargetDomainObject { get; set; }
    }
}
