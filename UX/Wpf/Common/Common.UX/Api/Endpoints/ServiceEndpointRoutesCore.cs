/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ServiceEndpointRoutes.cs
Function           :   ServiceEndpointRoutes for Purchasing Module
Created By         :   
Created on         :  
Revision History   :   [06-April-2020] : Srashti Gupta
*                  :   Added the endpoint SupplierMaterialHierarchyUploadValidationsOnSQLServer.
*                  :   [06-April-2020] : Srashti Gupta
*                  :   Added the endpoint SupplierSelectionHierarchyUploadValidationsOnSQLServer and SupplierMaterialPOPricingHierarchyUploadValidationsOnSQLServer.
*                  :   [07-April-2020] : Srashti Gupta
*                  :   Modify the endpoint SupplierSelectionHierarchyUploadValidationsOnSQLServer and SupplierMaterialPOPricingHierarchyUploadValidationsOnSQLServer.
*                  :   [20-April-2020] : Srashti Gupta
*                  :   Remove the endpoints of old process of Upload for MaterialHierarchy.
*                  :   [22-April-2020] : Srashti Gupta
*                  :   Added the endpoints of SupplierInActivePropagationOnSQLServer for Propagartion.
 ****************************************************************************************************/

namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {
        #region Security

        public static readonly ServiceEndpointRoutes Security = new ServiceEndpointRoutes("Security");
        public static readonly ServiceEndpointRoutes SecurityGroupsByUser = new ServiceEndpointRoutes("Security/User");
        public static readonly ServiceEndpointRoutes RecursiveSecurityGroupsByUser = new ServiceEndpointRoutes("Security/User/Recursive");
        public static readonly ServiceEndpointRoutes Menu = new ServiceEndpointRoutes("Menu");
        public static readonly ServiceEndpointRoutes UserList = new ServiceEndpointRoutes("UserList");
        public static readonly ServiceEndpointRoutes UserListLaunchStatus = new ServiceEndpointRoutes("UserList/LaunchStatus");
        public static readonly ServiceEndpointRoutes UpdateUserHelpDeskCallandUserRoles = new ServiceEndpointRoutes("UserList/UpdateUserHelpDeskCallandUserRoles");

        #endregion

        #region Service Configuration

        public static readonly ServiceEndpointRoutes ServiceConfiguration = new ServiceEndpointRoutes("ServiceConfiguration");
        public static readonly ServiceEndpointRoutes Connections = new ServiceEndpointRoutes("Connections");
        public static readonly ServiceEndpointRoutes H1ConfigurationSetting = new ServiceEndpointRoutes("H1ConfigurationSetting");
        public static readonly ServiceEndpointRoutes H1ServiceConfigurationSetting = new ServiceEndpointRoutes("H1ServiceConfigurationSetting");
        public static readonly ServiceEndpointRoutes H1ConfigurationKey = new ServiceEndpointRoutes("H1ConfigurationKey");

        #endregion

        #region Logging

        public static readonly ServiceEndpointRoutes AuditLog = new ServiceEndpointRoutes("AuditLog");
        public static readonly ServiceEndpointRoutes AuditLogGetAllDataByModelName = new ServiceEndpointRoutes("AuditLog/GetAllDataByModelName");
        public static readonly ServiceEndpointRoutes ETLAuditLogMaterialChangeGridModelGetGridListByFilter = new ServiceEndpointRoutes("AuditLog/GetAllDataByModelName");
        #endregion

        #region Notifications

        public static readonly ServiceEndpointRoutes Notifications = new ServiceEndpointRoutes("Notifications");
        public static readonly ServiceEndpointRoutes Subscriptions = new ServiceEndpointRoutes("Subscriptions");

        #endregion

        #region User

        public static readonly ServiceEndpointRoutes User = new ServiceEndpointRoutes("User");
        public static readonly ServiceEndpointRoutes UserNotifications = new ServiceEndpointRoutes("User/Notification");
        public static readonly ServiceEndpointRoutes UserSubscriptions = new ServiceEndpointRoutes("User/Subscription");
        public static readonly ServiceEndpointRoutes UserPreferences = new ServiceEndpointRoutes("User/Preference");

        #endregion

        #region Validation

        public static readonly ServiceEndpointRoutes ValidateMaterialUploadData = new ServiceEndpointRoutes("MaterialUploadValidations/ValidateMaterialUploadData");
        public static readonly ServiceEndpointRoutes ValidateSupplierUploadData = new ServiceEndpointRoutes("SupplierUploadValidations/ValidateSupplierUploadData");
        public static readonly ServiceEndpointRoutes SupplierMaterialUploadValidations = new ServiceEndpointRoutes("SupplierMaterialUploadValidations/ValidateSupplierMaterialUpload");
        public static readonly ServiceEndpointRoutes SupplierSelectionUploadValidations = new ServiceEndpointRoutes("SupplierSelectionUploadValidations/ValidateSupplierSelectionUpload");
        public static readonly ServiceEndpointRoutes SupplierSelectionUploadValdationsOnSQLServer = new ServiceEndpointRoutes("SupplierSelectionUploadValidations/SupplierSelectionUploadValdationsOnSQLServer");
        public static readonly ServiceEndpointRoutes SupplierMaterialPOPricingUploadValidationsOnSQLServer = new ServiceEndpointRoutes("SupplierMaterialPOPricingUploadValidations/SupplierMaterialPOPricingUploadValidationsOnSQLServer");
        public static readonly ServiceEndpointRoutes SupplierMaterialMaintenanceUploadValidationsOnSQLServer = new ServiceEndpointRoutes("SupplierMaterialUploadValidations/SupplierMaterialMaintenanceUploadValidationsOnSQLServer");

        public static readonly ServiceEndpointRoutes SupplierMaterialHierarchyUploadValidationsOnSQLServer = new ServiceEndpointRoutes("HierarchyUploadValidation/SupplierMaterialHierarchyUploadValidationsOnSQLServer");
        public static readonly ServiceEndpointRoutes SupplierSelectionHierarchyUploadValidationsOnSQLServer = new ServiceEndpointRoutes("HierarchyUploadValidation/SupplierSelectionHierarchyUploadValidationsOnSQLServer");
        public static readonly ServiceEndpointRoutes SupplierMaterialPOPricingHierarchyUploadValidationsOnSQLServer = new ServiceEndpointRoutes("HierarchyUploadValidation/SupplierMaterialPOPricingHierarchyUploadValidationsOnSQLServer");
        public static readonly ServiceEndpointRoutes MaterialUploadValidationsOnSQLServer = new ServiceEndpointRoutes("GlobalMasters/MaterialHierarchy/MaterialUploadValidationsOnSQLServer");
        public static readonly ServiceEndpointRoutes SupplierInActivePropagationOnSQLServer = new ServiceEndpointRoutes("HierarchyUploadValidation/SupplierInActivePropagationOnSQLServer");
        #endregion
    }
}
