/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   BusinessUnitManufacturingWebServiceModel.cs
Function           :   Business Unit Manufacturing Web Service
Created By         :   Shivam Dhingra
Created on         :   17-Feb-2021
Revision History   :   
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    /// <summary>
    /// Data Contract for BusinessUnitManufacturingWebServiceModel
    /// </summary>
    [DataContract, Serializable]
    public class BusinessUnitManufacturingWebServiceModel
    {
        /// <summary>
        /// Local Reference of _businessUnitCode
        /// </summary>
        private string _businessUnitCode;
        /// <summary>
        /// Get or Sets the value of {BusinessUnitCode} 
        /// </summary>
        [DataMember]
        public string BusinessUnitCode
        {
            get { return _businessUnitCode; }
            set { _businessUnitCode = value; }
        }

        /// <summary>
        /// Local Reference of _businessUnitName
        /// </summary>
        private string _businessUnitName;
        /// <summary>
        /// Get or Sets the value of {BusinessUnitName} 
        /// </summary>
        [DataMember]
        public string BusinessUnitName
        {
            get { return _businessUnitName; }
            set { _businessUnitName = value; }
        }

        /// <summary>
        /// Local Reference of _businessUnitTypeName
        /// </summary>
        private string _businessUnitTypeName;
        /// <summary>
        /// Get or Sets the value of {BusinessUnitTypeName} 
        /// </summary>
        [DataMember]
        public string BusinessUnitTypeName
        {
            get { return _businessUnitTypeName; }
            set { _businessUnitTypeName = value; }
        }

        /// <summary>
        /// Local Reference of _country
        /// </summary>
        private string _country;
        /// <summary>
        /// Get or Sets the value of {Country} 
        /// </summary>
        [DataMember]
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        /// <summary>
        /// Local Reference of _active
        /// </summary>
        private bool _active;
        /// <summary>
        /// Get or Sets the value of {Active} 
        /// </summary>
        [DataMember]
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

    }
}
