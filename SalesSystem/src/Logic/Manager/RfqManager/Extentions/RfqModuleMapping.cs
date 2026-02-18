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

        public static RfqProject ToRfqProject(this Rfq.RfqProjectGrpc rfqProjectGrpc)
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
        // --------------------------------------------------------------------
        // Manager (RfqModule) --> NPR : List wrapper
        // --------------------------------------------------------------------
        public static NPR.ListRfqNprRequestSetGrpc ToNpr(NPRListRfqNprRequestSetGrpc from)
        {
            NPR.ListRfqNprRequestSetGrpc to = new NPR.ListRfqNprRequestSetGrpc();

            if (from != null && from.Items != null)
            {
                foreach (RfqNprRequestSetGrpc item in from.Items)
                {
                    NPR.RfqNprRequestSetGrpc mapped = ToNpr(item);
                    to.Items.Add(mapped);
                }
            }

            return to;
        }

        // --------------------------------------------------------------------
        // Manager (RfqModule) --> NPR : Request set
        // --------------------------------------------------------------------
        public static NPR.RfqNprRequestSetGrpc ToNpr(RfqNprRequestSetGrpc from)
        {
            NPR.RfqNprRequestSetGrpc to = new NPR.RfqNprRequestSetGrpc();
            if (from == null)
            {
                return to;
            }

            // Non-nullable string in target, keep it non-null
            to.Id = from.Id ?? string.Empty;

            // Wrappers and timestamps: assign the wrapper directly (clone preserves reference semantics)
            to.RfqNumber = from.RfqNumber;
            to.Created = from.Created;
            to.Status = (NPR.NprSetRequestStatusGrpc)(int)from.Status;
            to.Updated = from.Updated;
            to.Closed = from.Closed;
            to.ProjectId = from.ProjectId;

            // Nested project info
            if (from.Project != null)
            {
                NPR.RfqProjectInfoGrpc mappedProject = ToNpr(from.Project);
                to.Project = mappedProject;
            }

            // Nested requests
            if (from.NprRequests != null)
            {
                foreach (RfqNprRequestGrpc req in from.NprRequests)
                {
                    NPR.RfqNprRequestGrpc mappedReq = ToNpr(req);
                    to.NprRequests.Add(mappedReq);
                }
            }

            return to;
        }

        // --------------------------------------------------------------------
        // Manager (RfqModule) --> NPR : Project info
        // --------------------------------------------------------------------
        public static NPR.RfqProjectInfoGrpc ToNpr(RfqProjectInfoGrpc from)
        {
            NPR.RfqProjectInfoGrpc to = new NPR.RfqProjectInfoGrpc();
            if (from == null)
            {
                return to;
            }

            // Primitives
            to.RowId = from.RowId;
            to.RfqReasonId = from.RfqReasonId;
            to.VehicleVolume = from.VehicleVolume;
            to.IsActive = from.IsActive;

            // Wrappers / timestamp (clone copies wrapper instance)
            to.RfqNumber = from.RfqNumber;
            to.CustomerBusinessUnitId = from.CustomerBusinessUnitId;
            to.CustomerLocationId = from.CustomerLocationId;
            to.ProjectId = from.ProjectId;
            to.RfqResponseDeadline = from.RfqResponseDeadline;
            to.CarModelId = from.CarModelId;

            return to;
        }

        // --------------------------------------------------------------------
        // Manager (RfqModule) --> NPR : Single request
        // --------------------------------------------------------------------
        public static NPR.RfqNprRequestGrpc ToNpr(RfqNprRequestGrpc from)
        {
            NPR.RfqNprRequestGrpc to = new NPR.RfqNprRequestGrpc();
            if (from == null)
            {
                return to;
            }

            // Non-nullable string in target
            to.Id = from.Id ?? string.Empty;

            // Simple wrappers
            to.Reason = from.Reason;
            to.Customer = from.Customer;
            to.PlatformName = from.PlatformName;
            to.ProgramName = from.ProgramName;
            to.Project = from.Project;

            // More wrappers
            to.MaterialType = from.MaterialType;
            to.SuggestedSewsEManufacturingSite = from.SuggestedSewsEManufacturingSite;

            to.CustomerPartNumber = from.CustomerPartNumber;
            to.SupplierPartNumber = from.SupplierPartNumber;
            to.SumitomoNumber = from.SumitomoNumber;

            to.MaterialDescription = from.MaterialDescription;
            to.UnitOfMeasure = from.UnitOfMeasure;
            to.SupplierGroup = from.SupplierGroup;

            to.QtyPerVehicle = from.QtyPerVehicle;
            to.Quantity = from.Quantity;

            // Timestamp wrapper
            to.RequiredDate = from.RequiredDate;

            to.RaisedRemarks = from.RaisedRemarks;

            // booleans
            to.IsCustomerNominatedSupplier = from.IsCustomerNominatedSupplier;
            to.IsCustomerNominatedMaterial = from.IsCustomerNominatedMaterial;
            to.SamplesRequired = from.SamplesRequired;

            // Sample-related wrappers
            to.SampleSite = from.SampleSite;
            to.SampleQuantity = from.SampleQuantity;
            to.SampleRecipient = from.SampleRecipient;
            to.SampleRequiredDate = from.SampleRequiredDate;

            // Remaining wrappers
            to.FreightAccount = from.FreightAccount;
            to.AssociatedParts = from.AssociatedParts;
            to.SuggestedManufacturer = from.SuggestedManufacturer;

            return to;
        }
        public static NPRListRfqNprRequestSetGrpc ToMgr(NPR.ListRfqNprRequestSetGrpc from)
        {
            NPRListRfqNprRequestSetGrpc to = new NPRListRfqNprRequestSetGrpc();

            if (from != null && from.Items != null)
            {
                foreach (NPR.RfqNprRequestSetGrpc item in from.Items)
                {
                    RfqNprRequestSetGrpc mapped = ToMgr(item);
                    to.Items.Add(mapped);
                }
            }

            return to;
        }

        public static RfqNprRequestSetGrpc ToMgr(NPR.RfqNprRequestSetGrpc from)
        {
            RfqNprRequestSetGrpc to = new RfqNprRequestSetGrpc();
            if (from == null)
            {
                return to;
            }

            to.Id = from.Id ?? string.Empty;

            // wrappers/timestamps assigned directly (same style as your other mappers)
            to.RfqNumber = from.RfqNumber;
            to.Created = from.Created;
            to.Status = (NprSetRequestStatusGrpc)(int)from.Status;
            to.Updated = from.Updated;
            to.Closed = from.Closed;
            to.ProjectId = from.ProjectId;

            if (from.Project != null)
            {
                to.Project = ToMgr(from.Project);
            }

            if (from.NprRequests != null)
            {
                foreach (NPR.RfqNprRequestGrpc req in from.NprRequests)
                {
                    RfqNprRequestGrpc mappedRequest;
                    mappedRequest = ToMgr(req);
                    to.NprRequests.Add(mappedRequest);

                }
            }

            return to;
        }

        public static RfqProjectInfoGrpc ToMgr(NPR.RfqProjectInfoGrpc from)
        {
            RfqProjectInfoGrpc to = new RfqProjectInfoGrpc();
            if (from == null)
            {
                return to;
            }

            // primitives
            to.RowId = from.RowId;
            to.RfqReasonId = from.RfqReasonId;
            to.VehicleVolume = from.VehicleVolume;
            to.IsActive = from.IsActive;

            // wrappers/timestamps
            to.RfqNumber = from.RfqNumber;
            to.CustomerBusinessUnitId = from.CustomerBusinessUnitId;
            to.CustomerLocationId = from.CustomerLocationId;
            to.ProjectId = from.ProjectId;
            to.RfqResponseDeadline = from.RfqResponseDeadline;
            to.CarModelId = from.CarModelId;

            return to;
        }

        public static RfqNprRequestGrpc ToMgr(NPR.RfqNprRequestGrpc from)
        {
            RfqNprRequestGrpc to = new RfqNprRequestGrpc();
            if (from == null)
            {
                return to;
            }

            to.Id = from.Id ?? string.Empty;

            to.Reason = from.Reason;
            to.Customer = from.Customer;
            to.PlatformName = from.PlatformName;
            to.ProgramName = from.ProgramName;
            to.Project = from.Project;

            to.MaterialType = from.MaterialType;
            to.SuggestedSewsEManufacturingSite = from.SuggestedSewsEManufacturingSite;

            to.CustomerPartNumber = from.CustomerPartNumber;
            to.SupplierPartNumber = from.SupplierPartNumber;
            to.SumitomoNumber = from.SumitomoNumber;

            to.MaterialDescription = from.MaterialDescription;
            to.UnitOfMeasure = from.UnitOfMeasure;
            to.SupplierGroup = from.SupplierGroup;

            to.QtyPerVehicle = from.QtyPerVehicle;
            to.Quantity = from.Quantity;

            to.RequiredDate = from.RequiredDate;

            to.RaisedRemarks = from.RaisedRemarks;

            to.IsCustomerNominatedSupplier = from.IsCustomerNominatedSupplier;
            to.IsCustomerNominatedMaterial = from.IsCustomerNominatedMaterial;
            to.SamplesRequired = from.SamplesRequired;

            to.SampleSite = from.SampleSite;
            to.SampleQuantity = from.SampleQuantity;
            to.SampleRecipient = from.SampleRecipient;
            to.SampleRequiredDate = from.SampleRequiredDate;

            to.FreightAccount = from.FreightAccount;
            to.AssociatedParts = from.AssociatedParts;
            to.SuggestedManufacturer = from.SuggestedManufacturer;

            return to;
        }
    }
}