using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Logging
{
    public interface ILogging : IErrorLog, IAuditLog, INPRStageChangeLog, IService
    {
    }
}
