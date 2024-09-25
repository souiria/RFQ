using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Fabric;
using System.Fabric.Health;
using System.Fabric.Query;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Administration.Security;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Contracts.Models.Core.Logging;
using Common.Core.Contracts.Models.Core.Settings.Commercial;
using Common.Core.Infrastructure.Extensions;
using Common.Core.Infrastructure.Helpers;
using Common.SF.Contracts.Interfaces.Administration.Security.DataFilter;
using Common.SF.Contracts.Interfaces.Base;
using Common.SF.Contracts.Interfaces.Base.Base64;
using Common.SF.Contracts.Interfaces.Core;
using Common.SF.Contracts.Interfaces.Core.Logging;
using Common.SF.Contracts.Interfaces.Core.Notifications;
using Common.SF.Contracts.Interfaces.Core.Settings;
using Common.SF.Contracts.Models.Core.Notifications;
using Common.SF.Contracts.Models.Core.Proxy;
using Common.SF.Contracts.Models.Core.Proxy.Commercial;
using Common.SF.Infrastructure.AsyncEnumerable.Extensions;
using Common.SF.Infrastructure.EntityFramework.Commercial;
using Common.SF.Infrastructure.Helpers;
using Common.SF.Infrastructure.PubSub.Helpers;
using Common.SF.Infrastructure.PubSub.Interfaces;
using Common.SF.Infrastructure.PubSub.Models;
using Common.SF.Infrastructure.PubSub.Wrappers;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.V1.FabricTransport.Client;
using Newtonsoft.Json;
using StatefulService = Microsoft.ServiceFabric.Services.Runtime.StatefulService;

//Not needed because it is used in the other StatefulServiceBase
//[assembly: FabricTransportServiceRemotingProvider(RemotingListenerVersion = RemotingListenerVersion.V2_1 | RemotingListenerVersion.V1, RemotingClientVersion = RemotingClientVersion.V2_1)]

namespace Common.SF.Infrastructure.Base.Commercial
{
    public abstract class StatefulServiceBase<T> : StatefulServiceBase, IBase where T : BaseModel<Guid>
    {
        #region Properties

        #region Remoting Interfaces    

        /// <summary>
        /// The proxy to the Notification service. This is created if notification implementation has been set to true
        /// </summary>
        private ISubscriptions _subscriptions;
        protected ISubscriptions Subscriptions
        {
            get
            {
                try
                {
                    return _subscriptions ?? (_subscriptions = ServiceProxyFactory.CreateServiceProxy<ISubscriptions>(UtilityProxy.InitializeNotifications().Result, new ServicePartitionKey(0)));
                }
                catch (Exception e)
                {
                    LogTextOutput($"Remoting proxy could not be created: {e.Message}");
                    LogHealthState(nameof(UtilityProxy), $"Remoting proxy could not be created: {e.Message}", HealthState.Warning, TimeSpan.FromMinutes(1), true).Wait();
                    return null;
                }
            }
        }

        /// <summary>
        /// The proxy to the Security Filter service.
        /// </summary>
        private Proxy<IDataFilter> _serviceDataFilter;
        protected Proxy<IDataFilter> ServiceDataFilter
        {
            get
            {
                try
                {
                    return _serviceDataFilter ?? (_serviceDataFilter = new Proxy<IDataFilter>(UtilityProxy.InitializeDataFilter().Result, ServiceProxyFactory));
                }
                catch (Exception e)
                {
                    LogTextOutput($"Remoting proxy could not be created: {e.Message}");
                    LogHealthState(nameof(UtilityProxy), $"Remoting proxy could not be created: {e.Message}", HealthState.Warning, TimeSpan.FromMinutes(1), true).Wait();
                    return null;
                }
            }
        }

        #endregion

        #region Constant Values

        protected const string _cacheName = "_cacheDictionary";
        protected const string _notificationQueue = "_notificationQueue";
        protected const string _auditQueue = "_auditQueue";
        protected const string _datasyncQueue = "datasyncQueue";
        protected readonly string[] _keysIndex16Bit = { "a", "b", "c", "d", "e", "f", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        #region Setting Names
        protected const string AutoCRUDNotificationSetting = "Automated CRUD Notifications";
        protected const string DatabaseSyncSetting = "Database Synchronization";
        //protected const string LegacySystemSyncSetting = "Legacy System Synchronization";
        #endregion

        #endregion

        #region Setting Properties

        protected string DatabaseSyncConnection { get; set; }
        protected bool AutoCRUDCurrentlyEnabled { get; set; }
        protected bool IsAutomatedNotificationsEnabled { get; set; }
        protected bool IsDatabaseSyncEnabled { get; set; }
        protected bool IsAuditLoggingEnabled { get; set; }
        //protected bool IsLegacySystemDataSyncEnabled { get; set; }

        #endregion

        #endregion

        #region ctors

        /// <summary>
        /// Creates an instance of a default Stateful Service
        /// </summary>
        /// <param name="context">The context for the stateful service</param>
        /// <param name="implementNotifications">Represents whether the service should automatically create <see cref="Subscriptions"/>s after crud operations.
        /// If this option is set to True, any Crud method that has been overriden will not create <see cref="Subscriptions"/>s and must be implemented manually.</param>
        /// <param name="connectDatabase">Represents whether the service should mirror crud operations to a database connection</param>
        protected StatefulServiceBase(StatefulServiceContext context, IReliableStateManagerReplica stateManagerReplica,
            IServiceProxyFactory serviceProxyFactory = null, IActorProxyFactory actorProxyFactory = null) : base(
            context, stateManagerReplica, serviceProxyFactory, actorProxyFactory)
        {

        }

        #endregion

        #region Setup

        /// <summary>
        /// This is the main entry point for your service replica.
        /// This method executes when this replica of your service becomes primary and has write status.
        /// </summary>
        /// <remarks>
        /// Starts the configuration settings refreshing and Crud queue consumption tasks in the background.
        /// </remarks>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service replica.</param>
        protected override Task BaseRun(CancellationToken cancellationToken)
        {
            var tasks = new Task[3];
            tasks[0] = Task.Run(() => NotificationQueue(cancellationToken), cancellationToken);
            tasks[1] = Task.Run(() => AuditQueue(cancellationToken), cancellationToken);
            tasks[2] = Task.Run(() => DataSyncQueue(cancellationToken), cancellationToken);
            return Task.WhenAll(tasks);
        }


        #region Queues

        protected async Task RegisterCRUDChannels(bool create)
        {
            if (create)
                await Subscriptions.CreateCrudChannels(ServiceName, CrudOperationType.Create);

            else
                await Subscriptions.CreateCrudChannels(ServiceName, CrudOperationType.Delete);

            AutoCRUDCurrentlyEnabled = IsAutomatedNotificationsEnabled;
        }

        private async Task NotificationQueue(CancellationToken cancellationToken)
        {
            var failCount = 0;
            while (!cancellationToken.IsCancellationRequested)
            {

                var queue = await StateManager.GetOrAddAsync<IReliableQueue<T>>(_notificationQueue);
                using (var tx = StateManager.CreateTransaction())
                {
                    try
                    {
                        var result = await queue.TryDequeueAsync(tx);
                        if (result.HasValue)
                        {
                            var model = result.Value;
                            await PublishNotification(model);
                        }
                        await tx.CommitAsync();
                    }
                    catch (Exception e)
                    {
                        if (failCount < 5)
                        {
                            tx.Abort();
                            failCount++;
                            await LogHealthState("RunAsync", $"A notification could not be sent due to the following error: {e.Message}", HealthState.Error, TimeSpan.FromMinutes(1), true);
                            await Task.Delay(TimeSpan.FromSeconds(29), cancellationToken);
                        }
                        else
                        {
                            failCount = 0;
                            await tx.CommitAsync();
                        }
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }

        private async Task AuditQueue(CancellationToken cancellationToken)
        {
            var failCount = 0;
            while (!cancellationToken.IsCancellationRequested)
            {

                var queue = await StateManager.GetOrAddAsync<IReliableQueue<T>>(_auditQueue);
                using (var tx = StateManager.CreateTransaction())
                {
                    try
                    {
                        var result = await queue.TryDequeueAsync(tx);
                        if (result.HasValue)
                        {
                            object oldModel = null;
                            object newModel = null;
                            var ignoreFieldslist = new List<string>();
                            var item = await GetUncompressed(result.Value.Id);

                            if (item == null) // delete
                            {
                                oldModel = Activator.CreateInstance(typeof(T));
                                newModel = result.Value;
                                var objDelete = (T)newModel;
                                objDelete.CrudOperationType = CrudOperationType.Delete;
                                newModel = objDelete;
                            }
                            else // create or udpate
                            {
                                newModel = item;
                                oldModel = item.CrudOperationType == CrudOperationType.Create ? Activator.CreateInstance(typeof(T)) : result.Value;
                                if (item.CrudOperationType == CrudOperationType.Update)
                                {
                                    ignoreFieldslist.Add("ModifiedDate");
                                    ignoreFieldslist.Add("CreatedDate");
                                }
                            }
                            await AuditLogItem(oldModel, newModel, ignoreFieldslist);
                        }
                        await tx.CommitAsync();
                    }
                    catch (Exception e)
                    {
                        if (failCount < 5)
                        {
                            tx.Abort();
                            failCount++;
                            await LogHealthState("AuditQueue", $"An audit log could not be sent due to the following error: {e.Message}", HealthState.Error, TimeSpan.FromMinutes(1), true);
                            await Task.Delay(TimeSpan.FromSeconds(29), cancellationToken);
                        }
                        else
                        {
                            failCount = 0;
                            await tx.CommitAsync();
                        }
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }

        private async Task DataSyncQueue(CancellationToken cancellationToken)
        {
            var failCount = 0;
            while (!cancellationToken.IsCancellationRequested)
            {
                var queue = await StateManager.GetOrAddAsync<IReliableQueue<T>>(_datasyncQueue);
                using (var tx = StateManager.CreateTransaction())
                {
                    try
                    {
                        var result = await queue.TryDequeueAsync(tx);
                        if (result.HasValue)
                        {
                            var model = result.Value;
                            await SyncItemToDatabase(model);
                        }
                        await tx.CommitAsync();
                    }
                    catch (Exception e)
                    {
                        if (failCount < 5)
                        {
                            tx.Abort();
                            failCount++;
                            await LogHealthState("DataSyncQueue", $"Data Synchronization could not complete due to the following error: {e.Message}", HealthState.Error, TimeSpan.FromMinutes(1), true);
                            await Task.Delay(TimeSpan.FromSeconds(29), cancellationToken);
                        }
                        else
                        {
                            failCount = 0;
                            await tx.CommitAsync();
                        }
                    }
                }
                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }

        ///// <summary>
        ///// Separate Queue for data sync. from H1 > CPD
        ///// </summary>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        //private async Task LegacySystemDataSyncQueue(CancellationToken cancellationToken)
        //{
        //    var failCount = 0;
        //    while (!cancellationToken.IsCancellationRequested)
        //    {
        //        var queue = await StateManager.GetOrAddAsync<IReliableQueue<T>>(_legacySystemDataSyncQueue);
        //        using (var tx = StateManager.CreateTransaction())
        //        {
        //            try
        //            {
        //                var result = await queue.TryDequeueAsync(tx);
        //                if (result.HasValue)
        //                {
        //                    var model = result.Value;
        //                    //await SyncItemToDatabase(model);
        //                }

        //                await tx.CommitAsync();
        //            }
        //            catch (Exception e)
        //            {
        //                if (failCount < 5)
        //                {
        //                    tx.Abort();
        //                    failCount++;
        //                    await LogHealthState("LegacySystemDataSyncQueue", $"H1 > CPD Data Synchronization could not complete due to the following error: {e.Message}", HealthState.Error, TimeSpan.FromMinutes(1), true);
        //                    await Task.Delay(TimeSpan.FromSeconds(29), cancellationToken);
        //                }
        //                else
        //                {
        //                    failCount = 0;
        //                    await tx.CommitAsync();
        //                }
        //            }
        //        }
        //        await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
        //    }
        //}

        private async Task EnqueueAuditLoggingItem(T model)
        {
            #region Audit Log
            if (IsAuditLoggingEnabled)
            {
                var queue = await StateManager.GetOrAddAsync<IReliableQueue<T>>(_auditQueue);
                using (var tx = StateManager.CreateTransaction())
                {

                    List<string> ignoreFieldslist = new List<string>();
                    var ItemModel = model;
                    if (model.CrudOperationType == CrudOperationType.Update)
                    {
                        var item = await GetUncompressed(model.Id);

                        if (item != null) // update
                        {
                            ItemModel = item;
                            ItemModel.CrudOperationType = model.CrudOperationType;
                        }
                    }
                    await queue.EnqueueAsync(tx, ItemModel);
                    await tx.CommitAsync();
                }
            }
            #endregion
        }

        private async Task EnqueueItems(IEnumerable<T> items)
        {
            var notificationQueue = await StateManager.GetOrAddAsync<IReliableQueue<T>>(_notificationQueue);
            var datasyncQueue = await StateManager.GetOrAddAsync<IReliableQueue<T>>(_datasyncQueue);
            //var legacyQueue = await StateManager.GetOrAddAsync<IReliableQueue<T>>(_legacySystemDataSyncQueue);

            foreach (var item in items)
            {
                using (var tx = StateManager.CreateTransaction())
                {
                    //if (IsAuditLoggingEnabled)
                    //        await queue.EnqueueAsync(tx, item);

                    if (IsAutomatedNotificationsEnabled)
                        await notificationQueue.EnqueueAsync(tx, item);

                    if (IsDatabaseSyncEnabled)
                        await datasyncQueue.EnqueueAsync(tx, item);

                    //if (IsLegacySystemDataSyncEnabled)
                    //    await legacyQueue.EnqueueAsync(tx, item);


                    await tx.CommitAsync();
                }
            }
        }

        #endregion

        #endregion

        #region Settings

        protected override List<ServiceConfig> DefaultSettings()
        {
            return new List<ServiceConfig>
            {
                new ServiceConfig(ServiceName, nameof(IsAutomatedNotificationsEnabled),false),
                new ServiceConfig(ServiceName, nameof(IsAuditLoggingEnabled), false),
                new ServiceConfig(ServiceName, nameof(DatabaseSyncConnection), ConfigType.All, null, nameof(IsDatabaseSyncEnabled), false)
            };
        }
        #endregion

        #region Byte[] Crud Methods

        #region Uncompressed Get Methods

        /// <summary>
        /// Gets all the model currently in the stored state
        /// </summary>
        /// <returns>A list of the requested models</returns>
        public virtual async Task<IEnumerable<T>> GetAllUncompressed()
        {
            LogTextOutput($"GetAll : Started parallel retrieval of dictionaries");

            List<T> itemList = new List<T>();
            await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            {
                using (var tx = StateManager.CreateTransaction())
                {
                    LogTextOutput($"GetAll : Started with key({ key })");
                    var stopwatcher = Stopwatch.StartNew();

                    List<T> models = new List<T>();
                    var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                    var items = await dictionary.CreateEnumerableAsync(tx);
                    using (var asyncEnumerator = items.GetAsyncEnumerator())
                    {
                        while (await asyncEnumerator.MoveNextAsync(CancellationToken.None))
                        {
                            models.Add(asyncEnumerator.Current.Value);
                        }
                    }

                    lock (itemList)
                        itemList.AddRange(models);

                    stopwatcher.Stop();
                    LogTextOutput($"GetAll : Ended with key({ key }) ::  total : { models.Count() } in { stopwatcher.Elapsed }ms");
                }
            }));

            LogTextOutput($"GetAll : Ended parallel retrieval of dictionaries");
            return itemList;
        }

        /// <summary>
        /// Gets a collection of models based on the provided filter logic. This method should not be used for cross service calls. It should
        /// only be used for internally getting the list of items.
        /// </summary>
        /// <param name="filterList">A list of filter logic to determine what to return</param>
        /// <returns>A list of the requested models</returns>
        public async Task<IEnumerable<T>> GetByFilterUncompressed(IEnumerable<FilterCollectionModel> filterList)
        {
            LogTextOutput($"GetByFilter : Started parallel retrieval of dictionaries");

            List<T> itemList = new List<T>();
            await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            {
                using (var tx = StateManager.CreateTransaction())
                {
                    LogTextOutput($"GetByFilter : Started with key({ key })");
                    var stopwatcher = Stopwatch.StartNew();

                    List<T> models = new List<T>();
                    var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                    var items = await dictionary.CreateEnumerableAsync(tx);
                    using (var asyncEnumerator = items.GetAsyncEnumerator())
                    {
                        while (await asyncEnumerator.MoveNextAsync(CancellationToken.None))
                        {
                            var item = asyncEnumerator.Current.Value;

                            if (ItemQualifiesFilter(filterList, item))
                                models.Add(asyncEnumerator.Current.Value);
                        }
                    }

                    lock (itemList)
                        itemList.AddRange(models);

                    stopwatcher.Stop();
                    LogTextOutput($"GetByFilter : Ended with key({ key }) ::  total : { models.Count() } in { stopwatcher.Elapsed }ms");
                }
            }));

            LogTextOutput($"GetByFilter : Ended parallel retrieval of dictionaries");
            return itemList;
        }

        /// <summary>
        /// Retrieves a model from the stored state based on the provided <see cref="Guid"/>.
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> of the model to be retrieved</param>
        /// <returns>The requested model compressed</returns>
        public virtual async Task<T> GetUncompressed(Guid id)
        {
            T result = null;
            using (var tx = StateManager.CreateTransaction())
            {
                var dictionary = await GetDictionaryByModelId(id);
                var item = await dictionary.TryGetValueAsync(tx, id);
                if (item.HasValue)
                    result = item.Value;
            }
            return result;
        }

        /// <summary>
        /// Return a boolean based on existance of the provided filter logic
        /// </summary>
        /// <param name="filterList">A list of filter logic to determine what to return</param>
        /// <returns>Boolean representing the existance</returns>
        public async Task<bool> ExistsByFilter(IEnumerable<FilterCollectionModel> filterList)
        {
            return (await GetByFilterUncompressed(filterList)).Any();
        }

        #endregion

        #region Compressed Get Methods

        /// <summary>
        /// Gets all the model currently in the stored state
        /// </summary>
        /// <returns>A list of the requested models</returns>
        public virtual async Task<byte[]> GetAll()
        {
            LogTextOutput($"GetAll : Started parallel retrieval of dictionaries");

            List<T> itemList = new List<T>();
            await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            {
                using (var tx = StateManager.CreateTransaction())
                {
                    LogTextOutput($"GetAll : Started with key({ key })");
                    var stopwatcher = Stopwatch.StartNew();

                    List<T> models = new List<T>();
                    var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                    var items = await dictionary.CreateEnumerableAsync(tx);
                    using (var asyncEnumerator = items.GetAsyncEnumerator())
                    {
                        while (await asyncEnumerator.MoveNextAsync(CancellationToken.None))
                        {
                            models.Add(asyncEnumerator.Current.Value);
                        }
                    }

                    lock (itemList)
                        itemList.AddRange(models);

                    stopwatcher.Stop();
                    LogTextOutput($"GetAll : Ended with key({ key }) ::  total : { models.Count() } in { stopwatcher.Elapsed }ms");
                }
            }));

            LogTextOutput($"GetAll : Ended parallel retrieval of dictionaries");
            var dataToPersist = Compressor.Compress(JsonConvert.SerializeObject(itemList));
            return dataToPersist;
        }



        public virtual async Task<IEnumerable<T>> GetAllByPartitionUncompressed(string key)
        {
            if (key[0] > 102 || (key[0] < 97 && key[0] > 57) || key[0] < 48 || key.Length > 1)
                throw new Exception($"Character {key} is not accepted by this method");

            using (var tx = StateManager.CreateTransaction())
            {
                LogTextOutput($"GetAllByPartition : Started with key({ key })");
                var stopwatcher = Stopwatch.StartNew();

                List<T> models = new List<T>();
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                var items = await dictionary.CreateEnumerableAsync(tx);
                using (var asyncEnumerator = items.GetAsyncEnumerator())
                {
                    while (await asyncEnumerator.MoveNextAsync(CancellationToken.None))
                    {
                        models.Add(asyncEnumerator.Current.Value);
                    }
                }
                stopwatcher.Stop();
                LogTextOutput($"GetAllByPartition : Ended with key({ key }) ::  total : { models.Count() } in { stopwatcher.Elapsed }ms");
                return models;
            }
        }

        public virtual async Task<byte[]> GetAllByPartition(string key)
        {
            var models = await GetAllByPartitionUncompressed(key);
            return Compressor.Compress(JsonConvert.SerializeObject(models));
        }

        public virtual async Task<byte[]> GetAllSecureDataByPartition(string key, byte[] guidData)
        {
            if (key[0] > 102 || (key[0] < 97 && key[0] > 57) || key[0] < 48 || key.Length > 1)
                throw new Exception($"Character {key} is not accepted by this method");

            var guids = Decompress<IEnumerable<Guid>>(guidData);

            LogTextOutput($"GetAllSecureDataByPartition :: Started with key({ key })");
            LogTextOutput($"GetAllSecureDataByPartition :: Started retrieving filters");

            var serviceFilters = Decompress<SecurityFilter>(await ServiceDataFilter.All(sdf => sdf.GetDataFiltersByRequest(guids, Context.ServiceName.ToString())));

            LogTextOutput($"GetAllSecureDataByPartition :: Ended retrieving filters");

            using (var tx = StateManager.CreateTransaction())
            {
                LogTextOutput($"GetAllSecureDataByPartition :: Started Data Filtering");
                var stopwatcher = Stopwatch.StartNew();

                List<T> models = new List<T>();

                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                var items = await dictionary.CreateEnumerableAsync(tx);
                using (var asyncEnumerator = items.GetAsyncEnumerator())
                {
                    while (await asyncEnumerator.MoveNextAsync(CancellationToken.None))
                    {
                        bool validModel = true;
                        var model = asyncEnumerator.Current.Value;
                        foreach (var filter in serviceFilters)
                        {
                            var modelValue = model.GetType().GetProperty(filter.FilterProperty)?.GetValue(model).ToString();

                            switch (filter.FilterType)
                            {
                                case FilterTypes.Equals:
                                    if (!string.Equals(modelValue, filter.FilterValue, StringComparison.CurrentCultureIgnoreCase))
                                        validModel = false; break;

                                case FilterTypes.Contains:
                                    if (!modelValue.Contains(filter.FilterValue))
                                        validModel = false; break;

                                case FilterTypes.DoesNotEqual:
                                    if (string.Equals(modelValue, filter.FilterValue, StringComparison.CurrentCultureIgnoreCase))
                                        validModel = false; break;

                                case FilterTypes.DoesNotConatin:
                                    if (modelValue.Contains(filter.FilterValue))
                                        validModel = false; break;
                            }
                        }

                        if (validModel)
                            models.Add(model);
                    }
                    stopwatcher.Stop();
                }

                LogTextOutput($"GetAllSecureDataByPartition :: Ended Data Filtering ::  total : { models.Count() } in { stopwatcher.Elapsed }");
                LogTextOutput($"GetAllSecureDataByPartition :: Ended with key({ key }) ::  total : { models.Count() } in { stopwatcher.Elapsed }ms");
                return Compressor.Compress(JsonConvert.SerializeObject(models));
            }
        }

        /// <summary>
        /// Gets a collection of models based on the provided filter logic
        /// </summary>
        /// <param name="filterList">A list of filter logic to determine what to return</param>
        /// <returns>A list of the requested models</returns>
        public async Task<byte[]> GetByFilter(byte[] filterList)
        {
            var uncompressedData = await GetByFilterUncompressed(Decompress<IEnumerable<FilterCollectionModel>>(filterList));
            return Compress(uncompressedData);
        }

        public virtual async Task<byte[]> GetByFilterByPartition(string key, byte[] filter)
        {
            var filterList = Decompress<IEnumerable<FilterCollectionModel>>(filter);
            using (var tx = StateManager.CreateTransaction())
            {
                LogTextOutput($"GetByFilter : Started with key({ key })");
                var stopwatcher = Stopwatch.StartNew();

                List<T> models = new List<T>();
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                var items = await dictionary.CreateEnumerableAsync(tx);
                using (var asyncEnumerator = items.GetAsyncEnumerator())
                {
                    while (await asyncEnumerator.MoveNextAsync(CancellationToken.None))
                    {
                        var item = asyncEnumerator.Current.Value;

                        if (ItemQualifiesFilter(filterList, item))
                            models.Add(asyncEnumerator.Current.Value);
                    }
                }

                stopwatcher.Stop();
                LogTextOutput($"GetByFilter : Ended with key({ key }) ::  total : { models.Count() } in { stopwatcher.Elapsed }ms");

                return Compress(models);
            }
        }

        /// <summary>
        /// Retrieves a model from the stored state based on the provided <see cref="Guid"/>.
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> of the model to be retrieved</param>
        /// <returns>The requested model compressed</returns>
        public virtual async Task<byte[]> Get(Guid id)
        {
            byte[] result = null;
            using (var tx = StateManager.CreateTransaction())
            {
                var dictionary = await GetDictionaryByModelId(id);
                var item = await dictionary.TryGetValueAsync(tx, id);
                if (item.HasValue)
                    result = Compress(item.Value);
            }
            return result;
        }

        ///// <summary>
        ///// Retrieves a model from the stored state based on the provided <see cref="Guid"/>.
        ///// </summary>
        ///// <param name="id">The <see cref="Guid"/> of the model to be retrieved</param>
        ///// <returns>The requested model compressed</returns>
        //public virtual async Task<T> Get(Guid id)
        //{
        //    T result = null;
        //    using (var tx = StateManager.CreateTransaction())
        //    {
        //        var dictionary = await GetDictionaryByModelId(id);
        //        var item = await dictionary.TryGetValueAsync(tx, id);
        //        if (item.HasValue)
        //            result = item.Value;
        //    }
        //    return result;
        //}

        #endregion

        #region Create/Update

        /// <summary>
        /// Creates or updates a model based on the models <see cref="Guid"/>. If no <see cref="Guid"/> is provided, the method creates one.       
        /// </summary>
        /// <remarks>
        /// This method does not add the model to the database queue and is not processed by the <see cref="EntityFrameworkRepository{T}"/>.
        /// </remarks>
        /// <param name="model">The model to be saved</param>
        /// <returns>The saved model</returns>
        public virtual async Task<IEnumerable<T>> Save(IEnumerable<T> modellist)
        {
            var errors = new List<T>();
            using (var tx = StateManager.CreateTransaction())
            {
                foreach (var model in modellist)
                {
                    if (model.CrudOperationType == CrudOperationType.Create)
                    {
                        var _dictionary = await GetDictionaryByModelId(model.Id);
                        if (await _dictionary.TryAddAsync(tx, model.Id, model))
                        {
                            await EnqueueAuditLoggingItem(model);
                        }
                        else
                        {
                            model.Error = "Id already exists";
                            errors.Add(model);
                        }

                    }
                    else
                    {
                        var _dictionary = await GetDictionaryByModelId(model.Id);
                        await EnqueueAuditLoggingItem(model);
                        await _dictionary.AddOrUpdateAsync(tx, model.Id, model, (key, value) => model);

                    }

                }
                await tx.CommitAsync();
            }
            return errors;
        }

        #endregion

        #region Delete

        /// <summary>
        /// Removes a model from the stored state based on the provided <see cref="Guid"/>.
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> of the model to be removed</param>
        /// <returns>The removed model</returns>
        public async Task<IEnumerable<T>> Delete(IEnumerable<T> modelList)
        {
            var errors = new List<T>();
            using (var tx = StateManager.CreateTransaction())
            {
                foreach (var model in modelList)
                {
                    var _dictionary = await GetDictionaryByModelId(model.Id);
                    if (!(await _dictionary.TryRemoveAsync(tx, model.Id)).HasValue)
                    {
                        model.Error = "Id does not exist";
                        errors.Add(model);
                    }
                    else
                    {
                        await EnqueueAuditLoggingItem(model);
                    }
                }
                await tx.CommitAsync();
            }
            return errors;
        }

        /// <summary>
        /// Clears the complete state of the stored collection
        /// </summary>
        /// <returns></returns>
        public async Task DeleteAll()
        {
            try
            {
                foreach (var key in _keysIndex16Bit)
                {
                    var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                    await dictionary.ClearAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #endregion

        #region Base64 Crud Methods

        async Task<string> IBase64.GetAll()
        {
            throw new NotImplementedException();
        }

        async Task<string> IBase64.Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ProcessOperation(string objData)
        {
            throw new NotImplementedException();
        }

        async Task<string> IBase64.GetAllByPartition(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetAllSecureDataByPartition(string key, string guidObjData)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Business Logic

        private async Task<IReliableDictionary<Guid, T>> GetDictionaryByModelId(Guid id)
        {
            var key = id.ToDictionaryKey();
            return await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
        }

        /// <summary>
        /// Validates the creation or updating of models when <see cref="Save"/> is called. When overidding this method,
        /// populate the models Error property with a suitable error string before returning.
        /// </summary>
        /// <param name="model">The model to be validated</param>
        /// <param name="dictionary">The currently stored cache. Is available for comparisson with the model</param>     
        /// <returns>If the model is valid</returns>
        protected virtual Task<bool> Validate(T model, List<T> list)
        {
            return Task.FromResult(true);
        }

        public async Task<byte[]> ProcessOperation(byte[] objData)
        {
            var modelList = JsonConvert.DeserializeObject<IEnumerable<T>>(Compressor.Decompress(objData));
            var errors = await ProcessOperation(modelList);
            return Compressor.Compress(JsonConvert.SerializeObject(errors));
        }

        /// <summary>
        /// Creates, updates or deletes models from the StateManager, based on the stored <see cref="CrudOperationType"/>. Once 
        /// added to the state the same action is repeated into the database using the <see cref="EntityFrameworkRepository{T}"/>.
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns>The list of modified models</returns>
        public virtual async Task<IEnumerable<T>> ProcessOperation(IEnumerable<T> modelList)
        {
            var count = modelList.Count();
            var errors = new List<T>();
            var batchListAdd = new List<T>();
            var batchListDelete = new List<T>();
            int batchCounter = 0;
            int batchSize = 2000;

            foreach (var model in modelList)
            {
                switch (model.CrudOperationType)
                {
                    case CrudOperationType.Create:
                    case CrudOperationType.Update:
                        batchCounter++;
                        batchListAdd.Add(model);
                        break;

                    case CrudOperationType.Delete:
                        batchCounter++;
                        batchListDelete.Add(model);
                        break;

                    default:
                        break;
                }

                if (batchCounter % batchSize == 0 || batchCounter == count)
                {
                    errors.AddRange(await Save(batchListAdd));
                    batchListAdd = new List<T>();

                    errors.AddRange(await Delete(batchListDelete));
                    batchListDelete = new List<T>();
                }
            }

            var enqueueModels = modelList.Where(model => errors.All(error => model.Id != error.Id));
            await EnqueueItems(enqueueModels);
            return errors;
        }

        #region Audit Logging

        protected async Task AuditLogItem(object oldModel, object newModel, List<string> ignoreFieldslist)
        {
            var auditLogItems = GetItemDifferencesForAudit(oldModel, newModel, ignoreFieldslist.ToArray());
            if (auditLogItems.Count > 0)
            {
                await Logging.ProcessAudits(Compress(auditLogItems));
            }
        }

        public List<AuditTrailModel> GetItemDifferencesForAudit(object objectA, object objectB, string[] ignoreList)
        {
            List<AuditTrailModel> Auditlogs = new List<AuditTrailModel>();
            if (objectA != null && objectB != null)
            {
                Type objectType;

                objectType = objectA.GetType();
                Guid itemGuid = (Guid)objectB.GetType().GetProperty("Id").GetValue(objectB);
                Guid batchGuid = Guid.NewGuid();

                var action = objectType.GetProperty("CrudOperationType").GetValue(objectB);

                if (action.ToString().ToLower() != "read")
                {
                    var modifiedBy = (Guid)objectType.GetProperty("ModifiedBy").GetValue(objectB);
                    var createdBy = (Guid)objectType.GetProperty("CreatedBy").GetValue(objectB);
                    var createdDate = (DateTime)objectType.GetProperty("CreatedDate").GetValue(objectB);
                    var modifiedDate = (DateTime)objectType.GetProperty("ModifiedDate").GetValue(objectB);

                    foreach (PropertyInfo propertyInfo in objectType.GetProperties(
                      BindingFlags.Public | BindingFlags.Instance).Where(
                      p => p.CanRead && !ignoreList.Contains(p.Name) && p.CustomAttributes.Count() > 0 && !Attribute.IsDefined(p, typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute))))
                    {
                        object valueA;
                        object valueB;

                        valueA = propertyInfo.GetValue(objectA, null);
                        valueB = propertyInfo.GetValue(objectB, null);
                        // if it is a primitive type, value type or implements
                        // IComparable, just directly try and compare the value
                        if (CanDirectlyCompare(propertyInfo.PropertyType))
                        {
                            if (!AreValuesEqual(valueA, valueB))
                            {
                                Auditlogs.Add(new AuditTrailModel()
                                {
                                    Id = Guid.NewGuid(),
                                    ModelName = objectType.Name,
                                    FieldName = propertyInfo.Name,
                                    OldValue = valueA != null ? valueA.ToString() : string.Empty,
                                    NewValue = valueB != null ? valueB.ToString() : string.Empty,
                                    Action = action.ToString(),
                                    ItemGuid = itemGuid,
                                    BatchGuid = batchGuid,
                                    CrudOperationType = CrudOperationType.Create,
                                    ModifiedBy = modifiedBy,
                                    CreatedBy = createdBy,
                                    CreatedDate = createdDate,
                                    ModifiedDate = modifiedDate
                                });
                            }
                        }
                    }
                }
            }
            return Auditlogs;
        }

        private bool CanDirectlyCompare(Type type)
        {
            return typeof(IComparable).IsAssignableFrom(type) || type.IsPrimitive || type.IsValueType;
        }

        private bool AreValuesEqual(object valueA, object valueB)
        {
            bool result;
            IComparable selfValueComparer;

            selfValueComparer = valueA as IComparable;

            if (valueA == null && valueB != null || valueA != null && valueB == null)
                result = false; // one of the values is null
            else if (selfValueComparer != null && selfValueComparer.CompareTo(valueB) != 0)
                result = false; // the comparison using IComparable failed
            else if (!object.Equals(valueA, valueB))
                result = false; // the comparison using Equals failed
            else
                result = true; // match

            return result;
        }

        #endregion

        #region Database Synchronization

        private EntityFrameworkRepository<T> GetDatabaseSyncRepository()
        {
            var entityFramework = new EntityFrameworkRepository<T>();
            entityFramework.SetDBConnection(DatabaseSyncConnection);
            return entityFramework;
        }

        /// <summary>
        /// Creates, updates or deletes a model from the database based on the models <see cref="CrudOperationType"/>
        /// </summary>
        /// <param name="model">The model to be processed</param>
        /// <returns></returns>
        protected async Task SyncItemToDatabase(T model)
        {
            switch (model.CrudOperationType)
            {
                case CrudOperationType.Create:
                    await GetDatabaseSyncRepository().CreateEntity(model);
                    break;
                case CrudOperationType.Update:
                    await GetDatabaseSyncRepository().UpdateEntity(model);
                    break;
                case CrudOperationType.Delete:
                    await GetDatabaseSyncRepository().DeleteEntity(model);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #endregion

        #region Recovery
        public async Task<byte[]> GetAllDatabaseEntries()
        {
            return Compress(await GetDatabaseSyncRepository().GetAllEntities());
        }

        public async Task RecoveryProcessOperations(string objData)
        {
            throw new NotImplementedException();
        }

        public async Task RecoveryProcessOperations(byte[] objData)
        {
            var items = Decompress<List<T>>(objData);
            var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>(_cacheName);

            int batchCounter = 0;
            int batchSize = 2000;
            List<T> batchItems = new List<T>();
            List<T> errors = new List<T>();

            foreach (var item in items)
            {
                batchCounter++;
                batchItems.Add(item);
                if (batchCounter % batchSize == 0 || batchCounter == items.Count)
                {
                    using (var tx = StateManager.CreateTransaction())
                    {
                        foreach (var batchItem in batchItems)
                        {
                            try
                            {
                                await dictionary.AddAsync(tx, batchItem.Id, batchItem);
                            }
                            catch (Exception)
                            {
                                errors.Add(batchItem);
                            }
                        }
                        await tx.CommitAsync();
                    }

                }

            }
        }

        public virtual async Task DatabaseRecovery(bool mergeData)
        {
            try
            {
                //Get All DBItems
                var databaseItems = await GetDatabaseSyncRepository().GetAllEntities();
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>(_cacheName);
                var mergedItems = new List<T>();

                if (!mergeData)
                {
                    await DeleteAll();
                    mergedItems = databaseItems;
                }
                else
                {
                    var serviceItems = (await GetAllUncompressed()).ToList();
                    var concatList = serviceItems.Concat(databaseItems).ToList();
                    var duplicateGroups = concatList.GroupBy(x => x.Id).Where(y => y.Count() > 1);
                    foreach (var duplicateGroup in duplicateGroups)
                    {
                        var duplicates = duplicateGroup.ToList();

                        //Remove duplicates whos ModifiedDate is earlier than other duplicate items
                        duplicates.RemoveAll(x => duplicates.Any(y => x.ModifiedDate > y.ModifiedDate));
                        foreach (var duplicate in duplicates)
                            concatList.Remove(duplicate);
                    }
                    mergedItems = concatList;
                }

                #region Add Items to State
                int batchCounter = 0;
                int batchSize = 2000;
                List<T> batchItems = new List<T>();
                List<T> errors = new List<T>();

                foreach (var mergedItem in mergedItems)
                {
                    batchCounter++;
                    batchItems.Add(mergedItem);
                    if (batchCounter % batchSize == 0 || batchCounter == databaseItems.Count)
                    {
                        using (var tx = StateManager.CreateTransaction())
                        {
                            foreach (var item in batchItems)
                            {
                                try
                                {
                                    await dictionary.AddAsync(tx, item.Id, item);
                                }
                                catch (Exception)
                                {
                                    errors.Add(item);
                                }
                            }
                            await tx.CommitAsync();
                        }

                    }
                }
                #endregion

            }
            catch (Exception e)
            {
                await LogHealthState("DatabaseRecovery", $"An error occured during recovery: {e.Message}", HealthState.Error, TimeSpan.FromMinutes(1));
            }
        }
        #endregion

        #region Filter Logic

        private bool ItemQualifiesFilter(IEnumerable<FilterCollectionModel> filters, T item)
        {
            bool qualifies = true;
            foreach (var filter in filters)
            {
                if (filter.IsAnd)
                    qualifies = qualifies && ItemQualifiesInternalFilter(filter.InternalFilterCollection, item);

                else
                    qualifies = ItemQualifiesInternalFilter(filter.InternalFilterCollection, item);
            }

            return qualifies;
        }

        private bool ItemQualifiesInternalFilter(IEnumerable<InternalFilterModel> filters, T item)
        {
            bool qualifies = true;
            foreach (var filter in filters)
            {
                if (filter.IsAnd)
                {
                    var property = item.GetType().GetProperty(filter.FilterProperty);
                    if (property != null)
                        qualifies = qualifies && property.GetValue(item).ToString().Equals(filter.FilterValue, StringComparison.CurrentCultureIgnoreCase);

                    else
                        qualifies = false;
                }
                else
                {
                    var property = item.GetType().GetProperty(filter.FilterProperty);
                    if (property != null)
                        qualifies = property.GetValue(item).ToString().Equals(filter.FilterValue, StringComparison.CurrentCultureIgnoreCase);

                    else
                        qualifies = false;
                }
            }

            return qualifies;
        }
        #endregion

        #region Notifications        

        protected virtual async Task PublishNotification(T model)
        {
            try
            {
                ServiceEventSource.Current.ServiceMessage(Context, $"Sending notification from {ServiceName} to the notification service");
                var notification = NotificationModelConverter<T>.ConvertModel(model);
                var name = ServiceName.Remove(0, ServiceName.LastIndexOf('.') + 1);
                await PublisherServiceHelper.PublishMessageAsync(this, notification, $"{name}{model.CrudOperationType}Channel");
            }
            catch (AggregateException e)
            {

                await LogHealthState("PublishNotification", $"An error occured sending a Notification: {e.Flatten().Message}", HealthState.Warning, TimeSpan.FromMinutes(1), true);
                await LogException(e);
            }
            catch (Exception e)
            {
                await LogHealthState("PublishNotification", $"An error occured sending a Notification: {e.Message}", HealthState.Warning, TimeSpan.FromMinutes(1), true);
                await LogException(e);
            }
        }

        #endregion

        #region Helper Methods

        protected async Task<List<T>> DictionaryToList(IReliableDictionary<Guid, T> dictionary)
        {
            var itemList = new List<T>();
            using (var tx = StateManager.CreateTransaction())
            {
                var enumerable = await dictionary.CreateEnumerableAsync(tx);

                using (var asyncEnumerator = enumerable.GetAsyncEnumerator())
                {
                    while (await asyncEnumerator.MoveNextAsync(CancellationToken.None))
                    {
                        itemList.Add(asyncEnumerator.Current.Value);
                    }
                }
                await tx.CommitAsync();
            }
            return itemList;
        }

        #endregion

        #region Service Extensions

        public virtual async Task<byte[]> WhereAsync(Func<KeyValuePair<Guid, T>, bool> filter)
        {
            List<T> itemList = new List<T>();
            await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            {
                using (var tx = StateManager.CreateTransaction())
                {
                    var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                    var items = await dictionary.CreateEnumerableAsync(tx);
                    lock (itemList)
                        itemList.AddRange(items.Where(filter).Select(it => it.Value).ToListAsync(tx).Result.ToList());
                }
            }));
            return Compressor.Compress(JsonConvert.SerializeObject(itemList));
        }
        public virtual async Task<byte[]> WhereByDictionaryKeyAsync(string key, Func<KeyValuePair<Guid, T>, bool> filter)
        {
            List<T> itemList = new List<T>();
            using (var tx = StateManager.CreateTransaction())
            {
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                var items = await dictionary.CreateEnumerableAsync(tx);
                itemList.AddRange(items.Where(filter).Select(it => it.Value).ToListAsync(tx).Result.ToList());
            }
            return Compressor.Compress(JsonConvert.SerializeObject(itemList));
        }
        public virtual async Task<byte[]> SelectAsync<R>(Func<KeyValuePair<Guid, T>, R> fields)
        {
            List<R> itemList = new List<R>();
            await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            {
                using (var tx = StateManager.CreateTransaction())
                {
                    var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                    var items = await dictionary.CreateEnumerableAsync(tx);
                    lock (itemList)
                        itemList.AddRange(items.Select(fields).ToListAsync(tx).Result.ToList());
                }
            }));
            return Compressor.Compress(JsonConvert.SerializeObject(itemList));
        }
        public virtual async Task<byte[]> SelectByDictionaryKeyAsync<R>(string key, Func<KeyValuePair<Guid, T>, R> fields)
        {
            List<R> itemList = new List<R>();
            using (var tx = StateManager.CreateTransaction())
            {
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                var items = await dictionary.CreateEnumerableAsync(tx);
                itemList.AddRange(items.Select(fields).ToListAsync(tx).Result.ToList());
            }
            return Compressor.Compress(JsonConvert.SerializeObject(itemList));
        }
        public virtual async Task<byte[]> TakeAsync(int take)
        {
            List<T> itemList = new List<T>();
            await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            {
                using (var tx = StateManager.CreateTransaction())
                {
                    var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                    var items = await dictionary.CreateEnumerableAsync(tx);
                    lock (itemList)
                        itemList.AddRange(items.Select(it => it.Value).ToListAsync(tx).Result.ToList());
                }
            }));
            return Compressor.Compress(JsonConvert.SerializeObject(itemList.OrderBy(it => it.Id).Take(take)));
        }
        public virtual async Task<byte[]> TakeByDictionayKeyAsync(string key, int take)
        {
            List<T> itemList = new List<T>();
            using (var tx = StateManager.CreateTransaction())
            {
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                var items = await dictionary.CreateEnumerableAsync(tx);
                itemList.AddRange(items.Select(it => it.Value).ToListAsync(tx).Result.ToList());
            }
            return Compressor.Compress(JsonConvert.SerializeObject(itemList.OrderBy(it => it.Id).Take(take)));
        }
        public virtual async Task<bool> AnyAsync()
        {
            List<bool> itemList = new List<bool>();
            await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            {
                using (var tx = StateManager.CreateTransaction())
                {
                    var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                    var items = await dictionary.CreateEnumerableAsync(tx);
                    itemList.Add(items.AnyAsync().Result);
                }
            }));
            return itemList.Any(it => it);
        }
        public virtual async Task<bool> AnyByDictionayKeyAsync(string key)
        {
            List<bool> itemList = new List<bool>();
            using (var tx = StateManager.CreateTransaction())
            {
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                var items = await dictionary.CreateEnumerableAsync(tx);
                itemList.Add(items.AnyAsync().Result);
            }
            return itemList.Any(it => it);
        }
        public virtual async Task<bool> AnyAsync(Func<KeyValuePair<Guid, T>, bool> condition)
        {
            List<bool> itemList = new List<bool>();
            await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            {
                using (var tx = StateManager.CreateTransaction())
                {
                    var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                    var items = await dictionary.CreateEnumerableAsync(tx);
                    itemList.Add(items.AnyAsync(condition).Result);
                }
            }));
            return itemList.Any(it => it);
        }
        public virtual async Task<bool> AnyByDictionaryKeyAsync(string key, Func<KeyValuePair<Guid, T>, bool> condition)
        {
            List<bool> itemList = new List<bool>();
            using (var tx = StateManager.CreateTransaction())
            {
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                var items = await dictionary.CreateEnumerableAsync(tx);
                itemList.Add(items.AnyAsync(condition).Result);
            }
            return itemList.Any(it => it);
        }
        public virtual async Task<bool> AllAsync(Func<KeyValuePair<Guid, T>, bool> condition)
        {
            List<bool> itemList = new List<bool>();
            await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            {
                using (var tx = StateManager.CreateTransaction())
                {
                    var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                    var items = await dictionary.CreateEnumerableAsync(tx);
                    itemList.Add(items.AllAsync(condition).Result);
                }
            }));
            return itemList.All(it => it);
        }
        public virtual async Task<bool> AllByDictionaryKeyAsync(string key, Func<KeyValuePair<Guid, T>, bool> condition)
        {
            List<bool> itemList = new List<bool>();
            using (var tx = StateManager.CreateTransaction())
            {
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                var items = await dictionary.CreateEnumerableAsync(tx);
                itemList.Add(items.AllAsync(condition).Result);
            }
            return itemList.All(it => it);
        }
        public virtual async Task<byte[]> FirstAsync()
        {
            List<T> itemList = new List<T>();
            await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            {
                using (var tx = StateManager.CreateTransaction())
                {
                    var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                    var items = await dictionary.CreateEnumerableAsync(tx);
                    itemList.Add(items.FirstAsync().Result.Value);
                }
            }));
            return Compressor.Compress(JsonConvert.SerializeObject(itemList.First()));
        }
        public virtual async Task<byte[]> FirstByDictionaryKeyAsync(string key)
        {
            List<T> itemList = new List<T>();
            using (var tx = StateManager.CreateTransaction())
            {
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                var items = await dictionary.CreateEnumerableAsync(tx);
                itemList.Add(items.FirstAsync().Result.Value);
            }
            return Compressor.Compress(JsonConvert.SerializeObject(itemList.First()));
        }
        public virtual async Task<byte[]> FirstOrDefaultAsync(Func<KeyValuePair<Guid, T>, bool> condition)
        {
            List<T> itemList = new List<T>();
            await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            {
                using (var tx = StateManager.CreateTransaction())
                {
                    var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                    var items = await dictionary.CreateEnumerableAsync(tx);
                    itemList.Add(items.FirstOrDefaultAsync(condition).Result.Value);
                }
            }));
            return Compressor.Compress(JsonConvert.SerializeObject(itemList.FirstOrDefault()));
        }
        public virtual async Task<byte[]> FirstOrDefaultByDictionaryKeyAsync(string key, Func<KeyValuePair<Guid, T>, bool> condition)
        {
            List<T> itemList = new List<T>();
            using (var tx = StateManager.CreateTransaction())
            {
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                var items = await dictionary.CreateEnumerableAsync(tx);
                itemList.Add(items.FirstOrDefaultAsync(condition).Result.Value);
            }
            return Compressor.Compress(JsonConvert.SerializeObject(itemList.FirstOrDefault()));
        }
        #endregion
    }

    public abstract class StatefulServiceBase : StatefulService, ISubscriberService
    {
        #region Properties

        #region Remoting Interfaces

        private IUtilities _utilityProxy;
        /// <summary>
        /// An interface that connects to the Utilities service. If the proxy has not been created upon being accessed, it will create it.
        /// </summary>
        protected IUtilities UtilityProxy
        {
            get
            {
                try
                {
                    return _utilityProxy ?? (_utilityProxy = ServiceProxyFactory.CreateServiceProxy<IUtilities>(new Uri("fabric:/Core.Framework/SF.Core.Utilities")));
                }
                catch (Exception e)
                {
                    LogTextOutput($"Remoting proxy could not be created: {e.Message}");
                    LogHealthState(nameof(UtilityProxy), $"Remoting proxy could not be created: {e.Message}", HealthState.Warning, TimeSpan.FromMinutes(1), true).Wait();
                    return null;
                }
            }
        }

        private ILogging _logging;
        /// <summary>
        /// An interface that connects to the Logging service. If the proxy has not been created upon being accessed, it will create it.
        /// </summary>
        protected ILogging Logging
        {
            get
            {
                try
                {
                    return _logging ?? (_logging = ServiceProxyFactory.CreateServiceProxy<ILogging>(UtilityProxy.InitializeLogging().Result));
                }
                catch (Exception e)
                {
                    LogTextOutput($"Remoting proxy could not be created: {e.Message}");
                    LogHealthState(nameof(Logging), $"Remoting proxy could not be created: {e.Message}", HealthState.Warning, TimeSpan.FromMinutes(1), true).Wait();
                    return null;
                }
            }
        }

        private Proxy<IServiceConfiguration> _serviceConfiguration;
        /// <summary>
        /// A proxy handler for the Service Configuration service. If the proxy has not been created upon being accessed, it will create it.
        /// </summary>
        protected Proxy<IServiceConfiguration> ServiceConfiguration
        {
            get
            {
                try
                {
                    return _serviceConfiguration ?? (_serviceConfiguration = new Proxy<IServiceConfiguration>(UtilityProxy.InitializeServiceConfiguration().Result, ServiceProxyFactory));
                }
                catch (Exception e)
                {
                    LogTextOutput($"Remoting proxy could not be created: {e.Message}");
                    LogHealthState(nameof(ServiceConfiguration), $"Remoting proxy could not be created: {e.Message}", HealthState.Warning, TimeSpan.FromMinutes(1), true).Wait();
                    return null;
                }
            }
        }

        private PublisherServiceHelper _publisherServiceHelper;
        /// <summary>
        /// A helper class for PubSub connectivity. If the helper has not been created upon being accessed, it will create it.
        /// </summary>
        protected PublisherServiceHelper PublisherServiceHelper
        {
            get
            {
                try
                {
                    if (_publisherServiceHelper == null)
                        _publisherServiceHelper = new PublisherServiceHelper(new BrokerServiceLocator(ActorProxyFactory));
                    return _publisherServiceHelper;
                }
                catch (Exception e)
                {
                    LogTextOutput($"Remoting proxy could not be created: {e.Message}");
                    LogHealthState(nameof(PublisherServiceHelper), $"Remoting proxy could not be created: {e.Message}", HealthState.Warning, TimeSpan.FromMinutes(1), true).Wait();
                    return null;
                }
            }
        }

        private SubscriberServiceHelper _subscriberServiceHelper;
        protected SubscriberServiceHelper SubscriberServiceHelper
        {
            get
            {
                try
                {
                    if (_subscriberServiceHelper == null)
                        _subscriberServiceHelper = new SubscriberServiceHelper(new BrokerServiceLocator(ActorProxyFactory));
                    return _subscriberServiceHelper;
                }
                catch (Exception e)
                {
                    LogTextOutput($"Remoting proxy could not be created: {e.Message}");
                    LogHealthState(nameof(SubscriberServiceHelper), $"Remoting proxy could not be created: {e.Message}", HealthState.Warning, TimeSpan.FromMinutes(1), true).Wait();
                    return null;
                }
            }
        }

        #endregion

        #region Configuration Settings 

        private bool DiagnosticLoggingEnabled;
        private bool PerformanceLoggingEnabled;
        private bool UsageLoggingEnabled;

        #endregion

        protected IServiceProxyFactory ServiceProxyFactory { get; }
        protected IActorProxyFactory ActorProxyFactory { get; }

        protected string ServiceName => Context.ServiceName.Segments[Context.ServiceName.Segments.Count() - 1];

        #endregion

        #region ctors

        protected StatefulServiceBase(StatefulServiceContext context) : this(context, (new ReliableStateManager(context)))
        { }

        protected StatefulServiceBase(StatefulServiceContext context, IReliableStateManagerReplica stateManagerReplica,
            IServiceProxyFactory serviceProxyFactory = null, IActorProxyFactory actorProxyFactory = null) :
            base(context, stateManagerReplica)
        {
            var settings = new FabricTransportRemotingSettings
            {
                OperationTimeout = TimeSpan.FromMinutes(1),
                MaxMessageSize = int.MaxValue,
                UseWrappedMessage = true
            };
            ServiceProxyFactory = serviceProxyFactory ?? new ServiceProxyFactory(h => new FabricTransportServiceRemotingClientFactory(settings));
            ActorProxyFactory = actorProxyFactory ?? new ActorProxyFactory();
        }

        #endregion

        #region Setup

        /// <summary>
        /// Creates the service remote listeners for this service
        /// </summary>
        /// <returns>The listener</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return this.CreateServiceRemotingReplicaListeners();
        }

        protected virtual Task Initialize()
        {
            return Task.FromResult(0);
        }

        protected sealed override async Task RunAsync(CancellationToken cancellationToken)
        {
            try
            {
                var tasks = new Task[5];
                tasks[0] = Task.Run(() => InitializeRetryWrapper(cancellationToken), cancellationToken);
                tasks[1] = Task.Run(() => RetrieveServiceSettings(cancellationToken), cancellationToken);
                tasks[2] = Task.Run(() => RegisterSettingsChannel(cancellationToken), cancellationToken);
                tasks[3] = Task.Run(() => Queues(cancellationToken), cancellationToken);
                tasks[4] = BaseRun(cancellationToken);
                await Task.WhenAll(tasks);

            }
            catch (TaskCanceledException) { }
            catch (FabricNotPrimaryException) { }
            catch (Exception e)
            {
                await LogHealthState("RunAsync", $"{e.Message}", HealthState.Error);
                throw e;
            }
            await LogHealthState("RunAsync", "Initialized", HealthState.Ok);
        }

        protected async Task InitializeRetryWrapper(CancellationToken ct)
        {
            bool success = false;
            while (!ct.IsCancellationRequested && !success)
            {
                try
                {
                    await Initialize();
                    success = true;
                    ServiceEventSource.Current.ServiceMessage(Context, "Initialization completed successfully");
                    await LogHealthState("InitializeRetryWrapper", "Initialization completed successfully",
                    HealthState.Ok);
                }
                catch (Exception e)
                {
                    await LogHealthState("InitializeRetryWrapper", $"Initialize failed to complete due to the following reasons: {e.Message}",
                        HealthState.Warning, TimeSpan.FromMinutes(1), true);
                    await Task.Delay(TimeSpan.FromMinutes(1), ct);
                }
            }
        }

        protected virtual Task BaseRun(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Used to initialize new queue within RunAsync
        /// </summary>
        /// <returns></returns>
        protected virtual Task Queues(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        protected virtual async Task RegisterSettingsChannel(CancellationToken ct)
        {
            bool connected = false;
            while (!ct.IsCancellationRequested && !connected)
            {
                try
                {
                    await SubscriberServiceHelper.RegisterMessageChannelAsync(this, $"SettingsUpdate: {ServiceName}");
                    connected = true;
                    ServiceEventSource.Current.ServiceMessage(Context, $"{ServiceName} successfully created service channel");
                }
                catch (Exception e)
                {
                    await LogHealthState("RegisterSettingsChannel", "The service setting refresh channel could not be created as the service could not connect to the BrokerActor or " +
                        "Subscription service.",
                        HealthState.Warning, TimeSpan.FromMinutes(1), true);
                    await Task.Delay(TimeSpan.FromMinutes(1), ct);
                }
            }
        }

        #endregion

        #region CRUD Methods

        /// <summary>
        /// A generic method that gets all the models inside a specified dictionary.
        /// </summary>
        /// <remarks>
        /// For this method, it expects the dictionary structure to use a <see cref="Guid"/> as the key, which would be the Id of
        /// the model.
        /// </remarks>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="dictionaryName"></param>
        /// <returns></returns>
        protected async Task<IEnumerable<TModel>> GetAll<TModel>(string dictionaryName)
        {
            var models = new List<TModel>();
            var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, TModel>>(dictionaryName);
            using (var tx = StateManager.CreateTransaction())
            {
                var enumerator = (await dictionary.CreateEnumerableAsync(tx)).GetAsyncEnumerator();
                while (await enumerator.MoveNextAsync(CancellationToken.None))
                {
                    models.Add(enumerator.Current.Value);
                }
            }

            return models;
        }

        protected async Task<TModel> Get<TModel>(string dictionaryName, Guid id)
        {
            var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, TModel>>(dictionaryName);
            using (var tx = StateManager.CreateTransaction())
            {
                var conditionalValue = await dictionary.TryGetValueAsync(tx, id);
                if (!conditionalValue.HasValue) throw new NullReferenceException("An item with that id could not be found.");

                return conditionalValue.Value;
            }
        }

        protected async Task<IEnumerable<TModel>> GetByFilter<TModel>(string dictionaryName, IEnumerable<FilterCollectionModel> filters)
        {
            var models = new List<TModel>();
            var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, TModel>>(dictionaryName);
            using (var tx = StateManager.CreateTransaction())
            {
                var enumerator = (await dictionary.CreateEnumerableAsync(tx)).GetAsyncEnumerator();
                while (await enumerator.MoveNextAsync(CancellationToken.None))
                {
                    if (QualifiesFilter(filters, enumerator.Current.Value))
                    {
                        models.Add(enumerator.Current.Value);
                    }
                }
            }

            return models;
        }

        #region Qualifies Filter

        private bool QualifiesFilter<TModel>(IEnumerable<FilterCollectionModel> filters, TModel currentValue)
        {
            var isFirst = true;
            var qualifies = true;

            foreach (var filter in filters)
            {
                if (isFirst)
                {
                    qualifies = QualifiesInternalFilter(filter.InternalFilterCollection, currentValue);
                    isFirst = false;
                }
                else
                {
                    if (filter.IsAnd)
                        qualifies = qualifies && QualifiesInternalFilter(filter.InternalFilterCollection, currentValue);

                    else
                        qualifies = qualifies || QualifiesInternalFilter(filter.InternalFilterCollection, currentValue);
                }
            }

            return qualifies;
        }

        private bool QualifiesInternalFilter<TModel>(IEnumerable<InternalFilterModel> internalFilters, TModel currentValue)
        {
            var isFirst = true;
            var qualifies = true;

            foreach (var filter in internalFilters)
            {
                var property = currentValue.GetType().GetProperty(filter.FilterProperty, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (property != null)
                {
                    if (isFirst)
                    {
                        qualifies = property.GetValue(currentValue).ToString().Equals(filter.FilterValue, StringComparison.CurrentCultureIgnoreCase);
                        isFirst = false;
                    }
                    else
                    {
                        if (filter.IsAnd)
                            qualifies = qualifies && property.GetValue(currentValue).ToString().Equals(filter.FilterValue, StringComparison.CurrentCultureIgnoreCase);

                        else
                            qualifies = qualifies || property.GetValue(currentValue).ToString().Equals(filter.FilterValue, StringComparison.CurrentCultureIgnoreCase);
                    }
                }
                else
                {
                    qualifies = false;
                }

            }

            return qualifies;
        }

        #endregion

        protected async Task Process<TModel>(string dictionaryName, IEnumerable<TModel> models) where TModel : BaseModel<Guid>
        {
            var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, TModel>>(dictionaryName);
            using (var tx = StateManager.CreateTransaction())
            {
                foreach (var model in models)
                {
                    switch (model.CrudOperationType)
                    {
                        case CrudOperationType.Create:
                            if (!await dictionary.TryAddAsync(tx, model.Id, model)) throw new ArgumentException($"An item with id {model.Id} already exists.");
                            break;

                        case CrudOperationType.Update:
                            if ((await dictionary.TryGetValueAsync(tx, model.Id)).HasValue)
                                await dictionary.SetAsync(tx, model.Id, model);
                            else throw new ArgumentException($"An item with id {model.Id} could not be found.");
                            break;

                        case CrudOperationType.Delete:
                            if (!(await dictionary.TryRemoveAsync(tx, model.Id)).HasValue) throw new ArgumentException($"An item with id {model.Id} could not be found.");
                            break;
                    }
                }

                await tx.CommitAsync();
            }
        }

        #endregion

        #region Settings

        protected async Task RetrieveServiceSettings(CancellationToken ct)
        {
            var settingsUpToDate = false;
            while (!ct.IsCancellationRequested && !settingsUpToDate)
            {
                try
                {
                    var defaultSettings = DefaultSettings();
                    var resultData = await ServiceConfiguration.All(proxy => proxy.UpdateSettings(ServiceName, JsonConvert.SerializeObject(defaultSettings).Compress()));
                    await UpdateSettings(Decompress<ServiceConfig>(resultData));

                    settingsUpToDate = true;
                }
                catch (Exception e)
                {
                    await LogHealthState("ForceRefreshServiceConfiguration", "Service settings could not be applied as the service could not connect to the H1ServiceSettings Service",
                        HealthState.Warning, TimeSpan.FromMinutes(1), true);
                    await Task.Delay(TimeSpan.FromMinutes(1), ct);
                }
            }
        }

        #region Default Settings

        protected byte[] CompressedDefaultSettings()
        {
            var settings = DefaultSettings().Concat(BaseDefaultSettings());
            return JsonConvert.SerializeObject(settings).Compress();
        }

        private List<ServiceConfig> BaseDefaultSettings()
        {
            return new List<ServiceConfig>
            {
                new ServiceConfig(ServiceName, nameof(DiagnosticLoggingEnabled), false),
                new ServiceConfig(ServiceName, nameof(PerformanceLoggingEnabled), false),
                new ServiceConfig(ServiceName, nameof(UsageLoggingEnabled), false)
            };
        }

        protected virtual List<ServiceConfig> DefaultSettings()
        {
            return new List<ServiceConfig>();
        }

        #endregion

        public async Task UpdateSettings(IEnumerable<ServiceConfig> settings)
        {
            foreach (var setting in settings)
            {
                await UpdateSetting(setting);
            }
        }

        protected async Task UpdateSetting(ServiceConfig setting)
        {
            var serviceType = GetType();
            if (!string.IsNullOrEmpty(setting.ValueParameterName))
            {
                var valueProperty = serviceType.GetProperty(setting.ValueParameterName,
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (valueProperty != null && setting.Value != null)
                {
                    if (setting.ValueType == ConfigType.Numbers)
                    {
                        if (!int.TryParse(setting.Value, out var intValue))
                        {
                            await LogHealthState(nameof(UpdateSetting),
                                $"{setting.ValueParameterName} could not be set as {setting.Value} is not of type int",
                                HealthState.Warning);
                        }
                        else
                            valueProperty.SetValue(this, intValue);
                    }
                    else
                    {
                        valueProperty.SetValue(this, setting.Value);
                    }
                }
            }


            if (!string.IsNullOrEmpty(setting.IsEnabledParameterName))
            {
                var enabledProperty = serviceType.GetProperty(setting.IsEnabledParameterName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

                if (enabledProperty != null)
                    enabledProperty.SetValue(this, setting.IsEnabled);
            }
        }

        #endregion

        #region Notifications

        public async Task ReceiveMessageAsync(MessageWrapper message)
        {
            if (message.Channel.StartsWith("SettingsUpdate:"))
            {
                await UpdateSetting(JsonConvert.DeserializeObject<ServiceConfig>(message.Payload));
            }
            else
            {
                await NotificationReceived(message);
            }
        }

        /// <summary>
        /// Override this method in your service if you need to handle custom notifications
        /// </summary>
        /// <param name="message">The message object</param>
        /// <returns></returns>
        protected virtual Task NotificationReceived(MessageWrapper message)
        {
            return Task.FromResult(0);
        }

        #endregion

        #region Logging

        public async Task LogException(Exception exception)
        {
            try
            {
                await Logging.ProcessErrors(Compress(ExceptionMethods.LogException(exception, new Guid())));
            }
            catch (Exception e)
            {
                //Logging failed but should not stop application from running
                ServiceEventSource.Current.ServiceMessage(Context, $"Failed to send exception to the Logging Service: {e.Message}");
            }
        }

        public async Task LogHealthState(string source, string property, HealthState healthState)
        {
            var healthInformation = new HealthInformation(source, property, healthState)
            {
                TimeToLive = TimeSpan.FromMinutes(1),
                RemoveWhenExpired = true
            };
            Partition.ReportReplicaHealth(healthInformation);
        }

        public async Task LogHealthState(string source, string property, HealthState healthState, TimeSpan timeToLive, bool removeWhenExpired = false)
        {
            var healthInformation = new HealthInformation(source, property, healthState)
            {
                TimeToLive = timeToLive,
                RemoveWhenExpired = removeWhenExpired
            };
            Partition.ReportReplicaHealth(healthInformation);
        }

        protected void LogTextOutput(string info)
        {
            Console.WriteLine($"{ DateTime.Now.ToString(CultureInfo.InvariantCulture)} ::  { info }");
        }

        #endregion

        #region Compression

        protected byte[] Compress(object obj)
        {
            return Compressor.Compress(JsonConvert.SerializeObject(obj));
        }

        protected T Decompress<T>(byte[] objData)
        {
            if (objData != null)
                return JsonConvert.DeserializeObject<T>(Compressor.Decompress(objData));
            return default(T);
        }

        protected List<T> Decompress<T>(byte[][] objData)
        {
            List<T> results = new List<T>();

            if (objData != null)
                foreach (var byteArray in objData)
                {
                    var models = Decompress<IEnumerable<T>>(byteArray);
                    if (models != null)
                        results.AddRange(models);
                }

            return results;
        }

        protected List<T> DecompressFromSingle<T>(byte[][] objData)
        {
            if (objData != null)
                return objData.Select(x => Decompress<T>(x)).ToList();
            return null;
        }

        #endregion

        #region Helpers

        protected Range GetPartitionRange()
        {
            var info = (Int64RangePartitionInformation)Partition.PartitionInfo;
            return new Range(info.LowKey, info.HighKey);
        }

        #endregion
    }
}
