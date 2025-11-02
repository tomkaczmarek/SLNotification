using NotificationCore.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Domain.Entities
{
    public class Notification
    {
        public IntId Id { get; set; }
        public GuidId SourceId { get; set; }
        public NotificationKey Key { get; set; }
        public Body NoticationBody { get; set; }
        public BoolField IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public Notification(GuidId sourceId, NotificationKey key, Body noticationBody, BoolField isActive)
        {
            SourceId = sourceId;
            Key = key;
            NoticationBody = noticationBody;
            IsActive = isActive;
        }
    }
}
