/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ICPDToH1SynchronizationScheduler.cs
Function           :   Interface contains method for synchronization
Created By         :   Dharmendra Kumar
Created on         :   10-May-2018
Revision History   :   [12-Dec-2018] : Dharmendra Kumar
 *                 :   [ ] : Add method MaterialInventory/FirstReceiptDateBySectionCodeSynchronization
 *                 :   [14-Feb-2019] : Dharmendra Kumar
 *                 :   [ ] : Add method SupplierMaterialOriginExceptionPropagation 
 *                 :   [09-Apr-2019]  : Dharmendra Kumar
 *                 :   [ ]  : Add  Method for Facility Vehicle Customer Synchronization
****************************************************************************************************/

using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface ICPDToH1SynchronizationScheduler : IService
    {
        Task MaterialDataSynchronization();
        Task MaterialSiteDataSynchronization();
        Task FCDataSynchronization();
        Task<string> SupplierInactivePropagation(string SupplierStatus);
        Task<string> SupplierMaterialInactivePropagation(string SupplierMaterialStatus);
        Task FirstReceiptDateSynchronization();
        Task MaterialInventorySynchronization();
        Task<string> PurchasingSupplierMaterialInactivePropagation();
        //Added by Dharmendra Kumar on 12-Dec-2018 -Start
        Task MaterialInventoryBySectionCodeSynchronization(string sectionCode);
        Task FirstReceiptDateBySectionCodeSynchronization(string sectionCode);
        //Added by Dharmendra Kumar on 14-Feb-2019
        Task<string> SupplierMaterialOriginExceptionPropagation(string SMOExceptionEUPreferentialOriginStatus);
        //Added by Dharmendra Kumar on 12-Dec-2018 -End
        Task FCDataFacilityVehicleCustomerSynchronization();  //Added by Dharmendra Kumar on 09-Apr-2019
    }
}
