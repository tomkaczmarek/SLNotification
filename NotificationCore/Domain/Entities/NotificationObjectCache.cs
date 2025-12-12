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
        public Guid? AvatarId { get; set; }
        public string Name { get; set; }

        public NotificationObjectCache(Guid sourceId, Guid? avatarId, string name)
        {
            SourceId = sourceId;
            AvatarId = avatarId;
            Name = name;
        }
    }
}
