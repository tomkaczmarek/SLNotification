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
    public class AddWatcherCommandHandler : ICommandHandler<AddWatcherCommand>
    {
        private IWriteStatisticRepository repository;

        public AddWatcherCommandHandler(IWriteStatisticRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ApiResponse> HandleAsync(AddWatcherCommand command, CancellationToken cancellationToken)
        {
            var watcher = new Watcher(command.SourceId, command.TargetId, command.SourceDomainObject, command.TargetDomainObject);
            await this.repository.AddWatcher(watcher, cancellationToken);
            return new ApiResponse();
        }
    }
}
