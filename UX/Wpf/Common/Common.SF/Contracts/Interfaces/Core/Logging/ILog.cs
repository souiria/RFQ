using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Logging;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Logging
{
    [ServiceContract]
    public interface ILog : IService
    {
        [OperationContract]
        Task ValidationMessage(IEnumerable<ErrorLogModel> errorLogModel);
        [OperationContract]
        Task Info(IEnumerable<ErrorLogModel> errorLogModel);
        [OperationContract]
        Task RuntimeException(IEnumerable<ErrorLogModel> errorLogModel);
    }
}
