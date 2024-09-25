using Common.Core.Contracts.Models.ETL.EMACS;
using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.ETL.Emacs
{
    public interface IEmacsSupplier : IService
    {
        Task<string> GetAll();
        Task<IEnumerable<EMACSDataNoConvModel>> GetResultsByPartNumber(string partNumber);
        Task<string> GetSupplierPartNumberBySumitomoNumber(string sumitomoNumber);
        Task Create(List<EMACSDataNoConvModel> modelList);
    }
}
