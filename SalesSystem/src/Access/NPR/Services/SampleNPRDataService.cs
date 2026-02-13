namespace NPR.Services
{
    public static class SampleNPRDataService
    {
        #region H1NPRView
        public static ListH1NPRViewGrpc PopulateH1NPRViewGrpc()
        {
            ListH1NPRViewGrpc listH1NPRViewGrpc = new ListH1NPRViewGrpc();
            for (int i = 0; i < 5; i++)
            {
                H1NPRViewGrpc h1NPRViewGrpc = new H1NPRViewGrpc();
                h1NPRViewGrpc.Id = Guid.NewGuid().ToString();
                h1NPRViewGrpc.SubsidiaryId = $"TestSubsidiaryId{i}";
                h1NPRViewGrpc.RefNo = $"TestRefNo{i}";
                h1NPRViewGrpc.Type = $"TestType{i}";
                h1NPRViewGrpc.RaiseDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                h1NPRViewGrpc.UserId = $"TestUserId{i}";
                h1NPRViewGrpc.Status = $"TestStatus{i}";
                h1NPRViewGrpc.SumitomoNo = $"TestSumitomoNo{i}";
                h1NPRViewGrpc.Description = $"TestDescription{i}";
                h1NPRViewGrpc.ProjectId = $"TestProjectId{i}";
                h1NPRViewGrpc.SuggestedSupplierId = $"TestSuggestedSupplierId{i}";
                h1NPRViewGrpc.ReplacedPart = $"TestReplacedPart{i}";
                h1NPRViewGrpc.CustomerId = $"TestCustomerId{i}";
                h1NPRViewGrpc.SupplierNo = $"TestSupplierNo{i}";
                h1NPRViewGrpc.AssemblyNo = $"TestAssemblyNo{i}";
                h1NPRViewGrpc.CustomerNo = $"TestCustomerNo{i}";
                h1NPRViewGrpc.UoM = $"UoM{i}";
                h1NPRViewGrpc.QtyPerVehicle = i;
                h1NPRViewGrpc.EngComments = $"TestEngComments{i}";
                h1NPRViewGrpc.RfqRequiredDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                h1NPRViewGrpc.OrderDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                h1NPRViewGrpc.OrderedBy = $"TestOrderedBy{i}";
                h1NPRViewGrpc.DelvPromiseDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                h1NPRViewGrpc.QuotationDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                h1NPRViewGrpc.OriginCountry = $"TestOriginCountry{i}";
                h1NPRViewGrpc.SpecialDelivery = $"TestSpecialDelivery{i}";
                h1NPRViewGrpc.PoNo = $"TestPoNo{i}";
                h1NPRViewGrpc.Price = i;
                h1NPRViewGrpc.Currency = $"TestCurrency{i}";
                h1NPRViewGrpc.StdLeadTime = i;
                h1NPRViewGrpc.TariffCode = $"TestTariffCode{i}";
                h1NPRViewGrpc.PurchaseUoM = $"TestPurchaseUoM{i}";
                h1NPRViewGrpc.PurchaseUoM = $"TestPurchaseUoM{i}";
                h1NPRViewGrpc.Moq = i;
                h1NPRViewGrpc.BagQty = i;
                h1NPRViewGrpc.PurchasingComments = $"TestPurchasingComments{i}";
                h1NPRViewGrpc.PurchasingComments = $"TestPurchasingComments{i}";
                h1NPRViewGrpc.ActualSupplierId = $"TestActualSupplierId{i}";
                h1NPRViewGrpc.MaterialType = $"TestMaterialType{i}";
                h1NPRViewGrpc.ConfacPo = i;
                h1NPRViewGrpc.OriginStatus = $"TestOriginStatus{i}";
                h1NPRViewGrpc.ExpiryDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                h1NPRViewGrpc.CopperWeight = i;
                h1NPRViewGrpc.SupportCentre = $"TestSupportCentre{i}";
                h1NPRViewGrpc.EnquiryRef = $"TestEnquiryRef{i}";
                h1NPRViewGrpc.EnquiryDate = $"TestEnquiryDate{i}";
                h1NPRViewGrpc.PpapReqLevel = $"TestPpapReqLevel{i}";
                h1NPRViewGrpc.ReqQualDoc = $"TestReqQualDoc{i}";
                h1NPRViewGrpc.AirFreightRef = $"TestAirFreightRef{i}";
                h1NPRViewGrpc.CopperRate = i;
                h1NPRViewGrpc.StdBoxLength = i;
                h1NPRViewGrpc.Height = i;
                h1NPRViewGrpc.PackFactor = i;
                h1NPRViewGrpc.PPAP = $"TestPPAP{i}";
                h1NPRViewGrpc.Status1 = $"TestStatus1{i}";
                h1NPRViewGrpc.Name = $"TestName{i}";
                h1NPRViewGrpc.FacilityNm = $"TestFacilityNm{i}";
                h1NPRViewGrpc.FullBoxWeight = $"TestFullBoxWeight{i}";
                h1NPRViewGrpc.OfferDate = $"TestOfferDate{i}";
                h1NPRViewGrpc.RaisedByCSLC = $"TestRaisedByCSLC{i}";
                h1NPRViewGrpc.UOMWeight = $"TestUOMWeight{i}";
                h1NPRViewGrpc.DevPart = $"TestDevPart{i}";
                h1NPRViewGrpc.EnggName = $"TestEnggName{i}";
                h1NPRViewGrpc.CreationDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                listH1NPRViewGrpc.H1NPRViewGrpc.Add(h1NPRViewGrpc);
            }

            H1NPRViewGrpc fixedH1NPRViewGrpc = new H1NPRViewGrpc();
            fixedH1NPRViewGrpc.Id = Guid.NewGuid().ToString();
            fixedH1NPRViewGrpc.SubsidiaryId = $"TestSubsidiaryId";
            fixedH1NPRViewGrpc.RefNo = $"TestRefNo";
            fixedH1NPRViewGrpc.Type = $"TestType";
            fixedH1NPRViewGrpc.RaiseDate = DateTime.Now.ToUniversalTime().ToTimestamp();
            fixedH1NPRViewGrpc.UserId = $"TestUserId";
            fixedH1NPRViewGrpc.Status = $"TestStatus";
            fixedH1NPRViewGrpc.SumitomoNo = $"TestSumitomoNo";
            fixedH1NPRViewGrpc.Description = $"TestDescription";
            fixedH1NPRViewGrpc.ProjectId = $"TestProjectId";
            fixedH1NPRViewGrpc.SuggestedSupplierId = $"TestSuggestedSupplierId";
            fixedH1NPRViewGrpc.ReplacedPart = $"TestReplacedPart";
            fixedH1NPRViewGrpc.CustomerId = $"TestCustomerId";
            fixedH1NPRViewGrpc.SupplierNo = $"TestSupplierNo";
            fixedH1NPRViewGrpc.AssemblyNo = $"TestAssemblyNo";
            fixedH1NPRViewGrpc.CustomerNo = $"TestCustomerNo";
            fixedH1NPRViewGrpc.UoM = $"UoM";
            fixedH1NPRViewGrpc.QtyPerVehicle = 0;
            fixedH1NPRViewGrpc.EngComments = $"TestEngComments";
            fixedH1NPRViewGrpc.RfqRequiredDate = DateTime.Now.ToUniversalTime().ToTimestamp();
            fixedH1NPRViewGrpc.OrderDate = DateTime.Now.ToUniversalTime().ToTimestamp();
            fixedH1NPRViewGrpc.OrderedBy = $"TestOrderedBy";
            fixedH1NPRViewGrpc.DelvPromiseDate = DateTime.Now.ToUniversalTime().ToTimestamp();
            fixedH1NPRViewGrpc.QuotationDate = DateTime.Now.ToUniversalTime().ToTimestamp();
            fixedH1NPRViewGrpc.OriginCountry = $"TestOriginCountry";
            fixedH1NPRViewGrpc.SpecialDelivery = $"TestSpecialDelivery";
            fixedH1NPRViewGrpc.PoNo = $"TestPoNo";
            fixedH1NPRViewGrpc.Price = 0;
            fixedH1NPRViewGrpc.Currency = $"TestCurrency";
            fixedH1NPRViewGrpc.StdLeadTime = 0;
            fixedH1NPRViewGrpc.TariffCode = $"TestTariffCode";
            fixedH1NPRViewGrpc.PurchaseUoM = $"TestPurchaseUoM";
            fixedH1NPRViewGrpc.PurchaseUoM = $"TestPurchaseUoM";
            fixedH1NPRViewGrpc.Moq = 0;
            fixedH1NPRViewGrpc.BagQty = 0;
            fixedH1NPRViewGrpc.PurchasingComments = $"TestPurchasingComments";
            fixedH1NPRViewGrpc.PurchasingComments = $"TestPurchasingComments";
            fixedH1NPRViewGrpc.ActualSupplierId = $"TestActualSupplierId";
            fixedH1NPRViewGrpc.MaterialType = $"TestMaterialType";
            fixedH1NPRViewGrpc.ConfacPo = 0;
            fixedH1NPRViewGrpc.OriginStatus = $"TestOriginStatus";
            fixedH1NPRViewGrpc.ExpiryDate = DateTime.Now.ToUniversalTime().ToTimestamp();
            fixedH1NPRViewGrpc.CopperWeight = 0;
            fixedH1NPRViewGrpc.SupportCentre = $"TestSupportCentre";
            fixedH1NPRViewGrpc.EnquiryRef = $"TestEnquiryRef";
            fixedH1NPRViewGrpc.EnquiryDate = $"TestEnquiryDate";
            fixedH1NPRViewGrpc.PpapReqLevel = $"TestPpapReqLevel";
            fixedH1NPRViewGrpc.ReqQualDoc = $"TestReqQualDoc";
            fixedH1NPRViewGrpc.AirFreightRef = $"TestAirFreightRef";
            fixedH1NPRViewGrpc.CopperRate = 0;
            fixedH1NPRViewGrpc.StdBoxLength = 0;
            fixedH1NPRViewGrpc.Height = 0;
            fixedH1NPRViewGrpc.PackFactor = 0;
            fixedH1NPRViewGrpc.PPAP = $"TestPPAP";
            fixedH1NPRViewGrpc.Status1 = $"TestStatus1";
            fixedH1NPRViewGrpc.Name = $"TestName";
            fixedH1NPRViewGrpc.FacilityNm = $"TestFacilityNm";
            fixedH1NPRViewGrpc.FullBoxWeight = $"TestFullBoxWeight";
            fixedH1NPRViewGrpc.OfferDate = $"TestOfferDate";
            fixedH1NPRViewGrpc.RaisedByCSLC = $"TestRaisedByCSLC";
            fixedH1NPRViewGrpc.UOMWeight = $"TestUOMWeight";
            fixedH1NPRViewGrpc.DevPart = $"TestDevPart";
            fixedH1NPRViewGrpc.EnggName = $"TestEnggName";
            fixedH1NPRViewGrpc.CreationDate = DateTime.Now.ToUniversalTime().ToTimestamp();
            listH1NPRViewGrpc.H1NPRViewGrpc.Add(fixedH1NPRViewGrpc);
            return listH1NPRViewGrpc;
        }
        #endregion

        #region RFQStatus
        public static ListRFQStatusGrpc PopulateRFQStatusGrpc()
        {
            ListRFQStatusGrpc listRFQStatusGrpc = new ListRFQStatusGrpc();
            for (int i = 0; i < 5; i++)
            {
                RFQStatusGrpc rfqStatus = new RFQStatusGrpc();
                rfqStatus.RFQStatusDescription = $"TestDescription{i}";
                rfqStatus.NPRStage = $"TestStage{i}";
                listRFQStatusGrpc.RFQStatusGrpc.Add(rfqStatus);
            }

            RFQStatusGrpc fixedRFQStatus = new RFQStatusGrpc();
            fixedRFQStatus.RFQStatusDescription = "TestFixedDescription";
            fixedRFQStatus.NPRStage = "TestFixedStage";
            listRFQStatusGrpc.RFQStatusGrpc.Add(fixedRFQStatus);
            return listRFQStatusGrpc;
        }
        #endregion
    }
}
