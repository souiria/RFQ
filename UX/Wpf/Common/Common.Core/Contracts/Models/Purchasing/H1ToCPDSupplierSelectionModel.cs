using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class H1ToCPDSupplierSelectionModel
    {
        private Guid _supplierMaterialAssociationGuid;
        [DataMember]
        public Guid SupplierMaterialAssociationGuid
        {
            get => _supplierMaterialAssociationGuid;
            set => _supplierMaterialAssociationGuid = value;
        }
        private Guid _businessUnitGuid;
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => _businessUnitGuid = value;
        }

        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }
    }
    [DataContract, Serializable]
    public class H1ToCPDSupplierSelectionDataSyncModel
    {
        private string _section_code;
        [DataMember]
        public string section_code
        {
            get => _section_code;
            set => _section_code = value;
        }
        private string _supplier_code;
        [DataMember]
        public string supplier_code
        {
            get => _supplier_code;
            set => _supplier_code = value;
        }

        private string _material_number;
        [DataMember]
        public string material_number
        {
            get => _material_number;
            set => _material_number = value;
        }

        private int _order_ltime;
        [DataMember]
        public int order_ltime
        {
            get => _order_ltime;
            set => _order_ltime = value;
        }

        private int _trans_ltime;
        [DataMember]
        public int trans_ltime
        {
            get => _trans_ltime;
            set => _trans_ltime = value;
        }

        private DateTime _effectiveDate;
        [DataMember]
        public DateTime EffectiveDate
        {
            get => _effectiveDate;
            set => _effectiveDate = value;
        }

        private bool _isCPDSupplier = false;
        [DataMember]
        public bool IsCPDSupplier
        {
            get => _isCPDSupplier;
            set => _isCPDSupplier = value;
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }
        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }

        private string _error;
        [DataMember]
        public string Error
        {
            get => _error;
            set => _error = value;
        }
        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
    }
}
