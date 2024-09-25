/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   InvoiceeDetailsModel.cs
Function           :   Invoicee Details
Created By         :   Srashti Gupta
Created on         :   10-Feb-2020
Revision History   :   
                   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract use for EDISetUpMasters Service
    /// </summary>
    [DataContract, Serializable]
    public class InvoiceeDetailsModel : BaseModel<Guid>
    {
        private string _invoiceeCode;
        /// <summary>
        /// Get or Set for {InvoiceeCode}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(35)]
        public string InvoiceeCode
        {
            get => _invoiceeCode;
            set => SetProperty(ref _invoiceeCode, value);
        }

        private string _invoiceeName;
        /// <summary>
        /// Get or Set for {InvoiceeName}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(35)]
        public string InvoiceeName
        {
            get => _invoiceeName;
            set => SetProperty(ref _invoiceeName, value);
        }
    }
}
