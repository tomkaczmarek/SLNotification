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
        public GuidId RecipientId { get; set; }
        public NotificationKey Key { get; set; }
        public Body NoticationBody { get; set; }
        public BoolField IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public Notification(GuidId recipientId, NotificationKey key, Body noticationBody, BoolField isActive)
        {
            RecipientId = recipientId;
            Key = key;
            NoticationBody = noticationBody;
            IsActive = isActive;
        }
    }
}
