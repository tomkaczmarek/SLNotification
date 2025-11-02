using NotificationCore.Abstractions.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Abstractions.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        Task<ApiResponse> HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}
