/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ConfirmationModel.cs
Function           :   Data contract for ConfirmationModel
Created By         :   Srashti Gupta
Created on         :   06-May-2020
RevisionHistory    :   [06-May-2020] : Pawan
                   :   [] : Added more properties for Report Section 2
                   :   [03-Jun-2020] : Shivam Dhingra
                   :   [] : Added Columns to get data from ReportSection
                   :   [12-Jun-2020] : Pawan
                   :   [] : Added Columns to get data from Yokoten Status Settings
                   :   [20-Jun-2020] : Srashti
*                  :   Added field for RootCause, CounterMeasure & remove existing fields
                   :   [25-Jun-2020] : Pawan
*                  :   Added field for Section3 Guid
                   :   [07-Aug-2020] : Pawan
*                  :   Added field for Audit Type Guid
                   :   [01-Sep-2020] : Pawan
*                  :   Added field for Is Audit
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Yokoten
{
    [DataContract, Serializable]
    public class ConfirmationModel : BaseModel<Guid>
    {

        private Guid _section1Guid;
        /// <summary>
        /// This field will set Section1Guid
        /// </summary>
        [DataMember]
        [Required]
        public Guid Section1Guid
        {
            get => _section1Guid;
            set => SetProperty(ref _section1Guid, value);
        }
        private Guid? _section2Guid;
        /// <summary>
        /// This field will set Section2Guid
        /// </summary>
        [DataMember]
        [Required]
        public Guid? Section2Guid
        {
            get => _section2Guid;
            set => SetProperty(ref _section2Guid, value);
        }
        private Guid? _section3Guid;
        /// <summary>
        /// This field will set Section3Guid
        /// </summary>
        [DataMember]
        public Guid? Section3Guid
        {
            get => _section3Guid;
            set => SetProperty(ref _section3Guid, value);
        }
        private Guid _qualityConcernId;
        /// <summary>
        /// This field will set QualityConcernId
        /// </summary>
        [DataMember]
        [Required]
        public Guid QualityConcernId
        {
            get => _qualityConcernId;
            set => SetProperty(ref _qualityConcernId, value);
        }

        private string _concern;
        /// <summary>
        /// Get or Set for Concern.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Concern
        {
            get => _concern;
            set => SetProperty(ref _concern, value);
        }
        private string _yokotenNumber;
        /// <summary>
        /// This field will set YokotenNumber
        /// </summary>
        [DataMember]
        [StringLength(40)]
        public string YokotenNumber
        {
            get => _yokotenNumber;
            set => SetProperty(ref _yokotenNumber, value);
        }

        private string _defectDetails;
        /// <summary>
        /// This field will set DefectDetails
        /// </summary>
        [DataMember]
        [StringLength(200)]
        public string DefectDetails
        {
            get => _defectDetails;
            set => SetProperty(ref _defectDetails, value);
        }

        private string _functionProblem;
        /// <summary>
        /// This field will set FunctionProblem
        /// </summary>
        [DataMember]
        [StringLength(200)]
        public string FunctionProblem
        {
            get => _functionProblem;
            set => SetProperty(ref _functionProblem, value);
        }

        private string _raisedBy;
        /// <summary>
        /// This field will set RaisedBy
        /// </summary>
        [DataMember]
        public string RaisedBy
        {
            get => _raisedBy;
            set => SetProperty(ref _raisedBy, value);
        }

        private DateTime? _raisedDate;
        /// <summary>
        /// This field will set RaisedDate
        /// </summary>
        [DataMember]
        public DateTime? RaisedDate
        {
            get => _raisedDate;
            set => SetProperty(ref _raisedDate, value);
        }

        private string _liability;
        /// <summary>
        /// This field will set Liability
        /// </summary>
        [DataMember]
        [StringLength(200)]
        public string Liability
        {
            get => _liability;
            set => SetProperty(ref _liability, value);
        }

        private string _customer;
        /// <summary>
        /// This field will set Customer
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }
        private string _model;
        /// <summary>
        /// This field will set Model
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Model
        {
            get => _model;
            set => SetProperty(ref _model, value);
        }
        private string _harnessFamily;
        /// <summary>
        /// This field will set HarnessFamily
        /// </summary>
        [DataMember]
        [StringLength(200)]
        public string HarnessFamily
        {
            get => _harnessFamily;
            set => SetProperty(ref _harnessFamily, value);
        }

        private string _ciresNo;
        /// <summary>
        /// This field will set CiresNo
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string CiresNo
        {
            get => _ciresNo;
            set => SetProperty(ref _ciresNo, value);
        }

        private string _swsSite;
        /// <summary>
        /// This field will set SwSSite
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string SwSSite
        {
            get => _swsSite;
            set => SetProperty(ref _swsSite, value);
        }

        private DateTime _replyDate;
        /// <summary>
        /// This field will set ReplyDate
        /// </summary>
        [DataMember]
        [Required]
        public DateTime ReplyDate
        {
            get => _replyDate;
            set => SetProperty(ref _replyDate, value);
        }

        private string _componentProblem;
        /// <summary>
        /// This field will set ComponentProblem
        /// </summary>
        [DataMember]
        [StringLength(200)]
        public string ComponentProblem
        {
            get => _componentProblem;
            set => SetProperty(ref _componentProblem, value);
        }

        private string _supplier;
        /// <summary>
        /// This field will set Supplier
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Supplier
        {
            get => _supplier;
            set => SetProperty(ref _supplier, value);
        }

        private List<string> _siteswhereused;
        /// <summary>
        /// This field will set Siteswhereused
        /// </summary>
        [DataMember]
        public List<string> Siteswhereused
        {
            get => _siteswhereused;
            set => SetProperty(ref _siteswhereused, value);
        }

        private string _productpartno;
        /// <summary>
        /// This field will set Productpartno
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Productpartno
        {
            get => _productpartno;
            set => SetProperty(ref _productpartno, value);
        }

        private string _spqrNo;
        /// <summary>
        /// This field will set SpqrNo
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string SpqrNo
        {
            get => _spqrNo;
            set => SetProperty(ref _spqrNo, value);
        }

        private string _customerPartNo;
        /// <summary>
        /// This field will set CustomerPartNo
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string CustomerPartNo
        {
            get => _customerPartNo;
            set => SetProperty(ref _customerPartNo, value);
        }

        private DateTime _productmanufacturingDate;
        /// <summary>
        /// This field will set ProductmanufacturingDate
        /// </summary>
        [DataMember]
        [Required]
        public DateTime ProductmanufacturingDate
        {
            get => _productmanufacturingDate;
            set => SetProperty(ref _productmanufacturingDate, value);
        }

        private string _product;
        /// <summary>
        /// This field will set Product
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Product
        {
            get => _product;
            set => SetProperty(ref _product, value);
        }

        private string _troubleFlashReportNo;
        /// <summary>
        /// This field will set TroubleFlashReportNo
        /// </summary>
        [DataMember]
        [StringLength(200)]
        public string TroubleFlashReportNo
        {
            get => _troubleFlashReportNo;
            set => SetProperty(ref _troubleFlashReportNo, value);
        }

        private string _concernLocation;
        /// <summary>
        /// This field will set ConcernLocation
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string ConcernLocation
        {
            get => _concernLocation;
            set => SetProperty(ref _concernLocation, value);
        }

        private string _auditReportNo;
        /// <summary>
        /// This field will set AuditReportNo
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string AuditReportNo
        {
            get => _auditReportNo;
            set => SetProperty(ref _auditReportNo, value);
        }



        private Guid _auditTypeGuid;
        /// <summary>
        /// This field will set AuditTypeGuid
        /// </summary>
        [DataMember]
        public Guid AuditTypeGuid
        {
            get => _auditTypeGuid;
            set => SetProperty(ref _auditTypeGuid, value);
        }

        private Guid _auditNameGuid;
        /// <summary>
        /// This field will set AuditNameGuid
        /// </summary>
        [DataMember]
        public Guid AuditNameGuid
        {
            get => _auditNameGuid;
            set => SetProperty(ref _auditNameGuid, value);
        }

        private Guid _auditStandardSectionGuid;
        /// <summary>
        /// This field will set AuditStandardSectionGuid
        /// </summary>
        [DataMember]
        public Guid AuditStandardSectionGuid
        {
            get => _auditStandardSectionGuid;
            set => SetProperty(ref _auditStandardSectionGuid, value);
        }

        private string _auditTypeDescription;
        /// <summary>
        /// Get or Set for {AuditTypeDescription}
        /// </summary>
        [DataMember]
        public string AuditTypeDescription
        {
            get => _auditTypeDescription;
            set => SetProperty(ref _auditTypeDescription, value);
        }

        private string _auditNameDescription;
        /// <summary>
        /// Get or Set for {AuditNameDescription}
        /// </summary>
        [DataMember]
        public string AuditNameDescription
        {
            get => _auditNameDescription;
            set => SetProperty(ref _auditNameDescription, value);
        }

        private string _standardSectionsDescription;
        /// <summary>
        /// Get or Set for {StandardSectionsDescription}
        /// </summary>
        [DataMember]
        public string StandardSectionsDescription
        {
            get => _standardSectionsDescription;
            set => SetProperty(ref _standardSectionsDescription, value);
        }

        private string _yokotenStatus;
        /// <summary>
        /// This field will set YokotenStatus
        /// </summary>
        [DataMember]
        public string YokotenStatus
        {
            get => _yokotenStatus;
            set => SetProperty(ref _yokotenStatus, value);
        }

        private List<PhotoInformReplyModel> _photoList;
        /// <summary>
        /// This field will set PhotoList
        /// </summary>
        [DataMember]
        public List<PhotoInformReplyModel> PhotoList
        {
            get => _photoList;
            set => SetProperty(ref _photoList, value);
        }

        private string _concernDescription;
        /// <summary>
        /// This field will set ConcernDescription
        /// </summary>
        [DataMember]
        public string ConcernDescription
        {
            get => _concernDescription;
            set => SetProperty(ref _concernDescription, value);
        }
        private string _submittedBy;
        /// <summary>
        /// This field will set SubmittedBy
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string SubmittedBy
        {
            get => _submittedBy;
            set => SetProperty(ref _submittedBy, value);
        }

        private string _department;
        /// <summary>
        /// This field will set Department
        /// </summary>
        [DataMember]
        [StringLength(200)]
        public string Department
        {
            get => _department;
            set => SetProperty(ref _department, value);
        }


        private List<FileUploadModel> _documentList;
        /// <summary>
        /// This field will set DocumentList
        /// </summary>
        [DataMember]
        public List<FileUploadModel> DocumentList
        {
            get => _documentList;
            set => SetProperty(ref _documentList, value);
        }

        private Dictionary<Guid, string> _yokotenAction;
        /// <summary>
        /// This field will set YokotenAction
        /// </summary>
        [DataMember]
        public Dictionary<Guid, string> YokotenAction
        {
            get => _yokotenAction;
            set => SetProperty(ref _yokotenAction, value);
        }

        private List<BussinessUnitInformReplyModel> _bussinessUnitInformReply;
        /// <summary>
        /// This field will set InformReply
        /// </summary>
        [DataMember]
        public List<BussinessUnitInformReplyModel> BussinessUnitInformReply
        {
            get => _bussinessUnitInformReply;
            set => SetProperty(ref _bussinessUnitInformReply, value);
        }

        private bool _isCQApproved;
        /// <summary>
        /// This field will set Is CQ Approved
        /// </summary>
        [DataMember]
        public bool IsCQApproved
        {
            get => _isCQApproved;
            set => SetProperty(ref _isCQApproved, value);
        }

        private bool _isAudit;
        /// <summary>
        /// This field will set Is Audit
        /// </summary>
        [DataMember]
        public bool IsAudit
        {
            get => _isAudit;
            set => SetProperty(ref _isAudit, value);
        }

        private bool _isCQRejected;
        /// <summary>
        /// This field will set Is CQ Rejected
        /// </summary>
        [DataMember]
        public bool IsCQRejected
        {
            get => _isCQRejected;
            set => SetProperty(ref _isCQRejected, value);
        }

        private string _cqComments;
        /// <summary>
        /// This field will set CQ Comments
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string CQComments
        {
            get => _cqComments;
            set => SetProperty(ref _cqComments, value);
        }

        private int _yokotenStatusCode;

        /// <summary>
        /// Gets or sets a integer value for the Yokoten Status column.
        /// </summary>
        [DataMember]
        public int YokotenStatusCode
        {
            get => _yokotenStatusCode;
            set => SetProperty(ref _yokotenStatusCode, value);
        }

        private string _yokotenStatusDescription;
        /// <summary>
        /// Set Yokoten Status
        /// </summary>
        [DataMember]
        [StringLength(250)]
        public string YokotenStatusDescription
        {
            get => _yokotenStatusDescription;
            set => SetProperty(ref _yokotenStatusDescription, value);
        }

        private List<RootCauseModel> _rootCause;
        /// <summary>
        /// This field will set RootCause
        /// </summary>
        [DataMember]
        public List<RootCauseModel> RootCause
        {
            get => _rootCause;
            set => SetProperty(ref _rootCause, value);
        }

        private List<CounterMeasuresModel> _counterMeasure;
        /// <summary>
        /// This field will set CounterMeasure
        /// </summary>
        [DataMember]
        public List<CounterMeasuresModel> CounterMeasure
        {
            get => _counterMeasure;
            set => SetProperty(ref _counterMeasure, value);
        }

    }
}
