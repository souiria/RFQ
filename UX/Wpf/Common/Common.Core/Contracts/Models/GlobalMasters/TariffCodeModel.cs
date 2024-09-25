using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    public class TariffCodeModel : BaseModel<Guid>
    {
        private string _tariffCodeName;
        [DataMember]
        [Required]
        [StringLength(8)]
        public string TariffCodeName
        {
            get => _tariffCodeName;
            set => SetProperty(ref _tariffCodeName, value);
        }

        private string _tariffDescription;
        [DataMember]
        [Required]
        [StringLength(100)]
        public string TariffDescription
        {
            get => _tariffDescription;
            set => SetProperty(ref _tariffDescription, value);
        }

        private decimal _nonEuDutyRate;
        [DataMember]
        public decimal NonEuDutyRate
        {
            get => _nonEuDutyRate;
            set => SetProperty(ref _nonEuDutyRate, value);
        }

        private decimal _euDutyRate;
        [DataMember]
        public decimal EuDutyRate
        {
            get => _euDutyRate;
            set => SetProperty(ref _euDutyRate, value);
        }

        private decimal _vatRate;
        [DataMember]
        public decimal VatRate
        {
            get => _vatRate;
            set => SetProperty(ref _vatRate, value);
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

    }

    public class CheckTariffCodeRefrenceModel
    {
        private Guid _tariffCodeGuid = Guid.Empty;
        [DataMember]
        //Navigation Property
        public Guid TariffCodeGuid
        {
            get => _tariffCodeGuid;
            set =>  _tariffCodeGuid = value;
        }

    }
}