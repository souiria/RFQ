/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SiteUserMappingModel.cs
Function           :   Data contract for SiteUserMapping
Created By         :   Ashish Dutta
Created on         :   18-Jun-2021
Revision History   :   []
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Yokoten
{
    /// <summary>
    /// Data Contract for SiteUserMappingModel
    /// </summary>
    [DataContract, Serializable]
    public class SiteUserMappingModel : BaseModel<Guid>
    {
        private Guid _userId;
        /// <summary>
        /// Get or Set for {UserId}
        /// </summary>
        [DataMember]
        [Required]
        public Guid UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private Guid _siteId;
        /// <summary>
        /// Get or Set for {_siteId}
        /// </summary>
        [DataMember]
        [Required]
        public Guid SiteId
        {
            get => _siteId;
            set => SetProperty(ref _siteId, value);
        }

        private string _userName;
        /// <summary>
        /// Get or Set for {_userName}
        /// </summary>
        [NotMapped,DataMember]
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private string _siteName;
        /// <summary>
        /// Get or Set for {_siteName}
        /// </summary>
        [NotMapped,DataMember]
        public string SiteName
        {
            get => _siteName;
            set => SetProperty(ref _siteName, value);
        }

        private string _yokotenRole;
        /// <summary>
        /// Get or Set for {_siteName}
        /// </summary>
        [NotMapped,DataMember]
        public string YokotenRole
        {
            get => _yokotenRole;
            set => SetProperty(ref _yokotenRole, value);
        }


    }
}
