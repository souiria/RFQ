/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplierSelectionSearchModel.cs
Function           :   Supplier Selection filter model
Created By         :   Dharmendra 
Created on         :   15-Jun-2022
Revision History   :   [] :
****************************************************************************************************/
using System;
using System.Runtime.Serialization;


namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
   public class SupplierSelectionSearchModel
    {
        private string _supplierCode = string.Empty;
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }
        
        private string _materialNumber = string.Empty;
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }
        private string _businessUnitCode;
        [DataMember]
       
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set =>  _businessUnitCode= value;
        }
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set =>  _isActive= value;
        }
    }
}
