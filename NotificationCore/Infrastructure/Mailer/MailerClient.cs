using FluentEmail.Core;
using Microsoft.Extensions.Configuration;
using NotificationCore.Abstractions.Mailer;
using Polly;
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
        private readonly IAsyncPolicy _policy;
        private IConfiguration _configuration;

        public MailerClient(IFluentEmail fluentEmail, IAsyncPolicy policy, IConfiguration configuration)
        {
            _fluentEmail = fluentEmail;
            _policy = policy;
            _configuration = configuration;
        }

        public async Task Send(MailBody body, CancellationToken cancellationToken)
        {
            var testMail = _configuration.GetSection("RegistrationTestMail").Value;

            await _policy.ExecuteAsync(async ct =>
            {
                _fluentEmail
                    .To(string.IsNullOrEmpty(testMail) ? body.MailAddress : testMail)
                    .Subject("Lookstade rejestracja konta")
                    .Body(body.Body);

                await _fluentEmail.SendAsync(ct);
            }, cancellationToken);
        }
    }
}
