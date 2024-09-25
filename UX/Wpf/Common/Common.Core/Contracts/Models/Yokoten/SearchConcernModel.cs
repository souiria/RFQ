/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SearchConcernModel.cs
Function           :   Search Concern Model
Created By         :   Prakhar
Created on         :   02-August-2022
Revision History   :   [25-August-2022]
                   :   Added new models for concern and audit search.
                   :   [17-Oct-2022]
                   :   Added new property ProcessType.

****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Yokoten
{
    /// <summary>
    /// Data Contract use for SearchConcernModel Service
    /// </summary>
    [DataContract, Serializable]
    public class SearchConcernModel
    {

        private Guid _id;

        /// get or set for id
        [DataMember]
        [StringLength(20)]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        private string _recordNo;
        /// <summary>
        /// Get or Set for {recordnumber}.
        /// </summary>
        [DataMember]
        public string RecordNo
        {
            get => _recordNo;
            set => _recordNo = value;
        }
    }

    [DataContract, Serializable]
    public class SearchConcernModelFilter
    {


        private string _recordNumber;
        /// <summary>
        /// Get or Set for {recordnumber}.
        /// </summary>
        [DataMember]
        public string RecordNumber
        {
            get => _recordNumber;
            set => _recordNumber = value;
        }

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

        private Guid _concerGuid;
        /// <summary>
        /// Get or Set for {ConcerGuid}.
        /// </summary>
        [DataMember]
        public Guid ConcerGuid
        {
            get => _concerGuid;
            set => _concerGuid = value;
        }

        private string _product;
        /// <summary>
        /// Get or Set for {Product}.
        /// </summary>
        [DataMember]
        public string Product
        {
            get => _product;
            set => _product = value;
        }

        private Guid _siteGuid;
        /// <summary>
        /// Get or Set for {SiteGuid}.
        /// </summary>
        [DataMember]
        public Guid SiteGuid
        {
            get => _siteGuid;
            set => _siteGuid = value;
        }

        private string _ciresNumber;
        /// <summary>
        /// Get or Set for {CiresNumber}.
        /// </summary>
        [DataMember]
        public string CiresNumber
        {
            get => _ciresNumber;
            set => _ciresNumber = value;
        }

        private string _supplier;
        /// <summary>
        /// Get or Set for {Supplier}.
        /// </summary>
        [DataMember]
        public string Supplier
        {
            get => _supplier;
            set => _supplier = value;
        }

        private Guid _businessGuid;
        /// <summary>
        /// Get or Set for {BusinessGuid}.
        /// </summary>
        [DataMember]
        public Guid BusinessGuid
        {
            get => _businessGuid;
            set => _businessGuid = value;
        }

        private string _troubleFlashNumber;
        /// <summary>
        /// Get or Set for {TroubleFlashNumber}.
        /// </summary>
        [DataMember]
        public string TroubleFlashNumber
        {
            get => _troubleFlashNumber;
            set => _troubleFlashNumber = value;
        }

        private string _componentNumber;
        /// <summary>
        /// Get or Set for {ComponentNumber}.
        /// </summary>
        [DataMember]
        public string ComponentNumber
        {
            get => _componentNumber;
            set => _componentNumber = value;
        }

        private string _processText;
        /// <summary>
        /// Get or Set for {ProcessText}.
        /// </summary>
        [DataMember]
        public string ProcessText
        {
            get => _processText;
            set => _processText = value;
        }

        private string _processType;
        /// <summary>
        /// Get or Set for {ProcessType}.
        /// </summary>
        [DataMember]
        public string ProcessType
        {
            get => _processType;
            set => _processType = value;
        }

        private string _systemText;
        /// <summary>
        /// Get or Set for {SystemText}.
        /// </summary>
        [DataMember]
        public string SystemText
        {
            get => _systemText;
            set => _systemText = value;
        }



    }

    [DataContract, Serializable]
    public class DisplayConcernModelFilter
    {


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

        private Guid _section1Guid;
        /// <summary>
        /// Get or Set for {Section1Guid}.
        /// </summary>
        [DataMember]
        public Guid Section1Guid
        {
            get => _section1Guid;
            set => _section1Guid = value;
        }

        private Guid _section2Guid;
        /// <summary>
        /// Get or Set for {Section2Guid}.
        /// </summary>
        [DataMember]
        public Guid Section2Guid
        {
            get => _section2Guid;
            set => _section2Guid = value;
        }



        private string _recordNo;
        /// <summary>
        /// Get or Set for {RecordNo}.
        /// </summary>
        [DataMember]
        public string RecordNo
        {
            get => _recordNo;
            set => _recordNo = value;
        }

        private string _createdDate;
        /// <summary>
        /// Get or Set for {RecordNo}.
        /// </summary>
        [DataMember]
        public string CreatedDate
        {
            get => _createdDate;
            set => _createdDate = value;
        }

        private string _product;
        /// <summary>
        /// Get or Set for {Product}.
        /// </summary>
        [DataMember]
        public string Product
        {
            get => _product;
            set => _product = value;
        }

        private string _customer;
        /// <summary>
        /// Get or Set for {Customer}.
        /// </summary>
        [DataMember]
        public string Customer
        {
            get => _customer;
            set => _customer = value;
        }


        private string _ciresNo;
        /// <summary>
        /// Get or Set for {CiresNo}.
        /// </summary>
        [DataMember]
        public string CiresNo
        {
            get => _ciresNo;
            set => _ciresNo = value;
        }

        private string _sWSSite;
        /// <summary>
        /// Get or Set for {SWSSite}.
        /// </summary>
        [DataMember]
        public string SWSSite
        {
            get => _sWSSite;
            set => _sWSSite = value;
        }



        private string _troubleFlashReportNo;
        /// <summary>
        /// Get or Set for {recordnumber}.
        /// </summary>
        [DataMember]
        public string TroubleFlashReportNo
        {
            get => _troubleFlashReportNo;
            set => _troubleFlashReportNo = value;
        }

        private string _concern;
        /// <summary>
        /// Get or Set for {recordnumber}.
        /// </summary>
        [DataMember]
        public string Concern
        {
            get => _concern;
            set => _concern = value;
        }

        private string _supplier;
        /// <summary>
        /// Get or Set for {recordnumber}.
        /// </summary>
        [DataMember]
        public string Supplier
        {
            get => _supplier;
            set => _supplier = value;
        }

        private string _customerpartno;
        /// <summary>
        /// Get or Set for {recordnumber}.
        /// </summary>
        [DataMember]
        public string Customerpartno
        {
            get => _customerpartno;
            set => _customerpartno = value;
        }



    }


    [DataContract, Serializable]
    public class SearchAuditModelFilter
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

        private Guid _concernLocationGuid;
        /// <summary>
        /// Get or Set for {ConcernLocationGuid}.
        /// </summary>
        [DataMember]
        public Guid ConcernLocationGuid
        {
            get => _concernLocationGuid;
            set => _concernLocationGuid = value;
        }

        private string _recordNumber;
        /// <summary>
        /// Get or Set for {RecordNumber}.
        /// </summary>
        [DataMember]
        public string RecordNumber
        {
            get => _recordNumber;
            set => _recordNumber = value;
        }

        private Guid _auditTypeGuid;
        /// <summary>
        /// Get or Set for {AuditTypeGuid}.
        /// </summary>
        [DataMember]
        public Guid AuditTypeGuid
        {
            get => _auditTypeGuid;
            set => _auditTypeGuid = value;
        }


        private Guid _auditStandardSectionGuid;
        /// <summary>
        /// Get or Set for {AuditStandardSectionGuid}.
        /// </summary>
        [DataMember]
        public Guid AuditStandardSectionGuid
        {
            get => _auditStandardSectionGuid;
            set => _auditStandardSectionGuid = value;
        }


        private Guid _auditNameGuid;
        /// <summary>
        /// Get or Set for {AuditNameGuid}.
        /// </summary>
        [DataMember]
        public Guid AuditNameGuid
        {
            get => _auditNameGuid;
            set => _auditNameGuid = value;
        }

        private string _auditGrade;
        /// <summary>
        /// Get or Set for {AuditGrade}.
        /// </summary>
        [DataMember]
        public string AuditGrade
        {
            get => _auditGrade;
            set => _auditGrade = value;
        }


        private string _processText;
        /// <summary>
        /// Get or Set for {ProcessText}.
        /// </summary>
        [DataMember]
        public string ProcessText
        {
            get => _processText;
            set => _processText = value;
        }

        private string _systemText;
        /// <summary>
        /// Get or Set for {SystemText}.
        /// </summary>
        [DataMember]
        public string SystemText
        {
            get => _systemText;
            set => _systemText = value;
        }


        private string _iTAF;
        /// <summary>
        /// Get or Set for {ITAF}.
        /// </summary>
        [DataMember]
        public string ITAF
        {
            get => _iTAF;
            set => _iTAF = value;
        }


        private string _auditPrimaryProcess;
        /// <summary>
        /// Get or Set for {AuditPrimaryProcess}.
        /// </summary>
        [DataMember]
        public string AuditPrimaryProcess
        {
            get => _auditPrimaryProcess;
            set => _auditPrimaryProcess = value;
        }




    }

    [DataContract, Serializable]
    public class DisplayAuditModelFilter
    {
        private Guid _id;
        /// <summary>
        /// Get or Set for {AuditNameGuid}.
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        private Guid _section1Guid;
        /// <summary>
        /// Get or Set for {Section1Guid}.
        /// </summary>
        [DataMember]
        public Guid Section1Guid
        {
            get => _section1Guid;
            set => _section1Guid = value;
        }

        private Guid _section2Guid;
        /// <summary>
        /// Get or Set for {Section2Guid}.
        /// </summary>
        [DataMember]
        public Guid Section2Guid
        {
            get => _section2Guid;
            set => _section2Guid = value;
        }

        private Guid _section3Guid;
        /// <summary>
        /// Get or Set for {Section3Guid}.
        /// </summary>
        [DataMember]
        public Guid Section3Guid
        {
            get => _section3Guid;
            set => _section3Guid = value;
        }

        private string _recordNo;
        /// <summary>
        /// Get or Set for {RecordNo}.
        /// </summary>
        [DataMember]
        public string RecordNo
        {
            get => _recordNo;
            set => _recordNo = value;
        }

        private string _createdDate;
        /// <summary>
        /// Get or Set for {RecordNo}.
        /// </summary>
        [DataMember]
        public string CreatedDate
        {
            get => _createdDate;
            set => _createdDate = value;
        }

        private string _auditTypeDescription;
        /// <summary>
        /// Get or Set for {AuditTypeDescription}.
        /// </summary>
        [DataMember]
        public string AuditTypeDescription
        {
            get => _auditTypeDescription;
            set => _auditTypeDescription = value;
        }

        private string _concernLocation;
        /// <summary>
        /// Get or Set for {ConcernLocation}.
        /// </summary>
        [DataMember]
        public string ConcernLocation
        {
            get => _concernLocation;
            set => _concernLocation = value;
        }

        private string _standardSectionsDescription;
        /// <summary>
        /// Get or Set for {StandardSectionsDescription}.
        /// </summary>
        [DataMember]
        public string StandardSectionsDescription
        {
            get => _standardSectionsDescription;
            set => _standardSectionsDescription = value;
        }

        private string _auditNameDescription;
        /// <summary>
        /// Get or Set for {AuditNameDescription}.
        /// </summary>
        [DataMember]
        public string AuditNameDescription
        {
            get => _auditNameDescription;
            set => _auditNameDescription = value;
        }

        private string _auditGrade;
        /// <summary>
        /// Get or Set for {AuditNameDescription}.
        /// </summary>
        [DataMember]
        public string AuditGrade
        {
            get => _auditGrade;
            set => _auditGrade = value;
        }















    }
}