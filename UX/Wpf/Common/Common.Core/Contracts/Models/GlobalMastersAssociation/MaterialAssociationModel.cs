using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    /// <summary>
    /// Represents a row of MaterialAssociation data.
    /// </summary>
    [DataContract, Serializable]
    public class MaterialAssociationModel : BaseModel<Guid>
    {
        /// <summary>
        /// Gets or sets a Guid value for the MaterialGuid column.
        /// </summary>
        private Guid _materialGuid;
        [DataMember]
        [Required]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => SetProperty(ref _materialGuid, value);
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
    }
}
