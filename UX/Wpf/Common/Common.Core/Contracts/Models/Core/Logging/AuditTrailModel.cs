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

namespace Common.Core.Contracts.Models.Core.Logging
{
    public class AuditTrailModel : BaseModel<Guid>
    {
        private string _modelName;

        [DataMember]
        [Required]
        [StringLength(500)]
        public string ModelName { get => _modelName; set => SetProperty(ref _modelName, value); }

        private string _fieldName;
        [DataMember]
        [Required]
        [StringLength(100)]
        public string FieldName { get => _fieldName; set => SetProperty(ref _fieldName, value); }

        private string _newValue;
        [DataMember]
        [StringLength(8000)]
        public string NewValue { get => _newValue; set => SetProperty(ref _newValue, value); }

        private string _oldValue;
        [DataMember]
        [StringLength(8000)]
        public string OldValue { get => _oldValue; set => SetProperty(ref _oldValue, value); }

        private string _action;
        [DataMember]
        [Required]
        [StringLength(10)]
        public string Action { get => _action; set => SetProperty(ref _action, value); }

        private Guid _itemGuid;
        [DataMember]
        public Guid ItemGuid
        {
            get => _itemGuid; set => SetProperty(ref _itemGuid, value);
        }
        private Guid _batchGuid;
        [DataMember]
        public Guid BatchGuid
        {
            get => _batchGuid; set => SetProperty(ref _batchGuid, value);
        }

        private string _modifiedByUserName;
        [DataMember]
        public string ModifiedByUserName
        {
            get => _modifiedByUserName; set => _modifiedByUserName = value;
        }
    }
    [DataContract, Serializable]
    public class AuditTrailSQLModel : BaseModel<Guid>
    {

        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }
        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }
        private string _businessUnitCode;
        [DataMember]
        public string BusinessUnitCode
        {
            get { return _businessUnitCode; }
            set { _businessUnitCode = value; }
        }
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

        private string _contactTypeName;
        [DataMember]
        public string ContactTypeName
        {
            get { return _contactTypeName; }
            set { _contactTypeName = value; }
        }
        private string _supplierGroupName;
        [DataMember]
        public string SupplierGroupName
        {
            get { return _supplierGroupName; }
            set { _supplierGroupName = value; }
        }
        private string _countryName;
        [DataMember]
        public string CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }
        private string _originStatusCode;
        [DataMember]
        public string OriginStatusCode
        {
            get { return _originStatusCode; }
            set { _originStatusCode = value; }
        }

        private string _code;
        [DataMember]
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private Guid _nprId;
        [DataMember]
        public Guid NPRId
        {
            get { return _nprId; }
            set { _nprId = value; }
        }
    }


    [DataContract, Serializable]
    public class AuditTrailSearchModel
    {
        //TODO: Convert these to auto properties.

        private string _modelName;

        [DataMember]
        [Required]
        [StringLength(500)]
        public string ModelName
        {
            get => _modelName;
            set => _modelName = value;
        }

        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }
        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }
        private string _businessUnitCode;
        [DataMember]
        public string BusinessUnitCode
        {
            get { return _businessUnitCode; }
            set { _businessUnitCode = value; }
        }
        private DateTime? _fromDate;

        [DataMember, DataType(DataType.DateTime)]
        public DateTime? FromDate
        {
            get => _fromDate;
            set => _fromDate = value;
        }
        private DateTime? _toDate;

        [DataMember, DataType(DataType.DateTime)]
        public DateTime? ToDate
        {
            get => _toDate;
            set => _toDate = value;
        }

        private string _contactTypeName;
        [DataMember]
        public string ContactTypeName
        {
            get { return _contactTypeName; }
            set { _contactTypeName = value; }
        }
        private string _supplierGroupName;
        [DataMember]
        public string SupplierGroupName
        {
            get { return _supplierGroupName; }
            set { _supplierGroupName = value; }
        }
        private string _country;
        [DataMember]
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        private string _originStatus;
        [DataMember]
        public string OriginStatus
        {
            get { return _originStatus; }
            set { _originStatus = value; }
        }
        private string _requestId;
        [DataMember]
        public string RequestId
        {
            get { return _requestId; }
            set { _requestId = value; }
        }
    }

}
