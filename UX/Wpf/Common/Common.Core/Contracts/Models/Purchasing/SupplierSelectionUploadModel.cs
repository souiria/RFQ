using System;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class SupplierSelectionUploadModel : BaseModel<Guid>
    {
        private Guid _supplierMaterialAssociationGuid;
        [DataMember]
        public Guid SupplierMaterialAssociationGuid
        {
            get => _supplierMaterialAssociationGuid;
            set => SetProperty(ref _supplierMaterialAssociationGuid, value);
        }
        private Guid _businessUnitGuid;
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }
        private int _transitLeadTime;
        [DataMember]
        public int TransitLeadTime
        {
            get => _transitLeadTime;
            set => SetProperty(ref _transitLeadTime, value);
        }

        private DateTime _effectiveDate;
        [DataMember]
        public DateTime EffectiveDate
        {
            get => _effectiveDate;
            set => SetProperty(ref _effectiveDate, value);
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }

        private string _supplierName;
        [DataMember]
        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; }
        }
        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get { return _supplierGuid; }
            set { SetProperty(ref _supplierGuid, value); }
        }

        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get { return _materialGuid; }
            set { SetProperty(ref _materialGuid, value); }
        }

        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get { return _materialNumber; }
            set { SetProperty(ref _materialNumber, value); }
        }

        private string _businessUnitCode;
        [DataMember]
        public string BusinessUnitCode
        {
            get { return _businessUnitCode; }
            set { SetProperty(ref _businessUnitCode, value); }
        }
        private Guid _supplierMaterialPoPricingGuid;
        [DataMember]
        public Guid SupplierMaterialPoPricingGuid
        {
            get { return _supplierMaterialPoPricingGuid; }
            set { SetProperty(ref _supplierMaterialPoPricingGuid, value); }
        }
    }
}
