/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name           :   ServiceEndpointRoutesTransportManagement.cs
Function            :  	Maintaining all endpoints to connect service for Transport Management
Created By          :   MTSL Team
Created on          :   11-Mar-2024
Revision History    :   [07-Mar-2024] : Nishu 
*                   :   [] : Added two new endpoint GetProductCategoryData,ProcessProductCategory
*                   :   [15-Mar-2024] : Nishu 
*                   :   [] : Added two new endpoints GetPackageMasterData,ProcessPackageMaster
*                   :   [03-Apr-2024] : Nishu 
*                   :   [] : Added two new endpoints GetAllTransportSiteMaster,TransportSiteMasterProcessOperation
*                   :   [10-Apr-2024] : Nishu 
*                   :   [] : Added two new endpoints GetTransportMethodMasterData,ProcessTransportMethodMaster
*                   :   [29-Apr-2024] : Sachin Pandey 
*                   :   [] : Added two new endpoints GetTransportCustomerMappingData,ProcessTransportCustomerMapping
*                   :   [29-Apr-2024] : Nishu 
*                   :   [] : Added two new endpoints GetTMSSiteMaster,ProcessTMSSiteMaster
*                   :   [02-May-2024] : Nishu 
*                   :   [] : Added two new endpoints GetTMSSiteUserAssociation,ProcessTMSSiteUserAssociation
****************************************************************************************************/

namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {
       
        public static readonly ServiceEndpointRoutes GetFilteredTransportOrderForCombo = new ServiceEndpointRoutes("TransportManagement/TransportOrder/Filter");
        public static readonly ServiceEndpointRoutes GetAllTransportOrder = new ServiceEndpointRoutes("TransportManagement/TransportOrder");
        public static readonly ServiceEndpointRoutes ProcessTransportOrder = new ServiceEndpointRoutes("TransportManagement/TransportOrder/ProcessOperation");
        public static readonly ServiceEndpointRoutes GetProductCategoryData = new ServiceEndpointRoutes("TransportManagement/ProductCategory/GetProductCategoryData");//Nishu
        public static readonly ServiceEndpointRoutes ProcessProductCategory = new ServiceEndpointRoutes("TransportManagement/ProductCategory/ProcessProductCategory");//Nishu
        public static readonly ServiceEndpointRoutes GetAllSiteSequenceType = new ServiceEndpointRoutes("TransportManagement/SiteSequenceType");
        public static readonly ServiceEndpointRoutes SiteSequenceTypeProcessOperation = new ServiceEndpointRoutes("TransportManagement/SiteSequenceType/ProcessOperation");
        public static readonly ServiceEndpointRoutes GetPackageMasterData = new ServiceEndpointRoutes("TransportManagement/PackageMaster/GetPackageMasterData");//Nishu
        public static readonly ServiceEndpointRoutes ProcessPackageMaster = new ServiceEndpointRoutes("TransportManagement/PackageMaster/ProcessPackageMaster");//Nishu
        public static readonly ServiceEndpointRoutes GetTransportSiteMaster = new ServiceEndpointRoutes("TransportManagement/TransportSiteMaster/GetTransportSiteMaster");//Nishu
        public static readonly ServiceEndpointRoutes ProcessTransportSiteMaster = new ServiceEndpointRoutes("TransportManagement/TransportSiteMaster/ProcessTransportSiteMaster");//Nishu
        public static readonly ServiceEndpointRoutes GetTransportMethodMasterData = new ServiceEndpointRoutes("TransportManagement/TransportMethodMaster/GetTransportMethodMasterData");//Nishu
        public static readonly ServiceEndpointRoutes ProcessTransportMethodMaster = new ServiceEndpointRoutes("TransportManagement/TransportMethodMaster/ProcessTransportMethodMaster");//Nishu
        public static readonly ServiceEndpointRoutes SubmitTransportOrderToTMSandWMS = new ServiceEndpointRoutes("TransportManagement/TransportOrder/SubmitTO");
        public static readonly ServiceEndpointRoutes GetTransportCustomerMappingData = new ServiceEndpointRoutes("TransportManagement/TransportCustomerMapping/GetTransportCustomerMappingData");//Sachin
        public static readonly ServiceEndpointRoutes ProcessTransportCustomerMapping = new ServiceEndpointRoutes("TransportManagement/TransportCustomerMapping/ProcessTransportCustomerMapping");//Sachin
        public static readonly ServiceEndpointRoutes GetTMSSiteMaster = new ServiceEndpointRoutes("TransportManagement/TMSSiteMaster/GetTMSSiteMaster");//Nishu
        public static readonly ServiceEndpointRoutes ProcessTMSSiteMaster = new ServiceEndpointRoutes("TransportManagement/TMSSiteMaster/ProcessTMSSiteMaster");//Nishu
        public static readonly ServiceEndpointRoutes GetTMSSiteUserAssociation = new ServiceEndpointRoutes("TransportManagement/TMSSiteUserAssociation/GetTMSSiteUserAssociation");//Nishu
        public static readonly ServiceEndpointRoutes ProcessTMSSiteUserAssociation = new ServiceEndpointRoutes("TransportManagement/TMSSiteUserAssociation/ProcessTMSSiteUserAssociation");//Nishu

    }
}
