using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.SF.Contracts.Interfaces.Base;

namespace Common.SF.Contracts.Interfaces.GlobalMasters
{
    public interface IFacility : IBase
    {
        //Task<FacilityModel> Get(Guid id);
        Task<string> GetAll();
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filter);
        Task<string> ProcessOperation(string objData);
        Task DatabaseRecovery(bool mergeData);
    }
}
