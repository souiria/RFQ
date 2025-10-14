namespace Rfq.Extensions
{
    public static class RfqMappingExtentions
    {
        #region RfqDrawingPartNumber
        public static RfqDrawingPartNumbersGrpc FromEntity(this DbRfqDrawingPartNumber entity)
        {
            RfqDrawingPartNumbersGrpc data = new RfqDrawingPartNumbersGrpc();
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
            return data;
        }

        public static DbRfqDrawingPartNumber ToEntity(this RfqDrawingPartNumbersGrpc grpc)
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
            return data;
        }
        public static DbRfqProject ToEntity(this RfqProjectGrpc grpc)
        {
            DbRfqProject data = new DbRfqProject();
            data.RowId = grpc.RowId;
            data.RfqNumber = grpc.RfqNumber;
            data.CustomerBusinessUnitGuid = Guid.Parse(grpc.CustomerBusinessUnitGuid);
            data.CustomerLocationGuid = Guid.Parse(grpc.CustomerLocationGuid);
            data.ProjectGuid = Guid.Parse(grpc.ProjectGuid);
            data.RfqReasonId = grpc.RfqReasonId;
            data.RfqResponseDeadline = grpc.RfqResponseDeadline?.ToDateTime().ToLocalTime();
            data.CarModelGuid = Guid.Parse(grpc.CarModelGuid);
            data.VehicleVolume = grpc.VehicleVolume;
            data.CreatedDate = grpc.CreatedDate.ToDateTime().ToLocalTime();
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
            data.ReasonTitle = entity.ReasonTitle;
            return data;
        }
        public static DbRfqReason ToEntity(this RfqReasonGrpc grpc)
        {
            DbRfqReason data = new DbRfqReason();
            data.RowId = grpc.RowId;
            data.ReasonTitle = grpc.ReasonTitle;
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
            data.CreatedDate = grpc.CreatedDate.ToDateTime().ToLocalTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime().ToLocalTime();
            data.CreatedBy = Guid.Parse(grpc.CreatedBy);
            data.ModifiedBy = Guid.Parse(grpc.ModifiedBy);
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
            data.BranchConfigurationId = Guid.Parse(grpc.BranchConfigurationId);
            data.StartNode = grpc.StartNode;
            data.StartRoute = grpc.StartRoute;
            data.StartCoordinates = grpc.StartCoordinates;
            data.EndNode = grpc.EndNode;
            data.EndRoute = grpc.EndRoute;
            data.EndCoordinates = grpc.EndCoordinates;
            data.Length = grpc.Length ?? 0;
            data.CircuitOptionId = Guid.Parse(grpc.CircuitOptionId);
            data.BundleDiameter = grpc.BundleDiameter ?? 0;
            data.UserModule = grpc.UserModule;
            data.AssignedModule = grpc.AssignedModule;
            data.ModuleFrom = grpc.ModuleFrom;
            data.BendString = grpc.BendString;
            data.HarnessId = Guid.Parse(grpc.HarnessId);
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            data.CreatedBy = Guid.Parse(grpc.CreatedBy);
            data.ModifiedBy = Guid.Parse(grpc.ModifiedBy);
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
            data.CreatedBy = Guid.Parse(grpc.CreatedBy);
            data.ModifiedBy = Guid.Parse(grpc.ModifiedBy);
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
            data.Cutback = entity.Cutback;
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
            data.CircuitOptionId = Guid.Parse(grpc.CircuitOptionId);
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
            data.Cutback = grpc.Cutback ?? 0;
            data.IsConvoluted = grpc.IsConvoluted ?? false;
            data.IsSlit = grpc.IsSlit ?? false;
            data.ModuleSpecificData = grpc.ModuleSpecificData;
            data.HarnessId = Guid.Parse(grpc.HarnessId);
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            data.CreatedBy = Guid.Parse(grpc.CreatedBy);
            data.ModifiedBy = Guid.Parse(grpc.ModifiedBy);
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
            data.HarnessId = Guid.Parse(grpc.HarnessId);
            data.CreatedDate = grpc.CreatedDate.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();
            data.CreatedBy = Guid.Parse(grpc.CreatedBy);
            data.ModifiedBy = Guid.Parse(grpc.ModifiedBy);
            return data;
        }

        #endregion
    }
}
