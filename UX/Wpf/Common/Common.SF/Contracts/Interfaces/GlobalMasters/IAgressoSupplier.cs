using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Contracts.Models.GlobalMasters;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.GlobalMasters
{
    public interface IAgressoSupplier : IService
    {
        Task<IEnumerable<AgressoSupplierModel>> Create(IEnumerable<AgressoSupplierModel> modelList);
        Task<AgressoSupplierModel> Get(Guid id);
        Task<string> GetAll();
        Task<IEnumerable<AgressoSupplierModel>> GetByFilter(List<FilterCollectionModel> filterList);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteByFilter(List<FilterCollectionModel> filterList);
        Task<AgressoSupplierModel> Save(AgressoSupplierModel model);
    }
}
