/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ISupplierMaterialPOPricingUploadValidations.cs
Function           :   Supplier Material PO Pricing Upload Functionality
Created By         :   Dharmendra Kumar 
Created on         :   30-Dec-2019
Revision History   :   
****************************************************************************************************/
using Microsoft.ServiceFabric.Services.Remoting;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface ISupplierMaterialPOPricingUploadValidations : IService
    {
        Task<string> SupplierMaterialPOPricingUploadValidationsOnSQLServer(string objData);
          
    }
}
