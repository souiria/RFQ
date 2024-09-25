using Common.Core.Contracts.Models.ETL.EMACS;
using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.ETL.Emacs
{
    public interface IEmacsPart : IService
    {
        Task<string> GetAll();
        Task<IEnumerable<PARTMSModel>> GetResultsByPartNumber(string partNumber);
        Task<IEnumerable<PARTMSModel>> GetResultsBySumitomoNumber(string sumitomoNumber);
        Task Create(List<PARTMSModel> modelList);
    }
}
