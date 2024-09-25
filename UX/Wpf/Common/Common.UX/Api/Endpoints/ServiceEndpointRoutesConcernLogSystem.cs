/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name           :   ServiceEndpointRoutesConcernLogSystem.cs
Function            :  	Maintaining all endpoints to connect service for Concern Log System
Created By          :   MIND Team
Created on          :   09-Oct-2023
Revision History    :   [05-Oct-2023] : Piyush Anand
                    :   [] : Added two endpoints GetDepartmentMaster & ProcessOperationDepartmentMaster
                    :   [05-Oct-2023] : Sachin Pandey
                    :   [] : Added two endpoints GetConcernCodeData & ProcessOperationCodeConcernData
                    :   [05-Oct-2023] : Prakhar
                    :   [] : Added two endpoints GetSupplierRoleMaster,ProcessOperationSupplierRoleMaster,GetConcernClassification and ProcessOperationConcernClassification
                    :   [18-Oct-2023] : Vishwadeep Singh
                    :   [] : Added two endpoints CustomerLocationAssociation,GetCustomerLocationAssociation
                    :   [01-Nov-2023] : Piyush Anand
                    :   [] : Added Four endpoints GetBusinessUnitName,GetCustomerName,CustomerOriginatorUserMaster and GetCustomerOriginatorUserMaster
                    :   [05-Feb-2024] : Piyush Anand
                    :   [] : Added two endpoints GetCLSStatusEnquiry and GetAllCLSStateChangeLogData
****************************************************************************************************/
namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {
        public static readonly ServiceEndpointRoutes GetDepartmentMaster = new ServiceEndpointRoutes("ConcernLogSystem/DepartmentMaster/GetDepartmentMaster"); //Piyush Anand 
        public static readonly ServiceEndpointRoutes ProcessOperationDepartmentMaster = new ServiceEndpointRoutes("ConcernLogSystem/DepartmentMaster/ProcessOperationDepartmentMaster"); //Piyush Anand
        public static readonly ServiceEndpointRoutes GetConcernCodeData = new ServiceEndpointRoutes("ConcernLogSystem/ConcernCode/GetConcernCodeData");//Sachin
        public static readonly ServiceEndpointRoutes ProcessOperationCodeConcernData = new ServiceEndpointRoutes("ConcernLogSystem/ConcernCode/ProcessOperationConcernCode");//Sachin
        public static readonly ServiceEndpointRoutes GetSupplierRoleMaster = new ServiceEndpointRoutes("ConcernLogSystem/SupplierRoleMaster/GetSupplierRoleMaster");//Prakhar
        public static readonly ServiceEndpointRoutes ProcessOperationSupplierRoleMaster = new ServiceEndpointRoutes("ConcernLogSystem/SupplierRoleMaster/ProcessOperationSupplierRoleMaster");//Prakhar
        public static readonly ServiceEndpointRoutes GetConcernClassification = new ServiceEndpointRoutes("ConcernLogSystem/ConcernClassification/GetConcernClassification");//Prakhar
        public static readonly ServiceEndpointRoutes ProcessOperationConcernClassification = new ServiceEndpointRoutes("ConcernLogSystem/ConcernClassification/ProcessOperationConcernClassification");//Prakhar
        public static readonly ServiceEndpointRoutes CustomerLocationAssociation = new ServiceEndpointRoutes("ConcernLogSystem/CustomerLocationAssociation");//Vishwadeep
        public static readonly ServiceEndpointRoutes GetCustomerLocationAssociation = new ServiceEndpointRoutes("ConcernLogSystem/CustomerLocationAssociation/GetCustomerLocationAssociation");//Vishwadeep
        public static readonly ServiceEndpointRoutes GetBusinessUnitName = new ServiceEndpointRoutes("ConcernLogSystem/CustomerOriginatorUserMaster/GetBusinessUnitNameCUM");//piyush anand
        public static readonly ServiceEndpointRoutes GetCustomerName = new ServiceEndpointRoutes("ConcernLogSystem/CustomerOriginatorUserMaster/GetCustomerName");//piyush anand
        public static readonly ServiceEndpointRoutes CustomerOriginatorUserMaster = new ServiceEndpointRoutes("ConcernLogSystem/CustomerOriginatorUserMaster");//piyush anand
        public static readonly ServiceEndpointRoutes GetCustomerOriginatorUserMaster = new ServiceEndpointRoutes("ConcernLogSystem/CustomerOriginatorUserMaster/GetCustomerOriginatorUserMaster");//piyush anand

        #region Concern Log screen
        public static readonly ServiceEndpointRoutes ConcernLogSystem = new ServiceEndpointRoutes("ConcernLogSystem/ConcernLogSystem");
        public static readonly ServiceEndpointRoutes GetMastersForCLS = new ServiceEndpointRoutes("ConcernLogSystem/CLS/GetMastersForCLS");
        public static readonly ServiceEndpointRoutes GetMasterDataBasedOnModelType = new ServiceEndpointRoutes("ConcernLogSystem/CLS/GetMasterDataBasedOnModelType");//Virendra
        public static readonly ServiceEndpointRoutes ProcessConcernLogSystemDetail = new ServiceEndpointRoutes("ConcernLogSystem/CLS/ProcessConcernLogSystemDetail");//Virendra
        public static readonly ServiceEndpointRoutes Accepted_AnalyserFiveY_RouteCauseAnalysis_ByOriginator = new ServiceEndpointRoutes("ConcernLogSystem/CLS/Accepted_AnalyserFiveY_RouteCauseAnalysis_ByOriginator");//Virendra
        public static readonly ServiceEndpointRoutes GetConcernLogSystem = new ServiceEndpointRoutes("ConcernLogSystem/CLS/GetConcernLogSystem");//Virendra
        public static readonly ServiceEndpointRoutes GetConcernLogSystemDetail = new ServiceEndpointRoutes("ConcernLogSystem/CLS/GetConcernLogSystemDetail");//Virendra
        public static readonly ServiceEndpointRoutes H1_SearchCLSDetail = new ServiceEndpointRoutes("ConcernLogSystem/CLS/H1_SearchCLSDetail");//Virendra
        //public static readonly ServiceEndpointRoutes GetAnalyzerandFYDetail = new ServiceEndpointRoutes("ConcernLogSystem/CLS/GetAnalyzerandFYDetail");//Sachin

        public static readonly ServiceEndpointRoutes CancelConcern = new ServiceEndpointRoutes("ConcernLogSystem/CLS/CancelConcern");//Vishwadeep Singh

        #endregion

        public static readonly ServiceEndpointRoutes ProcessOperationGenerateCLSOTP = new ServiceEndpointRoutes("ConcernLogSystem/GenerateAndValidateCLSOTP/ProcessOperationGenerateCLSOTP");
        public static readonly ServiceEndpointRoutes ValidateCLSOTP = new ServiceEndpointRoutes("ConcernLogSystem/GenerateAndValidateCLSOTP/ValidateCLSOTP");
        public static readonly ServiceEndpointRoutes UpdatePasswordCLS = new ServiceEndpointRoutes("ConcernLogSystem/SupplierUserMaster/UpdatePasswordCLS");//Sachin
        public static readonly ServiceEndpointRoutes GetAnalyzerDetailbyUser = new ServiceEndpointRoutes("ConcernLogSystem/AnalyzerDetail/GetAnalyzerDetailbyUser");//Sachin
        public static readonly ServiceEndpointRoutes GetshadowlistforCustomerOriginator = new ServiceEndpointRoutes("ConcernLogSystem/CustomerOriginatorUserMaster/GetshadowlistforCustomerOriginator");
        public static readonly ServiceEndpointRoutes GetAnalyzerById = new ServiceEndpointRoutes("ConcernLogSystem/AnalyzerFeedBack/GetAnalyzerFeedBack");
        public static readonly ServiceEndpointRoutes saveAnalayzerFeedback = new ServiceEndpointRoutes("ConcernLogSystem/AnalyzerFeedBack/ProcessOperationAnalyzerFeedBack");

        public static readonly ServiceEndpointRoutes GetSupplierUserMasterData = new ServiceEndpointRoutes("ConcernLogSystem/SupplierUserMaster/GetSupplierUserMasterData");//Sachin
        public static readonly ServiceEndpointRoutes ProcessOperationSupplierUserMaster = new ServiceEndpointRoutes("ConcernLogSystem/SupplierUserMaster/ProcessOperationSupplierUserMaster");//Sachin
        public static readonly ServiceEndpointRoutes GetDepartmentName = new ServiceEndpointRoutes("ConcernLogSystem/SupplierUserMaster/GetDepartmentName");//Sachin
        public static readonly ServiceEndpointRoutes GetRoleName = new ServiceEndpointRoutes("ConcernLogSystem/SupplierUserMaster/GetRoleName");//Sachin
        public static readonly ServiceEndpointRoutes GetADUserName = new ServiceEndpointRoutes("ConcernLogSystem/SupplierUserMaster/GetADUserName");//Sachin
        public static readonly ServiceEndpointRoutes RandomPassword = new ServiceEndpointRoutes("ConcernLogSystem/SupplierUserMaster/RandomPassword");//Sachin
        public static readonly ServiceEndpointRoutes ResetPassword = new ServiceEndpointRoutes("ConcernLogSystem/SupplierUserMaster/ResetPassword");//Sachin
        public static readonly ServiceEndpointRoutes IssueUsername = new ServiceEndpointRoutes("ConcernLogSystem/SupplierUserMaster/IssueUsername");//Sachin
        public static readonly ServiceEndpointRoutes IssueUsernameandResetPassword = new ServiceEndpointRoutes("ConcernLogSystem/SupplierUserMaster/IssueUsernameandResetPassword");//Sachin
        public static readonly ServiceEndpointRoutes GetSupplierUserMasterDataByFilter = new ServiceEndpointRoutes("ConcernLogSystem/SupplierUserMaster/GetSupplierUserMasterDataByFilter");//Virendra


        public static readonly ServiceEndpointRoutes GetCLSStatusEnquiry = new ServiceEndpointRoutes("ConcernLogSystem/CLSStatusEnquiry/GetCLSStatusEnquiry");//piyush anand
        public static readonly ServiceEndpointRoutes GetAllCLSStateChangeLogData = new ServiceEndpointRoutes("ConcernLogSystem/CLSStatusEnquiry/GetAllCLSStateChangeLogData");//piyush anand

        public static readonly ServiceEndpointRoutes GetBusinessunitCLS = new ServiceEndpointRoutes("ConcernLogSystem/CustomerLocationAssociation/GetBusinessunitCLS");
        public static readonly ServiceEndpointRoutes GetMastersForCustomerLocationAssociation = new ServiceEndpointRoutes("ConcernLogSystem/CustomerLocationAssociation/GetMastersForCustomerLocationAssociation");

        #region Controller Screen
        public static readonly ServiceEndpointRoutes SaveConcernAssignToAnalyser = new ServiceEndpointRoutes("ConcernLogSystem/CLS/SaveConcernAssignToAnalyser");//Virendra
        public static readonly ServiceEndpointRoutes GetConcernAssignToAnalyser = new ServiceEndpointRoutes("ConcernLogSystem/CLS/GetConcernAssignToAnalyser");//Virendra
        public static readonly ServiceEndpointRoutes CLS_SubmitToAnalyser = new ServiceEndpointRoutes("ConcernLogSystem/CLS/CLS_SubmitToAnalyser");//Virendra
        public static readonly ServiceEndpointRoutes ReturnConcernToOriginatorByController = new ServiceEndpointRoutes("ConcernLogSystem/CLS/ReturnConcernToOriginatorByController");//Virendra
        public static readonly ServiceEndpointRoutes H1_GetMissingAnalyserOfConcern = new ServiceEndpointRoutes("ConcernLogSystem/CLS/H1_GetMissingAnalyserOfConcern");//Virendra
        public static readonly ServiceEndpointRoutes GetConcernAssignToAnalyserByConcernLogSystemId = new ServiceEndpointRoutes("ConcernLogSystem/CLS/GetConcernAssignToAnalyserByConcernLogSystemId");//Virendra
        public static readonly ServiceEndpointRoutes ReturnFiveWhyAnalysisToAnalyser = new ServiceEndpointRoutes("ConcernLogSystem/CLS/ReturnFiveWhyAnalysisToAnalyser");//Virendra
        public static readonly ServiceEndpointRoutes Submit_AnalyserFiveY_RouteCauseAnalysis_ControllerToOriginator = new ServiceEndpointRoutes("ConcernLogSystem/CLS/Submit_AnalyserFiveY_RouteCauseAnalysis_ControllerToOriginator");//Virendra
        #endregion
        
        #region CLS Email Configuration Settings
        public static readonly ServiceEndpointRoutes GetFieldDataList = new ServiceEndpointRoutes("ConcernLogSystem/CLSEmailConfiguration/GetFieldDataList");//piyush anand
        public static readonly ServiceEndpointRoutes GetCLSEmailConfiguration = new ServiceEndpointRoutes("ConcernLogSystem/CLSEmailConfiguration/GetCLSEmailConfiguration");//Piyush anand
        public static readonly ServiceEndpointRoutes GetCLSStatusName = new ServiceEndpointRoutes("ConcernLogSystem/CLSEmailConfiguration/GetCLSStatusName");//piyush anand
        public static readonly ServiceEndpointRoutes SaveCLSEmailConfiguration = new ServiceEndpointRoutes("ConcernLogSystem/CLSEmailConfiguration/SaveCLSEmailConfiguration");//Virendra
        #endregion

        #region CLS Stages
        public static readonly ServiceEndpointRoutes GetCLSStatus = new ServiceEndpointRoutes("ConcernLogSystem/CLSStatus/GetCLSStatus");//piyush anand
        public static readonly ServiceEndpointRoutes ProcessOperationCLSStatus = new ServiceEndpointRoutes("ConcernLogSystem/CLSStatus/ProcessOperationCLSStatus");//Piyush Anand
        #endregion
        
        #region FYAnalysis
        public static readonly ServiceEndpointRoutes ProcessFYRouteCouseAnalysis = new ServiceEndpointRoutes("ConcernLogSystem/FiveWhysAndRouteCause/ProcessFYRouteCouseAnalysis");//Virendra
        public static readonly ServiceEndpointRoutes GetFYRouteCauseAnalysis = new ServiceEndpointRoutes("ConcernLogSystem/FiveWhysAndRouteCause/GetFYRouteCauseAnalysis");//Virendra
        public static readonly ServiceEndpointRoutes ProcessAnalyserEvidence = new ServiceEndpointRoutes("ConcernLogSystem/FiveWhysAndRouteCause/ProcessAnalyserEvidence");//Virendra
        #endregion


        public static readonly ServiceEndpointRoutes GetUserNamebasedonH1UserRegisterModel = new ServiceEndpointRoutes("ConcernLogSystem/CustomerOriginatorUserMaster/GetUserNamebasedonH1UserRegisterModel");//Vishwadeep Singh

    }
}