using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class H1ToCPDCommodityModel
    {
        /// <summary>
        /// Gets or sets a string value for the commodityName column.
        /// </summary>
        private Guid _commodityGuid;
        [DataMember]
        public Guid CommodityGuid
        {
            get => _commodityGuid;
            set => _commodityGuid = value;
        }
        /// <summary>
        /// Gets or sets a string value for the CommodityGroup column.
        /// </summary>
        private string _commodityGroup;
        [DataMember]
        public string CommodityGroup
        {
            get => _commodityGroup;
            set => _commodityGroup = value;
        }
        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }
    }
    [DataContract, Serializable]
    public class H1ToCPDCommodityDataSyncModel : H1ToCPDCommodityModel
    {
        /// <summary>
        /// Gets or sets a string value for the Commodity Name column.
        /// </summary>
        private string _commodityName;
        [DataMember]
        public string CommodityName
        {
            get => _commodityName;
            set => _commodityName = value;
        }
        private string _error;
        [DataMember]
        public string Error
        {
            get => _error;
            set => _error = value;
        }
    }
}
