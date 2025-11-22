using NotificationCore.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Queries.GetActiveNotifications
{
    public class GetActiveNotificationsQuery : IQuery<List<GetActiveNotificationsResult>>
    {
        public Guid RecipientId { get; set; }
        public int SkipOffset { get; set; }
    }
}
