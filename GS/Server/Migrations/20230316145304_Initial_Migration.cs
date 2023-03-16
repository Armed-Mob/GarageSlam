using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GS.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrackableColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackableColor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackableYear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackableYear", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trackable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternalIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackableColorId = table.Column<int>(type: "int", nullable: false),
                    TrackableYearId = table.Column<int>(type: "int", nullable: false),
                    TrackableMake = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackableModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackableTrimLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationExpiry = table.Column<DateTime>(type: "date", nullable: true),
                    InsuranceExpiry = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trackable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trackable_TrackableColor_TrackableColorId",
                        column: x => x.TrackableColorId,
                        principalTable: "TrackableColor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trackable_TrackableYear_TrackableYearId",
                        column: x => x.TrackableYearId,
                        principalTable: "TrackableYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    InitialIssue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackableId = table.Column<int>(type: "int", nullable: false),
                    WorkCompleted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkOrderCost = table.Column<decimal>(type: "money", precision: 2, nullable: true),
                    WorkOrderPartsCost = table.Column<decimal>(type: "money", precision: 2, nullable: true),
                    WorkOrderLaborCost = table.Column<decimal>(type: "money", precision: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrder_Trackable_TrackableId",
                        column: x => x.TrackableId,
                        principalTable: "Trackable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.id);
                    table.ForeignKey(
                        name: "FK_Note_WorkOrder_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Note_WorkOrderId",
                table: "Note",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Trackable_TrackableColorId",
                table: "Trackable",
                column: "TrackableColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Trackable_TrackableYearId",
                table: "Trackable",
                column: "TrackableYearId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_TrackableId",
                table: "WorkOrder",
                column: "TrackableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "WorkOrder");

            migrationBuilder.DropTable(
                name: "Trackable");

            migrationBuilder.DropTable(
                name: "TrackableColor");

            migrationBuilder.DropTable(
                name: "TrackableYear");
        }
    }
}
