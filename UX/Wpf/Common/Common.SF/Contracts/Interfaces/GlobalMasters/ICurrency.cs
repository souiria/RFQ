using System;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.GlobalMasters;
using Common.SF.Contracts.Interfaces.Base;

namespace Common.SF.Contracts.Interfaces.GlobalMasters
{
    public interface ICurrency : IBase
    {
        Task<string> Get(Guid id);
        Task<string> GetAll();
        Task<CurrencyModel> GetUncompressed(Guid id);
    }
}
