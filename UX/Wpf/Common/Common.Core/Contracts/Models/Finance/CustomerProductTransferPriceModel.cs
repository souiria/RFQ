/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerProductTransferPriceModel.cs
Function           :   Customer Product Transfer Price
Created By         :   Shivam Dhingra
Created on         :   24-Feb-2022
Revision History   :    [01-04-2022] : Shahab
                   :   [ ] : Added new field CurrencyCode
                   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Finance
{
    [DataContract, Serializable]
    public class CustomerProductTransferPriceModel : BaseModel<Guid>
    {
        private int _recordEntryID;
        /// <summary>
        /// RecordEntryID
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int RecordEntryID
        {
            get => _recordEntryID;
            set => SetProperty(ref _recordEntryID, value);
        }

        private Guid _businessUnitGuid;
        /// <summary>
        /// BusinessUnitGuid
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }


        private string _customerProductNumber;
        /// <summary>
        /// CustomerProductNumber
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(26)]
        public string CustomerProductNumber
        {
            get => _customerProductNumber;
            set => SetProperty(ref _customerProductNumber, value);
        }

        private DateTime _effectiveDate;
        /// <summary>
        /// EffectiveDate
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime EffectiveDate
        {
            get => _effectiveDate;
            set => SetProperty(ref _effectiveDate, value);
        }

        private decimal _transferPrice;
        /// <summary>
        /// TransferPrice
        /// </summary>
        [DataMember]
        [DecimalPrecision(15, 6)]
        [Required]
        public decimal TransferPrice
        {
            get => _transferPrice;
            set => SetProperty(ref _transferPrice, value);
        }


        private string _currencyCode;
        /// <summary>
        /// CurrencyCode
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public string CurrencyCode
        {
            get => _currencyCode;
            set => SetProperty(ref _currencyCode, value);
        }
        
    }
    /// <summary>
    /// DAta Contract for CustomerProductTransferPriceProcedureParametersModel
    /// </summary>
    [DataContract, Serializable]
    public class CustomerProductTransferPriceProcedureParametersModel
    {
        /// <summary>
        /// Local variable _businessUnitGuid
        /// </summary>
        private Guid? _businessUnitGuid;
        /// <summary>
        /// Get or Set for {BusinessUnitGuid}.
        /// </summary>
        [DataMember]
        public Guid? BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => _businessUnitGuid = value;
        }

        /// <summary>
        /// Local variable _customerProductNumber
        /// </summary>
        private string _customerProductNumber;
        /// <summary>
        /// Get or Set for {CustomerProductNumber}.
        /// </summary>
        [DataMember]
        public string CustomerProductNumber
        {
            get => _customerProductNumber;
            set => _customerProductNumber = value;
        }

        /// <summary>
        /// Local variable _currentEffectivePrice
        /// </summary>
        private bool _currentEffectivePrice;
        /// <summary>
        /// Get or Set for {CurrentEffectivePrice}.
        /// </summary>
        [DataMember]
        public bool CurrentEffectivePrice
        {
            get => _currentEffectivePrice;
            set => _currentEffectivePrice = value;
        }

        private string _p_option;
        /// <summary>
        /// Get or Set for {P_option}.
        /// </summary>
        [DataMember]
        [StringLength(1)]
        public string P_option
        {
            get => _p_option;
            set => _p_option = value;
        }

    }

    /// <summary>
    /// Model For Upload Process
    /// </summary>
    [DataContract,Serializable]
    public class CustomerProductTransferPriceUploadModel : BaseModel<Guid>
    {
        private int _recordEntryID;
        /// <summary>
        /// RecordEntryID
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int RecordEntryID
        {
            get => _recordEntryID;
            set => SetProperty(ref _recordEntryID, value);
        }

        private string _businessUnitCode;
        /// <summary>
        /// BusinessUnitCode
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => SetProperty(ref _businessUnitCode, value);
        }


        private string _customerProductNumber;
        /// <summary>
        /// CustomerProductNumber
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(26)]
        public string CustomerProductNumber
        {
            get => _customerProductNumber;
            set => SetProperty(ref _customerProductNumber, value);
        }

        private DateTime _effectiveDate;
        /// <summary>
        /// EffectiveDate
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime EffectiveDate
        {
            get => _effectiveDate;
            set => SetProperty(ref _effectiveDate, value);
        }

        private decimal _transferPrice;
        /// <summary>
        /// TransferPrice
        /// </summary>
        [DataMember]
        [DecimalPrecision(15, 6)]
        [Required]
        public decimal TransferPrice
        {
            get => _transferPrice;
            set => SetProperty(ref _transferPrice, value);
        }

        private string _currencyCode;
        /// <summary>
        /// CurrencyCode
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [Required]
        public string CurrencyCode
        {
            get => _currencyCode;
            set => SetProperty(ref _currencyCode, value);
        }


    }
    /// <summary>
    /// Class File for CustomerProductNumberComboModel
    /// </summary>
    [DataContract, Serializable]
    public class CustomerProductNumberComboModel
    {
        private string _customerProductNumber;
        /// <summary>
        /// CustomerProductNumber
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(26)]
        public string CustomerProductNumber
        {
            get => _customerProductNumber;
            set => _customerProductNumber = value;
        }
    }
}
