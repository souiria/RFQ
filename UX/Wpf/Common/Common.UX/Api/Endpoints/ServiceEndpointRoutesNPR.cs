/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name           :   ServiceEndpointRoutesPurchasing.cs
Function            :   Maintaining all endpoints to reach the service for NPR module
Created By          :   MIND Team
Created on          :   
Revision History    :   [22-Feb-2023] : Vishwadeep Singh 
                    :   [ ] : HD:00375862 : Add endpoints for CheckProjectHierarchyInNPR
                    :   [05-April-2023] : Virendra
                    :   [ ] :  Add endpoints for GetAllNPRStatus_Filter
                    :   [05-April-2023] : Virendra
                    :   [ ] :  Add endpoints for Show_NewPartRequest_StatusEnquiryParentRecord
                    :   [10-April-2023] : Virendra
                    :   [ ] :  Add endpoints for GetAllNPRStateChangeLogData
                    :   [27-Jun-2023] : Prakhar
                    :   [ ] :  Add endpoints GetBacklogDataBySupplierGuid
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
        //public static readonly ServiceEndpointRoutes NPRNewPartRequest = new ServiceEndpointRoutes("NewPartRequest");
        //public static readonly ServiceEndpointRoutes NPRNewPartRequeststateless = new ServiceEndpointRoutes("NPRWebService/NewPartRequest");
        //public static readonly ServiceEndpointRoutes ProjectDetails = new ServiceEndpointRoutes("ProjectDetails");
        public static readonly ServiceEndpointRoutes NPRPartSearch = new ServiceEndpointRoutes("NPRPartSearch/NPRPartSearchData");
        public static readonly ServiceEndpointRoutes NPRPartValidation = new ServiceEndpointRoutes("NPRPartValidation/ValidateNPRPart");
        public static readonly ServiceEndpointRoutes NPRType = new ServiceEndpointRoutes("NPRType");
        //Ajay:20-Aug-2019
        //New endpoint route added for CustomerProjectStatus to be integrated in ProjectDetails/RFQSupplierSelection
        //public static readonly ServiceEndpointRoutes CustomerProjectStatus = new ServiceEndpointRoutes("CustomerProjectStatus");
        public static readonly ServiceEndpointRoutes NPRNewPartRequestStateless = new ServiceEndpointRoutes("NPRWebService/NewPartRequest");
        public static readonly ServiceEndpointRoutes GetNewPartRequestFilterByIdStateless = new ServiceEndpointRoutes("NPRWebService/NewPartRequest/GetNewPartRequestFilterById");
        public static readonly ServiceEndpointRoutes NPRPartValidationStateless = new ServiceEndpointRoutes("NPRWebService/NewPartRequest/ValidateNPRPartData");
        public static readonly ServiceEndpointRoutes GetAllStateChangeLog = new ServiceEndpointRoutes("NPRWebService/NewPartRequest/GetAllNPRStateChangeLog");
        public static readonly ServiceEndpointRoutes NPRNewPartRequestfilterStateless = new ServiceEndpointRoutes("NPRWebService/NewPartRequest/GetAllFilteredDataNewpartRequest");
        public static readonly ServiceEndpointRoutes NPRBacklogfilterStateless = new ServiceEndpointRoutes("NPRWebService/NPRBacklog/GetNPRBackLogByFilter");

        public static readonly ServiceEndpointRoutes CheckProjectHierarchyInNPR = new ServiceEndpointRoutes("NPRWebService/NewPartRequest/CheckProjectHierarchyInNPR");
        
        public static readonly ServiceEndpointRoutes GetAllNPRStatus_Filter = new ServiceEndpointRoutes("NPRWebService/NPRStatusEnquiry/GetAllNPRStatus_Filter");
        public static readonly ServiceEndpointRoutes Show_NewPartRequest_StatusEnquiryParentRecord = new ServiceEndpointRoutes("NPRWebService/NPRStatusEnquiry/Show_NewPartRequest_StatusEnquiryParentRecord");
        public static readonly ServiceEndpointRoutes GetAllNPRStateChangeLogData = new ServiceEndpointRoutes("NPRWebService/NPRStatusEnquiry/GetAllNPRStateChangeLogData");
        public static readonly ServiceEndpointRoutes GetBacklogDataBySupplierGuid = new ServiceEndpointRoutes("NPRWebService/NPRBacklog/GetBacklogDataBySupplierGuid");
    }
}