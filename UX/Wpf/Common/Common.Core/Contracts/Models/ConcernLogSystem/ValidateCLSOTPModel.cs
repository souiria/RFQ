/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  ValidateCLSOTPModel.cs
Function           :  ValidateCLSOTPModel.cs Model
Created By         :   Ashish Dutta
Created on         :   25-Dec-2023
Revision History   :   
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ConcernLogSystem
{
    /// <summary>
    /// Data contract used for Validate Supplier OTP
    /// </summary>

    [DataContract, Serializable]
    public class ValidateCLSOTPModel
    {

        private Guid _cLSGuid;
        /// <summary>
        /// Get or Set for {SupplierGroupGuid}.
        /// </summary>
        [DataMember]
        public Guid CLSGuid
        {
            get => _cLSGuid;
            set => _cLSGuid = value;
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
 
