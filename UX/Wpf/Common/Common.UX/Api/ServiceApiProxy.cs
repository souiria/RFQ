/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ServiceApiProxy.cs
Function           :   Proxy method collection
Created By         :   Amit
Created on         :   07-Mar-2018
Revision History   :   [14-Oct-2019] : Srashti Gupta
*                  :   [] : Added the GetAllFieldsSelector(),GetAllAsyncFieldsSelector() and GetByFilterFieldsSelector() Methods for proxy creation.
*                  :   [09-Oct-2020] : Shivam Dhingra
*                  :   [] : Overloaded method GetServiceApi() and GetAll() to accept string parameters
*                  :   [16-Oct-2020] : Srashti Gupta
*                  :   [] : Remove Overloaded method GetServiceApi() and GetAll() to accept string parameters
****************************************************************************************************/
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
    public class ServiceApiProxy : IServiceApiProxy
    {
        private static Dictionary<string, bool> ServiceDictionary { get; set; }

        private static readonly string[] Keys = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
        public ServiceApiProxy(Dictionary<string, bool> serviceDictionary)
        {
            ServiceDictionary = serviceDictionary;
        }

        private ServiceApi GetServiceApi(ServiceEndpointRoutes serviceEndPointRoutes, string parameters = null)
        {
            return new ServiceApi(EndpointHelper.EndpointAddress, "19081", serviceEndPointRoutes, parameters);
        }

        private static bool IsStateful(string endpoint)
        {
            return ServiceDictionary.ContainsKey(endpoint) && ServiceDictionary[endpoint];
        }

        public async Task<IEnumerable<T>> ProcessOperation<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<object> items, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).ProcessOperation<T>(items);
        }
        public async Task<List<T>> GetAll<T>(ServiceEndpointRoutes serviceRoute, string parameters = null)
        {
            return (await GetServiceApi(serviceRoute, parameters).GetAll<T>())?.ToList();
        }

        public async Task<List<T>> GetAllFieldsSelector<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, List<string> fields = null)
        {
            return (await GetServiceApi(serviceRoute, parameters).GetAllFieldsSelector<T>(fields))?.ToList();
        }

        public async Task<List<T>> GetAllAsync<T>(ServiceEndpointRoutes serviceRoute, string parameters = null)
        {
                if (IsStateful(serviceRoute))
                {
                    var t = new List<string>();
                    var items = new List<T>();
                    var tasks = new List<Task>();
               
                    foreach (var key in Keys)
                    {
                        tasks.Add(Task.Run(async () =>
                        {
                            var objDataList = await GetServiceApi(serviceRoute, $"DictionaryKey/{key}/{parameters}").GetAllAsync();
                            foreach (var objData in objDataList)
                            {
                                try
                                {
                                    var results = JsonConvert.DeserializeObject<List<T>>(objData.DecompressBase64());
                                    lock (items)
                                        items.AddRange(results);
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                        }));
                    }
                    await Task.WhenAll(tasks);
                    return items;
                }
                else
                    return (await GetServiceApi(serviceRoute, parameters).GetAll<T>())?.ToList();
        }

        


        public async Task<List<T>> GetAllAsyncFieldsSelector<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, List<string> fields = null)
        {
            if (IsStateful(serviceRoute))
            {
                var items = new List<T>();
                var tasks = new List<Task>();
                foreach (var key in Keys)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        var objDataList = await GetServiceApi(serviceRoute, $"GetAllFieldsSelectorByDictionary/{key}/{parameters}").GetAllAsyncFieldsSelector(fields);
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
                return (await GetServiceApi(serviceRoute, parameters).GetAllFieldsSelector<T>(fields))?.ToList();
        }

        public async Task<List<T>> GetSpecificFieldsAsyncByFilter<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, FiltersSpecificModel filtersSpecifics = null)
        {
            if (IsStateful(serviceRoute))
            {
                var items = new List<T>();
                var tasks = new List<Task>();
                foreach (var key in Keys)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        var objDataList = await GetServiceApi(serviceRoute, $"GetAllFieldsSelectorByDictionary/{key}/{parameters}").GetSpecificFieldsAsyncByFilter(filtersSpecifics);
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
                return (await GetServiceApi(serviceRoute, parameters).GetAllFieldsSelector<T>(filtersSpecifics.Fields))?.ToList();
        }

        public async Task<List<T>> GetFieldsSelectorWithFilterByDictionary<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, FiltersSpecificModel filtersSpecifics = null)
        {
            if (IsStateful(serviceRoute))
            {
                var items = new List<T>();
                var tasks = new List<Task>();
                foreach (var key in Keys)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        var objDataList = await GetServiceApi(serviceRoute, $"GetFieldsSelectorWithFilterByDictionary/{key}/{parameters}").GetFieldsSelectorWithFilterByDictionary(filtersSpecifics);
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
                return (await GetServiceApi(serviceRoute, parameters).GetAllFieldsSelector<T>(filtersSpecifics.Fields))?.ToList();
        }

        public async Task<IEnumerable<T>> GetByFilter<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<FilterCollectionModel> filters, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).GetByFilter<T>(filters);
        }

        public async Task<T> Get<T>(ServiceEndpointRoutes serviceRoute, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).Get<T>();
        }

        public T Post<T>(ServiceEndpointRoutes serviceRoute, object items, string parameters = null)
        {
            return GetServiceApi(serviceRoute, parameters).Post<T>(items);
        }
        public async Task<T> PostByteArray<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).PostByteArray<T>(item);
        }

        public IEnumerable<T> PostAndGet<T>(ServiceEndpointRoutes serviceRoute, object obj, string parameters = null)
        {
            return GetServiceApi(serviceRoute, parameters).PostAndGet<T>(obj);
        }
        public async Task<IEnumerable<T>> GetByFilterFieldsSelector<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<SpecificDataFilteringModel> filters, string parameters = null)
        {
            return await GetServiceApi(serviceRoute, parameters).GetByFilterFieldsSelector<T>(filters);
        }
    }
}
