using Newtonsoft.Json;
using SEWSE.H1.Commercial.Common.ServiceApi;
using SEWSE.H1.Common.Contracts;
using SEWSE.H1.UX.Infrastructure.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SEWSE.H1.Commercial.UX.Infrastructure.Core.Services
{
    public static class ServiceHelper
    {
        private static HttpClient HttpClient;
        private static readonly string[] Keys = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
        public static Dictionary<string, bool> ServiceDictionary { get; set; }

        /// <summary>
        /// Creates a static instance of the HttpClient. This should only be called once as it is important to reuse th HttpClient where possible.
        /// </summary>
        public static void CreateClient()
        {
            var client = new HttpClient
            {
                Timeout = TimeSpan.FromMinutes(5)
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            HttpClient = client;
        }

        private static ServiceApi GetServiceApi(ServiceEndPointRoutes serviceEndPointRoutes, string parameters = null)
        {
            return new ServiceApi(HttpClient, EndpointHelper.EndpointAddress, "19081", serviceEndPointRoutes, ServiceFabricApplicationsNode.HarnessOneSF, parameters);
        }

        private static bool IsStateful(string endpoint)
        {
            if (ServiceDictionary.ContainsKey(endpoint))
                return ServiceDictionary[endpoint];
            return false;
        }

        #region Post

        /// <summary>
        /// Communicates with the services, sending items to be changed and returning any incorecct or errored items.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="items">Items to process</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        /// <returns>Errored items</returns>
        public static async Task<IEnumerable<T>> ProcessOperation<T>(ServiceEndPointRoutes serviceRoute, IEnumerable<object> items, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).ProcessOperation<T>(items);
        }

        /// <summary>
        /// Communicates with the services, sending items to be changed and returning any incorecct or errored items.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="items">Items to process</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        /// <returns>Errored items</returns>
        public static async Task ProcessOperation(ServiceEndPointRoutes serviceRoute, IEnumerable<object> items, string parameters = null)
        {
            await GetServiceApi(serviceRoute, parameters).ProcessOperation(items);
        }

        /// <summary>
        /// Communicates with the services, sending items through a post call to the WebApi.
        /// </summary>
        /// <typeparam name="T">The returned model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">Items to process</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        /// <returns>Errored items</returns>
        public static async Task<T> Post<T>(ServiceEndPointRoutes serviceRoute, object item = null, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).Post<T>(item);
        }

        /// <summary>
        /// Communicates with the services, sending items through a post call to the WebApi.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">Items to process</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static async Task Post(ServiceEndPointRoutes serviceRoute, object item = null, string parameters = null)
        {
            await GetServiceApi(serviceRoute, parameters).Post(item);
        }

        #endregion

        #region Get

        /// <summary>
        /// Communicates with the services, retrieving all the items.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static async Task<List<T>> GetAll<T>(ServiceEndPointRoutes serviceRoute, string parameters = null)
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
                            var results = JsonConvert.DeserializeObject<List<T>>(Common.Infrastructure.Helpers.Compressor.Decompress(objData));
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

        public static async Task<IEnumerable<T>> GetAllSecureAsync<T>(ServiceEndPointRoutes serviceRoute, IEnumerable<Guid> guidIdentities, string parameters = null)
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
                            var results = JsonConvert.DeserializeObject<List<T>>(Common.Infrastructure.Helpers.Compressor.Decompress(objData));
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

        /// <summary>
        /// Communicates with the services, retrieving all the items that satisfy the fitler.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="filters">The collection of filters used against the items in the service</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static async Task<IEnumerable<T>> GetByFilter<T>(ServiceEndPointRoutes serviceRoute, IEnumerable<FilterCollectionModel> filters, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).GetByFilter<T>(filters);
        }


        /// <summary>
        /// Communicates with the services, performing a Get call through the WebApi.
        /// </summary>
        /// <typeparam name="T">The returned model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static async Task<T> Get<T>(ServiceEndPointRoutes serviceRoute, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).Get<T>();
        }

        #endregion

        #region Update

        /// <summary>
        /// Communicates with the services, performing an update call through the WebApi and retrieving the results.
        /// </summary>
        /// <typeparam name="T">The returned model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">The item for which to update with</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static async Task<T> Update<T>(ServiceEndPointRoutes serviceRoute, object item = null, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).Update<T>(item);
        }

        /// <summary>
        /// Communicates with the services, performing an update call through the WebApi.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">The item for which to update with</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static async Task Update(ServiceEndPointRoutes serviceRoute, object item = null, string parameters = null)
        {
            await GetServiceApi(serviceRoute, parameters).Update(item);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Communicates with the services, performing an delete call through the WebApi and retrieving the results.
        /// </summary>
        /// <typeparam name="T">The returned model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">The item for which to delete with</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static async Task<T> Delete<T>(ServiceEndPointRoutes serviceRoute, object item = null, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).Delete<T>(item);
        }

        /// <summary>
        /// Communicates with the services, performing an delete call through the WebApi.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">The item for which to delete with</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static async Task Delete(ServiceEndPointRoutes serviceRoute, object item = null, string parameters = null)
        {
            await GetServiceApi(serviceRoute, parameters).Delete(item);
        }

        #endregion
    }
}