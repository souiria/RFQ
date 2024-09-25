/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   NetCoreServiceHelper.cs
Function           :   Communication bridge of Net Core Services/Client
Created By         :   Amit
Created on         :   07-Mar-2018
Revision History   :   [11-Mar-2019] : Amit Agarwal
*                  :   [] : Method modified for provide mocking
*                  :   [14-Oct-2019] : Srashti Gupta
*                  :   [] : Added the GetAllFieldsSelector(), GetAllAsyncFieldsSelector(), GetByFilterColumns() for interaction between the Services/Client.
*                  :   [30-Mar-2020] : Srashti Gupta
*                  :   [] : Added the PostAndGet for interaction between the Services/Client.
*                  :   [27-May-2020] : Amit
*                  :   [] : passed parameters to ProcessOpeation method
*                  :   [03-May-2020] : Amit
*                  :   [] : Added the endpoints IsExistsWithFiltersByPartition()
*                  :   [15-Oct-2020] : Srashti Gupta
*                  :   [] : Overloaded GetAll() method to accept string parameters
*                  :   [20-July-2022] : Sejal Srivastava
*                  :   [] : Changes done as per DRP performance improvement         
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

    public static class NetCoreServiceHelper
    {
        private static readonly string[] Keys = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
        public static Dictionary<string, bool> ServiceDictionary { get; set; }

        public static INetCoreServiceApiProxy NetCoreServiceApiProxy = null;


        private static NetCoreServiceApi GetNetCoreServiceApi(ServiceEndpointRoutes serviceEndPointRoutes, string parameters = null)
        {
            return new NetCoreServiceApi(EndpointHelper.EndpointAddress, serviceEndPointRoutes, parameters);
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
            if (NetCoreServiceApiProxy == null)
                NetCoreServiceApiProxy = new NetCoreServiceApiProxy(ServiceDictionary);

            return await NetCoreServiceApiProxy.ProcessOperation<T>(serviceRoute, items, parameters);
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
            if (NetCoreServiceApiProxy == null)
                NetCoreServiceApiProxy = new NetCoreServiceApiProxy(ServiceDictionary);

            return NetCoreServiceApiProxy.GetAll<T>(serviceRoute).Result?.ToList();
        }

        /// <summary>
        /// Communicates with the services, retrieving all the items.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="parameters">Additional paramteres to define with the route (eg. User Guid / Model Id)</param>
        /// <param name="compress">Whether the method should compress passed items and recieve data compressed</param>
        public static async Task<List<T>> GetAll<T>(string serviceRoute, object parameters = null, bool compress = true)
        {
            if (NetCoreServiceApiProxy == null)
                NetCoreServiceApiProxy = new NetCoreServiceApiProxy(ServiceDictionary);

            return NetCoreServiceApiProxy.GetAll<T>(serviceRoute, parameters).Result?.ToList();
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
            if (NetCoreServiceApiProxy == null)
                NetCoreServiceApiProxy = new NetCoreServiceApiProxy(ServiceDictionary);

            return NetCoreServiceApiProxy.GetAllAsync<T>(serviceRoute, parameters).Result?.ToList();
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
            if (NetCoreServiceApiProxy == null)
                NetCoreServiceApiProxy = new NetCoreServiceApiProxy(ServiceDictionary);

            return NetCoreServiceApiProxy.GetAllAsyncFieldsSelector<T>(serviceRoute, parameters,fields).Result?.ToList();
        }

        public static async Task<IEnumerable<T>> GetSpecificFieldsAsyncByFilter<T>(ServiceEndpointRoutes serviceRoute,FiltersSpecificModel filtersSpecifics, string parameters = null, bool compress = true)
        {
            if (NetCoreServiceApiProxy == null)
                NetCoreServiceApiProxy = new NetCoreServiceApiProxy(ServiceDictionary);
            
            return await NetCoreServiceApiProxy.GetSpecificFieldsAsyncByFilter<T>(serviceRoute, parameters, filtersSpecifics);
        }
        public static async Task<bool> IsExistsWithFiltersByPartition(ServiceEndpointRoutes serviceRoute, List<SpecificDataFilteringModel> filterslist)
        {
            if (NetCoreServiceApiProxy == null)
                NetCoreServiceApiProxy = new NetCoreServiceApiProxy(ServiceDictionary);
            return await NetCoreServiceApiProxy.IsExistsWithFiltersByPartition(serviceRoute, filterslist);
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
            if (NetCoreServiceApiProxy == null)
                NetCoreServiceApiProxy = new NetCoreServiceApiProxy(ServiceDictionary);
            if (compress)
                return NetCoreServiceApiProxy.GetAllFieldsSelector<T>(serviceRoute, parameters,fields).Result?.ToList();
            else
                return await GetNetCoreServiceApi(serviceRoute, parameters).GetAllAsyncUncompressed<T>();
        }

        public static async Task<IEnumerable<T>> GetFieldsSelectorWithFilterByDictionary<T>(ServiceEndpointRoutes serviceRoute, FiltersSpecificModel filtersSpecifics, string parameters = null, bool compress = true)
        {
            if (NetCoreServiceApiProxy == null)
                NetCoreServiceApiProxy = new NetCoreServiceApiProxy(ServiceDictionary);
            return await NetCoreServiceApiProxy.GetFieldsSelectorWithFilterByDictionary<T>(serviceRoute, parameters, filtersSpecifics);
           
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
            if (NetCoreServiceApiProxy == null)
                NetCoreServiceApiProxy = new NetCoreServiceApiProxy(ServiceDictionary);
            
            return await GetNetCoreServiceApi(serviceRoute, parameters).PostAsync<IEnumerable<T>>(filters);
        }

        /// <summary>
        /// Communicates with the services, post uncompressed data and get data after decomressing.
        /// </summary>
        /// <typeparam name="T">The individual model type</typeparam>
        /// <param name="serviceRoute">The route of the service to communicate</param>
        /// <param name="obj">The object to be sent to the service</param>
        /// <param name="parameters">Additional parameters to define with the route (eg. User Guid / Model Id)</param>
        public static async Task<IEnumerable<T>> PostAndGet<T>(ServiceEndpointRoutes serviceRoute, object obj, string parameters = null)
        {
            if (NetCoreServiceApiProxy == null)
                NetCoreServiceApiProxy = new NetCoreServiceApiProxy(ServiceDictionary);

            return await NetCoreServiceApiProxy.PostAndGet<T>(serviceRoute, obj, parameters);
        }

        public static async Task<string> PostAndGetDataTable<T>(ServiceEndpointRoutes serviceRoute, object obj, string parameters = null)
        {
            if (NetCoreServiceApiProxy == null)
                NetCoreServiceApiProxy = new NetCoreServiceApiProxy(ServiceDictionary);

            return await NetCoreServiceApiProxy.PostAndGetDataTable<string>(serviceRoute, obj, parameters);
        }
        #endregion
    }
}
