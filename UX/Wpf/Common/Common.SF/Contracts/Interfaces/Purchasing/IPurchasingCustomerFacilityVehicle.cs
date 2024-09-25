using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
   public interface IPurchasingCustomerFacilityVehicle : IService, IPurchasingFacilityMaster, IPurchasingVehicleMaster, IPurchasingCustomerMaster
    {
    }
}
    