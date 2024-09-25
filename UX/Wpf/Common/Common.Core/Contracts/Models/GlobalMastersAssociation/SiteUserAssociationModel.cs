/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SiteUserAssociationModel.cs
Function           :   SiteUserAssociation
Created By         :   Shivam Dhingra
Created on         :   21-Oct-2020
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

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    /// <summary>
    /// Data Contract for Site User Association
    /// </summary>
    [DataContract, Serializable]
    public class SiteUserAssociationModel : BaseModel<Guid>
    {
        private Guid _userGuid;
        /// <summary>
        /// Get or set for UserGuid
        /// </summary>
        [DataMember]
        [Required]
        public Guid UserGuid
        {
            get => _userGuid;
            set => SetProperty(ref _userGuid, value);
        }

        private List<BusinessUnitMappingDetailsModel> _businessUnitList;
        /// <summary>
        /// This field will set BusinessUnitList
        /// </summary>
        [DataMember]
        [Required]
        public List<BusinessUnitMappingDetailsModel> BusinessUnitList
        {
            get => _businessUnitList;
            set => SetProperty(ref _businessUnitList, value);
        }
    }

    /// <summary>
    /// List for BusinessUnitMappingDetailsModel
    /// </summary>
    public class BusinessUnitMappingDetailsModel
    {
        private Guid _businessUnitGuid;
        /// <summary>
        /// This field will set BusinessUnitGuid
        /// </summary>
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get { return _businessUnitGuid; }
            set { _businessUnitGuid = value; }
        }

        private bool _isActive;
        /// <summary>
        /// This field will set IsActive
        /// </summary>
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
    }

}
