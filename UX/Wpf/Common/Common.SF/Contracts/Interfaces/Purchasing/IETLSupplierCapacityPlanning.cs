using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IETLSupplierCapacityPlanning : IService
    {
       // Task<IEnumerable<ETLSupplierCapacityPlanningGridModel>> GetGridData(SupplierCapacityPlanningSearchModel supplierCapacityPlanningSearchModel);
        Task<string> GetGridData(string supplierCapacityPlanningSearchModel);
    }
}
