using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// Model for Supplier Material Maintenance form Material Hierarchy
    /// </summary>
    [DataContract, Serializable]
    public class SupplierMaterialMaintenanceHierarchyExportAllStatelessModel : PurchasingSupplierMaterialHierarchyExportAllStatelessModel
    {
        #region Properties
        private Guid _materialGuid;
        [DataMember]
        [Required]
        //Navigation Property
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => SetProperty(ref _materialGuid, value);
        }
        private string _materialNumber;
        [DataMember]
        [StringLength(26)]
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
        private Guid _unitOfMeasureGuidMaterial;
        [DataMember]
        [Required]
        //Navigation Property
        public Guid UnitOfMeasureGuidMaterial
        {
            get => _unitOfMeasureGuidMaterial;
            set => SetProperty(ref _unitOfMeasureGuidMaterial, value);
        }

        private string _preProductionNumber;
        [DataMember]
        [StringLength(26)]
        public string PreProductionNumber
        {
            get => _preProductionNumber;
            set => SetProperty(ref _preProductionNumber, value);
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
        #endregion
    }

}
