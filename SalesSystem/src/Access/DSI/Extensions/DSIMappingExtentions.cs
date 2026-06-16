using SharedKernel;

namespace DSI.Extensions
{
    public static class DSIMappingExtentions
    {
        #region Component

        public static ComponentGrpc FromEntity(this DbComponent entity)
        {
            ComponentGrpc data = new ComponentGrpc();

            data.Id = entity.RowId;
            data.NodeName = entity.NodeName;
            data.CavityName = entity.CavityName;
            data.WireName = entity.WireName;
            data.SequenceNumber = entity.SequenceNumber;
            data.ComponentOption = entity.ComponentOption;
            data.Route = entity.Route;
            data.PartNumber1 = entity.PartNumber1;
            data.PartNumber2 = entity.PartNumber2;
            data.PartNumber3 = entity.PartNumber3;
            data.Quantity = (double?)entity.Quantity;
            data.CrossSectionalArea = (double?)entity.CrossSectionalArea;
            data.IsPlugged = entity.IsPlugged;
            data.MaterialCode = entity.MaterialCode;
            data.InsulationType = entity.InsulationType;
            data.HarnessID = entity.HarnessID?.ToString();

            return data;
        }

        public static DbComponent ToEntity(this ComponentGrpc grpc)
        {
            DbComponent data = new DbComponent();

            data.RowId = grpc.Id;
            data.NodeName = grpc.NodeName;
            data.CavityName = grpc.CavityName;
            data.WireName = grpc.WireName;
            data.SequenceNumber = grpc.SequenceNumber;
            data.ComponentOption = grpc.ComponentOption;
            data.Route = grpc.Route;
            data.PartNumber1 = grpc.PartNumber1;
            data.PartNumber2 = grpc.PartNumber2;
            data.PartNumber3 = grpc.PartNumber3;
            data.Quantity = (double?)grpc.Quantity;
            data.CrossSectionalArea = (double?)grpc.CrossSectionalArea;
            data.IsPlugged = grpc.IsPlugged;
            data.MaterialCode = grpc.MaterialCode;
            data.InsulationType = grpc.InsulationType;
            data.HarnessID = string.IsNullOrEmpty(grpc.HarnessID) ? null : Guid.Parse(grpc.HarnessID);

            return data;
        }

        #endregion
        #region BranchInsulation

        public static BranchInsulationGrpc FromEntity(this DbBranchInsulation entity)
        {
            BranchInsulationGrpc data = new BranchInsulationGrpc();

            data.Id = entity.RowId;
            data.StartNode = entity.StartNode;
            data.EndNode = entity.EndNode;
            data.PieceCode = entity.PieceCode;
            data.InsulationCode = entity.InsulationCode;
            data.Diameter = (double?)entity.Diameter;
            data.CircuitOptionID = entity.CircuitOptionID?.ToString();
            data.ManualAmount = (double?)entity.ManualAmount;
            data.PartNumber1 = entity.PartNumber1;
            data.IsConvoluted = entity.IsConvoluted;
            data.IsSlit = entity.IsSlit;
            data.HarnessID = entity.HarnessID?.ToString();

            return data;
        }

        public static DbBranchInsulation ToEntity(this BranchInsulationGrpc grpc)
        {
            DbBranchInsulation data = new DbBranchInsulation();

            data.RowId = grpc.Id;
            data.StartNode = grpc.StartNode;
            data.EndNode = grpc.EndNode;
            data.PieceCode = grpc.PieceCode;
            data.InsulationCode = grpc.InsulationCode;
            data.Diameter = (double?)grpc.Diameter;
            data.CircuitOptionID = string.IsNullOrEmpty(grpc.CircuitOptionID) ? null : Guid.Parse(grpc.CircuitOptionID);
            data.ManualAmount = (double?)grpc.ManualAmount;
            data.PartNumber1 = grpc.PartNumber1;
            data.IsConvoluted = grpc.IsConvoluted;
            data.IsSlit = grpc.IsSlit;
            data.HarnessID = string.IsNullOrEmpty(grpc.HarnessID) ? null : Guid.Parse(grpc.HarnessID);

            return data;
        }

        #endregion
        #region WireSpecification

        public static WireSpecificationGrpc FromEntity(this DbWireSpecification entity)
        {
            WireSpecificationGrpc data = new WireSpecificationGrpc();

            data.Id = entity.RowId;  
            data.WireName = entity.WireName;
            data.WireType = entity.WireType;
            data.Colour = entity.Colour;
            data.CrossSectionalArea = (double?)entity.CrossSectionalArea;
            data.Material = entity.Material;
            data.IsIncludedOnBom = entity.IsIncludedOnBom;
            data.IsIncludedOnChart = entity.IsIncludedOnChart;
            data.WireTag = entity.WireTag;
            data.WireNote = entity.WireNote;
            data.UnmodifiedWireLength = (double?)entity.UnmodifiedWireLength;
            data.ModifiedWireLength = (double?)entity.ModifiedWireLength;
            data.PartNumber1 = entity.PartNumber1;
            data.Signal = entity.Signal;
            data.HarnessID = entity.HarnessID?.ToString();
           data.Compositeoptionstring=entity.CompositeOptionString;
            data.End1NodeName = entity.End1NodeName;
            data.End2NodeName = entity.End2NodeName;

            return data;
        }

        public static DbWireSpecification ToEntity(this WireSpecificationGrpc grpc)
        {
            DbWireSpecification data = new DbWireSpecification();

            data.RowId = grpc.Id;
            data.WireName = grpc.WireName;
            data.WireType = grpc.WireType;
            data.Colour = grpc.Colour;
            data.CrossSectionalArea = (double?)grpc.CrossSectionalArea;
            data.Material = grpc.Material;
            data.IsIncludedOnBom = grpc.IsIncludedOnBom;
            data.IsIncludedOnChart = grpc.IsIncludedOnChart;
            data.WireTag = grpc.WireTag;
            data.WireNote = grpc.WireNote;
            data.UnmodifiedWireLength = (double?)grpc.UnmodifiedWireLength;
            data.ModifiedWireLength = (double?)grpc.ModifiedWireLength;
            data.PartNumber1 = grpc.PartNumber1;
            data.Signal = grpc.Signal;
            data.HarnessID = string.IsNullOrEmpty(grpc.HarnessID) ? null : Guid.Parse(grpc.HarnessID);
            data.CompositeOptionString = grpc.Compositeoptionstring;
            data.End1NodeName = grpc.End1NodeName;
            data.End2NodeName = grpc.End2NodeName;
            return data;
        }

        #endregion
        #region CompositeDetail

        public static CompositeDetailGrpc FromEntity(this DbCompositeDetail entity)
        {
            CompositeDetailGrpc data = new CompositeDetailGrpc();

            data.Id = entity.RowId;
            data.Customer = entity.Customer;
            data.Site = entity.Site;
            data.Range = entity.Range;
            data.BoardLength = (double?)entity.BoardLength;
            data.BoardWidth = (double?)entity.BoardWidth;
            data.Datum = entity.Datum;
            data.Type = entity.Type;
            data.Title = entity.Title;
            data.EngineSize = entity.EngineSize;
            data.ManufacturingCell = entity.ManufacturingCell;
            data.Trim = entity.Trim;
            data.HandDrive = entity.HandDrive;
            data.TubeAddOnType = entity.TubeAddOnType;
            data.TubeAddOnFactor = (double?)entity.TubeAddOnFactor;
            data.IsManualTerminal = entity.IsManualTerminal;
            data.IsAllConnectorsSealed = entity.IsAllConnectorsSealed;
            data.AlphaCode = entity.AlphaCode;
            data.HarnessID = entity.HarnessID?.ToString();
            data.CircuitOption = entity.CircuitOption;
            data.HarnessName1= entity.HarnessName1;
            data.HarnessName2= entity.HarnessName2;

            return data;
        }

        public static DbCompositeDetail ToEntity(this CompositeDetailGrpc grpc)
        {
            DbCompositeDetail data = new DbCompositeDetail();

            data.RowId = grpc.Id;
            data.Customer = grpc.Customer;
            data.Site = grpc.Site;
            data.Range = grpc.Range;
            data.BoardLength = (double?)grpc.BoardLength;
            data.BoardWidth = (double?)grpc.BoardWidth;
            data.Datum = grpc.Datum;
            data.Type = grpc.Type;
            data.Title = grpc.Title;
            data.EngineSize = grpc.EngineSize;
            data.ManufacturingCell = grpc.ManufacturingCell;
            data.Trim = grpc.Trim;
            data.HandDrive = grpc.HandDrive;
            data.TubeAddOnType = grpc.TubeAddOnType;
            data.TubeAddOnFactor = (double?)grpc.TubeAddOnFactor;
            data.IsManualTerminal = grpc.IsManualTerminal;
            data.IsAllConnectorsSealed = grpc.IsAllConnectorsSealed;
            data.AlphaCode = grpc.AlphaCode;
            data.HarnessID = string.IsNullOrEmpty(grpc.HarnessID) ? null : Guid.Parse(grpc.HarnessID);
            data.CircuitOption = grpc.CircuitOption;
            data.HarnessName1 = grpc.HarnessName1;
            return data;
        }

        #endregion
        #region Harness

        public static HarnessGrpc FromEntity(this DbHarness entity)
        {
            HarnessGrpc data = new HarnessGrpc();

            data.Id = entity.HarnessId.ToString();

            data.HarnessName1 = entity.HarnessName1;
            data.SimilarHarnessName1 = entity.SimilarHarnessName1;
            data.HarnessIssue1 = entity.HarnessIssue1;
            data.SimilarHarnessIssue1 = entity.SimilarHarnessIssue1;

            Timestamp? harnessDate1 = null;

            if (entity.HarnessDate1.HasValue)
            {
                DateTime dateTime = entity.HarnessDate1.Value.ToUniversalTime();

                harnessDate1 = Timestamp.FromDateTime(dateTime);
            }

            data.HarnessName2 = entity.HarnessName2;
            data.SimilarHarnessName2 = entity.SimilarHarnessName2;
            data.HarnessIssue2 = entity.HarnessIssue2;
            data.SimilarHarnessIssue2 = entity.SimilarHarnessIssue2;

            Timestamp? harnessDate2 = null;

            if (entity.HarnessDate2.HasValue)
            {
                DateTime dateTime = entity.HarnessDate2.Value.ToUniversalTime();

                harnessDate2 =Timestamp.FromDateTime(dateTime);
            }

            data.HarnessDate2 = harnessDate2;

            data.FileVersion = entity.FileVersion.HasValue ? (double?)(double)entity.FileVersion.Value : null;

            data.Customer = entity.Customer;
            data.Site = entity.Site;
            data.Range = entity.Range;

            data.BoardLength = entity.BoardLength.HasValue ? (double?)(double)entity.BoardLength.Value : null;
            data.BoardWidth = entity.BoardWidth.HasValue ? (double?)(double)entity.BoardWidth.Value : null;

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
            data.TubeAddOnFactor = entity.TubeAddOnFactor.HasValue
                ? (double?)(double)entity.TubeAddOnFactor.Value : null;

            data.IsManualTerminal = entity.IsManualTerminal;
            data.IsAllConnectorsSealed = entity.IsAllConnectorsSealed;
            data.IsModule = entity.IsModule;
            data.IsPitchTableUsed = entity.IsPitchTableUsed;

            data.AlphaCode = entity.AlphaCode;
            data.AdditionalComments = entity.AdditionalComments;

            Timestamp? createdDate = null;

            if (entity.CreatedDate.HasValue)
            {
                DateTime dateTime = entity.CreatedDate.Value.ToUniversalTime();

                createdDate = Timestamp.FromDateTime(dateTime);
            }

            Timestamp? modifiedDate = null;

            if (entity.ModifiedDate.HasValue)
            {
                DateTime dateTime = entity.ModifiedDate.Value.ToUniversalTime();

                modifiedDate = Timestamp.FromDateTime(dateTime);
            }

            data.CreatedBy = entity.CreatedBy?.ToString();
            data.ModifiedBy = entity.ModifiedBy?.ToString();

            return data;
        }

        public static DbHarness ToEntity(this HarnessGrpc grpc)
        {
            DbHarness data = new DbHarness();

            data.HarnessId = string.IsNullOrEmpty(grpc.Id) ? Guid.NewGuid() : Guid.Parse(grpc.Id);

            data.HarnessName1 = grpc.HarnessName1;
            data.SimilarHarnessName1 = grpc.SimilarHarnessName1;
            data.HarnessIssue1 = grpc.HarnessIssue1;
            data.SimilarHarnessIssue1 = grpc.SimilarHarnessIssue1;

            data.HarnessDate1 = grpc.HarnessDate1?.ToDateTime();
            data.HarnessDate2 = grpc.HarnessDate2?.ToDateTime();

            data.HarnessName2 = grpc.HarnessName2;
            data.SimilarHarnessName2 = grpc.SimilarHarnessName2;
            data.HarnessIssue2 = grpc.HarnessIssue2;
            data.SimilarHarnessIssue2 = grpc.SimilarHarnessIssue2;

            data.FileVersion = (double?)grpc.FileVersion;

            data.Customer = grpc.Customer;
            data.Site = grpc.Site;
            data.Range = grpc.Range;

            data.BoardLength = (double?)grpc.BoardLength;
            data.BoardWidth = (double?)grpc.BoardWidth;

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
            data.TubeAddOnFactor = (double?)grpc.TubeAddOnFactor;

            data.IsManualTerminal = grpc.IsManualTerminal;
            data.IsAllConnectorsSealed = grpc.IsAllConnectorsSealed;
            data.IsModule = grpc.IsModule;
            data.IsPitchTableUsed = grpc.IsPitchTableUsed;

            data.AlphaCode = grpc.AlphaCode;
            data.AdditionalComments = grpc.AdditionalComments;

            data.CreatedDate = grpc.CreatedDate?.ToDateTime();
            data.ModifiedDate = grpc.ModifiedDate?.ToDateTime();

            data.CreatedBy = string.IsNullOrEmpty(grpc.CreatedBy) ? null : Guid.Parse(grpc.CreatedBy);
            data.ModifiedBy = string.IsNullOrEmpty(grpc.ModifiedBy) ? null : Guid.Parse(grpc.ModifiedBy);

            return data;
        }

        #endregion
    }
}