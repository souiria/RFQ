using System;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Primitives;
using NPR;
using NPR.Data.Model;

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

        #region NPR Request Sets (DTO <-> gRPC)


        public static RfqNprRequestSetGrpc MapToGrpc(this RfqNprRequestSetModel s)
        {
            RfqNprRequestSetGrpc g = new RfqNprRequestSetGrpc();

            // Id
            g.Id = s.Id.ToString();

            // RfqNumber (string)
            if (!string.IsNullOrWhiteSpace(s.RfqNumber))
            {
                g.RfqNumber = s.RfqNumber;
            }
            else
            {
                g.RfqNumber = string.Empty;
            }

            // Created (Timestamp)
            DateTime created = s.Created;
            DateTime createdUtc = created.Kind == DateTimeKind.Utc ? created : created.ToUniversalTime();
            Timestamp createdTs = Timestamp.FromDateTime(createdUtc);
            g.Created = createdTs;

            // Status (enum)
            if (s.Status == NprSetRequestStatus.LocalUnchanged)
            {
                g.Status = NprSetRequestStatusGrpc.LocalUnchanged;
            }
            else if (s.Status == NprSetRequestStatus.LocalUpdated)
            {
                g.Status = NprSetRequestStatusGrpc.LocalUpdated;
            }
            else
            {
                g.Status = NprSetRequestStatusGrpc.NprSetStatusUnspecified;
            }

            // Updated (Timestamp)
            DateTime updated;
            bool updatedIsDefault = s.Updated == default;
            if (updatedIsDefault)
            {
                updated = DateTime.UtcNow;
            }
            else
            {
                updated = s.Updated;
            }

            DateTime updatedUtc = updated.Kind == DateTimeKind.Utc ? updated : updated.ToUniversalTime();
            Timestamp updatedTs = Timestamp.FromDateTime(updatedUtc);
            g.Updated = updatedTs;

            // Closed (Timestamp?)
            if (s.Closed.HasValue)
            {
                DateTime closed = s.Closed.Value;
                DateTime closedUtc = closed.Kind == DateTimeKind.Utc ? closed : closed.ToUniversalTime();
                Timestamp closedTs = Timestamp.FromDateTime(closedUtc);
                g.Closed = closedTs;
            }
            else
            {
                g.Closed = null;
            }

            // ProjectId (string)
            if (s.ProjectId != Guid.Empty)
            {
                g.ProjectId = s.ProjectId.ToString();
            }
            else
            {
                g.ProjectId = string.Empty;
            }

            // Project (nested)
            if (s.Project != null)
            {
                RfqProjectInfoGrpc pg = s.Project.MapToGrpc();
                g.Project = pg;
            }

            // Requests
            if (s.NprRequests != null && 0 < s.NprRequests.Count)
            {
                foreach (RfqNprRequestModel r in s.NprRequests)
                {
                    RfqNprRequestGrpc mapped = r.MapToGrpc();
                    g.NprRequests.Add(mapped);
                }
            }

            return g;
        }

 
        public static RfqNprRequestGrpc MapToGrpc(this RfqNprRequestModel r)
        {
            RfqNprRequestGrpc g = new RfqNprRequestGrpc();

            // Id
            g.Id = r.Id.ToString();

            g.Reason = !string.IsNullOrWhiteSpace(r.Reason) ? r.Reason : string.Empty;
            g.Customer = !string.IsNullOrWhiteSpace(r.Customer) ? r.Customer : string.Empty;
            g.PlatformName = !string.IsNullOrWhiteSpace(r.PlatformName) ? r.PlatformName : string.Empty;
            g.ProgramName = !string.IsNullOrWhiteSpace(r.ProgramName) ? r.ProgramName : string.Empty;
            g.Project = !string.IsNullOrWhiteSpace(r.Project) ? r.Project : string.Empty;

            g.MaterialType = !string.IsNullOrWhiteSpace(r.MaterialType) ? r.MaterialType : string.Empty;
            g.SuggestedSewsEManufacturingSite = !string.IsNullOrWhiteSpace(r.SuggestedSewsEManufacturingSite) ? r.SuggestedSewsEManufacturingSite : string.Empty;

            g.CustomerPartNumber = !string.IsNullOrWhiteSpace(r.CustomerPartNumber) ? r.CustomerPartNumber : string.Empty;
            g.SupplierPartNumber = !string.IsNullOrWhiteSpace(r.SupplierPartNumber) ? r.SupplierPartNumber : string.Empty;
            g.SumitomoNumber = !string.IsNullOrWhiteSpace(r.SumitomoNumber) ? r.SumitomoNumber : string.Empty;

            g.MaterialDescription = !string.IsNullOrWhiteSpace(r.MaterialDescription) ? r.MaterialDescription : string.Empty;
            g.UnitOfMeasure = !string.IsNullOrWhiteSpace(r.UnitOfMeasure) ? r.UnitOfMeasure : string.Empty;
            g.SupplierGroup = !string.IsNullOrWhiteSpace(r.SupplierGroup) ? r.SupplierGroup : string.Empty;

            g.RaisedRemarks = !string.IsNullOrWhiteSpace(r.RaisedRemarks) ? r.RaisedRemarks : string.Empty;

            g.SampleSite = !string.IsNullOrWhiteSpace(r.SampleSite) ? r.SampleSite : string.Empty;
            g.SampleRecipient = !string.IsNullOrWhiteSpace(r.SampleRecipient) ? r.SampleRecipient : string.Empty;

            g.FreightAccount = !string.IsNullOrWhiteSpace(r.FreightAccount) ? r.FreightAccount : string.Empty;
            g.AssociatedParts = !string.IsNullOrWhiteSpace(r.AssociatedParts) ? r.AssociatedParts : string.Empty;
            g.SuggestedManufacturer = !string.IsNullOrWhiteSpace(r.SuggestedManufacturer) ? r.SuggestedManufacturer : string.Empty;

            // Integers
            g.QtyPerVehicle = r.QtyPerVehicle;
            g.Quantity = r.Quantity;
            g.SampleQuantity = r.SampleQuantity;

            // Booleans
            g.IsCustomerNominatedSupplier = r.IsCustomerNominatedSupplier;
            g.IsCustomerNominatedMaterial = r.IsCustomerNominatedMaterial;
            g.SamplesRequired = r.SamplesRequired;

            // RequiredDate
            DateTime req = r.RequiredDate;
            DateTime reqUtc = req.Kind == DateTimeKind.Utc ? req : req.ToUniversalTime();
            Timestamp reqTs = Timestamp.FromDateTime(reqUtc);
            g.RequiredDate = reqTs;

            // SampleRequiredDate
            if (r.SampleRequiredDate.HasValue)
            {
                DateTime sdt = r.SampleRequiredDate.Value;
                DateTime sdtUtc = sdt.Kind == DateTimeKind.Utc ? sdt : sdt.ToUniversalTime();
                Timestamp sdtTs = Timestamp.FromDateTime(sdtUtc);
                g.SampleRequiredDate = sdtTs;
            }
            else
            {
                g.SampleRequiredDate = null;
            }

            return g;
        }


        public static RfqProjectInfoGrpc MapToGrpc(this RfqProjectInfo p)
        {
            RfqProjectInfoGrpc g = new RfqProjectInfoGrpc();

            g.RowId = (int)p.RowId;

            g.RfqNumber = !string.IsNullOrWhiteSpace(p.RfqNumber) ? p.RfqNumber : string.Empty;
            g.CustomerBusinessUnitId = !string.IsNullOrWhiteSpace(p.CustomerBusinessUnitId) ? p.CustomerBusinessUnitId : string.Empty;
            g.CustomerLocationId = !string.IsNullOrWhiteSpace(p.CustomerLocationId) ? p.CustomerLocationId : string.Empty;
            g.ProjectId = !string.IsNullOrWhiteSpace(p.ProjectId) ? p.ProjectId : string.Empty;

            g.RfqReasonId = p.RfqReasonId;

            if (p.RfqResponseDeadline.HasValue)
            {
                DateTime dt = p.RfqResponseDeadline.Value;
                DateTime dtUtc = dt.Kind == DateTimeKind.Utc ? dt : dt.ToUniversalTime();
                Timestamp ts = Timestamp.FromDateTime(dtUtc);
                g.RfqResponseDeadline = ts;
            }
            else
            {
                g.RfqResponseDeadline = null;
            }

            g.CarModelId = !string.IsNullOrWhiteSpace(p.CarModelId) ? p.CarModelId : string.Empty;

            g.VehicleVolume = p.VehicleVolume;
            g.IsActive = p.IsActive;

            return g;
        }

        public static RfqNprRequestSetModel MapToModel(this RfqNprRequestSetGrpc g)
        {
            RfqNprRequestSetModel s = new RfqNprRequestSetModel();

            // Id
            Guid id;
            bool idParsed = Guid.TryParse(g.Id, out id);
            if (idParsed)
            {
                s.Id = id;
            }

            // RfqNumber (string)
            if (!string.IsNullOrWhiteSpace(g.RfqNumber))
            {
                s.RfqNumber = g.RfqNumber;
            }
            else
            {
                s.RfqNumber = string.Empty;
            }

            // Created
            if (g.Created != null)
            {
                DateTime created = g.Created.ToDateTime();
                DateTime createdUtc = created.Kind == DateTimeKind.Utc ? created : created.ToUniversalTime();
                s.Created = createdUtc;
            }

            // Status
            if (g.Status == NprSetRequestStatusGrpc.LocalUnchanged)
            {
                s.Status = NprSetRequestStatus.LocalUnchanged;
            }
            else if (g.Status == NprSetRequestStatusGrpc.LocalUpdated)
            {
                s.Status = NprSetRequestStatus.LocalUpdated;
            }
            else
            {
                s.Status = NprSetRequestStatus.LocalUpdated;
            }

            // Updated
            if (g.Updated != null)
            {
                DateTime updated = g.Updated.ToDateTime();
                DateTime updatedUtc = updated.Kind == DateTimeKind.Utc ? updated : updated.ToUniversalTime();
                s.Updated = updatedUtc;
            }

            // Closed
            if (g.Closed != null)
            {
                DateTime closed = g.Closed.ToDateTime();
                DateTime closedUtc = closed.Kind == DateTimeKind.Utc ? closed : closed.ToUniversalTime();
                s.Closed = closedUtc;
            }
            else
            {
                s.Closed = null;
            }

            // ProjectId (string -> Guid)
            if (!string.IsNullOrWhiteSpace(g.ProjectId))
            {
                Guid pid;
                bool pidParsed = Guid.TryParse(g.ProjectId, out pid);
                if (pidParsed)
                {
                    s.ProjectId = pid;
                }
            }

            // Project
            if (g.Project != null)
            {
                RfqProjectInfo p = g.Project.MapToModel();
                s.Project = p;
            }

            // Requests
            if (g.NprRequests != null && 0 < g.NprRequests.Count)
            {
                foreach (RfqNprRequestGrpc r in g.NprRequests)
                {
                    RfqNprRequestModel rm = r.MapToModel();
                    s.NprRequests.Add(rm);
                }
            }

            return s;
        }


        public static RfqNprRequestModel MapToModel(this RfqNprRequestGrpc g)
        {
            RfqNprRequestModel r = new RfqNprRequestModel();

            // Id
            Guid id;
            bool idParsed = Guid.TryParse(g.Id, out id);
            if (idParsed)
            {
                r.Id = id;
            }

            // Strings (direct)
            if (!string.IsNullOrWhiteSpace(g.Reason))
            {
                r.Reason = g.Reason;
            }

            if (!string.IsNullOrWhiteSpace(g.Customer))
            {
                r.Customer = g.Customer;
            }

            if (!string.IsNullOrWhiteSpace(g.PlatformName))
            {
                r.PlatformName = g.PlatformName;
            }

            if (!string.IsNullOrWhiteSpace(g.ProgramName))
            {
                r.ProgramName = g.ProgramName;
            }

            if (!string.IsNullOrWhiteSpace(g.Project))
            {
                r.Project = g.Project;
            }

            if (!string.IsNullOrWhiteSpace(g.MaterialType))
            {
                r.MaterialType = g.MaterialType;
            }

            if (!string.IsNullOrWhiteSpace(g.SuggestedSewsEManufacturingSite))
            {
                r.SuggestedSewsEManufacturingSite = g.SuggestedSewsEManufacturingSite;
            }

            if (!string.IsNullOrWhiteSpace(g.CustomerPartNumber))
            {
                r.CustomerPartNumber = g.CustomerPartNumber;
            }

            if (!string.IsNullOrWhiteSpace(g.SupplierPartNumber))
            {
                r.SupplierPartNumber = g.SupplierPartNumber;
            }

            if (!string.IsNullOrWhiteSpace(g.SumitomoNumber))
            {
                r.SumitomoNumber = g.SumitomoNumber;
            }

            if (!string.IsNullOrWhiteSpace(g.MaterialDescription))
            {
                r.MaterialDescription = g.MaterialDescription;
            }

            if (!string.IsNullOrWhiteSpace(g.UnitOfMeasure))
            {
                r.UnitOfMeasure = g.UnitOfMeasure;
            }

            if (!string.IsNullOrWhiteSpace(g.SupplierGroup))
            {
                r.SupplierGroup = g.SupplierGroup;
            }

            if (!string.IsNullOrWhiteSpace(g.RaisedRemarks))
            {
                r.RaisedRemarks = g.RaisedRemarks;
            }

            if (!string.IsNullOrWhiteSpace(g.SampleSite))
            {
                r.SampleSite = g.SampleSite;
            }

            if (!string.IsNullOrWhiteSpace(g.SampleRecipient))
            {
                r.SampleRecipient = g.SampleRecipient;
            }

            if (!string.IsNullOrWhiteSpace(g.FreightAccount))
            {
                r.FreightAccount = g.FreightAccount;
            }

            if (!string.IsNullOrWhiteSpace(g.AssociatedParts))
            {
                r.AssociatedParts = g.AssociatedParts;
            }

            if (!string.IsNullOrWhiteSpace(g.SuggestedManufacturer))
            {
                r.SuggestedManufacturer = g.SuggestedManufacturer;
            }

            int qtyPerVehicle;
            if (g.QtyPerVehicle.HasValue)
            {
                qtyPerVehicle = g.QtyPerVehicle.Value;
            }
            else
            {
                qtyPerVehicle = 0;
            }

            r.QtyPerVehicle = qtyPerVehicle;

            int quantity;
            if (g.Quantity.HasValue)
            {
                quantity = g.Quantity.Value;
            }
            else
            {
                quantity = 0;
            }

            r.Quantity = quantity;

            int sampleQuantity;
            if (g.SampleQuantity.HasValue)
            {
                sampleQuantity = g.SampleQuantity.Value;
            }
            else
            {
                sampleQuantity = 0;
            }

            r.SampleQuantity = sampleQuantity;

            // Booleans (direct)
            r.IsCustomerNominatedSupplier = g.IsCustomerNominatedSupplier;
            r.IsCustomerNominatedMaterial = g.IsCustomerNominatedMaterial;
            r.SamplesRequired = g.SamplesRequired;

            // RequiredDate
            if (g.RequiredDate != null)
            {
                DateTime req = g.RequiredDate.ToDateTime();
                DateTime reqUtc = req.Kind == DateTimeKind.Utc ? req : req.ToUniversalTime();
                r.RequiredDate = reqUtc;
            }

            // SampleRequiredDate
            if (g.SampleRequiredDate != null)
            {
                DateTime sdt = g.SampleRequiredDate.ToDateTime();
                DateTime sdtUtc = sdt.Kind == DateTimeKind.Utc ? sdt : sdt.ToUniversalTime();
                r.SampleRequiredDate = sdtUtc;
            }
            else
            {
                r.SampleRequiredDate = null;
            }

            return r;
        }
        public static RfqProjectInfo MapToModel(this RfqProjectInfoGrpc g)
        {
            RfqProjectInfo p = new RfqProjectInfo();

            p.RowId = g.RowId;
            p.RfqReasonId = g.RfqReasonId;
            p.VehicleVolume = g.VehicleVolume;
            p.IsActive = g.IsActive;

            if (!string.IsNullOrWhiteSpace(g.RfqNumber))
            {
                p.RfqNumber = g.RfqNumber;
            }

            if (!string.IsNullOrWhiteSpace(g.CustomerBusinessUnitId))
            {
                p.CustomerBusinessUnitId = g.CustomerBusinessUnitId;
            }

            if (!string.IsNullOrWhiteSpace(g.CustomerLocationId))
            {
                p.CustomerLocationId = g.CustomerLocationId;
            }

            if (!string.IsNullOrWhiteSpace(g.ProjectId))
            {
                p.ProjectId = g.ProjectId;
            }

            if (!string.IsNullOrWhiteSpace(g.CarModelId))
            {
                p.CarModelId = g.CarModelId;
            }

            if (g.RfqResponseDeadline != null)
            {
                DateTime dt = g.RfqResponseDeadline.ToDateTime();
                DateTime dtUtc = dt.Kind == DateTimeKind.Utc ? dt : dt.ToUniversalTime();
                p.RfqResponseDeadline = dtUtc;
            }
            else
            {
                p.RfqResponseDeadline = null;
            }

            return p;
        }

        #endregion
   
    }
}