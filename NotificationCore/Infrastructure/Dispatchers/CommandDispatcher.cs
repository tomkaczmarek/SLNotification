using Microsoft.Extensions.DependencyInjection;
using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Response;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Infrastructure.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _services;

        public CommandDispatcher(IServiceProvider services)
        {
            _services = services;
        }

        public async Task<ApiResponse> SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : class, ICommand
        {
            if (command is null)
                return null;

            using var scope = _services.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            if (handler != null)
                return await handler.HandleAsync(command, cancellationToken);

            return null;
        }
    }
}
