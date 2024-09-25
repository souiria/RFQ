using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Notifications;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Notifications
{
    [ServiceContract]
    public interface INotification : IService
    {
        [OperationContract]
        Task SendAll(IEnumerable<Notification> notifications, string channel);
        [OperationContract]
        Task Send(Notification notification, string channel);
        [OperationContract]
        Task<string> GetRedisEndpoint();
    }
}
