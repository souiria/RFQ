/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ConcernLogSystemModel.cs
Function           :   ConcernLogSystemModel,ConcernLogSystemDetailModel
Created By         :   Vishwadeep Singh
Created on         :   04-Dec-2023
Revision History   :              
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ConcernLogSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class ConcernLogSystemModel : BaseModel<Guid>
    {
        private Guid _modulesGuid;
        /// <summary>
        /// Get or Set for {ModulesGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid ModulesGuid
        {
            get => _modulesGuid;
            set => SetProperty(ref _modulesGuid, value);
        }

        private string _modules;
        /// <summary>
        /// Get or Set for {Module}.
        /// </summary>
        [DataMember]
        [Required]
        public string Modules
        {
            get => _modules;
            set => SetProperty(ref _modules, value);
        }

        private string _concernReferenceNumber;
        /// <summary>
        /// Get or Set for {ConcernReferenceNumber}.
        /// </summary>
        [DataMember]
        [Required]
        public string ConcernReferenceNumber
        {
            get => _concernReferenceNumber;
            set => SetProperty(ref _concernReferenceNumber, value);
        }

        private Guid _userGuid;
        /// <summary>
        /// Get or Set for {UserGuid}.
        /// </summary>
        [DataMember]
        [Required]

        public Guid UserGuid
        {
            get => _userGuid;
            set => SetProperty(ref _userGuid, value);
        }

        private DateTime _dateRaised;
        /// <summary>
        /// Get or Set for {Logistics}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime DateRaised
        {
            get => _dateRaised;
            set => SetProperty(ref _dateRaised, value);
        }

        
        private Guid _businessUnitGuid;
        /// <summary>
        /// Get or Set for {BusinessUnitGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }


        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => SetProperty(ref _customerGuid, value);
        }

        private string _customerRaisedIssue;
        /// <summary>
        /// Get or Set for {CustomerRaisedIssue}.
        /// </summary>
        [DataMember]
        [Required]
        public string CustomerRaisedIssue
        {
            get => _customerRaisedIssue;
            set => SetProperty(ref _customerRaisedIssue, value);
        }

        private string _customerConcernReferenceNumber;
        /// <summary>
        /// Get or Set for {CustomerConcernReferenceNumber}.
        /// </summary>
        [DataMember]
        [Required]
        public string CustomerConcernReferenceNumber
        {
            get => _customerConcernReferenceNumber;
            set => SetProperty(ref _customerConcernReferenceNumber, value);
        }

        private Guid _supplierGuid;
        /// <summary>
        /// Get or Set for {SupplierGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => SetProperty(ref _supplierGuid, value);
        }

        private int _stage;
        /// <summary>
        /// Get or Set for {Stage}.
        /// </summary>
        [DataMember]
        [Required]
        public int Stage
        {
            get => _stage;
            set => SetProperty(ref _stage, value);
        }
        private string _originatorReturnComments;
        /// <summary>
        /// Get or Set for {OriginatorReturnComments}.
        /// </summary>
        [DataMember]
        public string OriginatorReturnComments
        {
            get => _originatorReturnComments;
            set => SetProperty(ref _originatorReturnComments, value);
        }

        private List<ConcernLogSystemDetailModel> _ConcernLogSystemDetailModel;

        [DataMember]
        public List<ConcernLogSystemDetailModel> ConcernLogSystemDetailModelobj
        {
            get => _ConcernLogSystemDetailModel;
            set => SetProperty(ref _ConcernLogSystemDetailModel, value);
        }

        private string _cancelRequestComment;
        /// <summary>
        /// Get or Set for {CancelRequestComment}.
        /// </summary>
        [DataMember]
        public string CancelRequestComment
        {
            get => _cancelRequestComment;
            set => SetProperty(ref _cancelRequestComment, value);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class ConcernLogSystemDetailModel : BaseModel<Guid>
    {

        private Guid _concernLogSystemGuid;
        /// <summary>
        /// Get or Set for {ConcernLogSystemGuid}.
        /// </summary>
        [DataMember]
        public Guid ConcernLogSystemGuid
        {
            get => _concernLogSystemGuid;
            set => SetProperty(ref _concernLogSystemGuid, value);
        }

        private Guid _concernClassificationGuid;
        /// <summary>
        /// Get or Set for {ConcernRating/ConcernClassification}.
        /// </summary>
        [DataMember]
        public Guid ConcernClassificationGuid
        {
            get => _concernClassificationGuid;
            set => SetProperty(ref _concernClassificationGuid, value);
        }


        private Guid _concernReasonGuid;
        /// <summary>
        /// Get or Set for {ConcernReasonGuid/Concern Code}.
        /// </summary>
        [DataMember]
        public Guid ConcernReasonGuid
        {
            get => _concernReasonGuid;
            set => SetProperty(ref _concernReasonGuid, value);
        }

        private string _concernDescription;
        /// <summary>
        /// Get or Set for {ConcernDescription}.
        /// </summary>
        [DataMember]
        public string ConcernDescription
        {
            get => _concernDescription;
            set => SetProperty(ref _concernDescription, value);
        }
         

        private string _detailedDescription;
        /// <summary>
        /// Get or Set for {DetailedDescription}.
        /// </summary>
        [DataMember]
        public string DetailedDescription
        {
            get => _detailedDescription;
            set => SetProperty(ref _detailedDescription, value);
        }
        
        private string _affectedCommodity;
        /// <summary>
        /// Get or Set for {AffectedCommodity}.
        /// </summary>
        [DataMember]
        public string AffectedCommodity
        {
            get => _affectedCommodity;
            set => SetProperty(ref _affectedCommodity, value);
        }

        private decimal _quantityofAffectedCommodity;
        /// <summary>
        /// Get or Set for {QuantityofAffectedCommodity}.
        /// </summary>
        [DataMember]
        public decimal QuantityofAffectedCommodity
        {
            get => _quantityofAffectedCommodity;
            set => SetProperty(ref _quantityofAffectedCommodity, value);
        }

        private decimal _valueofAffectedCommodity;
        /// <summary>
        /// Get or Set for {ValueofAffectedCommodity}.
        /// </summary>
        [DataMember]
        public decimal ValueofAffectedCommodity
        {
            get => _valueofAffectedCommodity;
            set => SetProperty(ref _valueofAffectedCommodity, value);
        }


        private string _customerAffected;
        /// <summary>
        /// Get or Set for {CustomerAffected}.
        /// </summary>
        [DataMember]
        public string CustomerAffected
        {
            get => _customerAffected;
            set => SetProperty(ref _customerAffected, value);
        }

        private string _replacementRequested;
        /// <summary>
        /// Get or Set for {ReplacementRequested}.
        /// </summary>
        [DataMember]
        public string ReplacementRequested
        {
            get => _replacementRequested;
            set => SetProperty(ref _replacementRequested, value);
        }
        
        private string _concernEvidence;
        /// <summary>
        /// Get or Set for {ConcernEvidence}.
        /// </summary>
        [DataMember]
        public string ConcernEvidence
        {
            get => _concernEvidence;
            set => SetProperty(ref _concernEvidence, value);
        }


        private string _reoccuringProblem;
        /// <summary>
        /// Get or Set for {ReoccuringProblem}.
        /// </summary>
        [DataMember]
        public string ReoccuringProblem
        {
            get => _reoccuringProblem;
            set => SetProperty(ref _reoccuringProblem, value);
        }

        private int _stage;
        /// <summary>
        /// Get or Set for {Stage}.
        /// </summary>
        [DataMember]
        [Required]
        public virtual int Stage
        {
            get => _stage;
            set => SetProperty(ref _stage, value);
        }

        private List<AnalyserConcernAssociationModel> _analyserConcernAssociationModels;
        /// <summary>
        /// Get or Set for {AnalyserConcernAssociationModels}.
        /// </summary>
        public List<AnalyserConcernAssociationModel> AnalyserConcernAssociationModels
        {
            get => _analyserConcernAssociationModels;
            set => SetProperty(ref _analyserConcernAssociationModels, value);
        }
        private Guid _baseCurrencyGuid;
        /// <summary>
        /// Get or Set for {BaseCurrencyGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid BaseCurrencyGuid
        {
            get => _baseCurrencyGuid;
            set => SetProperty(ref _baseCurrencyGuid, value);
        }

        private string _currencyCode;
        [DataMember]
        public string CurrencyCode
        {
            get => _currencyCode;
            set { SetProperty(ref _currencyCode, value); }
        }
    }

    /// <summary>
    /// Get or Set for {CancelConcernModel}.
    /// </summary>
    public class CancelConcernModel
    {
        /// <summary>
        ///  Get or Set for {ConcernLogSystemGuid}.
        /// </summary>
        public Guid ConcernLogSystemGuid { get; set; }
        /// <summary>
        ///  Get or Set for {Stage}.
        /// </summary>
        public CLSStage Stage { get; set; }
        /// <summary>
        ///  Get or Set for {ModifiedBy}.
        /// </summary>
        public Guid ModifiedBy { get; set; }
        /// <summary>
        ///  Get or Set for {CancelRequestComment}.
        /// </summary>
        public string CancelRequestComment { get; set; }
    }

}