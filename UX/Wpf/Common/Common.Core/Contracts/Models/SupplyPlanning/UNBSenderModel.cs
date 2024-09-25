/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   UNBSenderModel.cs
Function           :   Data Contract for UNBSender
Created By         :   Shivam Dhingra
Created on         :   08-May-2020
Revision History   :   [07-Jun-2021] : Shivam Kalia
                   :   Changed the data length from 12 characters to 35 characters for UNBSenderId 
*                  :   [10-Mar-2022] : Sejal Srivastava
*                  :   Removed Customer Business Group Name column               
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
    /// Data Contract for UNBSender
    /// </summary>
    [DataContract, Serializable]
    public class UNBSenderModel : BaseModel<Guid>
    {
        private string _unbSenderId;
        /// <summary>
        /// Get or Set for {UNBSenderId}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        [Required]
        public string UNBSenderId
        {
            get => _unbSenderId;
            set => SetProperty(ref _unbSenderId, value);
        }

        //private string _customerBusinessGroupName;
        ///// <summary>
        ///// Get or Set for {CustomerBusinessGroupName}.
        ///// </summary>
        //[DataMember]
        //[StringLength(100)]
        //[Required]
        //public string CustomerBusinessGroupName
        //{
        //    get => _customerBusinessGroupName;
        //    set => SetProperty(ref _customerBusinessGroupName, value);
        //}

    }
}
