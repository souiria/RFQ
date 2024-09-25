/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplierPasswordHistoryModel.cs
Function           :   Manages Password History for Supplier to login Supplier Web Portal 
Created By         :   Srashti Gupta
Created on         :   06-Feb-2020
Revision History   :   
****************************************************************************************************/

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
    public class SupplierPasswordHistoryModel
    {
        private DateTime _passwordCreationDate;

        /// <summary>
        /// Get or Set for PasswordCreationDate
        /// </summary>
        [DataMember]
        [Required]
        public DateTime PasswordCreationDate
        {
            get => _passwordCreationDate;
            set =>_passwordCreationDate = value;
        }
        private string _encryptedPassword;

        /// <summary>
        /// Get or Set for PasswordCreationDate
        /// </summary>
        [DataMember]
        [Required]
        public string EncryptedPassword
        {
            get => _encryptedPassword;
            set => _encryptedPassword = value;
        }
    }
}
