namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {
        #region Master
        public static readonly ServiceEndpointRoutes Subsidiary = new ServiceEndpointRoutes("Subsidiary");
        public static readonly ServiceEndpointRoutes NPAStatusCode = new ServiceEndpointRoutes("NPAStatusCode");
        public static readonly ServiceEndpointRoutes NPAType = new ServiceEndpointRoutes("NPAType");
        public static readonly ServiceEndpointRoutes ProductionPartApprovalProcessLevel = new ServiceEndpointRoutes("ProductionPartApprovalProcessLevel");
        #endregion

        #region Engineering
        public static readonly ServiceEndpointRoutes RaiseSampleNPA = new ServiceEndpointRoutes("RaiseSampleNPA");
        public static readonly ServiceEndpointRoutes SearchNPA = new ServiceEndpointRoutes("SearchNPA");
        public static readonly ServiceEndpointRoutes GetGridDataSearchNPA = new ServiceEndpointRoutes("SearchNPA/GetGridDataSearchNPA");
        public static readonly ServiceEndpointRoutes NPAProjectDetails = new ServiceEndpointRoutes("NPAProjectDetails");
        public static readonly ServiceEndpointRoutes NewPartsAuthorization = new ServiceEndpointRoutes("NewPartsAuthorization");
        public static readonly ServiceEndpointRoutes MassNPAUpload = new ServiceEndpointRoutes("MassNPAUpload");
        public static readonly ServiceEndpointRoutes ArchiveNewPartsAuthorization = new ServiceEndpointRoutes("ArchiveNewPartsAuthorization");
        public static readonly ServiceEndpointRoutes SearchDHSForParts = new ServiceEndpointRoutes("SearchDHSForParts");
        public static readonly ServiceEndpointRoutes GetGridDataSearchDHSForParts = new ServiceEndpointRoutes("SearchDHSForParts/GetGridDataSearchDHSForParts");
        public static readonly ServiceEndpointRoutes GetGridDataSearchDHSForPartsShowInventory = new ServiceEndpointRoutes("SearchDHSForParts/GetGridDataSearchDHSForPartsShowInventory");
        #endregion

        #region RFQ
        #endregion
    }
}
