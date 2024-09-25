using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Notifications
{
    [ServiceContract]
    public interface IEmailQueue : IService
    {
        [OperationContract]
        Task<bool> SendEmailBasic(string recipient, string subject, string body, byte[] snapshot);
        [OperationContract]
        Task<bool> SendEmailTemplate(string distributionlist, string subject, string body, byte[] snapshot);
        [OperationContract]
        Task<bool> ResetQueueStatus(Guid MessageId);
        [OperationContract]
        Task<bool> RemoveMessageFromQueue(Guid MessageId);
    }
}
