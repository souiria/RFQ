using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IETLConsolidatedMRPErrorList : IService
    {
        Task<string> GetGridData(string paramModel);
        //  Task<IEnumerable<ETLConsolidatedMRPErrorListGridModel>> GetGridData(IEnumerable<ConsolidatedMRPErrorParamModel> paramModel);      
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);
      //  Task<IEnumerable<ETLConsolidatedMRPErrorListGridModel>> GetDHSConsolidatedMRPErrorList(ConsolidatedMRPErrorParamModel paramModel);
      //  Task<IEnumerable<ETLConsolidatedMRPErrorListGridModel>> GetConsolidatedMRPErrorList(ConsolidatedMRPErrorParamModel ConsolidatedParamModel);
    }
}
