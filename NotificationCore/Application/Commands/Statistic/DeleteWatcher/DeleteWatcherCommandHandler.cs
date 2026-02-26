using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Response;
using NotificationCore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.Statistic.DeleteWatcher
{
    public class DeleteWatcherCommandHandler : ICommandHandler<DeleteWatcherCommand>
    {
        private IWriteStatisticRepository repository;

        public DeleteWatcherCommandHandler(IWriteStatisticRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ApiResponse> HandleAsync(DeleteWatcherCommand command, CancellationToken cancellationToken)
        {
            await repository.DeleteWatcher(new Domain.Entities.Watcher(command.SourceId, command.TargetId), cancellationToken);
            return new ApiResponse();
        }
    }
}
