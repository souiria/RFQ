using System;
using System.Threading.Tasks;
using Common.SF.Contracts.Interfaces.Base;

namespace Common.SF.Contracts.Interfaces.GlobalMastersAssociation
{
    public interface IProcurementUnitBusinessUnitAssociation : IBase
    {
        Task<string> Get(Guid id);
        Task<string> GetAll();
    }
}
