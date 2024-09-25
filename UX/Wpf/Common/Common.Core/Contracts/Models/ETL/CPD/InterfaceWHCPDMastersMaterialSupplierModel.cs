using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.CPD
{
    [DataContract, Serializable]
    public class InterfaceWHCPDMastersMaterialSupplierModel : BindableBaseEntity, IEntity<long>
    {
        private long _id;
        [DataMember, Key]
        public long Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        object IEntity.Id
        {
            get => Id;
            set => Id = (long)Convert.ChangeType(value, typeof(long));
        }

        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => SetProperty(ref _materialNumber, value);
        }

        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode;
            set => SetProperty(ref _supplierCode, value);
        }

        private string _poUnit;
        [DataMember]
        public string POUnit
        {
            get => _poUnit;
            set => SetProperty(ref _poUnit, value);
        }

        private int? _poMinimumOrderQuantity;
        [DataMember]
        public int? POMinimumOrderQuantity
        {
            get => _poMinimumOrderQuantity;
            set => SetProperty(ref _poMinimumOrderQuantity, value);
        }

        private decimal? _poPrice;
        [DataMember]
        public decimal? POPrice
        {
            get => _poPrice;
            set => SetProperty(ref _poPrice, value);
        }

        private byte? _poRatio;
        [DataMember]
        public byte? PORatio
        {
            get => _poRatio;
            set => SetProperty(ref _poRatio, value);
        }

        private byte? _orderLeadTime;
        [DataMember]
        public byte? OrderLeadTime
        {
            get => _orderLeadTime;
            set => SetProperty(ref _orderLeadTime, value);
        }

        private string _issueUnit;
        [DataMember]
        public string IssueUnit
        {
            get => _issueUnit;
            set => SetProperty(ref _issueUnit, value);
        }

        private int? _issueMinLot;
        [DataMember]
        public int? IssueMinLot
        {
            get => _issueMinLot;
            set => SetProperty(ref _issueMinLot, value);
        }

        private int? _unitConfacPO;
        [DataMember]
        public int? UnitConfacPO
        {
            get => _unitConfacPO;
            set => SetProperty(ref _unitConfacPO, value);
        }

        private int? _unitConfacIssue;
        [DataMember]
        public int? UnitConfacIssue
        {
            get => _unitConfacIssue;
            set => SetProperty(ref _unitConfacIssue, value);
        }

        private int? _bagQuantity;
        [DataMember]
        public int? BagQuantity
        {
            get => _bagQuantity;
            set => SetProperty(ref _bagQuantity, value);
        }

        private int? _boxQuantity;
        [DataMember]
        public int? BoxQuantity
        {
            get => _boxQuantity;
            set => SetProperty(ref _boxQuantity, value);
        }

        private string _supplierMaterialNumber;
        [DataMember]
        public string SupplierMaterialNumber
        {
            get => _supplierMaterialNumber;
            set => SetProperty(ref _supplierMaterialNumber, value);
        }

        private string _supplierMaterialName;
        [DataMember]
        public string SupplierMaterialName
        {
            get => _supplierMaterialName;
            set => SetProperty(ref _supplierMaterialName, value);
        }

        private string _updatedFlag;
        [DataMember]
        public string UpdatedFlag
        {
            get => _updatedFlag;
            set => SetProperty(ref _updatedFlag, value);
        }

        private string _userId;
        [DataMember]
        public string UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private DateTime? _entryDate;
        [DataMember]
        public DateTime? EntryDate
        {
            get => _entryDate;
            set => SetProperty(ref _entryDate, value);
        }

        private DateTime? _updateDate;
        [DataMember]
        public DateTime? UpdateDate
        {
            get => _updateDate;
            set => SetProperty(ref _updateDate, value);
        }

        private decimal? _standardBoxLength;
        [DataMember]
        public decimal? StandardBoxLength
        {
            get => _standardBoxLength;
            set => SetProperty(ref _standardBoxLength, value);
        }

        private decimal? _standardBoxWidth;
        [DataMember]
        public decimal? StandardBoxWidth
        {
            get => _standardBoxWidth;
            set => SetProperty(ref _standardBoxWidth, value);
        }

        private decimal? _standardBoxHeight;
        [DataMember]
        public decimal? StandardBoxHeight
        {
            get => _standardBoxHeight;
            set => SetProperty(ref _standardBoxHeight, value);
        }

        private int? _standardPackFactor;
        [DataMember]
        public int? StandardPackFactor
        {
            get => _standardPackFactor;
            set => SetProperty(ref _standardPackFactor, value);
        }

        private decimal? _copperWeight;
        [DataMember]
        public decimal? CopperWeight
        {
            get => _copperWeight;
            set => SetProperty(ref _copperWeight, value);
        }

        private decimal? _copperRate;
        [DataMember]
        public decimal? CopperRate
        {
            get => _copperRate;
            set => SetProperty(ref _copperRate, value);
        }

        private decimal? _poPriceExCopper;
        [DataMember]
        public decimal? POPriceExCopper
        {
            get => _poPriceExCopper;
            set => SetProperty(ref _poPriceExCopper, value);
        }

        private decimal? _initialVolumeQuantity;
        [DataMember]
        public decimal? InitialVolumeQuantity
        {
            get => _initialVolumeQuantity;
            set => SetProperty(ref _initialVolumeQuantity, value);
        }

        private string _replaceMaterialNumber;
        [DataMember]
        public string ReplaceMaterialNumber
        {
            get => _replaceMaterialNumber;
            set => SetProperty(ref _replaceMaterialNumber, value);
        }

        private decimal? _fullBoxWeight;
        [DataMember]
        public decimal? FullBoxWeight
        {
            get => _fullBoxWeight;
            set => SetProperty(ref _fullBoxWeight, value);
        }

        [NotMapped]
        public DateTime CreatedDate { get; set; }
        [NotMapped]
        public DateTime? ModifiedDate { get; set; }
        [NotMapped]
        public Guid CreatedBy { get; set; }
        [NotMapped]
        public Guid ModifiedBy { get; set; }
        [NotMapped]
        public byte[] Version { get; set; }
    }
}
