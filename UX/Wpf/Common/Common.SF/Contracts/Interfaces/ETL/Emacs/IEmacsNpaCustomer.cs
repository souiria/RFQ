using Common.Core.Contracts.Models.ETL.NPA;
using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.ETL.Emacs
{
    public interface IEmacsNpaCustomer : IService
    {
        Task<string> GetAll();
        Task Create(List<NPACustomerModel> modelList);
    }
}
