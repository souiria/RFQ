using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.GlobalMasters
{
    public interface ISupplierUploadValidations : IService
    {
        // Task<IEnumerable<SupplierUploadModel>> SupplierUploadValdationsData(IEnumerable<SupplierUploadModel> modelList);
        Task<string> SupplierUploadValdationsData(string objData);
    }
}
