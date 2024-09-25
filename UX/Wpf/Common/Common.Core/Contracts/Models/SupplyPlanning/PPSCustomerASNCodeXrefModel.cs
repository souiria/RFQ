/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   PPSCustomerASNCodeXrefModel.cs
Function           :   PPS Customer ASN Code Xref
Created By         :   Srashti Gupta
Created on         :   28-Oct-2020
Revision History   :  
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract for PPSCustomerASNCodeXrefModel
    /// </summary>
    [DataContract, Serializable]
    public class PPSCustomerASNCodeXrefModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local Reference for ManufacturingSite
        /// </summary>
        private string _manufacturingSite;
        /// <summary>
        /// Get or Set for {ManufacturingSite}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(4)]
        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => SetProperty(ref _manufacturingSite, value);
        }

        /// <summary>
        /// Local Reference for CustomerCode
        /// </summary>
        private string _customerCode;
        /// <summary>
        /// Get or Set for {CustomerCode}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(10)]
        public string CustomerCode
        {
            get => _customerCode;
            set => SetProperty(ref _customerCode, value);
        }

        /// <summary>
        /// Local Reference for WMS_ASN_CodeXref
        /// </summary>
        private string _wms_ASN_CodeXref;
        /// <summary>
        /// Get or Set for {WMS_ASN_CodeXref}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(4)]
        public string WMS_ASN_CodeXref
        {
            get => _wms_ASN_CodeXref;
            set => SetProperty(ref _wms_ASN_CodeXref, value);
        }
    }
}
