/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ICPDReports.cs
Function           :   Interface for CPD Reports
Created By         :   Pawan 
Created on         :   12-March-2019
Revision History   :   [22-May-2020] : Pawan
*                  :   Added interface for Material Inventory and first Receipt
*                  :   [13-Jul-2020] : Shivam Dhingra
*                  :   Added interface for MaterialChangeLog , SupplierMaterialChangeLog and MaterialSiteChangeLog
*                  :   [08-Sep-2021]: Shivam Kalia
*                  :   Added interface for MaterialShortageReportDHS                  
****************************************************************************************************/
using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    /// <summary>
    /// Interface for CPD Reports
    /// </summary>
    public interface ICPDReports : IService
    {
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);
        #region ETLConsolidatedMRPErrorList
        //  Task<IEnumerable<ETLConsolidatedMRPErrorListGridModel>> GetGridData(IEnumerable<ConsolidatedMRPErrorParamModel> paramModel);      
        //  Task<IEnumerable<ETLConsolidatedMRPErrorListGridModel>> GetDHSConsolidatedMRPErrorList(ConsolidatedMRPErrorParamModel paramModel);
        //  Task<IEnumerable<ETLConsolidatedMRPErrorListGridModel>> GetConsolidatedMRPErrorList(ConsolidatedMRPErrorParamModel ConsolidatedParamModel);

        Task<string> GetGridDataConsolidatedMRPErrorList(string paramModel);
     //   Task<string> GetByFilterConsolidatedMRPErrorList(IEnumerable<FilterCollectionModel> filterList);
        #endregion

        //#region ETLFirstReceiptDate
        //Task<string> GetGridDataFirstReceiptDate();
        //Task<string> GetGridDataWithFilterFirstReceiptDate(FirstReceiptDateSearchModel model);
        //#endregion

       // #region ETLMaterialInventory
       // Task<string> GetGridDataMaterialInventory();
       // Task<string> GetGridDataByFilterMaterialInventory(MaterialInventorySearchModel materialInventorySearchModel);
       //// Task<string> GetByFilterMaterialInventory(IEnumerable<FilterCollectionModel> filterList);
       // #endregion

        #region MaterialNoXReference
        //Task<string> GetGridData(ETLMaterialNoXReferenceGridModel model);
        Task<string> GetGridDataMaterialNoXReference(string model);
        //     Task<string> GetByFilterMaterialNoXReference(IEnumerable<FilterCollectionModel> filterList);
        #endregion

        #region FirstReceipt
        Task<string> GetGridDataFirstReceipt(string model);
        #endregion
        #region MaterialInventory
        Task<string> GetGridDataMaterialInventory(string model);
        #endregion

        // #region ETLMaterialOrigin
        // Task<IEnumerable<ETLMaterialOriginGridModel>> GetGridDataMaterialOrigin();
        // Task<string> GetGridDataByFilterMaterialOrigin(MaterialOriginSearchModel materialOriginSearchModel);
        //// Task<string> GetByFilterMaterialOrigin(IEnumerable<FilterCollectionModel> filterList);
        // #endregion

        #region ETLSupplierCapacityPlanning
        // Task<IEnumerable<ETLSupplierCapacityPlanningGridModel>> GetGridData(SupplierCapacityPlanningSearchModel supplierCapacityPlanningSearchModel);
        Task<string> GetGridDataSupplierCapacityPlanning(string supplierCapacityPlanningSearchModel);
        #endregion

        #region ETLMaterialChangeLog

        Task<string> GetGridDataMaterialChangeLog(string MAterialChangeLogParamModel);

        #endregion


        #region SupplierMaterialChangeLog

        Task<string> GetGridDataSupplierMaterialChangeLog(string SupplierMaterialChangeLog);

        #endregion

        #region MaterialSiteChangeLog

        Task<string> GetGridDataMaterialSiteChangeLog(string MaterialSiteChangeLog);

        #endregion

        #region MaterialShortageReportDHS
        Task<string> GetMaterialShortageReportDHSData(string materialShortageReportDHSProcedureParameterModel);
        #endregion

    }
}
