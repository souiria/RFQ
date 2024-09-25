using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.CPD
{
    [DataContract, Serializable]
    public class InterfaceWHCPDMastersMaterialOriginModel : BindableBaseEntity, IEntity<long>
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

        private string _siteCode;
        [DataMember]
        public string SiteCode
        {
            get => _siteCode;
            set => SetProperty(ref _siteCode, value);
        }

        private string _tarifCode;
        [DataMember]
        public string TarifCode
        {
            get => _tarifCode;
            set => SetProperty(ref _tarifCode, value);
        }

        private string _countryOfOriginCode;
        [DataMember]
        public string CountryOfOriginCode
        {
            get => _countryOfOriginCode;
            set => SetProperty(ref _countryOfOriginCode, value);
        }

        private string _originStatus;
        [DataMember]
        public string OriginStatus
        {
            get => _originStatus;
            set => SetProperty(ref _originStatus, value);
        }

        private DateTime? _expiryDate;
        [DataMember]
        public DateTime? ExpiryDate
        {
            get => _expiryDate;
            set => SetProperty(ref _expiryDate, value);
        }

        private string _supplierMaterialNumber;
        [DataMember]
        public string SupplierMaterialNumber
        {
            get => _supplierMaterialNumber;
            set => SetProperty(ref _supplierMaterialNumber, value);
        }

        private decimal? _poPrice;
        [DataMember]
        public decimal? POPrice
        {
            get => _poPrice;
            set => SetProperty(ref _poPrice, value);
        }

        private string _currencyCode;
        [DataMember]
        public string CurrencyCode
        {
            get => _currencyCode;
            set => SetProperty(ref _currencyCode, value);
        }

        private string _mrpDemand;
        [DataMember]
        public string MRPDemand
        {
            get => _mrpDemand;
            set => SetProperty(ref _mrpDemand, value);
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
