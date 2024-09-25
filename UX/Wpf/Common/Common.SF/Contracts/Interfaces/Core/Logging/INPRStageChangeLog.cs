using System;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Logging;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Logging
{
    public interface INPRStageChangeLog : IService
    {
        Task ProcessNPRStageChangeLog(byte[] objData);
    }
}
