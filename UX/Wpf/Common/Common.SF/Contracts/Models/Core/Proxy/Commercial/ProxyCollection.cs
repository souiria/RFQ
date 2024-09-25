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
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport;
using Microsoft.ServiceFabric.Services.Remoting.V1.FabricTransport.Client;
using Newtonsoft.Json;

namespace Common.SF.Contracts.Models.Core.Proxy.Commercial
{
    /// <summary>
    /// A collection of remote proxies for service communication. It is designed to work in conjunction with <see cref="IBaseByte"/>
    /// but has functionality to allow any service with more than one partition to be used with this class.
    /// </summary>
    /// <typeparam name="I">The interface of the service you are communicating with.</typeparam>
    /// <typeparam name="M">The model type returned by the generic method calls from <see cref="IBaseByte"/></typeparam>
    [Obsolete("The ProxyCollection is being filtered out of the application. Please change this to use the V2ProxyCollection.")]
    public class ProxyCollection<I, M> : Dictionary<Range, I> where I : IBase where M : BaseModel<Guid>
    {
        /// <summary>
        /// Returns the value at the specified index. If index provided is within the range of an object key, 
        /// it will return that value
        /// </summary>
        /// <param name="keyValue">The index in the dictionary</param>
        /// <returns>The value at that index</returns>
        public I this[int keyValue]
        {
            get => this.First(x => x.Key.Within(keyValue)).Value;
            set
            {
                var key = this.First(x => x.Key.Within(keyValue)).Key;
                this[key] = value;
            }
        }

        /// <summary>
        /// Retrieves the range/key that the provided index is within
        /// </summary>
        /// <param name="keyValue">The index</param>
        /// <returns>The range/key that the index sits within</returns>
        public Range GetKey(int keyValue)
        {
            return Keys.First(key => key.Within(keyValue));
        }

        /// <summary>
        /// Creates a new instance of the proxy collection and fills the collection with the remote proxies for the provided service.
        /// </summary>
        /// <param name="uri">The service address.</param>
        /// <exception cref="FabricInvalidPartitionKeyException">Throws when the service provided has a partition count greater than 16</exception>
        [Obsolete("This constructor creates a new ServiceProxyFactory. It is advised by Microsoft's documentation that creating a new factory " +
            "is an expensive operation and it should be cached and reused where possible. There is a ServiceProxyFactory created in StatefulServiceBase that can be " +
            "passed to the other constructor of this class.")]
        public ProxyCollection(Uri uri)
        {
            using (var client = new FabricClient())
            {
                var task = client.QueryManager.GetPartitionListAsync(uri);
                task.Wait();
                var partitions = task.Result;

                foreach (var partition in partitions)
                {
                    var partitionInformation = (Int64RangePartitionInformation)partition.PartitionInformation;
                    Add(new Range(partitionInformation.LowKey, partitionInformation.HighKey),
                        ServiceProxy.Create<I>(uri, new ServicePartitionKey(partitionInformation.LowKey)));
                }
            }

            if (Count > 16)
                throw new FabricInvalidPartitionKeyException("Partition count for the selected service is greater than 16 and cannot be processed using" +
                    " the generic classes.");
        }

        public ProxyCollection(Uri uri, ServiceProxyFactory serviceProxyFactory)
        {
            using (var client = new FabricClient())
            {
                var task = client.QueryManager.GetPartitionListAsync(uri);
                task.Wait();
                var partitions = task.Result;

                foreach (var partition in partitions)
                {
                    var partitionInformation = (Int64RangePartitionInformation)partition.PartitionInformation;
                    Add(new Range(partitionInformation.LowKey, partitionInformation.HighKey),
                        serviceProxyFactory.CreateServiceProxy<I>(uri, new ServicePartitionKey(partitionInformation.LowKey)));
                }
            }

            if (Count > 16)
                throw new FabricInvalidPartitionKeyException("Partition count for the selected service is greater than 16 and cannot be processed using" +
                    " the generic classes.");
        }

        [Obsolete("This method creates a new ServiceProxyFactory. It is advised by Microsoft's documentation that creating a new factory " +
            "is an expensive operation and it should be cached and reused where possible.")]
        protected virtual ServiceProxyFactory ServiceFactoryProxy()
        {

            FabricTransportRemotingSettings settings = new FabricTransportRemotingSettings();
            settings.OperationTimeout = TimeSpan.FromMinutes(10);
            settings.MaxMessageSize = int.MaxValue;
            return new ServiceProxyFactory(
                (h) =>
                {
                    return new FabricTransportServiceRemotingClientFactory(settings);
                });
        }

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
                proxyTasks.Add(((IBaseByte)proxy).GetAll());

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
        public async Task<List<byte[]>> GetAllByDictionary(string key)
        {
            Log($"Started async retrieval of data using key {key}");
            var stopwatch = Stopwatch.StartNew();
            var proxyTasks = new List<Task<byte[]>>();
            foreach (var proxy in this.Values)
                proxyTasks.Add(((IBaseByte)proxy).GetAllByPartition(key));
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
        public async Task<List<M>> GetByFilter(byte[] filters)
        {
            Log("Started async retrieval of data");
            var stopwatch = Stopwatch.StartNew();

            var proxyTasks = new List<Task<byte[]>>();
            foreach (var proxy in this.Values)
                proxyTasks.Add(proxy.GetByFilter(filters));

            var resultArray = await Task.WhenAll(proxyTasks);

            Log($"Finished async retrieval of data [{stopwatch.Elapsed}]");
            Log($"Started decompression and merge of data [{stopwatch.Elapsed}]");

            var results = resultArray.SelectMany(
                objData => JsonConvert.DeserializeObject<List<M>>(Compressor.Decompress(objData))).ToList();

            stopwatch.Stop();
            Log($"Finished decompression and merge of data [{stopwatch.Elapsed}]");

            return results;
        }

        public async Task<List<byte[]>> GetByFilterByDictionary(string key, byte[] filters)
        {
            Log($"Started async retrieval of data using key {key}");
            var stopwatch = Stopwatch.StartNew();

            var proxyTasks = new List<Task<byte[]>>();
            foreach (var proxy in this.Values)
                proxyTasks.Add(proxy.GetByFilterByPartition(key, filters));

            var results = (await Task.WhenAll(proxyTasks)).ToList();

            stopwatch.Stop();
            Log($"Finished async retrieval of data using key {key} [{stopwatch.Elapsed}]");

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
            var objData = await ((IBaseByte)this[partitionIndex]).Get(id);

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
        //    var dbObjData = await ((IBaseByte)this[0]).GetAllDatabaseEntries();
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
                tasks.Add(proxy.DeleteAll());
            }

            await Task.WhenAll(tasks);
        }

        /// <summary>
        /// Merges the result set of multiple compressed service calls. These calls are made asynchronously
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="tasks"></param>
        /// <example>
        /// Below is an example of how to use this method.
        /// <code>
        ///  _proxy.MergeResultsOfAction<BaseMaterialModel>(_materialProxies.Values.Select(proxy => proxy.PerformServiceCall()));
        ///  </code>
        /// </example>
        /// <returns>A merged list of results</returns>
        public async Task<List<X>> MergeResultsOfAction<X>(IEnumerable<Task<byte[]>> tasks)
        {
            List<X> results = new List<X>();
            var array = await Task.WhenAll(tasks);
            return array.SelectMany(objData => JsonConvert.DeserializeObject<List<X>>(Compressor.Decompress(objData))).ToList();
        }

        public async Task<List<X>> MergeResultsOfAction<X>(Func<I, Task<byte[]>> action)
        {
            var tasks = new List<Task<byte[]>>();

            foreach (var proxy in Values)
                tasks.Add(action(proxy));

            var array = await Task.WhenAll(tasks);
            return array.SelectMany(objData => JsonConvert.DeserializeObject<List<X>>(Compressor.Decompress(objData))).ToList();
        }

        private void Log(string text)
        {
            Console.WriteLine($"{ DateTime.Now.ToString(CultureInfo.InvariantCulture)} :: ProxyCollection :: {text}");
        }
    }

    /// <summary>
    /// A collection of remote proxies for service communication. It is designed to be a lightweight collection and doesn't imlpement the method of <see cref="IBaseByte"/>.
    /// This is particually useful for callin stateless services.
    /// </summary>
    /// <typeparam name="I">The interface of the service you are communicating with.</typeparam>
    public class ProxyCollection<I> : Dictionary<Range, I> where I : IService
    {
        /// <summary>
        /// Returns the value at the specified index. If index provided is within the range of an object key, 
        /// it will return that value
        /// </summary>
        /// <param name="keyValue">The index in the dictionary</param>
        /// <returns>The value at that index</returns>
        public I this[int keyValue]
        {
            get => this.First(x => x.Key.Within(keyValue)).Value;
            set
            {
                var key = this.First(x => x.Key.Within(keyValue)).Key;
                this[key] = value;
            }
        }

        /// <summary>
        /// Retrieves the range/key that the provided index is within
        /// </summary>
        /// <param name="keyValue">The index</param>
        /// <returns>The range/key that the index sits within</returns>
        public Range GetKey(int keyValue)
        {
            return Keys.First(key => key.Within(keyValue));
        }

        public ProxyCollection(Uri uri, ServiceProxyFactory serviceProxyFactory)
        {
            using (var client = new FabricClient())
            {
                var task = client.QueryManager.GetPartitionListAsync(uri);
                task.Wait();
                var partitions = task.Result;

                foreach (var partition in partitions)
                {
                    if (partition.PartitionInformation is SingletonPartitionInformation singletonPartitionInformation)
                    {
                        Add(new Range(0, 15), serviceProxyFactory.CreateServiceProxy<I>(uri));
                    }
                    else
                    {
                        var partitionInformation = (Int64RangePartitionInformation)partition.PartitionInformation;
                        Add(new Range(partitionInformation.LowKey, partitionInformation.HighKey),
                            serviceProxyFactory.CreateServiceProxy<I>(uri, new ServicePartitionKey(partitionInformation.LowKey)));
                    }
                }
            }

            if (Count > 16)
                throw new FabricInvalidPartitionKeyException("Partition count for the selected service is greater than 16 and cannot be processed using" +
                    " the generic classes.");
        }

        /// <summary>
        /// Creates a new instance of the proxy collection and fills the collection with the remote proxies for the provided service.
        /// </summary>
        /// <param name="uri">The service address.</param>
        /// <exception cref="FabricInvalidPartitionKeyException">Throws when the service provided has a partition count greater than 16</exception>
        public ProxyCollection(Uri uri)
        {
            using (var client = new FabricClient())
            {
                var task = client.QueryManager.GetPartitionListAsync(uri);
                task.Wait();
                var partitions = task.Result;

                foreach (var partition in partitions)
                {
                    if (partition.PartitionInformation is SingletonPartitionInformation singletonPartitionInformation)
                    {
                        Add(new Range(0, 15), ServiceProxy.Create<I>(uri));
                    }
                    else
                    {
                        var partitionInformation = (Int64RangePartitionInformation)partition.PartitionInformation;
                        Add(new Range(partitionInformation.LowKey, partitionInformation.HighKey),
                            ServiceProxy.Create<I>(uri, new ServicePartitionKey(partitionInformation.LowKey)));
                    }
                }
            }

            if (Count > 16)
                throw new Exception("Partition count for the selected service is greater than 16 and cannot be processed using" +
                    " the generic classes.");
            this.Select(x => x.Key);
        }

        public async Task<List<X>> MergeResultsOfAction<X>(IEnumerable<Task<byte[]>> tasks)
        {
            List<X> results = new List<X>();
            var array = await Task.WhenAll(tasks);
            return array.SelectMany(objData => JsonConvert.DeserializeObject<List<X>>(Compressor.Decompress(objData))).ToList();

        }
    }
}
