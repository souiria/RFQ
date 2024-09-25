using System;
using System.Runtime.Serialization;
/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   PurchasePriceFromH1ToEWMSModel.cs
Function           :   PurchasePriceFromH1ToEWMSModel
Created By         :   Dharmendra Kumar 
Created on         :   22-Aug-2022
Revision History   :  [08-Aug-2023]: Dharmendra
                   :  [] Addd new Property Remarks for handle output
****************************************************************************************************/
namespace Common.Core.Contracts.Models.SupplyPlanning
{
    [DataContract, Serializable]
    public class PurchasePriceFromH1ToEWMSModel
    {
        private string _ordernumber;
        [DataMember]
        public string OrderNumber
        {
            get { return _ordernumber; }
            set { _ordernumber = value; }
        }
        private string _partnumber;
        [DataMember]
        public string PartNumber
        {
            get { return _partnumber; }
            set { _partnumber = value; }
        }
        private decimal  _price;
        [DataMember]

        public decimal Price
        {
            get => _price;
            set => _price = value;
        }

        private string _currencyCode;
        [DataMember]

        public string CurrencyCode
        {
            get => _currencyCode;
            set => _currencyCode = value;
        }
        private string _remarks;
        [DataMember]

        public string Remarks
        {
            get => _remarks;
            set => _remarks = value;
        }

    }
}
