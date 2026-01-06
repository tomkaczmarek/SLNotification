using Microsoft.Extensions.DependencyInjection;
using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Consumer;
using NotificationCore.Abstractions.Queries;
using NotificationCore.Application.Commands.AddActiveNotificationCount;
using NotificationCore.Application.Commands.AddActiveNotificationCountNew;
using NotificationCore.Application.Commands.AddNotification;
using NotificationCore.Application.Commands.AddNotificationCache;
using NotificationCore.Application.Commands.Events.AddNotificationEventMemberCache;
using NotificationCore.Application.Commands.Events.NotifyMembersWhenNewAccept;
using NotificationCore.Application.Commands.Events.PublishEventNotification;
using NotificationCore.Application.Commands.Mailers.SendVerifyTokenMail;
using NotificationCore.Application.Commands.Statistic.AddWatcher;
using NotificationCore.Application.Commands.UpdateNotificationCache;
using NotificationCore.Application.Queries.GetActiveNotifications;
using NotificationCore.Application.Queries.GetActiveNotificationsCount;
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
            services.AddScoped<ICommandHandler<AddNotificationCommand>, AddNotificationCommandHandler>();
            services.AddScoped<ICommandHandler<SendVerifyTokenMailCommand>, SendVerifyTokenMailHandler>();
            services.AddScoped<ICommandHandler<AddWatcherCommand>, AddWatcherHandler>();
            services.AddScoped<ICommandHandler<AddNotificationCacheCommand>, AddNotificationCacheCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateNotificationCacheCommand>, UpdateNotificationCacheCommandHandler>();
            services.AddScoped<IQueryHandler<GetActiveNotificationsQuery, List<GetActiveNotificationsResult>>, GetActiveNotificationsHandler>();
            services.AddScoped<ICommandHandler<AddNotificationEventMemberCacheCommand>, AddNotificationEventMemberCacheCommandHandler>();
            services.AddScoped<ICommandHandler<AddActiveNotificationCountCommand>, AddActiveNotificationCountCommandHandler>();
            services.AddScoped<ICommandHandler<PublishEventNotificationCommand>, PublishEventNotificationCommandHandler>();
            services.AddScoped<IQueryHandler<GetActiveNotificationsCountQuery, GetActiveNotificationsCountQueryResult>, GetActiveNotificationsCountQueryHandler>();
            services.AddScoped<ICommandHandler<AddActiveNotificationCountNewCommand>, AddActiveNotificationCountNewCommandHandler>();
            services.AddScoped<ICommandHandler<NotifyMembersWhenNewAcceptCommand>, NotifyMembersWhenNewAcceptCommandHandler>();
            return services;
        }
    }
}
