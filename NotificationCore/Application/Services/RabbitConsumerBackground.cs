using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Consumer;
using NotificationCore.Application.Commands.AddNotification;
using NotificationCore.Application.Commands.Mailers.SendVerifyTokenMail;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

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

            await _consumer.ConsumeMessage<AddNotificationCommand>(_connection, "AddNewNotificationEvent", stoppingToken);
            await _consumer.ConsumeMessage<SendVerifyTokenMailCommand>(_connection, "SendMailTokenVerifyEvent", stoppingToken);
           
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

        private Type? CommandTypeFactory(string? routingKey)
        {
            return routingKey switch
            {
                "CreateAccountMailerEvent" => typeof(AddNotificationCommand),
                _ => null
            };
        }

        private ICommand CommandFactory(string commandName)
        {
            switch(commandName)
            {
                case "CreateAccountMailerEvent":
                    return new AddNotificationCommand();
                default:
                    return null;
                        
            }
        }
    }
}
