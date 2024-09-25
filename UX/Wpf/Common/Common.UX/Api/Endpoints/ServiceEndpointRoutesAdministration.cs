/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ServiceEndpointRoutes.cs
Function           :  Endpoint for UX accessing
Created By         :   Dharmendra
Created on         :  
Revision History   :  [09-Jun-2020] : Dharmenadra Kumar
                   :  []   Add new endpoint JsoxAudit
                   :  [07-Jul-2020] : Dharmenadra Kumar
                   :  []   Add new endpoint JsoxAuditUserPermission
                   :  [20-Jan-2021] : Dharmenadra Kumar
                   :  []   Add new endpoint GetJSoxH1UserRegitrationIformation & GetJSoxH1UserRegitrationHDCallIformation
                   :  [01-Mar-2021] : Dharmenadra Kumar
                   :  []   Add new endpoint H1UserList
                   :  [31-May-2021] : Ashish Dutta
                   :  []   Add new endpoint New Security Changes
                   :  [01-Jun-2021] : Dharmendra
                   :  []   Add new endpoint for User Group Associaiton
                   :  [02-Jun-2021] : Ashish Dutta
                   :  []   Add new endpoint for  Group Menu Associaiton
                   :  [28-Jun-2021] : Shivam Kalia
                   :  []   Add new endpoints for JSOXH1UserRegitration
                   :  [30-Jun-2021] : Dharmendra
                   :  []   Add new endpoint for get Custom Permission
                   :  [03-Jul-2021] : Dharmendra
                   :  []   Add new endpoint for get Custom group menu by user and GetAllGroupMenuAssociationIncludingCustomGroup
                   :  [21-Oct-2021] : Dharmendra
                   :  []   Add new endpoint  SyncH1UsersFromActiveDirectory 
                   :  [01-Nov-2023] : Piyush Anand
                   :  []   Add new endpoint  GetUserNamebasedonH1UserRegisterModel 
****************************************************************************************************/

using Common.Core.Infrastructure.Endpoints;

namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {
        #region Security
        
        public static readonly ServiceEndpointRoutes Access = new ServiceEndpointRoutes("Access");
        public static readonly ServiceEndpointRoutes FieldOverrideAccess = new ServiceEndpointRoutes("FieldOverride/FieldAccess");
        public static readonly ServiceEndpointRoutes FieldOverride = new ServiceEndpointRoutes("FieldOverride");
        public static readonly ServiceEndpointRoutes Hierarchy = new ServiceEndpointRoutes("Hierarchy");
        public static readonly ServiceEndpointRoutes HierarchyRoles = new ServiceEndpointRoutes("Hierarchy/Roles");

        public static readonly ServiceEndpointRoutes ServiceDataFilter = new ServiceEndpointRoutes("ServiceDataFilter");
        public static readonly ServiceEndpointRoutes ServiceDataFilterDataPermissions = new ServiceEndpointRoutes("ServiceDataFilter/DataFilters");
        public static readonly ServiceEndpointRoutes SecurityAudit = new ServiceEndpointRoutes("SecurityAudit");

        public static readonly ServiceEndpointRoutes JsoxAudit = new ServiceEndpointRoutes("AuditLog/ShowJsoxAuditReport");
        public static readonly ServiceEndpointRoutes JsoxAuditUserPermission = new ServiceEndpointRoutes("AuditLog/DisplayUserAuditScreenPermission");
        public static readonly ServiceEndpointRoutes GetJSoxH1UserRegitrationIformation = new ServiceEndpointRoutes("JSOXAudit/GetJSoxH1UserRegitrationIformation");        
        public static readonly ServiceEndpointRoutes GetJSoxH1UserRegitrationHDCallIformation = new ServiceEndpointRoutes("JSOXAudit/GetJSoxH1UserRegitrationHDCallIformation");
        public static readonly ServiceEndpointRoutes H1UserList = new ServiceEndpointRoutes("JSOXAudit/GetAllH1Users");
        #endregion

        #region Maintenance

        #region Performance

        public static readonly ServiceEndpointRoutes Performance = new ServiceEndpointRoutes("Performance");

        #endregion

        #region Masters

        public static readonly ServiceEndpointRoutes H1FunctionMaster = new ServiceEndpointRoutes("H1Function");
        public static readonly ServiceEndpointRoutes H1ModuleMaster = new ServiceEndpointRoutes("H1Module");
        public static readonly ServiceEndpointRoutes H1ViewMaster = new ServiceEndpointRoutes("H1View");
        public static readonly ServiceEndpointRoutes H1FieldMaster = new ServiceEndpointRoutes("H1Field");
        public static readonly ServiceEndpointRoutes FunctionControlSequenceType = new ServiceEndpointRoutes("FunctionControlSequenceType");
        public static readonly ServiceEndpointRoutes GetLastSequenceNumber = new ServiceEndpointRoutes("FunctionControlSequenceType/GenerateSequenceNumber");

        #endregion

        #region Associations

        public static readonly ServiceEndpointRoutes H1FunctionH1ModuleAssociation = new ServiceEndpointRoutes("H1FunctionH1ModuleAssociation");
        public static readonly ServiceEndpointRoutes H1ModuleH1ViewAssociation = new ServiceEndpointRoutes("H1ModuleH1ViewAssociation");
        public static readonly ServiceEndpointRoutes H1ViewH1FieldAssociation = new ServiceEndpointRoutes("H1ViewH1FieldAssociation");

        #endregion

        #region Resources

        public static readonly ServiceEndpointRoutes Languages = new ServiceEndpointRoutes("Languages");
        public static readonly ServiceEndpointRoutes Labels = new ServiceEndpointRoutes("Labels");
        public static readonly ServiceEndpointRoutes LanguageHierarchy = new ServiceEndpointRoutes("LanguageHierarchy");

        #endregion

        public static readonly ServiceEndpointRoutes ModuleOwner = new ServiceEndpointRoutes("ModuleOwner");
        public static readonly ServiceEndpointRoutes H1ServiceValidationSetting = new ServiceEndpointRoutes("H1ServiceValidationSetting");
        
        public static readonly ServiceEndpointRoutes BusinessProcessByCountryAndSites = new ServiceEndpointRoutes("BusinessProcessByCountryAndSites");
        public static readonly ServiceEndpointRoutes CoreBusinessProcessByCountryAndSites = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.CoreBusinessProcessByCountryAndSites);
        public static readonly ServiceEndpointRoutes CoreCountryUserFunctionAssociation = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.CoreCountryUserFunctionAssociation);


        #endregion

        #region New Security Changes
        public static readonly ServiceEndpointRoutes GroupMaster = new ServiceEndpointRoutes("Administration/api/GetGroup");
        public static readonly ServiceEndpointRoutes ProcessGroupMaster = new ServiceEndpointRoutes("Administration/api/ProcessGroupRecord");
        public static readonly ServiceEndpointRoutes GetGroupNameList = new ServiceEndpointRoutes("Administration/api/GetGroupName");
        public static readonly ServiceEndpointRoutes GetUsersDetailList = new ServiceEndpointRoutes("Administration/api/GetUsers");
        public static readonly ServiceEndpointRoutes GetUserGroupById = new ServiceEndpointRoutes("Administration/api/GetUserGroupById");
        public static readonly ServiceEndpointRoutes ProcessUserGroupAssociation = new ServiceEndpointRoutes("Administration/api/ProcessUserGroupAssociation");
        public static readonly ServiceEndpointRoutes GetGroupMenuAssociation = new ServiceEndpointRoutes("Administration/api/GetGroupMenuAssociation");
        public static readonly ServiceEndpointRoutes ProcessGroupMenuAssociation = new ServiceEndpointRoutes("Administration/api/ProcessGroupMenuAssociation");
        public static readonly ServiceEndpointRoutes GetMenuName = new ServiceEndpointRoutes("Administration/api/GetMenu");
        public static readonly ServiceEndpointRoutes UserScreenAccessPermission = new ServiceEndpointRoutes("Administration/api/GetUserScreenAccessPermission");
        public static readonly ServiceEndpointRoutes GetJSoxH1UserRegitrationIformationCore = new ServiceEndpointRoutes("Administration/api/GetJSoxH1UserRegitrationIformation");        
        public static readonly ServiceEndpointRoutes GetJSoxH1UserRegitrationHDCallIformationCore = new ServiceEndpointRoutes("Administration/api/GetJSoxH1UserRegitrationHDCallIformation");
        public static readonly ServiceEndpointRoutes GetCustomPermissionByUser = new ServiceEndpointRoutes("Administration/api/GetCustomPermissionByUser");
        public static readonly ServiceEndpointRoutes LoadMenu = new ServiceEndpointRoutes("Administration/api/LoadMenu");
        public static readonly ServiceEndpointRoutes GetAllGroupMenuAssociationIncludingCustomGroup = new ServiceEndpointRoutes("Administration/api/GetAllGroupMenuAssociationIncludingCustomGroup");
        public static readonly ServiceEndpointRoutes CustomGroupMenuByUser = new ServiceEndpointRoutes("Administration/api/CustomGroupMenuByUser");
        public static readonly ServiceEndpointRoutes SyncH1UsersFromActiveDirectory = new ServiceEndpointRoutes("Administration/api/SyncADH1User");
        //public static readonly ServiceEndpointRoutes GetUserNamebasedonH1UserRegisterModel = new ServiceEndpointRoutes("Administration/api/GetUserNamebasedonH1UserRegisterModel");//piyush anand
        #endregion
    }
}
