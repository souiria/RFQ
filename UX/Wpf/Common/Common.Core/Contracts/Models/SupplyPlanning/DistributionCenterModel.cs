/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   DistributionCenterModel.cs
Function           :   Distribution Center 
Created By         :   Shivam Dhingra
Created on         :   19-Feb-2020
Revision History   :   [20-Feb-2020] Shivam Dhingra
                   :   Renamed DistributionCenterType,Country to DistributionCenterTypeGuid, CountryGuid
                   :   [07-Nov-2022] Prakhar Singh
                   :   Added new property EWMSWarehouseCode.
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    [DataContract, Serializable]
    public class DistributionCenterModel : BaseModel<Guid>
    {
        private string _distributionCenterCode;
        /// <summary>
        /// Get or Set for {DistributionCenterCode}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(35)]
        public string DistributionCenterCode
        {
            get => _distributionCenterCode;
            set => SetProperty(ref _distributionCenterCode, value);
        }

        private string _ewmsWarehouseCode;
        /// <summary>
        /// get or set for EWMSWarehouseCode
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string EWMSWarehouseCode
        {
            get => _ewmsWarehouseCode;
            set => SetProperty(ref _ewmsWarehouseCode, value);
        }

        private string _distributionCenterDescription;
        /// <summary>
        /// Get or Set for {DistributionCenterDescription}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string DistributionCenterDescription
        {
            get => _distributionCenterDescription;
            set => SetProperty(ref _distributionCenterDescription, value);
        }
        private Guid _countryGuid;
        /// <summary>
        /// Get or Set for {Country}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CountryGuid
        {
            get => _countryGuid;
            set => SetProperty(ref _countryGuid, value);
        }

        private Guid _distributionCenterTypeGuid;
        /// <summary>
        /// Get or Set for {DistributionCenterType}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid DistributionCenterTypeGuid
        {
            get => _distributionCenterTypeGuid;
            set => SetProperty(ref _distributionCenterTypeGuid, value);
        }
    }
}
