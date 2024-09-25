using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.Purchasing
{
    public  class SupplierMaterialPOPricingModel : BaseModel<Guid>
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
        [Required]
        public Guid SupplierMaterialGuid
        {
            get => _supplierMaterialGuid;
            set => SetProperty(ref _supplierMaterialGuid, value);
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
    public class SupplierMaterialPOPricingLatestPriceModel
    {
        /**************************************************************************************************
        (C) 2018 SEWS-E Ltd., All rights reserved
        File Name          :   SupplierMaterialPOPricingLatestPriceModel.cs
        Function           :   Display data in grid
        Created By         :   Dharmendra Kumar
        Created on         :   05-Feb-2019
        Revision History   :   [05-Feb-2019] : Dharmendra Kumar                  
        *                  :   [ ]  : Get Latest PO Price on the basis of Modified Date
        ****************************************************************************************************/
        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        private Guid _supplierMaterialGuid;
        [DataMember]
        public Guid SupplierMaterialGuid
        {
            get => _supplierMaterialGuid;
            set => _supplierMaterialGuid = value;
        }

        private decimal _poPrice;
        [DataMember]
        [DecimalPrecision(10, 5)]
        public decimal POPrice
        {
            get => _poPrice;
            set => _poPrice = value;
        }

        private decimal _metalWeight;
        [DataMember]
        [DecimalPrecision(10, 6)]
        public decimal MetalWeight
        {
            get => _metalWeight;
            set => _metalWeight = value;
        }

        private decimal _metalRate;
        [DataMember]
        [DecimalPrecision(10, 6)]
        public decimal MetalRate
        {
            get => _metalRate;
            set => _metalRate = value;
        }

        private decimal _poPriceExcludingMetal;
        [DataMember]
        [DecimalPrecision(10, 6)]
        public decimal POPriceExcludingMetal
        {
            get => _poPriceExcludingMetal;
            set => _poPriceExcludingMetal = value;
        }
        private int _recordEntryID;
        [DataMember]
        public int RecordEntryID
        {
            get => _recordEntryID;
            set => _recordEntryID = value;
        }
        //Added By Dharmendra Kumar on 05-Feb-2019
        private DateTime? _modifiedDate;
        [DataMember]
        public DateTime? ModifiedDate
        {
            get => _modifiedDate;
            set => _modifiedDate = value;
        }
        //Added By Amit Agarwal on 19-Feb-2019
        private DateTime _effectiveFromDate;
        [DataMember]
        public DateTime EffectiveFromDate
        {
            get => _effectiveFromDate;
            set => _effectiveFromDate = value;
        }
    }
}
