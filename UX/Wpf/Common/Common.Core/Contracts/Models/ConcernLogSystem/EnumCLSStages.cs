/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EnumCLSStages.cs
Function           :   Enum for CLS Stages
Created By         :   Vishwadeep Singh
Created on         :   02-Feb-2024
Revision History   :              
****************************************************************************************************/

namespace Common.Core.Contracts.Models.ConcernLogSystem
{
    /// <summary>
    /// 
    /// </summary>
    public enum CLSStage : int
    {
        Saved = 1,
        IssuedToController = 2,
        ReturnedToOriginator = 3,
        AssignedForAnalysisAndCorrectiveActionPlan = 4,
        AnalysisRequestRejectedAndReturnedToController = 5,
        AnalysisAndCorrectiveActionPlanSubmittedToController = 6,
        AnalysisAndCorrectiveActionPlanRejectedByContoller = 7,
        AnalysisAndCorrectiveActionPlanSubmittedToOriginator = 8,
        AnalysisAndCorrectiveActionPlanRejectedByOriginator = 9,
        ReAssignedForAnalysisAndCorrectiveActionPlan = 10,
        AnalysisAndCorrectiveActionPlanAcceptedByOriginator = 11,
        CorrectiveActionEffectivenessRejectedByOriginator = 12,
        CorrectiveActionEffectivenessAcceptedByOriginator = 13,
        RejectedByBusinessOwner = 14,
        ApprovedByBusinessOwner = 15,
        Cancelled = 99
    }
}
