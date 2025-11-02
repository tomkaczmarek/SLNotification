using FluentEmail.Core;
using NotificationCore.Abstractions.Mailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Infrastructure.Mailer
{
    public class MailerClient : IMailer
    {
        private readonly IFluentEmail _fluentEmail;

        public MailerClient(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task Send(MailBody body, CancellationToken cancellationToken)
        {
            _fluentEmail
                .To("t.kaczmarek@wp.pl")
                .Body(body.Body)
                .Subject("Soundlink rejestracja konta");

            await _fluentEmail.SendAsync(cancellationToken);
        }
    }
}
