/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EDIFileTypeModel.cs
Function           :   EDI File Type Model
Created By         :   Srashti Gupta
Created on         :   23-Jan-2020
Revision History   :   Srashti Gupta
                   :   [24-Jan-2020]:Change the Model as per the requirements.  
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
    
    public class EDIFileTypeModel : BaseModel<Guid>
    {
        
        private string _ediFileType;
        /// <summary>
        /// Get or Set for {EDIFileType}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(4)]
        public string EDIFileType
        {
            get => _ediFileType;
            set => SetProperty(ref _ediFileType, value);
        }
    }
}
