using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Response;
using NotificationCore.Domain.Entities;
using NotificationCore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.Statistic.AddWatcher
{
    public class AddWatcherHandler : ICommandHandler<AddWatcherCommand>
    {
        private IWriteStatisticRepository repository;

        public AddWatcherHandler(IWriteStatisticRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ApiResponse> HandleAsync(AddWatcherCommand command, CancellationToken cancellationToken)
        {
            var watcher = new WatchStatistic(command.SourceId, command.TargetId);
            await this.repository.AddWatch(watcher, cancellationToken);
            return new ApiResponse();
        }
    }
}
