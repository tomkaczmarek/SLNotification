using NotificationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Abstractions.Repository
{
    public interface IWriteNotificationRepository
    {
        Task Add(Notification notification, CancellationToken cancellationToken);
    }
}
