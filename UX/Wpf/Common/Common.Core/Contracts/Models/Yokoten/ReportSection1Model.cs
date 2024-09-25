/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ReportSection1Model.cs
Function           :   Data contract for ReportSection1Model
Created By         :   Srashti Gupta
Created on         :   27-Feb-2020
RevisionHistory    :   [04-Mar-2020] : Srashti Gupta
*                  :   Added new property [ProcessEquipmentDetails,SystemDetails] and remove [EquipmentProcessProblem]
*                  :   [04-May-2020] : Shivam Dhingra
*                  :   Added new properties : QCFeedback,ActionOnQCFeedback,ActionOnQCFeedback
*                  :   [06-May-2020] : Pawan
*                  :   Added new properties : YokotenStatus
*                  :   [22-May-2020] : Srashti Gupta
*                  :   Added new properties : PrimaryProcess, BestPracticeDescription
*                  :   [15-July-2020] : Srashti Gupta
*                  :   Added FilteredModel for filtering Data, added property SelectCount in FilteredModel 
*                  :   [06-Aug-2020] : Pawan
*                  :   Added property for Audit Type Guid , Name and Standard Section 
*                  :   [10-Aug-2020] : Pawan
*                  :   Added property for Audit Primary Process Detail 
*                  :   [18-Aug-2020] : Pawan
*                  :   Added property for Audit Attachments Upload
*                  :   [03-Sep-2020] : Pawan
*                  :   Added property for Audit Detail Model
*                  :   [06-May-2021] : Shivam Dhinga
*                  :   Added model to save ReplyDate only
*                  :   [01-Feb-2022] : Shivam Kalia
*                  :   Added new property CustomerBusinessHierarchyGuid
*                  :   [12-Apr-2023] : Ashish Dutta
*                  :   Added new property statefull to stateless
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
    public class ReportSection1Model : BaseModel<Guid>
    {
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

        private Guid _customerBusinessHierarchyGuid;
        /// <summary>
        /// This field will set CustomerBusinessHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessHierarchyGuid
        {
            get => _customerBusinessHierarchyGuid;
            set => SetProperty(ref _customerBusinessHierarchyGuid, value);
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

        private bool _replyDateRequired;
        /// <summary>
        /// This field will set ReplyDateRequired
        /// </summary>
        [DataMember]
        [Required]
        public bool ReplyDateRequired
        {
            get => _replyDateRequired;
            set => SetProperty(ref _replyDateRequired, value);
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


        private Guid _swsSiteGuid;
        /// <summary>
        /// This field will set _liabilityGuid
        /// </summary>
        [DataMember]
        public Guid SwSSiteGuid
        {
            get => _swsSiteGuid;
            set => SetProperty(ref _swsSiteGuid, value);
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

        private string _recordNo;
        /// <summary>
        /// This field will set RecordNo
        /// </summary>
        [DataMember]
        [StringLength(40)]
        public string RecordNo
        {
            get => _recordNo;
            set => SetProperty(ref _recordNo, value);
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

        private Guid _liabilityGuid;
        /// <summary>
        /// This field will set _liabilityGuid
        /// </summary>
        [DataMember]
        public Guid LiabilityGuid
        {
            get => _liabilityGuid;
            set => SetProperty(ref _liabilityGuid, value);
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

        private Guid _harnessFamilyGuid;
        /// <summary>
        /// This field will set _liabilityGuid
        /// </summary>
        [DataMember]
        public Guid HarnessFamilyGuid
        {
            get => _harnessFamilyGuid;
            set => SetProperty(ref _harnessFamilyGuid, value);
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

        private Guid _defectDetailsGuid;
        /// <summary>
        /// This field will set _liabilityGuid
        /// </summary>
        [DataMember]
        public Guid DefectDetailsGuid
        {
            get => _defectDetailsGuid;
            set => SetProperty(ref _defectDetailsGuid, value);
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

        private Guid _concernLocationGuid;
        /// <summary>
        /// This field will set _liabilityGuid
        /// </summary>
        [DataMember]
        public Guid ConcernLocationGuid
        {
            get => _concernLocationGuid;
            set => SetProperty(ref _concernLocationGuid, value);
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

        private Dictionary<Guid, Guid> _iatfAudit;
        /// <summary>
        /// This field will set IatfAudit
        /// </summary>
        [DataMember]
        public Dictionary<Guid, Guid> IatfAudit
        {
            get => _iatfAudit;
            set => SetProperty(ref _iatfAudit, value);
        }

        private List<AuditDetailModel> _auditDefinitionDetail;
        /// <summary>
        /// This field will set AuditDefinitionDetail
        /// </summary>
        [DataMember]
        public List<AuditDetailModel> AuditDefinitionDetail
        {
            get => _auditDefinitionDetail;
            set => SetProperty(ref _auditDefinitionDetail, value);
        }

        private List<AuditDetailModel> _auditPrimaryProcessDetail;
        /// <summary>
        /// This field will set AuditPrimaryProcessDetail
        /// </summary>
        [DataMember]
        public List<AuditDetailModel> AuditPrimaryProcessDetail
        {
            get => _auditPrimaryProcessDetail;
            set => SetProperty(ref _auditPrimaryProcessDetail, value);
        }

        private string _auditGrade;
        /// <summary>
        /// This field will set AuditGrade
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string AuditGrade
        {
            get => _auditGrade;
            set => SetProperty(ref _auditGrade, value);
        }

        private string _ncDescription;
        /// <summary>
        /// This field will set NcDescription
        /// </summary>
        [DataMember]
        [StringLength(200)]
        public string NcDescription
        {
            get => _ncDescription;
            set => SetProperty(ref _ncDescription, value);
        }

        private Dictionary<Guid, string> _processEquipmentDetails;
        /// <summary>
        /// This field will set ProcessEquipmentDetails
        /// </summary>
        [DataMember]
        public Dictionary<Guid, string> ProcessEquipmentDetails
        {
            get => _processEquipmentDetails;
            set => SetProperty(ref _processEquipmentDetails, value);
        }

        private Dictionary<Guid, string> _systemDetails;
        /// <summary>
        /// This field will set SystemDetails
        /// </summary>
        [DataMember]
        public Dictionary<Guid, string> SystemDetails
        {
            get => _systemDetails;
            set => SetProperty(ref _systemDetails, value);
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

        private string _primaryProcess;
        /// <summary>
        /// Get or Set for {PrimaryProcess}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string PrimaryProcess
        {
            get => _primaryProcess;
            set => SetProperty(ref _primaryProcess, value);
        }

        private string _bestPracticeDescription;
        /// <summary>
        /// Get or Set for {BestPracticeDescription}.
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string BestPracticeDescription
        {
            get => _bestPracticeDescription;
            set => SetProperty(ref _bestPracticeDescription, value);
        }

        private List<FileUploadModel> _auditAttachmentList;
        /// <summary>
        /// This field will set AuditAttachmentList
        /// </summary>
        [DataMember]
        public List<FileUploadModel> AuditAttachmentList
        {
            get => _auditAttachmentList;
            set => SetProperty(ref _auditAttachmentList, value);
        }
    }
    [DataContract, Serializable]
    public class FilteredModel
    {
        private string _filterOption;
        /// <summary>
        /// Get or Set for {FilterOption}.
        /// </summary>
        [DataMember]
        public string FilterOption
        {
            get => _filterOption;
            set => _filterOption = value;
        }

        private string _filterValue;
        /// <summary>
        /// Get or Set for {FilterValue}.
        /// </summary>
        [DataMember]
        public string FilterValue
        {
            get => _filterValue;
            set => _filterValue = value;
        }

        private int _selectCount;
        /// <summary>
        /// Get or Set for {SelectCount}.
        /// </summary>
        [DataMember]
        public int SelectCount
        {
            get => _selectCount;
            set => _selectCount = value;
        }
    }

    /// <summary>
    /// List for AuditDetail Model
    /// </summary>
    public class AuditDetailModel
    {
        private Guid _auditDetailGuid;
        /// <summary>
        /// This field will set AuditDetailGuid
        /// </summary>
        public Guid AuditDetailGuid
        {
            get { return _auditDetailGuid; }
            set { _auditDetailGuid = value; }
        }

        private Guid _nonConformityGuid;
        /// <summary>
        /// This field will set NonConformityGuid
        /// </summary>
        public Guid NonConformityGuid
        {
            get { return _nonConformityGuid; }
            set { _nonConformityGuid = value; }
        }

        private string _comments;
        /// <summary>
        /// This field will set Comments
        /// </summary>
        [StringLength(250)]
        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
    }

    /// <summary>
    /// Data contract for processing ReplyDate on basis of ID
    /// </summary>
    [DataContract,Serializable]
    public class ProcessReportSection1ReplyDateModel
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

        private DateTime _replyDate;
        /// <summary>
        /// Get or Set for {_replyDate}.
        /// </summary>
        [DataMember]
        public DateTime ReplyDate
        {
            get => _replyDate;
            set => _replyDate = value;
        }

    }
    //Added by Ashish on 12-Apr-2023

    /// <summary>
    /// Data contract for get CustomerBusinessHierarchyYokoten 
    /// </summary>
    [DataContract, Serializable]
    public class CustomerBusinessHierarchyYokoten
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

        private string _customerBusinessGroupCode;
        /// <summary>
        /// Get or Set for {_customerBusinessGroupCode}.
        /// </summary>
        [DataMember]
        public string CustomerBusinessGroupCode
        {
            get => _customerBusinessGroupCode;
            set => _customerBusinessGroupCode = value;
        }

        private string _customerBusinessGroupName;
        /// <summary>
        /// Get or Set for {_customerBusinessGroupName}.
        /// </summary>
        [DataMember]
        public string CustomerBusinessGroupName
        {
            get => _customerBusinessGroupName;
            set => _customerBusinessGroupName = value;
        }

        private string _sEWSEBusinessTeam;
        /// <summary>
        /// Get or Set for {_sEWSEBusinessTeam}.
        /// </summary>
        [DataMember]
        public string SEWSEBusinessTeam
        {
            get => _sEWSEBusinessTeam;
            set => _sEWSEBusinessTeam = value;
        }

    }

    /// <summary>
    /// Data contract for get CustomerBusinessHierarchyYokoteneithTier2 
    /// </summary>
    [DataContract, Serializable]
    public class CustomerProjectPlatformHierarchy
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

        private string _customerBusinessGroupCode;
        /// <summary>
        /// Get or Set for {_customerBusinessGroupCode}.
        /// </summary>
        [DataMember]
        public string CustomerBusinessGroupCode
        {
            get => _customerBusinessGroupCode;
            set => _customerBusinessGroupCode = value;
        }

        private string _customerBusinessGroupName;
        /// <summary>
        /// Get or Set for {_customerBusinessGroupName}.
        /// </summary>
        [DataMember]
        public string CustomerBusinessGroupName
        {
            get => _customerBusinessGroupName;
            set => _customerBusinessGroupName = value;
        }
        private Guid _customerBusinessHierarchyGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessHierarchyGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessHierarchyGuid
        {
            get => _customerBusinessHierarchyGuid;
            set => _customerBusinessHierarchyGuid = value;
        }

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

        private string _customerCode;
        /// <summary>
        /// Get or Set for {CustomerCode}.
        /// </summary>
        [DataMember]
        public string CustomerCode
        {
            get => _customerCode;
            set => _customerCode = value;
        }

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

        private string _programName;
        /// <summary>
        /// Get or Set for {ProgramName}.
        /// </summary>
        [DataMember]
        public string ProgramName
        {
            get => _programName;
            set => _programName = value;
        }

        private string _platformName;
        /// <summary>
        /// Get or Set for {PlatformName}.
        /// </summary>
        [DataMember]
        public string PlatformName
        {
            get => _platformName;
            set => _platformName = value;
        }

        private Guid _platformGuid;
        /// <summary>
        /// Get or Set for {PlatformGuid}.
        /// </summary>
        [DataMember]
        public Guid PlatformGuid
        {
            get => _platformGuid;
            set => _platformGuid = value;
        }

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

        private Guid _userGuid;
        /// <summary>
        /// Get or Set for {UserGuid}.
        /// </summary>
        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => _userGuid = value;
        }

    }


    [DataContract, Serializable]
    public class CustomerHierarchyYokoten
    {
        private Guid _customerBusinessHierarchyGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessHierarchyGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessHierarchyGuid
        {
            get => _customerBusinessHierarchyGuid;
            set => _customerBusinessHierarchyGuid = value;
        }

        private string _customerBusinessGroupCode;
        /// <summary>
        /// Get or Set for {_customerBusinessGroupCode}.
        /// </summary>
        [DataMember]
        public string CustomerBusinessGroupCode
        {
            get => _customerBusinessGroupCode;
            set => _customerBusinessGroupCode = value;
        }

        private string _customerBusinessGroupName;
        /// <summary>
        /// Get or Set for {_customerBusinessGroupName}.
        /// </summary>
        [DataMember]
        public string CustomerBusinessGroupName
        {
            get => _customerBusinessGroupName;
            set => _customerBusinessGroupName = value;
        }

        private string _sEWSEBusinessTeam;
        /// <summary>
        /// Get or Set for {_sEWSEBusinessTeam}.
        /// </summary>
        [DataMember]
        public string SEWSEBusinessTeam
        {
            get => _sEWSEBusinessTeam;
            set => _sEWSEBusinessTeam = value;
        }
        private Guid _customerBusinessQualityManagerGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessQualityManagerGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessQualityManagerGuid
        {
            get => _customerBusinessQualityManagerGuid;
            set => _customerBusinessQualityManagerGuid = value;
        }

        private string _customerBusinessQualityManagerName;
        /// <summary>
        /// Get or Set for {CustomerBusinessQualityManagerName}.
        /// </summary>
        [DataMember]
        public string CustomerBusinessQualityManagerName
        {
            get => _customerBusinessQualityManagerName;
            set => _customerBusinessQualityManagerName = value;
        }

    }
    //Added Ended by Ashish on 12-Apr-2023
}
