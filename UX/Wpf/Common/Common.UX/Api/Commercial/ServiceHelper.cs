using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Infrastructure.Helpers;
using Common.UX.Api.Endpoints;
using Common.UX.Helpers;
using Newtonsoft.Json;

namespace Common.UX.Api.Commercial
{
    //TODO: Merge class with ServiceApi.
    //TODO: Enquire whether it is still necessary to create the Service Dictionary manually. Would it be beneficial for the api to check the partitions on connecting instead.

    public static class ServiceHelper
    {
        private static HttpClient _httpClient;
        public static Dictionary<string, bool> ServiceDictionary { get; set; }
        private static readonly string[] Keys = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
        public static IServiceNonstatic nonstatic;

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
            _httpClient = client;
        }

        private static ServiceApi GetServiceApi(ServiceEndpointRoutes serviceEndPointRoutes, string parameters = null)
        {
            return new ServiceApi(_httpClient, EndpointHelper.EndpointAddress, "19081", serviceEndPointRoutes, parameters);
        }

        private static bool IsStateful(string endpoint)
        {
            return ServiceDictionary.ContainsKey(endpoint) && ServiceDictionary[endpoint];
        }

        #region Post

        /// <summary>
        /// Communicates with the services, sending items to be changed and returning any incorrect or errored items.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="items">Items to process</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        /// <returns>Errored items</returns>
        public static async Task<IEnumerable<T>> ProcessOperation<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<object> items, string parameters = null)
        {
            if(nonstatic == null)
                nonstatic = new ServiceNonstatic(_httpClient,ServiceDictionary);
            return await nonstatic.ProcessOperation<T>(serviceRoute, items, parameters);
        }

        /// <summary>
        /// Communicates with the services, sending items to be changed and returning any incorrect or errored items.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="items">Items to process</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        /// <returns>Errored items</returns>
        public static async Task ProcessOperation(ServiceEndpointRoutes serviceRoute, IEnumerable<object> items, string parameters = null)
        {
            if (nonstatic == null)
                nonstatic = new ServiceNonstatic(_httpClient, ServiceDictionary);
            await nonstatic.ProcessOperation(serviceRoute, items, parameters);
        }

        /// <summary>
        /// Communicates with the services, sending items through a post call to the WebApi.
        /// </summary>
        /// <typeparam name="T">The returned model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">Items to process</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        /// <returns>Errored items</returns>
        public static async Task<T> Post<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            if (nonstatic == null)
                nonstatic = new ServiceNonstatic(_httpClient, ServiceDictionary);
            return await nonstatic.Post<T>(serviceRoute, item, parameters);
        }

        /// <summary>
        /// Communicates with the services, sending items through a post call to the WebApi.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">Items to process</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static async Task Post(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            if (nonstatic == null)
                nonstatic = new ServiceNonstatic(_httpClient, ServiceDictionary);
            await nonstatic.Post(serviceRoute, item, parameters);
        }

        #endregion

        #region Get

        /// <summary>
        /// Communicates with the services, retrieving all the items.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static async Task<List<T>> GetAll<T>(ServiceEndpointRoutes serviceRoute, string parameters = null)
        {
            if (nonstatic == null)
                nonstatic = new ServiceNonstatic(_httpClient, ServiceDictionary);
            return await nonstatic.GetAll<T>(serviceRoute, parameters);
        }

        public static async Task<IEnumerable<T>> GetAllSecureAsync<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<Guid> guidIdentities, string parameters = null)
        {
            if (nonstatic == null)
                nonstatic = new ServiceNonstatic(_httpClient, ServiceDictionary);
            return await nonstatic.GetAllSecureAsync<T>(serviceRoute, guidIdentities, parameters);
        }

        /// <summary>
        /// Communicates with the services, retrieving all the items that satisfy the filter.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="filters">The collection of filters used against the items in the service</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static async Task<IEnumerable<T>> GetByFilter<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<FilterCollectionModel> filters, string parameters = null)
        {
            if (nonstatic == null)
                nonstatic = new ServiceNonstatic(_httpClient, ServiceDictionary);
            return await nonstatic.GetByFilter<T>(serviceRoute, filters, parameters);
        }


        /// <summary>
        /// Communicates with the services, performing a Get call through the WebApi.
        /// </summary>
        /// <typeparam name="T">The returned model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static async Task<T> Get<T>(ServiceEndpointRoutes serviceRoute, string parameters = null)
        {
            if (nonstatic == null)
                nonstatic = new ServiceNonstatic(_httpClient, ServiceDictionary);
            return await nonstatic.Get<T>(serviceRoute, parameters);
        }

        #endregion

        #region Update

        /// <summary>
        /// Communicates with the services, performing an update call through the WebApi and retrieving the results.
        /// </summary>
        /// <typeparam name="T">The returned model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">The item for which to update with</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static async Task<T> Update<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            if (nonstatic == null)
                nonstatic = new ServiceNonstatic(_httpClient, ServiceDictionary);
            return await nonstatic.Update<T>(serviceRoute, item, parameters);
        }

        /// <summary>
        /// Communicates with the services, performing an update call through the WebApi.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">The item for which to update with</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static async Task Update(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            if (nonstatic == null)
                nonstatic = new ServiceNonstatic(_httpClient, ServiceDictionary);
            await nonstatic.Update(serviceRoute, item, parameters);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Communicates with the services, performing an delete call through the WebApi and retrieving the results.
        /// </summary>
        /// <typeparam name="T">The returned model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">The item for which to delete with</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static async Task<T> Delete<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            if (nonstatic == null)
                nonstatic = new ServiceNonstatic(_httpClient, ServiceDictionary);
            return await nonstatic.Delete<T>(serviceRoute, item, parameters);

        }

        /// <summary>
        /// Communicates with the services, performing an delete call through the WebApi.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">The item for which to delete with</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static async Task Delete(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            if (nonstatic == null)
                nonstatic = new ServiceNonstatic(_httpClient, ServiceDictionary);
            await nonstatic.Delete(serviceRoute, item, parameters);
        }

        #endregion

        //TODO: Remove old Base64 methods once its use has been dropped.

        #region Base64 Old Methods 
        
        #region Post

        /// <summary>
        /// Communicates with the services, sending items to be changed and returning any incorrect or errored items.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="items">Items to process</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and receive data compressed</param>
        /// <returns>Errored items</returns>
        public static IEnumerable<T> Base64ProcessOperation<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<object> items, string parameters = null, bool compress = true)
        {
            return compress ? GetServiceApi(serviceRoute, parameters).OldProcessOperation<T>(items) : GetServiceApi(serviceRoute, parameters).OldProcessOperationUncompressed<T>(items);
        }

        /// <summary>
        /// Communicates with the services, sending items to be changed and returning any incorrect or errored items.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="items">Items to process</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and receive data compressed</param>
        /// <returns>Errored items</returns>
        public static void Base64ProcessOperation(ServiceEndpointRoutes serviceRoute, IEnumerable<object> items, string parameters = null, bool compress = true)
        {
            if (compress)
                GetServiceApi(serviceRoute, parameters).OldProcessOperation(items);
            else
                GetServiceApi(serviceRoute, parameters).OldProcessOperationUncompressed(items);
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
        public static T Base64Post<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
        {
            if (compress)
                return GetServiceApi(serviceRoute, parameters).OldPost<T>(item);
            else
                return GetServiceApi(serviceRoute, parameters).OldPostUncompressed<T>(item);
        }

        /// <summary>
        /// Communicates with the services, sending items through a post call to the WebApi.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">Items to process</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static void Base64Post(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
        {
            if (compress)
                GetServiceApi(serviceRoute, parameters).OldPost(item);
            else
                GetServiceApi(serviceRoute, parameters).OldPostUncompressed(item);
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
        public static List<T> Base64GetAll<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, bool compress = true)
        {
            if (compress)
                return GetServiceApi(serviceRoute, parameters).OldGetAll<T>()?.ToList();
            else
                return GetServiceApi(serviceRoute, parameters).OldGetAllUncompressed<T>()?.ToList();
        }

        /// <summary>
        /// Communicates with the services, retrieving all the items.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static async Task<IEnumerable<T>> Base64GetAllAsync<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, bool compress = true)
        {
            if (IsStateful(serviceRoute))
            {
                var items = new List<T>();
                var tasks = new List<Task>();
                foreach (var key in Keys)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        var objDataList = await GetServiceApi(serviceRoute, $"DictionaryKey/{key}/{parameters}").OldGetAllAsync();
                        foreach (var objData in objDataList)
                        {
                            var results = JsonConvert.DeserializeObject<List<T>>(objData.DecompressBase64());
                            lock (items)
                                items.AddRange(results);
                        }
                    }));
                }
                await Task.WhenAll(tasks);
                return items;
            }
            else
            {
                return await GetServiceApi(serviceRoute, parameters).OldGetAllAsync<IEnumerable<T>>();
            }
        }

        /// <summary>
        /// Communicates with the services, retrieving all the items that satisfy the fitler.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="filters">The collection of filters used against the items in the service</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static IEnumerable<T> Base64GetByFilter<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<FilterCollectionModel> filters, string parameters = null, bool compress = true)
        {
            if (compress)
                return GetServiceApi(serviceRoute, parameters).OldGetByFilter<T>(filters);
            else
                return GetServiceApi(serviceRoute, parameters).OldGetByFilterUncompressed<T>(filters);
        }

        /// <summary>
        /// Communicates with the services, post uncompressed data and get data after decomressing.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="obj">The object to be sent to the service</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static IEnumerable<T> Base64PostAndGet<T>(ServiceEndpointRoutes serviceRoute, object obj, string parameters = null)
        {
            return GetServiceApi(serviceRoute, parameters).OldPostAndGet<T>(obj);
        }

        /// <summary>
        /// Communicates with the services, performing a Get call through the WebApi.
        /// </summary>
        /// <typeparam name="T">The returned model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and receive data compressed</param>
        public static T Base64Get<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, bool compress = true)
        {
            if (compress)
                return GetServiceApi(serviceRoute, parameters).OldGet<T>();
            else
                return GetServiceApi(serviceRoute, parameters).OldGetUncompressed<T>();
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
        public static T Base64Update<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
        {
            if (compress)
                return GetServiceApi(serviceRoute, parameters).OldUpdate<T>(item);
            else
                return GetServiceApi(serviceRoute, parameters).OldUpdateUncompressed<T>(item);
        }

        /// <summary>
        /// Communicates with the services, performing an update call through the WebApi.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">The item for which to update with</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static void Base64Update(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
        {
            if (compress)
                GetServiceApi(serviceRoute, parameters).OldUpdate(item);
            else
                GetServiceApi(serviceRoute, parameters).OldUpdateUncompressed(item);
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
        public static T Base64Delete<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
        {
            if (compress)
                return GetServiceApi(serviceRoute, parameters).OldDelete<T>(item);
            else
                return GetServiceApi(serviceRoute, parameters).OldDeleteUncompressed<T>(item);
        }

        /// <summary>
        /// Communicates with the services, performing an delete call through the WebApi.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">The item for which to delete with</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static void Base64Delete(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
        {
            if (compress)
                GetServiceApi(serviceRoute, parameters).OldDelete(item);
            else
                GetServiceApi(serviceRoute, parameters).OldDeleteUncompressed(item);
        }

        #endregion

        #endregion
    }
}
