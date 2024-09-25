/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   StatefulServiceBase.cs
Function           :   Collecting the records from service.
Created By         :  
Created on         :  
Revision History   :   [3-Oct-2019] : Srashti Gupta
*                  :   [] : Modifiy the class as per the requirement for performance optimization.
*                  :   [17-Dec-2019] : Nitin
*                  :   [] : Removed NotificationQueue, AuditQueue and DataSyncQueue which are obsolete now    
*                  :   [18-Dec-2019] : Nitin
*                  :   [] : Code Commented for RetrieveServiceSettings which is obsolete
*                  :   [18-Dec-2019] : Nitin
*                  :   [] : Code Commented for RegisterSettingsChannel which is obsolete
*                  :   [20-Dec-2019] : Nitin
*                  :   [] : Code Commented for Queues() which is obsolete 
*                  :   [06-Jan-2020] : Srashti
*                  :   [] : Added the GetFilterConditionValue() for Filtering the value using dynamic linq.
*                  :   [09-Jan-2020] : Amit Agarwal
*                  :   [] : LINQ Filter corrected
*                  :   [10-Jan-2020] : Srashti Gupta
*                  :   [] : Convert String to Int for FilterOrder.
*                  :   [13-Jan-2020] : Amit Agarwal
*                  :   [] : Added methods for getting data and posting data on non generic stateful service base of achieving mulitple masters on single service with base64 string
*                  :   [15-Jan-2020] : Nitin
*                  :   [] : Code Commented for RegisterOldSettingsChannel which is obsolete
*                  :   [07-Jun-2021] : Dharmendra
*                  :   [] : Remove Parallel foreach from method GetByFilterUncompressed()
*                  :   [10-Oct-2021] : Ashish Dutta
*                  :   [] : Remove Parallel foreach from method's    
****************************************************************************************************/

using Common.Core.Contracts.Models.Administration.Security;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Contracts.Models.Core.Logging;
using Common.Core.Contracts.Models.Core.Settings;
using Common.Core.Contracts.Models.Core.Settings.Commercial;
using Common.Core.Infrastructure.Extensions;
using Common.Core.Infrastructure.Helpers;
using Common.SF.Contracts.Interfaces.Administration.Security.DataFilter;
using Common.SF.Contracts.Interfaces.Base;
using Common.SF.Contracts.Interfaces.Base.Byte;
using Common.SF.Contracts.Interfaces.Core;
using Common.SF.Contracts.Interfaces.Core.Logging;
using Common.SF.Contracts.Interfaces.Core.Notifications;
using Common.SF.Contracts.Interfaces.Core.Settings;
using Common.SF.Contracts.Models.Core.Notifications;
using Common.SF.Contracts.Models.Core.Proxy;
using Common.SF.Infrastructure.AsyncEnumerable.Extensions;
using Common.SF.Infrastructure.EntityFramework;
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
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.V1.FabricTransport.Client;
using Microsoft.ServiceFabric.Services.Runtime;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Fabric;
using System.Fabric.Health;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

[assembly: FabricTransportServiceRemotingProvider(RemotingListenerVersion = RemotingListenerVersion.V2_1 | RemotingListenerVersion.V1, RemotingClientVersion = RemotingClientVersion.V2_1)]

namespace Common.SF.Infrastructure.Base
{
    public abstract class StatefulServiceBase<T> : StatefulServiceBase, IBase where T : BaseModel<Guid>
    {
        #region Properties

        /// <summary>
        /// The name of the service. This is generated on start-up based on the naming conventions of the service project.
        /// </summary>
        private string _serviceName;
        protected string ServiceName
        {
            get
            {
                if (string.IsNullOrEmpty(_serviceName))
                {
                    var name = Context.ServiceName.Segments[Context.ServiceName.Segments.Count() - 1];
                    name.Substring(name.LastIndexOf('.') + 1);
                    string.Concat(name.Select(c => char.IsUpper(c) ? " " + c.ToString() : c.ToString())).TrimStart();
                    _serviceName = name;
                }
                return _serviceName;
            }
        }

        #region Remoting Interfaces    

        /// <summary>
        /// The proxy to the Notification service. This is created if notification implementation has been set to true
        /// </summary>
        private INotifications _notifications;
        protected INotifications Notifications
        {
            get
            {
                try
                {
                    return _notifications ?? (_notifications = ServiceProxyFactory.CreateServiceProxy<INotifications>(UtilityProxy.InitializeNotifications().Result, new ServicePartitionKey(0)));
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
        /// The proxy to the Service Configuration Setting service. This is created if database connection has been set to true
        /// </summary>
        private IH1ServiceConfigurationSetting _h1ServiceConfigurationSettingService;
        protected IH1ServiceConfigurationSetting H1ServiceConfigurationSettingService
        {
            get
            {
                try
                {
                    return _h1ServiceConfigurationSettingService ?? (_h1ServiceConfigurationSettingService = ServiceProxyFactory.CreateServiceProxy<IH1ServiceConfigurationSetting>(UtilityProxy.InitializeH1ServiceConfigurationSetting().Result, new ServicePartitionKey(0)));
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
        private IDataFilter _serviceDataFilter;
        protected IDataFilter ServiceDataFilter
        {
            get
            {
                try
                {
                    return _serviceDataFilter ?? (_serviceDataFilter = ServiceProxyFactory.CreateServiceProxy<IDataFilter>(UtilityProxy.InitializeDataFilter().Result, new ServicePartitionKey(0)));
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

        /// <summary>
        /// The configuration settings for this service. 
        /// </summary>
        protected H1ServiceConfigurationSettingModel H1ServiceConfigurationSettingModel { get; private set; }

        #region Quick Settings Methods
        // [17-Dec-2019] : Code Commented for Database Sync enable Log by Nitin
        /// <summary>
        /// The Check Database Sync is Enabled or not
        /// </summary>
        //bool IsDataBaseSyncEnabled
        //{
        //    get
        //    {
        //        if (H1ServiceConfigurationSettingModel != null)
        //        {
        //            if (H1ServiceConfigurationSettingModel.DatabaseSyncModel != null)
        //            {
        //                return H1ServiceConfigurationSettingModel.DatabaseSyncModel.IsDatabaseSyncEnabled.Value;
        //            }
        //        }
        //        return false;
        //    }
        //}
        //[17-Dec-2019] : Code Commented for Audit Log by Nitin
        ///// <summary>
        ///// To Check is Audit Logging enabled or not from Service Configuration Setting
        ///// </summary>
        //bool IsAuditLoggingEnabled
        //{
        //    get
        //    {
        //        if (H1ServiceConfigurationSettingModel != null)
        //        {
        //            if (H1ServiceConfigurationSettingModel.AuditLoggingModel != null)
        //            {
        //                return H1ServiceConfigurationSettingModel.AuditLoggingModel.IsAuditLoggingEnabled.Value;
        //            }
        //        }
        //        return false;
        //    }
        //}

        bool IsAutomatedNotificationsEnabled
        {
            get
            {
                if (H1ServiceConfigurationSettingModel != null)
                {
                    return H1ServiceConfigurationSettingModel.IsAutomatedCrudNotifications;
                }
                return false;
            }
        }

        bool IsLegacySystemDataSyncEnabled
        {
            get
            {
                if (H1ServiceConfigurationSettingModel != null)
                {
                    return H1ServiceConfigurationSettingModel.IsLegacySystemSynchronizationEnabled;
                }
                return false;
            }
        }

        #endregion

        /// <summary>
        /// The entity framework created for the supplied model <see cref="T"/>
        /// </summary>
        protected EntityFrameworkRepository<T> DatabaseSyncEntityFramework { get; private set; }
        //[17-Dec-2019] : Code Commented for Data Sync by Nitin
        //  protected EntityFrameworkRepository<T> AuditLoggingEntityFramework { get; private set; }
        protected EntityFrameworkRepository<T> LegacySystemDataSyncEntityFramework { get; private set; }

        protected const string _cacheName = "_cacheDictionary";
        protected const string _notificationQueue = "_notificationQueue";
        //[17-Dec-2019] : Code Commented for Data Sync by Nitin
        // protected const string _auditQueue = "_auditQueue";
        protected const string _datasyncQueue = "datasyncQueue";
        protected const string _legacySystemDataSyncQueue = "legacySystemDataSyncQueue";
        protected string[] _keysIndex16Bit = { "a", "b", "c", "d", "e", "f", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        protected string[] _dateFormats = { "yyyy-MM-dd HH:mm:ss.FFFFFFF", "dd-MM-yyyy HH:mm:ss.FFFFFFF" };
        #endregion

        #region ctors
        /// <summary>
        /// Creates an instance of a default Stateful Service
        /// </summary>
        /// <param name="context">The context for the stateful service</param>
        /// <param name="implementNotifications">Represents whether the service should automatically create <see cref="Subscriptions"/>s after crud operations.
        /// If this option is set to True, any Crud method that has been overriden will not create <see cref="Subscriptions"/>s and must be implemented manually.</param>
        /// <param name="connectDatabase">Represents whether the service should mirror crud operations to a database connection</param>
        public StatefulServiceBase(StatefulServiceContext context, bool implementCrudNotifications = false, bool connectDatabase = false)
            : base(context)
        { }

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

        // [15-Jan-2020]: Code Commented for RegisterOldSettingsChannel which is obsolete by Nitin
        //protected override async Task BaseRunAsync(CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        //[17-Dec-2019] : Code Commented for obsolete tasks by Nitin
        //        var tasks = new Task[1];
        //        //tasks[0] = NotificationQueue(cancellationToken);
        //        //tasks[1] = AuditQueue(cancellationToken);
        //        //tasks[2] = DataSyncQueue(cancellationToken);
        //        tasks[0] = RegisterOldSettingsChannel(cancellationToken);
        //        await Task.WhenAll(tasks);
        //    }
        //    catch (TaskCanceledException) { }
        //    catch (FabricNotPrimaryException) { }
        //    catch (Exception e)
        //    {
        //        await LogHealthState("RunAsync", $"{e.Message}", HealthState.Error);
        //        throw e;
        //    }
        //}

        // [15-Jan-2020]: Code Commented for RegisterOldSettingsChannel which is obsolete by Nitin
        //private async Task RegisterOldSettingsChannel(CancellationToken ct)
        //{
        //    bool connected = false;
        //    while (!ct.IsCancellationRequested && !connected)
        //    {
        //        try
        //        {
        //            await SubscriberServiceHelper.RegisterMessageChannelAsync(this, $"H1 Service Configuration Setting-{ Context.ServiceName.Segments[Context.ServiceName.Segments.Count() - 1]}-CRUD");
        //            await Notifications.ProcessChannels(CompressToBytes(NotificationModelConverter<T>.CreatesCrudChannels(Context)));
        //            connected = true;
        //            ServiceEventSource.Current.ServiceMessage(Context, "Service successfully created service channel");
        //        }
        //        catch (Exception)
        //        {
        //            await LogHealthState("RegisterSettingsChannel", "The service setting refresh channel could not be created as the service could not connect to the BrokerActor or " +
        //                                                            "Subscription service.",
        //                HealthState.Warning, TimeSpan.FromMinutes(1), true);
        //            await Task.Delay(TimeSpan.FromMinutes(1), ct);
        //        }
        //    }
        //}


        #region Queues

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
        //[17-Dec-2019] : Code Commented for Audit Log by Nitin
        //private async Task AuditQueue(CancellationToken cancellationToken)
        //{
        //    var failCount = 0;
        //    while (!cancellationToken.IsCancellationRequested)
        //    {

        //        var queue = await StateManager.GetOrAddAsync<IReliableQueue<T>>(_auditQueue);
        //        using (var tx = StateManager.CreateTransaction())
        //        {
        //            try
        //            {
        //                var result = await queue.TryDequeueAsync(tx);
        //                if (result.HasValue)
        //                {
        //                    object oldModel = null;
        //                    object newModel = null;
        //                    List<string> ignoreFieldslist = new List<string>();
        //                    var item = await GetUncompressed(result.Value.Id);

        //                    if (item == null) // delete
        //                    {
        //                        oldModel = Activator.CreateInstance(typeof(T));
        //                        newModel = result.Value;
        //                        var objDelete = (T)newModel;
        //                        objDelete.CrudOperationType = CrudOperationType.Delete;
        //                        newModel = objDelete;
        //                    }
        //                    else // create or udpate
        //                    {
        //                        newModel = item;
        //                        oldModel = item.CrudOperationType == CrudOperationType.Create ? Activator.CreateInstance(typeof(T)) : result.Value;
        //                        if (item.CrudOperationType == CrudOperationType.Update)
        //                        {
        //                            ignoreFieldslist.Add("ModifiedDate");
        //                            ignoreFieldslist.Add("CreatedDate");
        //                        }
        //                    }
        //                    await AuditLogItem(oldModel, newModel, ignoreFieldslist);
        //                }
        //                await tx.CommitAsync();
        //            }
        //            catch (Exception e)
        //            {
        //                if (failCount < 5)
        //                {
        //                    tx.Abort();
        //                    failCount++;
        //                    await LogHealthState("AuditQueue", $"An audit log could not be sent due to the following error: {e.Message}", HealthState.Error, TimeSpan.FromMinutes(1), true);
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

        //private async Task DataSyncQueue(CancellationToken cancellationToken)
        //{
        //    var failCount = 0;
        //    while (!cancellationToken.IsCancellationRequested)
        //    {
        //        var queue = await StateManager.GetOrAddAsync<IReliableQueue<T>>(_datasyncQueue);
        //        using (var tx = StateManager.CreateTransaction())
        //        {
        //            try
        //            {
        //                var result = await queue.TryDequeueAsync(tx);
        //                if (result.HasValue)
        //                {
        //                    var model = result.Value;
        //                   // await SyncItemToDatabase(model);
        //                }
        //                await tx.CommitAsync();
        //            }
        //            catch (Exception e)
        //            {
        //                if (failCount < 5)
        //                {
        //                    tx.Abort();
        //                    failCount++;
        //                    await LogHealthState("DataSyncQueue", $"Data Synchronization could not complete due to the following error: {e.Message}", HealthState.Error, TimeSpan.FromMinutes(1), true);
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

        /// <summary>
        /// Separate Queue for data sync. from H1 > CPD
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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

        //[17-Dec-2019] : Code Commented for Audit Log by Nitin
        //private async Task EnqueueAuditLoggingItem(T model)
        //{
        //    #region Audit Log
        //    if (IsAuditLoggingEnabled)
        //    {
        //        var queue = await StateManager.GetOrAddAsync<IReliableQueue<T>>(_auditQueue);
        //        using (var tx = StateManager.CreateTransaction())
        //        {

        //            List<string> ignoreFieldslist = new List<string>();
        //            var ItemModel = model;
        //            if (model.CrudOperationType == CrudOperationType.Update)
        //            {
        //                var item = await GetUncompressed(model.Id);

        //                if (item != null) // update
        //                {
        //                    ItemModel = item;
        //                    ItemModel.CrudOperationType = model.CrudOperationType;
        //                }
        //            }
        //            await queue.EnqueueAsync(tx, ItemModel);
        //            await tx.CommitAsync();
        //        }
        //    }
        //    #endregion
        //}

        private async Task EnqueueItems(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                //#region Audit Log
                //if (IsAuditLoggingEnabled)
                //{
                //    var queue = await StateManager.GetOrAddAsync<IReliableQueue<T>>(_auditQueue);
                //    using (var tx = StateManager.CreateTransaction())
                //    {
                //        await queue.EnqueueAsync(tx, item);
                //        await tx.CommitAsync();
                //    }
                //}
                //#endregion

                #region Notifications
                //if (IsAutomatedNotificationsEnabled)
                //{
                //    var queue = await StateManager.GetOrAddAsync<IReliableQueue<T>>(_notificationQueue);
                //    using (var tx = StateManager.CreateTransaction())
                //    {
                //        await queue.EnqueueAsync(tx, item);
                //        await tx.CommitAsync();
                //    }
                //}
                #endregion
                // [17-Dec-2019] : Code Commented for Database Sync enable Log by Nitin
                //#region Data Sync
                //if (IsDataBaseSyncEnabled)
                //{
                //    var queue = await StateManager.GetOrAddAsync<IReliableQueue<T>>(_datasyncQueue);
                //    using (var tx = StateManager.CreateTransaction())
                //    {
                //        await queue.EnqueueAsync(tx, item);
                //        await tx.CommitAsync();
                //    }
                //}
                //#endregion

                //#region H1 > CPD Data Sync
                //if (IsLegacySystemDataSyncEnabled)
                //{
                //    var queue = await StateManager.GetOrAddAsync<IReliableQueue<T>>(_legacySystemDataSyncQueue);
                //    using (var tx = StateManager.CreateTransaction())
                //    {
                //        await queue.EnqueueAsync(tx, item);
                //        await tx.CommitAsync();
                //    }
                //}
                //#endregion

            }
        }

        #endregion

        #endregion

        #region Service Configuration

        /// <summary>
        /// <para> Continuously refreshes the Service configuration settings by connecting to the ServiceConfiguration service</para>
        /// </summary>
        /// <returns></returns>
        private async Task ForceRefreshServiceConfiguration()
        {
            var filters = new List<FilterCollectionModel>();
            var internalFilters = new List<InternalFilterModel>
                {
                    new InternalFilterModel
                    {
                        FilterProperty = "ServiceName",
                        FilterValue = this.Context.ServiceName.Segments[this.Context.ServiceName.Segments.Count() - 1],
                        IsAnd = false
                    }
                };
            filters.Add(new FilterCollectionModel() { InternalFilterCollection = internalFilters, IsAnd = false });
            var h1Config = Decompress<IEnumerable<H1ServiceConfigurationSettingModel>>(await H1ServiceConfigurationSettingService.GetByFilter(filters));
            if (h1Config?.Count() > 0)
            {
                H1ServiceConfigurationSettingModel = h1Config.FirstOrDefault();
                //if (IsDataBaseSyncEnabled)
                //{
                //    await SetDatabaseSyncConnectionStrings();
                //    //var dbEntities = await DatabaseSyncEntityFramework.GetAllEntities();
                //}
                // else
                DatabaseSyncEntityFramework = null;

                //[17-Dec-2019] : Code Commented for Audit Log by Nitin
                //if (IsAuditLoggingEnabled)
                //{
                //    await SetAuditLoggingConnectionStrings();
                //}

                //if (IsAutomatedNotificationsEnabled)
                //{
                //    await CreateSubscriptionChannels();
                //}
            }
            else
            {
                var defaultSetting = await DefaultSettings();
                await H1ServiceConfigurationSettingService.ProcessOperation(defaultSetting);
                await ForceRefreshServiceConfiguration();
            }
        }


        public virtual Task<string> DefaultSettings()
        {
            var setting = new List<H1ServiceConfigurationSettingModel>
            {
                new H1ServiceConfigurationSettingModel
                {
                    ServiceName = Context.ServiceName.Segments[this.Context.ServiceName.Segments.Count() - 1],
                    AllowRefreshing = true,
                    IsActive = true,
                    IsAutomatedCrudNotifications = false,
                    IsLegacySystemSynchronizationEnabled = false,
                    IsTextLoggingEnabled = false,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    CrudOperationType = CrudOperationType.Create,
                    AuditLoggingModel = new AuditLoggingModel { IsAuditLoggingEnabled = false, },
                    DatabaseSyncModel = new DatabaseSyncModel { IsDatabaseSyncEnabled = false, },
                    ServiceValidation = new ServiceValidationModel { IsServiceValidationEnabled = false },
                }
            };
            return Task.FromResult(Compress(setting));
        }

        public virtual Task<H1ServiceConfigurationSettingModel> DefaultSettingsUncompressed()
        {
            return Task.FromResult(new H1ServiceConfigurationSettingModel
            {
                ServiceName = Context.ServiceName.Segments[this.Context.ServiceName.Segments.Count() - 1],
                AllowRefreshing = true,
                IsActive = true,
                IsAutomatedCrudNotifications = false,
                IsLegacySystemSynchronizationEnabled = false,
                IsTextLoggingEnabled = false,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                CrudOperationType = CrudOperationType.Create,
                AuditLoggingModel = new AuditLoggingModel { IsAuditLoggingEnabled = false, },
                DatabaseSyncModel = new DatabaseSyncModel { IsDatabaseSyncEnabled = false, },
                ServiceValidation = new ServiceValidationModel { IsServiceValidationEnabled = false },
            });
        }

        /// <summary>
        /// Retrieves the configuration settings for this service and creates the Database connection
        /// </summary>
        /// <returns></returns>
        //protected async Task SetDatabaseSyncConnectionStrings()
        //{
        //    try
        //    {
        //        if (DatabaseSyncEntityFramework == null)
        //        {
        //            DatabaseSyncEntityFramework = new EntityFrameworkRepository<T>();
        //        }
        //        await DatabaseSyncEntityFramework.SetDBConnection(H1ServiceConfigurationSettingModel.DatabaseSyncModel.H1ConfigurationSettingGuid);
        //    }
        //    catch (InvalidOperationException e)
        //    {
        //        await LogException(e);
        //    }
        //}

        //[17-Dec-2019] : Code Commented for Audit Log by Nitin
        /// <summary>
        /// Retrieves the configuration settings for this service and creates the Database connection
        /// </summary>
        /// <returns></returns>
        //protected async Task SetAuditLoggingConnectionStrings()
        //{
        //    try
        //    {
        //        if (AuditLoggingEntityFramework == null)
        //        {
        //            AuditLoggingEntityFramework = new EntityFrameworkRepository<T>();
        //        }
        //        await AuditLoggingEntityFramework.SetDBConnection(H1ServiceConfigurationSettingModel.AuditLoggingModel.AuditLoggingDBConnection_H1ConfigurationSettingGuid);
        //    }
        //    catch (InvalidOperationException e)
        //    {
        //        await LogException(e);
        //    }
        //}

        #endregion

        #region Base64 Crud Methods

        #region Uncompressed Get Methods

        /// <summary>
        /// Gets all the model currently in the stored state
        /// </summary>
        /// <returns>A list of the requested models</returns>
        public virtual async Task<IEnumerable<T>> GetAllUncompressed()
        {
            LogTextOutput($"GetAll : Started parallel retrieval of dictionaries");

            List<T> itemList = new List<T>();
            var tasks = new List<Task>();
            //await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            //{
            foreach (var key in _keysIndex16Bit)
            {
                tasks.Add(Task.Run(async () =>
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
            }
            await Task.WhenAll(tasks);
            LogTextOutput($"GetAll : Ended parallel retrieval of dictionaries");
            return itemList;
        }
        /// <summary>
        /// Get the specified model data in an uncompressed form. 
        /// </summary>
        /// <param name="field">Name of fields data required from service</param>
        /// <returns>A list of the requested models</returns>
        public async Task<string> GetAllFieldsSelectorUncompressed(string field)
        {
            LogTextOutput($"GetAllFieldsSelectorUncompressed : Started retrieval of specified items");
            List<T> itemList = new List<T>();
            List<object> specificitemList = new List<object>();
            var tasks = new List<Task>();
            foreach (var key in _keysIndex16Bit)
            {
                tasks.Add(Task.Run(async () =>
                {
                    using (var tx = StateManager.CreateTransaction())
                    {

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
                        LogTextOutput($"GetAllFieldsSelectorUncompressed ::  total : { models.Count() } in { stopwatcher.Elapsed }ms");
                    }
                }));
            }
            await Task.WhenAll(tasks);
            LogTextOutput($"GetAllFieldsSelectorUncompressed : Ended retrieval of specified items");
            var dataToPersist = itemList.Select($"new ({field})");
            return JsonConvert.SerializeObject(dataToPersist);
        }

        /// <summary>
        /// Get the specified model data in an uncompressed form while fetching the data from dictionaries. 
        /// </summary>
        /// <param name="field">Name of fields data required from service</param>
        /// <returns>A list of the requested models</returns>
        public virtual async Task<string> GetAllFieldsSelectorByDictionaryUncompressed(string key, string field)
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
                return JsonConvert.SerializeObject(models.Select($"new ({field})"));
            }
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
            var tasks = new List<Task>();
            //await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            //{
            foreach (var key in _keysIndex16Bit)
            {
                tasks.Add(Task.Run(async () =>
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
                                models.Add(asyncEnumerator.Current.Value);
                            }
                        }

                        var filteredModels = FilterItemList(filterList, models);

                        lock (itemList)
                            itemList.AddRange(filteredModels);

                        stopwatcher.Stop();
                        LogTextOutput($"GetByFilter : Ended with key({ key }) ::  total : { filteredModels.Count() } in { stopwatcher.Elapsed }ms");
                    }
                }));
            }
            //}));
            await Task.WhenAll(tasks);

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
            var list = (await GetAllUncompressed()).ToList();
            return FilterItemList(filterList, list).Any();
        }

        #endregion

        #region Compressed Get Methods

        /// <summary>
        /// Gets all the model currently in the stored state
        /// </summary>
        /// <returns>A list of the requested models</returns>
        public virtual async Task<string> GetAll()
        {
            LogTextOutput($"GetAll : Started parallel retrieval of dictionaries");
            List<T> itemList = new List<T>();
            var tasks = new List<Task>();
            foreach (var key in _keysIndex16Bit)
            {
                tasks.Add(Task.Run(async () =>
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
            }
            await Task.WhenAll(tasks);

            LogTextOutput($"GetAll : Ended parallel retrieval of dictionaries");
            var dataToPersist = Compress(itemList);
            return dataToPersist;
        }

        /// <summary>
        /// Gets all the specified fields currently in the stored state
        /// </summary>
        /// <param name="field">Fields which are require to fetch</param>
        /// <returns>A list of given fileds data</returns>
        public async Task<string> GetAllFieldsSelector(string field)
        {
            LogTextOutput($"GetAllFieldsSelector : Started parallel retrieval of dictionaries");
            List<T> itemList = new List<T>();
            var tasks = new List<Task>();
            foreach (var key in _keysIndex16Bit)
            {
                tasks.Add(Task.Run(async () =>
                {
                    using (var tx = StateManager.CreateTransaction())
                    {
                        LogTextOutput($"GetAllFieldsSelector : Started with key({ key })");
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
                        LogTextOutput($"GetAllFieldsSelector : Ended with key({ key }) ::  total : { models.Count() } in { stopwatcher.Elapsed }ms");
                    }
                }));
            }
            await Task.WhenAll(tasks);
            LogTextOutput($"GetAllFieldsSelector : Ended parallel retrieval of dictionaries");

            var specificFields = itemList.Select($"new ({field})");
            var dataToPersist = Compress(specificFields);
            return dataToPersist;
        }

        /// <summary>
        /// Handle passing argument with type
        /// </summary>
        /// <param name="propValue">Value of Property</param>
        /// <param name="propName">Name of Property</param>
        /// <returns>String</returns>
        public string GetFilterConditionValue(object propValue, string propName)
        {
            if (propValue != null)
                return propValue.ToString();
            else
                return null;
        }

        /// <summary>
        /// Gets a collection of models based on the provided filter logic
        /// </summary>
        /// <param name="Filters">A list of filter logic to determine what to return</param>
        /// <returns>A list of the requested models</returns>
        public async Task<string> GetAllFieldsSelectorFilter(List<SpecificDataFilteringModel> Filters)
        {
            string wherecondition = "";
            string specificfields = Filters.Where(it => !string.IsNullOrEmpty(it.SpecificFields)).Select(it => it.SpecificFields).FirstOrDefault();
            var conditions = Filters.Select((it) => new { it.FieldName, it.FieldValue, it.Operators, it.LogicalOperators, FilterOrder = Convert.ToInt32(it.FilterOrder) }).ToList();
            

            LogTextOutput($"GetAllFieldsSelectorFilter : Started parallel retrieval of dictionaries");
            List<T> itemList = new List<T>();
            var tasks = new List<Task>();
            foreach (var key in _keysIndex16Bit)
            {
                tasks.Add(Task.Run(async () =>
                {
                    using (var tx = StateManager.CreateTransaction())
                    {
                        LogTextOutput($"GetAllFieldsSelectorFilter : Started with key({ key })");
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
                        LogTextOutput($"GetAllFieldsSelectorFilter : Ended with key({ key }) ::  total : { models.Count() } in { stopwatcher.Elapsed }ms");
                    }
                }));
            }

            await Task.WhenAll(tasks);
            LogTextOutput($"GetAllFieldsSelectorFilter : Ended parallel retrieval of dictionaries");
            Dictionary<int, object> dateFilterListParams = new Dictionary<int, object>();
            
            foreach (var item in conditions.OrderBy(it => it.FilterOrder))
            {
                bool IsDateTime = false;
                bool IsGuid = false;
                DateTime dtObject = new DateTime();
                Guid guidObject = Guid.Empty;
                IsDateTime = DateTime.TryParseExact(item.FieldValue.ToString(), _dateFormats, null, System.Globalization.DateTimeStyles.None, out dtObject);
                if (IsDateTime)
                    dateFilterListParams.Add(item.FilterOrder, dtObject);
                else
                {
                    IsGuid = Guid.TryParse(item.FieldValue.ToString(), out guidObject);
                    if (IsGuid)
                        dateFilterListParams.Add(item.FilterOrder, guidObject);
                }

                if (item.Operators == ComparisionOperators.Contains || item.Operators == ComparisionOperators.StartsWith)
                {
                    wherecondition = wherecondition + $" {item.FieldName.ToString()}.ToLower().{item.Operators}({GetFilterConditionValue(item.FieldValue.ToString().ToLower(), item.FieldName)}) {item.LogicalOperators}";
                }
                else
                {
                    if (IsDateTime | IsGuid)
                        wherecondition = wherecondition + $" {item.FieldName.ToString()} {item.Operators} @{ item.FilterOrder } {item.LogicalOperators}";
                    else
                        wherecondition = wherecondition + $" {item.FieldName.ToString()} {item.Operators} {  GetFilterConditionValue(item.FieldValue, item.FieldName).ToString() } {item.LogicalOperators}";
                }
                LogTextOutput(IsDateTime.ToString() + "    " + IsGuid.ToString());
            }
            if (dateFilterListParams.Count > 0)
            {
                if (!string.IsNullOrEmpty(specificfields))
                    return Compress(itemList.Where($"{wherecondition}", dateFilterListParams.OrderBy(it => it.Key).Select(it => it.Value).ToArray()).Select($"new ({specificfields})"));
                else
                    return Compress(itemList.Where($"{wherecondition}", dateFilterListParams.OrderBy(it => it.Key).Select(it => it.Value).ToArray()));
            }
            else
            {
                if (!string.IsNullOrEmpty(specificfields))
                    return Compress(itemList.Where($"{wherecondition}").Select($"new ({specificfields})"));
                else
                    return Compress(itemList.Where($"{wherecondition}"));
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllByPartitionUncompressed(string key)
        {
            if (key[0] > 102 || (key[0] < 97 && key[0] > 57) || key[0] < 48 || key.Length > 1)
                throw new Exception($"Character {key} is not accepted by this method");

            //var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
            //var itemList = await DictionaryToList(dictionary);
            //return itemList;
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

        public virtual async Task<string> GetAllByPartition(string key)
        {
            var models = await GetAllByPartitionUncompressed(key);
            return Compress(models);
        }
        /// <summary>
        /// Collects the required fields data by dictionary w.r.t. Key value.
        /// </summary>
        /// <param name="key">Name of dictionary key.</param>
        /// <param name="selectorAndFilter">Fields which are require to fetch</param>
        /// <returns>String of Compressed form for specific fields record.</returns>
        public virtual async Task<string> GetAllFieldsSelectorByPartition(string key, string selectorAndFilter)
        {
            var models = await GetAllByPartitionUncompressed(key);
            var specificFields = Compress(models.Select($"new ({models})"));
            return specificFields;
        }

        public virtual async Task<string> GetFieldsSelectorWithFilterByDictionary(string key, string selectorAndFilter)
        {
            string specificFields = null;
            Dictionary<string, object> dateFilterListParams = new Dictionary<string, object>();
            string whereStr = string.Empty;
            var models = await GetAllByPartitionUncompressed(key);
            var deserializeitem = JsonConvert.DeserializeObject<FiltersSpecificModel>(Compressor.DecompressBase64(selectorAndFilter));
            if (deserializeitem.SpecificDataFiltering != null && deserializeitem.Fields != null)
            {
                whereStr = ConditionCheck(deserializeitem, ref dateFilterListParams);
                if (dateFilterListParams.Count == 0)
                        specificFields = Compress(models.Where($"{ whereStr }").Select($"new ({string.Join(",", deserializeitem.Fields.ToList())})"));
                else
                    specificFields = Compress(models.Where($"{ whereStr }", dateFilterListParams.OrderBy(it => it.Key).Select(it => it.Value).ToArray()).Select($"new ({string.Join(",", deserializeitem.Fields.ToList())})"));
            }
            else if (deserializeitem.Fields != null && deserializeitem.SpecificDataFiltering == null)
                specificFields = Compress(models.Select($"new ({string.Join(",", deserializeitem.Fields.ToList())})"));
            return specificFields;
        }

        public virtual async Task<IEnumerable<T>> GetAsyncFieldsSelectorByPartitionUnCompressed(string key, FiltersSpecificModel filtersSpecifics)
        {
            IEnumerable<T> specificFields = null;
            Dictionary<string, object> dateFilterListParams = new Dictionary<string, object>();
            string whereStr = string.Empty;
            var models = await GetAllByPartitionUncompressed(key);
            if (filtersSpecifics.SpecificDataFiltering.Count() > 0)
            {
                whereStr = ConditionCheck(filtersSpecifics, ref dateFilterListParams);
                if (dateFilterListParams.Count == 0)
                    specificFields = models.Where($"{ whereStr }");
                else
                    specificFields = models.Where($"{ whereStr }", dateFilterListParams.OrderBy(it => it.Key).Select(it => it.Value).ToArray());
            }
            else
            {
                specificFields = models;
            }
            return specificFields;
        }

        public virtual async Task<IEnumerable<T>> GetAsyncFieldsSelectorByPartition(string key, FiltersSpecificModel filtersSpecifics)
        {
            Dictionary<string, object> dateFilterListParams = new Dictionary<string, object>();
            string specificFieldsCompressedForm = null;
            IEnumerable<T> specificFields = null;
            var models = await GetAllByPartitionUncompressed(key);
            string whereStr = string.Empty;
            if (filtersSpecifics.SpecificDataFiltering.Count() > 0)
            {
                whereStr = ConditionCheck(filtersSpecifics, ref dateFilterListParams);
                if (dateFilterListParams.Count==0)
                    specificFieldsCompressedForm = Compress(models.Where($"{ whereStr }"));
                else
                    specificFieldsCompressedForm = Compress(models.Where($"{ whereStr }", dateFilterListParams.OrderBy(it => it.Key).Select(it => it.Value).ToArray()));
            }
            else
            {
                specificFieldsCompressedForm = Compress(models);
            }
            specificFields = JsonConvert.DeserializeObject<List<T>>(Compressor.DecompressBase64(specificFieldsCompressedForm));
            return specificFields;
        }

        private string ConditionCheck(FiltersSpecificModel filtersSpecifics, ref Dictionary<string, object> dateFilterListParams)
        {
            
            string wherecondition = "";
            foreach (var item in filtersSpecifics.SpecificDataFiltering.OrderBy(it => it.FilterOrder))
            {
                bool IsDateTime = false;
                bool IsGuid = false;
                DateTime dtObject = new DateTime();
                Guid guidObject = Guid.Empty;
                IsDateTime = DateTime.TryParseExact(item.FieldValue.ToString(), _dateFormats, null, System.Globalization.DateTimeStyles.None, out dtObject);
                if (IsDateTime)
                    dateFilterListParams.Add(item.FilterOrder, dtObject);
                else
                {
                    IsGuid = Guid.TryParse(item.FieldValue.ToString(), out guidObject);
                    if (IsGuid)
                        dateFilterListParams.Add(item.FilterOrder, guidObject);
                }

                if (item.Operators == ComparisionOperators.Contains || item.Operators == ComparisionOperators.StartsWith)
                {
                    wherecondition = wherecondition + $" {item.FieldName.ToString()}.ToLower().{item.Operators}({GetFilterConditionValue(item.FieldValue.ToString().ToLower(), item.FieldName)}) {item.LogicalOperators}";
                }
                else
                {
                    if (IsDateTime | IsGuid)
                        wherecondition = wherecondition + $" {item.FieldName.ToString()} {item.Operators} @{ item.FilterOrder } {item.LogicalOperators}";
                    else
                        wherecondition = wherecondition + $" {item.FieldName.ToString()} {item.Operators} {  GetFilterConditionValue(item.FieldValue, item.FieldName).ToString() } {item.LogicalOperators}";
                }
            }
            return wherecondition;
        }

        /// <summary>
        /// Gets a collection of models based on the provided filter logic
        /// </summary>
        /// <param name="filterList">A list of filter logic to determine what to return</param>
        /// <returns>A list of the requested models</returns>
        public async Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList)
        {
            var uncompressedData = await GetByFilterUncompressed(filterList);
            var dataToPersist = Compress(uncompressedData);
            return dataToPersist;
        }

        /// <summary>
        /// Retrieves a model from the stored state based on the provided <see cref="Guid"/>.
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> of the model to be retrieved</param>
        /// <returns>The requested model compressed</returns>
        public virtual async Task<string> Get(Guid id)
        {
            string result = "";
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
        /// This method does not add the model to the database queue and is not processed by the <see cref="EntityFrameworkRespository{T}"/>.
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
                            //[17-Dec-2019] : Code Commented for Audit Log by Nitin
                            //  await EnqueueAuditLoggingItem(model);
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
                        //[17-Dec-2019] : Code Commented for Audit Log by Nitin
                        // await EnqueueAuditLoggingItem(model);
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
                    //[17-Dec-2019] : Code Commented for Audit Log by Nitin
                    //else
                    //{
                    //    await EnqueueAuditLoggingItem(model);
                    //}
                }
                await tx.CommitAsync();
            }
            return errors;
        }

        /// <summary>
        /// Removes a collection of models based on the provided filter logic
        /// </summary>
        /// <param name="filterList">A list of filter logic to determine what to remove</param>
        /// <returns>A list of the removed models</returns>
        [Obsolete("This method will not work. It is using an older method of storing the data. Marked as obsolete as the method is not exposed.")]
        public async Task<IEnumerable<T>> DeleteByFilter(IEnumerable<FilterCollectionModel> filterList)
        {
            var modelList = new List<T>();
            try
            {
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>(_cacheName);
                var itemList = await DictionaryToList(dictionary);
                var resultList = FilterItemList(filterList, itemList);
                using (var tx = StateManager.CreateTransaction())
                {
                    foreach (var filteredItem in resultList)
                    {
                        //[17-Dec-2019] : Code Commented for Audit Log by Nitin
                        // if (IsAuditLoggingEnabled)
                        // await AuditLogItem(filteredItem);

                        //if (IsDataBaseSyncEnabled)
                        //    await SyncItemToDatabase(filteredItem);

                        //if (IsAutomatedNotificationsEnabled)
                        //    await PublishNotification(filteredItem);

                        await dictionary.TryRemoveAsync(tx, filteredItem.Id);
                        modelList.Add(filteredItem);
                    }
                    await tx.CommitAsync();
                }
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceMessage(Context, $"A failure occured during RunAsync: {e.Message}");
                await LogHealthState("DeleteByFilter", e.Message, HealthState.Error);
                await LogException(e);
                throw;
            }
            return modelList;
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

        #region Byte[] Crud Methods


        #region Compressed Get Methods

        /// <summary>
        /// Gets all the model currently in the stored state
        /// </summary>
        /// <returns>A list of the requested models</returns>
        async Task<byte[]> IBaseByte.GetAll()
        {
            LogTextOutput($"GetAll : Started parallel retrieval of dictionaries");

            List<T> itemList = new List<T>();
            var tasks = new List<Task>();
            //await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            //{
            foreach (var key in _keysIndex16Bit)
            {
                tasks.Add(Task.Run(async () =>
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
            }
            await Task.WhenAll(tasks);

            LogTextOutput($"GetAll : Ended parallel retrieval of dictionaries");
            var dataToPersist = Compressor.Compress(JsonConvert.SerializeObject(itemList));
            return dataToPersist;
        }

        async Task<byte[]> IBaseByte.GetAllByPartition(string key)
        {
            var models = await GetAllByPartitionUncompressed(key);
            return Compressor.Compress(JsonConvert.SerializeObject(models));
        }

        public virtual async Task<byte[]> GetAllSecureDataByPartition(string key, byte[] guidData)
        {
            if (key[0] > 102 || (key[0] < 97 && key[0] > 57) || key[0] < 48 || key.Length > 1)
                throw new Exception($"Character {key} is not accepted by this method");

            var guids = DecompressToBytes<IEnumerable<Guid>>(guidData);

            LogTextOutput($"GetAllSecureDataByPartition :: Started with key({ key })");
            LogTextOutput($"GetAllSecureDataByPartition :: Started retrieving filters");

            var serviceFilters = DecompressToBytes<IEnumerable<SecurityFilter>>(await ServiceDataFilter.GetDataFiltersByRequest(guids, Context.ServiceName.ToString()));

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
            var uncompressedData = await GetByFilterUncompressed(DecompressToBytes<IEnumerable<FilterCollectionModel>>(filterList));
            return CompressToBytes(uncompressedData);
        }

        public virtual async Task<byte[]> GetByFilterByPartition(string key, byte[] filter)
        {
            var filterList = DecompressToBytes<IEnumerable<FilterCollectionModel>>(filter);
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

                return CompressToBytes(models);
            }
        }

        /// <summary>
        /// Retrieves a model from the stored state based on the provided <see cref="Guid"/>.
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> of the model to be retrieved</param>
        /// <returns>The requested model compressed</returns>
        async Task<byte[]> IBaseByte.Get(Guid id)
        {
            byte[] result = null;
            using (var tx = StateManager.CreateTransaction())
            {
                var dictionary = await GetDictionaryByModelId(id);
                var item = await dictionary.TryGetValueAsync(tx, id);
                if (item.HasValue)
                    result = CompressToBytes(item.Value);
            }
            return result;
        }

        public async Task<byte[]> ProcessOperation(byte[] objData)
        {
            var modelList = JsonConvert.DeserializeObject<IEnumerable<T>>(objData.Decompress());
            var errors = await ProcessOperation(modelList);
            return Compressor.Compress(JsonConvert.SerializeObject(errors));
        }

        #endregion

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

        public async Task<string> ProcessOperation(string objData)
        {
            var modelList = Decompress<IEnumerable<T>>(objData);
            var errors = await ProcessOperation(modelList);
            return Compress(errors);
        }

        /// <summary>
        /// Creates, updates or deletes models from the StateManager, based on the stored <see cref="CrudOperationType"/>. Once 
        /// added to the state the same action is repeated into the database using the <see cref="EntityFrameworkRespository{T}"/>.
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns>The list of modified models</returns>
        public virtual async Task<IEnumerable<T>> ProcessOperation(IEnumerable<T> modelList)
        {
            var count = modelList.Count();
            var errors = new List<T>();
            var currentModels = new List<T>();
            var batchListAdd = new List<T>();
            var batchListDelete = new List<T>();
            int batchCounter = 0;
            int batchSize = 2000;


            //using (var tx = StateManager.CreateTransaction())
            //{
            //    var items = await _dictionary.CreateEnumerableAsync(tx);
            //    using (var asyncEnumerator = items.GetAsyncEnumerator())
            //    {
            //        while (await asyncEnumerator.MoveNextAsync(CancellationToken.None))
            //        {
            //            currentModels.Add(asyncEnumerator.Current.Value);
            //        }
            //    }
            //}

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

        //[17-Dec-2019] : Code Commented for Audit Log by Nitin
        //protected async Task AuditLogItem(object oldModel, object newModel, List<string> ignoreFieldslist)
        //{
        //    // List<string> ignoreFieldslist = new List<string>();

        //    //switch (model.CrudOperationType)
        //    //{
        //    //    case CrudOperationType.Delete:
        //    //        oldModel = Activator.CreateInstance(typeof(T));
        //    //        newModel = model;
        //    //        break;

        //    //    case CrudOperationType.Create:
        //    //    case CrudOperationType.Update:
        //    //        newModel = model;
        //    //        oldModel = model.CrudOperationType == CrudOperationType.Create ? Activator.CreateInstance(typeof(T)) : model;
        //    //        if (model.CrudOperationType == CrudOperationType.Update)
        //    //        {
        //    //            ignoreFieldslist.Add("ModifiedDate");
        //    //            ignoreFieldslist.Add("CreatedDate");
        //    //        }
        //    //        break;
        //    //}
        //    var auditLogItems = H1ServiceConfigurationSettingModel.AuditLoggingModel.GetItemDifferencesForAudit(oldModel, newModel, ignoreFieldslist.ToArray());
        //    if (auditLogItems.Count > 0)
        //    {
        //        await Logging.ProcessAudits(CompressToBytes(auditLogItems));
        //    }
        //}

        /// <summary>
        /// Creates, updates or deletes a model from the database based on the models <see cref="CrudOperationType"/>
        /// </summary>
        /// <param name="model">The model to be processed</param>
        /// <returns></returns>
        //protected async Task SyncItemToDatabase(T model)
        //{
        //    switch (model.CrudOperationType)
        //    {
        //        case CrudOperationType.Create:
        //            await DatabaseSyncEntityFramework.CreateEntity(model);
        //            break;
        //        case CrudOperationType.Update:
        //            await DatabaseSyncEntityFramework.UpdateEntity(model);
        //            break;
        //        case CrudOperationType.Delete:
        //            await DatabaseSyncEntityFramework.DeleteEntity(model);
        //            break;
        //        default:
        //            break;
        //    }
        //}

        #endregion

        #region Recovery

        public async Task<string> GetAllDatabaseEntries()
        {
            return Compress(await DatabaseSyncEntityFramework.GetAllEntities());
        }

        public async Task RecoveryProcessOperations(string objData)
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
                var databaseItems = await DatabaseSyncEntityFramework.GetAllEntities();
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

        protected List<T> FilterItemList(IEnumerable<FilterCollectionModel> filterList, List<T> itemList)
        {
            var results = new List<T>();
            foreach (var filter in filterList)
            {
                var filterCollection = filter.InternalFilterCollection;
                if (filter.IsAnd)
                {
                    var resultList = !results.Any() ? itemList : results;
                    var filteredItems = FilterInternalItemList(filterCollection, resultList);
                    results = filteredItems.ToList();
                }
                else
                {
                    var filteredItems = FilterInternalItemList(filterCollection, itemList);
                    results.AddRange(filteredItems.Where(x => !x.Equals(results.Any())));
                }
            }
            return results;
        }

        protected IEnumerable<T> FilterInternalItemList(IEnumerable<InternalFilterModel> internalFilterList, List<T> itemList)
        {
            LogTextOutput($"FilterInternalItemList:: itemList Count: {itemList.Count}");
            var resultList = new List<T>();
            foreach (var item in internalFilterList)
            {
                LogTextOutput($"FilterInternalItemList:: Starting internal filter :: Filter Property: {item.FilterProperty}:: Filter Value: {item.FilterValue}:: Current Results {resultList.Count}");

                if (item.IsAnd)
                {
                    resultList = !resultList.Any() ? itemList : resultList;
                    resultList =
                        resultList.Where(m => m.GetType().GetProperty(item.FilterProperty)?.GetValue(m).ToString().ToLower() == item.FilterValue.ToLower())
                            .ToList();
                }
                else
                {
                    resultList.AddRange(
                        itemList.Where(m => m.GetType().GetProperty(item.FilterProperty)?.GetValue(m).ToString().ToLower() == item.FilterValue.ToLower()
                                            && !resultList.Contains(m))
                            .ToList());
                }

                LogTextOutput($"FilterInternalItemList:: Ended internal filter:: Current Results {resultList.Count}");

            }
            return resultList;
        }
        #endregion

        #region Notifications

        public override async Task ReceiveMessageAsync(MessageWrapper message)
        {
            if (message.Channel.StartsWith("H1 Service Configuration Setting"))
            {
                await ForceRefreshServiceConfiguration();
            }
            else
            {
                await NotificationReceived(message);
            }
        }

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

        protected virtual async Task CreateSubscriptionChannels()
        {
            var succeeded = false;
            while (!succeeded)
            {
                try
                {
                    await Notifications.ProcessChannels(CompressToBytes(NotificationModelConverter<T>.CreatesCrudChannels(Context)));
                    succeeded = true;
                }
                catch (Exception)
                {
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
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

        public virtual async Task<string> WhereAsync(Func<KeyValuePair<Guid, T>, bool> filter)
        {
            List<T> itemList = new List<T>();
            var tasks = new List<Task>();
            //await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            //{
            foreach (var key in _keysIndex16Bit)
            {
                tasks.Add(Task.Run(async () =>
                {
                    using (var tx = StateManager.CreateTransaction())
                    {
                        var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                        var items = await dictionary.CreateEnumerableAsync(tx);
                        lock (itemList)
                            itemList.AddRange(items.Where(filter).Select(it => it.Value).ToListAsync(tx).Result.ToList());
                    }
                }));
            }
            await Task.WhenAll(tasks);
            return Compress(itemList);
        }
        public virtual async Task<string> WhereByDictionaryKeyAsync(string key, Func<KeyValuePair<Guid, T>, bool> filter)
        {
            List<T> itemList = new List<T>();
            using (var tx = StateManager.CreateTransaction())
            {
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                var items = await dictionary.CreateEnumerableAsync(tx);
                itemList.AddRange(items.Where(filter).Select(it => it.Value).ToListAsync(tx).Result.ToList());
            }
            return Compress(itemList);
        }
        public virtual async Task<string> SelectAsync<R>(Func<KeyValuePair<Guid, T>, R> fields)
        {
            List<R> itemList = new List<R>();
            var tasks = new List<Task>();
            //await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            //{
            foreach (var key in _keysIndex16Bit)
            {
                tasks.Add(Task.Run(async () =>
                {

                    using (var tx = StateManager.CreateTransaction())
                    {
                        var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                        var items = await dictionary.CreateEnumerableAsync(tx);
                        lock (itemList)
                            itemList.AddRange(items.Select(fields).ToListAsync(tx).Result.ToList());
                    }
                }));
            }
            await Task.WhenAll(tasks);
            return Compress(itemList);
        }
        public virtual async Task<string> SelectByDictionaryKeyAsync<R>(string key, Func<KeyValuePair<Guid, T>, R> fields)
        {
            List<R> itemList = new List<R>();
            using (var tx = StateManager.CreateTransaction())
            {
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                var items = await dictionary.CreateEnumerableAsync(tx);
                itemList.AddRange(items.Select(fields).ToListAsync(tx).Result.ToList());
            }
            return Compress(itemList);
        }
        public virtual async Task<string> TakeAsync(int take)
        {
            List<T> itemList = new List<T>();
            var tasks = new List<Task>();
            //await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            //{
            foreach (var key in _keysIndex16Bit)
            {
                tasks.Add(Task.Run(async () =>
                {
                    using (var tx = StateManager.CreateTransaction())
                    {
                        var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                        var items = await dictionary.CreateEnumerableAsync(tx);
                        lock (itemList)
                            itemList.AddRange(items.Select(it => it.Value).ToListAsync(tx).Result.ToList());
                    }
                }));
            }
            await Task.WhenAll(tasks);
            return Compress(itemList.OrderBy(it => it.Id).Take(take));
        }
        public virtual async Task<string> TakeByDictionayKeyAsync(string key, int take)
        {
            List<T> itemList = new List<T>();
            using (var tx = StateManager.CreateTransaction())
            {
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                var items = await dictionary.CreateEnumerableAsync(tx);
                itemList.AddRange(items.Select(it => it.Value).ToListAsync(tx).Result.ToList());
            }
            return Compress(itemList.OrderBy(it => it.Id).Take(take));
        }
        public virtual async Task<bool> AnyAsync()
        {
            List<bool> itemList = new List<bool>();
            var tasks = new List<Task>();
            //await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            //{
            foreach (var key in _keysIndex16Bit)
            {
                tasks.Add(Task.Run(async () =>
                {
                    using (var tx = StateManager.CreateTransaction())
                    {
                        var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                        var items = await dictionary.CreateEnumerableAsync(tx);
                        itemList.Add(items.AnyAsync().Result);
                    }
                }));
            }
            await Task.WhenAll(tasks);
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
            var tasks = new List<Task>();
            //await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            //{
            foreach (var key in _keysIndex16Bit)
            {
                tasks.Add(Task.Run(async () =>
                {
                    using (var tx = StateManager.CreateTransaction())
                    {
                        var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                        var items = await dictionary.CreateEnumerableAsync(tx);
                        itemList.Add(items.AnyAsync(condition).Result);
                    }
                }));
            }
            await Task.WhenAll(tasks);
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
            var tasks = new List<Task>();
            //await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            //{
            foreach (var key in _keysIndex16Bit)
            {
                tasks.Add(Task.Run(async () =>
                {
                    using (var tx = StateManager.CreateTransaction())
                    {
                        var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                        var items = await dictionary.CreateEnumerableAsync(tx);
                        itemList.Add(items.AllAsync(condition).Result);
                    }
                }));
            }
            await Task.WhenAll(tasks);
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
        public virtual async Task<string> FirstAsync()
        {
            List<T> itemList = new List<T>();
            var tasks = new List<Task>();
            //await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            //{
            foreach (var key in _keysIndex16Bit)
            {
                tasks.Add(Task.Run(async () =>
                {
                    using (var tx = StateManager.CreateTransaction())
                    {
                        var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                        var items = await dictionary.CreateEnumerableAsync(tx);
                        itemList.Add(items.FirstAsync().Result.Value);
                    }
                }));
            }
            await Task.WhenAll(tasks);
            return Compress(itemList.First());
        }
        public virtual async Task<string> FirstByDictionaryKeyAsync(string key)
        {
            List<T> itemList = new List<T>();
            using (var tx = StateManager.CreateTransaction())
            {
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                var items = await dictionary.CreateEnumerableAsync(tx);
                itemList.Add(items.FirstAsync().Result.Value);
            }
            return Compress(itemList.First());
        }
        public virtual async Task<string> FirstOrDefaultAsync(Func<KeyValuePair<Guid, T>, bool> condition)
        {
            List<T> itemList = new List<T>();
            var tasks = new List<Task>();
            //await Task.Run(() => Parallel.ForEach(_keysIndex16Bit, async key =>
            //{
            foreach (var key in _keysIndex16Bit)
            {
                tasks.Add(Task.Run(async () =>
                {
                    using (var tx = StateManager.CreateTransaction())
                    {
                        var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                        var items = await dictionary.CreateEnumerableAsync(tx);
                        itemList.Add(items.FirstOrDefaultAsync(condition).Result.Value);
                    }
                }));
            }
            await Task.WhenAll(tasks);
            return Compress(itemList.FirstOrDefault());
        }
        public virtual async Task<string> FirstOrDefaultByDictionaryKeyAsync(string key, Func<KeyValuePair<Guid, T>, bool> condition)
        {
            List<T> itemList = new List<T>();
            using (var tx = StateManager.CreateTransaction())
            {
                var dictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, T>>($"{_cacheName}_{key}");
                var items = await dictionary.CreateEnumerableAsync(tx);
                itemList.Add(items.FirstOrDefaultAsync(condition).Result.Value);
            }
            return Compress(itemList.FirstOrDefault());
        }
        #endregion
    }

    public abstract class StatefulServiceBase : StatefulService, ISubscriberService
    {
        #region Properties

        #region Remoting Interfaces

        /// <summary>
        /// The proxy to the Utility service. This is created upon initialization
        /// </summary>
        private IUtilities _utilityProxy;
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

        /// <summary>
        /// The proxy to the ErrorLogging service. This is created upon initialization
        /// </summary>
        private ILogging _logging;
        protected ILogging Logging
        {
            get
            {
                try
                {
                    return _logging ?? (_logging =
                               ServiceProxyFactory.CreateServiceProxy<ILogging>(UtilityProxy.InitializeLogging().Result));
                }
                catch (Exception e)
                {
                    LogTextOutput($"Remoting proxy could not be created: {e.Message}");
                    LogHealthState(nameof(Logging), $"Remoting proxy could not be created: {e.Message}", HealthState.Warning, TimeSpan.FromMinutes(1), true).Wait();
                    return null;
                }
            }
        }

        private V2ProxyCollection<IServiceConfiguration> _serviceConfiguration;
        protected V2ProxyCollection<IServiceConfiguration> ServiceConfiguration
        {
            get
            {
                try
                {
                    return _serviceConfiguration ?? (_serviceConfiguration = new V2ProxyCollection<IServiceConfiguration>(UtilityProxy.InitializeServiceConfiguration().Result, ServiceProxyFactory));
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
        protected PublisherServiceHelper PublisherServiceHelper
        {
            set
            {
                LogHealthState(nameof(PublisherServiceHelper), $"{nameof(PublisherServiceHelper)} is attempting to be set. Interfaces are created when called through Get. " +
                    $"Please remove instances of '{nameof(PublisherServiceHelper)} = ...' from your service.",
                    HealthState.Warning, TimeSpan.FromMinutes(1), true).Wait();
            }
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
            set
            {
                LogHealthState(nameof(SubscriberServiceHelper), $"{nameof(SubscriberServiceHelper)} is attempting to be set. Interfaces are created when called through Get. " +
                  $"Please remove instances of '{nameof(SubscriberServiceHelper)} = ...' from your service.",
                  HealthState.Warning, TimeSpan.FromMinutes(1), true).Wait();
            }
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

        #region Proxy Factories

        protected IServiceProxyFactory ServiceProxyFactory { get; }
        protected IActorProxyFactory ActorProxyFactory { get; }

        #endregion

        protected string ServiceName => Context.ServiceName.Segments[Context.ServiceName.Segments.Count() - 1];
        private bool SettingsUpToDate { get; set; }
        protected bool UseH1ConfigurationSettings { get; } = false;

        #endregion

        #region ctors

        protected StatefulServiceBase(StatefulServiceContext context) : this(context, new ReliableStateManager(context))
        { }

        protected StatefulServiceBase(StatefulServiceContext context, IReliableStateManagerReplica2 stateManagerReplica,
            IServiceProxyFactory serviceProxyFactory = null, IActorProxyFactory actorProxyFactory = null) : base(context, stateManagerReplica)
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

        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            try
            {
                var tasks = new Task[2];
                // if (!UseH1ConfigurationSettings) { tasks[0] = Task.Run(() => RetrieveServiceSettings(cancellationToken)); } //[18-Dec-2019] : Code Commented for obsolete tasks by Nitin
                tasks[0] = Task.Run(() => InitializeRetryWrapper(cancellationToken));
                // tasks[1] = Task.Run(() => RegisterSettingsChannel(cancellationToken)); //[18-Dec-2019] : Code Commented for obsolete tasks by Nitin
                //tasks[2] = Task.Run(() => Queues(cancellationToken));
                tasks[1] = BaseRunAsync(cancellationToken);
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

        protected virtual Task BaseRunAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        protected virtual Task Initialize()
        {
            return Task.FromResult(0);
        }

        private async Task InitializeRetryWrapper(CancellationToken ct)
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
                    HealthState.Ok, TimeSpan.FromMinutes(1), true);
                }
                catch (Exception e)
                {
                    await LogHealthState("InitializeRetryWrapper", $"Initialize failed to complete due to the following reasons: {e.Message}",
                        HealthState.Warning, TimeSpan.FromMinutes(1), true);
                    await Task.Delay(TimeSpan.FromMinutes(1), ct);
                }
            }
        }

        //[18-Dec-2019] : Code Commented for obsolete tasks by Nitin
        //protected async Task RegisterSettingsChannel(CancellationToken ct)
        //{
        //    bool connected = false;
        //    while (!ct.IsCancellationRequested && !connected)
        //    {
        //        try
        //        {
        //            await SubscriberServiceHelper.RegisterMessageChannelAsync(this, $"SettingsUpdate: {ServiceName}");
        //            connected = true;
        //            ServiceEventSource.Current.ServiceMessage(Context, $"{ServiceName} successfully created service channel");
        //        }
        //        catch (Exception e)
        //        {
        //            await LogHealthState("RegisterSettingsChannel", "The service setting refresh channel could not be created as the service could not connect to the BrokerActor or " +
        //                "Subscription service.",
        //                HealthState.Warning, TimeSpan.FromMinutes(1), true);
        //            await Task.Delay(TimeSpan.FromMinutes(1), ct);
        //        }
        //    }
        //}

        protected virtual Task Queues(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        #endregion

        #region H1ServiceSettings Methods

        // [18-Dec-2019] : Code Commented for obsolete tasks by Nitin
        //protected async Task RetrieveServiceSettings(CancellationToken ct)
        //{
        //    var settingsUpToDate = false;
        //    while (!ct.IsCancellationRequested && !settingsUpToDate)
        //    {
        //        try
        //        {
        //            var defaultSettings = DefaultSettings();
        //            var resultSettings = await ServiceConfiguration.MergeResultsOfActionAsBytes<ServiceConfig>(proxy => proxy.UpdateSettings(ServiceName, JsonConvert.SerializeObject(defaultSettings).Compress()));
        //            await UpdateSettings(resultSettings);

        //            settingsUpToDate = true;
        //        }
        //        catch (Exception e)
        //        {
        //            await LogHealthState("ForceRefreshServiceConfiguration", "Service settings could not be applied as the service could not connect to the H1ServiceSettings Service",
        //                HealthState.Warning, TimeSpan.FromMinutes(1), true);
        //            await Task.Delay(TimeSpan.FromMinutes(1), ct);
        //        }
        //    }
        //}

        #region Default Settings

        protected byte[] CompressedDefaultSettings()
        {
            return Compressor.Compress(JsonConvert.SerializeObject(DefaultSettings()));
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
            Type serviceType = GetType();

            if (!string.IsNullOrEmpty(setting.ValueParameterName))
            {
                var property = serviceType.GetProperty(setting.ValueParameterName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (property != null)
                {
                    if (setting.ValueType == ConfigType.Numbers)
                    {
                        int intValue = 0;
                        if (!int.TryParse(setting.Value, out intValue))
                        {
                            await LogHealthState(nameof(UpdateSetting), $"{setting.ValueParameterName} could not be set as {setting.Value} is not of type int", HealthState.Warning);
                        }

                        property.SetValue(this, intValue);
                    }
                    else
                    {
                        property.SetValue(this, setting.Value);
                    }
                }
            }

            if (!string.IsNullOrEmpty(setting.IsEnabledParameterName))
            {
                var property = serviceType.GetProperty(setting.IsEnabledParameterName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (property != null)
                    property.SetValue(this, setting.IsEnabled);
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

        #region Notifications

        public async virtual Task ReceiveMessageAsync(MessageWrapper message)
        {
            await NotificationReceived(message);
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
                await Logging.ProcessErrors(CompressToBytes(ExceptionMethods.LogException(exception, new Guid())));
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

        #region Base64 String Compression

        protected string Compress(object obj)
        {
            return JsonConvert.SerializeObject(obj).CompressBase64();
        }

        protected T Decompress<T>(string objData)
        {
            return JsonConvert.DeserializeObject<T>(objData.DecompressBase64());
        }

        #endregion

        #region GZip Byte[] Compression Methods

        protected byte[] CompressToBytes(object obj)
        {
            return JsonConvert.SerializeObject(obj).Compress();
        }

        protected T DecompressToBytes<T>(byte[] objData)
        {
            return JsonConvert.DeserializeObject<T>(objData.Decompress());
        }

        protected List<T> DecompressByteMulti<T>(byte[][] objData)
        {
            var results = new List<T>();
            if (objData == null) return results;

            foreach (var byteArray in objData)
            {
                var models = DecompressToBytes<IEnumerable<T>>(byteArray);
                if (models != null)
                    results.AddRange(models);
            }

            return results;
        }

        protected List<T> DecompressByteSingle<T>(byte[][] objData)
        {
            return objData?.Select(DecompressToBytes<T>).ToList();
        }

        #endregion
        #endregion
    }
}
