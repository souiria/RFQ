using Newtonsoft.Json;
using SEWSE.H1.Common.Contracts;
using SEWSE.H1.Common.Infrastructure.Helpers;
using SEWSE.H1.Common.ServiceApi;
using SEWSE.H1.UX.Infrastructure.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEWSE.H1.UX.Infrastructure.Core.Services
{
    public static class ServiceHelper
    {
        private static string[] Keys = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
        public static Dictionary<string, bool> ServiceDictionary { get; set; }

        private static ServiceApi GetServiceApi(ServiceEndPointRoutes serviceEndPointRoutes, string parameters = null)
        {
            return new ServiceApi(EndpointHelper.EndpointAddress, "19081", serviceEndPointRoutes, ServiceFabricApplicationsNode.HarnessOneSF, parameters);
        }

        private static bool IsStateful(string endpoint)
        {
            return ServiceDictionary[endpoint];
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
        public static IEnumerable<T> ProcessOperation<T>(ServiceEndPointRoutes serviceRoute, IEnumerable<object> items, string parameters = null, bool compress = true)
        {
            if (compress)
                return GetServiceApi(serviceRoute, parameters).ProcessOperation<T>(items);
            else
                return GetServiceApi(serviceRoute, parameters).ProcessOperationUncompressed<T>(items);
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
        public static void ProcessOperation(ServiceEndPointRoutes serviceRoute, IEnumerable<object> items, string parameters = null, bool compress = true)
        {
            if (compress)
                GetServiceApi(serviceRoute, parameters).ProcessOperation(items);
            else
                GetServiceApi(serviceRoute, parameters).ProcessOperationUncompressed(items);
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
        public static T Post<T>(ServiceEndPointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
        {
            if (compress)
                return GetServiceApi(serviceRoute, parameters).Post<T>(item);
            else
                return GetServiceApi(serviceRoute, parameters).PostUncompressed<T>(item);
        }

        /// <summary>
        /// Communicates with the services, sending items through a post call to the WebApi.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">Items to process</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static void Post(ServiceEndPointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
        {
            if (compress)
                GetServiceApi(serviceRoute, parameters).Post(item);
            else
                GetServiceApi(serviceRoute, parameters).PostUncompressed(item);
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
        public static List<T> GetAll<T>(ServiceEndPointRoutes serviceRoute, string parameters = null, bool compress = true)
        {
            if (compress)
                return GetServiceApi(serviceRoute, parameters).GetAll<T>()?.ToList();
            else
                return GetServiceApi(serviceRoute, parameters).GetAllUncompressed<T>()?.ToList();
        }

        /// <summary>
        /// Communicates with the services, retrieving all the items.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static async Task<IEnumerable<T>> GetAllAsync<T>(ServiceEndPointRoutes serviceRoute, string parameters = null, bool compress = true)
        {
            if (IsStateful(serviceRoute))
            {
                var items = new List<T>();
                var tasks = new List<Task>();
                foreach (var key in Keys)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        var objDataList = await GetServiceApi(serviceRoute, $"DictionaryKey/{key}/{parameters}").GetAllAsync();
                        foreach (var objData in objDataList)
                        {
                            var results = JsonConvert.DeserializeObject<List<T>>(Compressor.Decompress(objData));
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
                return await GetServiceApi(serviceRoute, parameters).GetAllAsync<IEnumerable<T>>();
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
        public static IEnumerable<T> GetByFilter<T>(ServiceEndPointRoutes serviceRoute, IEnumerable<FilterCollectionModel> filters, string parameters = null, bool compress = true)
        {
            if (compress)
                return GetServiceApi(serviceRoute, parameters).GetByFilter<T>(filters);
            else
                return GetServiceApi(serviceRoute, parameters).GetByFilterUncompressed<T>(filters);
        }
        /// <summary>
        /// Communicates with the services, post uncompressed data and get data after decomressing.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="filters">The collection of filters used against the items in the service</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        public static IEnumerable<T> PostAndGet<T>(ServiceEndPointRoutes serviceRoute, object obj, string parameters = null)
        {
            return GetServiceApi(serviceRoute, parameters).PostAndGet<T>(obj);
        }

        /// <summary>
        /// Communicates with the services, performing a Get call through the WebApi.
        /// </summary>
        /// <typeparam name="T">The returned model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static T Get<T>(ServiceEndPointRoutes serviceRoute, string parameters = null, bool compress = true)
        {
            if (compress)
                return GetServiceApi(serviceRoute, parameters).Get<T>();
            else
                return GetServiceApi(serviceRoute, parameters).GetUncompressed<T>();
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
        public static T Update<T>(ServiceEndPointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
        {
            if (compress)
                return GetServiceApi(serviceRoute, parameters).Update<T>(item);
            else
                return GetServiceApi(serviceRoute, parameters).UpdateUncompressed<T>(item);
        }

        /// <summary>
        /// Communicates with the services, performing an update call through the WebApi.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">The item for which to update with</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static void Update(ServiceEndPointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
        {
            if (compress)
                GetServiceApi(serviceRoute, parameters).Update(item);
            else
                GetServiceApi(serviceRoute, parameters).UpdateUncompressed(item);
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
        public static T Delete<T>(ServiceEndPointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
        {
            if (compress)
                return GetServiceApi(serviceRoute, parameters).Delete<T>(item);
            else
                return GetServiceApi(serviceRoute, parameters).DeleteUncompressed<T>(item);
        }

        /// <summary>
        /// Communicates with the services, performing an delete call through the WebApi.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">The item for which to delete with</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static void Delete(ServiceEndPointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
        {
            if (compress)
                GetServiceApi(serviceRoute, parameters).Delete(item);
            else
                GetServiceApi(serviceRoute, parameters).DeleteUncompressed(item);
        }

        #endregion
    }
}