/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   AnalyserEvidencAnalysisModel.cs
Function           :   AnalyserEvidencAnalysisModel
Created By         :   Virendra
Created on         :   26-Feb-2024
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
    public class AnalyserEvidencAnalysisModel : BaseModel<Guid>
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
        /// Gets or Sets the caption value for [Evidence] [Grid] column 
        /// </summary>
        private string _evidence;
        [DataMember]
        public string Evidence
        {
            get { return _evidence; }
            set { SetProperty(ref _evidence, value); }
        }
    }
}
