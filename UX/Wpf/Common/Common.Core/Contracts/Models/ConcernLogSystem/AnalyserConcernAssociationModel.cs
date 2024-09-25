/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   AnalyserConcernAssociationModel.cs
Function           :   AnalyserConcernAssociationModel
Created By         :   Virendra
Created on         :   15-Jan-2024
Revision History   :  
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.ConcernLogSystem
{

    public class AnalyserConcernAssociationModel : BaseModel<Guid>
    {
        private Guid _concernLogSystemDetailGuid;
        /// <summary>
        /// Get or Set for {ConcernLogSystemDetailGuid}.
        /// </summary>
        [DataMember]
        public Guid ConcernLogSystemDetailGuid
        {
            get => _concernLogSystemDetailGuid;
            set => SetProperty(ref _concernLogSystemDetailGuid, value);
        }
        private Guid _departmentMasterGuid;
        /// <summary>
        /// Get or Set for {DepartmentMasterGuid}.
        /// </summary>
        [DataMember]
        public Guid DepartmentMasterGuid
        {
            get => _departmentMasterGuid;
            set => SetProperty(ref _departmentMasterGuid, value);
        }

        private string _aDUserName;
        /// <summary>
        /// Get or Set for {ADUserName}.
        /// </summary>
        [DataMember]
        public string ADUserName
        {
            get => _aDUserName;
            set => SetProperty(ref _aDUserName, value);
        }

        private int _stage;
        /// <summary>
        /// Get or Set for {Stage}.
        /// </summary>
        [DataMember]
        public int Stage
        {
            get => _stage;
            set => SetProperty(ref _stage, value);
        }
        private string _analyserReturnComments;
        /// <summary>
        /// Get or Set for {AnalyserReturnComments}.
        /// </summary>
        [DataMember]
        public string AnalyserReturnComments
        {
            get => _analyserReturnComments;
            set => SetProperty(ref _analyserReturnComments, value);
        }
        private string _controllerReturnComments;
        /// <summary>
        /// Get or Set for {ControllerReturnComments}.
        /// </summary>
        [DataMember]
        public string ControllerReturnComments
        {
            get => _controllerReturnComments;
            set => SetProperty(ref _controllerReturnComments, value);
        }
    }


    public class ConcernLogDetailByAnalyser
    {


        private string _concernReferenceNumber;
        /// <summary>
        /// Get or Set for {ConcernReferenceNumber}.
        /// </summary>
        [DataMember]
        public string ConcernReferenceNumber
        {
            get => _concernReferenceNumber;
            set => _concernReferenceNumber = value;
        }

        private string _dateRaised;
        /// <summary>
        /// Get or Set for {DateRaised}.
        /// </summary>
        [DataMember]
        public string DateRaised
        {
            get => _dateRaised;
            set => _dateRaised = value;
        }

        private string _supplierCode;
        /// <summary>
        /// Get or Set for {SupplierCode}.
        /// </summary>
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }

        private string _businessUnitCode;
        /// <summary>
        /// Get or Set for {BusinessUnitCode}.
        /// </summary>
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => _businessUnitCode = value;
        }

        private string _orginator;
        /// <summary>
        /// Get or Set for {Orginator}.
        /// </summary>
        [DataMember]
        public string Orginator
        {
            get => _orginator;
            set => _orginator = value;
        }

        private string _code;
        /// <summary>
        /// Get or Set for {Code}.
        /// </summary>
        [DataMember]
        public string Code
        {
            get => _code;
            set => _code = value;
        }

        private string _description;
        /// <summary>
        /// Get or Set for {Description}.
        /// </summary>
        [DataMember]
        public string Description
        {
            get => _description;
            set => _description = value;
        }

        private string _subCategory;
        /// <summary>
        /// Get or Set for {SubCategory}.
        /// </summary>
        [DataMember]
        public string SubCategory
        {
            get => _subCategory;
            set => _subCategory = value;
        }

        private string _departmentName;
        /// <summary>
        /// Get or Set for {DepartmentName}.
        /// </summary>
        [DataMember]
        public string DepartmentName
        {
            get => _departmentName;
            set => _departmentName = value;
        }

        private string _customerAffected;
        /// <summary>
        /// Get or Set for {CustomerAffected}.
        /// </summary>
        [DataMember]
        public string CustomerAffected
        {
            get => _customerAffected;
            set => _customerAffected = value;
        }

        private string _concernEvidence;
        /// <summary>
        /// Get or Set for {ConcernEvidence}.
        /// </summary>
        [DataMember]
        public string ConcernEvidence
        {
            get => _concernEvidence;
            set => _concernEvidence = value;
        }

        private string _reoccuringProblem;
        /// <summary>
        /// Get or Set for {ReoccuringProblem}.
        /// </summary>
        [DataMember]
        public string ReoccuringProblem
        {
            get => _reoccuringProblem;
            set => _reoccuringProblem = value;
        }

        private Guid _concernId;
        /// <summary>
        /// Get or Set for {ConcernId}.
        /// </summary>
        [DataMember]
        public Guid ConcernId
        {
            get => _concernId;
            set => _concernId = value;
        }

        private Guid _concernDetailId;
        /// <summary>
        /// Get or Set for {ConcernDetailId}.
        /// </summary>
        [DataMember]
        public Guid ConcernDetailId
        {
            get => _concernDetailId;
            set => _concernDetailId = value;
        }

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

        private string _controllerReturnComments;
        /// <summary>
        /// Get or Set for {ControllerReturnComments}.
        /// </summary>
        [DataMember]
        public string ControllerReturnComments
        {
            get => _controllerReturnComments;
            set => _controllerReturnComments = value;
        }


        private int _hasEvidanceAnalyser;
        /// <summary>
        /// Get or Set for {HasEvidanceAnalyser}.
        /// </summary>
        [DataMember]
        public int HasEvidanceAnalyser
        {
            get => _hasEvidanceAnalyser;
            set => _hasEvidanceAnalyser = value;
        }

        private int _hasEvidanceOrig;
        /// <summary>
        /// Get or Set for {HasEvidanceOrig}.
        /// </summary>
        [DataMember]
        public int HasEvidanceOrig
        {
            get => _hasEvidanceOrig;
            set => _hasEvidanceOrig = value;
        }

        private string _analyserEvidence;
        /// <summary>
        /// Get or Set for {AnalyserEvidence}.
        /// </summary>
        [DataMember]
        public string AnalyserEvidence
        {
            get => _analyserEvidence;
            set => _analyserEvidence = value;
        }

        private int _stage;
        /// <summary>
        /// Get or Set for {Stage}.
        /// </summary>
        [DataMember]
        public int Stage
        {
            get => _stage;
            set => _stage = value;
        }

        private string _taskDeadline;
        /// <summary>
        /// Get or Set for {TaskDeadline}.
        /// </summary>
        [DataMember]
        public string TaskDeadline
        {
            get => _taskDeadline;
            set => _taskDeadline = value;
        }

        private string _concernClassification;
        /// <summary>
        /// Get or Set for {ConcernClassification}.
        /// </summary>
        [DataMember]
        public string ConcernClassification
        {
            get => _concernClassification;
            set => _concernClassification = value;
        }
    }

}
