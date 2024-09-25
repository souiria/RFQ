using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Purchasing;
using Common.SF.Contracts.Interfaces.Base;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IPurchasingArticleSynchronization : IBase
    {
        Task<string> Get(Guid id);
        Task<string> GetAll();
        Task<PurchasingArticleSynchronizationModel> GetUncompressed(Guid id);
    }
}
