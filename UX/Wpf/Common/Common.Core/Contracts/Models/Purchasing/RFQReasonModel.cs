/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   RFQReasonModel.cs
Function           :   RFQ Reason 
Created By         :   Param
Created on         :   03-Jun-2019
Revision History   :   [11-Jun-2019] : Pawan
                   :   [] : Removed Reason Code from Data Contract model 
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a row of Reason Code.
    /// </summary>
    [DataContract, Serializable]
    public class RFQReasonModel : BaseModel<Guid>
    {
        /// <summary>
        /// Gets or sets a string value for the Reason Description column.
        /// </summary>
        private string _reasonDescription;
        [DataMember]
        [StringLength(100)]
        [Required]
        public string ReasonDescription
        {
            get => _reasonDescription;
            set => SetProperty(ref _reasonDescription, value);
        }
    }
}