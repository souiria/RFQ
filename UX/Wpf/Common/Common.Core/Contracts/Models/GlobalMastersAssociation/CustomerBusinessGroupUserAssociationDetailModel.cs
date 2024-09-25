/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerBusinessGroupUserAssociationDetailModel.cs
Function           :   Stateful service for CustomerBusinessUserAssociation
Created By         :   Srashti Gupta
Created on         :   19-May-2020
Revision History   :   [21-May-2020] : Srashti 
*                  :    Added Id property in Model
****************************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract, Serializable]
    public class CustomerBusinessGroupUserAssociationDetailModel
    {
        private Guid _userGuid;
        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => _userGuid = value;
        }

        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        private Guid _customerBusinessHierarchyGuid;
        [DataMember]
        public Guid CustomerBusinessHierarchyGuid
        {
            get => _customerBusinessHierarchyGuid;
            set => _customerBusinessHierarchyGuid = value;
        }

        private bool _isActive;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }
    }
}
