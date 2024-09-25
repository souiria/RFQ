/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ISupplierMaterialUploadValidations.cs
Function           :   Supplier Material Upload Functionality
Created By         :   Amit Agarwal
Created on         :   31-May-2018
Revision History   :   [02-Jan-2020] : Dharmendra Kumar
 *                 :   [ ] : Add new method SupplierMaterialMaintenanceUploadValidationsOnSQLServer()
 ****************************************************************************************************/
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.GlobalMastersAssociation
{
    public interface ISupplierMaterialUploadValidations: IService
    {
        //  Task<IEnumerable<SupplierMaterialUploadModel>> ValidateSupplierMaterialUploadData(IEnumerable<SupplierMaterialUploadModel> modelList);
        Task<string> ValidateSupplierMaterialUploadData(string objData);
        Task<string> SupplierMaterialMaintenanceUploadValidationsOnSQLServer(string objData);
    }
}
