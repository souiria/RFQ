using Common.Core.Contracts.Models.ETL.EMACS;
using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.ETL.Emacs
{
    public interface IEmacsSearch : IService
    {
        Task<IEnumerable<SearchResultModel>> DirectPartSearch(string partNumber);
        Task<IEnumerable<SearchResultModel>> PartSearch(string partNumber);
    }
}
