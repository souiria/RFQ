namespace Rfq.Extensions
{
    public static class RfqMappingExtentions
    {
        #region RfqDrawingPartNumber
        public static RfqDrawingPartNumberGrpc FromEntity(this DbRfqDrawingPartNumber entity)
        {
            RfqDrawingPartNumberGrpc data = new RfqDrawingPartNumberGrpc();
            data.RowId = entity.RowId;
            data.RfqId = entity.RfqId;
            data.OriginalPartNumber = entity.OriginalPartNumber;
            data.OriginalPartNumberPrice = (double?)entity.OriginalPartNumberPrice;
            data.SwappedPartNumber = entity.SwappedPartNumber;
            data.SwappedPartNumberPrice = (double?)entity.SwappedPartNumberPrice;
            data.PriceSource = entity.PriceSource;
            data.IsExactMatch = entity.IsExactMatch;
            data.IsSwapped = entity.IsSwapped;
            data.Comments = entity.Comments;
            data.SumitomoPartNumber = entity.SumitomoPartNumber;
            data.SupplierPartNumber = entity.SupplierPartNumber;
            data.NprId = entity.NprId?.ToString();
            data.CustomerPartNumber = entity.CustomerPartNumber;
            data.NprRequest = entity.NprRequest;
            data.Status = (int?)entity.Status;
            data.Quantity = (double?)entity.Quantity;
            data.PartNumber1 = entity.PartNumber1;
            data.PartNumber2 = entity.PartNumber2;  
            data.PartNumber3 = entity.PartNumber3;
            return data;
        }

        public static DbRfqDrawingPartNumber ToEntity(this RfqDrawingPartNumberGrpc grpc)
        {
            DbRfqDrawingPartNumber data = new DbRfqDrawingPartNumber();
            data.RowId = grpc.RowId;
            data.RfqId = grpc.RfqId;
            data.OriginalPartNumber = grpc.OriginalPartNumber;
            data.OriginalPartNumberPrice = (decimal?)grpc.OriginalPartNumberPrice;
            data.SwappedPartNumber = grpc.SwappedPartNumber;
            data.SwappedPartNumberPrice = (decimal?)grpc.SwappedPartNumberPrice;
            data.PriceSource = grpc.PriceSource;
            data.IsExactMatch = grpc.IsExactMatch;
            data.IsSwapped = grpc.IsSwapped;
            data.Comments = grpc.Comments;
            data.SumitomoPartNumber = grpc.SumitomoPartNumber;
            data.SupplierPartNumber = grpc.SupplierPartNumber;
            data.NprId = string.IsNullOrEmpty(grpc.NprId) ? null : Guid.Parse(grpc.NprId);
            data.CustomerPartNumber = grpc.CustomerPartNumber;
            data.NprRequest = grpc.NprRequest;
            data.Status = (RfqDrawingPartNumberStatus)(grpc.Status ?? 0);
            data.Quantity = (decimal)(grpc.Quantity ?? 0);
            data.PartNumber1 = grpc.PartNumber1;
            data.PartNumber2 = grpc.PartNumber2;
            data.PartNumber3 = grpc.PartNumber3;
            return data;
        }
        #endregion

        #region RfqProject
        public static RfqProjectGrpc FromEntity(this DbRfqProject entity)
        {
            RfqProjectGrpc data = new RfqProjectGrpc();
            data.RowId = entity.RowId;
            data.RfqNumber = entity.RfqNumber;
            data.CustomerBusinessUnitGuid = entity.CustomerBusinessUnitGuid.ToString();
            data.CustomerLocationGuid = entity.CustomerLocationGuid.ToString();
            data.ProjectGuid = entity.ProjectGuid.ToString();
            data.RfqReasonId = entity.RfqReasonId;
            data.RfqResponseDeadline = entity.RfqResponseDeadline?.ToUniversalTime().ToTimestamp();
            data.CarModelGuid = entity.CarModelGuid.ToString();
            data.VehicleVolume = entity.VehicleVolume;
            data.CreatedDate = entity.CreatedDate?.ToUniversalTime().ToTimestamp();
            data.IsActive = entity.IsActive;
          data.JsonData = entity.JsonData;
            return data;
        }
        public static DbRfqProject ToEntity(this RfqProjectGrpc grpc)
        {
            DbRfqProject data = new DbRfqProject();
            data.RowId = grpc.RowId;
            data.RfqNumber = grpc.RfqNumber;
            data.CustomerBusinessUnitGuid = !string.IsNullOrWhiteSpace(grpc.CustomerBusinessUnitGuid)
                ? Guid.Parse(grpc.CustomerBusinessUnitGuid)
                : Guid.Empty;
            data.CustomerLocationGuid = !string.IsNullOrWhiteSpace(grpc.CustomerLocationGuid)
                ? Guid.Parse(grpc.CustomerLocationGuid)
                : Guid.Empty;
            data.ProjectGuid = !string.IsNullOrWhiteSpace(grpc.ProjectGuid)
                ? Guid.Parse(grpc.ProjectGuid)
                : Guid.Empty;
            data.RfqReasonId = grpc.RfqReasonId;
            data.RfqResponseDeadline = grpc.RfqResponseDeadline?.ToDateTime().ToUniversalTime();
            data.CarModelGuid = !string.IsNullOrWhiteSpace(grpc.CarModelGuid)
                ? Guid.Parse(grpc.CarModelGuid)
                : Guid.Empty;
            data.VehicleVolume = grpc.VehicleVolume;
            data.CreatedDate = grpc.CreatedDate != null
            ? grpc.CreatedDate.ToDateTime().ToLocalTime()
            : DateTime.UtcNow; // or DateTime.MinValue or any default

            data.IsActive = grpc.IsActive ?? true;
            data.JsonData = grpc.JsonData;
            return data;
        }
        #endregion

        #region RfqNotes
        public static RfqNotesGrpc FromEntity(this DbRfqNotes entity)
        {
            RfqNotesGrpc data = new RfqNotesGrpc();
            data.RowId = entity.RowId;
            data.RfqId = entity.RfqId;
            data.Note = entity.Note;
            data.UserGuid = entity.UserGuid.ToString();
            data.LastModifiedOn = entity.LastModifiedOn?.ToUniversalTime().ToTimestamp();
            return data;
        }
        public static DbRfqNotes ToEntity(this RfqNotesGrpc grpc)
        {
            DbRfqNotes data = new DbRfqNotes();
            data.RowId = grpc.RowId;
            data.RfqId = grpc.RfqId;
            data.Note = grpc.Note;
            data.UserGuid = Guid.Parse(grpc.UserGuid);
            data.LastModifiedOn = DateTime.Now.ToLocalTime();
            return data;
        }
        #endregion

        #region RfqReason

        public static RfqReasonGrpc FromEntity(this DbRfqReason entity)
        {
            RfqReasonGrpc data = new RfqReasonGrpc();
            data.RowId = entity.RowId;
            data.RfqReasonTitle = entity.ReasonTitle;
            return data;
        }
        public static DbRfqReason ToEntity(this RfqReasonGrpc grpc)
        {
            DbRfqReason data = new DbRfqReason();
            data.RowId = grpc.RowId ?? 0;
            data.ReasonTitle = grpc.RfqReasonTitle ?? string.Empty;
            return data;
        }

        #endregion

        #region DsiBend

        public static DsiBendGrpc FromEntity(this DbDsiBend entity)
        {
            DsiBendGrpc data = new DsiBendGrpc();
            data.RowId = entity.RowId;
            data.BendId = entity.BendId.ToString();
            data.Bend = entity.Bend;
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiBend ToEntity(this DsiBendGrpc grpc)
        {
            DbDsiBend data = new DbDsiBend();
            data.RowId = grpc.RowId;
            data.BendId = Guid.Parse(grpc.BendId);
            data.Bend = grpc.Bend;
            data.CreatedDate = grpc.CreatedDate.ToDateTime().ToUniversalTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime().ToUniversalTime();
            data.CreatedBy = Guid.Parse(grpc.CreatedBy);
            return data;
        }

        #endregion

        #region DsiBranchConfiguration

        public static DsiBranchConfigurationGrpc FromEntity(this DbDsiBranchConfiguration entity)
        {
            DsiBranchConfigurationGrpc data = new DsiBranchConfigurationGrpc();
            data.RowId = entity.RowId;
            data.BranchConfigurationId = entity.BranchConfigurationId.ToString();
            data.StartNode = entity.StartNode;
            data.StartRoute = entity.StartRoute;
            data.StartCoordinates = entity.StartCoordinates;
            data.EndNode = entity.EndNode;
            data.EndRoute = entity.EndRoute;
            data.EndCoordinates = entity.EndCoordinates;
            data.Length = entity.Length;
            data.CircuitOptionId = entity.CircuitOptionId.ToString();
            data.BundleDiameter = entity.BundleDiameter;
            data.UserModule = entity.UserModule;
            data.AssignedModule = entity.AssignedModule;
            data.ModuleFrom = entity.ModuleFrom;
            data.BendString = entity.BendString;
            data.HarnessId = entity.HarnessId.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiBranchConfiguration ToEntity(this DsiBranchConfigurationGrpc grpc)
        {
            DbDsiBranchConfiguration data = new DbDsiBranchConfiguration();
            data.RowId = grpc.RowId;
            data.BranchConfigurationId = Guid.Parse(grpc.BranchConfigurationId ?? Guid.Empty.ToString());
            data.StartNode = grpc.StartNode;
            data.StartRoute = grpc.StartRoute;
            data.StartCoordinates = grpc.StartCoordinates;
            data.EndNode = grpc.EndNode;
            data.EndRoute = grpc.EndRoute;
            data.EndCoordinates = grpc.EndCoordinates;
            data.Length = grpc.Length ?? 0;
            data.CircuitOptionId = Guid.Parse(grpc.CircuitOptionId ?? Guid.Empty.ToString());
            data.BundleDiameter = grpc.BundleDiameter ?? 0;
            data.UserModule = grpc.UserModule;
            data.AssignedModule = grpc.AssignedModule;
            data.ModuleFrom = grpc.ModuleFrom;
            data.BendString = grpc.BendString;
            data.HarnessId = Guid.Parse(grpc.HarnessId ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiBranchConfigurationBendAssociation

        public static DsiBranchConfigurationBendAssociationGrpc FromEntity(this DbDsiBranchConfigurationBendAssociation entity)
        {
            DsiBranchConfigurationBendAssociationGrpc data = new DsiBranchConfigurationBendAssociationGrpc();
            data.RowId = entity.RowId;
            data.BranchConfigurationId = entity.BranchConfigurationId.ToString();
            data.BendId = entity.BendId.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiBranchConfigurationBendAssociation ToEntity(this DsiBranchConfigurationBendAssociationGrpc grpc)
        {
            DbDsiBranchConfigurationBendAssociation data = new DbDsiBranchConfigurationBendAssociation();
            data.RowId = grpc.RowId;
            data.BranchConfigurationId = Guid.Parse(grpc.BranchConfigurationId);
            data.BendId = Guid.Parse(grpc.BendId);
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiBranchInsulation

        public static DsiBranchInsulationGrpc FromEntity(this DbDsiBranchInsulation entity)
        {
            DsiBranchInsulationGrpc data = new DsiBranchInsulationGrpc();
            data.RowId = entity.RowId;
            data.StartNode = entity.StartNode;
            data.EndNode = entity.EndNode;
            data.EndRoute = entity.EndRoute;
            data.PieceCode = entity.PieceCode;
            data.InsulationCode = entity.InsulationCode;
            data.Diameter = entity.Diameter;
            data.CircuitOptionId = entity.CircuitOptionId.ToString();
            data.InsulationNote = entity.InsulationNote;
            data.UserModule = entity.UserModule;
            data.AssignedModule = entity.AssignedModule;
            data.ModuleFrom = entity.ModuleFrom;
            data.CalculationMethod = entity.CalculationMethod;
            data.ManualAmount = entity.ManualAmount;
            data.SplitValue = entity.SplitValue;
            data.JoinNumber = entity.JoinNumber;
            data.AssemblyItemNumber = entity.AssemblyItemNumber;
            data.Layer = entity.Layer;
            data.InsulationType = entity.InsulationType;
            data.PartNumber1 = entity.PartNumber1;
            data.PartNumber2 = entity.PartNumber2;
            data.PartNumber3 = entity.PartNumber3;
            data.Colour = entity.Colour;
            data.Type = entity.Type;
            data.Material = entity.Material;
            data.WallThickness = entity.WallThickness;
            data.NumberOfTurns = entity.NumberOfTurns;
            data.TurnsPerBreakout = entity.TurnsPerBreakout;
            data.TurnsPerBranch = entity.TurnsPerBranch;
            data.DistanceBetweenItems = entity.DistanceBetweenItems;
            data.LongestDistance = entity.LongestDistance;
            data.DistanceFromConnector = entity.DistanceFromConnector;
            data.TubeSelectionType = entity.TubeSelectionType;
            data.TubeSelectionFactor = entity.TubeSelectionFactor;
            data.CutBack = entity.Cutback;
            data.IsConvoluted = entity.IsConvoluted;
            data.IsSlit = entity.IsSlit;
            data.ModuleSpecificData = entity.ModuleSpecificData;
            data.HarnessId = entity.HarnessId.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiBranchInsulation ToEntity(this DsiBranchInsulationGrpc grpc)
        {
            DbDsiBranchInsulation data = new DbDsiBranchInsulation();
            data.RowId = grpc.RowId;
            data.StartNode = grpc.StartNode;
            data.EndNode = grpc.EndNode;
            data.EndRoute = grpc.EndRoute;
            data.PieceCode = grpc.PieceCode;
            data.InsulationCode = grpc.InsulationCode;
            data.Diameter = grpc.Diameter ?? 0;
            data.CircuitOptionId = Guid.Parse(grpc.CircuitOptionId ?? Guid.Empty.ToString());
            data.InsulationNote = grpc.InsulationNote;
            data.UserModule = grpc.UserModule;
            data.AssignedModule = grpc.AssignedModule;
            data.ModuleFrom = grpc.ModuleFrom;
            data.CalculationMethod = grpc.CalculationMethod;
            data.ManualAmount = grpc.ManualAmount ?? 0;
            data.SplitValue = grpc.SplitValue;
            data.JoinNumber = grpc.JoinNumber ?? 0;
            data.AssemblyItemNumber = grpc.AssemblyItemNumber ?? 0;
            data.Layer = grpc.Layer ?? 0;
            data.InsulationType = grpc.InsulationType;
            data.PartNumber1 = grpc.PartNumber1;
            data.PartNumber2 = grpc.PartNumber2;
            data.PartNumber3 = grpc.PartNumber3;
            data.Colour = grpc.Colour;
            data.Type = grpc.Type;
            data.Material = grpc.Material;
            data.WallThickness = grpc.WallThickness ?? 0;
            data.NumberOfTurns = grpc.NumberOfTurns ?? 0;
            data.TurnsPerBreakout = grpc.TurnsPerBreakout ?? 0;
            data.TurnsPerBranch = grpc.TurnsPerBranch ?? 0;
            data.DistanceBetweenItems = grpc.DistanceBetweenItems ?? 0;
            data.LongestDistance = grpc.LongestDistance ?? 0;
            data.DistanceFromConnector = grpc.DistanceFromConnector ?? 0;
            data.TubeSelectionType = grpc.TubeSelectionType;
            data.TubeSelectionFactor = grpc.TubeSelectionFactor ?? 0;
            data.Cutback = grpc.CutBack ?? 0;
            data.IsConvoluted = grpc.IsConvoluted ?? false;
            data.IsSlit = grpc.IsSlit ?? false;
            data.ModuleSpecificData = grpc.ModuleSpecificData;
            data.HarnessId = Guid.Parse(grpc.HarnessId ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiBranchInsulationThroughNode

        public static DsiBranchInsulationThroughNodeGrpc FromEntity(this DbDsiBranchInsulationThroughNode entity)
        {
            DsiBranchInsulationThroughNodeGrpc data = new DsiBranchInsulationThroughNodeGrpc();
            data.RowId = entity.RowId;
            data.PieceCode = entity.PieceCode;
            data.ThroughOrder = entity.ThroughOrder;
            data.ThroughNode = entity.ThroughNode;
            data.ThroughRoute = entity.ThroughRoute;
            data.IsThroughFlag = entity.IsThroughFlag;
            data.HarnessId = entity.HarnessId.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiBranchInsulationThroughNode ToEntity(this DsiBranchInsulationThroughNodeGrpc grpc)
        {
            DbDsiBranchInsulationThroughNode data = new DbDsiBranchInsulationThroughNode();
            data.RowId = grpc.RowId;
            data.PieceCode = grpc.PieceCode;
            data.ThroughOrder = grpc.ThroughOrder ?? 0;
            data.ThroughNode = grpc.ThroughNode;
            data.ThroughRoute = grpc.ThroughRoute;
            data.IsThroughFlag = grpc.IsThroughFlag ?? false;
            data.HarnessId = Guid.Parse(grpc.HarnessId ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiCavityMapping

        public static DsiCavityMappingGrpc FromEntity(this DbDsiCavityMapping entity)
        {
            DsiCavityMappingGrpc data = new DsiCavityMappingGrpc();
            data.RowId = entity.RowId;
            data.CavityMappingId = entity.CavityMappingId.ToString();
            data.CavityMapping = entity.CavityMapping;
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiCavityMapping ToEntity(this DsiCavityMappingGrpc grpc)
        {
            DbDsiCavityMapping data = new DbDsiCavityMapping();
            data.RowId = grpc.RowId;
            data.CavityMappingId = Guid.Parse(grpc.CavityMappingId ?? Guid.Empty.ToString());
            data.CavityMapping = grpc.CavityMapping;
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiSupplier
        public static DsiSupplierGrpc FromEntity(this DbDsiSupplier entity)
        {
            DsiSupplierGrpc data = new DsiSupplierGrpc();
            data.RowId = entity.RowId;
            data.Code = entity.Code;
            data.Name = entity.Name;
            data.SubsidiaryId = entity.Subsidiary_Id ?? 0;
            data.BuyerId = entity.Buyer_Id ?? 0;
            data.Address = entity.Address;
            data.Phone = entity.Phone;
            data.Email = entity.Email;
            data.Contact = entity.Contact;
            data.AlternateContact = entity.Alternate_Contact;
            data.Active = entity.Active ?? false;
            data.JSupplier = entity.J_Supplier ?? false;
            return data;
        }

        public static DbDsiSupplier ToEntity(this DsiSupplierGrpc grpc)
        {
            DbDsiSupplier data = new DbDsiSupplier();
            data.RowId = grpc.RowId;
            data.Code = grpc.Code;
            data.Name = grpc.Name;
            data.Subsidiary_Id = grpc.SubsidiaryId == 0 ? null : grpc.SubsidiaryId;
            data.Buyer_Id = grpc.BuyerId == 0 ? null : grpc.BuyerId;
            data.Address = grpc.Address;
            data.Phone = grpc.Phone;
            data.Email = grpc.Email;
            data.Contact = grpc.Contact;
            data.Alternate_Contact = grpc.AlternateContact;
            data.Active = grpc.Active;
            data.J_Supplier = grpc.JSupplier;
            return data;
        }

        #endregion

        #region DsiCentreStrip

        public static DsiCentreStripGrpc FromEntity(this DbDsiCentreStrip entity)
        {
            DsiCentreStripGrpc data = new DsiCentreStripGrpc();
            data.RowId = entity.RowId;
            data.NodeName = entity.NodeName;
            data.Route = entity.Route;
            data.WireName = entity.WireName;
            data.StripLength = entity.StripLength;
            data.LengthChangeType = entity.LengthChangeType;
            data.LengthChangeValue = entity.LengthChangeValue;
            data.Option = entity.Option;
            data.ThroughOrder = entity.ThroughOrder;
            data.HarnessID = entity.HarnessID.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiCentreStrip ToEntity(this DsiCentreStripGrpc grpc)
        {
            DbDsiCentreStrip data = new DbDsiCentreStrip();
            data.RowId = grpc.RowId;
            data.NodeName = grpc.NodeName;
            data.Route = grpc.Route;
            data.WireName = grpc.WireName;
            data.StripLength = grpc.StripLength;
            data.LengthChangeType = grpc.LengthChangeType;
            data.LengthChangeValue = grpc.LengthChangeValue;
            data.Option = grpc.Option;
            data.ThroughOrder = grpc.ThroughOrder;
            data.HarnessID = Guid.Parse(grpc.HarnessID ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiCircuitOption

        public static DsiCircuitOptionGrpc FromEntity(this DbDsiCircuitOption entity)
        {
            DsiCircuitOptionGrpc data = new DsiCircuitOptionGrpc();
            data.RowId = entity.RowId;
            data.CircuitOptionId = entity.CircuitOptionId.ToString();
            data.OptionName = entity.OptionName;
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiCircuitOption ToEntity(this DsiCircuitOptionGrpc grpc)
        {
            DbDsiCircuitOption data = new DbDsiCircuitOption();
            data.RowId = grpc.RowId;
            data.CircuitOptionId = Guid.Parse(grpc.CircuitOptionId ?? Guid.Empty.ToString());
            data.OptionName = grpc.OptionName;
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiComponent

        public static DsiComponentGrpc FromEntity(this DbDsiComponent entity)
        {
            DsiComponentGrpc data = new DsiComponentGrpc();
            data.RowId = entity.RowId;
            data.NodeName = entity.NodeName;
            data.CavityName = entity.CavityName;
            data.WireName = entity.WireName;
            data.SequenceNumber = entity.SequenceNumber;
            data.ComponentTypeCode1 = entity.ComponentTypeCode1;
            data.ComponentOption = entity.ComponentOption;
            data.ServiceFunction = entity.ServiceFunction;
            data.Route = entity.Route;
            data.PartNumber1 = entity.PartNumber1;
            data.PartNumber2 = entity.PartNumber2;
            data.PartNumber3 = entity.PartNumber3;
            data.Quantity = entity.Quantity;
            data.CrossSectionalArea = entity.CrossSectionalArea;
            data.IsSelectTerminal = entity.IsSelectTerminal;
            data.IsSeal = entity.IsSeal;
            data.IsPlugged = entity.IsPlugged;
            data.BlockNumber = entity.BlockNumber;
            data.TerminationMethod = entity.TerminationMethod;
            data.MaterialCode = entity.MaterialCode;
            data.ComponentTypeCode2 = entity.ComponentTypeCode2;
            data.InsulationType = entity.InsulationType;
            data.UserModule = entity.UserModule;
            data.AssignedModule = entity.AssignedModule;
            data.ModuleFrom = entity.ModuleFrom;
            data.SplitValue = entity.SplitValue;
            data.Datum = entity.Datum;
            data.AssemblyItemNumber = entity.AssemblyItemNumber;
            data.ColourCode = entity.ColourCode;
            data.NumberOfCavities = entity.NumberOfCavities;
            data.IsBackshell = entity.IsBackshell;
            data.WireOption = entity.WireOption;
            data.HarnessID = entity.HarnessID.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiComponent ToEntity(this DsiComponentGrpc grpc)
        {
            DbDsiComponent data = new DbDsiComponent();
            data.RowId = grpc.RowId;
            data.NodeName = grpc.NodeName;
            data.CavityName = grpc.CavityName;
            data.WireName = grpc.WireName;
            data.SequenceNumber = grpc.SequenceNumber;
            data.ComponentTypeCode1 = grpc.ComponentTypeCode1;
            data.ComponentOption = grpc.ComponentOption;
            data.ServiceFunction = grpc.ServiceFunction;
            data.Route = grpc.Route;
            data.PartNumber1 = grpc.PartNumber1;
            data.PartNumber2 = grpc.PartNumber2;
            data.PartNumber3 = grpc.PartNumber3;
            data.Quantity = grpc.Quantity;
            data.CrossSectionalArea = grpc.CrossSectionalArea;
            data.IsSelectTerminal = grpc.IsSelectTerminal;
            data.IsSeal = grpc.IsSeal;
            data.IsPlugged = grpc.IsPlugged;
            data.BlockNumber = grpc.BlockNumber;
            data.TerminationMethod = grpc.TerminationMethod;
            data.MaterialCode = grpc.MaterialCode;
            data.ComponentTypeCode2 = grpc.ComponentTypeCode2;
            data.InsulationType = grpc.InsulationType;
            data.UserModule = grpc.UserModule;
            data.AssignedModule = grpc.AssignedModule;
            data.ModuleFrom = grpc.ModuleFrom;
            data.SplitValue = grpc.SplitValue;
            data.Datum = grpc.Datum;
            data.AssemblyItemNumber = grpc.AssemblyItemNumber;
            data.ColourCode = grpc.ColourCode;
            data.NumberOfCavities = grpc.NumberOfCavities;
            data.IsBackshell = grpc.IsBackshell;
            data.WireOption = grpc.WireOption;
            data.HarnessID = Guid.Parse(grpc.HarnessID ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiCompositeDetail

        public static DsiCompositeDetailGrpc FromEntity(this DbDsiCompositeDetail entity)
        {
            DsiCompositeDetailGrpc data = new DsiCompositeDetailGrpc();
            data.RowId = entity.RowId;
            data.CompositeDetailId = entity.CompositeDetailId.ToString();
            data.HarnessName1 = entity.HarnessName1;
            data.SimilarHarnessName1 = entity.SimilarHarnessName1;
            data.HarnessIssue1 = entity.HarnessIssue1;
            data.SimilarHarnessIssue1 = entity.SimilarHarnessIssue1;
            data.HarnessDate1 = entity.HarnessDate1.ToUniversalTime().ToTimestamp();
            data.HarnessName2 = entity.HarnessName2;
            data.SimilarHarnessName2 = entity.SimilarHarnessName2;
            data.HarnessIssue2 = entity.HarnessIssue2;
            data.SimilarHarnessIssue2 = entity.SimilarHarnessIssue2;
            data.HarnessDate2 = entity.HarnessDate2.ToUniversalTime().ToTimestamp();
            data.Customer = entity.Customer;
            data.Site = entity.Site;
            data.Range = entity.Range;
            data.BoardLength = entity.BoardLength;
            data.BoardWidth = entity.BoardWidth;
            data.Datum = entity.Datum;
            data.UserField1 = entity.UserField1;
            data.UserField2 = entity.UserField2;
            data.UserField3 = entity.UserField3;
            data.UserField4 = entity.UserField4;
            data.UserField5 = entity.UserField5;
            data.Checker = entity.Checker;
            data.Inputter = entity.Inputter;
            data.DraftedBy = entity.DraftedBy;
            data.PreparedBy = entity.PreparedBy;
            data.Type = entity.Type;
            data.Title = entity.Title;
            data.EngineSize = entity.EngineSize;
            data.ManufacturingCell = entity.ManufacturingCell;
            data.Trim = entity.Trim;
            data.HandDrive = entity.HandDrive;
            data.TubeAddOnType = entity.TubeAddOnType;
            data.TubeAddOnFactor = entity.TubeAddOnFactor;
            data.IsManualTerminal = entity.IsManualTerminal;
            data.IsAllConnectorsSealed = entity.IsAllConnectorsSealed;
            data.AlphaCode = entity.AlphaCode;
            data.HarnessID = entity.HarnessID.ToString();
            data.CircuitOption = entity.CircuitOption;
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiCompositeDetail ToEntity(this DsiCompositeDetailGrpc grpc)
        {
            DbDsiCompositeDetail data = new DbDsiCompositeDetail();
            data.RowId = grpc.RowId;
            data.CompositeDetailId = Guid.Parse(grpc.CompositeDetailId);
            data.HarnessName1 = grpc.HarnessName1;
            data.SimilarHarnessName1 = grpc.SimilarHarnessName1;
            data.HarnessIssue1 = grpc.HarnessIssue1;
            data.SimilarHarnessIssue1 = grpc.SimilarHarnessIssue1;
            data.HarnessDate1 = grpc.HarnessDate1.ToDateTime();
            data.HarnessName2 = grpc.HarnessName2;
            data.SimilarHarnessName2 = grpc.SimilarHarnessName2;
            data.HarnessIssue2 = grpc.HarnessIssue2;
            data.SimilarHarnessIssue2 = grpc.SimilarHarnessIssue2;
            data.HarnessDate2 = grpc.HarnessDate2.ToDateTime();
            data.Customer = grpc.Customer;
            data.Site = grpc.Site;
            data.Range = grpc.Range;
            data.BoardLength = grpc.BoardLength;
            data.BoardWidth = grpc.BoardWidth;
            data.Datum = grpc.Datum;
            data.UserField1 = grpc.UserField1;
            data.UserField2 = grpc.UserField2;
            data.UserField3 = grpc.UserField3;
            data.UserField4 = grpc.UserField4;
            data.UserField5 = grpc.UserField5;
            data.Checker = grpc.Checker;
            data.Inputter = grpc.Inputter;
            data.DraftedBy = grpc.DraftedBy;
            data.PreparedBy = grpc.PreparedBy;
            data.Type = grpc.Type;
            data.Title = grpc.Title;
            data.EngineSize = grpc.EngineSize;
            data.ManufacturingCell = grpc.ManufacturingCell;
            data.Trim = grpc.Trim;
            data.HandDrive = grpc.HandDrive;
            data.TubeAddOnType = grpc.TubeAddOnType;
            data.TubeAddOnFactor = grpc.TubeAddOnFactor;
            data.IsManualTerminal = grpc.IsManualTerminal;
            data.IsAllConnectorsSealed = grpc.IsAllConnectorsSealed;
            data.AlphaCode = grpc.AlphaCode;
            data.HarnessID = Guid.Parse(grpc.HarnessID ?? Guid.Empty.ToString());
            data.CircuitOption = grpc.CircuitOption;
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }
        #endregion

        #region DsiCompositeDetailCircuitOptionAssociation

        public static DsiCompositeDetailCircuitOptionAssociationGrpc FromEntity(this DbDsiCompositeDetailCircuitOptionAssociation entity)
        {
            DsiCompositeDetailCircuitOptionAssociationGrpc data = new DsiCompositeDetailCircuitOptionAssociationGrpc();
            data.RowId = entity.RowId;
            data.CompositeDetailId = entity.CompositeDetailId.ToString();
            data.CircuitOptionId = entity.CircuitOptionId.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiCompositeDetailCircuitOptionAssociation ToEntity(this DsiCompositeDetailCircuitOptionAssociationGrpc grpc)
        {
            DbDsiCompositeDetailCircuitOptionAssociation data = new DbDsiCompositeDetailCircuitOptionAssociation();
            data.RowId = grpc.RowId;
            data.CompositeDetailId = Guid.Parse(grpc.CompositeDetailId ?? Guid.Empty.ToString());
            data.CircuitOptionId = Guid.Parse(grpc.CircuitOptionId ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();// This !!
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiCompositeOption

        public static DsiCompositeOptionGrpc FromEntity(this DbDsiCompositeOption entity)
        {
            DsiCompositeOptionGrpc data = new DsiCompositeOptionGrpc();
            data.RowId = entity.RowId;
            data.CompositeOptionId = entity.CompositeOptionId.ToString();
            data.OptionName = entity.OptionName;
            data.Description = entity.Description;
            data.HarnessID = entity.HarnessID.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiCompositeOption ToEntity(this DsiCompositeOptionGrpc grpc)
        {
            DbDsiCompositeOption data = new DbDsiCompositeOption();
            data.RowId = grpc.RowId;
            data.CompositeOptionId = Guid.Parse(grpc.CompositeOptionId);
            data.OptionName = grpc.OptionName;
            data.Description = grpc.Description;
            data.HarnessID = Guid.Parse(grpc.HarnessID ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiHarness

        public static DsiHarnessGrpc FromEntity(this DbDsiHarness entity)
        {
            DsiHarnessGrpc data = new DsiHarnessGrpc();
            data.RowId = entity.RowId;
            data.HarnessId = entity.HarnessId.ToString();
            data.HarnessName1 = entity.HarnessName1;
            data.SimilarHarnessName1 = entity.SimilarHarnessName1;
            data.HarnessIssue1 = entity.HarnessIssue1;
            data.SimilarHarnessIssue1 = entity.SimilarHarnessIssue1;
            data.HarnessDate1 = entity.HarnessDate1.ToUniversalTime().ToTimestamp();
            data.HarnessName2 = entity.HarnessName2;
            data.SimilarHarnessName2 = entity.SimilarHarnessName2;
            data.HarnessIssue2 = entity.HarnessIssue2;
            data.SimilarHarnessIssue2 = entity.SimilarHarnessIssue2;
            data.HarnessDate2 = entity.HarnessDate2.ToUniversalTime().ToTimestamp();
            data.FileVersion = entity.FileVersion;
            data.Customer = entity.Customer;
            data.Site = entity.Site;
            data.Range = entity.Range;
            data.BoardLength = entity.BoardLength;
            data.BoardWidth = entity.BoardWidth;
            data.Datum = entity.Datum;
            data.UserField1 = entity.UserField1;
            data.UserField2 = entity.UserField2;
            data.UserField3 = entity.UserField3;
            data.UserField4 = entity.UserField4;
            data.UserField5 = entity.UserField5;
            data.Checker = entity.Checker;
            data.Inputter = entity.Inputter;
            data.DraftedBy = entity.DraftedBy;
            data.PreparedBy = entity.PreparedBy;
            data.Type = entity.Type;
            data.Title = entity.Title;
            data.EngineSize = entity.EngineSize;
            data.ManufacturingCell = entity.ManufacturingCell;
            data.Trim = entity.Trim;
            data.HandDrive = entity.HandDrive;
            data.TubeAddOnType = entity.TubeAddOnType;
            data.TubeAddOnFactor = entity.TubeAddOnFactor;
            data.IsManualTerminal = entity.IsManualTerminal;
            data.IsAllConnectorsSealed = entity.IsAllConnectorsSealed;
            data.DatumNode = entity.DatumNode;
            data.DatumRoute = entity.DatumRoute;
            data.IsModule = entity.IsModule;
            data.AlphaCode = entity.AlphaCode;
            data.IsPitchTableUsed = entity.IsPitchTableUsed;
            data.AdditionalComments = entity.AdditionalComments;
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiHarness ToEntity(this DsiHarnessGrpc grpc)
        {
            DbDsiHarness data = new DbDsiHarness();
            data.RowId = grpc.RowId;
            data.HarnessId = Guid.Parse(grpc.HarnessId ?? Guid.Empty.ToString());
            data.HarnessName1 = grpc.HarnessName1;
            data.SimilarHarnessName1 = grpc.SimilarHarnessName1;
            data.HarnessIssue1 = grpc.HarnessIssue1;
            data.SimilarHarnessIssue1 = grpc.SimilarHarnessIssue1;
            data.HarnessDate1 = grpc.HarnessDate1.ToDateTime();
            data.HarnessName2 = grpc.HarnessName2;
            data.SimilarHarnessName2 = grpc.SimilarHarnessName2;
            data.HarnessIssue2 = grpc.HarnessIssue2;
            data.SimilarHarnessIssue2 = grpc.SimilarHarnessIssue2;
            data.HarnessDate2 = grpc.HarnessDate2.ToDateTime();
            data.FileVersion = grpc.FileVersion;
            data.Customer = grpc.Customer;
            data.Site = grpc.Site;
            data.Range = grpc.Range;
            data.BoardLength = grpc.BoardLength;
            data.BoardWidth = grpc.BoardWidth;
            data.Datum = grpc.Datum;
            data.UserField1 = grpc.UserField1;
            data.UserField2 = grpc.UserField2;
            data.UserField3 = grpc.UserField3;
            data.UserField4 = grpc.UserField4;
            data.UserField5 = grpc.UserField5;
            data.Checker = grpc.Checker;
            data.Inputter = grpc.Inputter;
            data.DraftedBy = grpc.DraftedBy;
            data.PreparedBy = grpc.PreparedBy;
            data.Type = grpc.Type;
            data.Title = grpc.Title;
            data.EngineSize = grpc.EngineSize;
            data.ManufacturingCell = grpc.ManufacturingCell;
            data.Trim = grpc.Trim;
            data.HandDrive = grpc.HandDrive;
            data.TubeAddOnType = grpc.TubeAddOnType;
            data.TubeAddOnFactor = grpc.TubeAddOnFactor;
            data.IsManualTerminal = grpc.IsManualTerminal;
            data.IsAllConnectorsSealed = grpc.IsAllConnectorsSealed;
            data.DatumNode = grpc.DatumNode;
            data.DatumRoute = grpc.DatumRoute;
            data.IsModule = grpc.IsModule;
            data.AlphaCode = grpc.AlphaCode;
            data.IsPitchTableUsed = grpc.IsPitchTableUsed;
            data.AdditionalComments = grpc.AdditionalComments;
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiHarnessScope

        public static DsiHarnessScopeGrpc FromEntity(this DbDsiHarnessScope entity)
        {
            DsiHarnessScopeGrpc data = new DsiHarnessScopeGrpc();
            data.RowId = entity.RowId;
            data.HarnessScopeId = entity.HarnessScopeId.ToString();
            data.HarnessName1 = entity.HarnessName1;
            data.HarnessIssue1 = entity.HarnessIssue1;
            data.HarnessName2 = entity.HarnessName2;
            data.HarnessIssue2 = entity.HarnessIssue2;
            data.ScopeCategory = entity.ScopeCategory;
            data.HarnessID = entity.HarnessID.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiHarnessScope ToEntity(this DsiHarnessScopeGrpc grpc)
        {
            DbDsiHarnessScope data = new DbDsiHarnessScope();
            data.RowId = grpc.RowId;
            data.HarnessScopeId = Guid.Parse(grpc.HarnessScopeId);
            data.HarnessName1 = grpc.HarnessName1;
            data.HarnessIssue1 = grpc.HarnessIssue1;
            data.HarnessName2 = grpc.HarnessName2;
            data.HarnessIssue2 = grpc.HarnessIssue2;
            data.ScopeCategory = grpc.ScopeCategory;
            data.HarnessID = Guid.Parse(grpc.HarnessID ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiHarnessScopeScopeAssociation

        public static DsiHarnessScopeScopeAssociationGrpc FromEntity(this DbDsiHarnessScopeScopeAssociation entity)
        {
            DsiHarnessScopeScopeAssociationGrpc data = new DsiHarnessScopeScopeAssociationGrpc();
            data.RowId = entity.RowId;
            data.HarnessScopeID = entity.HarnessScopeID.ToString();
            data.ScopeID = entity.ScopeID.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiHarnessScopeScopeAssociation ToEntity(this DsiHarnessScopeScopeAssociationGrpc grpc)
        {
            DbDsiHarnessScopeScopeAssociation data = new DbDsiHarnessScopeScopeAssociation();
            data.RowId = grpc.RowId;
            data.HarnessScopeID = Guid.Parse(grpc.HarnessScopeID ?? Guid.Empty.ToString());
            data.ScopeID = Guid.Parse(grpc.ScopeID ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiManualBomQuantity

        public static DsiManualBomQuantityGrpc FromEntity(this DbDsiManualBomQuantity entity)
        {
            DsiManualBomQuantityGrpc data = new DsiManualBomQuantityGrpc();
            data.RowId = entity.RowId;
            data.SplitValue = entity.SplitValue;
            data.ModuleCode = entity.ModuleCode;
            data.Percentage = entity.Percentage;
            data.HarnessID = entity.HarnessID.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiManualBomQuantity ToEntity(this DsiManualBomQuantityGrpc grpc)
        {
            DbDsiManualBomQuantity data = new DbDsiManualBomQuantity();
            data.RowId = grpc.RowId;
            data.SplitValue = grpc.SplitValue;
            data.ModuleCode = grpc.ModuleCode;
            data.Percentage = grpc.Percentage;
            data.HarnessID = Guid.Parse(grpc.HarnessID ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiMidWireComponent

        public static DsiMidWireComponentGrpc FromEntity(this DbDsiMidWireComponent entity)
        {
            DsiMidWireComponentGrpc data = new DsiMidWireComponentGrpc();
            data.RowId = entity.RowId;
            data.NodeName = entity.NodeName;
            data.Route = entity.Route;
            data.WireName = entity.WireName;
            data.Option = entity.Option;
            data.MidWireOption = entity.MidWireOption;
            data.Cavity = entity.Cavity;
            data.ThroughOrder = entity.ThroughOrder;
            data.HarnessID = entity.HarnessID.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiMidWireComponent ToEntity(this DsiMidWireComponentGrpc grpc)
        {
            DbDsiMidWireComponent data = new DbDsiMidWireComponent();
            data.RowId = grpc.RowId;
            data.NodeName = grpc.NodeName;
            data.Route = grpc.Route;
            data.WireName = grpc.WireName;
            data.Option = grpc.Option;
            data.MidWireOption = grpc.MidWireOption;
            data.Cavity = grpc.Cavity;
            data.ThroughOrder = grpc.ThroughOrder;
            data.HarnessID = Guid.Parse(grpc.HarnessID ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiModuleChildDetail

        public static DsiModuleChildDetailGrpc FromEntity(this DbDsiModuleChildDetail entity)
        {
            DsiModuleChildDetailGrpc data = new DsiModuleChildDetailGrpc();
            data.RowId = entity.RowId;
            data.ModuleCode = entity.ModuleCode;
            data.IsCoreModule = entity.IsCoreModule;
            data.HarnessName1 = entity.HarnessName1;
            data.SimilarHarnessName1 = entity.SimilarHarnessName1;
            data.HarnessIssue1 = entity.HarnessIssue1;
            data.SimilarHarnessIssue1 = entity.SimilarHarnessIssue1;
            data.HarnessDate1 = entity.HarnessDate1?.ToUniversalTime().ToTimestamp();
            data.HarnessName2 = entity.HarnessName2;
            data.SimilarHarnessName2 = entity.SimilarHarnessName2;
            data.HarnessIssue2 = entity.HarnessIssue2;
            data.SimilarHarnessIssue2 = entity.SimilarHarnessIssue2;
            data.HarnessDate2 = entity.HarnessDate2?.ToUniversalTime().ToTimestamp();
            data.Customer = entity.Customer;
            data.Site = entity.Site;
            data.Range = entity.Range;
            data.BoardLength = entity.BoardLength;
            data.BoardWidth = entity.BoardWidth;
            data.Datum = entity.Datum;
            data.UserField1 = entity.UserField1;
            data.UserField2 = entity.UserField2;
            data.UserField3 = entity.UserField3;
            data.UserField4 = entity.UserField4;
            data.UserField5 = entity.UserField5;
            data.Checker = entity.Checker;
            data.Inputter = entity.Inputter;
            data.DraftedBy = entity.DraftedBy;
            data.PreparedBy = entity.PreparedBy;
            data.Type = entity.Type;
            data.Title = entity.Title;
            data.EngineSize = entity.EngineSize;
            data.ManufacturingCell = entity.ManufacturingCell;
            data.Trim = entity.Trim;
            data.HandDrive = entity.HandDrive;
            data.TubeAddOnType = entity.TubeAddOnType;
            data.TubeAddOnFactor = entity.TubeAddOnFactor;
            data.IsManualTerminal = entity.IsManualTerminal;
            data.IsAllConnectorSealed = entity.IsAllConnectorSealed;
            data.AlphaCode = entity.AlphaCode;
            data.HarnessID = entity.HarnessID.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiModuleChildDetail ToEntity(this DsiModuleChildDetailGrpc grpc)
        {
            DbDsiModuleChildDetail data = new DbDsiModuleChildDetail();
            data.RowId = grpc.RowId;
            data.ModuleCode = grpc.ModuleCode;
            data.IsCoreModule = grpc.IsCoreModule;
            data.HarnessName1 = grpc.HarnessName1;
            data.SimilarHarnessName1 = grpc.SimilarHarnessName1;
            data.HarnessIssue1 = grpc.HarnessIssue1;
            data.SimilarHarnessIssue1 = grpc.SimilarHarnessIssue1;
            data.HarnessDate1 = grpc.HarnessDate1?.ToDateTime();
            data.HarnessName2 = grpc.HarnessName2;
            data.SimilarHarnessName2 = grpc.SimilarHarnessName2;
            data.HarnessIssue2 = grpc.HarnessIssue2;
            data.SimilarHarnessIssue2 = grpc.SimilarHarnessIssue2;
            data.HarnessDate2 = grpc.HarnessDate2?.ToDateTime();
            data.Customer = grpc.Customer;
            data.Site = grpc.Site;
            data.Range = grpc.Range;
            data.BoardLength = grpc.BoardLength;
            data.BoardWidth = grpc.BoardWidth;
            data.Datum = grpc.Datum;
            data.UserField1 = grpc.UserField1;
            data.UserField2 = grpc.UserField2;
            data.UserField3 = grpc.UserField3;
            data.UserField4 = grpc.UserField4;
            data.UserField5 = grpc.UserField5;
            data.Checker = grpc.Checker;
            data.Inputter = grpc.Inputter;
            data.DraftedBy = grpc.DraftedBy;
            data.PreparedBy = grpc.PreparedBy;
            data.Type = grpc.Type;
            data.Title = grpc.Title;
            data.EngineSize = grpc.EngineSize;
            data.ManufacturingCell = grpc.ManufacturingCell;
            data.Trim = grpc.Trim;
            data.HandDrive = grpc.HandDrive;
            data.TubeAddOnType = grpc.TubeAddOnType;
            data.TubeAddOnFactor = grpc.TubeAddOnFactor;
            data.IsManualTerminal = grpc.IsManualTerminal;
            data.IsAllConnectorSealed = grpc.IsAllConnectorSealed;
            data.AlphaCode = grpc.AlphaCode;
            data.HarnessID = Guid.Parse(grpc.HarnessID ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiModuleCompatibility

        public static DsiModuleCompatibilityGrpc FromEntity(this DbDsiModuleCompatibility entity)
        {
            DsiModuleCompatibilityGrpc data = new DsiModuleCompatibilityGrpc();
            data.RowId = entity.RowId;
            data.ModuleCode1 = entity.ModuleCode1;
            data.ModuleCode2 = entity.ModuleCode2;
            data.Relationship = entity.Relationship;
            data.HarnessID = entity.HarnessID.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiModuleCompatibility ToEntity(this DsiModuleCompatibilityGrpc grpc)
        {
            DbDsiModuleCompatibility data = new DbDsiModuleCompatibility();
            data.RowId = grpc.RowId;
            data.ModuleCode1 = grpc.ModuleCode1;
            data.ModuleCode2 = grpc.ModuleCode2;
            data.Relationship = grpc.Relationship;
            data.HarnessID = Guid.Parse(grpc.HarnessID ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiMulticoreSpecification

        public static DsiMulticoreSpecificationGrpc FromEntity(this DbDsiMulticoreSpecification entity)
        {
            DsiMulticoreSpecificationGrpc data = new DsiMulticoreSpecificationGrpc();
            data.RowId = entity.RowId;
            data.MulticoreName = entity.MulticoreName;
            data.IsIncludedOnBom = entity.IsIncludedOnBom;
            data.IsIncludedOnChart = entity.IsIncludedOnChart;
            data.Tag = entity.Tag;
            data.Note = entity.Note;
            data.LengthChangeType = entity.LengthChangeType;
            data.LengthChangeValue = entity.LengthChangeValue;
            data.OuterSheathCutBackAtEnd1Type = entity.OuterSheathCutBackAtEnd1Type;
            data.OuterSheathCutBackAtEnd1Value = entity.OuterSheathCutBackAtEnd1Value;
            data.OuterSheathCutBackAtEnd2Type = entity.OuterSheathCutBackAtEnd2Type;
            data.OuterSheathCutBackAtEnd2Value = entity.OuterSheathCutBackAtEnd2Value;
            data.Colour = entity.Colour;
            data.Material = entity.Material;
            data.Specification = entity.Specification;
            data.IsSheathed = entity.IsSheathed;
            data.UserModule = entity.UserModule;
            data.AssemblyItemNumber = entity.AssemblyItemNumber;
            data.ParentMulticoreName = entity.ParentMulticoreName;
            data.MulticoreOption = entity.MulticoreOption;
            data.ParentMulticoreOption = entity.ParentMulticoreOption;
            data.UnmodifiedMulticoreLength = entity.UnmodifiedMulticoreLength;
            data.ModifiedMulticoreLength = entity.ModifiedMulticoreLength;
            data.PartNumber1 = entity.PartNumber1;
            data.PartNumber2 = entity.PartNumber2;
            data.PartNumber3 = entity.PartNumber3;
            data.HarnessID = entity.HarnessID.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiMulticoreSpecification ToEntity(this DsiMulticoreSpecificationGrpc grpc)
        {
            DbDsiMulticoreSpecification data = new DbDsiMulticoreSpecification();
            data.RowId = grpc.RowId;
            data.MulticoreName = grpc.MulticoreName;
            data.IsIncludedOnBom = grpc.IsIncludedOnBom;
            data.IsIncludedOnChart = grpc.IsIncludedOnChart;
            data.Tag = grpc.Tag;
            data.Note = grpc.Note;
            data.LengthChangeType = grpc.LengthChangeType;
            data.LengthChangeValue = grpc.LengthChangeValue;
            data.OuterSheathCutBackAtEnd1Type = grpc.OuterSheathCutBackAtEnd1Type;
            data.OuterSheathCutBackAtEnd1Value = grpc.OuterSheathCutBackAtEnd1Value;
            data.OuterSheathCutBackAtEnd2Type = grpc.OuterSheathCutBackAtEnd2Type;
            data.OuterSheathCutBackAtEnd2Value = grpc.OuterSheathCutBackAtEnd2Value;
            data.Colour = grpc.Colour;
            data.Material = grpc.Material;
            data.Specification = grpc.Specification;
            data.IsSheathed = grpc.IsSheathed;
            data.UserModule = grpc.UserModule;
            data.AssemblyItemNumber = grpc.AssemblyItemNumber;
            data.ParentMulticoreName = grpc.ParentMulticoreName;
            data.MulticoreOption = grpc.MulticoreOption;
            data.ParentMulticoreOption = grpc.ParentMulticoreOption;
            data.UnmodifiedMulticoreLength = grpc.UnmodifiedMulticoreLength;
            data.ModifiedMulticoreLength = grpc.ModifiedMulticoreLength;
            data.PartNumber1 = grpc.PartNumber1;
            data.PartNumber2 = grpc.PartNumber2;
            data.PartNumber3 = grpc.PartNumber3;
            data.HarnessID = Guid.Parse(grpc.HarnessID ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiPinMapping

        public static DsiPinMappingGrpc FromEntity(this DbDsiPinMapping entity)
        {
            DsiPinMappingGrpc data = new DsiPinMappingGrpc();
            data.RowId = entity.RowId;
            data.PinMappingId = entity.PinMappingId.ToString();
            data.Node1 = entity.Node1;
            data.Node2 = entity.Node2;
            data.HarnessName1 = entity.HarnessName1;
            data.HarnessIssue1 = entity.HarnessIssue1;
            data.HarnessName2 = entity.HarnessName2;
            data.HarnessIssue2 = entity.HarnessIssue2;
            data.Separator = entity.Separator;
            data.HarnessID = entity.HarnessID.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiPinMapping ToEntity(this DsiPinMappingGrpc grpc)
        {
            DbDsiPinMapping data = new DbDsiPinMapping();
            data.RowId = grpc.RowId;
            data.PinMappingId = Guid.Parse(grpc.PinMappingId ?? Guid.Empty.ToString());
            data.Node1 = grpc.Node1;
            data.Node2 = grpc.Node2;
            data.HarnessName1 = grpc.HarnessName1;
            data.HarnessIssue1 = grpc.HarnessIssue1;
            data.HarnessName2 = grpc.HarnessName2;
            data.HarnessIssue2 = grpc.HarnessIssue2;
            data.Separator = grpc.Separator;
            data.HarnessID = Guid.Parse(grpc.HarnessID ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiPinMappingCavityMappingAssociation

        public static DsiPinMappingCavityMappingAssociationGrpc FromEntity(this DbDsiPinMappingCavityMappingAssociation entity)
        {
            DsiPinMappingCavityMappingAssociationGrpc data = new DsiPinMappingCavityMappingAssociationGrpc();
            data.RowId = entity.RowId;
            data.PinMappingID = entity.PinMappingID.ToString();
            data.CavityMappingID = entity.CavityMappingID.ToString();
            data.MappingNumber = entity.MappingNumber;
            data.CreatedDate = entity.CreatedDate;
            data.ModifiedDate = entity.ModifiedDate;
            data.CreatedBy = entity.CreatedBy;
            data.ModifiedBy = entity.ModifiedBy;
            return data;
        }

        public static DbDsiPinMappingCavityMappingAssociation ToEntity(this DsiPinMappingCavityMappingAssociationGrpc grpc)
        {
            DbDsiPinMappingCavityMappingAssociation data = new DbDsiPinMappingCavityMappingAssociation();
            data.RowId = grpc.RowId;
            data.PinMappingID = Guid.Parse(grpc.PinMappingID ?? Guid.Empty.ToString());
            data.CavityMappingID = Guid.Parse(grpc.CavityMappingID ?? Guid.Empty.ToString());
            data.MappingNumber = grpc.MappingNumber;
            data.CreatedDate = grpc.CreatedDate;
            data.ModifiedDate = grpc.ModifiedDate;
            data.CreatedBy = grpc.CreatedBy;
            data.ModifiedBy = grpc.ModifiedBy;
            return data;
        }

        #endregion

        #region DsiScope

        public static DsiScopeGrpc FromEntity(this DbDsiScope entity)
        {
            DsiScopeGrpc data = new DsiScopeGrpc();
            data.RowId = entity.RowId;
            data.Scope = entity.Scope;
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiScope ToEntity(this DsiScopeGrpc grpc)
        {
            DbDsiScope data = new DbDsiScope();
            data.RowId = grpc.RowId;
            data.Scope = grpc.Scope;
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiTransformedCompositeDetail

        public static DsiTransformedCompositeDetailGrpc FromEntity(this DbDsiTransformedCompositeDetail entity)
        {
            DsiTransformedCompositeDetailGrpc data = new DsiTransformedCompositeDetailGrpc();
            data.RowId = entity.RowId;
            data.HarnessName1 = entity.HarnessName1;
            data.SimilarHarnessName1 = entity.SimilarHarnessName1;
            data.HarnessIssue1 = entity.HarnessIssue1;
            data.SimilarHarnessIssue1 = entity.SimilarHarnessIssue1;
            data.HarnessDate1 = entity.HarnessDate1.ToUniversalTime().ToTimestamp();
            data.HarnessName2 = entity.HarnessName2;
            data.SimilarHarnessName2 = entity.SimilarHarnessName2;
            data.HarnessIssue2 = entity.HarnessIssue2;
            data.SimilarHarnessIssue2 = entity.SimilarHarnessIssue2;
            data.HarnessDate2 = entity.HarnessDate2.ToUniversalTime().ToTimestamp();
            data.Customer = entity.Customer;
            data.Site = entity.Site;
            data.Range = entity.Range;
            data.BoardLength = entity.BoardLength;
            data.BoardWidth = entity.BoardWidth;
            data.Datum = entity.Datum;
            data.UserField1 = entity.UserField1;
            data.UserField2 = entity.UserField2;
            data.UserField3 = entity.UserField3;
            data.UserField4 = entity.UserField4;
            data.UserField5 = entity.UserField5;
            data.Checker = entity.Checker;
            data.Inputter = entity.Inputter;
            data.DraftedBy = entity.DraftedBy;
            data.PreparedBy = entity.PreparedBy;
            data.Type = entity.Type;
            data.Title = entity.Title;
            data.EngineSize = entity.EngineSize;
            data.ManufacturingCell = entity.ManufacturingCell;
            data.Trim = entity.Trim;
            data.HandDrive = entity.HandDrive;
            data.TubeAddOnType = entity.TubeAddOnType;
            data.TubeAddOnFactor = entity.TubeAddOnFactor;
            data.IsManualTerminal = entity.IsManualTerminal;
            data.IsAllConnectorsSealed = entity.IsAllConnectorsSealed;
            data.AlphaCode = entity.AlphaCode;
            data.HarnessID = entity.HarnessID.ToString();
            data.CircuitOption = entity.CircuitOption;
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiTransformedCompositeDetail ToEntity(this DsiTransformedCompositeDetailGrpc grpc)
        {
            DbDsiTransformedCompositeDetail data = new DbDsiTransformedCompositeDetail();
            data.RowId = grpc.RowId;
            data.HarnessName1 = grpc.HarnessName1;
            data.SimilarHarnessName1 = grpc.SimilarHarnessName1;
            data.HarnessIssue1 = grpc.HarnessIssue1;
            data.SimilarHarnessIssue1 = grpc.SimilarHarnessIssue1;
            data.HarnessDate1 = grpc.HarnessDate1.ToDateTime();
            data.HarnessName2 = grpc.HarnessName2;
            data.SimilarHarnessName2 = grpc.SimilarHarnessName2;
            data.HarnessIssue2 = grpc.HarnessIssue2;
            data.SimilarHarnessIssue2 = grpc.SimilarHarnessIssue2;
            data.HarnessDate2 = grpc.HarnessDate2.ToDateTime();
            data.Customer = grpc.Customer;
            data.Site = grpc.Site;
            data.Range = grpc.Range;
            data.BoardLength = grpc.BoardLength;
            data.BoardWidth = grpc.BoardWidth;
            data.Datum = grpc.Datum;
            data.UserField1 = grpc.UserField1;
            data.UserField2 = grpc.UserField2;
            data.UserField3 = grpc.UserField3;
            data.UserField4 = grpc.UserField4;
            data.UserField5 = grpc.UserField5;
            data.Checker = grpc.Checker;
            data.Inputter = grpc.Inputter;
            data.DraftedBy = grpc.DraftedBy;
            data.PreparedBy = grpc.PreparedBy;
            data.Type = grpc.Type;
            data.Title = grpc.Title;
            data.EngineSize = grpc.EngineSize;
            data.ManufacturingCell = grpc.ManufacturingCell;
            data.Trim = grpc.Trim;
            data.HandDrive = grpc.HandDrive;
            data.TubeAddOnType = grpc.TubeAddOnType;
            data.TubeAddOnFactor = grpc.TubeAddOnFactor;
            data.IsManualTerminal = grpc.IsManualTerminal;
            data.IsAllConnectorsSealed = grpc.IsAllConnectorsSealed;
            data.AlphaCode = grpc.AlphaCode;
            data.HarnessID = Guid.Parse(grpc.HarnessID ?? Guid.Empty.ToString());
            data.CircuitOption = grpc.CircuitOption;
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiTransformedHarness

        public static DsiTransformedHarnessGrpc FromEntity(this DbDsiTransformedHarness entity)
        {
            DsiTransformedHarnessGrpc data = new DsiTransformedHarnessGrpc();
            data.RowId = entity.RowId;
            data.HarnessName1 = entity.HarnessName1;
            data.SimilarHarnessName1 = entity.SimilarHarnessName1;
            data.HarnessIssue1 = entity.HarnessIssue1;
            data.SimilarHarnessIssue1 = entity.SimilarHarnessIssue1;
            data.HarnessDate1 = entity.HarnessDate1.ToUniversalTime().ToTimestamp();
            data.HarnessName2 = entity.HarnessName2;
            data.SimilarHarnessName2 = entity.SimilarHarnessName2;
            data.HarnessIssue2 = entity.HarnessIssue2;
            data.SimilarHarnessIssue2 = entity.SimilarHarnessIssue2;
            data.HarnessDate2 = entity.HarnessDate2.ToUniversalTime().ToTimestamp();
            data.FileVersion = entity.FileVersion;
            data.Customer = entity.Customer;
            data.Site = entity.Site;
            data.Range = entity.Range;
            data.BoardLength = entity.BoardLength;
            data.BoardWidth = entity.BoardWidth;
            data.Datum = entity.Datum;
            data.UserField1 = entity.UserField1;
            data.UserField2 = entity.UserField2;
            data.UserField3 = entity.UserField3;
            data.UserField4 = entity.UserField4;
            data.UserField5 = entity.UserField5;
            data.Checker = entity.Checker;
            data.Inputter = entity.Inputter;
            data.DraftedBy = entity.DraftedBy;
            data.PreparedBy = entity.PreparedBy;
            data.Type = entity.Type;
            data.Title = entity.Title;
            data.EngineSize = entity.EngineSize;
            data.ManufacturingCell = entity.ManufacturingCell;
            data.Trim = entity.Trim;
            data.HandDrive = entity.HandDrive;
            data.TubeAddOnType = entity.TubeAddOnType;
            data.TubeAddOnFactor = entity.TubeAddOnFactor;
            data.IsManualTerminal = entity.IsManualTerminal;
            data.IsAllConnectorsSealed = entity.IsAllConnectorsSealed;
            data.DatumNode = entity.DatumNode;
            data.DatumRoute = entity.DatumRoute;
            data.IsModule = entity.IsModule;
            data.AlphaCode = entity.AlphaCode;
            data.IsPitchTableUsed = entity.IsPitchTableUsed;
            data.AdditionalComments = entity.AdditionalComments;
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiTransformedHarness ToEntity(this DsiTransformedHarnessGrpc grpc)
        {
            DbDsiTransformedHarness data = new DbDsiTransformedHarness();
            data.RowId = grpc.RowId;
            data.HarnessName1 = grpc.HarnessName1;
            data.SimilarHarnessName1 = grpc.SimilarHarnessName1;
            data.HarnessIssue1 = grpc.HarnessIssue1;
            data.SimilarHarnessIssue1 = grpc.SimilarHarnessIssue1;
            data.HarnessDate1 = grpc.HarnessDate1.ToDateTime();
            data.HarnessName2 = grpc.HarnessName2;
            data.SimilarHarnessName2 = grpc.SimilarHarnessName2;
            data.HarnessIssue2 = grpc.HarnessIssue2;
            data.SimilarHarnessIssue2 = grpc.SimilarHarnessIssue2;
            data.HarnessDate2 = grpc.HarnessDate2.ToDateTime();
            data.FileVersion = grpc.FileVersion;
            data.Customer = grpc.Customer;
            data.Site = grpc.Site;
            data.Range = grpc.Range;
            data.BoardLength = grpc.BoardLength;
            data.BoardWidth = grpc.BoardWidth;
            data.Datum = grpc.Datum;
            data.UserField1 = grpc.UserField1;
            data.UserField2 = grpc.UserField2;
            data.UserField3 = grpc.UserField3;
            data.UserField4 = grpc.UserField4;
            data.UserField5 = grpc.UserField5;
            data.Checker = grpc.Checker;
            data.Inputter = grpc.Inputter;
            data.DraftedBy = grpc.DraftedBy;
            data.PreparedBy = grpc.PreparedBy;
            data.Type = grpc.Type;
            data.Title = grpc.Title;
            data.EngineSize = grpc.EngineSize;
            data.ManufacturingCell = grpc.ManufacturingCell;
            data.Trim = grpc.Trim;
            data.HandDrive = grpc.HandDrive;
            data.TubeAddOnType = grpc.TubeAddOnType;
            data.TubeAddOnFactor = grpc.TubeAddOnFactor;
            data.IsManualTerminal = grpc.IsManualTerminal;
            data.IsAllConnectorsSealed = grpc.IsAllConnectorsSealed;
            data.DatumNode = grpc.DatumNode;
            data.DatumRoute = grpc.DatumRoute;
            data.IsModule = grpc.IsModule;
            data.AlphaCode = grpc.AlphaCode;
            data.IsPitchTableUsed = grpc.IsPitchTableUsed;
            data.AdditionalComments = grpc.AdditionalComments;
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiTransformedModuleChildDetail

        public static DsiTransformedModuleChildDetailGrpc FromEntity(this DbDsiTransformedModuleChildDetail entity)
        {
            DsiTransformedModuleChildDetailGrpc data = new DsiTransformedModuleChildDetailGrpc();
            data.RowId = entity.RowId;
            data.ModuleCode = entity.ModuleCode;
            data.IsCoreModule = entity.IsCoreModule ?? false;
            data.HarnessName1 = entity.HarnessName1;
            data.SimilarHarnessName1 = entity.SimilarHarnessName1;
            data.HarnessIssue1 = entity.HarnessIssue1;
            data.SimilarHarnessIssue1 = entity.SimilarHarnessIssue1;
            data.HarnessDate1 = entity.HarnessDate1?.ToUniversalTime().ToTimestamp();
            data.HarnessName2 = entity.HarnessName2;
            data.SimilarHarnessName2 = entity.SimilarHarnessName2;
            data.HarnessIssue2 = entity.HarnessIssue2;
            data.SimilarHarnessIssue2 = entity.SimilarHarnessIssue2;
            data.HarnessDate2 = entity.HarnessDate2?.ToUniversalTime().ToTimestamp();
            data.Customer = entity.Customer;
            data.Site = entity.Site;
            data.Range = entity.Range;
            data.BoardLength = entity.BoardLength;
            data.BoardWidth = entity.BoardWidth;
            data.Datum = entity.Datum;
            data.UserField1 = entity.UserField1;
            data.UserField2 = entity.UserField2;
            data.UserField3 = entity.UserField3;
            data.UserField4 = entity.UserField4;
            data.UserField5 = entity.UserField5;
            data.Checker = entity.Checker;
            data.Inputter = entity.Inputter;
            data.DraftedBy = entity.DraftedBy;
            data.PreparedBy = entity.PreparedBy;
            data.Type = entity.Type;
            data.Title = entity.Title;
            data.EngineSize = entity.EngineSize;
            data.ManufacturingCell = entity.ManufacturingCell;
            data.Trim = entity.Trim;
            data.HandDrive = entity.HandDrive;
            data.TubeAddOnType = entity.TubeAddOnType;
            data.TubeAddOnFactor = entity.TubeAddOnFactor;
            data.IsManualTerminal = entity.IsManualTerminal;
            data.IsAllConnectorSealed = entity.IsAllConnectorSealed;
            data.AlphaCode = entity.AlphaCode;
            data.HarnessID = entity.HarnessID.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiTransformedModuleChildDetail ToEntity(this DsiTransformedModuleChildDetailGrpc grpc)
        {
            DbDsiTransformedModuleChildDetail data = new DbDsiTransformedModuleChildDetail();
            data.RowId = grpc.RowId;
            data.ModuleCode = grpc.ModuleCode;
            data.IsCoreModule = grpc.IsCoreModule;
            data.HarnessName1 = grpc.HarnessName1;
            data.SimilarHarnessName1 = grpc.SimilarHarnessName1;
            data.HarnessIssue1 = grpc.HarnessIssue1;
            data.SimilarHarnessIssue1 = grpc.SimilarHarnessIssue1;
            data.HarnessDate1 = grpc.HarnessDate1?.ToDateTime();
            data.HarnessName2 = grpc.HarnessName2;
            data.SimilarHarnessName2 = grpc.SimilarHarnessName2;
            data.HarnessIssue2 = grpc.HarnessIssue2;
            data.SimilarHarnessIssue2 = grpc.SimilarHarnessIssue2;
            data.HarnessDate2 = grpc.HarnessDate2?.ToDateTime();
            data.Customer = grpc.Customer;
            data.Site = grpc.Site;
            data.Range = grpc.Range;
            data.BoardLength = grpc.BoardLength;
            data.BoardWidth = grpc.BoardWidth;
            data.Datum = grpc.Datum;
            data.UserField1 = grpc.UserField1;
            data.UserField2 = grpc.UserField2;
            data.UserField3 = grpc.UserField3;
            data.UserField4 = grpc.UserField4;
            data.UserField5 = grpc.UserField5;
            data.Checker = grpc.Checker;
            data.Inputter = grpc.Inputter;
            data.DraftedBy = grpc.DraftedBy;
            data.PreparedBy = grpc.PreparedBy;
            data.Type = grpc.Type;
            data.Title = grpc.Title;
            data.EngineSize = grpc.EngineSize;
            data.ManufacturingCell = grpc.ManufacturingCell;
            data.Trim = grpc.Trim;
            data.HandDrive = grpc.HandDrive;
            data.TubeAddOnType = grpc.TubeAddOnType;
            data.TubeAddOnFactor = grpc.TubeAddOnFactor;
            data.IsManualTerminal = grpc.IsManualTerminal;
            data.IsAllConnectorSealed = grpc.IsAllConnectorSealed;
            data.AlphaCode = grpc.AlphaCode;
            data.HarnessID = Guid.Parse(grpc.HarnessID ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiUnitOfMeasure

        public static DsiUnitOfMeasureGrpc FromEntity(this DbDsiUnitOfMeasure entity)
        {
            DsiUnitOfMeasureGrpc data = new DsiUnitOfMeasureGrpc();
            data.RowId = entity.RowId;
            data.Abbreviation = entity.Abbreviation;
            data.Description = entity.Description;
            data.SubsidiaryId = entity.Subsidiary_Id;
            return data;
        }

        public static DbDsiUnitOfMeasure ToEntity(this DsiUnitOfMeasureGrpc grpc)
        {
            DbDsiUnitOfMeasure data = new DbDsiUnitOfMeasure();
            data.RowId = grpc.RowId;
            data.Abbreviation = grpc.Abbreviation;
            data.Description = grpc.Description;
            data.Subsidiary_Id = grpc.SubsidiaryId;
            return data;
        }

        #endregion

        #region DsiWireMulticoreMarker

        public static DsiWireMulticoreMarkerGrpc FromEntity(this DbDsiWireMulticoreMarker entity)
        {
            DsiWireMulticoreMarkerGrpc data = new DsiWireMulticoreMarkerGrpc();
            data.RowId = entity.RowId;
            data.ItemType = entity.ItemType;
            data.ItemName = entity.ItemName;
            data.Option = entity.Option;
            data.Location = entity.Location;
            data.Text = entity.Text;
            data.ColourCode = entity.ColourCode;
            data.Spacing = entity.Spacing ?? 0;
            data.HarnessID = entity.HarnessID.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy?.ToString() ?? string.Empty;
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiWireMulticoreMarker ToEntity(this DsiWireMulticoreMarkerGrpc grpc)
        {
            DbDsiWireMulticoreMarker data = new DbDsiWireMulticoreMarker();
            data.RowId = grpc.RowId;
            data.ItemType = grpc.ItemType;
            data.ItemName = grpc.ItemName;
            data.Option = grpc.Option;
            data.Location = grpc.Location;
            data.Text = grpc.Text;
            data.ColourCode = grpc.ColourCode;
            data.Spacing = grpc.Spacing;
            data.HarnessID = Guid.Parse(grpc.HarnessID ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiWireSpecification

        public static DsiWireSpecificationGrpc FromEntity(this DbDsiWireSpecification entity)
        {
            DsiWireSpecificationGrpc data = new DsiWireSpecificationGrpc();
            data.RowId = entity.RowId;
            data.WireName = entity.WireName;
            data.CompositeOptionString = entity.CompositeOptionString;
            data.WireType = entity.WireType;
            data.Colour = entity.Colour;
            data.CrossSectionalArea = entity.CrossSectionalArea;
            data.Material = entity.Material;
            data.UserModule = entity.UserModule;
            data.MulticoreName = entity.MulticoreName;
            data.End1NodeName = entity.End1NodeName;
            data.End1Route = entity.End1Route;
            data.End1Cavity = entity.End1Cavity;
            data.End1MaterialCode = entity.End1MaterialCode;
            data.End2NodeName = entity.End2NodeName;
            data.End2Route = entity.End2Route;
            data.End2Cavity = entity.End2Cavity;
            data.End2MaterialCode = entity.End2MaterialCode;
            data.IsIncludedOnBom = entity.IsIncludedOnBom;
            data.IsIncludedOnChart = entity.IsIncludedOnChart;
            data.WireTag = entity.WireTag;
            data.WireNote = entity.WireNote;
            data.WireLengthChangeType = entity.WireLengthChangeType;
            data.WireLengthChangeValue = entity.WireLengthChangeValue;
            data.AssemblyItemNumber = entity.AssemblyItemNumber;
            data.MulticoreOption = entity.MulticoreOption;
            data.UnmodifiedWireLength = entity.UnmodifiedWireLength;
            data.ModifiedWireLength = entity.ModifiedWireLength;
            data.CutbackAtEnd1 = entity.CutbackAtEnd1;
            data.CutbackAtEnd2 = entity.CutbackAtEnd2;
            data.PartNumber1 = entity.PartNumber1;
            data.PartNumber2 = entity.PartNumber2;
            data.PartNumber3 = entity.PartNumber3;
            data.Signal = entity.Signal;
            data.HarnessID = entity.HarnessID.ToString();
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiWireSpecification ToEntity(this DsiWireSpecificationGrpc grpc)
        {
            DbDsiWireSpecification data = new DbDsiWireSpecification();
            data.RowId = grpc.RowId;
            data.WireName = grpc.WireName;
            data.CompositeOptionString = grpc.CompositeOptionString;
            data.WireType = grpc.WireType;
            data.Colour = grpc.Colour;
            data.CrossSectionalArea = grpc.CrossSectionalArea;
            data.Material = grpc.Material;
            data.UserModule = grpc.UserModule;
            data.MulticoreName = grpc.MulticoreName;
            data.End1NodeName = grpc.End1NodeName;
            data.End1Route = grpc.End1Route;
            data.End1Cavity = grpc.End1Cavity;
            data.End1MaterialCode = grpc.End1MaterialCode;
            data.End2NodeName = grpc.End2NodeName;
            data.End2Route = grpc.End2Route;
            data.End2Cavity = grpc.End2Cavity;
            data.End2MaterialCode = grpc.End2MaterialCode;
            data.IsIncludedOnBom = grpc.IsIncludedOnBom;
            data.IsIncludedOnChart = grpc.IsIncludedOnChart;
            data.WireTag = grpc.WireTag;
            data.WireNote = grpc.WireNote;
            data.WireLengthChangeType = grpc.WireLengthChangeType;
            data.WireLengthChangeValue = grpc.WireLengthChangeValue;
            data.AssemblyItemNumber = grpc.AssemblyItemNumber;
            data.MulticoreOption = grpc.MulticoreOption;
            data.UnmodifiedWireLength = grpc.UnmodifiedWireLength;
            data.ModifiedWireLength = grpc.ModifiedWireLength;
            data.CutbackAtEnd1 = grpc.CutbackAtEnd1;
            data.CutbackAtEnd2 = grpc.CutbackAtEnd2;
            data.PartNumber1 = grpc.PartNumber1;
            data.PartNumber2 = grpc.PartNumber2;
            data.PartNumber3 = grpc.PartNumber3;
            data.Signal = grpc.Signal;
            data.HarnessID = Guid.Parse(grpc.HarnessID ?? Guid.Empty.ToString());
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region DsiWireThroughNode

        public static DsiWireThroughNodeGrpc FromEntity(this DbDsiWireThroughNode entity)
        {
            DsiWireThroughNodeGrpc data = new DsiWireThroughNodeGrpc();
            data.RowId = entity.RowId;
            data.WireName = entity.WireName;
            data.Option = entity.Option;
            data.ThroughOrder = entity.ThroughOrder;
            data.ThroughNode = entity.ThroughNode;
            data.ThroughRoute = entity.ThroughRoute;
            data.IsThroughFlag = entity.IsThroughFlag;
            data.HarnessID = entity.HarnessID?.ToString() ?? string.Empty;
            data.CreatedDate = entity.CreatedDate.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            return data;
        }

        public static DbDsiWireThroughNode ToEntity(this DsiWireThroughNodeGrpc grpc)
        {
            DbDsiWireThroughNode data = new DbDsiWireThroughNode();
            data.RowId = grpc.RowId;
            data.WireName = grpc.WireName;
            data.Option = grpc.Option;
            data.ThroughOrder = grpc.ThroughOrder;
            data.ThroughNode = grpc.ThroughNode;
            data.ThroughRoute = grpc.ThroughRoute;
            data.IsThroughFlag = grpc.IsThroughFlag;
            data.HarnessID = string.IsNullOrEmpty(grpc.HarnessID) ? null : Guid.Parse(grpc.HarnessID);
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            if (!Guid.TryParse(grpc.CreatedBy, out Guid createdBy))
            {
                createdBy = Guid.Empty;
            }

            data.ModifiedBy = createdBy;
            if (!Guid.TryParse(grpc.ModifiedBy, out Guid modifiedBy))
            {
                modifiedBy = Guid.Empty;
            }

            data.ModifiedBy = modifiedBy;
            return data;
        }

        #endregion

        #region RfqNprRequest

        public static RfqNprRequestGrpc FromEntity(this DbRfqNprRequestModel entity)
        {
            RfqNprRequestGrpc data = new RfqNprRequestGrpc();
            data.Id = entity.Id.ToString();
            data.CustomerRfqNo = entity.CustomerRfqNo;
            data.CustomerCode = entity.CustomerCode;
            data.RequestID = entity.RequestID;
            data.OriginatorName = entity.OriginatorName;
            data.DeadlineDate = entity.DeadlineDate?.ToUniversalTime().ToTimestamp();
            data.ReasonDescription = entity.ReasonDescription;
            data.MaterialNumber = entity.MaterialNumber;
            data.MaterialDescription = entity.MaterialDescription;
            data.CustomerPartNumber = entity.CustomerPartNumber;
            data.SupplierPartNumber = entity.SupplierPartNumber;
            data.SEWSEUnitOfMeasurement = entity.SEWSEUnitOfMeasurement;
            data.SupplierGroup = entity.SupplierGroup;
            data.SupplierDetailComments = entity.SupplierDetailComments;
            data.ProjectCode = entity.ProjectCode;
            data.QtyPerVehicle = (double?)entity.QtyPerVehicle;
            data.VehicleTotalQuantity = entity.VehicleTotalQuantity;
            data.IsSampleDataRequired = entity.IsSampleDataRequired;

            // Map SampleSiteDetails
            if (entity.SampleSiteDetails != null)
            {
                foreach (RfqNprSampleSiteData site in entity.SampleSiteDetails)
                {
                    RfqNprRequestSampleSiteDataGrpc sampleSite = new RfqNprRequestSampleSiteDataGrpc();
                    sampleSite.BusinessUnitCode = site.BusinessUnitCode;
                    sampleSite.SampleQty = site.SampleQty;
                    sampleSite.SendSampleContactPersonName = site.SendSampleContactPersonName;
                    sampleSite.RequiredDate = site.RequiredDate?.ToUniversalTime().ToTimestamp();
                    sampleSite.FreightAccount = site.FreightAccount;
                    data.SampleSiteDetails.Add(sampleSite);
                }
            }

            data.NPRRaisedRemarks = entity.NPRRaisedRemarks;
            data.ManufacturingSite = entity.ManufacturingSite;
            data.IsCustomerNominatedSupplier = entity.IsCustomerNominatedSupplier;
            data.IsCustomerNominatedMaterial = entity.IsCustomerNominatedMaterial;
            data.PlatformName = entity.PlatformName;
            data.ProgramName = entity.ProgramName;
            data.SuggestedManufacturerGroup = entity.SuggestedManufacturerGroup;
            data.AssociatedParts = entity.AssociatedParts;
            data.NPRUploadSeqNo = entity.NPRUploadSeqNo;
            data.CreatedAt = entity.Created.ToUniversalTime().ToTimestamp();
            data.ModifiedAt = entity.Updated.ToUniversalTime().ToTimestamp();
            data.Status = (int?)entity.Status;
            data.IsActive = entity.IsActive;
            data.SubmittedAt = entity.Closed?.ToUniversalTime().ToTimestamp();
            data.RemoteEndpointResponse = entity.Reason;
            return data;
        }

        public static DbRfqNprRequestModel ToEntity(this RfqNprRequestGrpc grpc)
        {
            DbRfqNprRequestModel data = new DbRfqNprRequestModel();
            //data.Id = string.IsNullOrEmpty(grpc.Id) ? Guid.Empty : Guid.Parse(grpc.Id);
            data.Id = string.IsNullOrEmpty(grpc.Id) || !Guid.TryParse(grpc.Id, out Guid parsedId)
                ? Guid.Empty
                : parsedId;
            data.CustomerRfqNo = grpc.CustomerRfqNo;
            data.CustomerCode = grpc.CustomerCode;
            data.RequestID = grpc.RequestID;
            data.OriginatorName = grpc.OriginatorName;
            data.DeadlineDate = grpc.DeadlineDate?.ToDateTime();
            data.ReasonDescription = grpc.ReasonDescription;
            data.MaterialNumber = grpc.MaterialNumber;
            data.MaterialDescription = grpc.MaterialDescription;
            data.CustomerPartNumber = grpc.CustomerPartNumber;
            data.SupplierPartNumber = grpc.SupplierPartNumber;
            data.SEWSEUnitOfMeasurement = grpc.SEWSEUnitOfMeasurement;
            data.SupplierGroup = grpc.SupplierGroup;
            data.SupplierDetailComments = grpc.SupplierDetailComments;
            data.ProjectCode = grpc.ProjectCode;
            data.QtyPerVehicle = (decimal?)grpc.QtyPerVehicle;
            data.VehicleTotalQuantity = grpc.VehicleTotalQuantity;
            data.IsSampleDataRequired = grpc.IsSampleDataRequired ?? false;
            data.Status = grpc.Status ?? 0;

            // Map SampleSiteDetails
            List<RfqNprSampleSiteData> sampleSiteList = new List<RfqNprSampleSiteData>();
            foreach (RfqNprRequestSampleSiteDataGrpc site in grpc.SampleSiteDetails)
            {
                RfqNprSampleSiteData sampleSite = new RfqNprSampleSiteData();
                sampleSite.BusinessUnitCode = site.BusinessUnitCode;
                sampleSite.SampleQty = site.SampleQty;
                sampleSite.SendSampleContactPersonName = site.SendSampleContactPersonName;
                sampleSite.RequiredDate = site.RequiredDate?.ToDateTime();
                sampleSite.FreightAccount = site.FreightAccount;
                sampleSiteList.Add(sampleSite);
            }

            data.SampleSiteDetails = sampleSiteList;

            data.NPRRaisedRemarks = grpc.NPRRaisedRemarks;
            data.ManufacturingSite = grpc.ManufacturingSite;
            data.IsCustomerNominatedSupplier = grpc.IsCustomerNominatedSupplier ?? false;
            data.IsCustomerNominatedMaterial = grpc.IsCustomerNominatedMaterial ?? false;
            data.PlatformName = grpc.PlatformName;
            data.ProgramName = grpc.ProgramName;
            data.SuggestedManufacturerGroup = grpc.SuggestedManufacturerGroup;
            data.AssociatedParts = grpc.AssociatedParts;
            data.NPRUploadSeqNo = grpc.NPRUploadSeqNo;
            data.Created = grpc.CreatedAt != null ? grpc.CreatedAt.ToDateTime() : DateTime.UtcNow;
            data.Updated = grpc.ModifiedAt != null ? grpc.ModifiedAt.ToDateTime() : DateTime.UtcNow;
            data.Closed = grpc.SubmittedAt?.ToDateTime();
            data.Reason = grpc.RemoteEndpointResponse;
            // 😁As IsActive is a non-nullable field in the entity, we need to provide a default value if it's null in the gRPC model. Assuming that if it's null, it should be treated as true (active), we can set it to true by default.
            data.IsActive = grpc.IsActive == true;
            return data;
        }

        #endregion

    }
}