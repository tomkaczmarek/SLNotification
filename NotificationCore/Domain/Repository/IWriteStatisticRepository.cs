using NotificationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Domain.Repository
{
    public interface IWriteStatisticRepository
    {
        Task AddLike(LikeStatistic likeStatistic, CancellationToken cancellationToken);
        Task AddWatch(WatchStatistic watchStatistic, CancellationToken cancellationToken);
    }
}
