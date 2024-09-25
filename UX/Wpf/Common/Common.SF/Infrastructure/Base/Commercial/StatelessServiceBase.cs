using System;
using System.Collections.Generic;
using System.Fabric;
using System.Fabric.Health;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Settings.Commercial;
using Common.Core.Infrastructure.Helpers;
using Common.SF.Contracts.Interfaces.Core;
using Common.SF.Contracts.Interfaces.Core.Logging;
using Common.SF.Contracts.Interfaces.Core.Notifications;
using Common.SF.Contracts.Interfaces.Core.Settings;
using Common.SF.Contracts.Models.Core.Proxy.Commercial;
using Common.SF.Infrastructure.Helpers;
using Common.SF.Infrastructure.PubSub.Helpers;
using Common.SF.Infrastructure.PubSub.Interfaces;
using Common.SF.Infrastructure.PubSub.Models;
using Common.SF.Infrastructure.PubSub.Wrappers;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.V1.FabricTransport.Client;
using Microsoft.ServiceFabric.Services.Runtime;
using Newtonsoft.Json;

namespace Common.SF.Infrastructure.Base.Commercial
{
    public abstract class StatelessServiceBase : StatelessService, ISubscriberService
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
                    return _logging ?? (_logging = ServiceProxyFactory.CreateServiceProxy<ILogging>(UtilityProxy.InitializeLogging().Result));
                }
                catch (Exception e)
                {
                    LogTextOutput($"Remoting proxy could not be created: {e.Message}");
                    LogHealthState(nameof(UtilityProxy), $"Remoting proxy could not be created: {e.Message}", HealthState.Warning, TimeSpan.FromMinutes(1), true).Wait();
                    return null;
                }
            }
        }

        private Proxy<IServiceConfiguration> _serviceConfiguration;
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

        private PublisherServiceHelper _publisherServiceHelper;
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

        #region Service Configurations

        private bool DiagnosticLoggingEnabled;
        private bool PerformanceLoggingEnabled;
        private bool UsageLoggingEnabled;

        #endregion

        protected IServiceProxyFactory ServiceProxyFactory { get; set; }
        protected IActorProxyFactory ActorProxyFactory { get; set; }


        protected string ServiceName => Context.ServiceName.Segments[Context.ServiceName.Segments.Count() - 1];

        #endregion

        #region ctors

        protected StatelessServiceBase(StatelessServiceContext context, IServiceProxyFactory serviceProxyFactory = null, IActorProxyFactory actorProxyFactory = null) : base(context)
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

        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            try
            {
                var tasks = new Task[4];
                tasks[0] = Task.Run(() => RetrieveServiceSettings(cancellationToken));
                tasks[1] = Task.Run(() => InitializeRetryWrapper(cancellationToken));
                tasks[2] = Task.Run(() => RegisterSettingsChannel(cancellationToken));
                tasks[3] = Task.Run(() => Queues(cancellationToken));
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
                    ServiceEventSource.Current.ServiceMessage(this, "Initialization completed successfully");
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

        protected virtual async Task RegisterSettingsChannel(CancellationToken ct)
        {
            bool connected = false;
            while (!ct.IsCancellationRequested && !connected)
            {
                try
                {
                    await SubscriberServiceHelper.RegisterMessageChannelAsync(this, $"SettingsUpdate: {ServiceName}");
                    connected = true;
                    ServiceEventSource.Current.ServiceMessage(this, $"{ServiceName} successfully created service channel");
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

        /// <summary>
        /// Used to initialize new queue within RunAsync
        /// </summary>
        /// <returns></returns>
        protected virtual Task Queues(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }


        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return this.CreateServiceRemotingInstanceListeners();
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
                    if (!(this is IServiceConfiguration))
                    {
                        var defaultSettings = DefaultSettings();
                        var resultData = await ServiceConfiguration.All(proxy => proxy.UpdateSettings(ServiceName, JsonConvert.SerializeObject(defaultSettings).Compress()));
                        await UpdateSettings(Decompress<ServiceConfig>(resultData));

                        settingsUpToDate = true;
                    }
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
                ServiceEventSource.Current.ServiceMessage(this, $"Failed to send exception to the Logging Service: {e.Message}");
            }
        }

        public async Task LogHealthState(string source, string property, HealthState healthState, TimeSpan? timeToLive = null, bool removeWhenExpired = false)
        {
            var healthInformation = new HealthInformation(source, property, healthState);
            if (timeToLive.HasValue)
                healthInformation.TimeToLive = timeToLive.Value;
            healthInformation.RemoveWhenExpired = removeWhenExpired;
            Partition.ReportInstanceHealth(healthInformation);
        }

        protected void LogTextOutput(string info)
        {
            Console.WriteLine($"{ DateTime.Now.ToString(CultureInfo.InvariantCulture)} ::  { info }");
        }

        #endregion

        #region Compression

        protected byte[] Compress(object obj)
        {
            return JsonConvert.SerializeObject(obj).Compress();
        }

        protected T Decompress<T>(byte[] objData)
        {
            if (objData != null)
                return JsonConvert.DeserializeObject<T>(objData.Decompress());
            return default(T);
        }

        protected string CompressToBase64(object obj)
        {
            return JsonConvert.SerializeObject(obj).CompressBase64();
        }

        protected T DecompressFromBase64<T>(string objData)
        {
            if (objData != null)
                return JsonConvert.DeserializeObject<T>(objData.DecompressBase64());
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
            return objData?.Select(Decompress<T>).ToList();
        }

        #endregion
    }
}
