using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.SF.Contracts.Interfaces.Base;

namespace Common.SF.Contracts.Interfaces.GlobalMasters
{
   public interface IProcurementUnit : IBase
    {
        //Task<ProcurementUnitModel> Get(Guid id);
       Task<string> GetAll();
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);
        Task<string> ProcessOperation(string objData);
        Task DatabaseRecovery(bool mergeData);

    }
}
