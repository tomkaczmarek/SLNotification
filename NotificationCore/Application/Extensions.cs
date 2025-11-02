using Microsoft.Extensions.DependencyInjection;
using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Consumer;
using NotificationCore.Application.Commands.AddNotification;
using NotificationCore.Application.Commands.Mailers.SendVerifyTokenMail;
using NotificationCore.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddSingleton<IMessageConsumer, RabbitMqConsumer>();
            services.AddScoped<ICommandHandler<AddNotificationCommand>, AddNotifactionHandler>();
            services.AddScoped<ICommandHandler<SendVerifyTokenMailCommand>, SendVerifyTokenMailHandler>();
            return services;
        }
    }
}
