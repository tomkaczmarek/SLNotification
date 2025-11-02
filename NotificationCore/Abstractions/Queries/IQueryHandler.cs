using NotificationCore.Abstractions.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Abstractions.Queries
{
    public interface IQueryHandler<in IQuery, TResult> where IQuery : class, IQuery<TResult>
    {
        Task<ApiResponse<TResult>> HandleAsync(IQuery query, CancellationToken cancellationToken);
    }
}
