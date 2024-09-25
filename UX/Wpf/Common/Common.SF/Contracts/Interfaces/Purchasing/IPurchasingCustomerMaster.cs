using System;
using System.Threading.Tasks;
using Common.SF.Contracts.Interfaces.Base;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
  public  interface IPurchasingCustomerMaster : IService
    {
        Task<string> GetCustomer(Guid id);
        Task<string> GetAllCustomers();
        Task<string> GetCustomerByFilter(string filter);
        Task ProcessCustomers(string objData);
    }
}
