/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   V2ProxyCollection.cs
Function           :   Creates a new instance of the proxy collection.
Created By         :  
Created on         :  
Revision History   :   [14-Oct-2019] : Srashti Gupta
*                  :   [] : Modifiy the class as per the requirement for performance optimization.
*                  :   [06-Jan-2020] : Amit Agarwal
*                  :   [] : Modifiy w.r.t. memory leak issues
*                  :   [10-Oct-2021] : Ashish Dutta
*                  :   [] : Remove Parallel foreach from method ProcessOperation()
****************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Fabric;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Infrastructure.Extensions;
using Common.Core.Infrastructure.Helpers;
using Common.SF.Contracts.Interfaces.Base;
using Common.SF.Contracts.Interfaces.Base.Base64;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport;
using Microsoft.ServiceFabric.Services.Remoting.V1.FabricTransport.Client;
using Microsoft.ServiceFabric.Services.Runtime;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Fabric;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Common.SF.Contracts.Models.Core.Proxy
{
    public class V2ProxyCollection<I> : ProxyCollection<I> where I : IService
    {
        public V2ProxyCollection(Uri uri, IServiceProxyFactory serviceProxyFactory) : base(uri, serviceProxyFactory)
        { }


        //[Obsolete("This constructor creates a new ServiceProxyFactory. It is advised by Microsoft's documentation that creating a new factory " +
        //    "is an expensive operation and it should be cached and reused where possible. There is a ServiceProxyFactory created in StatefulServiceBase that can be " +
        //    "passed to the overload constructor of this class.")]
        //public V2ProxyCollection(Uri uri) : base(uri)
        //{ }

        [Obsolete("This method creates a new ServiceProxyFactory. It is advised by Microsoft's documentation that creating a new factory " +
            "is an expensive operation and it should be cached and reused where possible.")]
        protected override ServiceProxyFactory ServiceProxyFactory()
        {
            FabricTransportRemotingSettings settings = new FabricTransportRemotingSettings();
            settings.OperationTimeout = TimeSpan.FromMinutes(10);
            settings.MaxMessageSize = int.MaxValue;
            settings.UseWrappedMessage = true;

            return new ServiceProxyFactory(
                (h) =>
                {
                    return new FabricTransportServiceRemotingClientFactory(settings);
                });
        }

        public async Task<List<X>> MergeResultsOfAction<X>(Func<I, Task<string>> action)
        {
            var tasks = new List<Task<string>>();

            foreach (var proxy in Values)
                tasks.Add(action(proxy));

            var array = await Task.WhenAll(tasks);
            return array.SelectMany(objData =>
            {
                var decompressed = Compressor.DecompressBase64(objData);
                return JsonConvert.DeserializeObject<List<X>>(decompressed);
            }).ToList();
        }


        public async Task<List<X>> MergeResultsOfActionAsBytes<X>(Func<I, Task<byte[]>> action)
        {
            var tasks = new List<Task<byte[]>>();

            foreach (var proxy in Values)
                tasks.Add(action(proxy));

            var array = await Task.WhenAll(tasks);
            return array.SelectMany(objData =>
            {
                var decompressed = objData.Decompress();

                return !string.IsNullOrEmpty(decompressed) ? JsonConvert.DeserializeObject<List<X>>(decompressed) : new List<X>();

            }).ToList();
        }


        public async Task<List<X>> MergeResultOfAction<X>(Func<I, Task<string>> action)
        {
            var tasks = new List<Task<string>>();

            foreach (var proxy in Values)
                tasks.Add(action(proxy));

            var array = await Task.WhenAll(tasks);
            return array.Select(objData =>
            {
                var decompressed = Compressor.DecompressBase64(objData);
                return JsonConvert.DeserializeObject<X>(decompressed);
            }).ToList();
        }

        /// <summary>
        /// Performs a method call on the first proxy in the collection
        /// </summary>
        /// <param name="action">The method to call on the proxy</param>
        /// <returns></returns>
        public async Task Call(Func<I, Task> action)
        {
            await action(this[0]);
        }

        /// <summary>
        /// Performs a method call on the first proxy in the collection
        /// </summary>
        /// <typeparam name="X">The returned value</typeparam>
        /// <param name="action">The method to call on the proxy</param>
        /// <returns></returns>
        public async Task<X> Call<X>(Func<I, Task<X>> action)
        {
            return await action(this[0]);
        }

        protected void Log(string text)
        {
            Console.WriteLine($"{ DateTime.Now.ToString(CultureInfo.InvariantCulture)} :: ProxyCollection :: {text}");
        }
    }

    public class V2ProxyCollection<I, M> : V2ProxyCollection<I> where I : IBase where M : BaseModel<Guid>
    {
        /// <summary>
        /// Creates a new instance of the proxy collection and fills the collection with the remote proxies for the provided service.
        /// </summary>
        /// <param name="uri">The service address.</param>
        /// <exception cref="FabricInvalidPartitionKeyException">Throws when the service provided has a partition count greater than 16</exception>
        public V2ProxyCollection(Uri uri, IServiceProxyFactory serviceProxyFactory) : base(uri, serviceProxyFactory)
        { }

        //[Obsolete("This constructor creates a new ServiceProxyFactory. It is advised by Microsoft's documentation that creating a new factory " +
        //    "is an expensive operation and it should be cached and reused where possible. There is a ServiceProxyFactory created in StatefulServiceBase that can be " +
        //    "passed to the overload constructor of this class.")]
        //public V2ProxyCollection(Uri uri) : base(uri)
        //{ }

        /// <summary>
        /// Performs the GetAll method call provided by <see cref="IBase"/> on all the remote proxies in the collection, merging the results into one list
        /// </summary>
        /// <returns>The results of all the method calls</returns>
        public async Task<List<M>> GetAll()
        {
            CompressorNonStatic compressorNonStatic = new CompressorNonStatic();
            string nameOfModel = typeof(M).Name;
            List<M> lstReturned = new List<M>();
            var proxyTasks = new List<Task<string>>();
            try
            {
                Log($"{ nameOfModel } : Started async retrieval of data");
                var stopwatch = Stopwatch.StartNew();

                foreach (var proxy in this.Values)
                    proxyTasks.Add(((IBase64)proxy).GetAll());
                var resultArray = await Task.WhenAll(proxyTasks);
                Log($"{ nameOfModel } : Finished async retrieval of data [{stopwatch.Elapsed}]");
                Log($"{ nameOfModel } : Started decompression and merge of data [{stopwatch.Elapsed}]");

                List<M> itemsPerPartition = new List<M>();
                foreach (var item in resultArray)
                {
                    itemsPerPartition = JsonConvert.DeserializeObject<List<M>>(compressorNonStatic.DecompressBase64(item));
                    lstReturned.AddRange(itemsPerPartition);
                    Log($"{ nameOfModel } : Partition items [{itemsPerPartition.Count()}]");
                    itemsPerPartition.Clear();
                    itemsPerPartition.TrimExcess();
                }
                stopwatch.Stop();
                Array.Clear(resultArray,0,resultArray.Length);
                Log($"{ nameOfModel } : Total items [{lstReturned.Count()}]");
                Log($"{ nameOfModel } : Finished decompression and merge of data [{stopwatch.Elapsed}]");
                
                return lstReturned;
            }
            catch (Exception e)
            {
                Log($"Exception:GetAll : { e.Message }");
            }
            finally {
                proxyTasks.Clear();
                compressorNonStatic.Dispose();
            }
            return lstReturned;
        }
        /// <summary>
        /// Performs the GetAllFieldsSelector method call provided by <see cref="IBase64Custom"/> on all the remote proxies in the collection, merging the results into one list
        /// </summary>
        /// <param name="fieldsname">Name of the required specific fields</param>
        /// <returns>The results of all the method calls</returns>
        public async Task<List<M>> GetAllFieldsSelector(string fieldsname)
        {
            string nameOfModel = typeof(M).Name;
            Log($"{ nameOfModel } : GetAllFieldsSelector - Started async retrieval of data");
            var stopwatch = Stopwatch.StartNew();

            var proxyTasks = new List<Task<string>>();
            foreach (var proxy in this.Values)
                proxyTasks.Add(((IBase64Custom)proxy).GetAllFieldsSelector(fieldsname));

            var resultArray = await Task.WhenAll(proxyTasks);

            Log($"{ nameOfModel } : GetAllFieldsSelector - Finished async retrieval of data [{stopwatch.Elapsed}]");
            Log($"{ nameOfModel } : GetAllFieldsSelector - Started decompression and merge of data [{stopwatch.Elapsed}]");

            List<M> lstReturned = new List<M>();
            foreach (var item in resultArray)
            {
                var itemsPerPartition = JsonConvert.DeserializeObject<List<M>>(Compressor.DecompressBase64(item));
                lstReturned.AddRange(itemsPerPartition);
                Log($"{ nameOfModel } : GetAllFieldsSelector - Partition items [{itemsPerPartition.Count()}]");
            }
            stopwatch.Stop();
            Log($"{ nameOfModel } :GetAllFieldsSelector -  Total items [{lstReturned.Count()}]");
            Log($"{ nameOfModel } :GetAllFieldsSelector -  Finished decompression and merge of data [{stopwatch.Elapsed}]");
            return lstReturned;
        }

        /// <summary>
        /// Performs the GetByFilter method call provided by <see cref="IBase64Custom"/> on all the remote proxies in the collection using the provided filter and merging the results into one list.
        /// </summary>
        /// <param name="Filters">the filter used to determine the results returned</param>
        /// <returns>The filtered results of all the method callss</returns>
        public async Task<List<M>> GetAllFieldsSelectorFilter(List<SpecificDataFilteringModel> Filters)
        {
            string nameOfModel = typeof(M).Name;
            Log($"{ nameOfModel } : GetAllFieldsSelectorFilter - Started async retrieval of data");
            var stopwatch = Stopwatch.StartNew();

            var proxyTasks = new List<Task<string>>();
            foreach (var proxy in this.Values)
                proxyTasks.Add(((IBase64Custom)proxy).GetAllFieldsSelectorFilter(Filters));

            var resultArray = await Task.WhenAll(proxyTasks);

            Log($"{ nameOfModel } : GetAllFieldsSelectorFilter - Finished async retrieval of data [{stopwatch.Elapsed}]");
            Log($"{ nameOfModel } : GetAllFieldsSelectorFilter - Started decompression and merge of data [{stopwatch.Elapsed}]");

            List<M> lstReturned = new List<M>();
            foreach (var item in resultArray)
            {
                var itemsPerPartition = JsonConvert.DeserializeObject<List<M>>(Compressor.DecompressBase64(item));
                lstReturned.AddRange(itemsPerPartition);
                Log($"{ nameOfModel } : GetAllFieldsSelectorFilter - Partition items [{itemsPerPartition.Count()}]");
            }
            stopwatch.Stop();
            Log($"{ nameOfModel } :GetAllFieldsSelectorFilter -  Total items [{lstReturned.Count()}]");
            Log($"{ nameOfModel } :GetAllFieldsSelectorFilter -  Finished decompression and merge of data [{stopwatch.Elapsed}]");
            return lstReturned;
        }
        public async Task<List<string>> GetByDictionary(string key)
        {
            Log($"Started async retrieval of data using key {key}");
            var stopwatch = Stopwatch.StartNew();
            var proxyTasks = new List<Task<string>>();
            foreach (var proxy in this.Values)
                proxyTasks.Add(((IBase64)proxy).GetAllByPartition(key));
            var results = (await Task.WhenAll(proxyTasks)).ToList();
            stopwatch.Stop();
            Log($"Finished async retrieval of data using key {key} [{stopwatch.Elapsed}]");
            return results;
        }
        /// <summary>
        /// Performs the GetFieldsSelectorByDictionary method call provided by <see cref="IBase64Custom"/> on all the remote proxies in the collection, merging the results into one list
        /// </summary>
        /// <param name="key">Dictionary Key</param>
        /// <param name="field">Name of the required specific fields</param>
        /// <returns>The results of all the method calls</returns>
        public async Task<List<string>> GetFieldsSelectorByDictionary(string key, string field)
        {
            Log($"GetFieldsSelectorByDictionary - Started async retrieval of data using key {key}");
            var stopwatch = Stopwatch.StartNew();
            var proxyTasks = new List<Task<string>>();
            foreach (var proxy in this.Values)
                proxyTasks.Add(((IBase64Custom)proxy).GetAllFieldsSelectorByPartition(key, field));
            var results = (await Task.WhenAll(proxyTasks)).ToList();
            stopwatch.Stop();
            Log($"GetFieldsSelectorByDictionary - Finished async retrieval of data using key {key} [{stopwatch.Elapsed}]");
            return results;
        }

        public async Task<List<string>> GetFieldsSelectorWithFilterByDictionary(string key, string field)
        {
            Log($"GetFieldsSelectorByDictionary - Started async retrieval of data using key {key}");
            var stopwatch = Stopwatch.StartNew();
            var proxyTasks = new List<Task<string>>();
            foreach (var proxy in this.Values)
                proxyTasks.Add(((IBase64Custom)proxy).GetFieldsSelectorWithFilterByDictionary(key, field));
            var results = (await Task.WhenAll(proxyTasks)).ToList();
            stopwatch.Stop();
            Log($"GetFieldsSelectorByDictionary - Finished async retrieval of data using key {key} [{stopwatch.Elapsed}]");
            return results;
        }
        //public async Task<List<string>> GetAllSecureDataByDictionary(string key, string guids)
        //{
        //    Log($"Started async retrieval of data using key {key}");
        //    var stopwatch = Stopwatch.StartNew();

        //    var proxyTasks = new List<Task<string>>();
        //    foreach (var proxy in this.Values)
        //        proxyTasks.Add(proxy.GetAllSecureDataByPartition(key, guids));
        //    var results = (await Task.WhenAll(proxyTasks)).ToList();

        //    stopwatch.Stop();
        //    Log($"Finished async retrieval of data using key {key} [{stopwatch.Elapsed}]");
        //    return results;
        //}
        /// <summary>
        /// Get Models from Keys/Guids  
        /// </summary>
        /// <param name="guidObjData">Key List</param>
        /// <returns>List of Models</returns>
        public async Task<List<M>> GetByIds(string guidObjData)
        {
            Log($"Started async retrieval of data using keys");
            var stopwatch = Stopwatch.StartNew();
            var guids = JsonConvert.DeserializeObject<IEnumerable<Guid>>(guidObjData.DecompressBase64());
            List<M> items = new List<M>();
            var proxyTasks = new List<Task<M>>();
            foreach (Guid item in guids)
                proxyTasks.Add(Get(item));
            var results = (await Task.WhenAll(proxyTasks)).ToList();
            stopwatch.Stop();
            Log($"Finished async retrieval of data using keys [{stopwatch.Elapsed}]");
            return results;
        }
        /// <summary>
        /// Performs the GetByFilter method call provided by <see cref="IBase"/> on all the remote proxies in the collection using the provided filter and merging the results into one list.
        /// </summary>
        /// <param name="filters">The filter used to determine the results returned</param>
        /// <returns>The filtered results of all the method calls</returns>
        public async Task<List<M>> GetByFilter(List<FilterCollectionModel> filters)
        {
            Log("Started async retrieval of data");
            var stopwatch = Stopwatch.StartNew();

            var proxyTasks = new List<Task<string>>();
            foreach (var proxy in this.Values)
                proxyTasks.Add(proxy.GetByFilter(filters));

            var resultArray = await Task.WhenAll(proxyTasks);

            Log($"Finished async retrieval of data [{stopwatch.Elapsed}]");
            Log($"Started decompression and merge of data [{stopwatch.Elapsed}]");

            var results = resultArray.SelectMany(
                objData => JsonConvert.DeserializeObject<List<M>>(Compressor.DecompressBase64(objData))).ToList();

            stopwatch.Stop();
            Log($"Finished decompression and merge of data [{stopwatch.Elapsed}]");

            return results;
        }

        /// <summary>
        /// Determines the correct remote proxy to call and performs the Get method call upon it.
        /// </summary>
        /// <param name="id">The Id of the model to retrieve. This also determines the partition this object performs the call upon.</param>
        /// <returns>The object with a matching <see cref="Guid"/></returns>
        public async Task<M> Get(Guid id)
        {
            Log("Started retrieval of data");
            var stopwatch = Stopwatch.StartNew();

            var partitionIndex = (int)id.ToPartitionKey();
            var objData = await ((IBase64)this[partitionIndex]).Get(id);

            Log($"Finished retrieval of data [{stopwatch.Elapsed}]");
            Log($"Started decompression and merge of data [{stopwatch.Elapsed}]");

            var result = JsonConvert.DeserializeObject<M>(Compressor.DecompressBase64(objData));

            stopwatch.Stop();
            Log($"Finished decompression and merge of data [{stopwatch.Elapsed}]");

            return result;
        }

        /// <summary>
        /// Sorts the provided models into partitioned list and calls <see cref="StatefulServiceBase.ProcessOperation(IEnumerable{T})"/> 
        /// on each partition with its respective list.
        /// </summary>
        /// <param name="models">The list of models to processs. The Ids for these models must already be set.</param>
        /// <returns>A list of errors returned from each partition</returns>
        public async Task<List<M>> ProcessOperation(IEnumerable<M> models)
        {
            Log("Started data processing");
            var stopwatch = Stopwatch.StartNew();

            Dictionary<Range, List<M>> modelsDictionary = new Dictionary<Range, List<M>>();

            foreach (var model in models)
            {
                var partitionRangeKey = GetKey((int)model.Id.ToPartitionKey());

                if (!modelsDictionary.ContainsKey(partitionRangeKey))
                    modelsDictionary.Add(partitionRangeKey, new List<M>());

                modelsDictionary[partitionRangeKey].Add(model);
            }

            Log($"Finished data processing [Items:{models.Count()}] :: [{stopwatch.Elapsed}]");
            Log($"Started async data sending and error retrieval [{stopwatch.Elapsed}]");

            List<M> erroredModels = new List<M>();
            var tasks = new List<Task>();
            //await Task.Run(() => Parallel.ForEach(modelsDictionary, async (pair) =>
            //{
            foreach (var pair in modelsDictionary)
            {
                tasks.Add(Task.Run(async () =>
                {
                    var errorObjectData = await this[pair.Key].ProcessOperation(JsonConvert.SerializeObject(pair.Value).CompressBase64());
                    lock (erroredModels)
                    {
                        erroredModels.AddRange(JsonConvert.DeserializeObject<List<M>>(Compressor.DecompressBase64(errorObjectData)));
                    }
                }));
            }
            await Task.WhenAll(tasks);
            Log($"Finished async data sending and error retrieval [Errors:{erroredModels.Count}] :: [{stopwatch.Elapsed}]");

            return erroredModels;
        }

        ///// <summary>
        ///// Performs database recovery for a service application. It retrieves the database entries and partitions those items across the service.
        ///// </summary>
        ///// <param name="merge">Determines whether the items are merged. The merge is determined by the <see cref="BaseModel{T}.ModifiedDate"/> of the model.</param>
        ///// <returns></returns>
        //public async Task DatabaseRecovery(bool merge)
        //{
        //    var dbObjData = await this[0].GetAllDatabaseEntries();
        //    var dbItems = JsonConvert.DeserializeObject<List<M>>(Compressor.DecompressBase64(dbObjData));
        //    var mergedItems = new List<M>();
        //    if (!merge)
        //    {
        //        await ClearAllData();
        //        mergedItems = dbItems;
        //    }
        //    else
        //    {
        //        var serviceItems = await GetAll();
        //        var concatList = serviceItems.Concat(dbItems).ToList();
        //        var duplicateGroups = concatList.GroupBy(x => x.Id).Where(y => y.Count() > 1);
        //        foreach (var duplicateGroup in duplicateGroups)
        //        {
        //            var duplicates = duplicateGroup.ToList();

        //            //Remove duplicates whos ModifiedDate is earlier than other duplicate items
        //            duplicates.RemoveAll(x => duplicates.Any(y => x.ModifiedDate > y.ModifiedDate));
        //            foreach (var duplicate in duplicates)
        //                concatList.Remove(duplicate);
        //        }
        //        mergedItems = concatList;
        //    }

        //    await ProcessOperation(mergedItems);
        //}

        /// <summary>
        /// Clears all the data from all the partitions of a service application.
        /// </summary>
        /// <returns></returns>
        public async Task ClearAllData()
        {
            List<Task> tasks = new List<Task>();
            foreach (var proxy in this.Values)
            {
                tasks.Add(proxy.DeleteAll());
            }

            await Task.WhenAll(tasks);
        }

        public async Task<List<M>> GetAllFieldsSelectorUncompressed(string fieldsname)
        {
            string nameOfModel = typeof(M).Name;
            Log($"{ nameOfModel } : GetAllFieldsSelectorUncompressed - Started async retrieval of data");
            var stopwatch = Stopwatch.StartNew();

            var proxyTasks = new List<Task<string>>();
            foreach (var proxy in this.Values)
                proxyTasks.Add(((IBase64Custom)proxy).GetAllFieldsSelectorUncompressed(fieldsname));

            var resultArray = await Task.WhenAll(proxyTasks);

            Log($"{ nameOfModel } : GetAllFieldsSelectorUncompressed - Finished async retrieval of data [{stopwatch.Elapsed}]");
            Log($"{ nameOfModel } : GetAllFieldsSelectorUncompressed - Started decompression and merge of data [{stopwatch.Elapsed}]");

            List<M> lstReturned = new List<M>();
            foreach (var item in resultArray)
            {
                var itemsPerPartition = JsonConvert.DeserializeObject<List<M>>(Compressor.DecompressBase64(item));
                lstReturned.AddRange(itemsPerPartition);
                Log($"{ nameOfModel } : GetAllFieldsSelectorUncompressed - Partition items [{itemsPerPartition.Count()}]");
            }
            stopwatch.Stop();
            Log($"{ nameOfModel } :GetAllFieldsSelectorUncompressed -  Total items [{lstReturned.Count()}]");
            Log($"{ nameOfModel } :GetAllFieldsSelectorUncompressed -  Finished decompression and merge of data [{stopwatch.Elapsed}]");
            return lstReturned;
        }

        public async Task<List<string>> GetAllFieldsSelectorByDictionaryUncompressed(string key, string field)
        {
            Log($"GetAllFieldsSelectorByDictionaryUncompressed - Started async retrieval of data using key {key}");
            var stopwatch = Stopwatch.StartNew();
            var proxyTasks = new List<Task<string>>();
            foreach (var proxy in this.Values)
                proxyTasks.Add(((IBase64Custom)proxy).GetAllFieldsSelectorByDictionaryUncompressed(key, field));
            var results = (await Task.WhenAll(proxyTasks)).ToList();
            stopwatch.Stop();
            Log($"GetAllFieldsSelectorByDictionaryUncompressed - Finished async retrieval of data using key {key} [{stopwatch.Elapsed}]");
            return results;
        }
    }
}
