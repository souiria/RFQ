/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   PPSCustomerMappingModel.cs
Function           :  PPS Customer Mapping
Created By         :   Dharmendra Kumar
Created on         :   21-Apr-2020
Revision History   :   [22-Jun-2020] : Shivam Dhingra
                   :   Changed String Length for PPSCustomerCode from 10 to 18
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Class file for PPS Customer Model
    /// </summary>
    public class PPSCustomerMappingModel : BaseModel<Guid>
    {
        /// <summary>
        /// Get or Set for PPS Manufacturing Site Guid
        /// </summary>
        private Guid _ppsManufacturingSiteGuid;
        [DataMember]
        public Guid PPSManufacturingSiteGuid
        {
            get => _ppsManufacturingSiteGuid;
            set => SetProperty(ref _ppsManufacturingSiteGuid, value);
        }

        /// <summary>
        /// Get or Set for {PPSManufacturingSite}
        /// </summary>
        private string _ppsManufacturingSite;
        [DataMember]
        [StringLength(50)]
        public string PPSManufacturingSite
        {
            get => _ppsManufacturingSite;
            set => SetProperty(ref _ppsManufacturingSite, value);
        }
        /// <summary>
        /// Get or Set for {PPSCustomer}
        /// </summary>
        private string _ppsCustomer;
        [DataMember]
        [StringLength(18)]
        public string PPSCustomerCode
        {
            get => _ppsCustomer;
            set => SetProperty(ref _ppsCustomer, value);
        }
        private string _ppsCarModel;
        [DataMember]
        [StringLength(20)]
        public string PPSCarModel
        {
            get => _ppsCarModel;
            set => SetProperty(ref _ppsCarModel, value);
        }
        /// <summary>
        /// Local reference of {ProductionStartDate}
        /// </summary>
        private DateTime _productionStartDate;
        [DataMember, DataType(DataType.Date)]
        [Required]
        public DateTime ProductionStartDate
        {
            get => _productionStartDate;
            set => SetProperty(ref _productionStartDate, value.Date);
        }
        /// <summary>
        /// Local reference of {ProductionFinishDate}
        /// </summary>
        private DateTime _productionFinishDate;
        [DataMember, DataType(DataType.Date)]
        [Required]
        public DateTime ProductionFinishDate
        {
            get => _productionFinishDate;
            set => SetProperty(ref _productionFinishDate, value.Date);
        }
        /// <summary>
        /// Local reference of {ProductionPercentage}
        /// </summary>
        private int _productionPercentage;
        [DataMember]
        public int ProductionPercentage
        {
            get => _productionPercentage;
            set => SetProperty(ref _productionPercentage, value);
        }

        private Guid _distributionCenterGuid;
        /// <summary>
        /// Get or Set for {DistributionCenterGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid DistributionCenterGuid
        {
            get => _distributionCenterGuid;
            set => SetProperty(ref _distributionCenterGuid, value);
        }
    }
}
