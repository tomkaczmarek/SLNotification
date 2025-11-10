using Microsoft.Extensions.DependencyInjection;
using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Consumer;
using NotificationCore.Application.Commands.AddNotification;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace NotificationCore.Application.Services
{
    public class RabbitMqConsumer : IMessageConsumer
    {
        private readonly IServiceProvider _serviceProvider;
        public RabbitMqConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public async Task ConsumeMessage<T>(IConnection connection, string queueName, CancellationToken cancellationToken) where T : class, ICommand
        {
            var channel = await connection.CreateChannelAsync(null, cancellationToken);

            var consumer = new AsyncEventingBasicConsumer(channel);

            await channel.QueueDeclareAsync(queue: queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            await channel.BasicConsumeAsync(queue: queueName, autoAck: false, consumer, cancellationToken: cancellationToken);

            consumer.ReceivedAsync += async (sender, eventArg) =>
            {
                var channel = consumer.Channel;
                try
                {
                    var consumer = (AsyncEventingBasicConsumer)sender;
                    
                    using var scope = _serviceProvider.CreateScope();
                    var dispatcher = scope.ServiceProvider.GetRequiredService<ICommandDispatcher>();

                    string message = Encoding.UTF8.GetString(eventArg.Body.ToArray());
                    T commandFromJson = JsonSerializer.Deserialize<T>(message);

                    await dispatcher.SendAsync<T>(commandFromJson, cancellationToken);

                    await channel.BasicAckAsync(eventArg.DeliveryTag, false, cancellationToken);
                }
                catch (Exception ex)
                {
                    await channel.BasicAckAsync(eventArg.DeliveryTag, false, cancellationToken);
                }               
            };
        }
        public void Dispose()
        {
            
        }

        public async Task ConsumeMessageWithExchange<T>(IConnection connection, string queueName, string exchangeName, string rountingKey, CancellationToken cancellationToken) where T : class, ICommand
        {
            var channel = await connection.CreateChannelAsync(null, cancellationToken);
            string routingKey = typeof(T).Name.ToLowerInvariant();

            await channel.ExchangeDeclareAsync(
            exchange: exchangeName,
            type: ExchangeType.Topic, 
            durable: true,
            autoDelete: false);

            await channel.QueueDeclareAsync(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            await channel.QueueBindAsync(
                queue: queueName,
                exchange: exchangeName,
                routingKey: rountingKey);

            var consumer = new AsyncEventingBasicConsumer(channel);

            await channel.BasicConsumeAsync(
                queue: queueName,
                autoAck: false,
                consumer: consumer,
                cancellationToken: cancellationToken);


            consumer.ReceivedAsync += async (sender, eventArg) =>
            {
                var channel = consumer.Channel;
                try
                {
                    var consumer = (AsyncEventingBasicConsumer)sender;

                    using var scope = _serviceProvider.CreateScope();
                    var dispatcher = scope.ServiceProvider.GetRequiredService<ICommandDispatcher>();

                    string message = Encoding.UTF8.GetString(eventArg.Body.ToArray());
                    T commandFromJson = JsonSerializer.Deserialize<T>(message);

                    await dispatcher.SendAsync<T>(commandFromJson, cancellationToken);

                    await channel.BasicAckAsync(eventArg.DeliveryTag, false, cancellationToken);
                }
                catch (Exception ex)
                {
                    await channel.BasicAckAsync(eventArg.DeliveryTag, false, cancellationToken);
                }
            };
        }
    }
}
