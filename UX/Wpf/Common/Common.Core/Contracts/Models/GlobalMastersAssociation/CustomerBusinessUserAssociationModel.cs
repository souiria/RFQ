/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerBusinessUserAssociationModel.cs
Function           :   Stateful service for CustomerBusinessUserAssociationModel
Created By         :   
Created on         :   
Revision History   :   [21-May-2020] : Srashti 
*                  :   Created the IsActive property nullable.
*                  :   [03-June-2020] : Srashti 
*                  :   Created the model {CustomerBusinessUserMappingDetailsModel}
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract, Serializable]
    public class CustomerBusinessUserAssociationModel : BaseModel<Guid>
    {
        private Guid _userGuid;
        /// <summary>
        /// This field will set UserGuid
        /// </summary>
        [DataMember]
        [Required]
        public Guid UserGuid
        {
            get => _userGuid;
            set => SetProperty(ref _userGuid, value);
        }

        private List<CustomerBusinessUserMappingDetailsModel> _customerBusinessHierarchyList;
        /// <summary>
        /// This field will set CustomerBusinessHierarchyList
        /// </summary>
        [DataMember]
        [Required]
        public List<CustomerBusinessUserMappingDetailsModel> CustomerBusinessHierarchyList
        {
            get => _customerBusinessHierarchyList;
            set => SetProperty(ref _customerBusinessHierarchyList, value);
        }
    }
    /// <summary>
    /// List for CustomerBusinessUserMappingDetailsModel Model
    /// </summary>
    public class CustomerBusinessUserMappingDetailsModel
    {
        private Guid _customerBusinessHierarchyGuid;
        /// <summary>
        /// This field will set CustomerBusinessHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessHierarchyGuid
        {
            get { return _customerBusinessHierarchyGuid; }
            set { _customerBusinessHierarchyGuid = value; }
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
