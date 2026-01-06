using Microsoft.AspNetCore.Mvc;
using NotificationCore.Abstractions.Queries;
using NotificationCore.Abstractions.Response;
using NotificationCore.Application.Queries.GetActiveNotifications;
using NotificationCore.Application.Queries.GetActiveNotificationsCount;

namespace NotificationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {

        private IQueryDispatcher queryDispatcher;

        public NotificationController(IQueryDispatcher queryDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
        }

        [HttpPost("getActiveNotifications")]
        public async Task<ActionResult<ApiResponse<List<GetActiveNotificationsResult>>>> GetActiveNotifications(GetActiveNotificationsQuery query, CancellationToken cancellationToken)
        {
            var result = await queryDispatcher.QueryAsync(query, cancellationToken);

            return StatusCode((int)result.HttpStatusCode, result);
        }

        [HttpPost("getActiveNotificationsCount")]
        public async Task<ActionResult<ApiResponse<GetActiveNotificationsCountQueryResult>>> GetActiveNotificationsCount(GetActiveNotificationsCountQuery query, CancellationToken cancellationToken)
        {
            var result = await queryDispatcher.QueryAsync(query, cancellationToken);

            return StatusCode((int)result.HttpStatusCode, result);
        }
    }
}
