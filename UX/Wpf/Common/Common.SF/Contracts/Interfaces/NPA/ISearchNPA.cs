using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.NPA
{
   public interface ISearchNPA : IService
    {
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);
        Task<byte[]> GetGridDataSearchNPA(byte[] paramModel);
    }
}
