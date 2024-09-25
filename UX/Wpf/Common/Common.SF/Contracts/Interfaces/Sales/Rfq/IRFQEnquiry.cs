using Common.Core.Contracts.Models.Sales.Rfq;
using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Sales.Rfq
{
    public interface IRFQEnquiry : IService
    {
        Task<byte[]> ExecuteHarnessOneRFQPartSearchProcedure(byte[] objData);
        Task<byte[]> ExecuteRFQPartSearchProcedure(byte[] objData);
        Task<IEnumerable<RFQInformationProcedureModel>> ExecuteHarnessOneRFQInformationSearchProcedure(string sumitomoParts);
    }
}
