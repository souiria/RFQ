/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ServiceEndpointRoutesFinance.cs
Function           :   ServiceEndpointRoutes Finance
Created By         :   Shivam Dhingra
Created on         :   28-Feb-2022
Revision History   :   [08-Mar-202] : Sejal Srivastava
                   :   [] Added new endpoint GetBusinessUnitFGPurchasedPriceAssociation and SaveBusinessUnitFGPurchasedPriceAssociation
                   :   [14-Mar-2023] : Prakhar Singh
                   :   [] Added new endpoint GetFGSupplierInvoiceReconciliation and ProcessOperationFGSupplierInvoiceReconciliation
                   :   [21-Jul-2023] : Ranjay
                   :   [] Added new endpoint GetFGPurchasedPriceAlertFilterData,ShowFGPurchasedPriceAlertData, SaveFGPurchasedPriceAlertData
                   :   [19-Oct-2023] : Prakhar
                   :   [] Added new endpoint GetFinanceDataSyncConfigurationSetup,ProcessOperationFinanceDataSyncConfigurationSetup, DataSyncFunctionDropDown,SyncFinanceDataSyncConfigurationSetupToWMS.
                   :   [10-Jan-2024] : Prakhar
                   :   [HD-00395018] Added new endpoint ExportFGSupplierInvoiceReconciliationPriceDifferenceRecap
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {
        public static readonly ServiceEndpointRoutes GetCustomerProductTransferPrice = new ServiceEndpointRoutes("Finance/CustomerProductTransferPrice/CustomerProductTransferPriceByProcedure");
        public static readonly ServiceEndpointRoutes CustomerProductTransferPrice = new ServiceEndpointRoutes("Finance/CustomerProductTransferPrice");
        public static readonly ServiceEndpointRoutes UploadCustomerProductTransferPrice = new ServiceEndpointRoutes("Finance/CustomerProductTransferPrice/UploadCustomerProductTransferPrice");
        public static readonly ServiceEndpointRoutes GetBusinessUnitFGPurchasedPriceAssociation = new ServiceEndpointRoutes("Finance/BusinessUnitFGPurchasedPriceAssociation/GetBusinessUnitFGPurchasedPriceAssociation");
        public static readonly ServiceEndpointRoutes SaveBusinessUnitFGPurchasedPriceAssociation = new ServiceEndpointRoutes("Finance/BusinessUnitFGPurchasedPriceAssociation");
        public static readonly ServiceEndpointRoutes GetFGSupplierInvoiceReconciliation = new ServiceEndpointRoutes("Finance/FGSupplierInvoiceReconciliation/GetFGSupplierInvoiceReconciliation");
        public static readonly ServiceEndpointRoutes ProcessOperationFGSupplierInvoiceReconciliation = new ServiceEndpointRoutes("Finance/FGSupplierInvoiceReconciliation/ProcessOperationFGSupplierInvoiceReconciliation");
        public static readonly ServiceEndpointRoutes GetFGPurchasedPriceAlertFilterData = new ServiceEndpointRoutes("Finance/FGPurchasedPriceAlert/GetFGPurchasedPriceAlertFilterData");
        public static readonly ServiceEndpointRoutes ShowFGPurchasedPriceAlertData = new ServiceEndpointRoutes("Finance/FGPurchasedPriceAlert/ShowFGPurchasedPriceAlert");
        public static readonly ServiceEndpointRoutes SaveFGPurchasedPriceAlertData = new ServiceEndpointRoutes("Finance/FGPurchasedPriceAlert/ProcessOperation");
        public static readonly ServiceEndpointRoutes GetFinanceDataSyncConfigurationSetup = new ServiceEndpointRoutes("Finance/FinanceDataSyncConfigurationSetup/GetFinanceDataSyncConfigurationSetup");
        public static readonly ServiceEndpointRoutes ProcessOperationFinanceDataSyncConfigurationSetup = new ServiceEndpointRoutes("Finance/FinanceDataSyncConfigurationSetup/ProcessOperationFinanceDataSyncConfigurationSetup");
        public static readonly ServiceEndpointRoutes DataSyncFunctionDropDown = new ServiceEndpointRoutes("Finance/FinanceDataSyncConfigurationSetup/DataSyncFunctionDropDown");
        public static readonly ServiceEndpointRoutes SyncFinanceDataSyncConfigurationSetupToWMS = new ServiceEndpointRoutes("Finance/FinanceDataSyncConfigurationSetup/SyncFinanceDataSyncConfigurationSetupToWMS");
        public static readonly ServiceEndpointRoutes ExportFGSupplierInvoiceReconciliationPriceDifferenceRecap = new ServiceEndpointRoutes("Finance/FGSupplierInvoiceReconciliation/ExportFGSupplierInvoiceReconciliationPriceDifferenceRecap");

    }
}
