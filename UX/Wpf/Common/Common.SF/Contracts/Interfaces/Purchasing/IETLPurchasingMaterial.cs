using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Contracts.Models.GlobalMastersAssociation;
using Common.Core.Contracts.Models.Purchasing;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IETLPurchasingMaterial : IService
    {
        Task<IEnumerable<ETLPurchasingMaterialGridModel>> GetGridData();
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);
        Task<string> GetGridDataByFilter(MaterialAssociationSearchModel materialAssociationSearchModel);
    }
}
