/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   NetCoreServiceApiProxy.cs
Function           :   Proxy method collection to connect with Net Core Api
Created By         :   Amit
Created on         :   12-Feb-2019
Revision History   :   [30-Mar-2020] : Srashti Gupta
*                  :   [] : Added new method GetSpecificFieldsAsyncByFilter(), PostAndGet() for interacting with Net Core Api
*                  :   [14-04-2020] : Amit Agarwal
                   :   [] : Improvements done w.r.t filters.
                   :   [15-04-2020] : Srashti Gupta
                   :   [] : Improvements done w.r.t filters.
                   :   [15-04-2020] : Amit Agarwal
                   :   [] : Fabric Client Api called
                   :   [24-04-2020] : Amit Agarwal
                   :   [] : Fabric Client Api calling removed
*                  :   [27-May-2020] : Amit
*                  :   [] : passed parameters to ProcessOpeation method
*                  :   [03-May-2020] : Amit
*                  :   [] : Added the endpoints IsExistsWithFiltersByPartition()
*                  :   [08-June-2020] : Srashti Gupta
*                  :   [] : Modified the else condition of GetSpecificFieldsAsyncByFilter()
*                  :   [12-Oct-2020] : Srashti Gupta
*                  :   [] : Fetching the partition count using FabricClient.
*                  :   [13-Oct-2020] : Srashti Gupta
*                  :   [] : Commented code for Fetching the partition count using FabricClient.
*                  :   [16-Oct-2020] : Srashti Gupta
*                  :   [] : Overloaded method NetCoreServiceApi() and GetAll() to accept string parameters
*                  :   [20-July-2022] : Sejal Srivastava
*                  :   [] : Changes done as per DRP performance improvement         
****************************************************************************************************/
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Infrastructure.Helpers;
using Common.UX.Api.Endpoints;
using Common.UX.Contracts.Interfaces.Core;
using Common.UX.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
//using System.Fabric;
using System.Linq;
using System.Threading.Tasks;

namespace Common.UX.Api
{
    public class NetCoreServiceApiProxy : INetCoreServiceApiProxy
    {
        private static Dictionary<string, bool> ServiceDictionary { get; set; }

        private static readonly string[] Keys = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
        private static readonly string[] PartitionsLowKeys = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" };
        public NetCoreServiceApiProxy(Dictionary<string, bool> serviceDictionary)
        {
            ServiceDictionary = serviceDictionary;
        }

        private static string ReplacePostResponseDelimiters(string bodyString)
        {
            if (bodyString.StartsWith("[\""))
            {
                bodyString = bodyString.Replace("[\"", string.Empty);
            }
            if (bodyString.EndsWith("\"]"))
            {
                bodyString = bodyString.Replace("\"]", string.Empty);
            }
            return bodyString;
        }

        private NetCoreServiceApi GetNetCoreServiceApi(ServiceEndpointRoutes serviceEndPointRoutes, string parameters = null, string port = "8100")
        {
            return new NetCoreServiceApi(EndpointHelper.EndpointAddress, serviceEndPointRoutes, parameters, port);
        }
        private static bool IsStateful(string endpoint)
        {
            return ServiceDictionary.ContainsKey(endpoint) && ServiceDictionary[endpoint];
        }

        public async Task<IEnumerable<T>> ProcessOperation<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<object> items, string parameters = null)
        {
            return await GetNetCoreServiceApi(serviceRoute, parameters).PostAsync<IEnumerable<T>>(items);
        }
        public async Task<List<T>> GetAll<T>(ServiceEndpointRoutes serviceRoute, string parameters = null)
        {
            return (await GetNetCoreServiceApi(serviceRoute, parameters).GetAllAsync<List<T>>())?.ToList();
        }

        public async Task<List<T>> GetAll<T>(string serviceRoute, object parameters = null)
        {
            return (await new NetCoreServiceApi(EndpointHelper.EndpointAddress, serviceRoute).GetAllAsync<List<T>>(parameters))?.ToList();
        }

        public async Task<List<T>> GetAllFieldsSelector<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, List<string> fields = null)
        {
            return (await GetNetCoreServiceApi(serviceRoute, parameters).PostAsync<List<T>>(fields))?.ToList();
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
                        var objDataList = await GetNetCoreServiceApi(serviceRoute, $"DictionaryKey/{key}/{parameters}").GetAllAsync();
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
                return (await GetNetCoreServiceApi(serviceRoute, parameters).GetAllAsync<List<T>>())?.ToList();
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
                        var objDataList = await GetNetCoreServiceApi(serviceRoute, $"GetAllFieldsSelectorByDictionary/{key}/{parameters}").GetAllAsyncFieldsSelector(fields);
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
                return (await GetNetCoreServiceApi(serviceRoute, parameters).PostAsync<List<T>>(fields))?.ToList();
        }

        public async Task<List<T>> GetSpecificFieldsAsyncByFilter<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, FiltersSpecificModel filtersSpecifics = null)
        {
            List<long> PartitionsKey = new List<long>();
            //PartitionsKey = await FabricClientHelper.GetInstance.GetServicePartitionsLowKeyAsync(serviceRoute);
            if (IsStateful(serviceRoute))
            {
                var items = new List<T>();
                var tasks = new List<Task>();
                try
                {
                    foreach (var key in PartitionsLowKeys)
                    { 
                        tasks.Add(Task.Run(async () =>
                        {
                            var objDataList = await GetNetCoreServiceApi(serviceRoute, $"GetAllFieldsSelectorByPartition/{parameters}?PartitionKey={ key }&PartitionKind=Int64Range", "19081").GetSpecificFieldsAsyncByFilter(filtersSpecifics);
                            foreach (var objData in objDataList)
                            {
                                if (objData != "")
                                {
                                    var results = JsonConvert.DeserializeObject<List<T>>(Compressor.DecompressBase64(ReplacePostResponseDelimiters(objData)));
                                    lock (items)
                                        items.AddRange(results);
                                }
                            }
                        }));
                    }
                }
                catch(Exception ex)
                {

                }
                await Task.WhenAll(tasks);
                return items;
            }
            else
                return (await GetNetCoreServiceApi(serviceRoute, parameters).PostAsync<List<T>>(filtersSpecifics))?.ToList();
        }
        public async Task<bool> IsExistsWithFiltersByPartition(ServiceEndpointRoutes serviceRoute, List<SpecificDataFilteringModel> filterslist = null)
        {
            if (IsStateful(serviceRoute))
            {
                //List<long> PartitionsKey = new List<long>();
                //PartitionsKey = await FabricClientHelper.GetInstance.GetServicePartitionsLowKeyAsync(serviceRoute);
                var items = new List<bool>();
                var tasks = new List<Task>();
                try
                {
                    foreach (var key in PartitionsLowKeys)
                    {
                        tasks.Add(Task.Run(async () =>
                        {
                            var objDataList = await GetNetCoreServiceApi(serviceRoute, $"IsExistsWithFiltersByPartition?PartitionKey={ key }&PartitionKind=Int64Range", "19081").IsExistsByFiltersAsync(filterslist);
                            foreach (var objData in objDataList)
                            {
                                if (objData != "")
                                {
                                    var results = JsonConvert.DeserializeObject<List<bool>>(Compressor.DecompressBase64(ReplacePostResponseDelimiters(objData)));
                                    lock (items)
                                        items.AddRange(results);
                                }
                            }
                        }));
                    }
                }
                catch (Exception) { }
                await Task.WhenAll(tasks);
                return items.Any(it => it);
            }
            return true;
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
                        var objDataList = await GetNetCoreServiceApi(serviceRoute, $"GetFieldsSelectorWithFilterByDictionary/{key}/{parameters}").GetFieldsSelectorWithFilterByDictionary(filtersSpecifics);
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
                return (await GetNetCoreServiceApi(serviceRoute, parameters).PostAsync<List<T>>(filtersSpecifics.Fields))?.ToList();
        }

        public async Task<IEnumerable<T>> PostAndGet<T>(ServiceEndpointRoutes serviceRoute, object obj, string parameters = null)
        {
            var items = new List<T>();
            try
            {
                var objDataList = await GetNetCoreServiceApi(serviceRoute, parameters).PostAndGet<IEnumerable<T>>(obj);
                foreach (var objData in objDataList)
                {
                    var results = JsonConvert.DeserializeObject<List<T>>(objData.DecompressBase64());
                    lock (items)
                        items.AddRange(results);
                }
            }
            catch(Exception ex)
            {
            }
            return items;
        }

        public async Task<string> PostAndGetDataTable<T>(ServiceEndpointRoutes serviceRoute, object obj, string parameters = null)
        {
            var items = string.Empty;
            try
            {
                var objDataList = await GetNetCoreServiceApi(serviceRoute, parameters).PostAndGet<IEnumerable<string>>(obj);
                foreach (var objData in objDataList)
                {
                    var results = objData.DecompressBase64();
                    lock (items)
                        return results;
                }
            }
            catch (Exception ex)
            {
            }
            return items;
        }
    }
}
