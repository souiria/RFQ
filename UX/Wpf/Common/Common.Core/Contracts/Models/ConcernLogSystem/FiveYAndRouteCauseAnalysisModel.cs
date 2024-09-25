/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   FiveYAndRouteCauseAnalysisModel.cs
Function           :   FiveYAndRouteCauseAnalysisModel,DataForRetrunModel
Created By         :   Vishwadeep Singh
Created on         :   19-Jan-2024
Revision History   :              
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ConcernLogSystem
{
    public class FiveYAndRouteCauseAnalysisModel : BaseModel<Guid>
    {

        /// <summary>
        /// Gets or Sets the caption value for [AnalyzerFiveYAnalysisCollection]
        /// </summary>
        private List<AnalyzerFiveYAnalysisModel> _analyzerFiveYAnalysisCollection;
        [DataMember]
        public List<AnalyzerFiveYAnalysisModel> AnalyzerFiveYAnalysisCollection
        {
            get { return _analyzerFiveYAnalysisCollection; }
            set { SetProperty(ref _analyzerFiveYAnalysisCollection, value); }
        }
      
        /// <summary>
        /// Gets or Sets the caption value for [AnalyzerRouteCauseAnalysisCollection] [Grid] column 
        /// </summary>
        private List<AnalyzerRouteCauseAnalysisModel> _analyzerRouteCauseAnalysisCollection;
        [DataMember]
        public List<AnalyzerRouteCauseAnalysisModel> AnalyzerRouteCauseAnalysisCollection
        {
            get { return _analyzerRouteCauseAnalysisCollection; }
            set { SetProperty(ref _analyzerRouteCauseAnalysisCollection, value); }
        }

        /// <summary>
        /// Gets or Sets the caption value for [_DataForRetrunModelCollection] [Grid] column 
        /// </summary>
        private DataForRetrunModel _DataForRetrunModelCollection;
        [DataMember]
        public DataForRetrunModel DataForRetrunModelCollection
        {
            get { return _DataForRetrunModelCollection; }
            set { SetProperty(ref _DataForRetrunModelCollection, value); }
        }

    }

    public class DataForRetrunModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local reference for ReturnComments Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [ReturnComments] [Grid] column 
        /// </summary>
        private string _ReturnComments;
        [DataMember]
        public string ReturnComments
        {
            get { return _ReturnComments; }
            set { SetProperty(ref _ReturnComments, value); }
        }
        /// <summary>
        /// Local reference for ConcernAssignToAnalyserGuid Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [ConcernAssignToAnalyserGuid] [Grid] column 
        /// </summary>
        private string _ConcernAssignToAnalyserGuid;
        [DataMember]
        public string ConcernAssignToAnalyserGuid
        {
            get { return _ConcernAssignToAnalyserGuid; }
            set { SetProperty(ref _ConcernAssignToAnalyserGuid, value); }
        }
        /// <summary>
        /// Local reference for ConcernLogSystemGuid Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [ConcernLogSystemGuid] [Grid] column 
        /// </summary>
        private string _ConcernLogSystemGuid;
        [DataMember]
        public string ConcernLogSystemGuid
        {
            get { return _ConcernLogSystemGuid; }
            set { SetProperty(ref _ConcernLogSystemGuid, value); }
        }
        /// <summary>
        /// Local reference for Stage Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [Stage] [Grid] column 
        /// </summary>
        private string _Stage;
        [DataMember]
        public string Stage
        {
            get { return _Stage; }
            set { SetProperty(ref _Stage, value); }
        }
        /// <summary>
        /// Local reference for ModifiedBy Property
        /// </summary>
        /// <summary>
        /// Gets or Sets the caption value for [ModifiedBy] [Grid] column 
        /// </summary>
        private string _ModifiedBy;
        [DataMember]
        public string ModifiedBy
        {
            get { return _ModifiedBy; }
            set { SetProperty(ref _ModifiedBy, value); }
        }
    }
}
