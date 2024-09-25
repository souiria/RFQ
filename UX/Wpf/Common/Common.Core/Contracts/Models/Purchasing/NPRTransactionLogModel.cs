/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   AuditTrailModel.cs
Function           :   Audit Trail Model
Created By         :   Pawan
Created on         :   04-Jul-2018
Revision History   :   [24-Sep-2019] : Pawan
                   :   [] : Added new field for NPR Number and Supplier Group
                   :   [13-May-2020] : Srashti
                   :   [] : Added new field for NPRId
****************************************************************************************************/
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Purchasing
{
    
    [DataContract, Serializable]
    public class NPRTransactionLogModel 
    {

        private string _nprNumber;
        [DataMember]
        public string NPRNumber
        {
            get { return _nprNumber; }
            set { _nprNumber = value; }
        }

        private string _supplierGroup;
        [DataMember]
        public string SupplierGroup
        {
            get { return _supplierGroup; }
            set { _supplierGroup = value; }
        }
        private string _modelName;

        [DataMember]
        [Required]
        [StringLength(500)]
        public string ModelName
        {
            get => _modelName;
            set => _modelName = value;
        }

        private string _fieldName;
        [DataMember]
        [Required]
        [StringLength(100)]
        public string FieldName { get => _fieldName; set => _fieldName = value; }

        private string _newValue;
        [DataMember]
        [StringLength(8000)]
        public string NewValue { get => _newValue; set => _newValue = value; }

        private string _oldValue;
        [DataMember]
        [StringLength(8000)]
        public string OldValue { get => _oldValue; set => _oldValue = value; }

        private string _action;
        [DataMember]
        [Required]
        [StringLength(10)]
        public string Action { get => _action; set => _action = value; }

        private Guid _itemGuid;
        [DataMember]
        public Guid ItemGuid
        {
            get => _itemGuid; set => _itemGuid = value;
        }
        private Guid _batchGuid;
        [DataMember]
        public Guid BatchGuid
        {
            get => _batchGuid; set => _batchGuid = value;
        }

        private string _modifiedByUserName;
        [DataMember]
        public string ModifiedByUserName
        {
            get => _modifiedByUserName; set => _modifiedByUserName = value;
        }

        private DateTime _modifiedDate;
        [DataMember]
        public DateTime ModifiedDate
        {
            get => _modifiedDate; set => _modifiedDate = value;
        }

    }

}
