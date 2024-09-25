using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.GlobalMasters;
using Common.SF.Contracts.Interfaces.Base;
using Common.SF.Contracts.Interfaces.Base.Base64;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.GlobalMasters
{

    public interface IMaterial : IBase, IBase64Custom
    {
        Task<string> GetAll();
        Task<MaterialModel> GetUncompressed(Guid id);
        Task<string> GetByMaterialNumberRange(string materialNumberFrom, string materialNumberTo);
        Task<string> GetBaseMaterials(string materialNumberFrom, string materialNumberTo);
    }
}
