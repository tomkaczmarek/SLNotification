using NotificationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Queries.GetActiveNotifications
{
    public class GetActiveNotificationsResult
    {
        public int Id { get; set; }
        public NotificationTypes NotificationType { get; set; }
        public NotificationPayload NotificationPayload { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class NotificationPayload()
    {
        public Guid? SourceId { get; set; }
        public string SourceName { get; set; }
        public DomainObjectsType SourceDomainObjectsType { get; set; }

        public Guid? DestinationId { get; set; }
        public string DestinationName { get; set; }
        public DomainObjectsType DestinationDomainObjectsType { get; set; }


        public Guid? CoordinatorId { get; set; }
        public string CoordinatorName { get; set; }
        public DomainObjectsType CoordinatorDomainObjectsType { get; set; }

        public string InfoKey { get; set; }
    }
}
