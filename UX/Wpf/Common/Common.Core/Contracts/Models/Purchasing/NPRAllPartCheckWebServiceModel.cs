/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   NPRAllPartCheckWebServiceModel.cs
Function           :   NPRAllPartCheckWebService
Created By         :   Srashti Gupta
Created on         :   17-Nov-2019
Revision History   :   
****************************************************************************************************/
using Common.Core.Infrastructure.Attributes;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// Data Contract use for NPRAllPartCheckWebServiceModel Service
    /// </summary>
    [DataContract, Serializable]
    public class NPRAllPartCheckWebServiceModel
    {
        /// <summary>
        /// Local Reference of reference_no
        /// </summary>
        private string _reference_no;
        /// <summary>
        /// Get or Sets the value of {reference_no} 
        /// </summary>
        [DataMember]
        public string reference_no
        {
            get => _reference_no;
            set => _reference_no = value;
        }
        /// <summary>
        /// Local Reference of supplier_part_no
        /// </summary>
        private string _supplier_part_no;
        /// <summary>
        /// Get or Sets the value of {supplier_part_no} 
        /// </summary>
        [DataMember]
        public string supplier_part_no
        {
            get => _supplier_part_no;
            set => _supplier_part_no = value;
        }
        /// <summary>
        /// Local Reference of suggested_supplier
        /// </summary>
        private string _suggested_supplier;
        /// <summary>
        /// Get or Sets the value of {suggested_supplier} 
        /// </summary>
        [DataMember]
        public string suggested_supplier
        {
            get => _suggested_supplier;
            set => _suggested_supplier = value;
        }

        /// <summary>
        /// Local Reference of actual_supplier
        /// </summary>
        private string _actual_supplier;
        /// <summary>
        /// Get or Sets the value of {actual_supplier} 
        /// </summary>
        [DataMember]
        public string actual_supplier
        {
            get => _actual_supplier;
            set => _actual_supplier = value;
        }

        /// <summary>
        /// Local Reference of countryoforigin
        /// </summary>
        private string _countryoforigin;
        /// <summary>
        /// Get or Sets the value of {countryoforigin} 
        /// </summary>
        [DataMember]
        public string countryoforigin
        {
            get => _countryoforigin;
            set => _countryoforigin = value;
        }
        /// <summary>
        /// Local Reference of tariffcode
        /// </summary>
        private string _tariffcode;
        /// <summary>
        /// Get or Sets the value of {tariffcode} 
        /// </summary>
        [DataMember]
        public string tariffcode
        {
            get => _tariffcode;
            set => _tariffcode = value;
        }
        /// <summary>
        /// Local Reference of currency
        /// </summary>
        private string _currency;
        /// <summary>
        /// Get or Sets the value of {currency} 
        /// </summary>
        [DataMember]
        public string currency
        {
            get => _currency;
            set => _currency = value;
        }
        /// <summary>
        /// Local Reference of purchase_UOM
        /// </summary>
        private string _purchase_UOM;
        /// <summary>
        /// Get or Sets the value of {purchase_UOM} 
        /// </summary>
        [DataMember]
        public string purchase_UOM
        {
            get => _purchase_UOM;
            set => _purchase_UOM = value;
        }
        /// <summary>
        /// Local Reference of price
        /// </summary>
        private decimal _price;
        /// <summary>
        /// Get or Sets the value of {price} 
        /// </summary>
        [DataMember]
        [DecimalPrecision(9, 5)]
        public decimal price
        {
            get => _price;
            set => _price = value;
        }
        /// <summary>
        /// Local Reference of unitconversionfactor
        /// </summary>
        private int _unitconversionfactor;
        /// <summary>
        /// Get or Sets the value of {unitconversionfactor} 
        /// </summary>
        [DataMember]
        public int unitconversionfactor
        {
            get => _unitconversionfactor;
            set => _unitconversionfactor = value;
        }
        /// <summary>
        /// Local Reference of CuAl_rate
        /// </summary>
        private string _CuAl_rate;
        /// <summary>
        /// Get or Sets the value of {CuAl_rate} 
        /// </summary>
        [DataMember]
        public string CuAl_rate
        {
            get => _CuAl_rate;
            set => _CuAl_rate = value;
        }
        /// <summary>
        /// Local Reference of sumitomo_no
        /// </summary>
        private string _sumitomo_no;
        /// <summary>
        /// Get or Sets the value of {sumitomo_no} 
        /// </summary>
        [DataMember]
        public string sumitomo_no
        {
            get => _sumitomo_no;
            set => _sumitomo_no = value;
        }
        /// <summary>
        /// Local Reference of IsPartMatched
        /// </summary>
        private string _isPartMatched;
        /// <summary>
        /// Get or Sets the value of {IsPartMatched} 
        /// </summary>
        [DataMember]
        public string IsPartMatched
        {
            get { return _isPartMatched; }
            set { _isPartMatched = value; }
        }

    }
}
