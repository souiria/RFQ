using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Infrastructure.Helpers;
using Common.UX.Api.Endpoints;
using Common.UX.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.UX.Api.Commercial
{
    public class ServiceNonstatic : IServiceNonstatic
    {
        private HttpClient _httpClient = null;
        private static Dictionary<string, bool> ServiceDictionary { get; set; }

        private static readonly string[] Keys = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
        public ServiceNonstatic(HttpClient httpClient, Dictionary<string, bool> serviceDictionary)
        {
            _httpClient = httpClient;
            ServiceDictionary = serviceDictionary;
        }

        private ServiceApi GetServiceApi(ServiceEndpointRoutes serviceEndPointRoutes, string parameters = null)
        {
            return new ServiceApi(_httpClient, EndpointHelper.EndpointAddress, "19081", serviceEndPointRoutes, parameters);
        }
        private static bool IsStateful(string endpoint)
        {
            return ServiceDictionary.ContainsKey(endpoint) && ServiceDictionary[endpoint];
        }

        public async Task<IEnumerable<T>> ProcessOperation<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<object> items, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).ProcessOperation<T>(items);
        }

        public async Task ProcessOperation(ServiceEndpointRoutes serviceRoute, IEnumerable<object> items, string parameters = null)
        {
            await GetServiceApi(serviceRoute, parameters).ProcessOperation(items);
        }

        public async Task<T> Post<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).Post<T>(item);
        }

        public async Task Post(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            await GetServiceApi(serviceRoute, parameters).Post(item);
        }


        public async Task<List<T>> GetAll<T>(ServiceEndpointRoutes serviceRoute, string parameters = null)
        {
            if (IsStateful(serviceRoute))
            {
                var items = new List<T>();
                var tasks = new List<Task>();
                foreach (var key in Keys)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        var objDataList = await GetServiceApi(serviceRoute, $"DictionaryKey/{key}/{parameters}").GetAll<byte[]>();
                        foreach (var objData in objDataList)
                        {
                            var results = JsonConvert.DeserializeObject<List<T>>(objData.Decompress());
                            lock (items)
                                items.AddRange(results);
                        }
                    }));
                }
                await Task.WhenAll(tasks);
                return items;
            }
            else
                return (await GetServiceApi(serviceRoute, parameters).GetAll<T>())?.ToList();
        }

        public async Task<IEnumerable<T>> GetAllSecureAsync<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<Guid> guidIdentities, string parameters = null)
        {
            if (IsStateful(serviceRoute))
            {
                var items = new List<T>();
                var tasks = new List<Task>();
                foreach (var key in Keys)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        var objDataList = await GetServiceApi(serviceRoute, $"ServiceFilter/{key}/{parameters}").Post<IEnumerable<byte[]>>(guidIdentities);
                        foreach (var objData in objDataList)
                        {
                            var results = JsonConvert.DeserializeObject<List<T>>(objData.Decompress());
                            lock (items)
                                items.AddRange(results);
                        }
                    }));
                }
                await Task.WhenAll(tasks);
                return items;
            }
            else
                return (await GetServiceApi(serviceRoute, parameters).GetAll<T>())?.ToList();
        }

        public async Task<IEnumerable<T>> GetByFilter<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<FilterCollectionModel> filters, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).GetByFilter<T>(filters);
        }

        public async Task<T> Get<T>(ServiceEndpointRoutes serviceRoute, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).Get<T>();
        }

        public async Task<T> Update<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).Update<T>(item);
        }

        public async Task Update(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            await GetServiceApi(serviceRoute, parameters).Update(item);
        }
        public async Task<T> Delete<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).Delete<T>(item);
        }

        public async Task Delete(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            await GetServiceApi(serviceRoute, parameters).Delete(item);
        }
    }
}
