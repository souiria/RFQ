using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Fabric;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Extensions;
using Common.Core.Infrastructure.Helpers;
using Common.SF.Contracts.Interfaces.Base;
using Common.SF.Contracts.Interfaces.Base.Byte;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Newtonsoft.Json;

namespace Common.SF.Contracts.Models.Core.Proxy.Commercial
{
    public class V2ProxyCollection<I> : ProxyCollection<I> where I : IService
    {
        public V2ProxyCollection(Uri uri, ServiceProxyFactory serviceProxyFactory) : base(uri, serviceProxyFactory)
        { }

        public V2ProxyCollection(Uri uri) : base(uri)
        { }

        public async Task<bool> Call(Func<I, Task<bool>> action, bool allTrue = false)
        {
            var tasks = new List<Task<bool>>();

            foreach (var proxy in Values)
                tasks.Add(action(proxy));

            var array = await Task.WhenAll(tasks);

            return allTrue ? array.All(x => x) : array.Any(x => x);
        }

        /// <summary>
        /// Performs a method call on the first proxy in the collection
        /// </summary>
        /// <param name="action">The method to call on the proxy</param>
        /// <returns></returns>
        public async Task Call(Func<I, Task> action)
        {
            var tasks = new List<Task>();

            foreach (var proxy in Values)
                tasks.Add(action(proxy));

            await Task.WhenAll(tasks);
        }

        /// <summary>
        /// Performs a method call on the first proxy in the collection
        /// </summary>
        /// <typeparam name="X">The returned value</typeparam>
        /// <param name="action">The method to call on the proxy</param>
        /// <returns></returns>
        public async Task<X[]> Call<X>(Func<I, Task<X>> action)
        {
            var tasks = new List<Task<X>>();

            foreach (var proxy in Values)
                tasks.Add(action(proxy));

            return await Task.WhenAll(tasks);
        }

        protected void Log(string text)
        {
            Console.WriteLine($"{ DateTime.Now.ToString(CultureInfo.InvariantCulture)} :: ProxyCollection :: {text}");
        }
    }

    public class V2ProxyCollection<I, M> : V2ProxyCollection<I> where I : IBaseByte where M : BaseModel<Guid>
    {
        /// <summary>
        /// Creates a new instance of the proxy collection and fills the collection with the remote proxies for the provided service.
        /// </summary>
        /// <param name="uri">The service address.</param>
        /// <exception cref="FabricInvalidPartitionKeyException">Throws when the service provided has a partition count greater than 16</exception>
        public V2ProxyCollection(Uri uri, ServiceProxyFactory serviceProxyFactory) : base(uri, serviceProxyFactory)
        { }

        [Obsolete("This constructor creates a new ServiceProxyFactory. It is advised by Microsoft's documentation that creating a new factory " +
            "is an expensive operation and it should be cached and reused where possible. There is a ServiceProxyFactory created in StatefulServiceBase that can be " +
            "passed to the overload constructor of this class.")]
        public V2ProxyCollection(Uri uri) : base(uri)
        { }

        /// <summary>
        /// Performs the GetAll method call provided by <see cref="IBaseByte"/> on all the remote proxies in the collection, merging the results into one list
        /// </summary>
        /// <returns>The results of all the method calls</returns>
        public async Task<List<M>> GetAll()
        {
            string nameOfModel = typeof(M).Name;
            Log($"{ nameOfModel } : Started async retrieval of data");
            var stopwatch = Stopwatch.StartNew();

            var proxyTasks = new List<Task<byte[]>>();
            foreach (var proxy in this.Values)
                proxyTasks.Add(proxy.GetAll());

            var resultArray = await Task.WhenAll(proxyTasks);

            Log($"{ nameOfModel } : Finished async retrieval of data [{stopwatch.Elapsed}]");
            Log($"{ nameOfModel } : Started decompression and merge of data [{stopwatch.Elapsed}]");

            List<M> lstReturned = new List<M>();
            foreach (var item in resultArray)
            {
                var itemsPerPartition = JsonConvert.DeserializeObject<List<M>>(Compressor.Decompress(item));
                lstReturned.AddRange(itemsPerPartition);
                Log($"{ nameOfModel } : Partition items [{itemsPerPartition.Count()}]");
            }

            //var results = resultArray.SelectMany(
            //    objData => JsonConvert.DeserializeObject<List<M>>(Compressor.Decompress(objData))).ToList();

            stopwatch.Stop();
            Log($"{ nameOfModel } : Total items [{lstReturned.Count()}]");
            Log($"{ nameOfModel } : Finished decompression and merge of data [{stopwatch.Elapsed}]");

            return lstReturned;
        }
        public async Task<List<byte[]>> GetByDictionary(string key)
        {
            Log($"Started async retrieval of data using key {key}");
            var stopwatch = Stopwatch.StartNew();
            var proxyTasks = new List<Task<byte[]>>();
            foreach (var proxy in this.Values)
                proxyTasks.Add(proxy.GetAllByPartition(key));
            var results = (await Task.WhenAll(proxyTasks)).ToList();
            stopwatch.Stop();
            Log($"Finished async retrieval of data using key {key} [{stopwatch.Elapsed}]");
            return results;
        }

        public async Task<List<byte[]>> GetAllSecureDataByDictionary(string key, byte[] guidObjData)
        {
            Log($"Started async retrieval of data using key {key}");
            var stopwatch = Stopwatch.StartNew();

            var proxyTasks = new List<Task<byte[]>>();
            foreach (var proxy in this.Values)
                proxyTasks.Add(proxy.GetAllSecureDataByPartition(key, guidObjData));
            var results = (await Task.WhenAll(proxyTasks)).ToList();

            stopwatch.Stop();
            Log($"Finished async retrieval of data using key {key} [{stopwatch.Elapsed}]");
            return results;
        }

        /// <summary>
        /// Performs the GetByFilter method call provided by <see cref="IBaseByte"/> on all the remote proxies in the collection using the provided filter and merging the results into one list.
        /// </summary>
        /// <param name="filters">The filter used to determine the results returned</param>
        /// <returns>The filtered results of all the method calls</returns>
        public async Task<List<M>> GetByFilter(byte[] data)
        {
            Log("Started async retrieval of data");
            var stopwatch = Stopwatch.StartNew();

            var proxyTasks = new List<Task<byte[]>>();
            foreach (var proxy in this.Values)
                proxyTasks.Add(proxy.GetByFilter(data));

            var resultArray = await Task.WhenAll(proxyTasks);

            Log($"Finished async retrieval of data [{stopwatch.Elapsed}]");
            Log($"Started decompression and merge of data [{stopwatch.Elapsed}]");

            var results = resultArray.SelectMany(
                objData => JsonConvert.DeserializeObject<List<M>>(Compressor.Decompress(objData))).ToList();

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
            var objData = await this[partitionIndex].Get(id);

            Log($"Finished retrieval of data [{stopwatch.Elapsed}]");
            Log($"Started decompression and merge of data [{stopwatch.Elapsed}]");

            var result = JsonConvert.DeserializeObject<M>(Compressor.Decompress(objData));

            stopwatch.Stop();
            Log($"Finished decompression and merge of data [{stopwatch.Elapsed}]");

            return result;
        }

        /// <summary>
        /// Sorts the provided models into partitioned list and calls <see cref="StatefulServiceBase{T}.ProcessOperation(IEnumerable{T})"/> 
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

            await Task.Run(() => Parallel.ForEach(modelsDictionary, async (pair) =>
            {
                var errorObjectData = await this[pair.Key].ProcessOperation(JsonConvert.SerializeObject(pair.Value).Compress());
                lock (erroredModels)
                {
                    erroredModels.AddRange(JsonConvert.DeserializeObject<List<M>>(Compressor.Decompress(errorObjectData)));
                }
            }));

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
        //    var dbItems = JsonConvert.DeserializeObject<List<M>>(Compressor.Decompress(dbObjData));
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
                if(proxy is IDeleteAll deleteProxy)
                tasks.Add(deleteProxy.DeleteAll());
            }

            await Task.WhenAll(tasks);
        }
    }
}
