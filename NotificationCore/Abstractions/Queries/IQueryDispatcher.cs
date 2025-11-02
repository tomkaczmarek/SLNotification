using NotificationCore.Abstractions.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Abstractions.Queries
{
    public interface IQueryDispatcher
    {
        Task<ApiResponse<TResult>> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken);
    }
}
