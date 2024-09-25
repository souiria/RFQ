using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract, Serializable]
    public class CurrencyExchangeRateAssociationModel : BaseModel<Guid>
    {
        private Guid _currencyGuid;
        [DataMember]
        [Required]
        public Guid CurrencyGuid
        {
            get => _currencyGuid;
            set => SetProperty(ref _currencyGuid, value);
        }

        /// <summary>
        /// Gets or sets a decimal value for the Global EuroRate column.
        /// </summary>
        private decimal _euroRate;
        [DataMember]
        public decimal EuroRate
        {
            get => _euroRate;
            set => SetProperty(ref _euroRate, value);
        }

        private bool _baseFlag = false;
        [DataMember]
        public bool BaseFlag
        {
            get => _baseFlag;
            set => SetProperty(ref _baseFlag, value);
        }
    }
}
