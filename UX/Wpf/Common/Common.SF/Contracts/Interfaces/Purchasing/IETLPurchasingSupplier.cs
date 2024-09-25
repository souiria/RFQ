using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Contracts.Models.Purchasing;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IETLPurchasingSupplier : IService
    {
        Task<string> GetGridData();
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);
      Task<string> GetGridDataByFilter(PurchasingSupplierSearchModel purchasingSupplierGridFilter);
    }
}
