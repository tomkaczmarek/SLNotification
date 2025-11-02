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
            var smtp = new SmtpClient("smtp.wp.pl")
            {
                EnableSsl = true,
                Port = 587,
                Credentials = new NetworkCredential("t.kaczmarek@wp.pl", "1234ParasitE!@#$")
            };

            services.AddFluentEmail("t.kaczmarek@wp.pl").AddSmtpSender(smtp);
            services.AddScoped<IMailer, MailerClient>();
            return services;
        }
    }
}
