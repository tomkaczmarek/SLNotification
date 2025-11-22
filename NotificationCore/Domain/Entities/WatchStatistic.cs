using NotificationCore.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Domain.Entities
{
    public class WatchStatistic
    {
        public long Id { get; set; }
        public GuidId SourceId { get; set; }
        public GuidId TargetId { get; set; }

        public WatchStatistic(GuidId sourceId, GuidId targetId)
        {
            SourceId = sourceId;
            TargetId = targetId;
        }
    }
}
