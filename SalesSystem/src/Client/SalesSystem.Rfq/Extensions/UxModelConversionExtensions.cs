namespace SalesSystem.Rfq.Extensions
{
    public static class UxModelConversionExtensions

    {
        #region RqfCustomerProjectAssociationUxModel Conversion
        public static RqfCustomerProjectAssociationUxModel? ToUx(this ProjectAssociation association)
        {
            if (association == null)
            {
                return null;
            }

            RqfCustomerProjectAssociationUxModel projectAssociation = new RqfCustomerProjectAssociationUxModel();
            projectAssociation.ProjectId = association.CustomerProjectGuid.ToUpperInvariant();
            projectAssociation.ProjectName = association.CustomerProjectName;
            projectAssociation.CustomerId = association.CustomerLocationGuid.ToUpperInvariant();
            projectAssociation.CustomerName = association.CustomerLocationName;
            projectAssociation.CustomerCode = association.CustomerCode;
            projectAssociation.ProjectCode = association.CustomerProjectCode;
            projectAssociation.Id = association.Id.ToUpperInvariant();
            return projectAssociation;
        }
        #endregion

        #region RqfProjectUxModel Conversion
        public static RqfProjectUxModel? ToUx(this RfqProject? rfqProject)
        {
            if (rfqProject == null)
            {
                return null;
            }

            RqfProjectUxModel uxModel = new RqfProjectUxModel();
            uxModel.RowId = rfqProject.RowId;
            uxModel.RfqNumber = rfqProject.RfqNumber;
            uxModel.CustomerBusinessUnitId = rfqProject.CustomerBusinessUnitGuid.Trim().ToUpperInvariant();
            uxModel.CustomerLocationId = rfqProject.CustomerLocationGuid.Trim().ToUpperInvariant();
            uxModel.ProjectId = rfqProject.ProjectGuid.Trim().ToUpperInvariant();
            uxModel.RfqReasonId = rfqProject.RfqReasonId;
            uxModel.RfqResponseDeadline = rfqProject.RfqResponseDeadline?.ToDateTime();
            uxModel.CarModelId = rfqProject.CarModelGuid.Trim().ToUpperInvariant();
            uxModel.VehicleVolume = rfqProject.VehicleVolume;
            uxModel.IsActive = rfqProject.IsActive ?? false;
            uxModel.JsonData = rfqProject.JsonData;

            return uxModel;
        }
        public static RfqProject ToDto(this RqfProjectUxModel uxModel)
        {
            if (uxModel == null)
            {
                throw new ArgumentNullException(nameof(uxModel));
            }

            RfqProject dto = new RfqProject();

            dto.RowId = uxModel.RowId;
            dto.RfqNumber = uxModel.RfqNumber;
            dto.CustomerBusinessUnitGuid = uxModel.CustomerBusinessUnitId.Trim().ToUpperInvariant();
            dto.CustomerLocationGuid = uxModel.CustomerLocationId.Trim().ToUpperInvariant();
            dto.ProjectGuid = uxModel.ProjectId.Trim().ToUpperInvariant();
            dto.RfqReasonId = uxModel.RfqReasonId;
            if (uxModel.RfqResponseDeadline.HasValue)
            {
                DateTime utc = uxModel.RfqResponseDeadline.Value.ToUniversalTime();
                dto.RfqResponseDeadline = Timestamp.FromDateTime(utc);
            }

            dto.CarModelGuid = uxModel.CarModelId.Trim().ToUpperInvariant();
            dto.VehicleVolume = uxModel.VehicleVolume;
            dto.IsActive = uxModel.IsActive;
            dto.JsonData = uxModel.JsonData;
            return dto;
        }
        #endregion

        #region CustomerUxModel Conversion
        public static CustomerUxModel? ToUx(this CustomerGrpc customerGrpc)
        {
            if (customerGrpc == null)
            {
                return null;
            }

            CustomerUxModel customerUx = new CustomerUxModel();
            customerUx.Id = customerGrpc.Id?.ToUpperInvariant();
            customerUx.CustomerBusinessGroupCode = customerGrpc.CustomerBusinessGroupCode;
            customerUx.CustomerBusinessGroupName = customerGrpc.CustomerBusinessGroupName;
            customerUx.SEWSEBusinessTeam = customerGrpc.SEWSEBusinessTeam;
            customerUx.IsActive = customerGrpc.IsActive ?? false;
            return customerUx;
        }
        #endregion

        #region RfqDrawingPartNumberUxModel Conversion
        public static RfqDrawingPartNumberUxModel? ToUx(this RfqDrawingPartNumber dto)
        {
            if (dto == null)
            {
                return null;
            }

            RfqDrawingPartNumberUxModel uxModel = new RfqDrawingPartNumberUxModel();

            uxModel.RowId = dto.RowId;
            uxModel.RfqId = dto.RfqId;
            if(!string.IsNullOrEmpty(dto.OriginalPartNumber) 
                && (string.IsNullOrEmpty(dto.SumitomoPartNumber) || dto.SumitomoPartNumber == "0000000"))
            {
                uxModel.CustomerPartNumber = dto.OriginalPartNumber;
                uxModel.DrawingPartNumber = string.Empty;
            }
            else
            {
                uxModel.CustomerPartNumber = dto.OriginalPartNumber;
                uxModel.DrawingPartNumber = dto.SumitomoPartNumber;
            }

            uxModel.DrawingPartNumberPrice = Convert.ToDecimal(dto.OriginalPartNumberPrice, CultureInfo.InvariantCulture);
            uxModel.SwappedPartNumber = dto.SwappedPartNumber;
            uxModel.SwappedPartNumberPrice = Convert.ToDecimal(dto.SwappedPartNumberPrice, CultureInfo.InvariantCulture);
            uxModel.PriceSource = dto.PriceSource;
            if (dto.IsSwapped)
            {
                uxModel.IsExactMatch = false;
                uxModel.IsSwapped = true;
            }
            else if (dto.IsExactMatch && !dto.IsSwapped)
            {
                uxModel.IsExactMatch = true;
                uxModel.IsSwapped = false;
            }
            else
            {
                uxModel.IsExactMatch = false;
                uxModel.IsSwapped = false;
            }

            uxModel.Comments = dto.Comments;
            uxModel.Quantity = Convert.ToDecimal(dto.Quantity, CultureInfo.InvariantCulture);

            return uxModel;
        }
        public static RfqDrawingPartNumber ToDto(this RfqDrawingPartNumberUxModel uxModel)
        {
            if (uxModel == null)
            {
                throw new ArgumentNullException(nameof(uxModel));
            }

            RfqDrawingPartNumber dto = new RfqDrawingPartNumber();

            dto.RowId = uxModel.RowId;
            dto.RfqId = uxModel.RfqId;
            dto.OriginalPartNumber = uxModel.CustomerPartNumber;
            dto.SumitomoPartNumber = uxModel.DrawingPartNumber;
            dto.OriginalPartNumberPrice = Convert.ToDouble(uxModel.DrawingPartNumberPrice, CultureInfo.InvariantCulture);
            dto.SwappedPartNumber = uxModel.SwappedPartNumber;
            dto.SwappedPartNumberPrice = Convert.ToDouble(uxModel.SwappedPartNumberPrice, CultureInfo.InvariantCulture);
            dto.PriceSource = uxModel.PriceSource;
            dto.IsExactMatch = uxModel.IsExactMatch == true;
            dto.IsSwapped = uxModel.IsSwapped == true;
            // dto.IsActive = uxModel.IsActive;
            if(!string.IsNullOrEmpty(uxModel.Comments) && uxModel.Comments.Contains("||<<<", StringComparison.OrdinalIgnoreCase))
            {
                dto.Comments = uxModel.Comments.Split("||<<<", StringSplitOptions.None)[0];
            }
            else
            {
                dto.Comments = uxModel.Comments;
            }
            dto.Quantity = Convert.ToDouble(uxModel.Quantity, CultureInfo.InvariantCulture);

            return dto;
        }
        public static RfqDrawingPartNumberUxModel ToUx(this DsiComponentUxModel component, long rfqId)
        {
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component), "DSI Component cannot be null.");
            }

            if (rfqId < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rfqId), "RFQ ID must be a non-negative value.");
            }

            RfqDrawingPartNumberUxModel rfqItem = new RfqDrawingPartNumberUxModel
            {
                // Maps the database primary key to row reference tracker
                RfqId = rfqId,

                // Map the primary active part number from the component data profile
                CustomerPartNumber = component.PartNumber1 ?? string.Empty,
                DrawingPartNumber = component.PartNumber1 ?? string.Empty,

                // Convert double? quantity to decimal safely, defaulting to 0 if null
                DrawingPartNumberPrice = 0m,
                SwappedPartNumber = string.Empty,
                SwappedPartNumberPrice = 0m,
                PriceSource = string.Empty,
                Comments = string.Empty,

                IsExactMatch = false,
                IsSwapped = false,
                MultiMatch = false,
                Status = RfqDrawingPartNumberStatus.New,
                // and of course, the quantity is missing
                Quantity = component.Quantity.HasValue ? Convert.ToDecimal(component.Quantity.Value, CultureInfo.InvariantCulture) : 0m
            };

            return rfqItem;
        }
        #endregion

        #region SearchResultUxModel
        public static SearchResultUxModel ToUx(this FilterGrpcResponse searchResult)
        {
            if (searchResult == null)
            {
                throw new ArgumentNullException(nameof(searchResult));
            }

            SearchResultUxModel resultUx = new SearchResultUxModel();
            resultUx.StringList.Clear();
            foreach (string? item in searchResult.StringList)
            {
                resultUx.StringList.Add(item);
            }

            resultUx.IntList.Clear();
            foreach (int? item in searchResult.IntList)
            {
                if (item.HasValue)
                {
                    resultUx.IntList.Add(item.Value);
                }
            }

            resultUx.ByteList.Clear();
            foreach (ByteString item in searchResult.ByteList)
            {
                byte[] arr = item.ToByteArray();
                resultUx.ByteList.Add(arr);
            }

            resultUx.DoubleList.Clear();
            foreach (double? item in searchResult.DoubleList)
            {
                if (item.HasValue)
                {
                    resultUx.DoubleList.Add(item.Value);
                }
            }

            resultUx.StringList2.Clear();
            foreach (string? item in searchResult.StringList2)
            {
                resultUx.StringList2.Add(item);
            }

            return resultUx;
        }
        #endregion

        #region AlternativePartUx Conversion
        public static AlternativePartUxModel ToUx(this RfqAlternativePartsGrpc dto)
        {
            AlternativePartUxModel ux = new AlternativePartUxModel();

            ux.SumitomoNumber = dto.SumitomoNumber;
            ux.SumitomoDescription = dto.SumitomoDescription;
            ux.MainSupplier = dto.MainSupplier;
            ux.SupplierName = dto.SupplierName;
            ux.SupplierNumber = dto.SupplierNumber;
            ux.Price = dto.Price;
            ux.CurrencyCode = dto.CurrencyCode;
            ux.UnitOfMeasure = dto.UnitOfMeasure;
            ux.PartGroup = dto.PartGroup;
            ux.GroupDescription = dto.GroupDescription;
            ux.Class1 = dto.Class1;
            ux.Class1Name = dto.Class1Name;
            ux.Class2 = dto.Class2;
            ux.Class2Name = dto.Class2Name;
            ux.ColourCode = dto.ColourCode;
            ux.ColorName = dto.ColorName;
            ux.MaterialGroup = dto.MaterialGroup;
            ux.Expr1 = dto.Expr1;
            ux.MaterialType = dto.MaterialType;
            ux.TypeDescription = dto.TypeDescription;
            ux.CategoryCode = dto.CategoryCode;
            ux.DetailedCategoryCode = dto.DetailedCategoryCode;
            ux.CategoryName = dto.CategoryName;
            ux.PartGroupCode = dto.PartGroupCode;
            ux.Description = dto.Description;
            ux.OldPartClass = dto.OldPartClass;
            ux.OldMaterial = dto.OldMaterial;
            ux.ClassDetailGroupCode = dto.ClassDetailGroupCode;
            ux.ClassDetailId = dto.ClassDetailId;
            ux.MaterialGroupId = dto.MaterialGroupId;
            ux.MaterialTypeId = dto.MaterialTypeId;
            ux.ColorCode = dto.ColorCode;
            ux.NumberOfCavity = dto.NumberOfCavity;
            ux.InsideDiameter = dto.InsideDiameter;
            ux.WallThickness = dto.WallThickness;
            ux.Length = dto.Length;
            ux.WidthOrOutsideDiameter = dto.WidthOrOutsideDiameter;
            ux.HoleDiameter = dto.HoleDiameter;
            ux.ShrinkRateLength = dto.ShrinkRateLength;
            ux.NumberOfTapingSpots = dto.NumberOfTapingSpots;
            ux.MassOrWeight = dto.MassOrWeight;
            ux.Quantity = dto.Quantity;
            ux.UoM = dto.UoM;
            ux.Group1 = dto.Group1;
            ux.Group2 = dto.Group2;
            ux.Group3 = dto.Group3;
            ux.Group4 = dto.Group4;
            ux.Group5 = dto.Group5;
            ux.Group6 = dto.Group6;
            ux.Group7 = dto.Group7;
            ux.Group8 = dto.Group8;
            ux.CustomerId = dto.CustomerId;
            ux.CustomerCode = dto.CustomerCode;
            ux.MassOrWeight2 = dto.MassOrWeight2;
            ux.L1 = dto.L1;
            ux.L2 = dto.L2;
            ux.L3 = dto.L3;
            ux.PitchWidth = dto.PitchWidth;
            ux.Tilt = dto.Tilt;
            ux.Grease = dto.Grease;
            ux.CategoryCode2 = dto.CategoryCode2;

            // UX-only properties can be set here if needed, e.g.:
            ux.HasImage = false; // or some logic to determine if image exists

            return ux;
        }
        #endregion

        #region NprRequests
        // convert a drawing number in a given rfq project into a npr request
        public static RfqNprRequestUxModel ToNprRequest(this RfqDrawingPartNumberUxModel partNumber, RqfProjectUxModel rfqProject)
        {
            RfqNprRequestUxModel nprRequest = new RfqNprRequestUxModel();
            nprRequest.DeadlineDate = rfqProject.RfqResponseDeadline;
            nprRequest.IsCustomerNominatedMaterial = false;
            nprRequest.IsCustomerNominatedSupplier = false;
            nprRequest.QtyPerVehicle = 1;
            //nprRequest.VehicleTotalQuantity = 1;
            nprRequest.AssociatedParts = "";
            nprRequest.CustomerCode = rfqProject.CustomerCode;
            nprRequest.CustomerPartNumber = partNumber.CustomerPartNumber;
            nprRequest.MaterialDescription = "";
            nprRequest.MaterialNumber = "";
            //nprRequest.PlatformName = "";
            //nprRequest.ProgramName = "";
            nprRequest.ProjectCode = rfqProject.ProjectCode;
            nprRequest.NPRRaisedRemarks = "";
            nprRequest.ReasonDescription = rfqProject.RfqReason;
            nprRequest.SuggestedManufacturerGroup = "";
            nprRequest.ManufacturingSite = rfqProject.CustomerLocation;
            nprRequest.SupplierGroup = "";
            nprRequest.SupplierDetailComments = "";
            nprRequest.SupplierPartNumber = "";
            nprRequest.BOMUnitOfMeasurement = "";
            nprRequest.CustomerRfqNo = "";
            nprRequest.OriginatorName = "";
            // samples
            nprRequest.IsSampleDataRequired = false;

            nprRequest.UxStatus = UxObjectStatus.Created;

            return nprRequest;
        }

        public static RfqNprRequestUxModel Update(this RfqNprRequestUxModel nprRequest, RqfProjectUxModel rfqProject, GlobalValue globalValue)
        {
            nprRequest.CustomerCode = rfqProject.CustomerCode;
            nprRequest.OriginatorName = globalValue.DisplayName;
            nprRequest.CustomerRfqNo = rfqProject.RfqNumber;
            nprRequest.DeadlineDate = rfqProject.RfqResponseDeadline;
            //nprRequest.BOMUnitOfMeasurement = "";
            nprRequest.ProjectCode = rfqProject.ProjectCode;
            //nprRequest.VehicleTotalQuantity = rfqProject.VehicleVolume;
            nprRequest.ManufacturingSite = rfqProject.CustomerLocation ?? nprRequest.ManufacturingSite;
            
            return nprRequest;
        }

        // SampleSiteData gRPC <-> UX conversion
        public static RfqNprRequestSampleSiteDataGrpc ToSampleSiteGrpc(this RfqNprRequestSampleSiteDataUxModel model)
        {
            RfqNprRequestSampleSiteDataGrpc grpc = new RfqNprRequestSampleSiteDataGrpc();
            grpc.BusinessUnitCode = model.BusinessUnitCode;
            grpc.SampleQty = model.SampleQty;
            grpc.SendSampleContactPersonName = model.SendSampleContactPersonName;
            grpc.RequiredDate = model.RequiredDate?.ToUniversalTime().ToTimestamp();
            grpc.FreightAccount = model.FreightAccount;
            return grpc;
        }

        public static RfqNprRequestSampleSiteDataUxModel ToSampleSiteUx(this RfqNprRequestSampleSiteDataGrpc grpc)
        {
            RfqNprRequestSampleSiteDataUxModel model = new RfqNprRequestSampleSiteDataUxModel();
            model.BusinessUnitCode = grpc.BusinessUnitCode;
            model.SampleQty = grpc.SampleQty;
            model.SendSampleContactPersonName = grpc.SendSampleContactPersonName;
            model.RequiredDate = grpc.RequiredDate is null ? null : grpc.RequiredDate.ToDateTime();
            model.FreightAccount = grpc.FreightAccount;
            model.UxStatus = UxObjectStatus.Read;
            return model;
        }

        // NprRequest gRPC -> UX conversion
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        public static RfqNprRequestGrpc ToNprGrpc(this RfqNprRequestUxModel model)
        {
            RfqNprRequestGrpc nprGrpc = new RfqNprRequestGrpc();
            try
            {
                nprGrpc.Id = model.Id.ToString();
            }
            catch (Exception ex)
            {
                nprGrpc.Id = Guid.Empty.ToString();
                Console.WriteLine($"Error converting Id to string: {ex.Message}");
            }   

            nprGrpc.ReasonDescription = model.ReasonDescription;
            nprGrpc.CustomerCode = model.CustomerCode;
            // nprGrpc.PlatformName = model.PlatformName;
            // nprGrpc.ProgramName = model.ProgramName;
            nprGrpc.ProjectCode = model.ProjectCode;
            nprGrpc.ManufacturingSite = model.ManufacturingSite;
            nprGrpc.CustomerPartNumber = model.CustomerPartNumber;
            nprGrpc.SupplierPartNumber = model.SupplierPartNumber;
            nprGrpc.MaterialNumber = model.MaterialNumber;
            nprGrpc.MaterialDescription = model.MaterialDescription;
            nprGrpc.SEWSEUnitOfMeasurement = model.BOMUnitOfMeasurement;
            nprGrpc.SupplierGroup = model.SupplierGroup;
            nprGrpc.SupplierDetailComments = model.SupplierDetailComments;
            nprGrpc.QtyPerVehicle = (double?)model.QtyPerVehicle;
            //nprGrpc.VehicleTotalQuantity = model.VehicleTotalQuantity;
            nprGrpc.DeadlineDate = model.DeadlineDate?.ToUniversalTime().ToTimestamp();
            nprGrpc.NPRRaisedRemarks = model.NPRRaisedRemarks;
            nprGrpc.IsCustomerNominatedSupplier = model.IsCustomerNominatedSupplier;
            nprGrpc.IsCustomerNominatedMaterial = model.IsCustomerNominatedMaterial;
            nprGrpc.IsSampleDataRequired = model.IsSampleDataRequired;

            // Map SampleSiteDetails collection
            foreach (RfqNprRequestSampleSiteDataUxModel site in model.SampleSiteDetails)
            {
                if (site.UxStatus != UxObjectStatus.Deleted)
                {
                    nprGrpc.SampleSiteDetails.Add(site.ToSampleSiteGrpc());
                }
            }

            nprGrpc.AssociatedParts = model.AssociatedParts;
            nprGrpc.SuggestedManufacturerGroup = model.SuggestedManufacturerGroup;
            nprGrpc.CreatedAt = model.Created.ToUniversalTime().ToTimestamp();
            //nprGrpc.CreatedBy = model.CreatedBy.ToString();
            nprGrpc.ModifiedAt = model.Updated.ToUniversalTime().ToTimestamp();
            //nprGrpc.ModifiedBy = model.ModifiedBy.ToString();
            nprGrpc.SubmissionStatus = (int?)model.Status;
            //nprGrpc.RemoteEndpointResponse = model.RemoteEndpointResponse;
            //nprGrpc.SubmittedAt = model.SubmittedAt?.ToUniversalTime().ToTimestamp();
            nprGrpc.CustomerRfqNo = model.CustomerRfqNo;
            nprGrpc.RequestID = model.RequestID;
            nprGrpc.OriginatorName = model.OriginatorName;
            nprGrpc.NPRUploadSeqNo = model.NPRUploadSeqNo;

            nprGrpc.IsActive = model.UxStatus != UxObjectStatus.Deleted;

            return nprGrpc;
        }

        // NprRequest UX -> gRPC conversion
        public static RfqNprRequestUxModel ToNprUx(this RfqNprRequestGrpc grpc)
        {
            RfqNprRequestUxModel model = new RfqNprRequestUxModel();
            model.Id = Guid.Parse(grpc.Id);
            model.ReasonDescription = grpc.ReasonDescription;
            model.CustomerCode = grpc.CustomerCode;
            //model.PlatformName = grpc.PlatformName;
            //model.ProgramName = grpc.ProgramName;
            model.ProjectCode = grpc.ProjectCode;
            model.ManufacturingSite = grpc.ManufacturingSite;
            model.CustomerPartNumber = grpc.CustomerPartNumber;
            model.SupplierPartNumber = grpc.SupplierPartNumber;
            model.MaterialNumber = grpc.MaterialNumber;
            model.MaterialDescription = grpc.MaterialDescription;
            model.BOMUnitOfMeasurement = grpc.SEWSEUnitOfMeasurement;
            model.SupplierGroup = grpc.SupplierGroup;
            model.SupplierDetailComments = grpc.SupplierDetailComments;
            model.QtyPerVehicle = grpc.QtyPerVehicle.HasValue ? (decimal)grpc.QtyPerVehicle.Value : null;
            //model.VehicleTotalQuantity = grpc.VehicleTotalQuantity;
            model.DeadlineDate = grpc.DeadlineDate?.ToDateTime();
            model.NPRRaisedRemarks = grpc.NPRRaisedRemarks;
            model.IsCustomerNominatedSupplier = grpc.IsCustomerNominatedSupplier ?? false;
            model.IsCustomerNominatedMaterial = grpc.IsCustomerNominatedMaterial ?? false;
            model.IsSampleDataRequired = grpc.IsSampleDataRequired ?? false;

            // Map SampleSiteDetails collection
            foreach (RfqNprRequestSampleSiteDataGrpc siteGrpc in grpc.SampleSiteDetails)
            {
                model.SampleSiteDetails.Add(siteGrpc.ToSampleSiteUx());
            }

            model.AssociatedParts = grpc.AssociatedParts;
            model.SuggestedManufacturerGroup = grpc.SuggestedManufacturerGroup;
            model.RequestID = grpc.RequestID;
            model.OriginatorName = grpc.OriginatorName;
            model.NPRUploadSeqNo = grpc.NPRUploadSeqNo;
            model.Created = grpc.CreatedAt is null
                ? DateTime.UtcNow
                : grpc.CreatedAt.ToDateTime();
            //nprGrpc.CreatedBy = model.CreatedBy.ToString();
            model.Updated = grpc.ModifiedAt is null
                ? DateTime.UtcNow
                : grpc.ModifiedAt.ToDateTime();
            //nprGrpc.ModifiedBy = model.ModifiedBy.ToString();
            model.Status = grpc.SubmissionStatus.HasValue ? (RfqNprRequestSet)grpc.SubmissionStatus.Value : new RfqNprRequestSet();
            //nprGrpc.RemoteEndpointResponse = model.RemoteEndpointResponse;
            //nprGrpc.SubmittedAt = model.SubmittedAt?.ToUniversalTime().ToTimestamp();
            model.CustomerRfqNo = grpc.CustomerRfqNo;

            model.UxStatus = grpc.IsActive == false ? UxObjectStatus.Deleted : UxObjectStatus.Read;

            return model;
        }
        #endregion

        #region Suppliers and Supplier Group
        public static SupplierUxModel? ToUx(this SupplierGrpc? supplier)
        {
            if (supplier == null)
            {
                return null;
            }

            SupplierUxModel uxModel = new SupplierUxModel();
            uxModel.SupplierCode = supplier.SupplierCode;
            uxModel.SupplierName = supplier.SupplierName;
            uxModel.Address1 = supplier.Address1;
            uxModel.Address2 = supplier.Address2;
            uxModel.Address3 = supplier.Address3;
            uxModel.City = supplier.City;
            uxModel.Region = supplier.Region;
            uxModel.ZipCode = supplier.ZipCode;
            uxModel.ZipCode = supplier.ZipCode;
            uxModel.CountryGuid = Guid.TryParse(supplier.CountryGuid, out Guid countryGuid) ? countryGuid : Guid.Empty;
            uxModel.SupplierTypeGuid = Guid.TryParse(supplier.SupplierTypeGuid, out Guid supplierTypeGuid) ? supplierTypeGuid : Guid.Empty;
            uxModel.SupplierGroupGuid = Guid.TryParse(supplier.SupplierGroupGuid, out Guid supplierGroupGuid) ? supplierGroupGuid : Guid.Empty;
            uxModel.SupplierIncoTermsGuid = Guid.TryParse(supplier.SupplierIncoTermsGuid, out Guid supplierIncoTermsGuid) ? supplierIncoTermsGuid : Guid.Empty;
            uxModel.SupplierCurrencyGuid = Guid.TryParse(supplier.SupplierCurrencyGuid, out Guid supplierCurrencyGuid) ? supplierCurrencyGuid : Guid.Empty;
            uxModel.SupplierBuyerGuid = Guid.TryParse(supplier.SupplierBuyerGuid, out Guid supplierBuyerGuid) ? supplierBuyerGuid : Guid.Empty;
            uxModel.SupplierDevelopmentTeamGuid = Guid.TryParse(supplier.SupplierDevelopmentTeamGuid, out Guid supplierDevelopmentTeamGuid) ? supplierDevelopmentTeamGuid : Guid.Empty;
            uxModel.PaymentTerms = supplier.PaymentTerms;
            uxModel.EPOCommodityGroupGuid = Guid.TryParse(supplier.EPOCommodityGroupGuid, out Guid ePOCommodityGroupGuid) ? ePOCommodityGroupGuid : Guid.Empty;
            uxModel.POPriceEffectiveDateTypeGuid = Guid.TryParse(supplier.POPriceEffectiveDateTypeGuid, out Guid pOPriceEffectiveDateTypeGuid) ? pOPriceEffectiveDateTypeGuid : Guid.Empty;
            uxModel.SupplierApprovalStatusGuid = Guid.TryParse(supplier.SupplierApprovalStatusGuid, out Guid supplierApprovalStatusGuid) ? supplierApprovalStatusGuid : Guid.Empty;
            uxModel.IsActive = supplier.IsActive;
            uxModel.Id = Guid.TryParse(supplier.Id, out Guid id) ? id : Guid.Empty;
            uxModel.CreatedDate = supplier.CreatedDate?.ToDateTime();
            uxModel.ModifiedDate = supplier.ModifiedDate?.ToDateTime();
            uxModel.CreatedBy = Guid.TryParse(supplier.CreatedBy, out Guid createdBy) ? createdBy : Guid.Empty;
            uxModel.ModifiedBy = Guid.TryParse(supplier.ModifiedBy, out Guid modifiedBy) ? modifiedBy : Guid.Empty;
            uxModel.SyncToCPD = (short?)supplier.SyncToCPD;
            uxModel.DistributionCountryOfOriginGuid = Guid.TryParse(supplier.DistributionCountryOfOriginGuid, out Guid distributionCountryOfOriginGuid) ? distributionCountryOfOriginGuid : Guid.Empty;
            uxModel.IsEOLRequired = supplier.IsEOLRequired;

            return uxModel;
        }

        public static SupplierGroupUxModel? ToUx(this SupplierGroupGrpc? supplierGroup)
        {
            if (supplierGroup == null)
            {
                return null;
            }

            SupplierGroupUxModel uxModel = new SupplierGroupUxModel();
            uxModel.SupplierGroupName = supplierGroup.SupplierGroupName;
            uxModel.SupplierApprovalStatusGuid = Guid.TryParse(supplierGroup.SupplierApprovalStatusGuid, out Guid supplierApprovalStatusGuid) ? supplierApprovalStatusGuid : Guid.Empty;
            uxModel.SupplierPanelGuid = Guid.TryParse(supplierGroup.SupplierPanelGuid, out Guid supplierPanelGuid) ? supplierPanelGuid : Guid.Empty;
            uxModel.IsActive = supplierGroup.IsActive;
            uxModel.IsSWSPartNumberRequired = supplierGroup.IsSWSPartNumberRequired;
            uxModel.Id = Guid.TryParse(supplierGroup.Id, out Guid id) ? id : Guid.Empty;
            uxModel.CreatedDate = supplierGroup.CreatedDate?.ToDateTime();
            uxModel.ModifiedDate = supplierGroup.ModifiedDate?.ToDateTime();
            uxModel.CreatedBy = Guid.TryParse(supplierGroup.CreatedBy, out Guid createdBy) ? createdBy : Guid.Empty;
            uxModel.ModifiedBy = Guid.TryParse(supplierGroup.ModifiedBy, out Guid modifiedBy) ? modifiedBy : Guid.Empty;
            uxModel.SyncToCPD = (short?)supplierGroup.SyncToCPD;
            uxModel.IsEOLRequired = supplierGroup.IsEOLRequired;
            return uxModel;
        }
        #endregion

        #region UnitOfMeasure
        public static UnitOfMeasureUxModel? ToUx(this UnitOfMeasureGrpc? unitOfMeasure)
        {
            if (unitOfMeasure == null)
            {
                return null;
            }

            UnitOfMeasureUxModel uxModel = new UnitOfMeasureUxModel();
            uxModel.UnitOfMeasureDescription = unitOfMeasure.UnitOfMeasureDescription;
            uxModel.Code = unitOfMeasure.Code;
            uxModel.IsActive = unitOfMeasure.IsActive;
            uxModel.Id = Guid.TryParse(unitOfMeasure.Id, out Guid id) ? id : Guid.Empty;
            return uxModel;
        }
        public static BusinessUnitUxModel? ToUx(this BusinessUnitGrpc businessUnit)
        {
            if (businessUnit == null)
            {
                return null;
            }

            BusinessUnitUxModel uxModel = new BusinessUnitUxModel();
            uxModel.BusinessUnitCode = businessUnit.BusinessUnitCode;
            uxModel.BusinessUnitName = businessUnit.BusinessUnitName;
            uxModel.BusinessUnitTypeGuid = Guid.TryParse(businessUnit.BusinessUnitTypeGuid, out Guid businessUnitTypeGuid) ? businessUnitTypeGuid : (Guid?)null;
            uxModel.StreetNumber = businessUnit.StreetNumber;
            uxModel.StreetName = businessUnit.StreetName;
            uxModel.City = businessUnit.City;
            uxModel.Region = businessUnit.Region;
            uxModel.ZipCode = businessUnit.ZipCode;
            uxModel.CountryGuid = Guid.TryParse(businessUnit.CountryGuid, out Guid countryGuid) ? countryGuid : (Guid?)null;
            uxModel.IsActive = businessUnit.IsActive;
            uxModel.Id = Guid.TryParse(businessUnit.Id, out Guid id) ? id : (Guid?)null;
            uxModel.CreatedDate = businessUnit.CreatedDate is null ? null : businessUnit.CreatedDate.ToDateTime();
            uxModel.ModifiedDate = businessUnit.ModifiedDate is null ? null : businessUnit.ModifiedDate.ToDateTime();
            uxModel.CreatedBy = Guid.TryParse(businessUnit.CreatedBy, out Guid createdBy) ? createdBy : (Guid?)null;
            uxModel.ModifiedBy = Guid.TryParse(businessUnit.ModifiedBy, out Guid modifiedBy) ? modifiedBy : (Guid?)null;
            uxModel.SyncToCPD = businessUnit.SyncToCPD.HasValue ? (short?)businessUnit.SyncToCPD.Value : null;
            uxModel.IsExternalWarehouse = businessUnit.IsExternalWarehouse;
            uxModel.EWMSWarehouseCode = businessUnit.EWMSWarehouseCode;
            uxModel.DisplayName = businessUnit.DisplayName;
            uxModel.LegacyBusinessUnitCode = businessUnit.LegacyBusinessUnitCode;
            uxModel.LegacyBusinessUnitName = businessUnit.LegacyBusinessUnitName;
            uxModel.Company = businessUnit.Company;
            uxModel.BusinessUnitDescription = businessUnit.BusinessUnitDescription;
            uxModel.BusinessUnitContactName = businessUnit.BusinessUnitContactName;
            uxModel.BusinessUnitContactNumber = businessUnit.BusinessUnitContactNumber;
            uxModel.BusinessUnitAltContactNumber = businessUnit.BusinessUnitAltContactNumber;
            uxModel.BusinessUnitMainPhoneNumber = businessUnit.BusinessUnitMainPhoneNumber;
            uxModel.BusinessUnitManagerEmail = businessUnit.BusinessUnitManagerEmail;
            uxModel.Router = businessUnit.Router;
            uxModel.Subnet = businessUnit.Subnet;
            uxModel.HostFrom = businessUnit.HostFrom;
            uxModel.HostTo = businessUnit.HostTo;
            uxModel.ITEngineer = businessUnit.ITEngineer;
            uxModel.BackupOperator = businessUnit.BackupOperator;
            uxModel.InterSeptor = businessUnit.InterSeptor;
            uxModel.InterSeptorFirmware = businessUnit.InterSeptorFirmware;
            uxModel.InterSeptorAlerts = businessUnit.InterSeptorAlerts;
            uxModel.UseLocalSupport = businessUnit.UseLocalSupport;
            uxModel.VideoConference = businessUnit.VideoConference;
            uxModel.VideoConferenceIP = businessUnit.VideoConferenceIP;
            uxModel.AccessCircuit = businessUnit.AccessCircuit.HasValue ? (decimal?)businessUnit.AccessCircuit.Value : null;
            uxModel.PERouter1 = businessUnit.PERouter1;
            uxModel.PERouter2 = businessUnit.PERouter2;
            uxModel.MRTG = businessUnit.MRTG;
            uxModel.WiFi = businessUnit.WiFi;
            uxModel.Printer = businessUnit.Printer;
            uxModel.Copier = businessUnit.Copier;
            uxModel.LocalIT = businessUnit.LocalIT;
            uxModel.Wan = businessUnit.Wan;
            uxModel.WanType = businessUnit.WanType;
            uxModel.WanStatus = businessUnit.WanStatus;
            uxModel.WanDownCount = businessUnit.WanDownCount;
            uxModel.WanHighRTT = businessUnit.WanHighRTT;
            uxModel.LocalBackups = businessUnit.LocalBackups;
            uxModel.MitelController = businessUnit.MitelController;
            uxModel.MitelControllerBackup = businessUnit.MitelControllerBackup;
            uxModel.Riverbed = businessUnit.Riverbed;
            uxModel.VCenter = businessUnit.VCenter;
            uxModel.CCTV = businessUnit.CCTV;
            uxModel.DefaultFileServer = businessUnit.DefaultFileServer;
            uxModel.DefaultMailServer = businessUnit.DefaultMailServer;
            uxModel.DefaultCopier = businessUnit.DefaultCopier;
            uxModel.DefaultWDSServer = businessUnit.DefaultWDSServer;
            uxModel.DefaultDeployRoot = businessUnit.DefaultDeployRoot;
            uxModel.DefaultHRManager = businessUnit.DefaultHRManager;
            uxModel.PDR = businessUnit.PDR;
            uxModel.Mapurl = businessUnit.MapUrl;
            uxModel.Longtitude = businessUnit.Longtitude;
            uxModel.Latitude = businessUnit.Latitude;
            uxModel.What3Words = businessUnit.What3Words;
            uxModel.NearestWeatherCity = businessUnit.NearestWeatherCity;
            uxModel.WeatherTemperatureHigh = businessUnit.WeatherTemperatureHigh;
            uxModel.WeatherTemperatureLow = businessUnit.WeatherTemperatureLow;
            uxModel.Weatherurl = businessUnit.WeatherUrl;
            uxModel.WeatherMaxWindSpeed = businessUnit.WeatherMaxWindSpeed;
            uxModel.WeatherTemperatureThreshold = businessUnit.WeatherTemperatureThreshold;
            uxModel.WeatherReportDate = businessUnit.WeatherReportDate is null ? null : businessUnit.WeatherReportDate.ToDateTime();
            uxModel.TrafficSummary = businessUnit.TrafficSummary;

            return uxModel;
        }
        #endregion

        #region DSIHarnessGrpc
        public static DsiHarnessUxModel? ToUxModel(this DSIHarnessGrpc dto)
        {
            if(dto is null)
            {
                return null;
            }

            DsiHarnessUxModel uxModel = new DsiHarnessUxModel();
            uxModel.Id = Guid.Parse(dto.Id);
            uxModel.HarnessName1 = dto.HarnessName1;
            uxModel.SimilarHarnessName1 = dto.SimilarHarnessName1;
            uxModel.HarnessIssue1 = dto.HarnessIssue1;
            uxModel.SimilarHarnessIssue1 = dto.SimilarHarnessIssue1;
            uxModel.HarnessDate1 = dto.HarnessDate1?.ToDateTime();

            uxModel.HarnessName2 = dto.HarnessName2;
            uxModel.SimilarHarnessName2 = dto.SimilarHarnessName2;
            uxModel.HarnessIssue2 = dto.HarnessIssue2;
            uxModel.SimilarHarnessIssue2 = dto.SimilarHarnessIssue2;
            uxModel.HarnessDate2 = dto.HarnessDate2?.ToDateTime();

            uxModel.FileVersion = dto.FileVersion;

            uxModel.Customer = dto.Customer;
            uxModel.Site = dto.Site;
            uxModel.Range = dto.Range;

            uxModel.BoardLength = dto.BoardLength;
            uxModel.BoardWidth = dto.BoardWidth;

            uxModel.Datum = dto.Datum;

            uxModel.UserField1 = dto.UserField1;
            uxModel.UserField2 = dto.UserField2;
            uxModel.UserField3 = dto.UserField3;
            uxModel.UserField4 = dto.UserField4;
            uxModel.UserField5 = dto.UserField5;

            uxModel.Checker = dto.Checker;
            uxModel.Inputter = dto.Inputter;
            uxModel.DraftedBy = dto.DraftedBy;
            uxModel.PreparedBy = dto.PreparedBy;

            uxModel.Type = dto.Type;
            uxModel.Title = dto.Title;
            uxModel.EngineSize = dto.EngineSize;
            uxModel.ManufacturingCell = dto.ManufacturingCell;
            uxModel.Trim = dto.Trim;
            uxModel.HandDrive = dto.HandDrive;

            uxModel.TubeAddOnType = dto.TubeAddOnType;
            uxModel.TubeAddOnFactor = dto.TubeAddOnFactor;

            uxModel.IsManualTerminal = dto.IsManualTerminal;
            uxModel.IsAllConnectorsSealed = dto.IsAllConnectorsSealed;
            uxModel.IsModule = dto.IsModule;
            uxModel.IsPitchTableUsed = dto.IsPitchTableUsed;

            //uxModel.AlphaCode = dto.AlphaCode;
            //uxModel.AdditionalComments = dto.AdditionalComments;

            //uxModel.CreatedDate = dto.CreatedDate?.ToDateTime();
            uxModel.ModifiedDate = dto.ModifiedDate?.ToDateTime();

            uxModel.CreatedBy = dto.CreatedBy;
            uxModel.ModifiedBy = dto.ModifiedBy;

            return uxModel;
        }
        public static DSIHarnessGrpc? ToGrpcDto(this DsiHarnessUxModel uxModel)
        {
            if (uxModel is null)
            {
                return null;
            }

            DSIHarnessGrpc dto = new DSIHarnessGrpc
            {
                Id = uxModel.Id.ToString(),

                HarnessName1 = uxModel.HarnessName1 ?? string.Empty,
                SimilarHarnessName1 = uxModel.SimilarHarnessName1 ?? string.Empty,
                HarnessIssue1 = uxModel.HarnessIssue1 ?? string.Empty,
                SimilarHarnessIssue1 = uxModel.SimilarHarnessIssue1 ?? string.Empty,

                HarnessName2 = uxModel.HarnessName2 ?? string.Empty,
                SimilarHarnessName2 = uxModel.SimilarHarnessName2 ?? string.Empty,
                HarnessIssue2 = uxModel.HarnessIssue2 ?? string.Empty,
                SimilarHarnessIssue2 = uxModel.SimilarHarnessIssue2 ?? string.Empty,

                FileVersion = uxModel.FileVersion ?? 0d,

                Customer = uxModel.Customer ?? string.Empty,
                Site = uxModel.Site ?? string.Empty,
                Range = uxModel.Range ?? string.Empty,

                BoardLength = uxModel.BoardLength ?? 0d,
                BoardWidth = uxModel.BoardWidth ?? 0d,

                Datum = uxModel.Datum ?? string.Empty,

                UserField1 = uxModel.UserField1 ?? string.Empty,
                UserField2 = uxModel.UserField2 ?? string.Empty,
                UserField3 = uxModel.UserField3 ?? string.Empty,
                UserField4 = uxModel.UserField4 ?? string.Empty,
                UserField5 = uxModel.UserField5 ?? string.Empty,

                Checker = uxModel.Checker ?? string.Empty,
                Inputter = uxModel.Inputter ?? string.Empty,
                DraftedBy = uxModel.DraftedBy ?? string.Empty,
                PreparedBy = uxModel.PreparedBy ?? string.Empty,

                Type = uxModel.Type ?? string.Empty,
                Title = uxModel.Title ?? string.Empty,
                EngineSize = uxModel.EngineSize ?? string.Empty,
                ManufacturingCell = uxModel.ManufacturingCell ?? string.Empty,
                Trim = uxModel.Trim ?? string.Empty,
                HandDrive = uxModel.HandDrive ?? string.Empty,

                TubeAddOnType = uxModel.TubeAddOnType ?? string.Empty,
                TubeAddOnFactor = uxModel.TubeAddOnFactor ?? 0d,

                IsManualTerminal = uxModel.IsManualTerminal ?? false,
                IsAllConnectorsSealed = uxModel.IsAllConnectorsSealed ?? false,
                IsModule = uxModel.IsModule ?? false,
                IsPitchTableUsed = uxModel.IsPitchTableUsed ?? false,

                //AlphaCode = uxModel.AlphaCode ?? string.Empty,
                //AdditionalComments = uxModel.AdditionalComments ?? string.Empty,

                CreatedBy = uxModel.CreatedBy ?? string.Empty,
                ModifiedBy = uxModel.ModifiedBy ?? string.Empty
            };

            // Timestamp fields (if present in your proto as google.protobuf.Timestamp)
            if (uxModel.HarnessDate1.HasValue)
            {
                dto.HarnessDate1 = Timestamp.FromDateTime(
                    DateTime.SpecifyKind(uxModel.HarnessDate1.Value, DateTimeKind.Utc));
            }

            if (uxModel.HarnessDate2.HasValue)
            {
                dto.HarnessDate2 = Timestamp.FromDateTime(
                    DateTime.SpecifyKind(uxModel.HarnessDate2.Value, DateTimeKind.Utc));
            }

            //if (uxModel.CreatedDate.HasValue)
            //{
            //    dto.CreatedDate = Timestamp.FromDateTime(
            //        DateTime.SpecifyKind(uxModel.CreatedDate.Value, DateTimeKind.Utc));
            //}

            if (uxModel.ModifiedDate.HasValue)
            {
                dto.ModifiedDate = Timestamp.FromDateTime(
                    DateTime.SpecifyKind(uxModel.ModifiedDate.Value, DateTimeKind.Utc));
            }

            return dto;
        }
        #endregion

        #region DSI CompositeDetailGrpc
        public static DsiCompositeDetailUxModel ToUxModel(this DSICompositeDetailGrpc dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            DsiCompositeDetailUxModel uxModel = new DsiCompositeDetailUxModel
            {
                Id = dto.Id,

                HarnessName1 = dto.HarnessName1,
                SimilarHarnessName1 = dto.SimilarHarnessName1,
                HarnessIssue1 = dto.HarnessIssue1,
                SimilarHarnessIssue1 = dto.SimilarHarnessIssue1,
                HarnessDate1 = dto.HarnessDate1?.ToDateTime(),

                HarnessName2 = dto.HarnessName2,
                SimilarHarnessName2 = dto.SimilarHarnessName2,
                HarnessIssue2 = dto.HarnessIssue2,
                SimilarHarnessIssue2 = dto.SimilarHarnessIssue2,
                HarnessDate2 = dto.HarnessDate2?.ToDateTime(),

                Customer = dto.Customer,
                Site = dto.Site,
                Range = dto.Range,

                BoardLength = dto.BoardLength,
                BoardWidth = dto.BoardWidth,

                Datum = dto.Datum,

                UserField1 = dto.UserField1,
                UserField2 = dto.UserField2,
                UserField3 = dto.UserField3,
                UserField4 = dto.UserField4,
                UserField5 = dto.UserField5,

                Checker = dto.Checker,
                Inputter = dto.Inputter,
                DraftedBy = dto.DraftedBy,
                PreparedBy = dto.PreparedBy,

                Type = dto.Type,
                Title = dto.Title,
                EngineSize = dto.EngineSize,
                ManufacturingCell = dto.ManufacturingCell,
                Trim = dto.Trim,
                HandDrive = dto.HandDrive,

                TubeAddOnType = dto.TubeAddOnType,
                TubeAddOnFactor = dto.TubeAddOnFactor,

                IsManualTerminal = dto.IsManualTerminal,
                IsAllConnectorsSealed = dto.IsAllConnectorsSealed,

                AlphaCode = dto.AlphaCode,
                //HarnessId = dto.HarnessId,
                CircuitOption = dto.CircuitOption,

                CreatedDate = dto.CreatedDate?.ToDateTime(),
                ModifiedDate = dto.ModifiedDate?.ToDateTime(),

                CreatedBy = dto.CreatedBy,
                ModifiedBy = dto.ModifiedBy
            };

            return uxModel;
        }

        public static DSICompositeDetailGrpc ToGrpcDto(this DsiCompositeDetailUxModel uxModel)
        {
            if (uxModel is null)
            {
                throw new ArgumentNullException(nameof(uxModel));
            }

            DSICompositeDetailGrpc dto = new DSICompositeDetailGrpc
            {
                Id = uxModel.Id,

                HarnessName1 = uxModel.HarnessName1 ?? string.Empty,
                SimilarHarnessName1 = uxModel.SimilarHarnessName1 ?? string.Empty,
                HarnessIssue1 = uxModel.HarnessIssue1 ?? string.Empty,
                SimilarHarnessIssue1 = uxModel.SimilarHarnessIssue1 ?? string.Empty,

                HarnessName2 = uxModel.HarnessName2 ?? string.Empty,
                SimilarHarnessName2 = uxModel.SimilarHarnessName2 ?? string.Empty,
                HarnessIssue2 = uxModel.HarnessIssue2 ?? string.Empty,
                SimilarHarnessIssue2 = uxModel.SimilarHarnessIssue2 ?? string.Empty,

                Customer = uxModel.Customer ?? string.Empty,
                Site = uxModel.Site ?? string.Empty,
                Range = uxModel.Range ?? string.Empty,

                BoardLength = uxModel.BoardLength ?? 0d,
                BoardWidth = uxModel.BoardWidth ?? 0d,

                Datum = uxModel.Datum ?? string.Empty,

                UserField1 = uxModel.UserField1 ?? string.Empty,
                UserField2 = uxModel.UserField2 ?? string.Empty,
                UserField3 = uxModel.UserField3 ?? string.Empty,
                UserField4 = uxModel.UserField4 ?? string.Empty,
                UserField5 = uxModel.UserField5 ?? string.Empty,

                Checker = uxModel.Checker ?? string.Empty,
                Inputter = uxModel.Inputter ?? string.Empty,
                DraftedBy = uxModel.DraftedBy ?? string.Empty,
                PreparedBy = uxModel.PreparedBy ?? string.Empty,

                Type = uxModel.Type ?? string.Empty,
                Title = uxModel.Title ?? string.Empty,
                EngineSize = uxModel.EngineSize ?? string.Empty,
                ManufacturingCell = uxModel.ManufacturingCell ?? string.Empty,
                Trim = uxModel.Trim ?? string.Empty,
                HandDrive = uxModel.HandDrive ?? string.Empty,

                TubeAddOnType = uxModel.TubeAddOnType ?? string.Empty,
                TubeAddOnFactor = uxModel.TubeAddOnFactor ?? 0d,

                IsManualTerminal = uxModel.IsManualTerminal ?? false,
                IsAllConnectorsSealed = uxModel.IsAllConnectorsSealed ?? false,

                AlphaCode = uxModel.AlphaCode ?? string.Empty,
                //HarnessId = uxModel.HarnessId ?? string.Empty,
                CircuitOption = uxModel.CircuitOption ?? string.Empty,

                CreatedBy = uxModel.CreatedBy ?? string.Empty,
                ModifiedBy = uxModel.ModifiedBy ?? string.Empty
            };

            if (uxModel.HarnessDate1.HasValue)
            {
                dto.HarnessDate1 = Timestamp.FromDateTime(
                    DateTime.SpecifyKind(uxModel.HarnessDate1.Value, DateTimeKind.Utc));
            }

            if (uxModel.HarnessDate2.HasValue)
            {
                dto.HarnessDate2 = Timestamp.FromDateTime(
                    DateTime.SpecifyKind(uxModel.HarnessDate2.Value, DateTimeKind.Utc));
            }

            if (uxModel.CreatedDate.HasValue)
            {
                dto.CreatedDate = Timestamp.FromDateTime(
                    DateTime.SpecifyKind(uxModel.CreatedDate.Value, DateTimeKind.Utc));
            }

            if (uxModel.ModifiedDate.HasValue)
            {
                dto.ModifiedDate = Timestamp.FromDateTime(
                    DateTime.SpecifyKind(uxModel.ModifiedDate.Value, DateTimeKind.Utc));
            }

            return dto;
        }
        #endregion

        #region DSIComponentGrpc
        public static DsiComponentUxModel ToUxModel(this DSIComponentGrpc dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            DsiComponentUxModel uxModel = new DsiComponentUxModel();
            
            uxModel.Id = dto.Id;
            uxModel.NodeName = dto.NodeName ?? string.Empty;
            uxModel.CavityName = dto.CavityName ?? string.Empty;
            uxModel.WireName = dto.WireName ?? string.Empty;
            uxModel.SequenceNumber = dto.SequenceNumber ?? string.Empty;
            uxModel.ComponentTypeCode1 = dto.ComponentTypeCode1 ?? string.Empty;
            uxModel.ComponentOption = dto.ComponentOption ?? string.Empty;
            uxModel.ServiceFunction = dto.ServiceFunction ?? string.Empty;
            uxModel.Route = dto.Route ?? string.Empty;
            uxModel.PartNumber1 = dto.PartNumber1 ?? string.Empty;
            uxModel.PartNumber2 = dto.PartNumber2 ?? string.Empty;
            uxModel.PartNumber3 = dto.PartNumber3 ?? string.Empty;
            uxModel.Quantity = dto.Quantity ?? 0d;
            uxModel.CrossSectionalArea = dto.CrossSectionalArea ?? 0d;
            uxModel.IsSelectTerminal = dto.IsSelectTerminal ?? false;
            uxModel.IsSeal = dto.IsSeal ?? false;
            uxModel.IsPlugged = dto.IsPlugged ?? false;
            uxModel.BlockNumber = dto.BlockNumber ?? string.Empty;
            uxModel.TerminationMethod = dto.TerminationMethod ?? string.Empty;
            uxModel.MaterialCode = dto.MaterialCode ?? string.Empty;
            uxModel.ComponentTypeCode2 = dto.ComponentTypeCode2 ?? string.Empty;
            uxModel.InsulationType = dto.InsulationType ?? string.Empty;
            uxModel.UserModule = dto.UserModule ?? string.Empty;
            uxModel.HarnessId = dto.HarnessID ?? string.Empty;
            uxModel.CreatedDate = dto.CreatedDate is null 
                ? DateTime.UtcNow
                : dto.CreatedDate.ToDateTime();
            uxModel.ModifiedDate = dto.ModifiedDate is null 
                ? DateTime.UtcNow
                : dto.ModifiedDate.ToDateTime();  
            
            return uxModel;
        }
        public static DSIComponentGrpc ToGrpcDto(this DsiComponentUxModel uxModel)
        {
            if (uxModel == null)
            {
                throw new ArgumentNullException(nameof(uxModel));
            }

            DSIComponentGrpc grpcDto = new();
                
            grpcDto.Id = uxModel.Id;
            grpcDto.NodeName = uxModel.NodeName;
            grpcDto.CavityName = uxModel.CavityName;
            grpcDto.WireName = uxModel.WireName;
            grpcDto.SequenceNumber = uxModel.SequenceNumber;
            grpcDto.ComponentTypeCode1 = uxModel.ComponentTypeCode1;
            grpcDto.ComponentOption = uxModel.ComponentOption;
            grpcDto.ServiceFunction = uxModel.ServiceFunction;
            grpcDto.Route = uxModel.Route;
            grpcDto.PartNumber1 = uxModel.PartNumber1;
            grpcDto.PartNumber2 = uxModel.PartNumber2;
            grpcDto.PartNumber3 = uxModel.PartNumber3;
            grpcDto.Quantity = uxModel.Quantity;
            grpcDto.CrossSectionalArea = uxModel.CrossSectionalArea;
            grpcDto.IsSelectTerminal = uxModel.IsSelectTerminal;
            grpcDto.IsSeal = uxModel.IsSeal;
            grpcDto.IsPlugged = uxModel.IsPlugged;
            grpcDto.BlockNumber = uxModel.BlockNumber;
            grpcDto.TerminationMethod = uxModel.TerminationMethod;
            grpcDto.MaterialCode = uxModel.MaterialCode;
            grpcDto.ComponentTypeCode2 = uxModel.ComponentTypeCode2;
            grpcDto.InsulationType = uxModel.InsulationType;
            grpcDto.UserModule = uxModel.UserModule;
            grpcDto.HarnessID = uxModel.HarnessId;
            grpcDto.CreatedDate = Timestamp.FromDateTime(DateTime.SpecifyKind(uxModel.CreatedDate, DateTimeKind.Utc));
            grpcDto.ModifiedDate = Timestamp.FromDateTime(DateTime.SpecifyKind(uxModel.ModifiedDate, DateTimeKind.Utc));

            return grpcDto;
        }
        #endregion

        #region DSIWireSpecificationGrpc
        public static DsiWireSpecificationUxModel ToUxModel(this DSIWireSpecificationGrpc dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            DsiWireSpecificationUxModel uxModel = new DsiWireSpecificationUxModel();
            
            uxModel.Id = dto.Id;
            uxModel.WireName = dto.WireName ?? string.Empty;
            uxModel.Compositeoptionstring = dto.Compositeoptionstring ?? string.Empty;
            uxModel.WireType = dto.WireType ?? string.Empty;
            uxModel.Colour = dto.Colour ?? string.Empty;
            uxModel.CrossSectionalArea = dto.CrossSectionalArea ?? 0d;
            uxModel.Material = dto.Material ?? string.Empty;
            uxModel.UserModule = dto.UserModule ?? string.Empty;
            uxModel.MulticoreName = dto.MulticoreName ?? string.Empty;

            uxModel.End1NodeName = dto.End1NodeName ?? string.Empty;
            uxModel.End1Route = dto.End1Route ?? string.Empty;
            uxModel.End1Cavity = dto.End1Cavity ?? string.Empty;
            uxModel.End1MaterialCode = dto.End1MaterialCode ?? string.Empty;    

            uxModel.End2NodeName = dto.End2NodeName ?? string.Empty;
            uxModel.End2Route = dto.End2Route ?? string.Empty;
            uxModel.End2Cavity = dto.End2Cavity ?? string.Empty;
            uxModel.End2MaterialCode = dto.End2MaterialCode ?? string.Empty;

            uxModel.IsIncludedOnBom = dto.IsIncludedOnBom ?? false;
            uxModel.IsIncludedOnChart = dto.IsIncludedOnChart ?? false;

            uxModel.WireTag = dto.WireTag ?? string.Empty;
            uxModel.WireNote = dto.WireNote ?? string.Empty;

            uxModel.WireLengthChangeType = dto.WireLengthChangeType ?? string.Empty;
            uxModel.WireLengthChangeValue = dto.WireLengthChangeValue ?? 0d;
            uxModel.AssemblyItemNumber = dto.AssemblyItemNumber ?? 0d;

            uxModel.MulticoreOption = dto.MulticoreOption ?? string.Empty;

            uxModel.UnmodifiedWireLength = dto.UnmodifiedWireLength ?? 0d;
            uxModel.ModifiedWireLength = dto.ModifiedWireLength ?? 0d;
            uxModel.CutbackAtEnd1 = dto.CutbackAtEnd1 ?? 0d;
            uxModel.CutbackAtEnd2 = dto.CutbackAtEnd2 ?? 0d;

            uxModel.PartNumber1 = dto.PartNumber1 ?? string.Empty;
            uxModel.PartNumber2 = dto.PartNumber2 ?? string.Empty;
            uxModel.PartNumber3 = dto.PartNumber3 ?? string.Empty;

            uxModel.Signal = dto.Signal ?? string.Empty;
            uxModel.HarnessID = dto.HarnessID ?? string.Empty;

            uxModel.CreatedDate = dto.CreatedDate.ToDateTime();
            uxModel.ModifiedDate = dto.ModifiedDate.ToDateTime();

            uxModel.CreatedBy = dto.CreatedBy ?? string.Empty;
            uxModel.ModifiedBy = dto.ModifiedBy ?? string.Empty;

            return uxModel;
        }
        public static DSIWireSpecificationGrpc ToGrpcDto(this DsiWireSpecificationUxModel uxModel)
        {
            if (uxModel == null)
            {
                throw new ArgumentNullException(nameof(uxModel));
            }

            DSIWireSpecificationGrpc dto = new DSIWireSpecificationGrpc();

            dto.Id = uxModel.Id;
            dto.WireName = uxModel.WireName; // Implicitly converts string to StringValue
            dto.Compositeoptionstring = uxModel.Compositeoptionstring;
            dto.WireType = uxModel.WireType;
            dto.Colour = uxModel.Colour;
            dto.CrossSectionalArea = uxModel.CrossSectionalArea; // Implicitly converts double to DoubleValue
            dto.Material = uxModel.Material;
            dto.UserModule = uxModel.UserModule;
            dto.MulticoreName = uxModel.MulticoreName;

            dto.End1NodeName = uxModel.End1NodeName;
            dto.End1Route = uxModel.End1Route;
            dto.End1Cavity = uxModel.End1Cavity;
            dto.End1MaterialCode = uxModel.End1MaterialCode;

            dto.End2NodeName = uxModel.End2NodeName;
            dto.End2Route = uxModel.End2Route;
            dto.End2Cavity = uxModel.End2Cavity;
            dto.End2MaterialCode = uxModel.End2MaterialCode;

            dto.IsIncludedOnBom = uxModel.IsIncludedOnBom; // Implicitly converts bool to BoolValue
            dto.IsIncludedOnChart = uxModel.IsIncludedOnChart;

            dto.WireTag = uxModel.WireTag;
            dto.WireNote = uxModel.WireNote;

            dto.WireLengthChangeType = uxModel.WireLengthChangeType;
            dto.WireLengthChangeValue = uxModel.WireLengthChangeValue;
            dto.AssemblyItemNumber = uxModel.AssemblyItemNumber;

            dto.MulticoreOption = uxModel.MulticoreOption;

            dto.UnmodifiedWireLength = uxModel.UnmodifiedWireLength;
            dto.ModifiedWireLength = uxModel.ModifiedWireLength;
            dto.CutbackAtEnd1 = uxModel.CutbackAtEnd1;
            dto.CutbackAtEnd2 = uxModel.CutbackAtEnd2;

            dto.PartNumber1 = uxModel.PartNumber1;
            dto.PartNumber2 = uxModel.PartNumber2;
            dto.PartNumber3 = uxModel.PartNumber3;

            dto.Signal = uxModel.Signal;
            dto.HarnessID = uxModel.HarnessID;

            // Handles systemic conversions to Google.Protobuf.WellKnownTypes.Timestamp
            dto.CreatedDate = Timestamp.FromDateTime(DateTime.SpecifyKind(uxModel.CreatedDate ?? DateTime.UtcNow, DateTimeKind.Utc));
            dto.ModifiedDate = Timestamp.FromDateTime(DateTime.SpecifyKind(uxModel.ModifiedDate ?? DateTime.UtcNow, DateTimeKind.Utc));

            dto.CreatedBy = uxModel.CreatedBy;
            dto.ModifiedBy = uxModel.ModifiedBy;

            return dto;
        }
        #endregion
    }
}
