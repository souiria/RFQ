/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EDIMessageMissingCustomerPartModel.cs
Function           :  
Created By         :   Shahab Ashraf
Created on         :   05-Aug-2021
Revision History   :   [28-Sep-2021] : Shivam Kalia
                   :   Added new class EDIMessageMissingCustomerPartProcedureParamterModel
                   :   [21-Oct-2021] : Shivam Kalia
                   :   Modified EDIMessageMissingCustomerPartByProcedure method for Selected Export values
                   :   [20-Sep-2022] : Prakhar Singh
                   :   Added new property customername,UNBsender,UnloadingPoint
                   :   [30-Oct-2023] : Virendra
                   :   [00391154]:Added new property UserGuid in the EDIMessageMissingCustomerPartProcedureParamterModel 
                   :   [01-Nov-2023] : Virendra
                   :   [00395769]:Added new property 'CustomerBusinessGroupGuid || CustomerGuid' in the EDIMessageMissingCustomerPartProcedureParamterModel 
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract use for EDIMessageMissingCustomerPart Service
    /// </summary>
    [DataContract, Serializable]
    public class EDIMessageMissingCustomerPartModel
    {
        /// <summary>
        /// Local variable _customerName     
        /// </summary>
        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value;
        }

        /// <summary>
        /// Local variable _uNBSenderId     
        /// </summary>
        private string _uNBSenderId;
        /// <summary>
        /// Get or Set for {UNBSenderID}.
        /// </summary>
        [DataMember]
        public string UNBSenderID
        {
            get => _uNBSenderId;
            set => _uNBSenderId = value;
        }

        /// <summary>
        /// Local variable _unloadingPoint     
        /// </summary>
        private string _unloadingPoint;
        /// <summary>
        /// Get or Set for {UnloadingPoint}.
        /// </summary>
        [DataMember]
        public string UnloadingPoint
        {
            get => _unloadingPoint;
            set => _unloadingPoint = value;
        }


        /// <summary>
        /// Local variable _partNumber     
        /// </summary>
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }



        /// <summary>
        /// Data Contract use for EDIMessageMissingCustomerPart Service
        /// </summary>
        [DataContract, Serializable]
        public class EDIMessageMissingCustomerPartProcedureParamterModel
        {
            private DateTime _dateTo;
            /// <summary>
            /// Get or Set for {DateTo}.
            /// </summary>
            [DataMember]
            public DateTime DateTo
            {
                get => _dateTo;
                set => _dateTo = value;
            }

            private DateTime _dateFrom;
            /// <summary>
            /// Get or Set for {DateFrom}.
            /// </summary>
            [DataMember]
            public DateTime DateFrom
            {
                get => _dateFrom;
                set => _dateFrom = value;
            }

            private string _UnloadingPoint;
            /// <summary>
            /// Get or Set for {UnloadingPoint}.
            /// </summary>
            [DataMember]
            public string UnloadingPoint
            {
                get => _UnloadingPoint;
                set => _UnloadingPoint = value;
            }

            private string _UNBSenderID;
            /// <summary>
            /// Get or Set for {UnloadingPoint}.
            /// </summary>
            [DataMember]
            public string UNBSenderID
            {
                get => _UNBSenderID;
                set => _UNBSenderID = value;
            }

            private string _FileName;
            /// <summary>
            /// Get or Set for {FileName}.
            /// </summary>
            [DataMember]
            public string FileName
            {
                get => _FileName;
                set => _FileName = value;
            }

            private Guid _UserGuid;
            /// <summary>
            /// Get or Set for {UserGuid}.
            /// </summary>
            [DataMember]
            public Guid UserGuid
            {
                get => _UserGuid;
                set => _UserGuid = value;
            }
            /// <summary>
            /// Local variable _customerBusinessGroupGuid     
            /// </summary>
            private Guid? _customerBusinessGroupGuid;
            /// <summary>
            /// Get or Set for {CustomerBusinessGroupGuid}.
            /// </summary>
            [DataMember]
            public Guid? CustomerBusinessGroupGuid 
            {
                get => _customerBusinessGroupGuid;
                set => _customerBusinessGroupGuid = value;
            }
            /// <summary>
            /// Local variable _customerGuid     
            /// </summary>
            private Guid? _customerGuid;
            /// <summary>
            /// Get or Set for {CustomerGuid}.
            /// </summary>
            [DataMember]
            public Guid? CustomerGuid
            {
                get => _customerGuid;
                set => _customerGuid = value;
            }
        }
    }
}
