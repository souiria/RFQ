using Common.Core.Contracts.Models.ETL.EMACS;
using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.ETL.Emacs
{
    public interface IEmacsCustomerData : IService
    {
        Task<string> GetAll();
        Task<string> GetCustomerByCustomerCode(string customerCode);
        Task Create(List<CustomerDataModel> modelList);
    }
}
