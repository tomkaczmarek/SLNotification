using Microsoft.Extensions.DependencyInjection;
using NotificationCore.Abstractions.Mailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Infrastructure.Mailer
{
    public static class Extensions
    {
        public static IServiceCollection AddMailer(this IServiceCollection services)
        {
            //TODO - to appconfig
            var smtp = new SmtpClient("serwer2683102.home.pl")
            {
                EnableSsl = true,
                Port = 587,
                Credentials = new NetworkCredential("registration@lookstage.com", "Registration1234!@#$")
            };

            services.AddFluentEmail("registration@lookstage.com").AddSmtpSender(smtp);
            services.AddScoped<IMailer, MailerClient>();
            return services;
        }
    }
}
