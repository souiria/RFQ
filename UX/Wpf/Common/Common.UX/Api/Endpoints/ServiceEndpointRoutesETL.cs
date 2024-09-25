namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {
        #region Helpdesk
        public static readonly ServiceEndpointRoutes HelpdeskCalls = new ServiceEndpointRoutes("HelpdeskCalls");
        public static readonly ServiceEndpointRoutes HelpdeskApprovals = new ServiceEndpointRoutes("HelpdeskApprovals");
        #endregion

        #region Emacs
        #region EmacsImport
        //public static readonly ServiceEndpointRoutes EmacsImportPartSearch = new ServiceEndpointRoutes("EmacsImport/PartSearch");
        public static readonly ServiceEndpointRoutes EmacsImportCustomer = new ServiceEndpointRoutes("EmacsImport/Customer");
        public static readonly ServiceEndpointRoutes EmacsImportCustomerData = new ServiceEndpointRoutes("EmacsImport/CustomerData");
        public static readonly ServiceEndpointRoutes EmacsImportNpaCustomer = new ServiceEndpointRoutes("EmacsImport/NpaCustomer");
        public static readonly ServiceEndpointRoutes EmacsImportNpaSupplier = new ServiceEndpointRoutes("EmacsImport/NpaSupplier");
        public static readonly ServiceEndpointRoutes EmacsImportPart = new ServiceEndpointRoutes("EmacsImport/Part");
        public static readonly ServiceEndpointRoutes EmacsImportSupplier = new ServiceEndpointRoutes("EmacsImport/Supplier");
        #endregion
        #region EmacsCustomer
        public static readonly ServiceEndpointRoutes EmacsCustomer = new ServiceEndpointRoutes("EmacsCustomer");
        #endregion
        #endregion

        #region Npa
        public static readonly ServiceEndpointRoutes NpaUpload = new ServiceEndpointRoutes("NpaUpload");
        public static readonly ServiceEndpointRoutes NpaSuppliersList = new ServiceEndpointRoutes("NpaUpload/SuppliersList");
        public static readonly ServiceEndpointRoutes NpaUomList = new ServiceEndpointRoutes("NpaUpload/UomList");
        public static readonly ServiceEndpointRoutes NpaVerification = new ServiceEndpointRoutes("NpaVerification");
        public static readonly ServiceEndpointRoutes NPAStatus = new ServiceEndpointRoutes("NPAStatus");

        #endregion
    }
}
