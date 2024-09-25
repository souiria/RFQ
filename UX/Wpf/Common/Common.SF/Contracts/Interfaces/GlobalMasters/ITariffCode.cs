using System;
using System.Threading.Tasks;
using Common.SF.Contracts.Interfaces.Base;

namespace Common.SF.Contracts.Interfaces.GlobalMasters
{
    public interface ITariffCode : IBase
    {
        Task<string> Get(Guid id);
        Task<string> GetAll();
    }
}
