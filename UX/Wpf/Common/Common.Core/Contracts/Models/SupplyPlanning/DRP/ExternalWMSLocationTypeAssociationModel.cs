/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ExternalWMSLocationTypeAssociationModel.cs
Function           :   External WMS Location Type Association & WarehouseCodeModel
Created By         :   Sachin Pandey
Created on         :   22-Sep-2023
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning.DRP
{
    /// <summary>
    /// Data Contract use for DRP Manual Order Generation Data Entry
    /// </summary>
    [DataContract, Serializable]
    public class ExternalWMSLocationTypeAssociationModel : BaseModel<Guid>
    {
        private string _warehouseCode;
        /// <summary>
        /// Get or Set for {WarehouseCode}.
        /// </summary>
        [DataMember]
        public string WarehouseCode
        {
            get => _warehouseCode;
            set => SetProperty(ref _warehouseCode, value);
        }

        private string _locationCode;
        /// <summary>
        /// Get or Set for {LocationCode}.
        /// </summary>
        [DataMember]
        public string LocationCode
        {
            get => _locationCode;
            set => SetProperty(ref _locationCode, value);
        }

        private string _locationType;
        /// <summary>
        /// Get or Set for {LocationType}.
        /// </summary>
        [DataMember]
        public string LocationType
        {
            get => _locationType;
            set => SetProperty(ref _locationType, value);
        }

        private string _locationTypeDescription;
        /// <summary>
        /// Get or Set for {LocationTypeDescription}.
        /// </summary>
        [DataMember]
        public string LocationTypeDescription
        {
            get => _locationTypeDescription;
            set => SetProperty(ref _locationTypeDescription, value);
        }
    }

    public class WarehouseCodeModel
    {
        private string _warehouseCode;
        /// <summary>
        /// Get or Set for {WarehouseCode}.
        /// </summary>
        [DataMember]
        public string WarehouseCode
        {
            get => _warehouseCode;
            set => _warehouseCode = value;
        }
    
    }
}
