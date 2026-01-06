using NotificationCore.Abstractions.Queries;
using NotificationCore.Abstractions.Repository;
using NotificationCore.Abstractions.Response;


namespace NotificationCore.Application.Queries.GetActiveNotificationsCount
{
    public class GetActiveNotificationsCountQueryHandler : IQueryHandler<GetActiveNotificationsCountQuery, GetActiveNotificationsCountQueryResult>
    {
        private IReadNotificationRepository _repository;

        public GetActiveNotificationsCountQueryHandler(IReadNotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<GetActiveNotificationsCountQueryResult>> HandleAsync(GetActiveNotificationsCountQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetActiveNotificationsCount(query.ProfileId, cancellationToken);

            return new ApiResponse<GetActiveNotificationsCountQueryResult>()
            {
                Result = new GetActiveNotificationsCountQueryResult()
                {
                    Count = result
                }
            };
        }
    }
}
