using System.Threading.Tasks;
using Common.Core.Contracts.Models.Base;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Notifications
{
    public interface ISubscription : IService
    {
        Task ProcessOperation(string serviceName, CrudOperationType crudOperationType);
    }
}
