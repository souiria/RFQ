using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;
namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ETLMaterialInventoryGridModel : BaseModel<Guid>
    {
        #region Properties
        private Guid _materialInventoryGuid;
        [DataMember]
        public Guid MaterialInventoryGuid
        {
            get => _materialInventoryGuid;
            set => SetProperty(ref _materialInventoryGuid, value);
        }
        private string _businessUnitCode;
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => SetProperty(ref _businessUnitCode, value);
        }

        private string _businessUnitName;
        [DataMember]
        public string BusinessUnitName
        {
            get => _businessUnitName;
            set => SetProperty(ref _businessUnitName, value);
        }

        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => SetProperty(ref _materialNumber, value);
        }

        private string _materialName;
        [DataMember]
        public string MaterialName
        {
            get => _materialName;
            set => SetProperty(ref _materialName, value);
        }

        private string _materialTypeCode;
        [DataMember]
        public string MaterialTypeCode
        {
            get => _materialTypeCode;
            set => SetProperty(ref _materialTypeCode, value);
        }

        private string _materialTypeDescription;
        [DataMember]
        public string MaterialTypeDerscription
        {
            get => _materialTypeDescription;
            set => SetProperty(ref _materialTypeDescription, value);
        }
        private string _unitOfMeasureCode;
        [DataMember]
        public string UnitOfMeasureCode
        {
            get => _unitOfMeasureCode;
            set => SetProperty(ref _unitOfMeasureCode, value);
        }
        private Guid _businessUnitGuid;
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => SetProperty(ref _materialGuid, value);
        }
        private int _inventoryQuantity;
        [DataMember]
        public int InventoryQuantity
        {
            get => _inventoryQuantity;
            set => SetProperty(ref _inventoryQuantity, value);
        }

        private int _safetyInventoryQuantity;
        [DataMember]
        public int SafetyInventoryQuantity
        {
            get => _safetyInventoryQuantity;
            set => SetProperty(ref _safetyInventoryQuantity, value);
        }

        private int _safetyInventoryDays;
        [DataMember]
        public int SafetyInventoryDays
        {
            get => _safetyInventoryDays;
            set => SetProperty(ref _safetyInventoryDays, value);
        }

        private int _dailyUsageQuantity;
        [DataMember]
        public int DailyUsageQuantity
        {
            get => _dailyUsageQuantity;
            set => SetProperty(ref _dailyUsageQuantity, value);
        }

        private DateTime _lastSynchronizeDateTime;
        [DataMember]
        public DateTime LastSynchronizeDateTime
        {
            get => _lastSynchronizeDateTime;
            set => SetProperty(ref _lastSynchronizeDateTime, value);
        }
        private DateTime _lastUpdateTime;
        [DataMember]
        public DateTime LastUpdateTime
        {
            get => _lastUpdateTime;
            set => SetProperty(ref _lastUpdateTime, value);
        }
        private Guid _lastUpdateBy;
        [DataMember]
        public Guid LastUpdateBy
        {
            get => _lastUpdateBy;
            set => SetProperty(ref _lastUpdateBy, value);
        }

    }
    #endregion
}

