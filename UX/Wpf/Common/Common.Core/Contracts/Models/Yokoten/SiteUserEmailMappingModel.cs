/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SiteUserEmailMappingModel.cs
Function           :   Data contract for SiteUserEmailMappingModel
Created By         :   Shivam Dhingra
Created on         :   27-March-2020
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

namespace Common.Core.Contracts.Models.Yokoten
{
    [DataContract, Serializable]
    public class SiteUserEmailMappingModel : BaseModel<Guid>
    {
        private Guid _businessUnitGuid;
        /// <summary>
        /// Get or Set for {BusinessUnitGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        private string _userName;
        /// <summary>
        /// This field will set EmailId
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private string _emailId;
        /// <summary>
        /// This field will set EmailId
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string EmailId
        {
            get => _emailId;
            set => SetProperty(ref _emailId, value);
        }

    }
}
