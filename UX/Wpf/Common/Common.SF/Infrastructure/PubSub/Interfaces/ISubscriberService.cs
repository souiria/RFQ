using System.ServiceModel;
using System.Threading.Tasks;
using Common.SF.Infrastructure.PubSub.Wrappers;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Infrastructure.PubSub.Interfaces
{
    /// <summary>
    /// Defines a common interface for all Subscriber Services. 
    /// </summary>
    [ServiceContract]
    public interface ISubscriberService : IService
    {
        /// <summary>
        /// Receives a published message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [OperationContract(IsOneWay = true)]
        Task ReceiveMessageAsync(MessageWrapper message);
    }
}
