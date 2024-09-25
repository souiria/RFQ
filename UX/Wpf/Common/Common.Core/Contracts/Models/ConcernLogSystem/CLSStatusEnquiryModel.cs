/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CLSStatusEnquiryModel.cs
Function           :   CLSStatusEnquiryModel
Created By         :   Piyush Anand 
Created on         :   29-Jan-2024
Revision History   :
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ConcernLogSystem
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract, Serializable]
    public class CLSStatusEnquiryModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local reference for _concernLogSystemGuid Property
        /// </summary>
        private Guid _concernLogSystemGuid;
        /// <summary>
        /// Gets or Sets the caption value for [ConcernLogSystem] [Grid] column 
        /// </summary>
        [DataMember]
        public Guid ConcernLogSystemGuid
        {
            get { return _concernLogSystemGuid; }
            set { SetProperty(ref _concernLogSystemGuid, value); }
        }
        /// <summary>
        /// Local reference for _concernLogSystemDetailGuid Property
        /// </summary>
        private Guid _concernLogSystemDetailGuid;
        /// <summary>
        /// Gets or Sets the caption value for [ConcernLogSystemDetail] [Grid] column 
        /// </summary>
        [DataMember]
        public Guid ConcernLogSystemDetailGuid
        {
            get { return _concernLogSystemDetailGuid; }
            set { SetProperty(ref _concernLogSystemDetailGuid, value); }
        }
        /// <summary>
        /// Local reference for _concernAssignToAnalyserGuid Property
        /// </summary>
        private Guid? _concernAssignToAnalyserGuid;
        /// <summary>
        /// Gets or Sets the caption value for [ConcernAssignToAnalyser] [Grid] column 
        /// </summary>
        [DataMember]
        public Guid? ConcernAssignToAnalyserGuid
        {
            get { return _concernAssignToAnalyserGuid; }
            set { SetProperty(ref _concernAssignToAnalyserGuid, value); }
        }
        /// <summary>
        /// Local reference for _concernReferenceNumber Property
        /// </summary>
        private string _concernReferenceNumber;
        /// <summary>
        /// Gets or Sets the caption value for [ConcernReferenceNumber] [Grid] column 
        /// </summary>
        [DataMember]
        public string ConcernReferenceNumber
        {
            get { return _concernReferenceNumber; }
            set { SetProperty(ref _concernReferenceNumber, value); }
        }
        /// <summary>
        /// Local reference for _reOccuringConcernReferenceNumber Property
        /// </summary>
        private string _reOccuringConcernReferenceNumber;
        /// <summary>
        /// Gets or Sets the caption value for [ReOccuringConcernReferenceNumber] [Grid] column 
        /// </summary>
        [DataMember]
        public string ReOccuringConcernReferenceNumber
        {
            get { return _reOccuringConcernReferenceNumber; }
            set { SetProperty(ref _reOccuringConcernReferenceNumber, value); }
        }
        /// <summary>
        /// Local reference for _dateRaised Property
        /// </summary>
        private DateTime _dateRaised;
        /// <summary>
        /// Gets or Sets the caption value for [DateRaised] [Grid] column 
        /// </summary>
        [DataMember]
        public DateTime DateRaised
        {
            get { return _dateRaised; }
            set { SetProperty(ref _dateRaised, value); }
        }
        /// <summary>
        /// Local reference for _originator Property
        /// </summary>
        private string _originator;
        /// <summary>
        /// Gets or Sets the caption value for [Originator] [Grid] column 
        /// </summary>
        [DataMember]
        public string Originator
        {
            get { return _originator; }
            set { SetProperty(ref _originator, value); }
        }
        /// <summary>
        /// Local reference for _businessUnitGuid Property
        /// </summary>
        private string _businessUnitGuid;
        /// <summary>
        /// Gets or Sets the caption value for [BusinessUnit] [Grid] column 
        /// </summary>
        [DataMember]
        public string BusinessUnit
        {
            get { return _businessUnitGuid; }
            set { SetProperty(ref _businessUnitGuid, value); }
        }

        /// <summary>
        /// Local reference for _customerCode Property
        /// </summary>
        private string _customerCode;
        /// <summary>
        /// Gets or Sets the caption value for [CustomerCode] [Grid] column 
        /// </summary>
        [DataMember]
        public string CustomerCode
        {
            get { return _customerCode; }
            set { SetProperty(ref _customerCode, value); }
        }
        /// <summary>
        /// Local reference for _customerName Property
        /// </summary>
        private string _customerName;
        /// <summary>
        /// Gets or Sets the caption value for [CustomerName] [Grid] column 
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get { return _customerName; }
            set { SetProperty(ref _customerName, value); }
        }
        /// <summary>
        /// Local reference for _customerRaisedIssue Property
        /// </summary>
        private string _customerRaisedIssue;
        /// <summary>
        /// Gets or Sets the caption value for [CustomerRaisedIssue] [Grid] column 
        /// </summary>
        [DataMember]
        public string CustomerRaisedIssue
        {
            get { return _customerRaisedIssue; }
            set { SetProperty(ref _customerRaisedIssue, value); }
        }
        /// <summary>
        /// Local reference for _customerConcernReferenceNumber Property
        /// </summary>
        private string _customerConcernReferenceNumber;
        /// <summary>
        /// Gets or Sets the caption value for [CustomerConcernReferenceNumber] [Grid] column 
        /// </summary>
        [DataMember]
        public string CustomerConcernReferenceNumber
        {
            get { return _customerConcernReferenceNumber; }
            set { SetProperty(ref _customerConcernReferenceNumber, value); }
        }
        /// <summary>
        /// Local reference for _supplierGuid Property
        /// </summary>
        private Guid _supplierGuid;
        /// <summary>
        /// Gets or Sets the caption value for [Supplier] [Grid] column 
        /// </summary>
        [DataMember]
        public Guid SupplierGuid
        {
            get { return _supplierGuid; }
            set { SetProperty(ref _supplierGuid, value); }
        }
        /// <summary>
        /// Local reference for _supplierCode Property
        /// </summary>
        private string _supplierCode;
        /// <summary>
        /// Gets or Sets the caption value for [SupplierCode] [Grid] column 
        /// </summary>
        [DataMember]
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { SetProperty(ref _supplierCode, value); }
        }
        /// <summary>
        /// Local reference for _supplierName Property
        /// </summary>
        private string _supplierName;
        /// <summary>
        /// Gets or Sets the caption value for [SupplierName] [Grid] column 
        /// </summary>
        [DataMember]
        public string SupplierName
        {
            get { return _supplierName; }
            set { SetProperty(ref _supplierName, value); }
        }
        /// <summary>
        /// Local reference for _concernReasonCategory Property
        /// </summary>
        private string _concernReasonCategory;
        /// <summary>
        /// Gets or Sets the caption value for [ConcernReasonCategory] [Grid] column 
        /// </summary>
        [DataMember]
        public string ConcernReasonCategory
        {
            get { return _concernReasonCategory; }
            set { SetProperty(ref _concernReasonCategory, value); }
        }
        /// <summary>
        /// Local reference for _concernSubCategory Property
        /// </summary>
        private string _concernSubCategory;
        /// <summary>
        /// Gets or Sets the caption value for [ConcernSubCategory] [Grid] column 
        /// </summary>
        [DataMember]
        public string ConcernSubCategory
        {
            get { return _concernSubCategory; }
            set { SetProperty(ref _concernSubCategory, value); }
        }
        /// <summary>
        /// Local reference for _concernClassification Property
        /// </summary>
        private string _concernClassification;
        /// <summary>
        /// Gets or Sets the caption value for [ConcernClassification] [Grid] column 
        /// </summary>
        [DataMember]
        public string ConcernClassification
        {
            get { return _concernClassification; }
            set { SetProperty(ref _concernClassification, value); }
        }
        /// <summary>
        /// Local reference for _currency Property
        /// </summary>
        private string _currency;
        /// <summary>
        /// Gets or Sets the caption value for [Currency] [Grid] column 
        /// </summary>
        [DataMember]
        public string Currency
        {
            get { return _currency; }
            set { SetProperty(ref _currency, value); }
        }
        /// <summary>
        /// Local reference for _valueOfConcern Property
        /// </summary>
        private string _valueOfConcern;
        /// <summary>
        /// Gets or Sets the caption value for [ValueOfConcern] [Grid] column 
        /// </summary>
        [DataMember]
        public string ValueOfConcern
        {
            get { return _valueOfConcern; }
            set { SetProperty(ref _valueOfConcern, value); }
        }
        /// <summary>
        /// Local reference for _currentStatus Property
        /// </summary>
        private string _currentStatus;
        /// <summary>
        /// Gets or Sets the caption value for [CurrentStatus] [Grid] column 
        /// </summary>
        [DataMember]
        public string CurrentStatus
        {
            get { return _currentStatus; }
            set { SetProperty(ref _currentStatus, value); }
        }
        /// <summary>
        /// Local reference for _systemStage Property
        /// </summary>
        private string _systemStage;
        /// <summary>
        /// Gets or Sets the caption value for [SystemStage] [Grid] column 
        /// </summary>
        [DataMember]
        public string SystemStage
        {
            get { return _systemStage; }
            set { SetProperty(ref _systemStage, value); }
        }
        /// <summary>
        /// Local reference for _nextAction Property
        /// </summary>
        private string _nextAction;
        /// <summary>
        /// Gets or Sets the caption value for [NextAction] [Grid] column 
        /// </summary>
        [DataMember]
        public string NextAction
        {
            get { return _nextAction; }
            set { SetProperty(ref _nextAction, value); }
        }
        /// <summary>
        /// Local reference for _nextActionOwner Property
        /// </summary>
        private string _nextActionOwner;
        /// <summary>
        /// Gets or Sets the caption value for [NextActionOwner] [Grid] column 
        /// </summary>
        [DataMember]
        public string NextActionOwner
        {
            get { return _nextActionOwner; }
            set { SetProperty(ref _nextActionOwner, value); }
        }
        /// <summary>
        /// Local reference for _stage Property
        /// </summary>
        private int _stage;
        /// <summary>
        /// Gets or Sets the caption value for [Stage] [Grid] column 
        /// </summary>
        [DataMember]
        public int Stage
        {
            get { return _stage; }
            set { SetProperty(ref _stage, value); }
        }
        /// <summary>
        /// Local reference for _cLSStatusDescription Property
        /// </summary>
        private string _cLSStatusDescription;
        /// <summary>
        /// Gets or Sets the caption value for [CLSStatusDescription] [Grid] column 
        /// </summary>
        [DataMember]
        public string CLSStatusDescription
        {
            get { return _cLSStatusDescription; }
            set { SetProperty(ref _cLSStatusDescription, value); }
        }

        /// <summary>
        /// Local reference for _detailedDescription Property
        /// </summary>
        private string _detailedDescription;
        /// <summary>
        /// Gets or Sets the caption value for [DetailedDescription] [Grid] column 
        /// </summary>
        [DataMember]
        public string DetailedDescription
        {
            get { return _detailedDescription; }
            set { SetProperty(ref _detailedDescription, value); }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ChangeLogData : BaseModel<Guid>
    {

        /// <summary>
        /// Local reference for _concernLogSystemGuid Property
        /// </summary>
        private Guid _concernLogSystemGuid;
        /// <summary>
        /// Gets or Sets the caption value for [ConcernLogSystem] [Grid] column 
        /// </summary>
        [DataMember]
        public Guid ConcernLogSystemGuid
        {
            get { return _concernLogSystemGuid; }
            set { SetProperty(ref _concernLogSystemGuid, value); }
        }
        /// <summary>
        /// Local reference for _concernLogSystemDetailGuid Property
        /// </summary>
        private Guid _concernLogSystemDetailGuid;
        /// <summary>
        /// Gets or Sets the caption value for [ConcernLogSystemDetail] [Grid] column 
        /// </summary>
        [DataMember]
        public Guid ConcernLogSystemDetailGuid
        {
            get { return _concernLogSystemDetailGuid; }
            set { SetProperty(ref _concernLogSystemDetailGuid, value); }
        }
        /// <summary>
        /// Local reference for _concernAssignToAnalyserGuid Property
        /// </summary>
        private Guid? _concernAssignToAnalyserGuid;
        /// <summary>
        /// Gets or Sets the caption value for [ConcernAssignToAnalyser] [Grid] column 
        /// </summary>
        [DataMember]
        public Guid? ConcernAssignToAnalyserGuid
        {
            get { return _concernAssignToAnalyserGuid; }
            set { SetProperty(ref _concernAssignToAnalyserGuid, value); }
        }

        /// <summary>
        /// Local reference for _previousStage Property
        /// </summary>
        private string _previousStage;
        /// <summary>
        /// Gets or Sets the caption value for [PreviousStage] [Grid] column 
        /// </summary>
        [DataMember]
        public string PreviousStage
        {
            get { return _previousStage; }
            set { SetProperty(ref _previousStage, value); }
        }
        /// <summary>
        /// Local reference for _previousUserRole Property
        /// </summary>
        private string _previousUserRole;
        /// <summary>
        /// Gets or Sets the caption value for [PreviousUserRole] [Grid] column 
        /// </summary>
        [DataMember]
        public string PreviousUserRole
        {
            get { return _previousUserRole; }
            set { SetProperty(ref _previousUserRole, value); }
        }
        /// <summary>
        /// Local reference for _previousUserName Property
        /// </summary>
        private string _previousUserName;
        /// <summary>
        /// Gets or Sets the caption value for [PreviousUserName] [Grid] column 
        /// </summary>
        [DataMember]
        public string PreviousUserName
        {
            get { return _previousUserName; }
            set { SetProperty(ref _previousUserName, value); }
        }
        /// <summary>
        /// Local reference for _currentStage Property
        /// </summary>
        private string _currentStage;
        /// <summary>
        /// Gets or Sets the caption value for [CurrentStage] [Grid] column 
        /// </summary>
        [DataMember]
        public string CurrentStage
        {
            get { return _currentStage; }
            set { SetProperty(ref _currentStage, value); }
        }
        /// <summary>
        /// Local reference for _currentUserRole Property
        /// </summary>
        private string _currentUserRole;
        /// <summary>
        /// Gets or Sets the caption value for [CurrentUserRole] [Grid] column 
        /// </summary>
        [DataMember]
        public string CurrentUserRole
        {
            get { return _currentUserRole; }
            set { SetProperty(ref _currentUserRole, value); }
        }
        /// <summary>
        /// Local reference for _currentUserName Property
        /// </summary>
        private string _currentUserName;
        /// <summary>
        /// Gets or Sets the caption value for [CurrentUserName] [Grid] column 
        /// </summary>
        [DataMember]
        public string CurrentUserName
        {
            get { return _currentUserName; }
            set { SetProperty(ref _currentUserName, value); }
        }
        /// <summary>
        /// Local reference for _previousActionDate Property
        /// </summary>
        private string _previousActionDate;
        /// <summary>
        /// Gets or Sets the caption value for [PreviousActionDate] [Grid] column 
        /// </summary>
        [DataMember]
        public string PreviousActionDate
        {
            get { return _previousActionDate; }
            set { SetProperty(ref _previousActionDate, value); }
        }
        /// <summary>
        /// Local reference for _currentTaskDeadlineDate Property
        /// </summary>
        private string _currentTaskDeadlineDate;
        /// <summary>
        /// Gets or Sets the caption value for [CurrentTaskDeadlineDate] [Grid] column 
        /// </summary>
        [DataMember]
        public string CurrentTaskDeadlineDate
        {
            get { return _currentTaskDeadlineDate; }
            set { SetProperty(ref _currentTaskDeadlineDate, value); }
        }
        /// <summary>
        /// Local reference for _currentStatus Property
        /// </summary>
        private string _currentStatus;
        /// <summary>
        /// Gets or Sets the caption value for [CurrentStatus] [Grid] column 
        /// </summary>
        [DataMember]
        public string CurrentStatus
        {
            get { return _currentStatus; }
            set { SetProperty(ref _currentStatus, value); }
        }
        /// <summary>
        /// Local reference for _comments Property
        /// </summary>
        private string _comments;
        /// <summary>
        /// Gets or Sets the caption value for [Comments] [Grid] column 
        /// </summary>
        [DataMember]
        public string Comments
        {
            get { return _comments; }
            set { SetProperty(ref _comments, value); }
        }


    }
}