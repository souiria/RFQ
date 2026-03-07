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
        public static Rfq.RfqNprRequestGrpc ToRfqNprRquestGrpcAccess(this RfqNprRequestGrpc rfqNprRequest)
        {
            Rfq.RfqNprRequestGrpc accessData = new Rfq.RfqNprRequestGrpc();
            accessData.Id = rfqNprRequest.Id;
            accessData.Reason = rfqNprRequest.Reason;
            accessData.Customer = rfqNprRequest.Customer;
            accessData.PlatformName = rfqNprRequest.PlatformName;
            accessData.ProgramName = rfqNprRequest.ProgramName;
            accessData.Project = rfqNprRequest.Project;
            accessData.MaterialType = rfqNprRequest.MaterialType;
            accessData.SuggestedSewsEManufacturingSite = rfqNprRequest.SuggestedSewsEManufacturingSite;
            accessData.CustomerPartNumber = rfqNprRequest.CustomerPartNumber;
            accessData.SupplierPartNumber = rfqNprRequest.SupplierPartNumber;
            accessData.SumitomoNumber = rfqNprRequest.SumitomoNumber;
            accessData.MaterialDescription = rfqNprRequest.MaterialDescription;
            accessData.UnitOfMeasure = rfqNprRequest.UnitOfMeasure;
            accessData.SupplierGroup = rfqNprRequest.SupplierGroup;
            accessData.QtyPerVehicle = rfqNprRequest.QtyPerVehicle;
            accessData.Quantity = rfqNprRequest.Quantity;
            accessData.RequiredDate = rfqNprRequest.RequiredDate;
            accessData.RaisedRemarks = rfqNprRequest.RaisedRemarks;
            accessData.IsCustomerNominatedSupplier = rfqNprRequest.IsCustomerNominatedSupplier;
            accessData.IsCustomerNominatedMaterial = rfqNprRequest.IsCustomerNominatedMaterial;
            accessData.SamplesRequired = rfqNprRequest.SamplesRequired;
            accessData.SampleSite = rfqNprRequest.SampleSite;
            accessData.SampleQuantity = rfqNprRequest.SampleQuantity;
            accessData.SampleRecipient = rfqNprRequest.SampleRecipient;
            accessData.SampleRequiredDate = rfqNprRequest.SampleRequiredDate;
            accessData.FreightAccount = rfqNprRequest.FreightAccount;
            accessData.AssociatedParts = rfqNprRequest.AssociatedParts;
            accessData.SuggestedManufacturer = rfqNprRequest.SuggestedManufacturer;
            accessData.CreatedAt = rfqNprRequest.CreatedAt;
            accessData.CreatedBy = rfqNprRequest.CreatedBy;
            accessData.ModifiedAt = rfqNprRequest.ModifiedAt;
            accessData.ModifiedBy = rfqNprRequest.ModifiedBy;
            accessData.SubmissionStatus = rfqNprRequest.SubmissionStatus;
            accessData.RemoteEndpointResponse = rfqNprRequest.RemoteEndpointResponse;
            accessData.SubmittedAt = rfqNprRequest.SubmittedAt;
            accessData.RfqNumber = rfqNprRequest.RfqNumber;
            accessData.IsActive = rfqNprRequest.IsActive;
            return accessData;
        }
        public static RfqNprRequestGrpc ToRfqNprRequest(this Rfq.RfqNprRequestGrpc accessData)
        {
            RfqNprRequestGrpc rfqNprRequest = new RfqNprRequestGrpc();
            rfqNprRequest.Id = accessData.Id;
            rfqNprRequest.Reason = accessData.Reason;
            rfqNprRequest.Customer = accessData.Customer;
            rfqNprRequest.PlatformName = accessData.PlatformName;
            rfqNprRequest.ProgramName = accessData.ProgramName;
            rfqNprRequest.Project = accessData.Project;
            rfqNprRequest.MaterialType = accessData.MaterialType;
            rfqNprRequest.SuggestedSewsEManufacturingSite = accessData.SuggestedSewsEManufacturingSite;
            rfqNprRequest.CustomerPartNumber = accessData.CustomerPartNumber;
            rfqNprRequest.SupplierPartNumber = accessData.SupplierPartNumber;
            rfqNprRequest.SumitomoNumber = accessData.SumitomoNumber;
            rfqNprRequest.MaterialDescription = accessData.MaterialDescription;
            rfqNprRequest.UnitOfMeasure = accessData.UnitOfMeasure;
            rfqNprRequest.SupplierGroup = accessData.SupplierGroup;
            rfqNprRequest.QtyPerVehicle = accessData.QtyPerVehicle;
            rfqNprRequest.Quantity = accessData.Quantity;
            rfqNprRequest.RequiredDate = accessData.RequiredDate;
            rfqNprRequest.RaisedRemarks = accessData.RaisedRemarks;
            rfqNprRequest.IsCustomerNominatedSupplier = accessData.IsCustomerNominatedSupplier;
            rfqNprRequest.IsCustomerNominatedMaterial = accessData.IsCustomerNominatedMaterial;
            rfqNprRequest.SamplesRequired = accessData.SamplesRequired;
            rfqNprRequest.SampleSite = accessData.SampleSite;
            rfqNprRequest.SampleQuantity = accessData.SampleQuantity;
            rfqNprRequest.SampleRecipient = accessData.SampleRecipient;
            rfqNprRequest.SampleRequiredDate = accessData.SampleRequiredDate;
            rfqNprRequest.FreightAccount = accessData.FreightAccount;
            rfqNprRequest.AssociatedParts = accessData.AssociatedParts;
            rfqNprRequest.SuggestedManufacturer = accessData.SuggestedManufacturer;
            rfqNprRequest.CreatedAt = accessData.CreatedAt;
            rfqNprRequest.CreatedBy = accessData.CreatedBy;
            rfqNprRequest.ModifiedAt = accessData.ModifiedAt;
            rfqNprRequest.ModifiedBy = accessData.ModifiedBy;
            rfqNprRequest.SubmissionStatus = accessData.SubmissionStatus;
            rfqNprRequest.RemoteEndpointResponse = accessData.RemoteEndpointResponse;
            rfqNprRequest.SubmittedAt = accessData.SubmittedAt;
            rfqNprRequest.RfqNumber = accessData.RfqNumber;
            rfqNprRequest.IsActive = accessData.IsActive;
            return rfqNprRequest;
        }
    }
}