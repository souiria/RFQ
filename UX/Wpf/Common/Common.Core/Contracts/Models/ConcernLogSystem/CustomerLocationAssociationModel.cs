/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  CustomerLocationAssociationModel.cs
Function           :  Customer Location Association Model
Created By         :  Vishwadeep Singh
Created on         :  18-Oct-2023
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

namespace Common.Core.Contracts.Models.ConcernLogSystem
{
    public class CustomerLocationAssociationModel : BaseModel<Guid>
    {

        
        private Guid businessUnitGuid;
        /// <summary>
        /// Get or Set for {BusinessUnitGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => businessUnitGuid;
            set => SetProperty(ref businessUnitGuid, value);
        }

        private Guid customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerGuid
        {
            get => customerGuid;
            set => SetProperty(ref customerGuid, value);
        }

        private Guid businessUnitTypeGuid;
        /// <summary>
        /// Get or Set for {BusinessUnitTypeGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid BusinessUnitTypeGuid
        {
            get => businessUnitTypeGuid;
            set => SetProperty(ref businessUnitTypeGuid, value);
        }

        
        private string clsType;
        /// <summary>
        /// Get or Set for {ClsType}.
        /// </summary>
        [DataMember]
        [Required]
        public string ClsType
        {
            get => clsType;
            set => SetProperty(ref clsType, value);
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
