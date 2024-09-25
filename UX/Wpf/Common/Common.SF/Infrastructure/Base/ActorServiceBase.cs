using System;
using System.ServiceModel.Configuration;
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
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Newtonsoft.Json;

namespace Common.SF.Infrastructure.Base
{
    /// <summary>
    /// A base service class that can used to provide a base level of functionality to an actor service.
    /// </summary>
    public abstract class ActorServiceBase : Actor, ISubscriberActor
    {
        #region Properties

        private IServiceProxyFactory ServiceProxyFactory { get; }
        private IActorProxyFactory ActorProxyFactory { get; }

        /// <summary>
        /// The proxy to the Utility service. This is created upon initialization
        /// </summary>
        protected IUtilities UtilityProxy { get; private set; }
        /// <summary>
        /// The proxy to the ErrorLogging service. This is created upon initialization
        /// </summary>
        protected ILogging Logging { get; private set; }
        /// <summary>
        /// The proxy to the Subscriptions service. This is created if notification implementation has been set to true
        /// </summary>
        protected ISubscriptions Subscriptions { get; private set; }
        /// <summary>
        /// A helper to publish notifications to the PubSub service.
        /// </summary>
        protected PublisherActorHelper PublisherActorHelper { get; }
        /// <summary>
        /// A helper class subscribe to notifications from the PubSub service.
        /// </summary>
        protected SubscriberActorHelper SubscriberActorHelper { get; }



        #endregion

        #region ctors

        /// <summary>
        /// Initializes a new instance of the actor class and initializes the PubSub helper classes.
        /// </summary>
        /// <param name="actorService">The <see cref="ActorService"/> that will host this actor instance.</param>
        /// <param name="actorId">The <see cref="ActorId"/> for this actor instance.</param>
        protected ActorServiceBase(ActorService actorService, ActorId actorId, IServiceProxyFactory serviceProxyFactory = null, IActorProxyFactory actorProxyFactory = null) : base(actorService, actorId)
        {
            ServiceProxyFactory = serviceProxyFactory ?? new ServiceProxyFactory();
            ActorProxyFactory = actorProxyFactory ?? new ActorProxyFactory();

            PublisherActorHelper = new PublisherActorHelper(new BrokerServiceLocator(ActorProxyFactory));
            SubscriberActorHelper = new SubscriberActorHelper(new BrokerServiceLocator(ActorProxyFactory));
        }

        #endregion

        #region Setup

        /// <inheritdoc />
        protected override async Task OnActivateAsync()
        {
            try
            {
                await base.OnActivateAsync();
                UtilityProxy = ServiceProxyFactory.CreateServiceProxy<IUtilities>(new Uri("fabric:/Core.Framework/SF.Core.Utilities"));
                Logging = ServiceProxyFactory.CreateServiceProxy<ILogging>(await UtilityProxy.InitializeLogging());
                Subscriptions = ServiceProxyFactory.CreateServiceProxy<ISubscriptions>(await UtilityProxy.InitializeNotifications(), new ServicePartitionKey(0));
            }
            catch (Exception e)
            {
                await Logging.ProcessErrors(CompressToBytes(ExceptionMethods.LogException(e, new Guid())));
                throw;
            }
        }

        #endregion

        #region Notifications

        /// <inheritdoc />
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
            await Logging.ProcessErrors(CompressToBytes(ExceptionMethods.LogException(exception, new Guid())));
        }

        #endregion

        #region Compression
        /// <summary>
        /// Serializes and compresses an object into a Base64 <see cref="string"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to be compressed.</param>
        /// <returns>A Base64 <see cref="string"/> that represent your object.</returns>
        protected string Compress(object obj)
        {
            return JsonConvert.SerializeObject(obj).CompressBase64();
        }

        /// <summary>
        /// Decompresses and deserializes an object from a Base64 <see cref="string"/> to the provided type.
        /// </summary>
        /// <typeparam name="T">The type to serialize the compressed data to.</typeparam>
        /// <param name="objData">The Base64 <see cref="string"/> that represent your object.</param>
        /// <returns></returns>
        protected T Decompress<T>(string objData)
        {
            return JsonConvert.DeserializeObject<T>(objData.DecompressBase64());
        }

        protected byte[] CompressToBytes(object obj)
        {
            return JsonConvert.SerializeObject(obj).Compress();
        }
        protected T DecompressToBytes<T>(byte[] objData)
        {
            return JsonConvert.DeserializeObject<T>(objData.Decompress());
        }

        #endregion
    }
}
