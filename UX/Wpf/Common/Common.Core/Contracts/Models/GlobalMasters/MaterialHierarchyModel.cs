using Common.Core.Contracts.Interfaces;
using Common.Core.Contracts.Interfaces.GlobalMasters;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Purchasing;
using Common.Core.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class MaterialHierarchyModel : BaseModel<Guid>, IMaterialHierarchy
    {
        private string _materialNumber;
        [DataMember]
        [StringLength(26)]
        [Required]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => SetProperty(ref _materialNumber, value);
        }

        private string _materialName;
        [DataMember]
        [StringLength(50)]
        public string MaterialName
        {
            get => _materialName;
            set => SetProperty(ref _materialName, value);
        }

        private Guid _sourceApplicationGuid = Guid.Empty;
        [DataMember]
        //Navigation Property
        public Guid SourceApplicationGuid
        {
            get => _sourceApplicationGuid;
            set => SetProperty(ref _sourceApplicationGuid, value);
        }

        private Guid _unitOfMeasureGuid;
        [DataMember]
        [Required]
        //Navigation Property
        public Guid UnitOfMeasureGuid
        {
            get => _unitOfMeasureGuid;
            set => SetProperty(ref _unitOfMeasureGuid, value);
        }

        private string _preProductionNumber;
        [DataMember]
        [StringLength(26)]
        public string PreProductionNumber
        {
            get => _preProductionNumber;
            set => SetProperty(ref _preProductionNumber, value);
        }

        private decimal _unitWeight;
        [DataMember]
        [DecimalPrecision(10, 2)]
        public decimal UnitWeight
        {
            get => _unitWeight;
            set => SetProperty(ref _unitWeight, value);
        }

        /// <summary>
        ///  /// Gets or sets a Guid value for the MaterialTypeGuid column.
        /// </summary>
        private Guid _materialTypeGuid;
        [DataMember]
        [Required]
        public Guid MaterialTypeGuid
        {
            get => _materialTypeGuid;
            set => SetProperty(ref _materialTypeGuid, value);
        }
        /// <summary>
        /// Gets or sets a Guid value for the CommodityGuid column.
        /// </summary>
        private Guid _commodityGuid;
        [DataMember]
        [Required]
        public Guid CommodityGuid
        {
            get => _commodityGuid;
            set => SetProperty(ref _commodityGuid, value);
        }
        /// <summary>
        ///  Gets or sets a Guid value for the CutLength column.
        /// </summary>
        private decimal _cutLength;
        [DataMember]
        [DecimalPrecision(8, 3)]
        public decimal CutLength
        {
            get => _cutLength;
            set => SetProperty(ref _cutLength, value);
        }

        /// <summary>
        /// Local Reference of IsCustomerNominatedMaterial
        /// </summary>
        private bool _isCustomerNominatedMaterial;
        /// <summary>
        /// Is Customer Nominated Material
        /// </summary>
        [DataMember]
        public bool IsCustomerNominatedMaterial
        {
            get => _isCustomerNominatedMaterial;
            set => SetProperty(ref _isCustomerNominatedMaterial, value);
        }
        /// <summary>
        /// Local Reference of PurchasingSupplierMaterialHierarchy
        /// </summary>
        private List<PurchasingSupplierMaterialHierarchyModel> _iPurchasingSupplierMaterialHierarchy;
        /// <summary>
        /// Hierarchy of Purchasing Supplier Material
        /// </summary>
        [DataMember]
        public List<PurchasingSupplierMaterialHierarchyModel> PurchasingSupplierMaterialHierarchy
        {
            get => _iPurchasingSupplierMaterialHierarchy;
            set => SetProperty(ref _iPurchasingSupplierMaterialHierarchy, value);
        }
    }
}
