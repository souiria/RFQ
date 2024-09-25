using Common.Core.Contracts.Models.ETL.EMACS;
using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.ETL.Emacs
{
    public interface IEmacsCustomer : IService
    {
        Task<string> GetAll();
        Task<IEnumerable<BUBANMModel>> GetResultsByPartNumber(string partNumber);
        Task<IEnumerable<BUBANMModel>> GetResultsBySumitomoNumber(string sumitomoNumber);
        Task Create(List<BUBANMModel> modelList);
    }
}
