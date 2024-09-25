/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplierGroupModel.cs
Function           :   Supplier Group
Created By         :   Pawan
Created on         :   10-Jun-2018
Revision History   :   [09-Sep-2019] : Pawan
                   :   [] : Added field for IsSWSPartNumberRequired
                   :   [21-Sep-2022] : Ashish
                   :   [] : Added field for IsEOLRequired
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class SupplierGroupModel : BaseModel<Guid>
    {

        private string _supplierGroupName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string SupplierGroupName
        {
            get => _supplierGroupName;
            set => SetProperty(ref _supplierGroupName, value);
        }

        private Guid _supplierApprovalStatusGuid;
        [DataMember]
        [Required]
        public Guid SupplierApprovalStatusGuid
        {
            get => _supplierApprovalStatusGuid;
            set => SetProperty(ref _supplierApprovalStatusGuid, value);
        }

        private Guid _supplierPanelGuid;
        [DataMember]
        [Required]
        public Guid SupplierPanelGuid
        {
            get => _supplierPanelGuid;
            set => SetProperty(ref _supplierPanelGuid, value);
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        private bool _isSWSPartNumberRequired = false;
        /// <summary>
        /// SWS Part Number Required
        /// </summary>
        [DataMember]
        public bool IsSWSPartNumberRequired
        {
            get => _isSWSPartNumberRequired;
            set => SetProperty(ref _isSWSPartNumberRequired, value);
        }

        private bool _isEOLRequired = false;
        /// <summary>
        /// SWS Part Number Required
        /// </summary>
        [DataMember]
        public bool IsEOLRequired
        {
            get => _isEOLRequired;
            set => SetProperty(ref _isEOLRequired, value);
        }
    }
}
