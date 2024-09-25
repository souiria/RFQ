/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   AnalyzerFeedBack.cs
Function           :   AnalyzerFeedBack Model
Created By         :   Piyush Anand
Created on         :   29-Dec-2023
Revision History   :   []
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ConcernLogSystem
{
    /// <summary>
    /// Model for AnalyzerFeedBack Screen
    /// </summary>
    [DataContract, Serializable]
    public class AnalyzerFeedBackModel : BaseModel<Guid>
    {
        private Guid _analyzerGuid;
        /// <summary>
        /// Get or Set for {AnalyzerGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid AnalyzerGuid
        {
            get => _analyzerGuid;
            set => SetProperty(ref _analyzerGuid, value);
        }

        private string _fY1;
        /// <summary>
        /// Get or Set for {FY1}.
        /// </summary>
        [DataMember]
        [Required]
        public string FY1
        {
            get => _fY1;
            set => SetProperty(ref _fY1, value);
        }

        private string _fY2;
        /// <summary>
        /// Get or Set for {FY2}.
        /// </summary>
        [DataMember]
        [Required]
        public string FY2
        {
            get => _fY2;
            set => SetProperty(ref _fY2, value);
        }

        private string _fY3;
        /// <summary>
        /// Get or Set for {FY3}.
        /// </summary>
        [DataMember]
        [Required]
        public string FY3
        {
            get => _fY3;
            set => SetProperty(ref _fY3, value);
        }

        private string _fY4;
        /// <summary>
        /// Get or Set for {FY4}.
        /// </summary>
        [DataMember]
        [Required]
        public string FY4
        {
            get => _fY4;
            set => SetProperty(ref _fY4, value);
        }

        private string _fY5;
        /// <summary>
        /// Get or Set for {FY5}.
        /// </summary>
        [DataMember]
        [Required]
        public string FY5
        {
            get => _fY5;
            set => SetProperty(ref _fY5, value);
        }

        private string _routeCause;
        /// <summary>
        /// Get or Set for {RouteCause}.
        /// </summary>
        [DataMember]
        [Required]
        public string RouteCause
        {
            get => _routeCause;
            set => SetProperty(ref _routeCause, value);
        }

        private string _immediateActionTaken;
        /// <summary>
        /// Get or Set for {ImmediateActionTaken}.
        /// </summary>
        [DataMember]
        [Required]
        public string ImmediateActionTaken
        {
            get => _immediateActionTaken;
            set => SetProperty(ref _immediateActionTaken, value);
        }

        private string _problemSolvingActionPlan;
        /// <summary>
        /// Get or Set for {ProblemSolvingActionPlan}.
        /// </summary>
        [DataMember]
        [Required]
        public string ProblemSolvingActionPlan
        {
            get => _problemSolvingActionPlan;
            set => SetProperty(ref _problemSolvingActionPlan, value);
        }

        private string _preventativeMeasure;
        /// <summary>
        /// Get or Set for {PreventativeMeasure}.
        /// </summary>
        [DataMember]
        [Required]
        public string PreventativeMeasure
        {
            get => _preventativeMeasure;
            set => SetProperty(ref _preventativeMeasure, value);
        }

        private DateTime _problemSolvingTime;
        /// <summary>
        /// Get or Set for {ProblemSolvingTime}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime ProblemSolvingTime
        {
            get => _problemSolvingTime;
            set => SetProperty(ref _problemSolvingTime, value);
        }       
    }

}
