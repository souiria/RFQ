using Common.Core.Contracts.Interfaces.Purchasing;
using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Purchasing
{
    public class SupplierMaterialPOPricingHierarchyModel : BaseModel<Guid>, ISupplierMaterialPOPricingHierarchy
    {
        private int _recordEntryID;
        [DataMember]
        public int RecordEntryID
        {
            get => _recordEntryID;
            set => SetProperty(ref _recordEntryID, value);
        }
        private decimal _poPrice;
        [DataMember]
        [Required]
        [DecimalPrecision(10, 5)]
        public decimal POPrice
        {
            get => _poPrice;
            set => SetProperty(ref _poPrice, value);
        }

        private decimal _metalWeight;
        [DataMember]
        [Required]
        [DecimalPrecision(10, 6)]
        public decimal MetalWeight
        {
            get => _metalWeight;
            set => SetProperty(ref _metalWeight, value);
        }


        private decimal _metalRate;
        [DataMember]
        [Required]
        [DecimalPrecision(10, 6)]
        public decimal MetalRate
        {
            get => _metalRate;
            set => SetProperty(ref _metalRate, value);
        }

        private decimal _poPriceExcludingMetal;
        [DataMember]
        [Required]
        [DecimalPrecision(10, 6)]
        public decimal POPriceExcludingMetal
        {
            get => _poPriceExcludingMetal;
            set => SetProperty(ref _poPriceExcludingMetal, value);
        }

        private DateTime _effectiveFromDate;
        [DataMember]
        [Required]
        public DateTime EffectiveFromDate
        {
            get => _effectiveFromDate;
            set => SetProperty(ref _effectiveFromDate, value);
        }

        private Guid _priceTypeGuid;
        [DataMember]
        [Required]
        public Guid PriceTypeGuid
        {
            get => _priceTypeGuid;
            set => SetProperty(ref _priceTypeGuid, value);
        }
        private string _priceChangeNotification;
        [DataMember]
        [StringLength(15)]
        public string PriceChangeNotification
        {
            get => _priceChangeNotification;
            set => SetProperty(ref _priceChangeNotification, value);
        }
        private string _approved;
        [DataMember]
        [StringLength(1)]
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
    }
}
