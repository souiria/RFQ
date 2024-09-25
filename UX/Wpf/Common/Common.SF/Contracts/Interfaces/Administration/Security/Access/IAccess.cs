using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Administration.Security.Access
{
    public interface IAccess : IService, IModuleOwners, IHelpdeskCallQueue
    {
        Task CreateUserRequest(byte[] permissionRequest);
    }
}
