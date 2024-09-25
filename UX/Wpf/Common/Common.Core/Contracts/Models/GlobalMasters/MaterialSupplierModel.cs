using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class MaterialSupplierModel : BaseModel<Guid>
    {
        private bool? _isRowChecked = false;
        [NotMapped, DataMember]
        public bool? IsRowChecked
        {
            get => _isRowChecked;
            set => SetProperty(ref _isRowChecked, value);
        }

        private Guid _materialGuid;
        [Required]
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => SetProperty(ref _materialGuid, value);
        }

        private Guid _supplierGuid;
        [DataMember]
        [Required]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => SetProperty(ref _supplierGuid, value);
        }

        private string _supplierMaterialNumber;
        [DataMember]
        [Required]
        [StringLength(12)]
        public string SupplierMaterialNumber
        {
            get => _supplierMaterialNumber;
            set => SetProperty(ref _supplierMaterialNumber, value);
        }

        private string _supplierMaterialName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string SupplierMaterialName
        {
            get => _supplierMaterialName;
            set => SetProperty(ref _supplierMaterialName, value);
        }

        private bool _isActive = true;
        [DataMember]
        [Required]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        private int _poMinimumOrderQuantity;
        [DataMember]
        [Required]
        public int POMinimumOrderQuantity
        {
            get => _poMinimumOrderQuantity;
            set => SetProperty(ref _poMinimumOrderQuantity, value);
        }

        private decimal _poPrice;
        [DataMember]
        [Required]
        [DecimalPrecision(18, 6)]
        public decimal POPrice
        {
            get => _poPrice;
            set => SetProperty(ref _poPrice, value);
        }

        private int _transitLeadTime;
        [DataMember]
        [Required]
        public int TransitLeadTime
        {
            get => _transitLeadTime;
            set => SetProperty(ref _transitLeadTime, value);
        }

        private int _orderLeadTime;
        [DataMember]
        [Required]
        public int OrderLeadTime
        {
            get => _orderLeadTime;
            set => SetProperty(ref _orderLeadTime, value);
        }

        private int _issueMinimumLot;
        [DataMember]
        [Required]
        public int IssueMinimumLot
        {
            get => _issueMinimumLot;
            set => SetProperty(ref _issueMinimumLot, value);
        }

        private int _containerQuantity;
        [DataMember]
        [Required]
        public int ContainerQuantity
        {
            get => _containerQuantity;
            set => SetProperty(ref _containerQuantity, value);
        }

        private int _noOfInnerContainer;
        [DataMember]
        [Required]
        public int NoOfInnerContainer
        {
            get => _noOfInnerContainer;
            set => SetProperty(ref _noOfInnerContainer, value);
        }

        private DateTime? _effectiveDateFrom;
        [DataMember]
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime? EffectiveDateFrom
        {
            get => _effectiveDateFrom;
            set => SetProperty(ref _effectiveDateFrom, value);
        }

        private DateTime? _effectiveDateTo;
        [DataMember]
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime? EffectiveDateTo
        {
            get => _effectiveDateTo;
            set => SetProperty(ref _effectiveDateTo, value);
        }
    }

    //prakhar
    public class SupplierPartNumberDropDownModel
    {


        private string _SupplierMaterialNumber;
        [DataMember]
        public string SupplierMaterialNumber
        {
            get => _SupplierMaterialNumber;
            set => _SupplierMaterialNumber = value;
        }


    }
}