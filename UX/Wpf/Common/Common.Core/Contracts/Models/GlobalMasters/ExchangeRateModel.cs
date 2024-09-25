using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    public class ExchangeRateModel : BaseModel<Guid>
    {
        private Guid _currencyID;
        [DataMember]
        public Guid CurrencyID
        {
            get => _currencyID;
            set => SetProperty(ref _currencyID, value);
        }

        private decimal _exchangeRate;
        [DataMember]
        public decimal ExchangeRate
        {
            get => _exchangeRate;
            set => SetProperty(ref _exchangeRate, value);
        }

        private DateTime _startDate;
        [DataMember]
        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private DateTime _endDate;
        [DataMember]
        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }
    }
}