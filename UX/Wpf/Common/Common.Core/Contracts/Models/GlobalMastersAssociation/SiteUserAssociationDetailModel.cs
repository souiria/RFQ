/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SiteUserAssociationDetailModel.cs
Function           :   Stateful service for SiteUserAssociation
Created By         :   Shivam Dhingra
Created on         :   22-Oct-2020
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    /// <summary>
    /// DataContract for SiteUserAssociationDetail
    /// </summary>
    [DataContract, Serializable]
    public class SiteUserAssociationDetailModel 
    {
        private Guid _userGuid;
        /// <summary>
        /// Gets or sets for UserGuid
        /// </summary>
        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => _userGuid = value;
        }

        private Guid _id;
        /// <summary>
        /// Gets or sets for Id
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        private Guid _businessUnitGuid;
        /// <summary>
        /// Gets or sets for BusinessUnitGuid
        /// </summary>
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => _businessUnitGuid = value;
        }

        private bool _isActive;
        /// <summary>
        /// Gets or sets for IsActive
        /// </summary>
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }
    }
}
