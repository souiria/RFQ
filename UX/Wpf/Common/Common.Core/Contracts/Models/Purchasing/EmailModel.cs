/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EmailModel.cs
Function           :   Manages Emails of Suppliers
Created By         :   Nitin Sagar
Created on         :   05-Jul-2019
Revision History   :   [] : 
****************************************************************************************************/
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// Types of Email
    /// </summary>
    [DataContract, Serializable]
    public class EmailModel
    {
        /// <summary>
        /// Public Reference of Email Id of Supplier
        /// </summary>
        [DataMember]
        [Required]
        public string EmailId { get; set; }

    }
}
