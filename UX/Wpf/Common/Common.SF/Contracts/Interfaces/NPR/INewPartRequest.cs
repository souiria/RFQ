using Common.Core.Contracts.Models.Core.Filtering;
using Common.SF.Contracts.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.SF.Contracts
{
  public  interface INewPartRequest : IBase
    {
        Task<string> Get(Guid id);
        Task<string> GetAll();
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filter);
        Task<string> ProcessOperation(string objData);
        Task DatabaseRecovery(bool mergeData);
    }
}
