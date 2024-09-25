/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  ManualDemandDocumentDataEntryModel.cs
Function           :  
Created By         :   Anmol Jain
Created on         :   19-April-2022
Revision History   :   [12-May-2022] : Sejal Srivastava
*                  :   [] : Added UnloadingPoint
*                  :   [25-May-2022] : Sejal Srivastava
*                  :   [] : Added new parameter Status
*                  :   [30-May-2022] : Ranjay
*                  :   [] : Added new class ManualDemandDocumentDataEntryUploadModel, ManualDemandDocumentDataEntryErrorModel
*                  :   [06-June-2022] : Sejal Srivastava
*                  :   [] : Added new parameter IsCallingFromParent to handle background colour change of child screen
*                  :   [16-Jun-2022] : Ranjay
*                  :   [] : Added new field CustomerBusinessGroupGuid
*                  :   [30-Aug-2022] : Sejal Srivastava
*                  :   [] : Changes w.r.t allowing entry of data at family level, i.e added documentType, familyName
*                  :   [04-Apr-2022] : Ranjay
*                  :   [HD-00377175] Added new field ProjectName, ProjectGuid
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
    [DataContract, Serializable]
    public class ManualDemandDocumentDataEntryModel : BaseModel<Guid>
    {
        private Guid _manualDemandDocumentDataEntryGuid;
        /// <summary>
        /// ManualDemandDocumentDataEntryGuid
        /// </summary>
        [DataMember]
        public Guid ManualDemandDocumentDataEntryGuid
        {
            get => _manualDemandDocumentDataEntryGuid;
            set => SetProperty(ref _manualDemandDocumentDataEntryGuid, value);
        }

        /// <summary>
        /// Local variable _partNumber     
        /// </summary>
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>

        [DataMember]
        [StringLength(18)]
        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }

        /// <summary>
        /// Local variable _familyGuid     
        /// </summary>
        private Guid _familyGuid;
        /// <summary>
        /// Get or Set for {Family}.
        /// </summary>

        [DataMember]
        public Guid FamilyGuid
        {
            get => _familyGuid;
            set => SetProperty(ref _familyGuid, value);
        }

        /// <summary>
        /// Local variable _familyName     
        /// </summary>
        private string _familyName;
        /// <summary>
        /// Get or Set for {Family}.
        /// </summary>

        [DataMember]
        public string FamilyName
        {
            get => _familyName;
            set => SetProperty(ref _familyName, value);
        }

        /// <summary>
        /// Local variable _Date     
        /// </summary>
        private DateTime _demandDate;
        /// <summary>
        /// Get or Set for {Date}.
        /// </summary>
        [DataMember]
        public DateTime DemandDate
        {
            get => _demandDate;
            set => SetProperty(ref _demandDate, value);
        }

        /// <summary>
        /// Local variable _EDI     
        /// </summary>
        private int _ediDemandQuantity;
        /// <summary>
        /// Get or Set for {EDI}.
        /// </summary>
        [DataMember]
        public int EdiDemandQuantity
        {
            get => _ediDemandQuantity;
            set => SetProperty(ref _ediDemandQuantity, value);
        }

        /// <summary>
        /// Local variable _EDI     
        /// </summary>
        private int _manualDemandQuantity;
        /// <summary>
        /// Get or Set for {EDI}.
        /// </summary>
        [DataMember]
        public int ManualDemandQuantity
        {
            get => _manualDemandQuantity;
            set => SetProperty(ref _manualDemandQuantity, value);
        }

        /// <summary>
        /// Local variable _ManualDemandDocumentGuid
        /// </summary>
        private Guid? _manualDemandDocumentGuid;
        /// <summary>
        /// Get or Set for {ManualDemandDocumentGuid}.
        /// </summary>
        [DataMember]
        public Guid? ManualDemandDocumentGuid
        {
            get => _manualDemandDocumentGuid;
            set => _manualDemandDocumentGuid = value;
        }


        public class GetDocumentEDICollection
        {
            // <summary>
            /// Local variable _DocumentId
            /// </summary>
            private string _documentId;
            /// <summary>
            /// Get or Set for {DocumentId}.
            /// </summary>
            [DataMember]
            public string DocumentId
            {
                get => _documentId;
                set => _documentId = value;
            }

            ///// <summary>
            ///// Local variable _fromDate
            ///// </summary>
            //private DateTime _fromDate;
            ///// <summary>
            ///// Get or Set for {FromDate}.
            ///// </summary>
            //[DataMember, DataType(DataType.DateTime)]
            //public DateTime FromDate
            //{
            //    get => _fromDate;
            //    set => _fromDate = value;
            //}


            /// <summary>
            /// Local variable _fromDate
            /// </summary>
            private string _fromDate;
            /// <summary>
            /// Get or Set for {FromDate}.
            /// </summary>
           //
            public string FromDate
            {
                get => _fromDate;
                set => _fromDate = value;
            }

            /// <summary>
            /// Local variable _toDate
            /// </summary>
            private string _toDate;
            /// <summary>
            /// Get or Set for {ToDate}.
            /// </summary>
            public string ToDate
            {
                get => _toDate;
                set => _toDate = value;
            }

            // <summary>
            /// Local variable id this is the id of ManualDemandDocumentDesign
            /// </summary>
            private Guid _id;
            /// <summary>
            /// Get or Set for {Id}.
            /// </summary>
            [DataMember]
            public Guid Id
            {
                get => _id;
                set => _id = value;
            }

            // <summary>
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

            // <summary>
            /// Local variable id this is the id of Customer
            /// </summary>
            private Guid _customerid;
            /// <summary>
            /// Get or Set for {Id}.
            /// </summary>
            [DataMember]
            public Guid Customerid
            {
                get => _customerid;
                set => _customerid = value;
            }

            // <summary>
            /// Local variable _customerDeliveryPoint
            /// </summary>
            private string _customerDeliveryPoint;
            /// <summary>
            /// Get or Set for {CustomerDeliveryPoint}.
            /// </summary>
            [DataMember]
            public string CustomerDeliveryPoint
            {
                get => _customerDeliveryPoint;
                set => _customerDeliveryPoint = value;
            }

            // <summary>
            /// Local variable id this is the id of CustomerDeliveryPoint
            /// </summary>
            private Guid _customerDeliveryPointId;
            /// <summary>
            /// Get or Set for {CustomerDeliveryPointId}.
            /// </summary>
            [DataMember]
            public Guid CustomerDeliveryPointId
            {
                get => _customerDeliveryPointId;
                set => _customerDeliveryPointId = value;
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
            /// Local variable _status     
            /// </summary>
            private string _status;
            /// <summary>
            /// Get or Set for {Status}.
            /// </summary>
            [DataMember]
            public string Status
            {
                get => _status;
                set => _status = value;
            }


            /// <summary>
            /// Local variable _isCallingFromParent     
            /// </summary>
            private string _isCallingFromParent;
            /// <summary>
            /// Get or Set for {IsCallingFromParent}.
            /// </summary>
            [DataMember]
            public string IsCallingFromParent
            {
                get => _isCallingFromParent;
                set => _isCallingFromParent = value;
            }

            // <summary>
            /// Local variable _CustomerBusinessGroupGuid
            /// </summary>
            private Guid _CustomerBusinessGroupGuid;
            /// <summary>
            /// Get or Set for {CustomerBusinessGroupGuid}.
            /// </summary>
            [DataMember]
            public Guid CustomerBusinessGroupGuid
            {
                get => _CustomerBusinessGroupGuid;
                set => _CustomerBusinessGroupGuid = value;
            }

            /// <summary>
            /// Local variable _documentType     
            /// </summary>
            private string _documentType;
            /// <summary>
            /// Get or Set for {DocumentType}.
            /// </summary>
            [DataMember]
            public string DocumentType
            {
                get => _documentType;
                set => _documentType = value;
            }

            /// <summary>
            /// Local variable _projectName     
            /// </summary>
            private string _projectName;
            /// <summary>
            /// Get or Set for {ProjectName}.
            /// </summary>
            [DataMember]
            public string ProjectName
            {
                get => _projectName;
                set => _projectName = value;
            }

            /// <summary>
            /// Local variable _projectGuid 
            /// </summary>
            private Guid _projectGuid;
            /// <summary>
            /// Get or Set for {ProjectGuid}.
            /// </summary>
            [DataMember]
            public Guid ProjectGuid
            {
                get => _projectGuid;
                set => _projectGuid = value;
            }
        }

    }

    [DataContract, Serializable]
    public class ManualDemandDocumentDataEntryProcedureParametersModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _ManualDemandDocumentGuid
        /// </summary>
        private Guid? _manualDemandDocumentGuid;
        /// <summary>
        /// Get or Set for {ManualDemandDocumentGuid}.
        /// </summary>
        [DataMember]
        public Guid? ManualDemandDocumentGuid
        {
            get => _manualDemandDocumentGuid;
            set => _manualDemandDocumentGuid = value;
        }

        /// <summary>
        /// Local variable _Option
        /// </summary>
        private string _option;
        /// <summary>
        /// Get or Set for {Option}.
        /// </summary>
        [DataMember]
        public string Option
        {
            get => _option;
            set => _option = value;
        }

        /// <summary>
        /// Local variable _RequestReason
        /// </summary>
        private string _requestReason;
        /// <summary>
        /// Get or Set for {RequestReason}.
        /// </summary>
        [DataMember]
        public string RequestReason
        {
            get => _requestReason;
            set => _requestReason = value;
        }

    }

    [DataContract, Serializable]
    public class ManualDemandDocumentDataEntryUploadModel : BaseModel<Guid>
    {
        // <summary>
        /// Local variable _manualDemandDocumentGuid
        /// </summary>
        private Guid _manualDemandDocumentGuid;
        /// <summary>
        /// Get or Set for {ManualDemandDocumentGuid}.
        /// </summary>
        [DataMember]
        public Guid ManualDemandDocumentGuid
        {
            get => _manualDemandDocumentGuid;
            set => _manualDemandDocumentGuid = value;
        }

        /// <summary>
        /// Local variable _partNumber     
        /// </summary>
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>

        [DataMember]
        [StringLength(18)]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }

        /// <summary>
        /// Local variable _familyName     
        /// </summary>
        private string _familyName;
        /// <summary>
        /// Get or Set for {Family}.
        /// </summary>
        [DataMember]
        public string FamilyName
        {
            get => _familyName;
            set => SetProperty(ref _familyName, value);
        }

        /// <summary>
        /// Local variable _Date     
        /// </summary>
        private DateTime _demandDate;
        /// <summary>
        /// Get or Set for {Date}.
        /// </summary>
        [DataMember]
        public DateTime DemandDate
        {
            get => _demandDate;
            set => _demandDate = value;
        }

        /// <summary>
        /// Local variable _EDI     
        /// </summary>
        private int _manualDemandQuantity;
        /// <summary>
        /// Get or Set for {EDI}.
        /// </summary>
        [DataMember]
        public int ManualDemandQuantity
        {
            get => _manualDemandQuantity;
            set => _manualDemandQuantity = value;
        }

    }

    [DataContract, Serializable]
    public class ManualDemandDocumentDataEntryErrorModel
    {
        // <summary>
        /// Local variable _DocumentId
        /// </summary>
        private string _DocumentId;
        /// <summary>
        /// Get or Set for {DocumentId}.
        /// </summary>
        [DataMember]
        public string DocumentId
        {
            get => _DocumentId;
            set => _DocumentId = value;
        }

        /// <summary>
        /// Local variable _partNumber     
        /// </summary>
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>

        [DataMember]
        [StringLength(18)]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }

        /// <summary>
        /// Local variable _familyName     
        /// </summary>
        private string _familyName;
        /// <summary>
        /// Get or Set for {Family}.
        /// </summary>
        [DataMember]
        public string FamilyName
        {
            get => _familyName;
            set => _familyName = value;
        }

        /// <summary>
        /// Local variable _demandDate     
        /// </summary>
        private DateTime _demandDate;
        /// <summary>
        /// Get or Set for {DemandDate}.
        /// </summary>
        [DataMember]
        public DateTime DemandDate
        {
            get => _demandDate;
            set => _demandDate = value;
        }

        /// <summary>
        /// Local variable _ManualQuantity     
        /// </summary>
        private int _ManualQuantity;
        /// <summary>
        /// Get or Set for {ManualQuantity}.
        /// </summary>
        [DataMember]
        public int ManualQuantity
        {
            get => _ManualQuantity;
            set => _ManualQuantity = value;
        }

        // <summary>
        /// Local variable _Errors
        /// </summary>
        private string _Errors;
        /// <summary>
        /// Get or Set for {Errors}.
        /// </summary>
        [DataMember]
        public string Errors
        {
            get => _Errors;
            set => _Errors = value;
        }
    }

}
