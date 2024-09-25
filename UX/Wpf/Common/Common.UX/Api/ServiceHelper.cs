/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ServiceHelper.cs
Function           :   Communication bridge of Services/Client
Created By         :   Amit
Created on         :   07-Mar-2018
Revision History   :   [11-Mar-2019] : Amit Agarwal
*                  :   [] : Method modified for provide mocking
*                  :   [14-Oct-2019] : Srashti Gupta
*                  :   [] : Added the GetAllFieldsSelector(), GetAllAsyncFieldsSelector(), GetByFilterColumns() for interaction between the Services/Client.
*                  :   [09-Oct-2020] : Shivam Dhingra
*                  :   [] : Overloaded GetAll() method to accept string parameters
*                  :   [16-Oct-2020] : Srashti Gupta
*                  :   [] : Remove Overloaded GetAll() method to accept string parameters
*********************************************************************************************************************************/
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Infrastructure.Helpers;
using Common.UX.Api.Endpoints;
using Common.UX.Contracts.Interfaces.Core;
using Common.UX.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.UX.Api
{

    public static class ServiceHelper
    {
        private static readonly string[] Keys = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
        public static Dictionary<string, bool> ServiceDictionary { get; set; }

        public static IServiceApiProxy ServiceApiProxy = null;


        private static ServiceApi GetServiceApi(ServiceEndpointRoutes serviceEndPointRoutes, string parameters = null)
        {
            return new ServiceApi(EndpointHelper.EndpointAddress, "19081", serviceEndPointRoutes, parameters);
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
        /// <param name="compress">Whether the method should compress passed items and receive data compressed</param>
        /// <returns>Errored items</returns>
        public static async Task<IEnumerable<T>> ProcessOperation<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<object> items, string parameters = null, bool compress = true)
        {
            if (ServiceApiProxy == null)
                ServiceApiProxy = new ServiceApiProxy(ServiceDictionary);

            if (compress)
                return await ServiceApiProxy.ProcessOperation<T>(serviceRoute, items);
            else
                return GetServiceApi(serviceRoute, parameters).ProcessOperationUncompressed<T>(items);
        }

        /// <summary>
        /// Communicates with the services, sending items to be changed and returning any incorrect or errored items.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="items">Items to process</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and receive data compressed</param>
        /// <returns>Errored items</returns>
        public static void ProcessOperation(ServiceEndpointRoutes serviceRoute, IEnumerable<object> items, string parameters = null, bool compress = true)
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
        public static T Post<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
        {
            if (ServiceApiProxy == null)
                ServiceApiProxy = new ServiceApiProxy(ServiceDictionary);

            if (compress)
                return  ServiceApiProxy.Post<T>(serviceRoute, item, parameters);//return GetServiceApi(serviceRoute, parameters).Post<T>(item);
            else
                return GetServiceApi(serviceRoute, parameters).PostUncompressed<T>(item);
        }
        /// <summary>
        /// Communicates with the services, sending items with byte array through a post call to the WebApi and get byte array.
        /// </summary>
        /// <typeparam name="T">The returned model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">Items to process</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <returns>Errored items</returns>
        public static async Task<T> PostByteArray<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            if (ServiceApiProxy == null)
                ServiceApiProxy = new ServiceApiProxy(ServiceDictionary);
            return await ServiceApiProxy.PostByteArray<T>(serviceRoute, item, parameters);
        }

        /// <summary>
        /// Communicates with the services, sending items through a post call to the WebApi.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">Items to process</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static void Post(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
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
        public static async Task<List<T>> GetAll<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, bool compress = true)
        {
            //if (compress)
            //    return GetServiceApi(serviceRoute, parameters).GetAll<T>()?.ToList();
            //else
            //    return GetServiceApi(serviceRoute, parameters).GetAllUncompressed<T>()?.ToList();

            if (ServiceApiProxy == null)
                ServiceApiProxy = new ServiceApiProxy(ServiceDictionary);

            if (compress)
                return ServiceApiProxy.GetAll<T>(serviceRoute).Result?.ToList();
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
        public static async Task<IEnumerable<T>> GetAllAsync<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, bool compress = true)
        {
            if (ServiceApiProxy == null)
                ServiceApiProxy = new ServiceApiProxy(ServiceDictionary);

            return ServiceApiProxy.GetAllAsync<T>(serviceRoute, parameters).Result?.ToList();
        }

        /// <summary>
        ///  Communicates with the services, retrieving the required items.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="fields">Name of fields required in the form of list</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> GetAllAsyncFieldsSelector<T>(ServiceEndpointRoutes serviceRoute, List<string> fields=null, string parameters = null, bool compress = true)
        {
            if (ServiceApiProxy == null)
                ServiceApiProxy = new ServiceApiProxy(ServiceDictionary);

            return ServiceApiProxy.GetAllAsyncFieldsSelector<T>(serviceRoute, parameters,fields).Result?.ToList();
        }

        public static async Task<IEnumerable<T>> GetSpecificFieldsAsyncByFilter<T>(ServiceEndpointRoutes serviceRoute,FiltersSpecificModel filtersSpecifics, string parameters = null, bool compress = true)
        {
            if (ServiceApiProxy == null)
                ServiceApiProxy = new ServiceApiProxy(ServiceDictionary);

            return ServiceApiProxy.GetSpecificFieldsAsyncByFilter<T>(serviceRoute, parameters, filtersSpecifics).Result?.ToList();
        }
        /// <summary>
        /// Communicates with the services, retrieving the required items asynchronously.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="fields">Name of fields required in the form of list</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        /// <returns></returns>
        public static async Task<List<T>> GetAllFieldsSelector<T>(ServiceEndpointRoutes serviceRoute, List<string> fields, string parameters = null, bool compress = true)
        {
            if (ServiceApiProxy == null)
                ServiceApiProxy = new ServiceApiProxy(ServiceDictionary);
            if (compress)
                return ServiceApiProxy.GetAllFieldsSelector<T>(serviceRoute, parameters,fields).Result?.ToList();
            else
                return GetServiceApi(serviceRoute, parameters).GetAllUncompressed<T>()?.ToList();
        }


        /// <summary>
        /// Communicates with the services, retrieving all the items that satisfy the fitler.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="filters">The collection of filters used against the items in the service</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static async Task<IEnumerable<T>> GetByFilter<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<FilterCollectionModel> filters, string parameters = null, bool compress = true)
        {
            if (ServiceApiProxy == null)
                ServiceApiProxy = new ServiceApiProxy(ServiceDictionary);

            if (compress)
                return await ServiceApiProxy.GetByFilter<T>(serviceRoute, filters, parameters);
            else
                return GetServiceApi(serviceRoute, parameters).GetByFilterUncompressed<T>(filters);
        }

        public static async Task<IEnumerable<T>> GetFieldsSelectorWithFilterByDictionary<T>(ServiceEndpointRoutes serviceRoute, FiltersSpecificModel filtersSpecifics, string parameters = null, bool compress = true)
        {
            if (ServiceApiProxy == null)
                ServiceApiProxy = new ServiceApiProxy(ServiceDictionary);
            return  ServiceApiProxy.GetFieldsSelectorWithFilterByDictionary<T>(serviceRoute, parameters, filtersSpecifics).Result?.ToList();
           
        }

        /// <summary>
        /// Communicates with the services, retrieving all the items that satisfy the fitler.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="filters">The collection of filters used against the items in the service</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static async Task<IEnumerable<T>> GetByFilterColumns<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<SpecificDataFilteringModel> filters, string parameters = null, bool compress = true)
        {
            if (ServiceApiProxy == null)
                ServiceApiProxy = new ServiceApiProxy(ServiceDictionary);

            if (compress)
                return await ServiceApiProxy.GetByFilterFieldsSelector<T>(serviceRoute, filters, parameters);
            else
                return GetServiceApi(serviceRoute, parameters).GetByFilterFieldsSelectorUncompressed<T>(filters);
        }

        /// <summary>
        /// Communicates with the services, post uncompressed data and get data after decomressing.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="obj">The object to be sent to the service</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static IEnumerable<T> PostAndGet<T>(ServiceEndpointRoutes serviceRoute, object obj, string parameters = null)
        {
            if (ServiceApiProxy == null)
                ServiceApiProxy = new ServiceApiProxy(ServiceDictionary);
            return ServiceApiProxy.PostAndGet<T>(serviceRoute, obj, parameters);
        }

        /// <summary>
        /// Communicates with the services, performing a Get call through the WebApi.
        /// </summary>
        /// <typeparam name="T">The returned model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and receive data compressed</param>
        public static async Task<T> Get<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, bool compress = true)
        {
            if (ServiceApiProxy == null)
                ServiceApiProxy = new ServiceApiProxy(ServiceDictionary);

            if (compress)
                return await ServiceApiProxy.Get<T>(serviceRoute, parameters);
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
        public static T Update<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
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
        public static void Update(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
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
        public static T Delete<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
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
        public static void Delete(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null, bool compress = true)
        {
            if (compress)
                GetServiceApi(serviceRoute, parameters).Delete(item);
            else
                GetServiceApi(serviceRoute, parameters).DeleteUncompressed(item);
        }

        #endregion

        #region Byte Service Heleper Methods

        #region Post

        /// <summary>
        /// Communicates with the services, sending items to be changed and returning any incorrect or errored items.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="items">Items to process</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        /// <returns>Errored items</returns>
        public static async Task<IEnumerable<T>> ProcessOperationAsBytes<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<object> items, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).ProcessOperationBytes<T>(items);
        }

        /// <summary>
        /// Communicates with the services, sending items to be changed and returning any incorrect or errored items.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="items">Items to process</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        /// <returns>Errored items</returns>
        public static async Task ProcessOperationAsBytes(ServiceEndpointRoutes serviceRoute, IEnumerable<object> items, string parameters = null)
        {
            await GetServiceApi(serviceRoute, parameters).ProcessOperationBytes(items);
        }

        /// <summary>
        /// Communicates with the services, sending items through a post call to the WebApi.
        /// </summary>
        /// <typeparam name="T">The returned model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">Items to process</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        /// <returns>Errored items</returns>
        public static async Task<T> PostAsBytes<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).PostBytes<T>(item);
        }

        /// <summary>
        /// Communicates with the services, sending items through a post call to the WebApi.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">Items to process</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static async Task PostAsBytes(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            await GetServiceApi(serviceRoute, parameters).PostBytes(item);
        }

        #endregion

        #region Get

        /// <summary>
        /// Communicates with the services, retrieving all the items.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static async Task<List<T>> GetAllAsBytes<T>(ServiceEndpointRoutes serviceRoute, string parameters = null)
        {
            if (IsStateful(serviceRoute))
            {
                var items = new List<T>();
                var tasks = new List<Task>();
                foreach (var key in Keys)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        var objDataList = await GetServiceApi(serviceRoute, $"DictionaryKey/{key}/{parameters}").GetAllBytes<byte[]>();
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
                return (await GetServiceApi(serviceRoute, parameters).GetAllBytes<T>())?.ToList();
        }

        public static async Task<IEnumerable<T>> GetAllSecureAsyncAsBytes<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<Guid> guidIdentities, string parameters = null)
        {
            if (IsStateful(serviceRoute))
            {
                var items = new List<T>();
                var tasks = new List<Task>();
                foreach (var key in Keys)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        var objDataList = await GetServiceApi(serviceRoute, $"ServiceFilter/{key}/{parameters}").PostBytes<IEnumerable<byte[]>>(guidIdentities);
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
                return (await GetServiceApi(serviceRoute, parameters).GetAllBytes<T>())?.ToList();

        }

        /// <summary>
        /// Communicates with the services, retrieving all the items that satisfy the filter.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="filters">The collection of filters used against the items in the service</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static async Task<IEnumerable<T>> GetByFilterAsBytes<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<FilterCollectionModel> filters, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).GetByFilterBytes<T>(filters);
        }


        /// <summary>
        /// Communicates with the services, performing a Get call through the WebApi.
        /// </summary>
        /// <typeparam name="T">The returned model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static async Task<T> GetAsBytes<T>(ServiceEndpointRoutes serviceRoute, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).GetBytes<T>();
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
        public static async Task<T> UpdateAsBytes<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).UpdateBytes<T>(item);
        }

        /// <summary>
        /// Communicates with the services, performing an update call through the WebApi.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">The item for which to update with</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static async Task UpdateAsBytes(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            await GetServiceApi(serviceRoute, parameters).UpdateBytes(item);
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
        public static async Task<T> DeleteAsBytes<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).DeleteBytes<T>(item);
        }

        /// <summary>
        /// Communicates with the services, performing an delete call through the WebApi.
        /// </summary>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="item">The item for which to delete with</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static async Task DeleteAsBytes(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            await GetServiceApi(serviceRoute, parameters).DeleteBytes(item);
        }

        #endregion

        #endregion
       
    }
}
