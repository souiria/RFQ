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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {    
            migrationBuilder.DropTable(
                name: "RfqNprRequest");
        }
    }
}
