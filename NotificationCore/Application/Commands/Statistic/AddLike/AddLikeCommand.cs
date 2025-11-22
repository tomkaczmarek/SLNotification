using NotificationCore.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.Statistic.AddLike
{
    public class AddLikeCommand : ICommand
    {
        public Guid SourceId { get; set; }
        public Guid TargetId { get; set; }    
    }
}
