using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CDb.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "Generated file with wrong format for new object creation according to iDesign rules, even if the source code is conformant...")]

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    Table = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClipTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentAggregation",
                columns: table => new
                {
                    ChildrenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentAggregation", x => new { x.ChildrenId, x.ParentsId });
                });

            migrationBuilder.CreateTable(
                name: "ComponentReplacements",
                columns: table => new
                {
                    DbComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplacedComponentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentReplacements", x => new { x.DbComponentId, x.ReplacedComponentsId });
                });

            migrationBuilder.CreateTable(
                name: "CoverTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrimpingProcessTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimpingProcessTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiscellaneousComponentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiscellaneousComponentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartNumberType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemperatureRanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemperatureRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    IsCustom = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureRanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerminalFamilies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterproofTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterproofTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WireProtectionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WireProtectionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WireTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WireTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileNames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileNames_FileTypes_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentContacts",
                columns: table => new
                {
                    ComponentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentContacts", x => new { x.ComponentsId, x.ContactsId });
                    table.ForeignKey(
                        name: "FK_ComponentContacts_Persons_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartnerType = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SupervisorPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partners_Persons_ContactPersonId",
                        column: x => x.ContactPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partners_Persons_SupervisorPersonId",
                        column: x => x.SupervisorPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComponentTags",
                columns: table => new
                {
                    ComponentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentTags", x => new { x.ComponentsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ComponentTags_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Color = table.Column<int>(type: "int", nullable: false),
                    WireCount = table.Column<int>(type: "int", nullable: false),
                    WireCountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Length = table.Column<decimal>(type: "decimal(8,1)", nullable: false),
                    IsShielded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cables_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClipTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TieType = table.Column<int>(type: "int", nullable: false),
                    DimensionCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ThicknessCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Length = table.Column<decimal>(type: "decimal(8,1)", nullable: false, defaultValue: 0.0m),
                    IsDoubleHarness = table.Column<bool>(type: "bit", nullable: false),
                    ClipOrientationStart = table.Column<int>(type: "int", nullable: false),
                    ClipOrientationEnd = table.Column<int>(type: "int", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clips_ClipTypes_ClipTypeId",
                        column: x => x.ClipTypeId,
                        principalTable: "ClipTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clips_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Covers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CoverTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Diameter = table.Column<decimal>(type: "decimal(8,1)", nullable: false, defaultValue: 0.0m),
                    Length = table.Column<decimal>(type: "decimal(8,1)", nullable: false, defaultValue: 0.0m),
                    Width = table.Column<decimal>(type: "decimal(8,1)", nullable: false, defaultValue: 0.0m),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasNoiseDampening = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsTearable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsPreCut = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Covers_CoverTypes_CoverTypeId",
                        column: x => x.CoverTypeId,
                        principalTable: "CoverTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Covers_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Diodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amperage = table.Column<decimal>(type: "decimal(5,1)", nullable: false, defaultValue: 0.0m),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diodes_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Eyelets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudSize = table.Column<decimal>(type: "decimal(8,1)", nullable: false, defaultValue: 0.0m),
                    Thickness = table.Column<decimal>(type: "decimal(8,1)", nullable: false, defaultValue: 0.0m),
                    Angle = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsWaterproof = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsCr6Free = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatingType = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eyelets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eyelets_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FuseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amperage = table.Column<decimal>(type: "decimal(8,1)", nullable: false, defaultValue: 0.0m),
                    Description = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fuses_FuseTypes_FuseTypeId",
                        column: x => x.FuseTypeId,
                        principalTable: "FuseTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fuses_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Grommets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grommets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grommets_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Housings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    RowCount = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Housings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Housings_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MiscellaneousComponents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MiscellaneousComponentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dimension = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Color = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiscellaneousComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiscellaneousComponents_MiscellaneousComponentTypes_MiscellaneousComponentTypeId",
                        column: x => x.MiscellaneousComponentTypeId,
                        principalTable: "MiscellaneousComponentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiscellaneousComponents_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Plugs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Diameter = table.Column<decimal>(type: "decimal(8,1)", nullable: false, defaultValue: 0.0m),
                    Color = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plugs_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Relays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amperage = table.Column<decimal>(type: "decimal(8,1)", nullable: false, defaultValue: 0.0m),
                    Description = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Specification = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relays_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Seals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Diameter = table.Column<decimal>(type: "decimal(8,1)", nullable: false, defaultValue: 0.0m),
                    Color = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seals_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shields_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Supports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supports_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TerminalSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TerminalFamilyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TerminalSize_TerminalFamilies_TerminalFamilyId",
                        column: x => x.TerminalFamilyId,
                        principalTable: "TerminalFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sleeves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Diameter = table.Column<decimal>(type: "decimal(8,1)", nullable: false, defaultValue: 0.0m),
                    Length = table.Column<decimal>(type: "decimal(8,1)", nullable: false, defaultValue: 0.0m),
                    WaterproofTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sleeves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sleeves_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sleeves_WaterproofTypes_WaterproofTypeId",
                        column: x => x.WaterproofTypeId,
                        principalTable: "WaterproofTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WireProtections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WireProtectionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    TapeWidth = table.Column<decimal>(type: "decimal(5,1)", nullable: false, defaultValue: 0.0m),
                    TubeDiameter = table.Column<decimal>(type: "decimal(5,1)", nullable: false, defaultValue: 0.0m),
                    Specification = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WireProtections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WireProtections_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WireProtections_WireProtectionTypes_WireProtectionTypeId",
                        column: x => x.WireProtectionTypeId,
                        principalTable: "WireProtectionTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Wires",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WireTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WireSection = table.Column<decimal>(type: "decimal(5,1)", nullable: false, defaultValue: 0.0m),
                    WireCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Flexibility = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    InsulationThickness = table.Column<decimal>(type: "decimal(5,1)", nullable: false, defaultValue: 0.0m),
                    BendingDiameter = table.Column<decimal>(type: "decimal(5,1)", nullable: false, defaultValue: 0.0m),
                    Color = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PlatingType = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wires_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Wires_WireTypes_WireTypeId",
                        column: x => x.WireTypeId,
                        principalTable: "WireTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComponentFileNames",
                columns: table => new
                {
                    ComponentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileNamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentFileNames", x => new { x.ComponentsId, x.FileNamesId });
                    table.ForeignKey(
                        name: "FK_ComponentFileNames_FileNames_FileNamesId",
                        column: x => x.FileNamesId,
                        principalTable: "FileNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentPartners",
                columns: table => new
                {
                    ComponentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartnersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentPartners", x => new { x.ComponentsId, x.PartnersId });
                    table.ForeignKey(
                        name: "FK_ComponentPartners_Partners_PartnersId",
                        column: x => x.PartnersId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Connectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WaterproofTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MatingType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CavitySize = table.Column<decimal>(type: "decimal(8,1)", nullable: false),
                    CavityCount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsHybrid = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsModule = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TerminalFamilyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TerminalSizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DbTerminalFamilyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DbTerminalSizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Connectors_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Connectors_TerminalFamilies_DbTerminalFamilyId",
                        column: x => x.DbTerminalFamilyId,
                        principalTable: "TerminalFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Connectors_TerminalFamilies_TerminalFamilyId",
                        column: x => x.TerminalFamilyId,
                        principalTable: "TerminalFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Connectors_TerminalSize_DbTerminalSizeId",
                        column: x => x.DbTerminalSizeId,
                        principalTable: "TerminalSize",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Connectors_TerminalSize_TerminalSizeId",
                        column: x => x.TerminalSizeId,
                        principalTable: "TerminalSize",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Connectors_WaterproofTypes_WaterproofTypeId",
                        column: x => x.WaterproofTypeId,
                        principalTable: "WaterproofTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubAssemblies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Function = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    TerminalFamilyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TerminalSizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Color = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubAssemblies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubAssemblies_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubAssemblies_TerminalFamilies_TerminalFamilyId",
                        column: x => x.TerminalFamilyId,
                        principalTable: "TerminalFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubAssemblies_TerminalSize_TerminalSizeId",
                        column: x => x.TerminalSizeId,
                        principalTable: "TerminalSize",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Terminals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<int>(type: "int", nullable: false),
                    SheetNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Issue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,1)", precision: 8, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserField5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicSymbol = table.Column<bool>(type: "bit", nullable: true),
                    InDb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PfReferencePsa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedToLatestDrawing = table.Column<bool>(type: "bit", nullable: true),
                    UpdateInCaphDb = table.Column<bool>(type: "bit", nullable: true),
                    StatusPv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusBrut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbUpdatedPv = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Validated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReplacement = table.Column<bool>(type: "bit", nullable: false),
                    TemperatureLow = table.Column<int>(type: "int", nullable: false),
                    TemperatureHigh = table.Column<int>(type: "int", nullable: false),
                    TemperatureRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TerminalFamilyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerminalSizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WireTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CrimpingIssues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterproofTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatingType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PlatingType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DbTerminalFamilyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DbTerminalSizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terminals_TemperatureRanges_TemperatureRangeId",
                        column: x => x.TemperatureRangeId,
                        principalTable: "TemperatureRanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Terminals_TerminalFamilies_DbTerminalFamilyId",
                        column: x => x.DbTerminalFamilyId,
                        principalTable: "TerminalFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Terminals_TerminalFamilies_TerminalFamilyId",
                        column: x => x.TerminalFamilyId,
                        principalTable: "TerminalFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Terminals_TerminalSize_DbTerminalSizeId",
                        column: x => x.DbTerminalSizeId,
                        principalTable: "TerminalSize",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Terminals_TerminalSize_TerminalSizeId",
                        column: x => x.TerminalSizeId,
                        principalTable: "TerminalSize",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Terminals_WaterproofTypes_WaterproofTypeId",
                        column: x => x.WaterproofTypeId,
                        principalTable: "WaterproofTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Terminals_WireTypes_WireTypeId",
                        column: x => x.WireTypeId,
                        principalTable: "WireTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ClipTypes",
                columns: new[] { "Id", "Code", "Description", "IsActive" },
                values: new object[,]
                {
                    { new Guid("0f9d1f7c-2499-414c-abe2-c4a86a2461f8"), "TAPEWRAP", "Tape Wrap", false },
                    { new Guid("76ad0414-d24a-4884-b76e-51317470badf"), "TIEWRAP", "Tie Wrap", false },
                    { new Guid("821ed34e-3b4d-4d34-9207-662ddc7f9573"), "DOUBLE", "Double", false },
                    { new Guid("aad59fb5-4169-464a-a8fb-c3f512e1d468"), "SPT", "SPT", false },
                    { new Guid("b3038713-fea7-4390-8656-60d32f3e2101"), "ROUNDSHAPED", "Round-Shaped", false },
                    { new Guid("d48040e2-a0f9-44a4-9b4c-451a48657297"), "OVALSHAPED", "Oval-Shaped", false },
                    { new Guid("ede18a04-94ec-4086-8bc1-8af8553bbf5b"), "UNKNOWN", "Unknown", false }
                });

            migrationBuilder.InsertData(
                table: "CoverTypes",
                columns: new[] { "Id", "Code", "Description", "IsActive" },
                values: new object[,]
                {
                    { new Guid("0a3aefca-9ea0-4615-b960-61ee394025e1"), "Type2", "Type 2", false },
                    { new Guid("365c57f6-99b1-40a7-b2c7-780fcfe98b2f"), "Type0", "Type 0", false },
                    { new Guid("373d634d-9b26-4beb-9557-aea345f9a39b"), "Type4", "Type 4", false },
                    { new Guid("44985f7a-9bad-45aa-9c57-da426da40d29"), "Unknown", "Unknown", false },
                    { new Guid("4a766121-2ca0-484d-a3c3-fb43b88b2e7a"), "Type3", "Type 3", false },
                    { new Guid("b802d262-98d7-492d-9017-adfb83c13283"), "Type1", "Type 1", false }
                });

            migrationBuilder.InsertData(
                table: "CrimpingProcessTypes",
                columns: new[] { "Id", "Code", "Description", "IsActive" },
                values: new object[,]
                {
                    { new Guid("568fd11b-6aa7-4951-987c-96e3ce3eccf3"), "Usw", "USW", false },
                    { new Guid("70a6f93e-5fd7-4a7e-9877-8c59c56e252a"), "TubularBarrel", "Tubular barrel", false },
                    { new Guid("b1adc998-66b4-4e21-add4-adfae8e027bc"), "OpenBarrel", "Open barrel", false },
                    { new Guid("d48a67f0-716d-485b-858a-47fecb598133"), "Unknown", "Unknown", false }
                });

            migrationBuilder.InsertData(
                table: "FileTypes",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("16e3d15d-99a1-450c-856c-771f522921d4"), "Component drawing", false, "ComponentDrawing" },
                    { new Guid("17d27e0b-cf12-41bf-b28d-1a2433f3d61b"), "Generic", false, "Generic" },
                    { new Guid("39dce531-aa68-4baf-9063-f41bcfae5da5"), "Catalog", false, "Catalog" },
                    { new Guid("4e0d0300-416f-4f2f-8cd4-56cd65aac632"), "Component image", false, "ComponentImage" },
                    { new Guid("832cecfc-eb83-484e-b72d-bb3164a86b35"), "Component symbol", false, "ComponentSymbol" },
                    { new Guid("b1cea2fa-23b8-4986-8f17-40a1107ab305"), "Drawing", false, "Drawing" },
                    { new Guid("f36a13d8-775f-4e46-a4c7-b4fc2a156760"), "User Manual", false, "UserManual" }
                });

            migrationBuilder.InsertData(
                table: "FuseTypes",
                columns: new[] { "Id", "Code", "Description", "IsActive" },
                values: new object[,]
                {
                    { new Guid("00d75012-1a40-47db-889e-f5d8c5ddc43c"), "MaxiCompactTypeL", "Maxi compact (maxi comp.L)", false },
                    { new Guid("121dd790-82f7-4bd8-aaa4-e18c3e7f39b5"), "ATO", "Blade fuse (ato)", false },
                    { new Guid("15c8f392-5f35-4b89-b481-fb968418f390"), "JCASE", "Female contact fuse (jcase)", false },
                    { new Guid("20fdf8bc-2123-4404-9710-50b7b36ffd9e"), "MEGACOMPACT", "Screwed fuse (mega comp.)", false },
                    { new Guid("55363161-8b9f-4ac6-96ed-509d43aa4b12"), "Unknown", "Unknown", false },
                    { new Guid("784ab3f6-e8a7-4b91-b86d-b272e3fd601a"), "MicroFuse3", "Micro fuse 3", false },
                    { new Guid("7b592938-45e2-4783-9fb6-0c4ca70e16b0"), "MAXI", "Blade fuse (maxi)", false },
                    { new Guid("8b4d565f-3095-42f1-98d6-f930ce3f509a"), "M8CompactTYPEM", "M8C", false },
                    { new Guid("8d33a867-b47d-4208-ac04-806967b71093"), "MEGA", "Screwed fuse (mega)", false },
                    { new Guid("957c2cdc-ebad-47b7-af1f-7f76c6198573"), "Mini", "Blade fuse (mini)", false },
                    { new Guid("a439752a-dedd-422a-b419-17fb17d39897"), "MicroFuse2", "Micro fuse 2", false },
                    { new Guid("a87b09a9-52a5-42bc-a8c1-de115284035e"), "MIDI", "Screwed fuse (midi)", false },
                    { new Guid("f213e762-3b2d-401f-9454-ac7292f3f5ea"), "JCASELP", "Female contact fuse (jcaseLP)", false },
                    { new Guid("f47cafac-c871-4121-9b2d-12951c99cf1b"), "MCASEPLUS", "Female contact fuse (mcase+)", false }
                });

            migrationBuilder.InsertData(
                table: "MaterialTypes",
                columns: new[] { "Id", "Code", "Description", "IsActive" },
                values: new object[,]
                {
                    { new Guid("0adde622-15e4-415e-83a3-bcf6ab2aad19"), "Al", "Aluminum", false },
                    { new Guid("2ec49bc3-9d62-4b4d-9c97-88975c0437d7"), "Unknown", "Unknown", false },
                    { new Guid("51a919dd-6717-4cb4-8c2d-010de737877b"), "Au", "Gold", false },
                    { new Guid("535f1668-f550-4a9e-aaa8-537a926f6ded"), "CarbonFiber", "CarbonFiber", false },
                    { new Guid("5560e408-ce74-4ddc-9a28-ed9434995377"), "Cu", "Copper", false },
                    { new Guid("7d764f3a-ddee-4174-b960-3a847ccee647"), "Plastic", "Plastic", false },
                    { new Guid("928c5cef-cf01-47a8-b2ff-b64ddf1cdd4d"), "Steel", "Steel", false },
                    { new Guid("de8c40a8-b81a-44fe-b01c-f8761fa92182"), "Sn", "Tin", false },
                    { new Guid("e075ac6a-9e3f-4511-8f0a-fee00dd73601"), "GlassFiber", "GlassFiber", false },
                    { new Guid("e51967d2-74ca-4265-898a-b503c26bf4b3"), "Ag", "Silver", false }
                });

            migrationBuilder.InsertData(
                table: "MiscellaneousComponentTypes",
                columns: new[] { "Id", "Code", "Description", "IsActive" },
                values: new object[,]
                {
                    { new Guid("00310452-b96e-4f50-89aa-c9ee78bc6241"), "TestLabel", "TEST LABEL", true },
                    { new Guid("022b88d8-5400-4a0a-8520-76ab29960c4a"), "RelayBox", "RELAY BOX", true },
                    { new Guid("0a4482e4-90cb-4b88-a15e-2eb9df932925"), "WireClamp", "WIRE CLAMP", true },
                    { new Guid("0a80307e-c1ef-4bac-abf8-9abbdb605b0b"), "FuseRelayBox", "FUSE/RELAY BOX", true },
                    { new Guid("0bede88d-34ed-4344-b5d5-37f0ab6b3068"), "TieWrap", "TIE WRAP", true },
                    { new Guid("0e0671fd-a9c2-40cb-a66a-e4a3d32d8e0b"), "Unknown", "Unknown", true },
                    { new Guid("0f0a1c05-ffb8-41e9-a658-3fbc2503bbe3"), "TE", "TE", true },
                    { new Guid("101d1abc-c6be-4b41-992f-d1d5c76d71f4"), "ERFBBoxAssembly", "ERFB BOX ASSY", true },
                    { new Guid("1223ee61-3c70-498a-a51d-bf47b1c30bab"), "PlasticBag", "PLASTIC BAG", true },
                    { new Guid("13a935ca-6359-4e7b-a66f-29de83ba4076"), "Grid", "GRID", true },
                    { new Guid("1701566b-bcdc-4195-a68f-30fe6eb1b1d4"), "BECB", "BECB", true },
                    { new Guid("2595f65c-023b-4f6b-9210-497367aca706"), "SpotTape", "SPOT TAPE", true },
                    { new Guid("26e57134-6a1f-4a18-99ed-3b1c462cff61"), "PlasticClamp", "PLASTIC CLAMP", true },
                    { new Guid("28c4821d-ae61-439c-a286-29e1cdc54070"), "Shell", "SHELL", true },
                    { new Guid("2bb13055-59fa-426b-9d57-25e5347288dc"), "WarningLabel", "WARNING LABEL", true },
                    { new Guid("38d67a79-1b8d-4694-843e-9228ff1a7aa2"), "Ferrule", "FERRULE", true },
                    { new Guid("4037e78b-2923-4789-843b-09ab426885db"), "BFAV", "BFAV", true },
                    { new Guid("4cb83857-723d-48da-abca-a27aabd4b376"), "IdentificationLabel", "IDENT. LABEL", true },
                    { new Guid("4f1f8dd2-23c3-4820-b68c-739827b2ef42"), "FoamBox", "FOAM BLOCK", true },
                    { new Guid("5db364bc-eeda-4a36-a108-7f0a31adbc50"), "Lock", "LOCK", true },
                    { new Guid("61c452cb-14fb-4ac1-8f36-620947dd1712"), "AssyClip", "POSTICHE", true },
                    { new Guid("6598fcce-5c6d-48ea-9eaa-dc5ca15a43e9"), "Label", "LABEL", true },
                    { new Guid("67302079-2a01-48fd-84a1-48e8370108a9"), "STRAP", "STRAP", true },
                    { new Guid("6e298c27-79cb-4b9f-ac24-eab9f0261e58"), "PaperBubble", "PAPER BUBBLE", true },
                    { new Guid("76229a19-0d0d-4594-a66d-a84450bc1898"), "UltrasonicWeld", "ULTRASONIC WELD", true },
                    { new Guid("78a309f0-0f12-4bae-9be1-debe7ae1fa6d"), "Nut", "NUT", true },
                    { new Guid("7ae3f1bf-597a-4d7e-ada3-bb1438f33f06"), "Ferrite", "FERRITE", true },
                    { new Guid("805435c0-2a2b-47e7-83c7-d3ba3cfc7034"), "Bracket", "BRACKET", true },
                    { new Guid("898e6a80-9fda-485d-89d8-fbc0ee86e419"), "AccessoryBox", "ACC BOX", true },
                    { new Guid("8c4a2c9a-53b9-403d-b664-a4fb6c1b49fd"), "Lever", "LEVER", true },
                    { new Guid("ae7cf68d-e91f-45d7-823d-58dc3129a1ab"), "BatteryHolder", "BAT FIXATION", true },
                    { new Guid("ae98b393-f62d-43d3-a087-a1f06685972b"), "BONN", "BONN", true },
                    { new Guid("b1f5b63b-6d03-4ecc-a899-12543fcfae07"), "RearHolder", "REAR HOLDER", true },
                    { new Guid("b9ccd291-581f-463f-b0bf-c459f7aafd6d"), "PEB", "PEB", true },
                    { new Guid("c0e89773-5ab1-4fb4-a585-c26cff2155b1"), "TPA", "TPA", true },
                    { new Guid("c223610f-e2f4-4e48-b84d-b790eb49a9f7"), "DoubleFaceTape", "DOUBLE FACE TAPE", true },
                    { new Guid("c2b2fcc1-e6b1-4cbe-a84b-b0b3c9ca6145"), "BubbleBag", "BUBBLE BAG", true },
                    { new Guid("c2ca150a-f465-4b87-b5df-e01bdad1953e"), "ProtectionLabel", "PROTECT. LABEL", true },
                    { new Guid("cf4db8f3-8be3-4ef1-be66-893fa1196fd9"), "PaperSheet", "PAPER SHEET", true },
                    { new Guid("d0c26c30-5841-4b9d-82a1-d8207964efd3"), "Screw", "SCREW", true },
                    { new Guid("d43d634c-e763-4832-8797-94f32637587f"), "CPA", "CPA", true },
                    { new Guid("d4db948b-2a1c-4050-bbb0-ef7db3053ced"), "FakraSubConnector", "FAKRA SUB CONNECTOR", true },
                    { new Guid("e934d33e-0e48-4e9f-ba5e-8e0d4c36b2ce"), "BEND", "BEND", true },
                    { new Guid("e9f08643-055d-4bbd-84f4-51fa33d941f9"), "OptionTape", "OPTION TAPE", true }
                });

            migrationBuilder.InsertData(
                table: "TemperatureRanges",
                columns: new[] { "Id", "IsCustom", "TemperatureHigh", "TemperatureLow", "TemperatureRange" },
                values: new object[,]
                {
                    { new Guid("2ee77793-836a-456c-8387-ace7c300c7d7"), false, 105, -40, "T4" },
                    { new Guid("3842b9d2-fe6a-4bd0-b0a2-468a48fb5f56"), false, 0, 0, "unknown" },
                    { new Guid("719b0379-72db-41b9-95fe-019d18070396"), false, 125, -55, "T5" },
                    { new Guid("a7c0d61f-8732-455b-af23-8215eff48a16"), false, 85, -40, "T3" },
                    { new Guid("dd8fdc91-72a3-4aaf-ab22-d27877bb0b0e"), false, 100, -10, "T1" },
                    { new Guid("f2b91ccb-5a55-4d28-95f1-ab4e4a2e25c1"), false, 85, -20, "T2" }
                });

            migrationBuilder.InsertData(
                table: "TypeCodes",
                columns: new[] { "Id", "Code", "IsActive" },
                values: new object[,]
                {
                    { new Guid("01bf13b0-75f5-4a31-b325-61bffa592e43"), "FRAM", true },
                    { new Guid("02d250e5-9130-42d1-84fb-c3750e04ba04"), "OTHER", true },
                    { new Guid("080daf76-420c-4b9a-aec9-46a6873e8064"), "PROT", true },
                    { new Guid("0c452a89-a5ee-45db-bfb7-2ba99b0eeda7"), "TEA7", true },
                    { new Guid("12cd3e52-5af1-4509-afd6-5d6a717246e3"), "PTCS", true },
                    { new Guid("1fc34695-b086-4632-bc8b-2570cd0b1d93"), "ETIQ", true },
                    { new Guid("20395f49-ce92-4488-a094-f9e45fdbb4c4"), "GAF", true },
                    { new Guid("31be2acc-0719-4397-9900-a9318b0e6f50"), "COVER", true },
                    { new Guid("387a3f41-1c19-4d68-baf9-3480f3c62ab6"), "JUN1", true },
                    { new Guid("3d2db8a6-8d96-4c83-ab5d-2ad16a566572"), "TIES", true },
                    { new Guid("3dceb200-3c4e-427c-b14e-625c71892e52"), "FLAG", true },
                    { new Guid("44827990-038a-4614-915a-6135df06f8c4"), "PLUG", true },
                    { new Guid("50457df4-4e32-48b0-81c7-f88a804fbe64"), "GSNA", true },
                    { new Guid("53f6a90c-6e77-4588-a812-f09946a23932"), "FELT", true },
                    { new Guid("5490b099-430b-456a-aa34-e968fa738c63"), "TAPE", true },
                    { new Guid("5731725d-7315-4706-b004-3f9ca2c2fc20"), "POE2", true },
                    { new Guid("5847ccf1-76eb-47f1-a4e8-5ad47ed5cf48"), "FOAM", true },
                    { new Guid("5d1da6cc-dfaf-47d4-bbd5-f6d555a24e6b"), "TAE6", true },
                    { new Guid("5ddeda8c-bff4-424b-905d-75963b9afa1d"), "CEYE", true },
                    { new Guid("65f5fcbc-e407-4a0c-8804-920b03c7e41f"), "ADHT", true },
                    { new Guid("6a8a2292-8240-4483-93c8-fb1bc087fb43"), "GSWA", true },
                    { new Guid("7253e933-4885-4fb9-98f7-d1c92f779123"), "NSLS", true },
                    { new Guid("73e28def-226a-425b-a2e0-c4557d48ea07"), "SAC", true },
                    { new Guid("78062ab1-cb85-4d6e-9417-0f5be7651792"), "CSUN", true },
                    { new Guid("8152f314-c906-4aa5-aa0b-7b9fda4627fc"), "N/A", true },
                    { new Guid("86daceea-502f-485c-a0fc-db1c609beeb4"), "TEA6", true },
                    { new Guid("8851efce-d175-4ef3-9ed5-7f35cc18ff6c"), "CSLA", true },
                    { new Guid("917d9f9b-ed86-4800-9217-712d17abe2e1"), "LOCK", true },
                    { new Guid("9d8f038d-bd2d-4468-9741-9d43e9edd38e"), "TWST", true },
                    { new Guid("9f48636f-fa97-4087-ad6f-968a33970b71"), "SEA2", true },
                    { new Guid("a08b5b0a-8a10-48ad-b2d1-9995bb9051fe"), "FUSS", true },
                    { new Guid("a32963fb-2680-4e47-b480-e7bae7a689fa"), "FIRE", true },
                    { new Guid("ab80f62c-3d56-46aa-9452-c00db643a3e1"), "HSSL", true },
                    { new Guid("ab86491a-dc0a-4034-aea0-646817a2dacd"), "WP", true },
                    { new Guid("adbfd83b-590c-4598-97da-31a134302a9d"), "NWP", true },
                    { new Guid("b1bb5a59-9f67-48ef-9fcf-9fe7060e8843"), "BCLI", true },
                    { new Guid("b1deb356-dbaa-4118-bac3-2c7d3d47aa5d"), "FUSN", true },
                    { new Guid("b5d9ad2f-066e-48b8-9ac0-a97dce907664"), "GBWA", true },
                    { new Guid("b675bfc9-2646-4a4f-9b8c-5b437a7354f9"), "MNWP", true },
                    { new Guid("b67ea2c3-015f-43cb-8aad-dffa1601aae8"), "SEA3", true },
                    { new Guid("b8fdb7a1-6d8c-443a-be42-1c7261ecc1c4"), "RELA", true },
                    { new Guid("bd266383-abfd-464f-bf7d-e55e95cabd32"), "HOOD", true },
                    { new Guid("c4a20890-a8bd-4c21-b2b4-f0537bbd6d17"), "CCLI", true },
                    { new Guid("c79cd00f-fb51-4fbf-803c-4653f9fac13d"), "TEA5", true },
                    { new Guid("c9fa754a-1885-4efa-b7f2-fb3eda772865"), "HLSL", true },
                    { new Guid("e228aba9-30c7-450d-ae9a-c3ac511254d1"), "NOWP", true },
                    { new Guid("ecbdeb6e-0998-4057-a323-7543876a887d"), "slaby", true },
                    { new Guid("f5e4cb6b-49bc-42c2-a6cb-07ed9f47d771"), "BOX", true },
                    { new Guid("f78f4a16-801f-4fa5-9b8d-9454ed904e1c"), "CSEP", true },
                    { new Guid("fb05d3e8-b244-472a-831d-538ac91f3bea"), "SEA1", true }
                });

            migrationBuilder.InsertData(
                table: "WaterproofTypes",
                columns: new[] { "Id", "Code", "Description", "IsActive" },
                values: new object[,]
                {
                    { new Guid("22c70a82-1612-48ae-a034-1bb301b45f66"), "Yes", "W/P", true },
                    { new Guid("878941ff-5994-4a08-8ac1-3aecbfc1de03"), "Grommet", "W/P P", true },
                    { new Guid("8a3de44b-fe51-4db6-9c18-fff862361322"), "SingleSeal", "W/P S/P", true },
                    { new Guid("952fd02e-1fcc-4bf1-b371-96e99fde3392"), "Undefined", "Undefined", true },
                    { new Guid("acfa8a66-8ac9-445e-a047-675e63b07445"), "Gel", "W/P GEL", true },
                    { new Guid("eb0614a6-0a78-4d9f-831d-f3336c53cccb"), "No", "", true }
                });

            migrationBuilder.InsertData(
                table: "WireProtectionTypes",
                columns: new[] { "Id", "Code", "Description", "IsActive" },
                values: new object[,]
                {
                    { new Guid("004c2b6f-1bfd-46cc-9f96-a90d00e2b393"), "DuctSealed", "DUCT SEALED", true },
                    { new Guid("05ade2ab-e073-4ca7-861e-55e4338f1180"), "CorrugateTube", "CORRUGATE TUBE", true },
                    { new Guid("28741e29-6348-4c19-94de-c16aa718acf4"), "PvcTube", "PVC TUBE", true },
                    { new Guid("2dd29272-2d11-4991-945a-302fc2c975bf"), "ScrollPvc", "SCROLL PVC", true },
                    { new Guid("333d06c0-1352-4ea8-b875-3fe9db7f89d2"), "NotApplicable", "Not applicable", true },
                    { new Guid("3d3ca329-0048-4b01-9c79-ae7d7918acdf"), "None", "", true },
                    { new Guid("44c3d3aa-4fdd-4f2c-8d60-6c1ee1ca1c77"), "Felt", "FELT", true },
                    { new Guid("47015b1a-96b6-4767-a3bf-da717b76eef4"), "CottonTape", "COTTON TAPE", true },
                    { new Guid("47ad2da4-3583-4296-97d8-708201a27e8f"), "FlexGuard", "FLEX GUARD", true },
                    { new Guid("4b266cd9-068f-41a2-9100-3563472d1f97"), "WovenSleeve", "WOVEN SLEEVE", true },
                    { new Guid("548d1f0e-7860-47e9-bfa6-1105477954d9"), "TwistedTube", "TWISTED TUBE", true },
                    { new Guid("58e2af56-2d09-4dbd-b9a3-b407ff12534e"), "GaineScroll", "GAINE SCROLL", true },
                    { new Guid("5fb6e68f-2d1d-4dbc-bc85-4d52b23a06b4"), "SmoothTube", "SMOOTH TUBE", true },
                    { new Guid("601ce685-0247-4ee1-ad2c-32242b43fb6b"), "PlasticCloth", "PLASTIC CLOTH", true },
                    { new Guid("6ff03a3c-c68d-40b6-a348-a5f74b8db227"), "PvcSheet", "PVC SHEET", true },
                    { new Guid("769e55c9-d3fc-4b02-92b1-2b847135f1d6"), "PvcTape", "PVC TAPE", true },
                    { new Guid("7964ee5b-0242-40f2-91b3-b461b3bbb490"), "PolyesterTape", "POLYESTER TAPE", true },
                    { new Guid("7cfa539c-99ad-41ca-bcff-f87d68a45ca2"), "GlassFiber", "GLASS FIBER", true },
                    { new Guid("867416a4-6bd8-4932-a3a7-2a7513ec37f2"), "WeavedSleeve", "WEAVED SLEEVE", true },
                    { new Guid("94cf0f5e-11ce-4442-81d3-e3befe23db61"), "Foam", "FOAM", true },
                    { new Guid("9a0613e1-5ed7-4a6a-b2d7-67b20bc64518"), "EpdmTube", "EPDM TUBE", true },
                    { new Guid("9dd59491-fbc2-4b69-810e-346b5b6c448c"), "FlexWrap", "FLEXWRAP", true },
                    { new Guid("a403411d-9d7a-490e-9bba-2d0a02b6b597"), "PpTape", "PP TAPE", true },
                    { new Guid("a4bc8c9a-2d51-4824-9940-13b314d1fe9e"), "PaperTape", "PAPER TAPE", true },
                    { new Guid("ab2120c0-64a6-4051-b2e7-d26ac4dc2ff7"), "HarnaSleeve", "HARNASLEEVE", true },
                    { new Guid("b81aa50a-d146-498b-998f-0bcc08c92ea2"), "CurlWrap", "CURLWRAP", true },
                    { new Guid("bf89db38-7dfe-43ee-baf0-b856190879d5"), "EmiHv", "EMI HV", true },
                    { new Guid("d0db818c-718f-4631-bd6d-5291cb79bf8a"), "Taefa", "TAEFA", true },
                    { new Guid("d6ad07b4-f49d-4ced-af77-1ed50ce601b2"), "PolyesterSleeve", "POLYESTER SLEEVE", true },
                    { new Guid("e16fb829-877a-4668-af54-50ba7dfa191e"), "Gab", "GAB", true }
                });

            migrationBuilder.InsertData(
                table: "WireTypes",
                columns: new[] { "Id", "Code", "Description", "IsActive" },
                values: new object[,]
                {
                    { new Guid("0399de9f-b7dd-457d-8cdc-aa9fe1144a8b"), "T4601", "T4601", true },
                    { new Guid("04736fb8-f581-4ea5-9d2d-950d2c17cbd3"), "D6CPC", "D6CPC", true },
                    { new Guid("04b13f27-8163-4830-9e0e-21febbaddd84"), "A3Z", "A3Z", true },
                    { new Guid("07fbc7f9-08c5-4780-9697-33aeff263678"), "B2C", "B2C", true },
                    { new Guid("09943644-6f38-4eb2-a7a5-620aa6105a3e"), "CFLRA", "CFLRA", true },
                    { new Guid("0a8c078a-6d1f-48f8-aafd-dae41f7696e4"), "ALDUS", "ALDUS", true },
                    { new Guid("128736a4-bd1e-47b1-a91e-539202e756ab"), "A4ZH", "A4ZH", true },
                    { new Guid("1780c824-c9e2-4ef8-8ab9-20735c224b62"), "SI_LD", "SI_LD", true },
                    { new Guid("17b09259-0a7d-4cdd-bbd7-08212d5a54de"), "T7988", "T7988", true },
                    { new Guid("18aeb947-a69f-44ee-85a3-e19bdd393359"), "C6ZH", "C6ZH", true },
                    { new Guid("1e64c342-f801-4c59-afdb-7b3594c1bc2d"), "CFLT2", "CFLT2", true },
                    { new Guid("22573c8f-9be9-4aed-8244-18e93c05d207"), "A4ZZ", "A4ZZ", true },
                    { new Guid("29905953-e069-46f9-bb2b-637e0d069093"), "DC631", "DC631", true },
                    { new Guid("2de83bf1-b3c4-4c79-a254-a37fa8d5f82d"), "FLRYB", "FLRYB", true },
                    { new Guid("31e0f934-6f84-4bc8-93da-a2bffba4d873"), "NF3Z", "NF3Z", true },
                    { new Guid("32b84f3f-d500-4593-a6ca-d9658a14180f"), "FLR13", "FLR13", true },
                    { new Guid("34068fa6-3288-48ab-a1c5-60fb52587172"), "C4A", "C4A", true },
                    { new Guid("3f840557-00a5-4598-9e9b-5c45b1f7c11c"), "C3PZH", "C3PZH", true },
                    { new Guid("3fc3ba57-eaf7-48a5-96c6-0ff874d970cc"), "FLYT2", "FLYT2", true },
                    { new Guid("421fcfe4-ef40-4aa4-b240-ffc06e38df7d"), "Unknown", "Unknown", true },
                    { new Guid("4431e5b2-5a59-4605-8769-76713a54a8c3"), "A3ZP", "A3ZP", true },
                    { new Guid("46d66738-08fe-4aee-ae93-498d3180a3a6"), "P3SNC", "P3SNC", true },
                    { new Guid("4d07265b-d946-4b59-aa42-977ade945bba"), "C3A", "C3A", true },
                    { new Guid("4d76c8ea-9575-49b9-9371-60b76c9126cd"), "CE3B", "CE3B", true },
                    { new Guid("58f8183e-3e7d-47f8-a2bc-93d4fb75e03b"), "T7129", "T7129", true },
                    { new Guid("5e198e68-432c-4ccc-b005-73465ded29b9"), "D6", "D6", true },
                    { new Guid("690f9c25-bd89-4352-bd19-c2ca9634ac13"), "G3ZH", "G3ZH", true },
                    { new Guid("69589f77-ed11-4b1d-a724-b3fb36272b21"), "C6A", "C6A", true },
                    { new Guid("809cc153-36cf-4646-80b3-cbb43170fbd4"), "T7128", "T7128", true },
                    { new Guid("854b50c5-1354-4ddc-bf21-b8bfca1ddb8d"), "CFLRB", "CFLRB", true },
                    { new Guid("8879df9f-779a-4b31-9fdc-7c3402cdc722"), "SRE", "SRE", true },
                    { new Guid("8937fefc-2714-40f4-9898-efc71d4cb3d4"), "C3ZH", "C3ZH", true },
                    { new Guid("89f3c3d7-f08b-4e97-97f5-d1119995ee96"), "_0219", "_0219", true },
                    { new Guid("8cded1ba-957c-4934-bf5a-e4901cfc3f58"), "B9Y01", "B9Y01", true },
                    { new Guid("8dbf1298-2d39-4716-9e98-0bb9aa40dbc5"), "FLRYA", "FLRYA", true },
                    { new Guid("92f0a168-1a4f-46f5-824e-f755b92c5a23"), "A4ZP", "A4ZP", true },
                    { new Guid("93003104-1d3c-4d49-9078-6ff121438ea7"), "A3ZH", "A3ZH", true },
                    { new Guid("947b94ed-b0d6-4a0b-976b-2278f2e1b77a"), "HV3", "HV3", true },
                    { new Guid("9dd0b7de-0717-4d6f-9182-5a56c1165261"), "SQUIB", "SQUIB", true },
                    { new Guid("9e1119dc-057f-435d-916e-0ab0103c069e"), "NF3ZZ", "NF3ZZ", true },
                    { new Guid("a1f60d39-ab5a-4319-987e-efb48ee01031"), "P3S", "P3S", true },
                    { new Guid("a25d02b5-64fd-476d-b6c1-4f1e64d22e16"), "C_F3Z", "C_F3Z", true },
                    { new Guid("a5478409-0620-4310-87ed-dd7c7696d5e1"), "F3ZPA", "F3ZPA", true },
                    { new Guid("a6a4d54f-aa27-4a49-836a-d9ec49578618"), "PVC1", "PVC1", true },
                    { new Guid("a74211ba-85be-40dd-b3fa-ea82273c6142"), "F3Z", "F3Z", true },
                    { new Guid("a7821889-8f42-4745-8db1-026485adfde7"), "G3C", "G3C", true },
                    { new Guid("a8d0f785-30e8-4ee5-b7f6-2e1869fcfe05"), "C5ZH", "C5ZH", true },
                    { new Guid("abd7edce-dc5b-4200-b5dd-afc27f984913"), "CE3C", "CE3C", true },
                    { new Guid("b4f68b1a-2420-446b-ab14-5c97606820c3"), "G4A", "G4A", true },
                    { new Guid("b5194fef-8687-41a0-9c9c-95213db6fad0"), "BV3C", "BV3C", true },
                    { new Guid("bee4c8c3-d130-4e36-b33e-954dc76d380d"), "R3Z", "R3Z", true },
                    { new Guid("c431fb4d-9750-48c7-8199-eb234d7f60be"), "A4Z_S", "A4Z_S", true },
                    { new Guid("cdce1221-e30e-4dd6-b9ad-4ddf6dd349ae"), "HV4C", "HV4C", true },
                    { new Guid("d48787e4-5ccb-434b-a9fb-5581c1a5060d"), "NF3ZA", "NF3ZA", true },
                    { new Guid("d5cf3270-dec5-41be-aaa1-7d40d2a68c47"), "C5A", "C5A", true },
                    { new Guid("d6d7c7d3-ff38-4ebb-a76e-81b4471f6130"), "C4ZH", "C4ZH", true },
                    { new Guid("db90da41-5fcb-499c-bc73-979748d7b3d3"), "G4C", "G4C", true },
                    { new Guid("e0c7f78d-05ea-425a-ba06-56eb8d66a097"), "R4S", "R4S", true },
                    { new Guid("e2c3f95d-37e3-4550-a799-605a96b83219"), "A3ZZ", "A3ZZ", true },
                    { new Guid("e4adc741-8d08-4c04-81bb-ce640138df89"), "A4Z", "A4Z", true },
                    { new Guid("e5f508d3-77ed-4b64-98fd-bfec38e64f3b"), "HV4", "HV4", true },
                    { new Guid("ebfb0128-3ca6-4271-9256-16afa243253f"), "DR_IN", "DR_IN", true },
                    { new Guid("f1dcbbd5-13a9-4c68-91a6-4ba1e4e93145"), "B2A", "B2A", true },
                    { new Guid("f3be4d7a-ed52-4211-bf45-30cb938e6529"), "A3ZPA", "A3ZPA", true },
                    { new Guid("f3f1c193-c274-4199-a192-cf374058f9cc"), "F4Z", "F4Z", true },
                    { new Guid("fcbe2224-aefe-476f-98f2-21c111b8e9b4"), "H4ZH", "H4ZH", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cables_Name",
                table: "Cables",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cables_SheetNumber",
                table: "Cables",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cables_TemperatureRangeId",
                table: "Cables",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clips_ClipTypeId",
                table: "Clips",
                column: "ClipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clips_Name",
                table: "Clips",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clips_SheetNumber",
                table: "Clips",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clips_TemperatureRangeId",
                table: "Clips",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClipTypes_Code",
                table: "ClipTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComponentAggregation_ParentsId",
                table: "ComponentAggregation",
                column: "ParentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentContacts_ContactsId",
                table: "ComponentContacts",
                column: "ContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentFileNames_FileNamesId",
                table: "ComponentFileNames",
                column: "FileNamesId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentPartners_PartnersId",
                table: "ComponentPartners",
                column: "PartnersId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentReplacements_ReplacedComponentsId",
                table: "ComponentReplacements",
                column: "ReplacedComponentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentTags_TagsId",
                table: "ComponentTags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Connectors_DbTerminalFamilyId",
                table: "Connectors",
                column: "DbTerminalFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Connectors_DbTerminalSizeId",
                table: "Connectors",
                column: "DbTerminalSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Connectors_Name",
                table: "Connectors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Connectors_SheetNumber",
                table: "Connectors",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Connectors_TemperatureRangeId",
                table: "Connectors",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Connectors_TerminalFamilyId",
                table: "Connectors",
                column: "TerminalFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Connectors_TerminalSizeId",
                table: "Connectors",
                column: "TerminalSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Connectors_WaterproofTypeId",
                table: "Connectors",
                column: "WaterproofTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Covers_CoverTypeId",
                table: "Covers",
                column: "CoverTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Covers_Name",
                table: "Covers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Covers_SheetNumber",
                table: "Covers",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Covers_TemperatureRangeId",
                table: "Covers",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverTypes_Code",
                table: "CoverTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrimpingProcessTypes_Code",
                table: "CrimpingProcessTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diodes_Name",
                table: "Diodes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diodes_SheetNumber",
                table: "Diodes",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diodes_TemperatureRangeId",
                table: "Diodes",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Eyelets_Name",
                table: "Eyelets",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eyelets_SheetNumber",
                table: "Eyelets",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eyelets_TemperatureRangeId",
                table: "Eyelets",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_FileNames_FileTypeId",
                table: "FileNames",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FileNames_Name",
                table: "FileNames",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileTypes_Name",
                table: "FileTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fuses_FuseTypeId",
                table: "Fuses",
                column: "FuseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fuses_Name",
                table: "Fuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fuses_SheetNumber",
                table: "Fuses",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fuses_TemperatureRangeId",
                table: "Fuses",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_FuseTypes_Code",
                table: "FuseTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grommets_Name",
                table: "Grommets",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grommets_SheetNumber",
                table: "Grommets",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grommets_TemperatureRangeId",
                table: "Grommets",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Housings_Name",
                table: "Housings",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Housings_SheetNumber",
                table: "Housings",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Housings_TemperatureRangeId",
                table: "Housings",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTypes_Code",
                table: "MaterialTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MiscellaneousComponents_MiscellaneousComponentTypeId",
                table: "MiscellaneousComponents",
                column: "MiscellaneousComponentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MiscellaneousComponents_Name",
                table: "MiscellaneousComponents",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MiscellaneousComponents_SheetNumber",
                table: "MiscellaneousComponents",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MiscellaneousComponents_TemperatureRangeId",
                table: "MiscellaneousComponents",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_MiscellaneousComponentTypes_Code",
                table: "MiscellaneousComponentTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partners_Code",
                table: "Partners",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_ContactPersonId",
                table: "Partners",
                column: "ContactPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_Name",
                table: "Partners",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_PartnerType_Code_Name",
                table: "Partners",
                columns: new[] { "PartnerType", "Code", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partners_SupervisorPersonId",
                table: "Partners",
                column: "SupervisorPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PartNumbers_ComponentId",
                table: "PartNumbers",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_PartNumbers_Name",
                table: "PartNumbers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Email",
                table: "Persons",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Name",
                table: "Persons",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonType_Name_Email",
                table: "Persons",
                columns: new[] { "PersonType", "Name", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plugs_Name",
                table: "Plugs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plugs_SheetNumber",
                table: "Plugs",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plugs_TemperatureRangeId",
                table: "Plugs",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Relays_Name",
                table: "Relays",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Relays_SheetNumber",
                table: "Relays",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Relays_TemperatureRangeId",
                table: "Relays",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seals_Name",
                table: "Seals",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seals_SheetNumber",
                table: "Seals",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seals_TemperatureRangeId",
                table: "Seals",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shields_Name",
                table: "Shields",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shields_SheetNumber",
                table: "Shields",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shields_TemperatureRangeId",
                table: "Shields",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sleeves_Name",
                table: "Sleeves",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sleeves_SheetNumber",
                table: "Sleeves",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sleeves_TemperatureRangeId",
                table: "Sleeves",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sleeves_WaterproofTypeId",
                table: "Sleeves",
                column: "WaterproofTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubAssemblies_Name",
                table: "SubAssemblies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubAssemblies_SheetNumber",
                table: "SubAssemblies",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubAssemblies_TemperatureRangeId",
                table: "SubAssemblies",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubAssemblies_TerminalFamilyId",
                table: "SubAssemblies",
                column: "TerminalFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_SubAssemblies_TerminalSizeId",
                table: "SubAssemblies",
                column: "TerminalSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Supports_Name",
                table: "Supports",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supports_SheetNumber",
                table: "Supports",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supports_TemperatureRangeId",
                table: "Supports",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TerminalFamilies_Name",
                table: "TerminalFamilies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_DbTerminalFamilyId",
                table: "Terminals",
                column: "DbTerminalFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_DbTerminalSizeId",
                table: "Terminals",
                column: "DbTerminalSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_Name",
                table: "Terminals",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_SheetNumber",
                table: "Terminals",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_TemperatureRangeId",
                table: "Terminals",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_TerminalFamilyId",
                table: "Terminals",
                column: "TerminalFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_TerminalSizeId",
                table: "Terminals",
                column: "TerminalSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_WaterproofTypeId",
                table: "Terminals",
                column: "WaterproofTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_WireTypeId",
                table: "Terminals",
                column: "WireTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminalSize_Name",
                table: "TerminalSize",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TerminalSize_TerminalFamilyId",
                table: "TerminalSize",
                column: "TerminalFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeCodes_Code",
                table: "TypeCodes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WaterproofTypes_Code",
                table: "WaterproofTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WireProtections_Name",
                table: "WireProtections",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WireProtections_SheetNumber",
                table: "WireProtections",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WireProtections_TemperatureRangeId",
                table: "WireProtections",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_WireProtections_WireProtectionTypeId",
                table: "WireProtections",
                column: "WireProtectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WireProtectionTypes_Code",
                table: "WireProtectionTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wires_Name",
                table: "Wires",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wires_SheetNumber",
                table: "Wires",
                column: "SheetNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wires_TemperatureRangeId",
                table: "Wires",
                column: "TemperatureRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Wires_WireTypeId",
                table: "Wires",
                column: "WireTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WireTypes_Code",
                table: "WireTypes",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditEvent");

            migrationBuilder.DropTable(
                name: "Cables");

            migrationBuilder.DropTable(
                name: "Clips");

            migrationBuilder.DropTable(
                name: "ComponentAggregation");

            migrationBuilder.DropTable(
                name: "ComponentContacts");

            migrationBuilder.DropTable(
                name: "ComponentFileNames");

            migrationBuilder.DropTable(
                name: "ComponentPartners");

            migrationBuilder.DropTable(
                name: "ComponentReplacements");

            migrationBuilder.DropTable(
                name: "ComponentTags");

            migrationBuilder.DropTable(
                name: "Connectors");

            migrationBuilder.DropTable(
                name: "Covers");

            migrationBuilder.DropTable(
                name: "CrimpingProcessTypes");

            migrationBuilder.DropTable(
                name: "Diodes");

            migrationBuilder.DropTable(
                name: "Eyelets");

            migrationBuilder.DropTable(
                name: "Fuses");

            migrationBuilder.DropTable(
                name: "Grommets");

            migrationBuilder.DropTable(
                name: "Housings");

            migrationBuilder.DropTable(
                name: "MaterialTypes");

            migrationBuilder.DropTable(
                name: "MiscellaneousComponents");

            migrationBuilder.DropTable(
                name: "PartNumbers");

            migrationBuilder.DropTable(
                name: "Plugs");

            migrationBuilder.DropTable(
                name: "Relays");

            migrationBuilder.DropTable(
                name: "Seals");

            migrationBuilder.DropTable(
                name: "Shields");

            migrationBuilder.DropTable(
                name: "Sleeves");

            migrationBuilder.DropTable(
                name: "SubAssemblies");

            migrationBuilder.DropTable(
                name: "Supports");

            migrationBuilder.DropTable(
                name: "Terminals");

            migrationBuilder.DropTable(
                name: "TypeCodes");

            migrationBuilder.DropTable(
                name: "WireProtections");

            migrationBuilder.DropTable(
                name: "Wires");

            migrationBuilder.DropTable(
                name: "ClipTypes");

            migrationBuilder.DropTable(
                name: "FileNames");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "CoverTypes");

            migrationBuilder.DropTable(
                name: "FuseTypes");

            migrationBuilder.DropTable(
                name: "MiscellaneousComponentTypes");

            migrationBuilder.DropTable(
                name: "TerminalSize");

            migrationBuilder.DropTable(
                name: "WaterproofTypes");

            migrationBuilder.DropTable(
                name: "WireProtectionTypes");

            migrationBuilder.DropTable(
                name: "TemperatureRanges");

            migrationBuilder.DropTable(
                name: "WireTypes");

            migrationBuilder.DropTable(
                name: "FileTypes");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "TerminalFamilies");
        }
    }
}
