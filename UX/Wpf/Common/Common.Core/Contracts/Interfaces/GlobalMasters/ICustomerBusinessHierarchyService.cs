using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.SF.Contracts.Interfaces.Base;
using Common.SF.Contracts.Interfaces.Base.Base64;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface ICustomerBusinessHierarchyService : IBase, IBase64Custom
    {
        Task<string> Get(Guid id);
        Task<string> GetAll();
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);
        Task<string> ProcessOperation(string objData);
        Task DatabaseRecovery(bool mergeData);
        Task<string> GetAllFlattenDataByDictionaryByModel(string key, string modelName);
        Task<string> GetAllCustomerBusinessGroupCodeList();
        Task<string> GetAllCustomerNameList();



    }
}
