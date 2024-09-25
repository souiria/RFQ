using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class MaterialOriginCostSettingsModel : BaseModel<Guid>
    {

        private Guid _businessUnitGuid;
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        private DateTime _effectiveFromDate;
        [DataMember]
        [Required]
        public DateTime EffectiveFromDate
        {
            get => _effectiveFromDate;
            set => SetProperty(ref _effectiveFromDate, value);
        }

        private decimal _dutyEUPct;
        [DataMember]
        [Required]
        [DecimalPrecision(5, 2)]
        public decimal DutyEUPct
        {
            get => _dutyEUPct;
            set => SetProperty(ref _dutyEUPct, value);
        }

        private decimal _dutyNonEUPct;
        [DataMember]
        [Required]
        [DecimalPrecision(5, 2)]
        public decimal DutyNonEUPct
        {
            get => _dutyNonEUPct;
            set => SetProperty(ref _dutyNonEUPct, value);
        }

        private decimal _transPortInsPct;
        [DataMember]
        [DecimalPrecision(5, 2)]
        [Required]
        public decimal TransPortInsPct
        {
            get => _transPortInsPct;
            set => SetProperty(ref _transPortInsPct, value);
        }

        private decimal _theresholdEUPct;
        [DataMember]
        [DecimalPrecision(5, 2)]
        [Required]
        public decimal TheresholdEUPct
        {
            get => _theresholdEUPct;
            set => SetProperty(ref _theresholdEUPct, value);
        }

        private decimal _overHead;
        [DataMember]
        [DecimalPrecision(7, 2)]
        [Required]
        public decimal OverHead
        {
            get => _overHead;
            set => SetProperty(ref _overHead, value);
        }

        private Guid _baseCurrencyGuid;
        [DataMember]
        [Required]
        public Guid BaseCurrencyGuid
        {
            get => _baseCurrencyGuid;
            set => SetProperty(ref _baseCurrencyGuid, value);
        }

        private Guid _reportingCurrencyGuid;
        [DataMember]
        [Required]
        public Guid ReportingCurrencyGuid
        {
            get => _reportingCurrencyGuid;
            set => SetProperty(ref _reportingCurrencyGuid, value);
        }

        private decimal _euLimitUptoPct;
        [DataMember]
        [Required]
        [DecimalPrecision(5, 2)]
        public decimal EULimitUptoPct
        {
            get => _euLimitUptoPct;
            set => SetProperty(ref _euLimitUptoPct, value);
        }
    }
}
