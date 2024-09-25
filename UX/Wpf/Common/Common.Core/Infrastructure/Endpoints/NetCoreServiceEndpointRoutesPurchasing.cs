/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   NetCoreServiceEndpointRoutes.cs
Function           :   NetCoreServiceEndpointRoutes
Created By         :   
Created on         :   
Revision History   :   [19-Oct-2019] : Srashti Gupta
*                  :   Added endpoint for CoreNPRWebService
****************************************************************************************************/
namespace Common.Core.Infrastructure.Endpoints
{
    public partial class NetCoreServiceEndpointRoutes
    {
        public static readonly NetCoreServiceEndpointRoutes CoreMaterialHierarchy = new NetCoreServiceEndpointRoutes("CentralPurchasing/api/SF.CentralPurchasing.CoreMaterialHierarchy/CoreMaterialHierarchy");
        public static readonly NetCoreServiceEndpointRoutes CoreMaterialHierarchyPartitions = new NetCoreServiceEndpointRoutes("H1.CentralPurchasing/SF.CentralPurchasing.CoreMaterialHierarchy/CoreMaterialHierarchy");
        public static readonly NetCoreServiceEndpointRoutes CoreNPRWebService = new NetCoreServiceEndpointRoutes("NPRWebService/NPRPartCheck");
    }
}