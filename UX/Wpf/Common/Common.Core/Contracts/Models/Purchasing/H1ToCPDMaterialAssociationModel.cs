using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class H1ToCPDMaterialAssociationModel
    {
        /// <summary>
        /// Gets or sets a Guid value for the MaterialGuid column.
        /// </summary>
        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => _materialGuid = value;
        }
        /// <summary>
        ///  /// Gets or sets a Guid value for the MaterialTypeGuid column.
        /// </summary>
        private Guid _materialTypeGuid;
        [DataMember]
        public Guid MaterialTypeGuid
        {
            get => _materialTypeGuid;
            set => _materialTypeGuid = value;
        }
        /// <summary>
        /// Gets or sets a Guid value for the CommodityGuid column.
        /// </summary>
        private Guid _commodityGuid;
        [DataMember]
        public Guid CommodityGuid
        {
            get => _commodityGuid;
            set => _commodityGuid = value;
        }
        /// <summary>
        ///  Gets or sets a Guid value for the CutLength column.
        /// </summary>
        private decimal _cutLength;
        [DataMember]
        public decimal CutLength
        {
            get => _cutLength;
            set => _cutLength = value;
        }
        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }
    }
}
