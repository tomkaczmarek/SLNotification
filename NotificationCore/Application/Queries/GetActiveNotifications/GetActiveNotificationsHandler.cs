using NotificationCore.Abstractions.Queries;
using NotificationCore.Abstractions.Repository;
using NotificationCore.Abstractions.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Queries.GetActiveNotifications
{
    public class GetActiveNotificationsHandler : IQueryHandler<GetActiveNotificationsQuery, List<GetActiveNotificationsResult>>
    {
        private IReadNotificationRepository _repository;

        public GetActiveNotificationsHandler(IReadNotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<List<GetActiveNotificationsResult>>> HandleAsync(GetActiveNotificationsQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetActiveNotifications(query.RecipientId, query.SkipOffset, cancellationToken);

            return new ApiResponse<List<GetActiveNotificationsResult>>
            {
                Result = result.Select(x => new GetActiveNotificationsResult()
                {
                    Body = x.NoticationBody,
                    CreatedAt = x.CreatedAt,
                    Id = x.Id,
                    Key = x.Key,
                    IsActive = x.IsActive
                }).ToList()
            };
        }
    }
}
