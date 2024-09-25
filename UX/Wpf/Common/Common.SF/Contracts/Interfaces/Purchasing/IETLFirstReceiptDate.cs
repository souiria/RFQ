using Microsoft.ServiceFabric.Services.Remoting;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Purchasing;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
  public  interface IETLFirstReceiptDate : IService
    {
        //Task<string> GetGridData();
        Task<string> GetGridDataWithFilter(FirstReceiptDateSearchModel model);
    }
}
