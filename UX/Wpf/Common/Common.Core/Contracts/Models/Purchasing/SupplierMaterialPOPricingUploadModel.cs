using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class SupplierMaterialPOPricingUploadModel : BaseModel<Guid>
    {
        private int _recordEntryID;
        [DataMember]
        public int RecordEntryID
        {
            get => _recordEntryID;
            set => SetProperty(ref _recordEntryID, value);
        }

        private Guid _supplierMaterialGuid;
        [DataMember]
        public Guid SupplierMaterialGuid
        {
            get => _supplierMaterialGuid;
            set => SetProperty(ref _supplierMaterialGuid, value);
        }

        private decimal _poPrice;
        [DataMember]
        public decimal POPrice
        {
            get => _poPrice;
            set => SetProperty(ref _poPrice, value);
        }

        private decimal _metalWeight;
        [DataMember]
        public decimal MetalWeight
        {
            get => _metalWeight;
            set => SetProperty(ref _metalWeight, value);
        }


        private decimal _metalRate;
        [DataMember]
        public decimal MetalRate
        {
            get => _metalRate;
            set => SetProperty(ref _metalRate, value);
        }

        private decimal _poPriceExcludingMetal;
        [DataMember]
        public decimal POPriceExcludingMetal
        {
            get => _poPriceExcludingMetal;
            set => SetProperty(ref _poPriceExcludingMetal, value);
        }

        private DateTime _effectiveFromDate;
        [DataMember]
        public DateTime EffectiveFromDate
        {
            get => _effectiveFromDate;
            set => SetProperty(ref _effectiveFromDate, value);
        }

        private Guid _priceTypeGuid;
        [DataMember]
        public Guid PriceTypeGuid
        {
            get => _priceTypeGuid;
            set => SetProperty(ref _priceTypeGuid, value);
        }

        private string _priceChangeNotification;
        [DataMember]
        public string PriceChangeNotification
        {
            get => _priceChangeNotification;
            set => SetProperty(ref _priceChangeNotification, value);
        }
        private string _approved;
        [DataMember]
        public string Approved
        {
            get => _approved;
            set => SetProperty(ref _approved, value);
        }


        private DateTime _approvedDate;
        [DataMember]
        public DateTime ApprovedDate
        {
            get => _approvedDate;
            set => SetProperty(ref _approvedDate, value);
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        #region Properties

        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { SetProperty(ref _supplierCode, value); }
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

        private string _poPriceTypeCode;
        [DataMember]
        public string POPriceTypeCode
        {
            get { return _poPriceTypeCode; }
            set { SetProperty(ref _poPriceTypeCode, value); }
        }

        private string _poPriceTypeDescription;
        [DataMember]
        public string POPriceTypeDescription
        {
            get { return _poPriceTypeDescription; }
            set { SetProperty(ref _poPriceTypeDescription, value); }
        }

        private string _approvedText;
        [DataMember]
        public string ApprovedText
        {
            get { return _approvedText; }
            set { SetProperty(ref _approvedText, value); }
        }
        private string _errorDesc;
        [DataMember]
        public string ErrorDesc
        {
            get { return _errorDesc; }
            set { SetProperty(ref _errorDesc, value); }
        }
        #endregion
    }
}
