using NotificationCore.Abstractions.Commands;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Abstractions.Consumer
{
    public interface IMessageConsumer
    {
        Task ConsumeMessage<T>(IConnection _connection, string queueName, CancellationToken cancellationToken) where T : class, ICommand;

        Task ConsumeMessageWithExchange<T>(IConnection connection, string queueName, string exchangeName, string rountingKey, CancellationToken cancellationToken) where T : class, ICommand;

        void Dispose();
    }
}
