using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Contracts.Models.NPA.Engineering;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.NPA
{
   public interface ISearchDHSForParts : IService
    {
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);
        Task<string> GetGridDataSearchDHSForParts(SearchDHSForPartsFilterModel paramModel);
        Task<string> GetGridDataSearchDHSForPartsShowInventory(SearchDHSForPartsShowInventoryFilterModel paramModel);
    }
}
