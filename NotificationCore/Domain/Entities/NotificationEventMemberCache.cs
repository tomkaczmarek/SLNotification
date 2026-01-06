using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Domain.Entities
{
    public class NotificationEventMemberCache
    {
        public Guid EventId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid SourceId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
