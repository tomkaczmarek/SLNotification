using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Queries;
using NotificationCore.Abstractions.Repository;
using NotificationCore.Abstractions.Works;
using NotificationCore.Application;
using NotificationCore.Domain.Repository;
using NotificationCore.Infrastructure.DAL;
using NotificationCore.Infrastructure.DAL.Repositories;
using NotificationCore.Infrastructure.DAL.Works;
using NotificationCore.Infrastructure.Dispatchers;
using NotificationCore.Infrastructure.Mailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMailer();
            services.AddCommands();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QuerieDispatcher>();
            services.AddScoped<IWriteNotificationRepository, WriteNotificationRepository>();
            services.AddScoped<IWriteStatisticRepository, WriteStatisticRepository>();
            services.AddScoped<IWriteNotificationCacheRepository, WriteNotifcationCacheRepository>();
            services.AddScoped<IReadNotificationRepository, ReadNotificationRepository>();
            services.AddScoped<IReadNotificationCacheRepository, ReadNotificationCacheRepository>();
            services.AddDbContext<NotificationDbContext>(x => x.UseNpgsql("Host=localhost;Database=ForbandNotification;Username=postgres;Password=12345678",
                              npgsqlOptions => npgsqlOptions.CommandTimeout(120)));
            return services;
        }

    }
}
