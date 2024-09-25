using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Contracts.Models.GlobalMasters;
using Common.SF.Contracts.Interfaces.Base;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.GlobalMasters
{
    public interface IWireColour : IBase
    {
        Task<string> Get(Guid id);
        Task<string> GetAll();
        Task<WireColourModel> GetUncompressed(Guid id);
    }
}
