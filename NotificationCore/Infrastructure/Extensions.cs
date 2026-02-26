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
using Polly;

namespace NotificationCore.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPolly();
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
            services.AddDbContext<NotificationDbContext>(x => x.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                              npgsqlOptions => npgsqlOptions.CommandTimeout(120)));
            return services;
        }

        private static IServiceCollection AddPolly(this IServiceCollection services)
        {
            services.AddSingleton<IAsyncPolicy>(sp =>
            {
                var retryPolicy = Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(
                        retryCount: 3,
                        sleepDurationProvider: retry => TimeSpan.FromSeconds(Math.Pow(2, retry)),
                        onRetry: (ex, ts, retry, ctx) =>
                        {
                            Console.WriteLine($"[MAIL] Retry {retry} after {ts.TotalSeconds}s");
                        });

                var circuitBreakerPolicy = Policy
                    .Handle<Exception>()
                    .CircuitBreakerAsync(
                        exceptionsAllowedBeforeBreaking: 5,
                        durationOfBreak: TimeSpan.FromSeconds(30),
                        onBreak: (ex, ts) =>
                        {
                            Console.WriteLine("[MAIL] Circuit OPEN");
                        },
                        onReset: () =>
                        {
                            Console.WriteLine("[MAIL] Circuit CLOSED");
                        });

                var timeoutPolicy = Policy.TimeoutAsync(TimeSpan.FromSeconds(10));

                return Policy.WrapAsync(timeoutPolicy, retryPolicy, circuitBreakerPolicy);
            });


            return services;
        }

    }
}
