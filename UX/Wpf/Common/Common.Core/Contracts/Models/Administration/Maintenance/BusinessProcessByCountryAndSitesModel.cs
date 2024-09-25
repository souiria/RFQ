/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   BusinessProcessByCountryAndSitesModel.cs
Function           :   BusinessProcessByCountryAndSites
Created By         :   Shivam Dhingra
Created on         :   25-Sep-2020
Revision History   :  
                   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Administration.Maintenance
{
    /// <summary>
    /// DataContract for BusinessProcessByCountryAndSites
    /// </summary>
    [DataContract,Serializable]
    public class BusinessProcessByCountryAndSitesModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _functionDescription     
        /// </summary>
        private string _functionDescription;
        /// <summary>
        /// Get or Set for {FunctionDescription}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string FunctionDescription
        {
            get => _functionDescription;
            set => SetProperty(ref _functionDescription, value);
        }

        /// <summary>
        /// Local variable _functionCode  
        /// </summary>
        private string _functionCode;
        /// <summary>
        /// Get or Set for {FunctionCode}.
        /// Value will automatically generated through FunctionControlSequence
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(18)]
        public string FunctionCode
        {
            get => _functionCode;
            set => SetProperty(ref _functionCode, value);
        }
    }
}
