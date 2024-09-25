using System;
using System.Threading.Tasks;
using Common.SF.Contracts.Interfaces.Base;
using Microsoft.ServiceFabric.Services.Remoting;
namespace Common.SF.Contracts.Interfaces.Purchasing
{
   public interface IPurchasingFacilityMaster : IService
    {
        Task<string> GetFacility(Guid id);
        Task<string> GetAllFacilities();
        Task<string> GetFacilityByFilter(string filter);
        Task ProcessFacilities(string objData);
    }
}
