using System;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.GlobalMasters;
using Common.SF.Contracts.Interfaces.Base;

namespace Common.SF.Contracts.Interfaces.GlobalMasters
{
    public interface IMaterialType : IBase
    {
        Task<string> Get(Guid id);
        Task<string> GetAll();
        Task<MaterialTypeModel> GetUncompressed(Guid id);
    }
}
