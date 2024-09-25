using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class PurchasingSupplierModel : BaseModel<Guid>
    {
        private Guid _supplierGuid;
        [DataMember]
        [Required]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => SetProperty(ref _supplierGuid, value);
        }

        private Guid _supplierAssociationGuid;
        [DataMember]
        public Guid SupplierAssociationGuid
        {
            get => _supplierAssociationGuid;
            set => SetProperty(ref _supplierAssociationGuid, value);
        }


        private string _paymentTerms;
        [DataMember]
        [Required]
        [MaxLength(20)]
        public string PaymentTerms
        {
            get => _paymentTerms;
            set => SetProperty(ref _paymentTerms, value);
        }

        private Guid _epoCommodityGroupGuid;
        [DataMember]
        [Required]
        public Guid EPOCommodityGroupGuid
        {
            get => _epoCommodityGroupGuid;
            set => SetProperty(ref _epoCommodityGroupGuid, value);
        }

        private string _CollectionAddress;
        [DataMember]
        [MaxLength(100)]
        public string CollectionAddress
        {
            get => _CollectionAddress;
            set => SetProperty(ref _CollectionAddress, value);
        }


        private Guid _pOPriceEffectiveDateTypeGuid;
        [DataMember] 
        public Guid POPriceEffectiveDateTypeGuid
        {
            get => _pOPriceEffectiveDateTypeGuid;
            set => SetProperty(ref _pOPriceEffectiveDateTypeGuid, value);
        }

     
     
        private Guid _tariffContentEmailGuid;
        [DataMember] 
        public Guid TariffContentEmailGuid
        {
            get => _tariffContentEmailGuid;
            set => SetProperty(ref _tariffContentEmailGuid, value);
        }

        private bool _tariffNotification;
        [DataMember]
        public bool TariffNotification
        {
            get => _tariffNotification;
            set => SetProperty(ref _tariffNotification, value);
        }

        private int _transporterVolume;
        [DataMember]
        public int TransporterVolume
        {
            get => _transporterVolume;
            set => SetProperty(ref _transporterVolume, value);
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
