using Microsoft.Extensions.DependencyInjection;
using NotificationCore.Abstractions.Queries;
using NotificationCore.Abstractions.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Infrastructure.Dispatchers
{
    public class QuerieDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _service;

        public QuerieDispatcher(IServiceProvider service)
        {
            _service = service;
        }

        public async Task<ApiResponse<TResult>> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken)
        {
            using var scope = _service.CreateScope();
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            var handler = scope.ServiceProvider.GetRequiredService(handlerType);

            if (handler == null)
                return default;

            return await (Task<ApiResponse<TResult>>)handlerType
           .GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))
           ?.Invoke(handler, new object[] { query, cancellationToken });
        }
    }
}
