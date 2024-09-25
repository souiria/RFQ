using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Purchasing;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface INPAToH1DataSynchronization : IService
    {
        Task<IEnumerable<string>> MaterialDataSynchronization(MaterialDataSynchronizationModel materialDataSynchronizationModel);
    }
}