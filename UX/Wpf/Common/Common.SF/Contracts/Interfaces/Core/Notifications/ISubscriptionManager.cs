using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Notifications;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Notifications
{
    public interface ISubscriptionManager : ISubscription, IService
    {
        Task<IEnumerable<SubscriptionChannel>> GetChannels();
        Task ProcessOperation(IEnumerable<SubscriptionChannel> modelList);
        
        //Task<byte[]> GetChannels();
        //Task ProcessOperation(string serviceName, CrudOperationType crudOperationType);
    }
}
