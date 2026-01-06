using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Abstractions.Works
{
    public interface IUnitOfWork
    {
        Task Execute(Func<Task> action, CancellationToken cancellation);
    }
}
