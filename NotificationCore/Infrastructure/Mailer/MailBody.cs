using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Infrastructure.Mailer
{
    public class MailBody
    {
        public string Body { get; set; }

        public string MailAddress { get; set; }

        public MailBody(string body)
        {
            Body = body;
        }
    }
}
