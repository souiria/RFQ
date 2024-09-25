using Common.Core.Contracts.Models.ETL.CPD;
using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.ETL
{
    [ServiceContract]
    public interface ICpd : IService
    {
        [OperationContract]
        Task<CpdDatabaseModel> GetAll();
        [OperationContract]
        Task<IEnumerable<InterfaceWHCPDMastersMaterialSupplierModel>> GetSupplierList();
        [OperationContract]
        Task<IEnumerable<InterfaceWHCPDMastersMaterialOriginModel>> GetMaterialList();
    }
}
