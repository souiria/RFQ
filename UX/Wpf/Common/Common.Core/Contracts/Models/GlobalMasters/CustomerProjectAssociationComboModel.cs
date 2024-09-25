/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerProjectAssociationComboModel.cs
Function           :   CustomerProjectAssociation
Created By         :   Virendra  
Created on         :   [22-July-2022]
Revision History       [18-Dec-2023] : Prakhar Singh
                   :   Added Property Id.
                   
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class CustomerProjectAssociationComboModel
    {
        private Guid _iD;

        /// get or set for CustomerGuid
        [DataMember]
        
        public Guid ID
        {
            get => _iD;
            set => _iD = value;
        }

        private Guid _customerGuid;

        /// get or set for CustomerGuid
        [DataMember]
        [StringLength(20)]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => _customerGuid = value;
        }
        private Guid _projectGuid;

        /// get or set for ProjectGuid
        [DataMember]
        [StringLength(20)]
        public Guid ProjectGuid
        {
            get => _projectGuid;
            set => _projectGuid = value;
        }

        private string _projectName;

        /// get or set for ProjectName
        [DataMember]
        [StringLength(100)]
        public string ProjectName
        {
            get => _projectName;
            set => _projectName = value;
        }

    }
}
