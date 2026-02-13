namespace NPR.Extentions
{
    public static class NPRMappingExtentions
    {
        #region H1NPRView

        public static H1NPRViewGrpc MapToH1NPRViewGrpc(this DbH1NPRView entity)
        {
            H1NPRViewGrpc data = new H1NPRViewGrpc();
            data.Id = entity.Id.ToString();
            data.SubsidiaryId = entity.Subsidiary_Id;
            data.RefNo = entity.Ref_No;
            data.Type = entity.Type;
            data.RaiseDate = entity.Raise_Date?.ToUniversalTime().ToTimestamp();
            data.UserId = entity.User_Id;
            data.Status = entity.Status;
            data.SumitomoNo = entity.Sumitomo_No;
            data.Description = entity.Description;
            data.ProjectId = entity.Project_Id;
            data.SuggestedSupplierId = entity.Suggested_Supplier_Id;
            data.ReplacedPart = entity.Replaced_Part;
            data.CustomerId = entity.Customer_Id;
            data.SupplierNo = entity.Supplier_No;
            data.AssemblyNo = entity.Assembly_No;
            data.CustomerNo = entity.Customer_No;
            data.UoM = entity.UoM;
            data.QtyPerVehicle = (double?)entity.Qty_Per_Vehicle;
            data.EngComments = entity.Eng_Comments;
            data.RfqRequiredDate = entity.Rfq_Required_Date?.ToUniversalTime().ToTimestamp();
            data.OrderDate = entity.Order_Date?.ToUniversalTime().ToTimestamp();
            data.OrderedBy = entity.Ordered_By;
            data.DelvPromiseDate = entity.Delv_Promise_Date?.ToUniversalTime().ToTimestamp();
            data.QuotationDate = entity.Quotation_Date?.ToUniversalTime().ToTimestamp();
            data.OriginCountry = entity.Origin_Country;
            data.SpecialDelivery = entity.Special_Delivery;
            data.PoNo = entity.Po_No;
            data.Price = (double?)entity.Price;
            data.Currency = entity.Currency;
            data.StdLeadTime = entity.Std_Lead_Time;
            data.TariffCode = entity.Tariff_Code;
            data.PurchaseUoM = entity.Purchase_UoM;
            data.Moq = entity.Moq;
            data.BagQty = entity.Bag_Qty;
            data.PurchasingComments = entity.Purchasing_Comments;
            data.ActualSupplierId = entity.Actual_Supplier_Id;
            data.MaterialType = entity.Material_Type;
            data.ConfacPo = entity.Confac_Po;
            data.OriginStatus = entity.Origin_Status;
            data.ExpiryDate = entity.Expiry_Date?.ToUniversalTime().ToTimestamp();
            data.CopperWeight = (double?)entity.Copper_Weight;
            data.SupportCentre = entity.Support_Centre;
            data.EnquiryRef = entity.Enquiry_Ref;
            data.EnquiryDate = entity.Enquiry_Date;
            data.PpapReqLevel = entity.Ppap_Req_Level;
            data.ReqQualDoc = entity.Req_Qual_Doc;
            data.AirFreightRef = entity.Air_Freight_Ref;
            data.CopperRate = (double?)entity.Copper_Rate;
            data.StdBoxLength = (double?)entity.Std_Box_Length;
            data.Height = (double?)entity.Height;
            data.Width = (double?)entity.Width;
            data.PackFactor = entity.Pack_Factor;
            data.PPAP = entity.PPAP;
            data.Status1 = entity.Status1;
            data.Name = entity.Name;
            data.FacilityNm = entity.Facility_Nm;
            data.FullBoxWeight = entity.Facility_Nm;
            data.OfferDate = entity.Offer_Date;
            data.RaisedByCSLC = entity.Raised_By_CSLC;
            data.UOMWeight = entity.UOMWeight;
            data.DevPart = entity.Dev_Part;
            data.EnggName = entity.Engg_Name;
            data.CreationDate = entity.CreationDate?.ToUniversalTime().ToTimestamp();
            return data;
        }

        public static RFQStatusGrpc MapToRFQStatus(this DbRFQStatus entity)
        {
            RFQStatusGrpc data = new RFQStatusGrpc();
            data.RFQStatusDescription = entity.RFQStatusDescription;
            data.NPRStage = entity.NPRStage;
            return data;
        }

        #endregion
    }
}
