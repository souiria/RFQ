/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   PPSCustomerCarModelFacilityModel.cs
Function           :   PPS Customer CarModel Facility Model 
Created By         :   Shivam Dhingra
Created on         :   22-Apr-2020
Revision History   :   [22-Jun-2020] : Shivam Dhingra
                   :   Changed String length for CustomerCode from 10 to 18

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
    /// <summary>
    /// Class file for PPSCustomerCarModelFacilityModel
    /// </summary>
    
    [DataContract, Serializable]
    public class PPSCustomerCarModelFacilityModel : BaseModel<Guid>
    {
       

         private string _customerBusinessUnit;
        /// <summary>
        /// Get or Set for {CustomerBusinessUnit}.
        /// </summary>
        [DataMember]
        [StringLength(20)]
        [Required]
        public string CustomerBusinessUnit
        {
            get => _customerBusinessUnit;
            set => SetProperty(ref _customerBusinessUnit, value);
        }

        private string _manufacturingSite;
        /// <summary>
        /// Get or Set for {ManufacturingSite}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        [Required]
        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => SetProperty(ref _manufacturingSite, value);
        }

        private string _customerCode;
        /// <summary>
        /// Get or Set for {CustomerCode}.
        /// </summary>
        [DataMember]
        [StringLength(18)]
        [Required]
        public string CustomerCode
        {
            get => _customerCode;
            set => SetProperty(ref _customerCode, value);
        }

        private string _carModel;
        /// <summary>
        /// Get or Set for {CarModel}.
        /// </summary>
        [DataMember]
        [StringLength(20)]
        [Required]
        public string CarModel
        {
            get => _carModel;
            set => SetProperty(ref _carModel, value);
        }

        private string _facilityName;
        /// <summary>
        /// Get or Set for {FacilityName}.
        /// </summary>
        [DataMember]
        [StringLength(20)]
        [Required]
        public string FacilityName
        {
            get => _facilityName;
            set => SetProperty(ref _facilityName, value);
        }

        private string _manufacturingCountry;
        /// <summary>
        /// Get or Set for {ManufacturingCountry}.
        /// </summary>
        [DataMember]
        [StringLength(7)]
        [Required]
        public string ManufacturingCountry
        {
            get => _manufacturingCountry;
            set => SetProperty(ref _manufacturingCountry, value);
        }

        private bool _obsolete;
        /// <summary>
        /// Get or Set for {Obsolete}.
        /// </summary>
        [DataMember]
        public bool Obsolete
        {
            get => _obsolete;
            set => SetProperty(ref _obsolete, value);
        }

    }
}
