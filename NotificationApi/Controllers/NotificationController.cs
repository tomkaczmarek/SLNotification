using Microsoft.AspNetCore.Mvc;
using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Queries;
using NotificationCore.Abstractions.Response;
using NotificationCore.Application.Commands.Configuration.DeleteTables;
using NotificationCore.Application.Queries.GetActiveNotifications;
using NotificationCore.Application.Queries.GetActiveNotificationsCount;

namespace NotificationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {

        private IQueryDispatcher queryDispatcher;
        private ICommandDispatcher commandDispatcher;

        public NotificationController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
            this.commandDispatcher = commandDispatcher;
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

        [HttpDelete("deleteTables")]
        public async Task<ActionResult<ApiResponse<GetActiveNotificationsCountQueryResult>>> DeleteTables(CancellationToken cancellationToken)
        {
            var result = await commandDispatcher.SendAsync(new DeleteTablesCommand(), cancellationToken);

            return StatusCode((int)result.HttpStatusCode, result);
        }
    }
}
