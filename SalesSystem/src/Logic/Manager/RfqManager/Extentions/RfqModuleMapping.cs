namespace RfqModule.Extentions
{
    public static class RfqModuleMapping
    {
        public static CustomerGrpc ToCustomerGrpc(this Master.CustomerGrpc masterCustomer)
        {
            CustomerGrpc customer = new CustomerGrpc();
            customer.Id = masterCustomer.Id;
            customer.CustomerBusinessGroupCode = masterCustomer.CustomerBusinessGroupCode;
            customer.CustomerBusinessGroupName = masterCustomer.CustomerBusinessGroupName;
            customer.SEWSEBusinessTeam = masterCustomer.SEWSEBusinessTeam;
            customer.IsActive = masterCustomer.IsActive;
            return customer;
        }

        public static CustomerLocationGrpc ToCustomerLocation(this Master.CustomerLocationGrpc masterLocationGrpc)
        {
            CustomerLocationGrpc location = new CustomerLocationGrpc();
            location.Id = masterLocationGrpc.Id;
            location.CustomerCode = masterLocationGrpc.CustomerCode;
            location.CustomerBusinessHierarchyGuid = masterLocationGrpc.CustomerBusinessHierarchyGuid;
            location.CustomerName = masterLocationGrpc.CustomerName;
            location.IsActive = masterLocationGrpc.IsActive;
            return location;
        }

        public static ProjectGrpc ToProject(this ProjectGrpc masterProjectGrpc)
        {
            ProjectGrpc projectAssociation = new ProjectGrpc();
            projectAssociation.Id = masterProjectGrpc.Id;
            projectAssociation.ProjectCode = masterProjectGrpc.ProjectCode;
            projectAssociation.ProjectName = masterProjectGrpc.ProjectName;
            projectAssociation.CustomerProjectCode = masterProjectGrpc.CustomerProjectCode;
            projectAssociation.ProjectDescription = masterProjectGrpc.ProjectDescription;
            projectAssociation.ProjectAnnualVolume = masterProjectGrpc.ProjectAnnualVolume;
            projectAssociation.ProgramHierarchyGuid = masterProjectGrpc.ProgramHierarchyGuid;
            projectAssociation.IsActive = masterProjectGrpc.IsActive;
            return projectAssociation;
        }

        public static VehicleGrpc ToVehicle(this Master.VehicleGrpc masterVehicleGrpc)
        {
            VehicleGrpc vehicle = new VehicleGrpc();
            vehicle.Id = masterVehicleGrpc.Id;
            vehicle.VehicleName = masterVehicleGrpc.VehicleName;
            vehicle.VehicleDisplay = masterVehicleGrpc.VehicleDisplay;
            vehicle.IsActive = masterVehicleGrpc.IsActive;
            return vehicle;
        }

        public static CustomerProjectAssociationGrpc ToCustomerProjectAssociation(this Master.CustomerProjectAssociationGrpc masterCustomerProjectAssociationGrpc)
        {
            CustomerProjectAssociationGrpc customerProjectAssociation = new CustomerProjectAssociationGrpc();
            customerProjectAssociation.Id = masterCustomerProjectAssociationGrpc.Id;
            customerProjectAssociation.CustomerLocationGuid = masterCustomerProjectAssociationGrpc.CustomerLocationGuid;
            customerProjectAssociation.ProjectGuid = masterCustomerProjectAssociationGrpc.ProjectGuid;
            customerProjectAssociation.IsActive = masterCustomerProjectAssociationGrpc.IsActive;
            return customerProjectAssociation;
        }

        public static RfqReasonGrpc ToReason(this Rfq.RfqReasonGrpc rfqRfqReasonGrpc)
        {
            RfqReasonGrpc reason = new RfqReasonGrpc();
            reason.RowId = rfqRfqReasonGrpc.RowId;
            reason.RfqReasonTitle = rfqRfqReasonGrpc.ReasonTitle;
            return reason;
        }

        public static RfqProject ToRfqProject(this RfqProjectGrpc rfqProjectGrpc)
        {
            RfqProject project = new RfqProject();
            project.RowId = rfqProjectGrpc.RowId;
            project.RfqNumber = rfqProjectGrpc.RfqNumber;
            project.CustomerBusinessUnitGuid = rfqProjectGrpc.CustomerBusinessUnitGuid;
            project.CustomerLocationGuid = rfqProjectGrpc.CustomerLocationGuid;
            project.ProjectGuid = rfqProjectGrpc.ProjectGuid;
            project.RfqReasonId = rfqProjectGrpc.RfqReasonId ??0;
            project.RfqResponseDeadline = rfqProjectGrpc.RfqResponseDeadline;
            project.CarModelGuid = rfqProjectGrpc.CarModelGuid;
            project.VehicleVolume = rfqProjectGrpc.VehicleVolume ??0;
            project.CreatedDate = rfqProjectGrpc.CreatedDate;
            project.RfqReasonName = rfqProjectGrpc.RfqReasonName;
            project.IsActive = rfqProjectGrpc.IsActive; 
            project.ProjectName = rfqProjectGrpc.ProjectName;
            project.CustomerBusinessGroupCode= rfqProjectGrpc.CustomerBusinessGroupCode;
            project.CustomerLocationName = rfqProjectGrpc.CustomerLocationName;
            project.CarModelName = rfqProjectGrpc.CarModelName;
            return project;
        }
        public static RfqDrawingPartNumber ToRfqDrawingPartNumber(this RfqDrawingPartNumbersGrpc rfqPartGrpc)
        {
            RfqDrawingPartNumber part = new RfqDrawingPartNumber();
            part.RowId = rfqPartGrpc.RowId;
            part.RfqId = rfqPartGrpc.RfqId;
            part.OriginalPartNumber = rfqPartGrpc.OriginalPartNumber;
            part.OriginalPartNumberPrice = rfqPartGrpc.OriginalPartNumberPrice ??0;
            part.SwappedPartNumber = rfqPartGrpc.SwappedPartNumber;
            part.SwappedPartNumberPrice = rfqPartGrpc.SwappedPartNumberPrice??0;
            part.PriceSource = rfqPartGrpc.PriceSource;
            part.IsExactMatch = rfqPartGrpc.IsExactMatch ?? false;
            part.IsSwapped = rfqPartGrpc.IsSwapped ?? false;
            part.Comments = rfqPartGrpc.Comments;
            part.SumitomoPartNumber = rfqPartGrpc.SumitomoPartNumber;
            return part;
        }

        public static RfqAlternativePartsGrpc ToRfqAlternativeParts(this AlternativePartsGrpc alternativeParts)
        {
            RfqAlternativePartsGrpc part = new RfqAlternativePartsGrpc();
            part.SumitomoNumber = alternativeParts.SumitomoNumber;
            part.SumitomoDescription = alternativeParts.SumitomoDescription;
            part.MainSupplier = alternativeParts.MainSupplier;
            part.SupplierName = alternativeParts.SupplierName;
            part.SupplierNumber = alternativeParts.SupplierNumber;
            part.Price = alternativeParts.Price;
            part.CurrencyCode = alternativeParts.CurrencyCode;
            part.UnitOfMeasure = alternativeParts.UnitOfMeasure;
            part.PartGroup = alternativeParts.PartGroup;
            part.GroupDescription = alternativeParts.GroupDescription;
            part.Class1 = alternativeParts.Class1;
            part.Class1Name = alternativeParts.Class1Name;
            part.Class2 = alternativeParts.Class2;
            part.Class2Name = alternativeParts.Class2Name;
            part.ColourCode = alternativeParts.ColourCode;
            part.ColorName = alternativeParts.ColorName;
            part.MaterialGroup = alternativeParts.MaterialGroup;
            part.Expr1 = alternativeParts.Expr1;
            part.MaterialType = alternativeParts.MaterialType;
            part.TypeDescription = alternativeParts.TypeDescription;
            part.CategoryCode = alternativeParts.CategoryCode;
            part.DetailedCategoryCode = alternativeParts.DetailedCategoryCode;
            part.Description = alternativeParts.Description;
            part.OldPartClass = alternativeParts.OldPartClass;
            part.OldMaterial = alternativeParts.OldMaterial;
            part.ClassDetailGroupCode = alternativeParts.ClassDetailGroupCode;
            part.ClassDetailId = alternativeParts.ClassDetailId;
            part.MaterialGroupId = alternativeParts.MaterialGroupId;
            part.MaterialTypeId = alternativeParts.MaterialTypeId;
            part.ColorCode = alternativeParts.ColorCode;
            part.NumberOfCavity = alternativeParts.NumberOfCavity;
            part.InsideDiameter = alternativeParts.InsideDiameter;
            part.WallThickness = alternativeParts.WallThickness;
            part.Length = alternativeParts.Length;
            part.WidthOrOutsideDiameter = alternativeParts.WidthOrOutsideDiameter;
            part.HoleDiameter = alternativeParts.HoleDiameter;
            part.ShrinkRateLength = alternativeParts.ShrinkRateLength;
            part.NumberOfTapingSpots = alternativeParts.NumberOfTapingSpots;
            part.MassOrWeight = alternativeParts.MassOrWeight;
            part.Quantity = alternativeParts.Quantity;
            part.UoM = alternativeParts.UoM;
            part.Group1 = alternativeParts.Group1;
            part.Group2 = alternativeParts.Group2;
            part.Group3 = alternativeParts.Group3;
            part.Group4 = alternativeParts.Group4;
            part.Group5 = alternativeParts.Group5;
            part.Group6 = alternativeParts.Group6;
            part.Group7 = alternativeParts.Group7;
            part.Group8 = alternativeParts.Group8;
            part.CustomerId = alternativeParts.CustomerId;
            part.CustomerCode = alternativeParts.CustomerCode;
            part.MassOrWeight2 = alternativeParts.MassOrWeight2;
            part.L1 = alternativeParts.L1;
            part.L2 = alternativeParts.L2;
            part.L3 = alternativeParts.L3;
            part.PitchWidth = alternativeParts.PitchWidth;
            part.Tilt = alternativeParts.Tilt;
            part.Grease = alternativeParts.Grease;
            part.CategoryCode2 = alternativeParts.CategoryCode2;
            return part;
        }
        //public static Rfq.RfqNprRequestGrpc ToRfqNprRquestGrpcAccess(this RfqNprRequestGrpc rfqNprRequest)
        //{
        //    Rfq.RfqNprRequestGrpc accessData = new Rfq.RfqNprRequestGrpc();
        //    accessData.Id = rfqNprRequest.Id;
        //    accessData.Reason = rfqNprRequest.Reason;
        //    accessData.Customer = rfqNprRequest.Customer;
        //    accessData.PlatformName = rfqNprRequest.PlatformName;
        //    accessData.ProgramName = rfqNprRequest.ProgramName;
        //    accessData.Project = rfqNprRequest.Project;
        //    accessData.MaterialType = rfqNprRequest.MaterialType;
        //    accessData.SuggestedSewsEManufacturingSite = rfqNprRequest.SuggestedSewsEManufacturingSite;
        //    accessData.CustomerPartNumber = rfqNprRequest.CustomerPartNumber;
        //    accessData.SupplierPartNumber = rfqNprRequest.SupplierPartNumber;
        //    accessData.SumitomoNumber = rfqNprRequest.SumitomoNumber;
        //    accessData.MaterialDescription = rfqNprRequest.MaterialDescription;
        //    accessData.UnitOfMeasure = rfqNprRequest.UnitOfMeasure;
        //    accessData.SupplierGroup = rfqNprRequest.SupplierGroup;
        //    accessData.QtyPerVehicle = rfqNprRequest.QtyPerVehicle;
        //    accessData.Quantity = rfqNprRequest.Quantity;
        //    accessData.RequiredDate = rfqNprRequest.RequiredDate;
        //    accessData.RaisedRemarks = rfqNprRequest.RaisedRemarks;
        //    accessData.IsCustomerNominatedSupplier = rfqNprRequest.IsCustomerNominatedSupplier;
        //    accessData.IsCustomerNominatedMaterial = rfqNprRequest.IsCustomerNominatedMaterial;
        //    accessData.SamplesRequired = rfqNprRequest.SamplesRequired;
        //    accessData.SampleSite = rfqNprRequest.SampleSite;
        //    accessData.SampleQuantity = rfqNprRequest.SampleQuantity;
        //    accessData.SampleRecipient = rfqNprRequest.SampleRecipient;
        //    accessData.SampleRequiredDate = rfqNprRequest.SampleRequiredDate;
        //    accessData.FreightAccount = rfqNprRequest.FreightAccount;
        //    accessData.AssociatedParts = rfqNprRequest.AssociatedParts;
        //    accessData.SuggestedManufacturer = rfqNprRequest.SuggestedManufacturer;
        //    accessData.CreatedAt = rfqNprRequest.CreatedAt;
        //    accessData.CreatedBy = rfqNprRequest.CreatedBy;
        //    accessData.ModifiedAt = rfqNprRequest.ModifiedAt;
        //    accessData.ModifiedBy = rfqNprRequest.ModifiedBy;
        //    accessData.SubmissionStatus = rfqNprRequest.SubmissionStatus;
        //    accessData.RemoteEndpointResponse = rfqNprRequest.RemoteEndpointResponse;
        //    accessData.SubmittedAt = rfqNprRequest.SubmittedAt;
        //    accessData.RfqNumber = rfqNprRequest.RfqNumber;
        //    return accessData;
        //}
        //public static RfqNprRequestGrpc ToRfqNprRequest(this Rfq.RfqNprRequestGrpc accessData)
        //{
        //    RfqNprRequestGrpc rfqNprRequest = new RfqNprRequestGrpc();
        //    rfqNprRequest.Id = accessData.Id;
        //    rfqNprRequest.Reason = accessData.Reason;
        //    rfqNprRequest.Customer = accessData.Customer;
        //    rfqNprRequest.PlatformName = accessData.PlatformName;
        //    rfqNprRequest.ProgramName = accessData.ProgramName;
        //    rfqNprRequest.Project = accessData.Project;
        //    rfqNprRequest.MaterialType = accessData.MaterialType;
        //    rfqNprRequest.SuggestedSewsEManufacturingSite = accessData.SuggestedSewsEManufacturingSite;
        //    rfqNprRequest.CustomerPartNumber = accessData.CustomerPartNumber;
        //    rfqNprRequest.SupplierPartNumber = accessData.SupplierPartNumber;
        //    rfqNprRequest.SumitomoNumber = accessData.SumitomoNumber;
        //    rfqNprRequest.MaterialDescription = accessData.MaterialDescription;
        //    rfqNprRequest.UnitOfMeasure = accessData.UnitOfMeasure;
        //    rfqNprRequest.SupplierGroup = accessData.SupplierGroup;
        //    rfqNprRequest.QtyPerVehicle = accessData.QtyPerVehicle;
        //    rfqNprRequest.Quantity = accessData.Quantity;
        //    rfqNprRequest.RequiredDate = accessData.RequiredDate;
        //    rfqNprRequest.RaisedRemarks = accessData.RaisedRemarks;
        //    rfqNprRequest.IsCustomerNominatedSupplier = accessData.IsCustomerNominatedSupplier;
        //    rfqNprRequest.IsCustomerNominatedMaterial = accessData.IsCustomerNominatedMaterial;
        //    rfqNprRequest.SamplesRequired = accessData.SamplesRequired;
        //    rfqNprRequest.SampleSite = accessData.SampleSite;
        //    rfqNprRequest.SampleQuantity = accessData.SampleQuantity;
        //    rfqNprRequest.SampleRecipient = accessData.SampleRecipient;
        //    rfqNprRequest.SampleRequiredDate = accessData.SampleRequiredDate;
        //    rfqNprRequest.FreightAccount = accessData.FreightAccount;
        //    rfqNprRequest.AssociatedParts = accessData.AssociatedParts;
        //    rfqNprRequest.SuggestedManufacturer = accessData.SuggestedManufacturer;
        //    rfqNprRequest.CreatedAt = accessData.CreatedAt;
        //    rfqNprRequest.CreatedBy = accessData.CreatedBy;
        //    rfqNprRequest.ModifiedAt = accessData.ModifiedAt;
        //    rfqNprRequest.ModifiedBy = accessData.ModifiedBy;
        //    rfqNprRequest.SubmissionStatus = accessData.SubmissionStatus;
        //    rfqNprRequest.RemoteEndpointResponse = accessData.RemoteEndpointResponse;
        //    rfqNprRequest.SubmittedAt = accessData.SubmittedAt;
        //    rfqNprRequest.RfqNumber = accessData.RfqNumber;
        //    return rfqNprRequest;
        //}
        public static Rfq.RfqNprRequestGrpc ToRfqNprRequestGrpcAccess(this RfqNprRequestGrpc rfqNprRequest, int? index = null)
        {
            Rfq.RfqNprRequestGrpc accessData = new Rfq.RfqNprRequestGrpc();
            accessData.Id = rfqNprRequest.Id;
            accessData.ReasonDescription = rfqNprRequest.ReasonDescription;
            accessData.CustomerCode = rfqNprRequest.CustomerCode;
            accessData.PlatformName = rfqNprRequest.PlatformName;
            accessData.ProgramName = rfqNprRequest.ProgramName;
            accessData.ProjectCode = rfqNprRequest.ProjectCode;
            accessData.ManufacturingSite = rfqNprRequest.ManufacturingSite;
            accessData.CustomerPartNumber = rfqNprRequest.CustomerPartNumber;
            accessData.SupplierPartNumber = rfqNprRequest.SupplierPartNumber;
            accessData.MaterialNumber = rfqNprRequest.MaterialNumber;
            accessData.MaterialDescription = rfqNprRequest.MaterialDescription;
            accessData.SEWSEUnitOfMeasurement = rfqNprRequest.SEWSEUnitOfMeasurement;
            accessData.SupplierGroup = rfqNprRequest.SupplierGroup;
            accessData.QtyPerVehicle = rfqNprRequest.QtyPerVehicle;
            accessData.VehicleTotalQuantity = rfqNprRequest.VehicleTotalQuantity;
            accessData.DeadlineDate = rfqNprRequest.DeadlineDate;
            accessData.NPRRaisedRemarks = rfqNprRequest.NPRRaisedRemarks;
            accessData.IsCustomerNominatedSupplier = rfqNprRequest.IsCustomerNominatedSupplier;
            accessData.IsCustomerNominatedMaterial = rfqNprRequest.IsCustomerNominatedMaterial;
            foreach (RfqNprRequestSampleSiteDataGrpc siteGrpc in rfqNprRequest.SampleSiteDetails)
            {
                Rfq.RfqNprRequestSampleSiteDataGrpc rfqNprRequestSampleSiteDataGrpc = siteGrpc.ToSampleSiteAccessGrpc();
                accessData.SampleSiteDetails.Add(rfqNprRequestSampleSiteDataGrpc);
            }

            accessData.AssociatedParts = rfqNprRequest.AssociatedParts;
            accessData.SuggestedManufacturerGroup = rfqNprRequest.SuggestedManufacturerGroup;
            accessData.CreatedAt = rfqNprRequest.CreatedAt;
            accessData.CreatedBy = rfqNprRequest.CreatedBy;
            accessData.ModifiedAt = rfqNprRequest.ModifiedAt;
            accessData.ModifiedBy = rfqNprRequest.ModifiedBy;
            accessData.SubmissionStatus = rfqNprRequest.SubmissionStatus;
            accessData.RemoteEndpointResponse = rfqNprRequest.RemoteEndpointResponse;
            accessData.SubmittedAt = rfqNprRequest.SubmittedAt;
            accessData.CustomerRfqNo = rfqNprRequest.CustomerRfqNo;
            accessData.IsActive = rfqNprRequest.IsActive;
            accessData.RequestID = rfqNprRequest.RequestID;
            accessData.OriginatorName = rfqNprRequest.OriginatorName;
            accessData.SupplierDetailComments = rfqNprRequest.SupplierDetailComments;
            accessData.NPRUploadSeqNo = index ?? rfqNprRequest.NPRUploadSeqNo;
            return accessData;
        }
        public static RfqNprRequestGrpc ToRfqNprRequest(this Rfq.RfqNprRequestGrpc accessData)
        {
            RfqNprRequestGrpc rfqNprRequest = new RfqNprRequestGrpc();
            rfqNprRequest.Id = accessData.Id;
            rfqNprRequest.ReasonDescription = accessData.ReasonDescription;
            rfqNprRequest.CustomerCode = accessData.CustomerCode;
            rfqNprRequest.PlatformName = accessData.PlatformName;
            rfqNprRequest.ProgramName = accessData.ProgramName;
            rfqNprRequest.ProjectCode = accessData.ProjectCode;
            rfqNprRequest.ManufacturingSite = accessData.ManufacturingSite;
            rfqNprRequest.CustomerPartNumber = accessData.CustomerPartNumber;
            rfqNprRequest.SupplierPartNumber = accessData.SupplierPartNumber;
            rfqNprRequest.MaterialNumber = accessData.MaterialNumber;
            rfqNprRequest.MaterialDescription = accessData.MaterialDescription;
            rfqNprRequest.SEWSEUnitOfMeasurement = accessData.SEWSEUnitOfMeasurement;
            rfqNprRequest.SupplierGroup = accessData.SupplierGroup;
            rfqNprRequest.QtyPerVehicle = accessData.QtyPerVehicle;
            rfqNprRequest.VehicleTotalQuantity = accessData.VehicleTotalQuantity;
            rfqNprRequest.DeadlineDate = accessData.DeadlineDate;
            rfqNprRequest.NPRRaisedRemarks = accessData.NPRRaisedRemarks;
            rfqNprRequest.IsCustomerNominatedSupplier = accessData.IsCustomerNominatedSupplier;
            rfqNprRequest.IsCustomerNominatedMaterial = accessData.IsCustomerNominatedMaterial;
            foreach (Rfq.RfqNprRequestSampleSiteDataGrpc siteGrpc in accessData.SampleSiteDetails)
            {
                RfqNprRequestSampleSiteDataGrpc rfqNprRequestSampleSiteDataGrpc = siteGrpc.ToSampleSiteGrpc();
                rfqNprRequest.SampleSiteDetails.Add(rfqNprRequestSampleSiteDataGrpc);
            }

            rfqNprRequest.AssociatedParts = accessData.AssociatedParts;
            rfqNprRequest.SuggestedManufacturerGroup = accessData.SuggestedManufacturerGroup;
            rfqNprRequest.CreatedAt = accessData.CreatedAt;
            rfqNprRequest.CreatedBy = accessData.CreatedBy;
            rfqNprRequest.ModifiedAt = accessData.ModifiedAt;
            rfqNprRequest.ModifiedBy = accessData.ModifiedBy;
            rfqNprRequest.SubmissionStatus = accessData.SubmissionStatus;
            rfqNprRequest.RemoteEndpointResponse = accessData.RemoteEndpointResponse;
            rfqNprRequest.SubmittedAt = accessData.SubmittedAt;
            rfqNprRequest.CustomerRfqNo = accessData.CustomerRfqNo;
            rfqNprRequest.IsActive = accessData.IsActive;
            rfqNprRequest.RequestID = accessData.RequestID;
            rfqNprRequest.OriginatorName = accessData.OriginatorName;
            rfqNprRequest.SupplierDetailComments = accessData.SupplierDetailComments;
            rfqNprRequest.NPRUploadSeqNo = accessData.NPRUploadSeqNo;
            return rfqNprRequest;
        }

        public static NPR.NprApiDataGrpc ToNprApiAccessData(this NprApiDataGrpc nprApiData)
        {
            NPR.NprApiDataGrpc apiData = new NPR.NprApiDataGrpc();
            apiData.Id = nprApiData.RfqNprRequest.Id;
            apiData.RfqNprRequestId = nprApiData.RfqNprRequest.Id;
            apiData.CustomerRfqNo = nprApiData.RfqNprRequest.CustomerRfqNo;
            apiData.CustomerCode = nprApiData.RfqNprRequest.CustomerCode;
            apiData.RequestID = nprApiData.RfqNprRequest.RequestID;
            apiData.OriginatorName = nprApiData.RfqNprRequest.OriginatorName;
            apiData.DeadlineDate = nprApiData.RfqNprRequest.DeadlineDate;
            apiData.ReasonDescription = nprApiData.RfqNprRequest.ReasonDescription;
            apiData.MaterialNumber = nprApiData.RfqNprRequest.MaterialNumber;
            apiData.MaterialDescription = nprApiData.RfqNprRequest.MaterialDescription;
            apiData.CustomerPartNumber = nprApiData.RfqNprRequest.CustomerPartNumber;
            apiData.SupplierPartNumber = nprApiData.RfqNprRequest.SupplierPartNumber;
            apiData.BOMUnitOfMeasurement = nprApiData.RfqNprRequest.SEWSEUnitOfMeasurement;
            apiData.SupplierGroup = nprApiData.RfqNprRequest.SupplierGroup;
            apiData.SupplierDetailComments = nprApiData.RfqNprRequest.SupplierDetailComments;
            apiData.ProjectCode = nprApiData.RfqNprRequest.ProjectCode;
            apiData.QtyPerVehicle = nprApiData.RfqNprRequest.QtyPerVehicle;
            apiData.IsSampleDataRequired = nprApiData.RfqNprRequest.IsSampleDataRequired;

            // Map SampleSiteDetails from RfqNprRequestSampleSiteDataGrpc to NPR.SampleSiteDetailsGrpc
            foreach (RfqNprRequestSampleSiteDataGrpc siteGrpc in nprApiData.RfqNprRequest.SampleSiteDetails)
            {
                SampleSiteDetailsGrpc sampleSite = new SampleSiteDetailsGrpc();
                sampleSite.BusinessUnitCode = siteGrpc.BusinessUnitCode;
                sampleSite.SampleQty = siteGrpc.SampleQty;
                sampleSite.SendSampleContactPersonName = siteGrpc.SendSampleContactPersonName;
                sampleSite.RequiredDate = siteGrpc.RequiredDate;
                sampleSite.FreightAccount = siteGrpc.FreightAccount;
                apiData.SampleSiteDetails.Add(sampleSite);
            }

            apiData.NPRRaisedRemarks = nprApiData.RfqNprRequest.NPRRaisedRemarks;
            apiData.ManufacturingSite = nprApiData.RfqNprRequest.ManufacturingSite;
            apiData.IsCustomerNominatedSupplier = nprApiData.RfqNprRequest.IsCustomerNominatedSupplier;
            apiData.IsCustomerNominatedMaterial = nprApiData.RfqNprRequest.IsCustomerNominatedMaterial;
            apiData.SuggestedManufacturerGroup = nprApiData.RfqNprRequest.SuggestedManufacturerGroup;
            apiData.AssociatedParts = nprApiData.RfqNprRequest.AssociatedParts;
            apiData.NPRUploadSeqNo = nprApiData.RfqNprRequest.NPRUploadSeqNo;
            return apiData;
        }
        public static NprApiDataGrpc ToNprApiData(this NPR.NprApiDataGrpc nprAccessData)
        {
            NprApiDataGrpc apiData = new NprApiDataGrpc();
            apiData.NprId = nprAccessData.Id;

            RfqNprRequestGrpc rfqNprRequestGrpc = new RfqNprRequestGrpc();
            rfqNprRequestGrpc.Id = nprAccessData.RfqNprRequestId;
            rfqNprRequestGrpc.CustomerRfqNo = nprAccessData.CustomerRfqNo;
            rfqNprRequestGrpc.CustomerCode = nprAccessData.CustomerCode;
            rfqNprRequestGrpc.RequestID = nprAccessData.RequestID;
            rfqNprRequestGrpc.OriginatorName = nprAccessData.OriginatorName;
            rfqNprRequestGrpc.DeadlineDate = nprAccessData.DeadlineDate;
            rfqNprRequestGrpc.ReasonDescription = nprAccessData.ReasonDescription;
            rfqNprRequestGrpc.MaterialNumber = nprAccessData.MaterialNumber;
            rfqNprRequestGrpc.MaterialDescription = nprAccessData.MaterialDescription;
            rfqNprRequestGrpc.CustomerPartNumber = nprAccessData.CustomerPartNumber;
            rfqNprRequestGrpc.SupplierPartNumber = nprAccessData.SupplierPartNumber;
            rfqNprRequestGrpc.SEWSEUnitOfMeasurement = nprAccessData.BOMUnitOfMeasurement;
            rfqNprRequestGrpc.SupplierGroup = nprAccessData.SupplierGroup;
            rfqNprRequestGrpc.SupplierDetailComments = nprAccessData.SupplierDetailComments;
            rfqNprRequestGrpc.ProjectCode = nprAccessData.ProjectCode;
            rfqNprRequestGrpc.IsSampleDataRequired = nprAccessData.IsSampleDataRequired;

            // Map SampleSiteDetails from NPR.SampleSiteDetailsGrpc to RfqNprRequestSampleSiteDataGrpc
            foreach (SampleSiteDetailsGrpc siteGrpc in nprAccessData.SampleSiteDetails)
            {
                RfqNprRequestSampleSiteDataGrpc sampleSite = new RfqNprRequestSampleSiteDataGrpc();
                sampleSite.BusinessUnitCode = siteGrpc.BusinessUnitCode;
                sampleSite.SampleQty = siteGrpc.SampleQty;
                sampleSite.SendSampleContactPersonName = siteGrpc.SendSampleContactPersonName;
                sampleSite.RequiredDate = siteGrpc.RequiredDate;
                sampleSite.FreightAccount = siteGrpc.FreightAccount;
                rfqNprRequestGrpc.SampleSiteDetails.Add(sampleSite);
            }

            rfqNprRequestGrpc.NPRRaisedRemarks = nprAccessData.NPRRaisedRemarks;
            rfqNprRequestGrpc.ManufacturingSite = nprAccessData.ManufacturingSite;
            rfqNprRequestGrpc.IsCustomerNominatedSupplier = nprAccessData.IsCustomerNominatedSupplier;
            rfqNprRequestGrpc.IsCustomerNominatedMaterial = nprAccessData.IsCustomerNominatedMaterial;
            rfqNprRequestGrpc.SuggestedManufacturerGroup = nprAccessData.SuggestedManufacturerGroup;
            rfqNprRequestGrpc.AssociatedParts = nprAccessData.AssociatedParts;
            rfqNprRequestGrpc.NPRUploadSeqNo = nprAccessData.NPRUploadSeqNo;

            apiData.RfqNprRequest = rfqNprRequestGrpc;
            return apiData;
        }

        public static Rfq.RfqNprRequestSampleSiteDataGrpc ToSampleSiteAccessGrpc(this RfqNprRequestSampleSiteDataGrpc model)
        {
            Rfq.RfqNprRequestSampleSiteDataGrpc grpc = new Rfq.RfqNprRequestSampleSiteDataGrpc();
            grpc.BusinessUnitCode = model.BusinessUnitCode;
            grpc.SampleQty = model.SampleQty;
            grpc.SendSampleContactPersonName = model.SendSampleContactPersonName;
            grpc.RequiredDate = model.RequiredDate;
            grpc.FreightAccount = model.FreightAccount;
            return grpc;
        }

        public static RfqNprRequestSampleSiteDataGrpc ToSampleSiteGrpc(this Rfq.RfqNprRequestSampleSiteDataGrpc model)
        {
            RfqNprRequestSampleSiteDataGrpc grpc = new RfqNprRequestSampleSiteDataGrpc();
            grpc.BusinessUnitCode = model.BusinessUnitCode;
            grpc.SampleQty = model.SampleQty;
            grpc.SendSampleContactPersonName = model.SendSampleContactPersonName;
            grpc.RequiredDate = model.RequiredDate;
            grpc.FreightAccount = model.FreightAccount;
            return grpc;
        }

        public static SupplierGrpc ToSupplierGrpc(this Master.SupplierGrpc supplier)
        {
            SupplierGrpc supplierGrpc = new SupplierGrpc();
            supplierGrpc.SupplierCode = supplier.SupplierCode;
            supplierGrpc.SupplierName = supplier.SupplierName;
            supplierGrpc.Address1 = supplier.Address1;
            supplierGrpc.Address2 = supplier.Address2;
            supplierGrpc.Address3 = supplier.Address3;
            supplierGrpc.City = supplier.City;
            supplierGrpc.Region = supplier.Region;
            supplierGrpc.ZipCode = supplier.ZipCode;
            supplierGrpc.CountryGuid = supplier.CountryGuid;
            supplierGrpc.SupplierTypeGuid = supplier.SupplierTypeGuid;
            supplierGrpc.SupplierGroupGuid = supplier.SupplierGroupGuid;
            supplierGrpc.SupplierIncoTermsGuid = supplier.SupplierIncoTermsGuid;
            supplierGrpc.SupplierCurrencyGuid = supplier.SupplierCurrencyGuid;
            supplierGrpc.SupplierBuyerGuid = supplier.SupplierBuyerGuid;
            supplierGrpc.SupplierDevelopmentTeamGuid = supplier.SupplierDevelopmentTeamGuid;
            supplierGrpc.PaymentTerms = supplier.PaymentTerms;
            supplierGrpc.EPOCommodityGroupGuid = supplier.EPOCommodityGroupGuid;
            supplierGrpc.POPriceEffectiveDateTypeGuid = supplier.POPriceEffectiveDateTypeGuid;
            supplierGrpc.SupplierApprovalStatusGuid = supplier.SupplierApprovalStatusGuid;
            supplierGrpc.IsActive = supplier.IsActive;
            supplierGrpc.Id = supplier.Id;
            supplierGrpc.CreatedDate = supplier.CreatedDate;
            supplierGrpc.ModifiedDate = supplier.ModifiedDate;
            supplierGrpc.CreatedBy = supplier.CreatedBy;
            supplierGrpc.ModifiedBy = supplier.ModifiedBy;
            supplierGrpc.SyncToCPD = supplier.SyncToCPD;
            supplierGrpc.DistributionCountryOfOriginGuid = supplier.DistributionCountryOfOriginGuid;
            supplierGrpc.IsEOLRequired = supplier.IsEOLRequired;
            return supplierGrpc;
        }

        public static SupplierGroupGrpc ToSupplierGroupGrpc(this Master.SupplierGroupGrpc supplierGroup)
        {
            SupplierGroupGrpc supplierGroupGrpc = new SupplierGroupGrpc();
            supplierGroupGrpc.SupplierGroupName = supplierGroup.SupplierGroupName;
            supplierGroupGrpc.SupplierApprovalStatusGuid = supplierGroup.SupplierApprovalStatusGuid;
            supplierGroupGrpc.SupplierPanelGuid = supplierGroup.SupplierPanelGuid;
            supplierGroupGrpc.IsActive = supplierGroup.IsActive;
            supplierGroupGrpc.Id = supplierGroup.Id;
            supplierGroupGrpc.CreatedDate = supplierGroup.CreatedDate;
            supplierGroupGrpc.ModifiedDate = supplierGroup.ModifiedDate;
            supplierGroupGrpc.CreatedBy = supplierGroup.CreatedBy;
            supplierGroupGrpc.ModifiedBy = supplierGroup.ModifiedBy;
            supplierGroupGrpc.SyncToCPD = supplierGroup.SyncToCPD;
            supplierGroupGrpc.IsEOLRequired = supplierGroup.IsEOLRequired;
            return supplierGroupGrpc;
        }
    }
}