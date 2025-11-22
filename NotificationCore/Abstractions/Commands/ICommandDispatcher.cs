using NotificationCore.Abstractions.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Abstractions.Commands
{
    public interface ICommandDispatcher
    {
        Task<ApiResponse> SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : class, ICommand;      
    }
}
