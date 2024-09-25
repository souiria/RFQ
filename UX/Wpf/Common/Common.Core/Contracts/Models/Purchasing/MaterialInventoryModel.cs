using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class MaterialInventoryModel : BaseModel<Guid>
    {
        private Guid _businessUnitGuid;
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        private Guid _materialGuid;
        [DataMember]
        [Required]
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
    }
    [DataContract, Serializable]
    public class CPDMaterialInventoryModel : ExternalDataSourceModel<object>
    {
        private string _section_c;
        [DataMember]
        public string section_c
        {
            get => _section_c;
            set => SetProperty(ref _section_c, value);
        }
        private string _material_no;
        [DataMember]
        public string material_no
        {
            get => _material_no;
            set => SetProperty(ref _material_no, value);
        }
        private int _invt_qty;
        [DataMember]
        public int invt_qty
        {
            get => _invt_qty;
            set => SetProperty(ref _invt_qty, value);
        }

        private int _safetyinvt_qty;
        [DataMember]
        public int safetyinvt_qty
        {
            get => _safetyinvt_qty;
            set => SetProperty(ref _safetyinvt_qty, value);
        }

        private byte _safetyinvt_days;
        [DataMember]
        public byte safetyinvt_days
        {
            get => _safetyinvt_days;
            set => SetProperty(ref _safetyinvt_days, value);
        }

        private int _dly_usage_qty;
        [DataMember]
        public int dly_usage_qty
        {
            get => _dly_usage_qty;
            set => SetProperty(ref _dly_usage_qty, value);
        }
        private string _userid;
        [DataMember]
        public string userid
        {
            get => _userid;
            set => SetProperty(ref _userid, value);
        }
        //Add by Dharmendra Kumar on 25-Apr-2019
        private DateTime _upd_dt;
        [DataMember]
        public DateTime upd_dt
        {
            get => _upd_dt;
            set => SetProperty(ref _upd_dt, value);
        }
    }
}
