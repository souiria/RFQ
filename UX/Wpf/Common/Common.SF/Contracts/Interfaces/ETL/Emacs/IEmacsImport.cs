using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.ETL.Emacs
{
    [ServiceContract]
    public interface IEmacsImport : IService
    {
        [OperationContract]
        Task<bool> ImportCustomerList();
        [OperationContract]
        Task<bool> ImportSupplierList();
        [OperationContract]
        Task<bool> ImportPartList();
        [OperationContract]
        Task<bool> ImportCustomerDataList();
        [OperationContract]
        Task<bool> ImportNpaCustomerList();
        [OperationContract]
        Task<bool> ImportNpaSupplierList();
    }
}
