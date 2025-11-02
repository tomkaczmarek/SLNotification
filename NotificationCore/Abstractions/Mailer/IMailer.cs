using NotificationCore.Infrastructure.Mailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Abstractions.Mailer
{
    public interface IMailer
    {
        Task Send(MailBody body, CancellationToken cancellationToken);
    }
}
