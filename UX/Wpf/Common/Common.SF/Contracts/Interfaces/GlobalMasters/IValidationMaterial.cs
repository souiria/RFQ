using Microsoft.ServiceFabric.Services.Remoting;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Settings;
using Common.Core.Contracts.Models.GlobalMasters;

namespace Common.SF.Contracts.Interfaces.GlobalMasters
{
    public interface IValidationMaterial : IService
    {
        Task<string> ValidateMaterial(MaterialModel materialModel, ServiceValidationModel serviceValidationModel);
    }
}
