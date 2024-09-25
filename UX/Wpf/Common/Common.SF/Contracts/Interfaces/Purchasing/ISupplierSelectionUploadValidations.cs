/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ISupplierSelectionUploadValidations.cs
Function           :   Supplier Selection Upload Functionality
Created By         :   Amit Agarwal
Created on         :   31-May-2018
Revision History   :   [27-Dec-2019] : Dharmendra
 *                 :   [] Add new Method SupplierSelectionUploadValdationsOnSQLServer()
****************************************************************************************************/
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface ISupplierSelectionUploadValidations : IService
    {
        //Task<IEnumerable<SupplierSelectionUploadModel>> SupplierSelectionUploadValdationsData(IEnumerable<SupplierSelectionUploadModel> modelList);
        Task<string> SupplierSelectionUploadValdationsData(string objData);
        Task<string> SupplierSelectionUploadValdationsOnSQLServer(string objData);
    }
}
