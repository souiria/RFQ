using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.SF.Contracts.Interfaces.Base;
using Common.SF.Contracts.Interfaces.Base.Base64;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface ISupplierSelection : IBase, IBase64Custom
    {
        //Task<SupplierSelectionModel> Get(Guid id);
        Task<string> GetAll();
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);
        Task<string> ProcessOperation(string objData);
        Task DatabaseRecovery(bool mergeData);
        Task<string> GetSupplierMaterialAssociationGroupedList(string key);

        Task<string> GetSupplierSelectionBySupplierMaterialAssociationGuid(List<Guid> smaGuidList, string Key);

    }
}
