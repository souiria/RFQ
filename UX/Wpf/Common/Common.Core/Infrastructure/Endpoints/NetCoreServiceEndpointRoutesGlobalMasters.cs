/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   NetCoreServiceEndpointRoutes.cs
Function           :   Endpoints to create a proxy of Core Services
Created By         :  
Created on         :   
Revision History   :  [25-May-2020] : Srashti Gupta
*                  :  Added endpoints for CoreLiabilityTypePartitions, CoreDefectTypePartitions, CoreHarnessFamilyGroupPartitions
*                  :  [10-June-2020] : Srashti Gupta
*                  :  Added endpoints for CorePurchasingCustomerMaster, CorePurchasingVehicleMaster, CorePurchasingFacilityMaster
*                  :  [02-Sep-2020] : Dharmendra
*                  :  Comment endpoints for CorePurchasingCustomerMaster, CorePurchasingVehicleMaster, CorePurchasingFacilityMaster
*                  :  [16-Oct-2020] : Srashti Gupta
*                  :  Comment endpoints for CoreCustomerBusinessUserAssociationPartitions
*                  :  [27-Oct-2020] : Srashti Gupta
*                  :  Comment endpoints for BusinessUnit, BusinessUnitType
*                  :  [30-Oct-2020] : Srashti Gupta
*                  :  Added endpoints for CoreCustomerProductList
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Infrastructure.Endpoints
{
    public partial class NetCoreServiceEndpointRoutes
    {
        public static readonly NetCoreServiceEndpointRoutes CoreDefectType = new NetCoreServiceEndpointRoutes("GlobalMasters/api/SF.GlobalMastersCore.Masters/DefectType");
        public static readonly NetCoreServiceEndpointRoutes CoreLiabilityType = new NetCoreServiceEndpointRoutes("GlobalMasters/api/SF.GlobalMastersCore.Masters/LiabilityType");
        public static readonly NetCoreServiceEndpointRoutes CoreHarnessFamilyGroup = new NetCoreServiceEndpointRoutes("GlobalMasters/api/SF.GlobalMastersCore.Masters/HarnessFamilyGroup");
        public static readonly NetCoreServiceEndpointRoutes CoreGetCustomerProductList = new NetCoreServiceEndpointRoutes("GlobalMasters/ConsolidatedCustomerProduct/GetAll");
        public static readonly NetCoreServiceEndpointRoutes CoreCustomerProductList = new NetCoreServiceEndpointRoutes("GlobalMasters/ConsolidatedCustomerProduct");

        public static readonly NetCoreServiceEndpointRoutes CoreLiabilityTypePartitions = new NetCoreServiceEndpointRoutes("GlobalMastersCore/SF.GlobalMastersCore.Masters/LiabilityType");
        public static readonly NetCoreServiceEndpointRoutes CoreDefectTypePartitions = new NetCoreServiceEndpointRoutes("GlobalMastersCore/SF.GlobalMastersCore.Masters/DefectType");
        public static readonly NetCoreServiceEndpointRoutes CoreHarnessFamilyGroupPartitions = new NetCoreServiceEndpointRoutes("GlobalMastersCore/SF.GlobalMastersCore.Masters/HarnessFamilyGroup");

        public static readonly NetCoreServiceEndpointRoutes CoreCustomerBusinessUserAssociationPartitions = new NetCoreServiceEndpointRoutes("GlobalMasters.Association3/SF.GlobalMastersAssociationCore.AssociationMasters/CustomerBusinessUserAssociation");
        
        public static readonly NetCoreServiceEndpointRoutes BusinessUnit = new NetCoreServiceEndpointRoutes("Core.Api/SF.Core.Api/BusinessUnit");
        public static readonly NetCoreServiceEndpointRoutes BusinessUnitType = new NetCoreServiceEndpointRoutes("Core.Api/SF.Core.Api/BusinessUnitType");
        public static readonly NetCoreServiceEndpointRoutes GetCustomerVehicleProduct = new NetCoreServiceEndpointRoutes("GlobalMasters/ProductMaster/GetCustomerVehicleProduct");
        public static readonly NetCoreServiceEndpointRoutes GetCustomerBuisnessGroupNameVehicleProduct = new NetCoreServiceEndpointRoutes("GlobalMasters/ProductMaster/GetCustomerBuisnessGroupNameVehicleProduct");

        //public static readonly NetCoreServiceEndpointRoutes CorePurchasingCustomerMaster = new NetCoreServiceEndpointRoutes("GlobalMasters/api/SF.GlobalMastersCore.Masters/PurchasingCustomerMaster");
        //public static readonly NetCoreServiceEndpointRoutes CorePurchasingVehicleMaster = new NetCoreServiceEndpointRoutes("GlobalMasters/api/SF.GlobalMastersCore.Masters/PurchasingVehicleMaster");
        //public static readonly NetCoreServiceEndpointRoutes CorePurchasingFacilityMaster = new NetCoreServiceEndpointRoutes("GlobalMasters/api/SF.GlobalMastersCore.Masters/PurchasingFacilityMaster");

        //public static readonly NetCoreServiceEndpointRoutes CorePurchasingCustomerPartitions = new NetCoreServiceEndpointRoutes("GlobalMastersCore/SF.GlobalMastersCore.Masters/PurchasingCustomerMaster");
        //public static readonly NetCoreServiceEndpointRoutes CorePurchasingVehicleMasterPartitions = new NetCoreServiceEndpointRoutes("GlobalMastersCore/SF.GlobalMastersCore.Masters/PurchasingVehicleMaster");
        //public static readonly NetCoreServiceEndpointRoutes CorePurchasingFacilityMasterPartitions = new NetCoreServiceEndpointRoutes("GlobalMastersCore/SF.GlobalMastersCore.Masters/PurchasingFacilityMaster");
    }
}