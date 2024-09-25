/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name           :   IETLSupplierMaterialPOPricing.cs
Function            :   IETLSupplierMaterialPOPricing
Created By          : 
Created on          :   
Revision History    :   [28-April-2020] : Srashti Gupta
                        []: Remove route for GetGridDataWithFilter.
****************************************************************************************************/
using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Purchasing;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IETLSupplierMaterialPOPricing : IService
    {
        //Task<IEnumerable<ETLSupplierMaterialPOPricingGridModel>> GetGridData();
        //Task<string> GetGridDataWithFilter(PurchasingSupplierMaterialSearchModel purchasingSupplierMaterialSearchModel);

        Task<string> GetGridDataForReportWithFilter(PurchasingSupplierMaterialPOPricingSearchModel purchasingSupplierMaterialPOPricingSearchModel);
        Task<string> GetPOPriceListIncSupplierMaterial(POPriceListIncSupplierMaterialDetailsSearchModel pOPriceListIncSupplierMaterialDetailsSearchMode);
    }

}
