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

            uxModel.DrawingPartNumberPrice = dto.OriginalPartNumberPrice != 0 ? Convert.ToDecimal(dto.OriginalPartNumberPrice) : null;
            uxModel.SwappedPartNumber = dto.SwappedPartNumber;
            uxModel.SwappedPartNumberPrice = dto.SwappedPartNumberPrice != 0 ? Convert.ToDecimal(dto.SwappedPartNumberPrice) : null;
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
            dto.OriginalPartNumberPrice = uxModel.DrawingPartNumberPrice.HasValue ? Convert.ToDouble(uxModel.DrawingPartNumberPrice.Value) : 0;
            dto.SwappedPartNumber = uxModel.SwappedPartNumber;
            dto.SwappedPartNumberPrice = uxModel.SwappedPartNumberPrice.HasValue ? Convert.ToDouble(uxModel.SwappedPartNumberPrice.Value) : 0;
            dto.PriceSource = uxModel.PriceSource;
            dto.IsExactMatch = uxModel.IsExactMatch ?? false;
            dto.IsSwapped = uxModel.IsSwapped ?? false;
            // dto.IsActive = uxModel.IsActive;
            if(!string.IsNullOrEmpty(uxModel.Comments) && uxModel.Comments.Contains("||<<<", StringComparison.OrdinalIgnoreCase))
            {
                dto.Comments = uxModel.Comments.Split("||<<<", StringSplitOptions.None)[0];
            }
            else
            {
                dto.Comments = uxModel.Comments;
            }

            return dto;
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
            nprRequest.VehicleTotalQuantity = 1;
            nprRequest.AssociatedParts = "";
            nprRequest.CustomerCode = rfqProject.CustomerBusinessUnit;
            nprRequest.CustomerPartNumber = partNumber.CustomerPartNumber;
            nprRequest.MaterialDescription = "";
            nprRequest.MaterialTypeDescription = "";
            nprRequest.MaterialNumber = "";
            nprRequest.PlatformName = "";
            nprRequest.ProgramName = "";
            nprRequest.ProjectCode = rfqProject.Project;
            nprRequest.NPRRaisedRemarks = "";
            nprRequest.ReasonDescription = rfqProject.RfqReason;
            nprRequest.SuggestedManufacturerGroup = "";
            nprRequest.ManufacturingSite = rfqProject.CustomerLocation;
            nprRequest.SupplierGroup = "";
            nprRequest.SupplierDetailComments = "";
            nprRequest.SupplierPartNumber = "";
            nprRequest.SEWSEUnitOfMeasurement = "";
            nprRequest.CustomerRfqNo = "";
            nprRequest.OriginatorName = "";
            // samples
            nprRequest.IsSampleDataRequired = false;

            nprRequest.UxStatus = UxObjectStatus.Created;

            return nprRequest;
        }
        // dto to/from ux conversion
        public static RfqNprRequestGrpc ToNprGrpc(this RfqNprRequestUxModel model)
        {
            RfqNprRequestGrpc nprGrpc = new RfqNprRequestGrpc();
            nprGrpc.Id = model.Id.ToString();
            nprGrpc.Reason = model.ReasonDescription;
            nprGrpc.Customer = model.CustomerCode;
            nprGrpc.PlatformName = model.PlatformName;
            nprGrpc.ProgramName = model.ProgramName;
            nprGrpc.Project = model.ProjectCode;
            nprGrpc.MaterialType = model.MaterialTypeDescription;
            nprGrpc.SuggestedSewsEManufacturingSite = model.ManufacturingSite;
            nprGrpc.CustomerPartNumber = model.CustomerPartNumber;
            nprGrpc.SupplierPartNumber = model.SupplierPartNumber;
            nprGrpc.SumitomoNumber = model.MaterialNumber;
            nprGrpc.MaterialDescription = model.MaterialDescription;
            nprGrpc.UnitOfMeasure = model.SEWSEUnitOfMeasurement;
            nprGrpc.SupplierGroup = model.SupplierGroup;
            nprGrpc.QtyPerVehicle = (int?)model.QtyPerVehicle;
            nprGrpc.Quantity = model.VehicleTotalQuantity;
            nprGrpc.RequiredDate = model.DeadlineDate?.ToUniversalTime().ToTimestamp();
            nprGrpc.RaisedRemarks = model.NPRRaisedRemarks;
            nprGrpc.IsCustomerNominatedSupplier = model.IsCustomerNominatedSupplier;
            nprGrpc.IsCustomerNominatedMaterial = model.IsCustomerNominatedMaterial;
            nprGrpc.SamplesRequired = model.IsSampleDataRequired;
            nprGrpc.SampleSite = model.SampleSiteDetails.Count > 0
                ? string.Join(",", model.SampleSiteDetails
                    .Where(s => s.UxStatus != UxObjectStatus.Deleted)
                    .Select(s => s.SendSampleContactPersonName))
                : "";
            nprGrpc.SampleQuantity = model.SampleSiteDetails.Count > 0
                ? model.SampleSiteDetails
                    .Where(s => s.UxStatus != UxObjectStatus.Deleted)
                    .FirstOrDefault()?.SampleQty
                : null;
            nprGrpc.SampleRecipient = model.SampleSiteDetails.Count > 0
                ? model.SampleSiteDetails
                    .Where(s => s.UxStatus != UxObjectStatus.Deleted)
                    .FirstOrDefault()?.SendSampleContactPersonName
                : "";
            nprGrpc.SampleRequiredDate = model.SampleSiteDetails.Count > 0
                ? model.SampleSiteDetails
                    .Where(s => s.UxStatus != UxObjectStatus.Deleted)
                    .FirstOrDefault()?.RequiredDate?.ToUniversalTime().ToTimestamp()
                : null;
            nprGrpc.FreightAccount = model.SampleSiteDetails.Count > 0
                ? model.SampleSiteDetails
                    .Where(s => s.UxStatus != UxObjectStatus.Deleted)
                    .FirstOrDefault()?.FreightAccount
                : "";
            nprGrpc.AssociatedParts = model.AssociatedParts;
            nprGrpc.SuggestedManufacturer = model.SuggestedManufacturerGroup;
            nprGrpc.CreatedAt = model.Created.ToUniversalTime().ToTimestamp();
            //nprGrpc.CreatedBy = model.CreatedBy.ToString();
            nprGrpc.ModifiedAt = model.Updated.ToUniversalTime().ToTimestamp();
            //nprGrpc.ModifiedBy = model.ModifiedBy.ToString();
            nprGrpc.SubmissionStatus = (int?)model.Status;
            //nprGrpc.RemoteEndpointResponse = model.RemoteEndpointResponse;
            //nprGrpc.SubmittedAt = model.SubmittedAt?.ToUniversalTime().ToTimestamp();
            nprGrpc.RfqNumber = model.CustomerRfqNo;

            nprGrpc.IsActive = model.UxStatus != UxObjectStatus.Deleted;

            return nprGrpc;
        }
        public static RfqNprRequestUxModel ToNprUx(this RfqNprRequestGrpc grpc)
        {
            RfqNprRequestUxModel model = new RfqNprRequestUxModel();
            model.Id = Guid.Parse(grpc.Id);
            model.ReasonDescription = grpc.Reason;
            model.CustomerCode = grpc.Customer;
            model.PlatformName = grpc.PlatformName;
            model.ProgramName = grpc.ProgramName;
            model.ProjectCode = grpc.Project;
            model.MaterialTypeDescription = grpc.MaterialType;
            model.ManufacturingSite = grpc.SuggestedSewsEManufacturingSite;
            model.CustomerPartNumber = grpc.CustomerPartNumber;
            model.SupplierPartNumber = grpc.SupplierPartNumber;
            model.MaterialNumber = grpc.SumitomoNumber;
            model.MaterialDescription = grpc.MaterialDescription;
            model.SEWSEUnitOfMeasurement = grpc.UnitOfMeasure;
            model.SupplierGroup = grpc.SupplierGroup;
            model.QtyPerVehicle = grpc.QtyPerVehicle.HasValue ? (decimal)grpc.QtyPerVehicle.Value : null;
            model.VehicleTotalQuantity = grpc.Quantity;
            model.DeadlineDate = grpc.RequiredDate?.ToDateTime();
            model.NPRRaisedRemarks = grpc.RaisedRemarks;
            model.IsCustomerNominatedSupplier = grpc.IsCustomerNominatedSupplier ?? false;
            model.IsCustomerNominatedMaterial = grpc.IsCustomerNominatedMaterial ?? false;
            model.IsSampleDataRequired = grpc.SamplesRequired ?? false;
            // Map flat gRPC sample fields into the first SampleSiteDetails entry
            if (model.IsSampleDataRequired)
            {
                RfqNprRequestSampleSiteDataUxModel sampleSite = new RfqNprRequestSampleSiteDataUxModel();
                sampleSite.SampleQty = grpc.SampleQuantity;
                sampleSite.SendSampleContactPersonName = grpc.SampleRecipient;
                sampleSite.RequiredDate = grpc.SampleRequiredDate is null ? null : grpc.SampleRequiredDate.ToDateTime();
                sampleSite.FreightAccount = grpc.FreightAccount;
                sampleSite.UxStatus = UxObjectStatus.Read;
                model.SampleSiteDetails.Add(sampleSite);
            }
            model.AssociatedParts = grpc.AssociatedParts;
            model.SuggestedManufacturerGroup = grpc.SuggestedManufacturer;
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
            model.CustomerRfqNo = grpc.RfqNumber;

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
    }
}
