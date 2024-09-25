using System;
using System.Fabric.Health;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Common.Core.Infrastructure.Helpers;
using Common.SF.Contracts.Interfaces.Core;
using Common.SF.Contracts.Interfaces.Core.Logging;
using Common.SF.Contracts.Interfaces.Core.Notifications;
using Common.SF.Infrastructure.Helpers;
using Common.SF.Infrastructure.PubSub.Helpers;
using Common.SF.Infrastructure.PubSub.Interfaces;
using Common.SF.Infrastructure.PubSub.Models;
using Common.SF.Infrastructure.PubSub.Wrappers;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport;
using Microsoft.ServiceFabric.Services.Remoting.V1.FabricTransport.Client;
using Newtonsoft.Json;

namespace Common.SF.Infrastructure.Base.Commercial
{
    /// <summary>
    /// A base service class that can used to provide a base level of functionality to an actor service.
    /// </summary>
    public class ActorServiceBase : Actor, ISubscriberActor
    {
        #region Properties

        #region Remoting Proxies

        /// <summary>
        /// The proxy to the Utility service. This is created upon initialization
        /// </summary>
        private IUtilities utilityProxy;
        protected IUtilities UtilityProxy
        {
            get
            {
                try
                {
                    if (utilityProxy == null)
                        utilityProxy = ServiceProxyFactory.CreateServiceProxy<IUtilities>(new Uri("fabric:/Core.Framework/SF.Core.Utilities"));
                    return utilityProxy;
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
                    LogHealthState(nameof(Logging), $"Remoting proxy could not be created: {e.Message}", HealthState.Warning, TimeSpan.FromMinutes(1), true).Wait();
                    return null;
                }
            }
        }
        /// <summary>
        /// The proxy to the Subscriptions service. This is created if notification implementation has been set to true
        /// </summary>
        private INotifications _notifications;
        protected INotifications Notifications
        {
            get
            {
                try
                {
                    return _notifications ?? (_notifications = ServiceProxyFactory.CreateServiceProxy<INotifications>(UtilityProxy.InitializeNotifications().Result));
                }
                catch (Exception e)
                {
                    LogTextOutput($"Remoting proxy could not be created: {e.Message}");
                    LogHealthState(nameof(Logging), $"Remoting proxy could not be created: {e.Message}", HealthState.Warning, TimeSpan.FromMinutes(1), true).Wait();
                    return null;
                }
            }
        }

        #endregion

        #region PubSub Helpers

        private PublisherActorHelper _publisherActorHelper;
        protected PublisherActorHelper PublisherActorHelper
        {
            get
            {
                try
                {
                    if (_publisherActorHelper == null)
                        _publisherActorHelper = new PublisherActorHelper(new BrokerServiceLocator(ActorProxyFactory));
                    return _publisherActorHelper;
                }
                catch (Exception e)
                {
                    LogTextOutput($"Remoting proxy could not be created: {e.Message}");
                    LogHealthState(nameof(PublisherActorHelper), $"Remoting proxy could not be created: {e.Message}", HealthState.Warning, TimeSpan.FromMinutes(1), true).Wait();
                    return null;
                }
            }
        }

        private SubscriberActorHelper _subscriberActorHelper;
        protected SubscriberActorHelper SubscriberActorHelper
        {
            get
            {
                try
                {
                    if (_subscriberActorHelper == null)
                        _subscriberActorHelper = new SubscriberActorHelper(new BrokerServiceLocator(ActorProxyFactory));
                    return _subscriberActorHelper;
                }
                catch (Exception e)
                {
                    LogTextOutput($"Remoting proxy could not be created: {e.Message}");
                    LogHealthState(nameof(SubscriberActorHelper), $"Remoting proxy could not be created: {e.Message}", HealthState.Warning, TimeSpan.FromMinutes(1), true).Wait();
                    return null;
                }
            }
        }

        #endregion

        protected IServiceProxyFactory ServiceProxyFactory { get; }
        protected IActorProxyFactory ActorProxyFactory { get; }

        protected string ServiceName => ActorService.Context.ServiceName.Segments[ActorService.Context.ServiceName.Segments.Count() - 1];

        #endregion

        #region ctors

        public ActorServiceBase(ActorService actorService, ActorId actorId, IServiceProxyFactory serviceProxyFactory = null, IActorProxyFactory actorProxyFactory = null) : base(actorService, actorId)
        {
            var settings = new FabricTransportRemotingSettings
            {
                OperationTimeout = TimeSpan.FromMinutes(1),
                MaxMessageSize = int.MaxValue,
                UseWrappedMessage = true
            };
            ServiceProxyFactory = serviceProxyFactory ?? new ServiceProxyFactory((h) => new FabricTransportServiceRemotingClientFactory(settings));
            ActorProxyFactory = actorProxyFactory ?? new ActorProxyFactory();

        }

        #endregion

        #region Notifications

        public async Task ReceiveMessageAsync(MessageWrapper message)
        {
            await NotificationReceived(message);
        }

        /// <summary>
        /// Override this method in your service if you need to handle custom notifications
        /// </summary>
        /// <param name="message">The message object</param>
        /// <returns></returns>
        protected async virtual Task NotificationReceived(MessageWrapper message)
        {

        }

        #endregion

        #region Logging

        private async Task LogException(Exception exception)
        {
            try
            {
                await Logging.ProcessErrors(Compress(ExceptionMethods.LogException(exception, new Guid())));
            }
            catch (Exception e)
            {
                //Logging failed but should not stop application from running
                //TODO: Add ActorEventSource message for when Logger fails to log an exception                
            }
        }

        public async Task LogHealthState(string source, string property, HealthState healthState)
        {
            var healthInformation = new HealthInformation(source, property, healthState)
            {
                TimeToLive = TimeSpan.FromMinutes(1),
                RemoveWhenExpired = true
            };
            ActorService.Context.CodePackageActivationContext.ReportDeployedServicePackageHealth(healthInformation);
        }

        public async Task LogHealthState(string source, string property, HealthState healthState, TimeSpan timeToLive, bool removeWhenExpired = false)
        {
            var healthInformation = new HealthInformation(source, property, healthState)
            {
                TimeToLive = timeToLive,
                RemoveWhenExpired = removeWhenExpired
            };
            ActorService.Context.CodePackageActivationContext.ReportDeployedServicePackageHealth(healthInformation);
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
            return JsonConvert.DeserializeObject<T>(objData.Decompress());
        }

        protected string CompressToBase64(object obj)
        {
            return JsonConvert.SerializeObject(obj).CompressBase64();
        }
        protected T DecompressToBase64<T>(string objData)
        {
            return JsonConvert.DeserializeObject<T>(objData.DecompressBase64());
        }


        #endregion
    }
}
