/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  SupplierRoleMasterMaster.cs
Function           :  Supplier Role Master Model
Created By         :  Prakhar
Created on         :  06-Oct-2023
Revision History   :  []
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
    public class SupplierRoleMasterModel : BaseModel<Guid>
    {
        private string _systemRole;
        /// <summary>
        /// Get or Set for {SystemRole}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]

        public string SystemRole
        {
            get => _systemRole;
            set => SetProperty(ref _systemRole, value);
        }

        private string _userFunction;
        /// <summary>
        /// Get or Set for {UserFunction}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string UserFunction
        {
            get => _userFunction;
            set => SetProperty(ref _userFunction, value);
        }

        private bool _isActive = true;
        /// <summary>
        /// Get or Set for {IsActive}.
        /// </summary>
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        private bool _supplierPortalAccountRequired;
        /// <summary>
        /// Get or Set for {SupplierPortalAccountRequired}.
        /// </summary>
        [DataMember]
        public bool SupplierPortalAccountRequired
        {
            get => _supplierPortalAccountRequired;
            set => SetProperty(ref _supplierPortalAccountRequired, value);
        }
    }
}
