/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ServiceEndpointRoutesYokoten.cs
Function           :   ServiceEndpointRoutes Yokoten
Created By         :   
Created on         :   
Revision History   :   [27-Feb-2020]:Srashti Gupta
*                  :   Added the ReportSection1 endpoint for ASP.NetCore Yokoten Service
*                  :   [04-Mar-2020]:Srashti Gupta
*                  :   Added the System endpoint for ASP.NetCore Yokoten Service
*                  :   [12-Mar-2020]:Srashti Gupta
*                  :   Added the ReportSection2 endpoint for ASP.NetCore Yokoten Service
*                  :   [19-Mar-2020]:Srashti Gupta
*                  :   Added the ReportSection3 endpoint for ASP.NetCore Yokoten Service
*                  :   [25-Mar-2020]: Shivam Dhingra
*                  :   Added YokotenReply endpoint for ASP.NetCore Yokoten Service
*                  :   [05-May-2020]:Srashti Gupta
*                  :   Added Dashboard endpoint for ASP.NetCore Yokoten Service
*                  :   [06-May-2020]:Srashti Gupta
*                  :   Added Confirmation endpoint for ASP.NetCore Yokoten Service
/**************************************************************************************************/
namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {
       
        #region Yokoten
        public static readonly ServiceEndpointRoutes ProcessType = new ServiceEndpointRoutes("Yokoten/api/SF.Yokoten.YokotenMastersCore/ProcessType");
        public static readonly ServiceEndpointRoutes QualityConcern = new ServiceEndpointRoutes("Yokoten/api/SF.Yokoten.YokotenMastersCore/QualityConcern");
        public static readonly ServiceEndpointRoutes ManufacturingProcessEquipment = new ServiceEndpointRoutes("Yokoten/api/SF.Yokoten.YokotenMastersCore/ManufacturingProcessEquipment");
        public static readonly ServiceEndpointRoutes ProductType = new ServiceEndpointRoutes("Yokoten/api/SF.Yokoten.YokotenMastersCore/ProductType");
        public static readonly ServiceEndpointRoutes Audit = new ServiceEndpointRoutes("Yokoten/api/SF.Yokoten.YokotenMastersCore/Audit");
        public static readonly ServiceEndpointRoutes ReportSection1 = new ServiceEndpointRoutes("Yokoten/api/SF.Yokoten.YokotenMastersCore/ReportSection1");
        public static readonly ServiceEndpointRoutes System = new ServiceEndpointRoutes("Yokoten/api/SF.Yokoten.YokotenMastersCore/System");
        public static readonly ServiceEndpointRoutes ReportSection2 = new ServiceEndpointRoutes("Yokoten/api/SF.Yokoten.YokotenMastersCore/ReportSection2");
        public static readonly ServiceEndpointRoutes ReportSection3 = new ServiceEndpointRoutes("Yokoten/api/SF.Yokoten.YokotenMastersCore/ReportSection3");
        public static readonly ServiceEndpointRoutes ReportAssociation = new ServiceEndpointRoutes("Yokoten/api/SF.Yokoten.YokotenMastersCore/ReportAssociation");
        public static readonly ServiceEndpointRoutes YokotenReply = new ServiceEndpointRoutes("Yokoten/api/SF.Yokoten.YokotenMastersCore/YokotenReply");
        public static readonly ServiceEndpointRoutes Dashboard = new ServiceEndpointRoutes("Yokoten/api/SF.Yokoten.YokotenMastersCore/Dashboard");
        public static readonly ServiceEndpointRoutes Confirmation = new ServiceEndpointRoutes("Yokoten/api/SF.Yokoten.YokotenMastersCore/Confirmation");

        #endregion

    }
}
