using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Contracts.Models.Purchasing;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IETLMaterialInventory : IService
    {
        //Task<string> GetGridData();
        Task<string> GetGridDataByFilter(MaterialInventorySearchModel materialInventorySearchModel);
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);
    }
}
