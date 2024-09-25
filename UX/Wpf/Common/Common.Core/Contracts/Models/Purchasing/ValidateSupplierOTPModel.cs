/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  ValidateSupplierOTPModel.cs.cs
Function           :  ValidateSupplierOTPModel.cs Model
Created By         :   Virendra
Created on         :   05-Dec-2022
Revision History   :   
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// Data contract used for Validate Supplier OTP
    /// </summary>

    [DataContract, Serializable]
    public class ValidateSupplierOTPModel
    {

        private Guid _supplierGroupGuid;
        /// <summary>
        /// Get or Set for {SupplierGroupGuid}.
        /// </summary>
        [DataMember]
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid;
            set => _supplierGroupGuid = value;
        }
        private string _otp;
        /// <summary>
        /// Get or Set for {OTP}.
        /// </summary>
        [DataMember]
        public string OTP
        {
            get => _otp;
            set => _otp = value;
        }
        private string _returnMessage;
        /// <summary>
        /// Get or Set for {ReturnMessage}.
        /// </summary>
        [DataMember]
        public string ReturnMessage
        {
            get => _returnMessage;
            set => _returnMessage = value;
        }
    }
}
 
