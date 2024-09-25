using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Contracts.Models.Purchasing;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IETLMaterialOrigin : IService
    {
        //Task<IEnumerable<ETLMaterialOriginGridModel>> GetGridData();
        Task<string> GetGridDataByFilter(MaterialOriginSearchModel materialOriginSearchModel);
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);

    }
}
