using Microsoft.Extensions.Hosting;
using NotificationCore.Abstractions.Consumer;
using NotificationCore.Application.Commands.AddNotification;
using NotificationCore.Application.Commands.AddNotificationCache;
using NotificationCore.Application.Commands.Mailers.SendVerifyTokenMail;
using NotificationCore.Application.Commands.Statistic.AddWatcher;
using NotificationCore.Application.Commands.UpdateNotificationCache;
using RabbitMQ.Client;

namespace NotificationCore.Application.Services
{
    public class RabbitConsumerBackground : BackgroundService
    {
        private IMessageConsumer _consumer;
        private IConnection _connection;
        private ConnectionFactory _connectionFactory;

        public RabbitConsumerBackground(IMessageConsumer consumer)
        {
            _connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            _consumer = consumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _connection = await _connectionFactory.CreateConnectionAsync(stoppingToken);

            await _consumer.ConsumeMessageWithExchange<AddNotificationCommand>(_connection, "AddNewNotificationEvent", "notificationExchange", "notification.addnew", stoppingToken);
            await _consumer.ConsumeMessage<SendVerifyTokenMailCommand>(_connection, "SendMailTokenVerifyEvent", stoppingToken);
            await _consumer.ConsumeMessage<AddWatcherCommand>(_connection, "AddWatcherEvent", stoppingToken);
            await _consumer.ConsumeMessage<AddNotificationCacheCommand>(_connection, "AddNotificationCacheEvent", stoppingToken);
            await _consumer.ConsumeMessage<UpdateNotificationCacheCommand>(_connection, "UpdateNotificationCacheEvent", stoppingToken);

            var tcs = new TaskCompletionSource();
            using (stoppingToken.Register(() => tcs.TrySetResult()))
            {
                await tcs.Task;
            }
        }

        public override void Dispose()
        {
            _consumer.Dispose();
            _connection.Dispose();
            base.Dispose();
        }
    }
}
