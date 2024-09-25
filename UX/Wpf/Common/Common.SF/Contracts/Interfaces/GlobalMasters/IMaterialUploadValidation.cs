using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.GlobalMasters
{
    public interface IMaterialUploadValidation : IService
    {
        // Task<IEnumerable<MaterialUploadModel>> ValidateMaterialUploadData(IEnumerable<MaterialUploadModel> modelList);
        Task<string> ValidateMaterialUploadData(string objData);      
    }
}
