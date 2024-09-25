using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Security
{
    public interface IMenuGenerator : IService
    {
        Task<byte[]> GetAll();
        Task<byte[]> ProcessOperation(byte[] objData);
        
        Task<IEnumerable<FunctionSecurityModel>> GetMenu(Guid id);
        Task<IEnumerable<string>> RetrieveActiveDirectoryGroups(Guid userGuid);
    }
}
