/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   AnalyzerRouteCauseAnalysisModel.cs
Function           :   AnalyzerRouteCauseAnalysisModel
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
    public class AnalyzerRouteCauseAnalysisModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local reference for _concernAssignToAnalyserGuid Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [ConcernAssignToAnalyserGuid] [Grid] column 
        /// </summary>
        private Guid _concernAssignToAnalyserGuid;
        [DataMember]
        public Guid ConcernAssignToAnalyserGuid
        {
            get { return _concernAssignToAnalyserGuid; }
            set { SetProperty(ref _concernAssignToAnalyserGuid, value); }
        }
        /// <summary>
        /// Local reference for _routeCause Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [RouteCause] [Grid] column 
        /// </summary>
        private string _routeCause;
        [DataMember]
        public string RouteCause
        {
            get { return _routeCause; }
            set { SetProperty(ref _routeCause, value); }
        }
        /// <summary>
        /// Local reference for _rCNO Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [RCNO] [Grid] column 
        /// </summary>
        private string _rCNO;
        [DataMember]
        public string RCNO
        {
            get { return _rCNO; }
            set { SetProperty(ref _rCNO, value); }
        }
        /// <summary>
        /// Local reference for _immediateActionTaken Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [ImmediateActionTaken] [Grid] column 
        /// </summary>
        private string _immediateActionTaken;
        [DataMember]
        public string ImmediateActionTaken
        {
            get { return _immediateActionTaken; }
            set { SetProperty(ref _immediateActionTaken, value); }
        }
        /// <summary>
        /// Local reference for _problemSolvingActionPlan Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [ProblemSolvingActionPlan] [Grid] column 
        /// </summary>
        private string _problemSolvingActionPlan;
        [DataMember]
        public string ProblemSolvingActionPlan
        {
            get { return _problemSolvingActionPlan; }
            set { SetProperty(ref _problemSolvingActionPlan, value); }
        }
        /// <summary>
        /// Local reference for _responsibleOwner Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [ResponsibleOwner] [Grid] column 
        /// </summary>
        private string _responsibleOwner;
        [DataMember]
        public string ResponsibleOwner
        {
            get { return _responsibleOwner; }
            set { SetProperty(ref _responsibleOwner, value); }
        }
        /// <summary>
        /// Local reference for _timingPlan_ProblemSolvingActionPlan Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [TimingPlan_ProblemSolvingActionPlan] [Grid] column 
        /// </summary>
        private string _timingPlan_ProblemSolvingActionPlan;
        [DataMember]
        public string TimingPlan_ProblemSolvingActionPlan
        {
            get { return _timingPlan_ProblemSolvingActionPlan; }
            set { SetProperty(ref _timingPlan_ProblemSolvingActionPlan, value); }
        }
        /// <summary>
        /// Local reference for _preventativeMeasure Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [PreventativeMeasure] [Grid] column 
        /// </summary>
        private string _preventativeMeasure;
        [DataMember]
        public string PreventativeMeasure
        {
            get { return _preventativeMeasure; }
            set { SetProperty(ref _preventativeMeasure, value); }
        }
        /// <summary>
        /// Local reference for _timingPlan_PreventativeMeasure Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [TimingPlan_PreventativeMeasure] [Grid] column 
        /// </summary>
        private string _timingPlan_PreventativeMeasure;
        [DataMember]
        public string TimingPlan_PreventativeMeasure
        {
            get { return _timingPlan_PreventativeMeasure; }
            set { SetProperty(ref _timingPlan_PreventativeMeasure, value); }
        }
        /// <summary>
        /// Local reference for _didYouReviewCompanyDocumentation Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [DidYouReviewCompanyDocumentation] [Grid] column 
        /// </summary>
        private string _didYouReviewCompanyDocumentation;
        [DataMember]
        public string DidYouReviewCompanyDocumentation
        {
            get { return _didYouReviewCompanyDocumentation; }
            set { SetProperty(ref _didYouReviewCompanyDocumentation, value); }
        }


    }
}
