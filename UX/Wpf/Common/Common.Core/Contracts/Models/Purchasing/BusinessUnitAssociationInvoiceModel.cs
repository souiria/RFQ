/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  BusinessUnitAssociationInvoiceModel.cs
Function           :  BusinessUnitAssociationInvoiceModel.cs Model
Created By         :   Virendra
Created on         :   19-July-2023
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class BusinessUnitAssociationInvoiceModel : BaseModel<Guid>
    {
        private Guid _businessUnitGuid;
        /// <summary>
        /// Get or Set for {BusinessUnitGuid}.
        /// </summary>
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        private string _businessUnitCode;
        /// <summary>
        /// Get or Set for {BusinessUnitCode}.
        /// </summary>
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => SetProperty(ref _businessUnitCode, value);
        }
        private string _legacyBusinessUnitCode;
        /// <summary>
        /// Get or Set for {LegacyBusinessUnitCode}.
        /// </summary>
        [DataMember]
        public string LegacyBusinessUnitCode
        {
            get => _legacyBusinessUnitCode;
            set => SetProperty(ref _legacyBusinessUnitCode, value);
        }

        private bool _isIncludeInvoice = true;
        /// <summary>
        /// Get or Set for {IsIncludeInvoice}.
        /// </summary>
        [DataMember]
        public bool IsIncludeInvoice
        {
            get => _isIncludeInvoice;
            set => SetProperty(ref _isIncludeInvoice, value);
        }
    }
}
