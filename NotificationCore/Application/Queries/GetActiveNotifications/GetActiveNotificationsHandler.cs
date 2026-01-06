using NotificationCore.Abstractions.Queries;
using NotificationCore.Abstractions.Repository;
using NotificationCore.Abstractions.Response;
using NotificationCore.Domain.Entities;
using NotificationCore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NotificationCore.Application.Queries.GetActiveNotifications
{
    public class GetActiveNotificationsHandler : IQueryHandler<GetActiveNotificationsQuery, List<GetActiveNotificationsResult>>
    {
        private IReadNotificationRepository _repository;
        private IReadNotificationCacheRepository _cacheRepository;
        private IWriteNotificationRepository _notificationRepository;

        public GetActiveNotificationsHandler(IReadNotificationRepository repository, IReadNotificationCacheRepository cacheRepository, IWriteNotificationRepository notificationRepository)
        {
            _repository = repository;
            _cacheRepository = cacheRepository;
            _notificationRepository = notificationRepository;
        }

        public async Task<ApiResponse<List<GetActiveNotificationsResult>>> HandleAsync(GetActiveNotificationsQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetActiveNotifications(query.RecipientId, query.SkipOffset, cancellationToken);

            if(result.Count > 0)
            {
                if (query.ActiveNotificationsCount > 0)
                    await _notificationRepository.ResetNotificationsCount(query.RecipientId, cancellationToken);

                Dictionary<int, NotificationPayload> payloadDict = result.ToDictionary(x => x.Id.Value, y => JsonSerializer.Deserialize<NotificationPayload>(y.NoticationBody));
                List<NotificationPayload> payLoad = result.Select(x => JsonSerializer.Deserialize<NotificationPayload>(x.NoticationBody)).ToList();
                List<Guid> sourcesId = payLoad.SelectMany(n => new Guid?[] { n.SourceId, n.DestinationId, n.CoordinatorId })
                                        .Where(g => g.HasValue)
                                        .Select(g => g.Value)
                                        .Distinct()  
                                        .ToList();

                var cacheResult = await _cacheRepository.GetFromCache(sourcesId, cancellationToken);

                if(cacheResult.Count > 0)
                {
                    var cacheToDictionary = cacheResult.Distinct().ToDictionary(x => x.SourceId, y => y);

                    List<GetActiveNotificationsResult> itemsResult = new List<GetActiveNotificationsResult>();
                    foreach (var r in result)
                    {
                        GetActiveNotificationsResult item = new GetActiveNotificationsResult()
                        {
                            Id = r.Id,
                            CreatedAt = r.CreatedAt,
                            IsActive = r.IsActive,
                            NotificationType = r.NotificationType
                        };

                        if(payloadDict.ContainsKey(r.Id.Value))
                        {
                            var payitem = payloadDict[r.Id.Value];

                            if(cacheToDictionary.ContainsKey(payitem.SourceId.GetValueOrDefault()))
                            {
                                payitem.SourceName = cacheToDictionary[payitem.SourceId.GetValueOrDefault()].Name;
                                payitem.SourceDomainObjectsType = cacheToDictionary[payitem.SourceId.GetValueOrDefault()].DomainObjectsType;
                            }

                            if (cacheToDictionary.ContainsKey(payitem.CoordinatorId.GetValueOrDefault()))
                            {
                                payitem.CoordinatorName = cacheToDictionary[payitem.CoordinatorId.GetValueOrDefault()].Name;
                                payitem.CoordinatorDomainObjectsType = cacheToDictionary[payitem.CoordinatorId.GetValueOrDefault()].DomainObjectsType;
                            }

                            if (cacheToDictionary.ContainsKey(payitem.DestinationId.GetValueOrDefault()))
                            {
                                payitem.DestinationName = cacheToDictionary[payitem.DestinationId.GetValueOrDefault()].Name;
                                payitem.DestinationDomainObjectsType = cacheToDictionary[payitem.DestinationId.GetValueOrDefault()].DomainObjectsType;
                            }
                            item.NotificationPayload = payitem;
                        }

                        itemsResult.Add(item);
                    } 
                    
                    return new ApiResponse<List<GetActiveNotificationsResult>> 
                    { 
                        Result = itemsResult 
                    };
                }
            }

            return new ApiResponse<List<GetActiveNotificationsResult>>();
        }      
    }
}
