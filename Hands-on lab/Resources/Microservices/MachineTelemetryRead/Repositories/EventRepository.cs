using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MachineTelemetryRead.Interfaces;
using MachineTelemetryRead.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Common.DTOs;
using Common.Utils;

namespace MachineTelemetryRead.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly Container _container;

        public EventRepository()
        {
            var accountEndpoint = EnvUtils.Get("COSMOS_DB_ACCOUNT_ENDPOINT");
            var authKey = EnvUtils.Get("COSMOS_DB_AUTH_KEY");
            var client = new CosmosClient(accountEndpoint, authKey, new CosmosClientOptions
            {
                SerializerOptions = new CosmosSerializationOptions
                {
                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase,
                }
            });
            _container = client.GetContainer("sensors", "telemetry");
        }
        
        public async Task<List<MachineTelemetry>> GetAllEventsAsync(int limit, int skip)
        {
            using var feedIterator = _container.GetItemLinqQueryable<MachineTelemetry>()
                .Skip(skip)
                .Take(limit)
                .ToFeedIterator();

            return await GetAllItemsFromIterator(feedIterator);
        }

        private async Task<List<T>> GetAllItemsFromIterator<T>(FeedIterator<T> feedIterator)
        {
            var mt = new List<T>();

            while (feedIterator.HasMoreResults)
            {
                mt.AddRange(await feedIterator.ReadNextAsync());
            }

            return mt;
        }
    }
}