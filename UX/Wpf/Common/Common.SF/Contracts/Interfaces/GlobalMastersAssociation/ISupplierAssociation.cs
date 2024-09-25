using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Contracts.Models.GlobalMastersAssociation;
using Common.SF.Contracts.Interfaces.Base;

namespace Common.SF.Contracts.Interfaces.GlobalMastersAssociation
{
    public interface ISupplierAssociation : IBase
    {
        Task<string> GetAll();
        Task<string> Get(Guid id);
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filter);
        Task<string> ProcessOperation(string objData);
        Task<string> GetGridRefreshData();
        Task<string> GetGridDataByFilter(SupplierAssociationSearchModel supplierAssociationSearchModel);
    }
}
