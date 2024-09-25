/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplierCapacityPlanningSearchModel.cs
Function           :   Data contract for Model to search data from CPD FC Annual Master
Created By         :   Pawan Kumar
Created on         :   29-Jul-2019
Revision History   :   [11-Sep-2020] :Pawan
                   :   [] : Added field for BusinessUnitCode , Supplier Code and Customer
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// Model to search data from CPD FC Annual Master
    /// </summary>
    [DataContract, Serializable]
    public class SupplierCapacityPlanningSearchModel
    {
        private Guid _businessUnit;
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnit;
            set => _businessUnit = value;
        }
        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => _supplierGuid = value;
        }
        private Guid _materialFromGuid;
        [DataMember]
        public Guid MaterialFromGuid
        {
            get => _materialFromGuid;
            set => _materialFromGuid = value;
        }
        private Guid _materialToGuid;
        [DataMember]
        public Guid MaterialToGuid
        {
            get => _materialToGuid;
            set => _materialToGuid = value;
        }
        private List<Guid> _customersGuid;
        [DataMember]
        public List<Guid> CustomersGuid
        {
            get => _customersGuid;
            set => _customersGuid = value;
        }
        private List<Guid> _vehiclesGuid;
        [DataMember]
        public List<Guid> VehiclesGuid
        {
            get => _vehiclesGuid;
            set => _vehiclesGuid = value;
        }
        private string _isShowFacility;
        [DataMember]
        public string IsShowFacility
        {
            get => _isShowFacility;
            set => _isShowFacility = value;
        }
        private int _noOfMonth;
        [DataMember]
        public int NoOfMonth
        {
            get => _noOfMonth;
            set => _noOfMonth = value;
        }
        private string _materialFromNumber = string.Empty;
        [DataMember]
        public string MaterialFromNumber
        {
            get => _materialFromNumber;
            set => _materialFromNumber = value;
        }
        private string _materialToNumber = string.Empty;
        [DataMember]
        public string MaterialToNumber
        {
            get => _materialToNumber;
            set => _materialToNumber = value;
        }
        private string _businessUnitCode = string.Empty;
        /// <summary>
        /// Parameter to receive value of Business Unit selected
        /// </summary>
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => _businessUnitCode = value;
        }
        private string _supplierCode = string.Empty;
        /// <summary>
        /// Parameter to receive value of Supplier selected
        /// </summary>
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }
        private List<string> _customersName;
        /// <summary>
        /// Parameter to receive value of Customer selected
        /// </summary>
        [DataMember]
        public List<string> CustomersName
        {
            get => _customersName;
            set => _customersName = value;
        }

        private List<string> _vehicleName;
        /// <summary>
        /// Parameter to receive value of Vehicle selected
        /// </summary>
        [DataMember]
        public List<string> VehicleName
        {
            get => _vehicleName;
            set => _vehicleName = value;
        }
    }
}