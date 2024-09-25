/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   PurchasingFacilityVehicleCustomerFCDataModel.cs
Function           :   Contain Information of Facility,Customer and Vehicle
Created By         :   Dharmendra Kumar
Created on         :   09-Apr-2019
Revision History   :  
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    public  class PurchasingFacilityVehicleCustomerFCDataModel : BaseModel<Guid>
    {
        [DataMember]
        public string PurchasingFacilityCode { get; set; }
        [DataMember]
        public string PurchasingFacilityName { get; set; }
        [DataMember]
        public string PurchasingVehicleCode  { get; set; }
        [DataMember]
        public string PurchasingVehicleName  { get; set; }
        [DataMember]
        public string PurchasingCustomerCode { get; set; }
        [DataMember]
        public string PurchasingCustomerName { get; set; }
    }
}
