using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Domain.Entities
{
    public class NotificationObjectCache
    {
        public int Id { get; set; }
        public Guid SourceId { get; set; }
        public string Name { get; set; }
        public DomainObjectsType DomainObjectsType { get; set; }

        public NotificationObjectCache(Guid sourceId, string name, DomainObjectsType domainObjectsType)
        {
            SourceId = sourceId;
            Name = name;
            DomainObjectsType = domainObjectsType;
        }
    }
}
