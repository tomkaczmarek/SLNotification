using NotificationCore.Abstractions.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Infrastructure.DAL.Works
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NotificationDbContext _context;
        public UnitOfWork(NotificationDbContext context)
        {
            _context = context;
        }
        public async Task Execute(Func<Task> action, CancellationToken cancellation)
        {
            using var trans = await _context.Database.BeginTransactionAsync(cancellation);
            try
            {
                await action();
                await trans.CommitAsync(cancellation);
            }
            catch (Exception)
            {
                await trans.RollbackAsync(cancellation);
                throw;
            }
        }
    }
}
