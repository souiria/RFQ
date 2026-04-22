using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rfq.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DsiBend",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bend = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiBend", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiBranchConfiguration",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchConfigurationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartNode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartRoute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartCoordinates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndNode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndRoute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndCoordinates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<double>(type: "float", nullable: false),
                    CircuitOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BundleDiameter = table.Column<double>(type: "float", nullable: false),
                    UserModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BendString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiBranchConfiguration", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiBranchConfigurationBendAssociation",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchConfigurationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiBranchConfigurationBendAssociation", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiBranchInsulation",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartNode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndNode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndRoute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PieceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsulationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diameter = table.Column<double>(type: "float", nullable: false),
                    CircuitOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsulationNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalculationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManualAmount = table.Column<double>(type: "float", nullable: false),
                    SplitValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoinNumber = table.Column<double>(type: "float", nullable: false),
                    AssemblyItemNumber = table.Column<double>(type: "float", nullable: false),
                    Layer = table.Column<double>(type: "float", nullable: false),
                    InsulationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartNumber3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WallThickness = table.Column<double>(type: "float", nullable: false),
                    NumberOfTurns = table.Column<double>(type: "float", nullable: false),
                    TurnsPerBreakout = table.Column<double>(type: "float", nullable: false),
                    TurnsPerBranch = table.Column<double>(type: "float", nullable: false),
                    DistanceBetweenItems = table.Column<double>(type: "float", nullable: false),
                    LongestDistance = table.Column<double>(type: "float", nullable: false),
                    DistanceFromConnector = table.Column<double>(type: "float", nullable: false),
                    TubeSelectionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TubeSelectionFactor = table.Column<double>(type: "float", nullable: false),
                    Cutback = table.Column<double>(type: "float", nullable: false),
                    IsConvoluted = table.Column<bool>(type: "bit", nullable: false),
                    IsSlit = table.Column<bool>(type: "bit", nullable: false),
                    ModuleSpecificData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiBranchInsulation", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiBranchInsulationThroughNode",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PieceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThroughOrder = table.Column<double>(type: "float", nullable: false),
                    ThroughNode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThroughRoute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsThroughFlag = table.Column<bool>(type: "bit", nullable: false),
                    HarnessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiBranchInsulationThroughNode", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiCavityMapping",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CavityMappingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CavityMapping = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiCavityMapping", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiCentreStrip",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WireName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StripLength = table.Column<double>(type: "float", nullable: false),
                    LengthChangeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LengthChangeValue = table.Column<double>(type: "float", nullable: false),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThroughOrder = table.Column<double>(type: "float", nullable: false),
                    HarnessID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiCentreStrip", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiCircuitOption",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CircuitOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiCircuitOption", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiComponent",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CavityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WireName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SequenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentTypeCode1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartNumber3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    CrossSectionalArea = table.Column<double>(type: "float", nullable: false),
                    IsSelectTerminal = table.Column<bool>(type: "bit", nullable: false),
                    IsSeal = table.Column<bool>(type: "bit", nullable: false),
                    IsPlugged = table.Column<bool>(type: "bit", nullable: false),
                    BlockNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentTypeCode2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsulationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SplitValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssemblyItemNumber = table.Column<double>(type: "float", nullable: false),
                    ColourCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfCavities = table.Column<double>(type: "float", nullable: false),
                    IsBackshell = table.Column<bool>(type: "bit", nullable: false),
                    WireOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiComponent", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiCompositeDetail",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompositeDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HarnessName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessIssue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessIssue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessDate1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HarnessName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessIssue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessIssue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessDate2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardLength = table.Column<double>(type: "float", nullable: false),
                    BoardWidth = table.Column<double>(type: "float", nullable: false),
                    Datum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Checker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inputter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DraftedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreparedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturingCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HandDrive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TubeAddOnType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TubeAddOnFactor = table.Column<double>(type: "float", nullable: false),
                    IsManualTerminal = table.Column<bool>(type: "bit", nullable: false),
                    IsAllConnectorsSealed = table.Column<bool>(type: "bit", nullable: false),
                    AlphaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CircuitOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiCompositeDetail", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiCompositeDetailCircuitOptionAssociation",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompositeDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CircuitOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiCompositeDetailCircuitOptionAssociation", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiCompositeOption",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompositeOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiCompositeOption", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiHarness",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HarnessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HarnessName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessIssue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessIssue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessDate1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HarnessName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessIssue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessIssue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessDate2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileVersion = table.Column<double>(type: "float", nullable: false),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardLength = table.Column<double>(type: "float", nullable: false),
                    BoardWidth = table.Column<double>(type: "float", nullable: false),
                    Datum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Checker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inputter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DraftedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreparedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturingCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HandDrive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TubeAddOnType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TubeAddOnFactor = table.Column<double>(type: "float", nullable: false),
                    IsManualTerminal = table.Column<bool>(type: "bit", nullable: false),
                    IsAllConnectorsSealed = table.Column<bool>(type: "bit", nullable: false),
                    DatumNode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRoute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsModule = table.Column<bool>(type: "bit", nullable: false),
                    AlphaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPitchTableUsed = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiHarness", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiHarnessScope",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HarnessScopeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HarnessName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessIssue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessIssue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScopeCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiHarnessScope", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiHarnessScopeScopeAssociation",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HarnessScopeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScopeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiHarnessScopeScopeAssociation", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiManualBomQuantity",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SplitValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<double>(type: "float", nullable: false),
                    HarnessID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiManualBomQuantity", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiMidWireComponent",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WireName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MidWireOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cavity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThroughOrder = table.Column<double>(type: "float", nullable: false),
                    HarnessID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiMidWireComponent", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiModuleChildDetail",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCoreModule = table.Column<bool>(type: "bit", nullable: false),
                    HarnessName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessIssue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessIssue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessDate1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HarnessName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessIssue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessIssue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessDate2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardLength = table.Column<double>(type: "float", nullable: false),
                    BoardWidth = table.Column<double>(type: "float", nullable: false),
                    Datum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Checker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inputter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DraftedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreparedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturingCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HandDrive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TubeAddOnType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TubeAddOnFactor = table.Column<double>(type: "float", nullable: false),
                    IsManualTerminal = table.Column<bool>(type: "bit", nullable: false),
                    IsAllConnectorSealed = table.Column<bool>(type: "bit", nullable: false),
                    AlphaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiModuleChildDetail", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiModuleCompatibility",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleCode1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleCode2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiModuleCompatibility", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiMulticoreSpecification",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MulticoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsIncludedOnBom = table.Column<bool>(type: "bit", nullable: false),
                    IsIncludedOnChart = table.Column<bool>(type: "bit", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LengthChangeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LengthChangeValue = table.Column<double>(type: "float", nullable: false),
                    OuterSheathCutBackAtEnd1Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OuterSheathCutBackAtEnd1Value = table.Column<double>(type: "float", nullable: false),
                    OuterSheathCutBackAtEnd2Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OuterSheathCutBackAtEnd2Value = table.Column<double>(type: "float", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSheathed = table.Column<bool>(type: "bit", nullable: false),
                    UserModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssemblyItemNumber = table.Column<double>(type: "float", nullable: false),
                    ParentMulticoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MulticoreOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentMulticoreOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnmodifiedMulticoreLength = table.Column<double>(type: "float", nullable: false),
                    ModifiedMulticoreLength = table.Column<double>(type: "float", nullable: false),
                    PartNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartNumber3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiMulticoreSpecification", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiPinMapping",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PinMappingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Node1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Node2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessIssue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessIssue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Separator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiPinMapping", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiPinMappingCavityMappingAssociation",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PinMappingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CavityMappingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MappingNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiPinMappingCavityMappingAssociation", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiScope",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiScope", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiSupplier",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subsidiary_Id = table.Column<long>(type: "bigint", nullable: true),
                    Buyer_Id = table.Column<long>(type: "bigint", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alternate_Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    J_Supplier = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiSupplier", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiTransformedCompositeDetail",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HarnessName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessIssue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessIssue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessDate1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HarnessName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessIssue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessIssue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessDate2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardLength = table.Column<double>(type: "float", nullable: false),
                    BoardWidth = table.Column<double>(type: "float", nullable: false),
                    Datum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Checker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inputter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DraftedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreparedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturingCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HandDrive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TubeAddOnType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TubeAddOnFactor = table.Column<double>(type: "float", nullable: false),
                    IsManualTerminal = table.Column<bool>(type: "bit", nullable: false),
                    IsAllConnectorsSealed = table.Column<bool>(type: "bit", nullable: false),
                    AlphaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CircuitOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiTransformedCompositeDetail", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiTransformedHarness",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HarnessName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessIssue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessIssue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessDate1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HarnessName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessIssue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessIssue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessDate2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileVersion = table.Column<double>(type: "float", nullable: false),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardLength = table.Column<double>(type: "float", nullable: false),
                    BoardWidth = table.Column<double>(type: "float", nullable: false),
                    Datum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Checker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inputter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DraftedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreparedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturingCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HandDrive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TubeAddOnType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TubeAddOnFactor = table.Column<double>(type: "float", nullable: false),
                    IsManualTerminal = table.Column<bool>(type: "bit", nullable: false),
                    IsAllConnectorsSealed = table.Column<bool>(type: "bit", nullable: false),
                    DatumNode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRoute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsModule = table.Column<bool>(type: "bit", nullable: false),
                    AlphaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPitchTableUsed = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiTransformedHarness", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiTransformedModuleChildDetail",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCoreModule = table.Column<bool>(type: "bit", nullable: true),
                    HarnessName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessIssue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessIssue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessDate1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HarnessName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessIssue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimilarHarnessIssue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessDate2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardLength = table.Column<double>(type: "float", nullable: false),
                    BoardWidth = table.Column<double>(type: "float", nullable: false),
                    Datum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Checker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inputter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DraftedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreparedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturingCell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HandDrive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TubeAddOnType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TubeAddOnFactor = table.Column<double>(type: "float", nullable: false),
                    IsManualTerminal = table.Column<bool>(type: "bit", nullable: false),
                    IsAllConnectorSealed = table.Column<bool>(type: "bit", nullable: false),
                    AlphaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiTransformedModuleChildDetail", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiUnitOfMeasure",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subsidiary_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiUnitOfMeasure", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiWireMulticoreMarker",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColourCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spacing = table.Column<double>(type: "float", nullable: true),
                    HarnessID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiWireMulticoreMarker", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiWireSpecification",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WireName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompositeOptionString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WireType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrossSectionalArea = table.Column<double>(type: "float", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MulticoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End1NodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End1Route = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End1Cavity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End1MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End2NodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End2Route = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End2Cavity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End2MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsIncludedOnBom = table.Column<bool>(type: "bit", nullable: false),
                    IsIncludedOnChart = table.Column<bool>(type: "bit", nullable: false),
                    WireTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WireNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WireLengthChangeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WireLengthChangeValue = table.Column<double>(type: "float", nullable: false),
                    AssemblyItemNumber = table.Column<double>(type: "float", nullable: false),
                    MulticoreOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnmodifiedWireLength = table.Column<double>(type: "float", nullable: false),
                    ModifiedWireLength = table.Column<double>(type: "float", nullable: false),
                    CutbackAtEnd1 = table.Column<double>(type: "float", nullable: false),
                    CutbackAtEnd2 = table.Column<double>(type: "float", nullable: false),
                    PartNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartNumber3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Signal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarnessID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiWireSpecification", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "DsiWireThroughNode",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WireName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThroughOrder = table.Column<double>(type: "float", nullable: false),
                    ThroughNode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThroughRoute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsThroughFlag = table.Column<bool>(type: "bit", nullable: false),
                    HarnessID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsiWireThroughNode", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "RfqNprRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerRfqNo = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    CustomerCode = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    RequestID = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    OriginatorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeadlineDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReasonDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaterialNumber = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    MaterialDescription = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MaterialTypeDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerPartNumber = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    SupplierPartNumber = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    SEWSEUnitOfMeasurement = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SupplierGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SupplierDetailComments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    QtyPerVehicle = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VehicleTotalQuantity = table.Column<int>(type: "int", nullable: true),
                    IsSampleDataRequired = table.Column<bool>(type: "bit", nullable: false),
                    NPRRaisedRemarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ManufacturingSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCustomerNominatedSupplier = table.Column<bool>(type: "bit", nullable: false),
                    IsCustomerNominatedMaterial = table.Column<bool>(type: "bit", nullable: false),
                    PlatformName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProgramName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SuggestedManufacturerGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AssociatedParts = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NPRUploadSeqNo = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Closed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampleSiteDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfqNprRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RfqReason",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfqReason", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "RfqProject",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfqNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "((('SEWS-'+right(CONVERT([varchar](4),datepart(year,[CreatedDate])),(2))) + '-027-')+right('000000'+CONVERT([varchar](6),[RowId]),(6)))", stored: true),
                    CustomerBusinessUnitGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerLocationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfqReasonId = table.Column<int>(type: "int", nullable: true),
                    RfqResponseDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CarModelGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VehicleVolume = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfqProject", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_RfqProject_RfqReason_RfqReasonId",
                        column: x => x.RfqReasonId,
                        principalTable: "RfqReason",
                        principalColumn: "RowId");
                });

            migrationBuilder.CreateTable(
                name: "RfqDrawingPartNumber",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfqId = table.Column<long>(type: "bigint", nullable: false),
                    OriginalPartNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalPartNumberPrice = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    SwappedPartNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SwappedPartNumberPrice = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: true),
                    PriceSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsExactMatch = table.Column<bool>(type: "bit", nullable: true),
                    IsSwapped = table.Column<bool>(type: "bit", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SumitomoPartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierPartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NprId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerPartNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NprRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfqDrawingPartNumber", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_RfqDrawingPartNumber_RfqProject_RfqId",
                        column: x => x.RfqId,
                        principalTable: "RfqProject",
                        principalColumn: "RowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RfqNotes",
                columns: table => new
                {
                    RowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RfqId = table.Column<long>(type: "bigint", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfqNotes", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_RfqNotes_RfqProject_RfqId",
                        column: x => x.RfqId,
                        principalTable: "RfqProject",
                        principalColumn: "RowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfqDrawingPartNumber_RfqId",
                table: "RfqDrawingPartNumber",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_RfqNotes_RfqId",
                table: "RfqNotes",
                column: "RfqId");

            migrationBuilder.CreateIndex(
                name: "IX_RfqProject_RfqReasonId",
                table: "RfqProject",
                column: "RfqReasonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DsiBend");

            migrationBuilder.DropTable(
                name: "DsiBranchConfiguration");

            migrationBuilder.DropTable(
                name: "DsiBranchConfigurationBendAssociation");

            migrationBuilder.DropTable(
                name: "DsiBranchInsulation");

            migrationBuilder.DropTable(
                name: "DsiBranchInsulationThroughNode");

            migrationBuilder.DropTable(
                name: "DsiCavityMapping");

            migrationBuilder.DropTable(
                name: "DsiCentreStrip");

            migrationBuilder.DropTable(
                name: "DsiCircuitOption");

            migrationBuilder.DropTable(
                name: "DsiComponent");

            migrationBuilder.DropTable(
                name: "DsiCompositeDetail");

            migrationBuilder.DropTable(
                name: "DsiCompositeDetailCircuitOptionAssociation");

            migrationBuilder.DropTable(
                name: "DsiCompositeOption");

            migrationBuilder.DropTable(
                name: "DsiHarness");

            migrationBuilder.DropTable(
                name: "DsiHarnessScope");

            migrationBuilder.DropTable(
                name: "DsiHarnessScopeScopeAssociation");

            migrationBuilder.DropTable(
                name: "DsiManualBomQuantity");

            migrationBuilder.DropTable(
                name: "DsiMidWireComponent");

            migrationBuilder.DropTable(
                name: "DsiModuleChildDetail");

            migrationBuilder.DropTable(
                name: "DsiModuleCompatibility");

            migrationBuilder.DropTable(
                name: "DsiMulticoreSpecification");

            migrationBuilder.DropTable(
                name: "DsiPinMapping");

            migrationBuilder.DropTable(
                name: "DsiPinMappingCavityMappingAssociation");

            migrationBuilder.DropTable(
                name: "DsiScope");

            migrationBuilder.DropTable(
                name: "DsiSupplier");

            migrationBuilder.DropTable(
                name: "DsiTransformedCompositeDetail");

            migrationBuilder.DropTable(
                name: "DsiTransformedHarness");

            migrationBuilder.DropTable(
                name: "DsiTransformedModuleChildDetail");

            migrationBuilder.DropTable(
                name: "DsiUnitOfMeasure");

            migrationBuilder.DropTable(
                name: "DsiWireMulticoreMarker");

            migrationBuilder.DropTable(
                name: "DsiWireSpecification");

            migrationBuilder.DropTable(
                name: "DsiWireThroughNode");

            migrationBuilder.DropTable(
                name: "RfqDrawingPartNumber");

            migrationBuilder.DropTable(
                name: "RfqNotes");

            migrationBuilder.DropTable(
                name: "RfqNprRequest");

            migrationBuilder.DropTable(
                name: "RfqProject");

            migrationBuilder.DropTable(
                name: "RfqReason");
        }
    }
}
