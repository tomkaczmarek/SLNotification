using NotificationCore.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Queries.GetActiveNotificationsCount
{
    public class GetActiveNotificationsCountQuery : IQuery<GetActiveNotificationsCountQueryResult>
    {
        public Guid ProfileId { get; set; }
    }
}
