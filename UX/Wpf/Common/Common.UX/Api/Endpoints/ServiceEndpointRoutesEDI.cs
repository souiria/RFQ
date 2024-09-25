/**************************************************************************************************
(C) 2024 SEWS-E Ltd., All rights reserved
File Name          :   ServiceEndpointRoutesEDI.cs
Function           :   ServiceEndpointRoutes Sales EDI
Created By         :   
Created on         :   
/**************************************************************************************************/
namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {

        #region EDI
        // http://ukhqh1uat.sews-e.com:19081/Commercial.EDI.FrontEnd/Commercial.EDI.API/swagger/index.html
        public static readonly ServiceEndpointRoutes EDI = new ServiceEndpointRoutes("Commercial.EDI.FrontEnd/Commercial.EDI.API");
        #endregion

    }
}
