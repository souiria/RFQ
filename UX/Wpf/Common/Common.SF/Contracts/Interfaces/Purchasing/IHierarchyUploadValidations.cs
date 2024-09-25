/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IHierarchyUploadValidations.cs
Function           :   Interface for Upload in MaterialHierarchy
Created By         :   Srashti Gupta
Created on         :  
Revision History   :   [06-April-2020] : Srashti Gupta
*                  :   Added the definiton for SupplierMaterialMaintenanceUploadValidationsOnSQLServer().
*                  :   [06-April-2020] : Srashti Gupta
*                  :   Added the definiton for SupplierSelectionHierarchyUploadValidationsOnSQLServer() & SupplierMaterialPOPricingHierarchyUploadValidationsOnSQLServer().
*                  :   [20-April-2020] : Srashti Gupta
*                  :   Remove the old process of Upload.
*                  :   [22-April-2020] : Srashti Gupta
*                  :   Added the definiton for  SupplierInActivePropagationOnSQLServer for Propagartion.
 ****************************************************************************************************/
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IHierarchyUploadValidations : IService
    {
        Task<string> MaterialUploadValidationsOnSQLServer(string modelList);
        Task<string> SupplierMaterialMaintenanceUploadValidationsOnSQLServer(string modelList);
        Task<string> SupplierSelectionHierarchyUploadValidationsOnSQLServer(string modelList);
        Task<string> SupplierMaterialPOPricingHierarchyUploadValidationsOnSQLServer(string modelList);
        Task<string> SupplierInActivePropagationOnSQLServer(string modelList);
    }
}
