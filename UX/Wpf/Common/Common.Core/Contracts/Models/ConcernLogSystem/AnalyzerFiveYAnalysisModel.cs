/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   AnalyzerFiveYAnalysisModel.cs
Function           :   AnalyzerFiveYAnalysisModel
Created By         :   Vishwadeep Singh
Created on         :   19-Jan-2024
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
    public class AnalyzerFiveYAnalysisModel : BaseModel<Guid>
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
        /// Local reference for _fYNO Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [FYNO] [Grid] column 
        /// </summary>
        private string _fYNO;
        [DataMember]
        public string FYNO
        {
            get { return _fYNO; }
            set { SetProperty(ref _fYNO, value); }
        }
        /// <summary>
        /// Local reference for _why Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [Why] [Grid] column 
        /// </summary>
        private string _why;
        [DataMember]
        public string Why
        {
            get { return _why; }
            set { SetProperty(ref _why, value); }
        }
        /// <summary>
        /// Local reference for _thisHappenedBecause Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [ThisHappenedBecause] [Grid] column 
        /// </summary>
        private string _thisHappenedBecause;
        [DataMember]
        public string ThisHappenedBecause
        {
            get { return _thisHappenedBecause; }
            set { SetProperty(ref _thisHappenedBecause, value); }
        }
        /// <summary>
        /// Local reference for _isRouteCause Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [IsRouteCause] [Grid] column 
        /// </summary>
        private string _isRouteCause;
        [DataMember]
        public string IsRouteCause
        {
            get { return _isRouteCause; }
            set { SetProperty(ref _isRouteCause, value); }
        }
        /// <summary>
        /// Local reference for _whyDidnntDetectProblem Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [WhyDidnntDetectProblem] [Grid] column 
        /// </summary>
        private string _whyDidnntDetectProblem;
        [DataMember]
        public string WhyDidnntDetectProblem
        {
            get { return _whyDidnntDetectProblem; }
            set { SetProperty(ref _whyDidnntDetectProblem, value); }
        }
    }
}
