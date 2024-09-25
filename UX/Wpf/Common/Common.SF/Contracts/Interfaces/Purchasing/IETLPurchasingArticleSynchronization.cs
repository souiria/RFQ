/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ETLPurchasingArticleSynchronizationController.cs
Function           :   Stateless Service for Synchronization by Adohc
Created By         :   Nitin Sagar
Created on         :   13-Apr-2018
Revision History   :   [12-Dec-2018] : Dharmendra Kumar
 *                 :   [ ] : Commented Code First Receipt Date / Material Inventory for Preventing Adohc call
 *                 :   [01-Jan-2019] : Nitin Sagar
 *                 :   [ ] : Removed all the references to the Archive Services 
 *                 :   [ ] : Removed H1ToCPD Synchronization Code for Article : "H1 To CPD"
 *                 :   [18-Apr-2019] :Dharmendra Kumar 
 *                 :    [ ] : Add New Article H1 To CPD To DHS for Adhoc Sync 
 *                 :   [01-May-2020] :Dharmendra Kumar 
 *                 :    [ ] : Core Material Hierarchy Proxy changes 
 *                 :   [06-May-2020] Dharmendra Kumar
 *                 :    [ ] Create two new method FCDataFacilityVehicleCustomerSynchronization()  and SupplierMaterialOriginExceptionPropagation() to ETLPurchasingArticleSynchronization
****************************************************************************************************/
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Contracts.Models.Purchasing;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IETLPurchasingArticleSynchronization : IService
    {
        Task<IEnumerable<ETLPurchasingArticleSynchronizationGridModel>> GetGridData();
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);

        // Task<IEnumerable<PurchasingArticleSynchronizationModel>> SyncArticles(IEnumerable<PurchasingArticleSynchronizationModel> syncModel);
        Task<string> SyncArticles(string objData);
        //Added by Dharmendra Kumar on 06-May-2020 Move from interface ICPDToH1SynchronizationScheduler
        Task<string> SupplierMaterialOriginExceptionPropagation(string SMOExceptionEUPreferentialOriginStatus);

        Task FCDataFacilityVehicleCustomerSynchronization();
    }
}
