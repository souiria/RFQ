/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CurrencyModel.cs
Function           :   Data contract for Currency
Created By         :   
Created on         :   
Revision History   :   [02-July-2020] : Shivam Dhingra
                   :   Added new field IsExchangeRequired
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a row of Currency data.
    /// </summary>
    [DataContract, Serializable]
    public class CurrencyModel : BaseModel<Guid>
    {
        /// <summary>
        /// Gets or sets a string value for the Global CurrencyCode column.
        /// </summary>
        private string _currencyCode;
        [DataMember]
        public string CurrencyCode
        {
            get => _currencyCode;
            set => SetProperty(ref _currencyCode, value);
        }

        /// <summary>
        /// Gets or sets a string value for the Global CurrencyName column.
        /// </summary>
        private string _currencyName;
        [DataMember]
        public string CurrencyName
        {
            get => _currencyName;
            set => SetProperty(ref _currencyName, value);
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

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        private bool _isExchangeRequired = false;
        /// <summary>
        /// Property {IsExchangeRequired}
        /// </summary>
        [DataMember]
        [Required]
        public bool IsExchangeRequired
        {
            get => _isExchangeRequired;
            set => SetProperty(ref _isExchangeRequired, value);
        }
    }
}