using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.SF.Contracts.Interfaces.Base;
using Common.SF.Contracts.Interfaces.Base.Base64;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IPurchasingSupplierMaterial : IBase, IBase64Custom
    {
		//Task<PurchasingSupplierMaterialModel> Get(Guid id);
       Task<string> GetAll();
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);
        Task<string> ProcessOperation(string objData);
        Task DatabaseRecovery(bool mergeData);

    }
}
