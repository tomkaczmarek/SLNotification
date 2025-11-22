using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Response;
using NotificationCore.Domain.Entities;
using NotificationCore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.Statistic.AddLike
{
    public class AddLikeHandler : ICommandHandler<AddLikeCommand>
    {
        private IWriteStatisticRepository repository;

        public AddLikeHandler(IWriteStatisticRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ApiResponse> HandleAsync(AddLikeCommand command, CancellationToken cancellationToken)
        {
            var like = new LikeStatistic(command.SourceId, command.TargetId);
            await repository.AddLike(like, cancellationToken);
            return new ApiResponse();
        }
    }
}
