using NotificationCore.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Domain.Entities
{
    public class Watcher
    {
        public long Id { get; set; }
        public GuidId SourceId { get; set; }
        public GuidId TargetId { get; set; }
        public DomainObjectsType SourceDomainObject { get; set; }
        public DomainObjectsType TargetDomainObject { get; set; }
        public DateTime CreatedAt { get; set; }

        public Watcher(GuidId sourceId, GuidId targetId)
        {
            SourceId = sourceId;
            TargetId = targetId;
        }

        public Watcher(GuidId sourceId, GuidId targetId, DomainObjectsType sourceDomainType, DomainObjectsType targetDomainType)
        {
            SourceId = sourceId;
            TargetId = targetId;
            SourceDomainObject = sourceDomainType;
            TargetDomainObject = targetDomainType;
        }
    }
}
