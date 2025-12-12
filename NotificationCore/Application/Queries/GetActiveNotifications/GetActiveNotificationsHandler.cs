using NotificationCore.Abstractions.Queries;
using NotificationCore.Abstractions.Repository;
using NotificationCore.Abstractions.Response;
using NotificationCore.Domain.Entities;
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

        public GetActiveNotificationsHandler(IReadNotificationRepository repository, IReadNotificationCacheRepository cacheRepository)
        {
            _repository = repository;
            _cacheRepository = cacheRepository;
        }

        public async Task<ApiResponse<List<GetActiveNotificationsResult>>> HandleAsync(GetActiveNotificationsQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetActiveNotifications(query.RecipientId, query.SkipOffset, cancellationToken);

            if(result.Count > 0)
            {
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
                    var cacheToDictionary = cacheResult.ToDictionary(x => x.SourceId, y => y);

                    List<GetActiveNotificationsResult> itemsResult = new List<GetActiveNotificationsResult>();
                    foreach (var r in result)
                    {
                        GetActiveNotificationsResult item = new GetActiveNotificationsResult()
                        {
                            Id = r.Id,
                            CreatedAt = r.CreatedAt,
                            IsActive = r.IsActive,
                            Key = r.Key
                        };

                        if(payloadDict.ContainsKey(r.Id.Value))
                        {
                            var payitem = payloadDict[r.Id.Value];

                            if(cacheToDictionary.ContainsKey(payitem.SourceId.GetValueOrDefault()))
                            {
                                payitem.SourceAvatarId = cacheToDictionary[payitem.SourceId.GetValueOrDefault()].AvatarId;
                                payitem.SourceName = cacheToDictionary[payitem.SourceId.GetValueOrDefault()].Name;
                            }

                            if (cacheToDictionary.ContainsKey(payitem.CoordinatorId.GetValueOrDefault()))
                            {
                                payitem.CoordinatorAvatarId = cacheToDictionary[payitem.CoordinatorId.GetValueOrDefault()].AvatarId;
                                payitem.CoordinatorName = cacheToDictionary[payitem.CoordinatorId.GetValueOrDefault()].Name;
                            }

                            if (cacheToDictionary.ContainsKey(payitem.DestinationId.GetValueOrDefault()))
                            {
                                payitem.DestinationAvatarId = cacheToDictionary[payitem.DestinationId.GetValueOrDefault()].AvatarId;
                                payitem.DestinationName = cacheToDictionary[payitem.DestinationId.GetValueOrDefault()].Name;
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
