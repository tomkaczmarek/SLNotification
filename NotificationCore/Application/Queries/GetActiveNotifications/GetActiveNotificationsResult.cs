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
        public string Key { get; set; }
        public string Body { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
