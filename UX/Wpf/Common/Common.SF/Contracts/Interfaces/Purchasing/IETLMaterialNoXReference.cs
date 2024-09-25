using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IETLMaterialNoXReference : IService
    {
        //Task<string> GetGridData(ETLMaterialNoXReferenceGridModel model);
        Task<string> GetGridData(string model);
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);

    }
}
