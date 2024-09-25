/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ProxyBase64.cs
Function           :   Collecting the records from service.
Created By         :  
Created on         :  
Revision History   :   [13-Jan-2020] : Amit Agarwal
*                  :   [] : created class w.r.t memory leak in byte array read/write
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading.Tasks;
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Infrastructure.Extensions;
using Common.Core.Infrastructure.Helpers;
using Common.SF.Contracts.Interfaces.Base.Base64;
using Common.SF.Contracts.Interfaces.Base.Byte;
using Common.SF.Infrastructure.Core;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Newtonsoft.Json;

namespace Common.SF.Contracts.Models.Core.Proxy
{
    /// <summary>
    /// A class that stores the partition information of a service proxy and attempt to provide useful methods for you to connect to
    /// services safely. This should be used instead of a <see cref="IService"/> proxy interface.
    /// </summary>
    /// <typeparam name="I">The interface of the service you wish to connect to.</typeparam>
    public class ProxyBase64<I> where I : IService
    {
        private readonly Random _random = new Random();
        private readonly IWrappedFabricClient _fabricClient = FabricClientProvider.FabricClient;

        private List<Range> Ranges { get; set; }

        /// <summary>
        /// Return a proxy to connect to a stateless service instead of attempting to determine partition information.
        /// </summary>
        public I Stateless => CreateProxy();

        /// <summary>
        /// Returns a proxy to connect to a random partition for the desired service.
        /// </summary>
        public I RandomPartition => this[_random.Next(16)];

        private Uri Address { get; }
        private IServiceProxyFactory ServiceProxyFactory { get; }

        #region Accessors

        /// <summary>
        /// Returns a proxy for the desired partition number. This number must be between 0 and 15.
        /// </summary>
        /// <remarks>
        /// This method finds the partition which contains the provided value within it's range.
        /// </remarks>
        /// <param name="keyValue">The desired partition.</param>
        /// <returns>A <see cref="IService"/> proxy.</returns>
        public I this[int keyValue] => CheckPartitions(() => CreateProxy(Ranges.First(x => x.Within(keyValue)))).GetAwaiter().GetResult();

        /// <summary>
        /// Returns a proxy for the desired partition number. This number must be between 0 and 15.
        /// </summary>
        /// <remarks>
        /// This method finds the partition which contains the provided value within it's range.
        /// </remarks>
        /// <param name="keyValue">The desired partition.</param>
        /// <returns>A <see cref="IService"/> proxy.</returns>
        public I this[long keyValue] => CheckPartitions(() => CreateProxy(Ranges.First(x => x.Within(keyValue)))).GetAwaiter().GetResult();

        /// <summary>
        /// Returns a proxy for the desired partition number. This number must be between 0 and 15.
        /// </summary>
        /// <remarks>
        /// This method finds the partition which contains the provided value within it's range.
        /// </remarks>
        /// <param name="range">The range of the desired partition</param>
        /// <returns>A <see cref="IService"/> proxy.</returns>
        public I this[Range range] => CheckPartitions(() => CreateProxy(Ranges.First(x => x.Equals(range)))).GetAwaiter().GetResult();

        #endregion

        /// <summary>
        /// Create a new proxy for the desired address.
        /// </summary>
        /// <param name="uri">The address to the service you wish to connect to.</param>
        public ProxyBase64(Uri uri, IServiceProxyFactory proxyFactory)
        {
            Address = uri;
            ServiceProxyFactory = proxyFactory;
        }

        private async Task<T> CheckPartitions<T>(Func<T> func)
        {
            if (Ranges == null)
            {
                Ranges = await EstablishPartitions();
            }

            try
            {
                if (Ranges.Count == 0)
                    throw new ArgumentException("Service cannot be called in this way, as it is a Stateless Service. Use the Stateless property of this class instead");

                return func();
            }
            catch
            {
                Ranges = null;
                throw;
            }
        }

        private async Task<List<Range>> EstablishPartitions()
        {
            var partitions = await _fabricClient.QueryManager.GetPartitionListAsync(Address);

            if (partitions.Count > 16)
                throw new FabricInvalidPartitionKeyException("Partition count for the selected service is greater than 16 and cannot be processed using" +
                    " the generic classes.");

            var ranges = new List<Range>();

            foreach (var partition in partitions)
            {
                switch (partition.PartitionInformation)
                {
                    case IWrappedSingletonPartitionInformation _:
                        return ranges;

                    case IWrappedInt64RangePartitionInformation int64RangePartitionInformation when int64RangePartitionInformation.LowKey < 0:
                        throw new ArgumentOutOfRangeException(nameof(int64RangePartitionInformation.LowKey), "Low and high key for partitions must be set to 0 and 15");

                    case IWrappedInt64RangePartitionInformation int64RangePartitionInformation when int64RangePartitionInformation.HighKey > 15:
                        throw new ArgumentOutOfRangeException(nameof(int64RangePartitionInformation.HighKey), "Low and high key for partitions must be set to 0 and 15");

                    case IWrappedInt64RangePartitionInformation int64RangePartitionInformation:
                        ranges.Add(new Range(int64RangePartitionInformation.LowKey, int64RangePartitionInformation.HighKey));
                        break;

                    default:
                        throw new ArgumentException("Service partitions are not of an expected type Int64RangePartitionInformation or SingletonPartitionInformation");
                }
            }

            return ranges;
        }

        private I CreateProxy(Range range = null)
        {
            return range != null ? ServiceProxyFactory.CreateServiceProxy<I>(Address, new ServicePartitionKey(range.Low)) : ServiceProxyFactory.CreateServiceProxy<I>(Address);
        }

        /// <summary>
        /// Return the <see cref="Range"/> of a partition where the provided value is within it Low and High key.
        /// </summary>
        /// <param name="key">The desired partition key.</param>
        /// <returns>The range of the partition.</returns>
        public Range GetKey(long key)
        {
            return Ranges.First(range => range.Within(key));
        }

        #region All

        //TODO: Modify the UX service api client to expect an array of an array of byte (string[]) instead of needing to convert this data to a model to then be compressed again before returning in the ServiceApi service.

        /// <summary>
        /// Performs a service method on all partitions and converts the resulting object data to a list of entities. This is commonly used
        /// for GetAll methods.
        /// </summary>
        /// <typeparam name="X">The deserialized return type.</typeparam>
        /// <param name="func">The method to be performed on each partition.</param>
        /// <param name="isSingular">Determines whether each partition returns a singular entity or multiple entities for deserialization.</param>
        /// <returns>A task containing a list of the returned results deserialized.</returns>
        public async Task<List<X>> All<X>(Func<I, Task<string>> func, bool isSingular = false)
        {
            return await await CheckPartitions(async () =>
            {
                var tasks = Ranges.Select(proxy => func(CreateProxy(proxy)));
                var objDataArray = await Task.WhenAll(tasks);

                var results = isSingular
                    ? objDataArray.Select(objData => JsonConvert.DeserializeObject<X>(objData.DecompressBase64()))
                    : objDataArray.SelectMany(
                        objData => JsonConvert.DeserializeObject<IEnumerable<X>>(objData.DecompressBase64()));

                return results.ToList();
            });
        }

        /// <summary>
        /// Performs a service method on all partitions, returning the results in an array. This is commonly used for GetAll methods.
        /// </summary>
        /// <typeparam name="X">The return type of the service call.</typeparam>
        /// <param name="func">The method to be performed on each partition.</param>
        /// <returns>A task containing an array of the return type.</returns>
        public async Task<X[]> All<X>(Func<I, Task<X>> func)
        {
            return await await CheckPartitions(async () =>
            {
                var tasks = Ranges.Select(proxy => func(CreateProxy(proxy)));
                return await Task.WhenAll(tasks);
            });
        }

        /// <summary>
        /// Performs a service method on all partitions.
        /// </summary>
        /// <param name="func">The method to be performed on each partition.</param>
        /// <returns></returns>
        public async Task All(Func<I, Task> func)
        {
            await await CheckPartitions(async () =>
            {
                var tasks = Ranges.Select(proxy => func(CreateProxy(proxy)));
                await Task.WhenAll(tasks);
            });
        }

        #endregion

        #region ByIds string

        /// <summary>
        /// Performs a method call on a service by deserializing the provided data to a IEnumerable of <see cref="IId{T}"/> and uses the Id property
        /// of each model to determine which partitions the method should be called on.
        /// <para>
        /// This will only accept <see cref="Guid"/> as the <see cref="IId{T}"/> type.
        /// </para>
        /// </summary>
        /// <typeparam name="TType">The type to deserialize the data passed in to.</typeparam>
        /// <param name="objData">The object data to be deserialized.</param>
        /// <param name="func">The method to be performed on a partition using the filtered list of objects for it.</param>
        /// <returns></returns>
        public async Task ByIds<TType>(string objData, Func<I, string, Task> func) where TType : IId<Guid>
        {
            await await CheckPartitions(async () =>
            {
                var modelsDictionary = new Dictionary<Range, List<IId<Guid>>>();
                var entities = JsonConvert.DeserializeObject<IEnumerable<TType>>(objData.DecompressBase64());

                foreach (var entity in entities)
                {
                    var partitionRangeKey = GetKey(entity.Id.ToPartitionKey());

                    if (!modelsDictionary.ContainsKey(partitionRangeKey))
                        modelsDictionary.Add(partitionRangeKey, new List<IId<Guid>>());

                    modelsDictionary[partitionRangeKey].Add(entity);
                }

                var tasks = modelsDictionary.Select(pair => func(this[pair.Key], JsonConvert.SerializeObject(pair.Value).CompressBase64()));
                await Task.WhenAll(tasks);
            });
        }

        /// <summary>
        /// Performs a method call on a service by deserializing the provided data to a IEnumerable of <see cref="IId{T}"/> and uses the Id property
        /// of each model to determine which partitions the method should be called on. It then deserializes the returned data to the type provided and returns
        /// it as a <see cref="List{T}"/>.
        /// <para>
        /// This will only accept <see cref="Guid"/> as the <see cref="IId{T}"/> type.
        /// </para>
        /// </summary>
        /// <typeparam name="TType">The type to deserialize the passed objData and the returned objData to.</typeparam>
        /// <param name="objData">The compressed list of entities to be filtered.</param>
        /// <param name="func">The method to be performed on a partition using the filtered list of objects for it.</param>
        /// <param name="isSingular">Determines whether each partition returns a singular entity or multiple entities for deserialization.</param>
        /// <returns></returns>
        public async Task<List<TType>> ByIds<TType>(string objData, Func<I, string, Task<string>> func, bool isSingular = false) where TType : IId<Guid>
        {
            return await await CheckPartitions(async () =>
            {
                var modelsDictionary = new Dictionary<Range, List<IId<Guid>>>();
                var entities = JsonConvert.DeserializeObject<IEnumerable<TType>>(objData.DecompressBase64());

                foreach (var entity in entities)
                {
                    var partitionRangeKey = GetKey(entity.Id.ToPartitionKey());

                    if (!modelsDictionary.ContainsKey(partitionRangeKey))
                        modelsDictionary.Add(partitionRangeKey, new List<IId<Guid>>());

                    modelsDictionary[partitionRangeKey].Add(entity);
                }

                var tasks = modelsDictionary.Select(pair => func(this[pair.Key], JsonConvert.SerializeObject(pair.Value).CompressBase64()));
                var objDataArray = await Task.WhenAll(tasks);

                var results = isSingular
                     ? objDataArray.Select(data => JsonConvert.DeserializeObject<TType>(data.DecompressBase64()))
                     : objDataArray.SelectMany(data => JsonConvert.DeserializeObject<IEnumerable<TType>>(data.DecompressBase64()));

                return results.ToList();
            });
        }

        /// <summary>
        /// Performs a method call on a service by deserializing the provided data to a IEnumerable of <see cref="IId{T}"/> and uses the Id property
        /// of each model to determine which partitions the method should be called on. It then deserializes the returned data to the type provided and returns
        /// it as a <see cref="List{T}"/>.
        /// <para>
        /// This will only accept <see cref="Guid"/> as the <see cref="IId{T}"/> type.
        /// </para>
        /// </summary>
        /// <typeparam name="TReturn">The type to deserialize the returned objData to.</typeparam>
        /// <typeparam name="TInput">The type to deserialize the data passed in to.</typeparam>
        /// <param name="objData">The compressed list of entities to be filtered.</param>
        /// <param name="func">The method to be performed on a partition using the filtered list of objects for it.</param>
        /// <param name="isSingular">Determines whether each partition returns a singular entity or multiple entities for deserialization.</param>
        /// <returns></returns>
        public async Task<List<TReturn>> ByIds<TInput, TReturn>(string objData, Func<I, string, Task<string>> func, bool isSingular = false) where TInput : IId<Guid>
        {
            return await await CheckPartitions(async () =>
            {
                var modelsDictionary = new Dictionary<Range, List<IId<Guid>>>();
                var entities = JsonConvert.DeserializeObject<IEnumerable<TInput>>(objData.DecompressBase64());

                foreach (var entity in entities)
                {
                    var partitionRangeKey = GetKey(entity.Id.ToPartitionKey());

                    if (!modelsDictionary.ContainsKey(partitionRangeKey))
                        modelsDictionary.Add(partitionRangeKey, new List<IId<Guid>>());

                    modelsDictionary[partitionRangeKey].Add(entity);
                }

                var tasks = modelsDictionary.Select(pair => func(this[pair.Key], JsonConvert.SerializeObject(pair.Value).DecompressBase64()));
                var objDataArray = await Task.WhenAll(tasks);

                var results = isSingular
                     ? objDataArray.Select(data => JsonConvert.DeserializeObject<TReturn>(data.DecompressBase64()))
                     : objDataArray.SelectMany(data => JsonConvert.DeserializeObject<IEnumerable<TReturn>>(data.DecompressBase64()));

                return results.ToList();
            });
        }

        /// <summary>
        /// Performs a method call on a service by deserializing the provided data to a IEnumerable of <see cref="IId{T}"/> and uses the Id property
        /// of each model to determine which partitions the method should be called on. It then returns the results of each partition in an array.
        /// <para>
        /// This will only accept <see cref="Guid"/> as the <see cref="IId{T}"/> type.
        /// </para>
        /// </summary>
        /// <typeparam name="TType">The type to deserialize the data passed in to.</typeparam>
        /// <param name="objData">The compressed list of entities to be filtered.</param>
        /// <param name="func">The method to be performed on a partition using the filtered list of objects for it.</param>
        /// <returns></returns>
        public async Task<TType[]> ByIds<TType>(string objData, Func<I, string, Task<TType>> func) where TType : IId<Guid>
        {
            return await await CheckPartitions(async () =>
            {
                var modelsDictionary = new Dictionary<Range, List<IId<Guid>>>();
                var entities = JsonConvert.DeserializeObject<IEnumerable<TType>>(objData.DecompressBase64());

                foreach (var entity in entities)
                {
                    var partitionRangeKey = GetKey(entity.Id.ToPartitionKey());

                    if (!modelsDictionary.ContainsKey(partitionRangeKey))
                        modelsDictionary.Add(partitionRangeKey, new List<IId<Guid>>());

                    modelsDictionary[partitionRangeKey].Add(entity);
                }

                var tasks = modelsDictionary.Select(pair => func(this[pair.Key], JsonConvert.SerializeObject(pair.Value).CompressBase64()));
                return await Task.WhenAll(tasks);
            });
        }

        /// <summary>
        /// Performs a method call on a service by deserializing the provided data to a IEnumerable of <see cref="IId{T}"/> and uses the Id property
        /// of each model to determine which partitions the method should be called on. It then returns the results of each partition in an array.
        /// <para>
        /// This will only accept <see cref="Guid"/> as the <see cref="IId{T}"/> type.
        /// </para>
        /// </summary>
        /// <typeparam name="TInput">The type to deserialize the data passed in to.</typeparam>
        /// <typeparam name="TReturn">The type to the returned entities.</typeparam>
        /// <param name="objData">The compressed list of entities to be filtered.</param>
        /// <param name="func">The method to be performed on a partition using the filtered list of objects for it.</param>
        /// <returns></returns>
        public async Task<TReturn[]> ByIds<TInput, TReturn>(string objData, Func<I, string, Task<TReturn>> func) where TInput : IId<Guid>
        {
            return await await CheckPartitions(async () =>
            {
                var modelsDictionary = new Dictionary<Range, List<IId<Guid>>>();
                var entities = JsonConvert.DeserializeObject<IEnumerable<TInput>>(objData.DecompressBase64());

                foreach (var entity in entities)
                {
                    var partitionRangeKey = GetKey(entity.Id.ToPartitionKey());

                    if (!modelsDictionary.ContainsKey(partitionRangeKey))
                        modelsDictionary.Add(partitionRangeKey, new List<IId<Guid>>());

                    modelsDictionary[partitionRangeKey].Add(entity);
                }

                var tasks = modelsDictionary.Select(pair => func(this[pair.Key], JsonConvert.SerializeObject(pair.Value).CompressBase64()));
                return await Task.WhenAll(tasks);
            });
        }

        #endregion

        #region ByIds IEnumerable

        /// <summary>
        /// Performs a method call on a service by enumerating the Id property of each model provided
        /// to determine which partitions the method should be called on.
        /// <para>
        /// This will only accept <see cref="Guid"/> as the <see cref="IId{T}"/> type.
        /// </para>
        /// </summary>
        /// <param name="entities">A list of entities that implement <see cref="IId{T}"/> to be processed</param>
        /// <param name="func">The method to be performed on a partition using the filtered list of objects for it.</param>
        /// <returns></returns>
        public async Task ByIds(IEnumerable<IId<Guid>> entities, Func<I, string, Task> func)
        {
            await await CheckPartitions(async () =>
            {
                var modelsDictionary = new Dictionary<Range, List<IId<Guid>>>();
                foreach (var entity in entities)
                {
                    var partitionRangeKey = GetKey(entity.Id.ToPartitionKey());

                    if (!modelsDictionary.ContainsKey(partitionRangeKey))
                        modelsDictionary.Add(partitionRangeKey, new List<IId<Guid>>());

                    modelsDictionary[partitionRangeKey].Add(entity);
                }

                var tasks = modelsDictionary.Select(pair => func(this[pair.Key], JsonConvert.SerializeObject(pair.Value).CompressBase64()));
                await Task.WhenAll(tasks);
            });
        }

        /// <summary>
        /// Performs a method call on a service by enumerating the Id property of each model provided
        /// to determine which partitions the method should be called on. It then deserializes the returned data to the type provided and returns
        /// it as a <see cref="List{T}"/>.
        /// <para>
        /// This will only accept <see cref="Guid"/> as the <see cref="IId{T}"/> type.
        /// </para>
        /// </summary>
        /// <typeparam name="TReturn">The type to deserialize the returned objData to.</typeparam>
        /// <param name="entities">A list of entities that implement <see cref="IId{T}"/> to be processed</param>
        /// <param name="func">The method to be performed on a partition using the filtered list of objects for it.</param>
        /// <param name="isSingular">Determines whether each partition returns a singular entity or multiple entities for deserialization.</param>
        /// <returns></returns>
        public async Task<List<TReturn>> ByIds<TReturn>(IEnumerable<IId<Guid>> entities, Func<I, string, Task<string>> func, bool isSingular = false)
        {
            return await await CheckPartitions(async () =>
            {
                var modelsDictionary = new Dictionary<Range, List<IId<Guid>>>();
                foreach (var entity in entities)
                {
                    var partitionRangeKey = GetKey(entity.Id.ToPartitionKey());

                    if (!modelsDictionary.ContainsKey(partitionRangeKey))
                        modelsDictionary.Add(partitionRangeKey, new List<IId<Guid>>());

                    modelsDictionary[partitionRangeKey].Add(entity);
                }

                var tasks = modelsDictionary.Select(pair => func(this[pair.Key], JsonConvert.SerializeObject(pair.Value).CompressBase64()));
                var objDataArray = await Task.WhenAll(tasks);

                var results = isSingular
                     ? objDataArray.Select(data => JsonConvert.DeserializeObject<TReturn>(data.DecompressBase64()))
                     : objDataArray.SelectMany(data => JsonConvert.DeserializeObject<IEnumerable<TReturn>>(data.DecompressBase64()));

                return results.ToList();
            });
        }

        /// <summary>
        /// Performs a method call on a service by enumerating the Id property of each model provided
        /// to determine which partitions the method should be called on. It then returns the results of each partition in an array.
        /// <para>
        /// This will only accept <see cref="Guid"/> as the <see cref="IId{T}"/> type.
        /// </para>
        /// </summary>
        /// <typeparam name="TReturn">The type to the returned entities.</typeparam>
        /// <param name="entities">A list of entities that implement <see cref="IId{T}"/> to be processed</param>
        /// <param name="func">The method to be performed on a partition using the filtered list of objects for it.</param>
        /// <returns></returns>
        public async Task<TReturn[]> ByIds<TReturn>(IEnumerable<IId<Guid>> entities, Func<I, string, Task<TReturn>> func)
        {
            return await await CheckPartitions(async () =>
            {
                var modelsDictionary = new Dictionary<Range, List<IId<Guid>>>();
                foreach (var entity in entities)
                {
                    var partitionRangeKey = GetKey(entity.Id.ToPartitionKey());

                    if (!modelsDictionary.ContainsKey(partitionRangeKey))
                        modelsDictionary.Add(partitionRangeKey, new List<IId<Guid>>());

                    modelsDictionary[partitionRangeKey].Add(entity);
                }

                var tasks = modelsDictionary.Select(pair => func(this[pair.Key], JsonConvert.SerializeObject(pair.Value).CompressBase64()));
                return await Task.WhenAll(tasks);
            });
        }

        #endregion

        #region ById

        /// <summary>
        /// Performs a method call on a service by using the provided id to determine which partition the method should be called on.
        /// </summary>
        /// <typeparam name="TReturn">The return type of the service.</typeparam>
        /// <param name="id">The id to determine the partition with.</param>
        /// <param name="func">The method to be performed on the resolved partition.</param>
        /// <returns>The result of the service call.</returns>
        public async Task<TReturn> ById<TReturn>(Guid id, Func<I, Task<TReturn>> func)
        {
            return await await CheckPartitions(async () =>
            {
                var partitionRangeKey = GetKey(id.ToPartitionKey());

                return await func(this[partitionRangeKey]);
            });
        }

        /// <summary>
        /// Performs a method call on a service by using the provided id to determine which partition the method should be called on
        /// and deserializes the data return to the provided type.
        /// </summary>
        /// <typeparam name="TReturn">The type to deserialize the returned data to.</typeparam>
        /// <param name="id">The id to determine the partition with.</param>
        /// <param name="func">The method to be performed on the resolved partition.</param>
        /// <returns>The deserialized result of the service call.</returns>
        public async Task<TReturn> ById<TReturn>(Guid id, Func<I, Task<string>> func)
        {
            return await await CheckPartitions(async () =>
            {
                var partitionRangeKey = GetKey(id.ToPartitionKey());

                var objData = await func(this[partitionRangeKey]);
                return JsonConvert.DeserializeObject<TReturn>(objData.DecompressBase64());
            });
        }

        /// <summary>
        /// Performs a method call on a service by using the provided id to determine which partition the method should be called on.
        /// </summary>
        /// <param name="id">The id to determine the partition with.</param>
        /// <param name="func">The method to be performed on the resolved partition.</param>
        /// <returns></returns>
        public async Task ById(Guid id, Func<I, Guid, Task> func)
        {
            await await CheckPartitions(async () =>
            {
                var partitionRangeKey = GetKey(id.ToPartitionKey());
                await func(this[partitionRangeKey], id);
            });
        }

        #endregion

        //TODO: Remove the use of these methods and remove this section.
        #region IBase Methods

        public async Task<List<X>> GetAll<X>()
        {
            return await await CheckPartitions(async () =>
            {
                if (!typeof(I).GetInterfaces().Contains(typeof(IBase64)))
                    throw new ArgumentException($"Provided interface is not of type {nameof(IBase64)}", nameof(I));

                var tasks = Ranges.Select(proxy => ((IBase64)CreateProxy(proxy)).GetAll());
                var objDataArray = await Task.WhenAll(tasks);
                var results = objDataArray.SelectMany(objData =>
                    JsonConvert.DeserializeObject<IEnumerable<X>>(objData.DecompressBase64()));
                return results.ToList();
            });
        }

        public async Task<List<X>> ProcessOperation<X>(IEnumerable<X> models) where X : BaseModel<Guid>
        {
            return await await CheckPartitions(async () =>
            {
                if (!typeof(I).GetInterfaces().Contains(typeof(IBase64)))
                    throw new ArgumentException($"Provided interface is not of type {nameof(IBase64)}", nameof(I));

                Dictionary<Range, List<X>> modelsDictionary = new Dictionary<Range, List<X>>();

                foreach (var model in models)
                {
                    var partitionRangeKey = GetKey(model.Id.ToPartitionKey());

                    if (!modelsDictionary.ContainsKey(partitionRangeKey))
                        modelsDictionary.Add(partitionRangeKey, new List<X>());

                    modelsDictionary[partitionRangeKey].Add(model);
                }

                var tasks = modelsDictionary.Select(pair =>
                    ((IBase64)this[pair.Key]).ProcessOperation(JsonConvert.SerializeObject(pair.Value).CompressBase64()));
                var objDataArray = await Task.WhenAll(tasks);

                var results = objDataArray.SelectMany(objData =>
                    JsonConvert.DeserializeObject<List<X>>(objData.DecompressBase64()));
                return results.ToList();
            });
        }

        public async Task<X> Get<X>(Guid id)
        {
            return await await CheckPartitions(async () =>
            {
                if (!typeof(I).GetInterfaces().Contains(typeof(IBase64)))
                    throw new ArgumentException($"Provided interface is not of type {nameof(IBase64)}", nameof(I));

                var objData = await ((IBase64)this[id.ToPartitionKey()]).Get(id);
                var result = JsonConvert.DeserializeObject<X>(objData.DecompressBase64());
                return result;
            });
        }

        public async Task<List<X>> GetByFilter<X>(IEnumerable<FilterCollectionModel> filters)
        {
            return await await CheckPartitions(async () =>
            {
                if (!typeof(I).GetInterfaces().Contains(typeof(IBase64)))
                    throw new ArgumentException($"Provided interface is not of type {nameof(IBase64)}", nameof(I));

                // var filterData = JsonConvert.SerializeObject(filters).CompressBase64();
                var tasks = Ranges.Select(proxy => ((IBase64)CreateProxy(proxy)).GetByFilter(filters));
                var objDataArray = await Task.WhenAll(tasks);
                var results = objDataArray.SelectMany(objData =>
                    JsonConvert.DeserializeObject<IEnumerable<X>>(objData.DecompressBase64()));
                return results.ToList();
            });
        }

        //public async Task<List<X>> GetByFilter<X>(IEnumerable<FilterCollectionModel> filterData)
        //{
        //    return await await CheckPartitions(async () =>
        //    {
        //        if (!typeof(I).GetInterfaces().Contains(typeof(IBase64)))
        //            throw new ArgumentException($"Provided interface is not of type {nameof(IBase64)}", nameof(I));

        //        var tasks = Ranges.Select(proxy => ((IBase64)CreateProxy(proxy)).GetByFilter(filterData));
        //        var objDataArray = await Task.WhenAll(tasks);
        //        var results = objDataArray.SelectMany(objData =>
        //            JsonConvert.DeserializeObject<IEnumerable<X>>(objData.DecompressBase64()));
        //        return results.ToList();
        //    });
        //}

        #endregion
    }
}
