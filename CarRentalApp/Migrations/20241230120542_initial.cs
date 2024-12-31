using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalApp.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchNameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    branchnameEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "Classifications",
                columns: table => new
                {
                    classificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    classificationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classifications", x => x.classificationId);
                });

            migrationBuilder.CreateTable(
                name: "Colour",
                columns: table => new
                {
                    ColourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColourNameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColourNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colour", x => x.ColourId);
                });

            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyNameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    InsuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    PolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BDPolicyNumber = table.Column<DateOnly>(type: "date", nullable: false),
                    EDPolicyNumber = table.Column<DateOnly>(type: "date", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.InsuranceId);
                });

            migrationBuilder.CreateTable(
                name: "Manufactorers",
                columns: table => new
                {
                    ManufactorerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufactorNameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufactorNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufactorers", x => x.ManufactorerId);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceViewModel",
                columns: table => new
                {
                    InsuranceId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    PolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BDPolicyNumber = table.Column<DateOnly>(type: "date", nullable: false),
                    EDPolicyNumber = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_InsuranceViewModel_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modeels",
                columns: table => new
                {
                    ModeelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufactorerId = table.Column<int>(type: "int", nullable: false),
                    ModeelNameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModeelNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modeels", x => x.ModeelId);
                    table.ForeignKey(
                        name: "FK_Modeels_Manufactorers_ManufactorerId",
                        column: x => x.ManufactorerId,
                        principalTable: "Manufactorers",
                        principalColumn: "ManufactorerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    ManufactorerId = table.Column<int>(type: "int", nullable: false),
                    ModeelId = table.Column<int>(type: "int", nullable: false),
                    classificationId = table.Column<int>(type: "int", nullable: false),
                    ChassisNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yearfmanufacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColourId = table.Column<int>(type: "int", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BDFormNumber = table.Column<DateOnly>(type: "date", nullable: true),
                    EDFormNumber = table.Column<DateOnly>(type: "date", nullable: true),
                    CheckNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BDCheckNumber = table.Column<DateOnly>(type: "date", nullable: true),
                    EDCheckNumber = table.Column<DateOnly>(type: "date", nullable: true),
                    CartNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Classifications_classificationId",
                        column: x => x.classificationId,
                        principalTable: "Classifications",
                        principalColumn: "classificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Colour_ColourId",
                        column: x => x.ColourId,
                        principalTable: "Colour",
                        principalColumn: "ColourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Manufactorers_ManufactorerId",
                        column: x => x.ManufactorerId,
                        principalTable: "Manufactorers",
                        principalColumn: "ManufactorerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Modeels_ModeelId",
                        column: x => x.ModeelId,
                        principalTable: "Modeels",
                        principalColumn: "ModeelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BranchId",
                table: "Cars",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_classificationId",
                table: "Cars",
                column: "classificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColourId",
                table: "Cars",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ManufactorerId",
                table: "Cars",
                column: "ManufactorerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModeelId",
                table: "Cars",
                column: "ModeelId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceViewModel_CompanyId",
                table: "InsuranceViewModel",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Modeels_ManufactorerId",
                table: "Modeels",
                column: "ManufactorerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "InsuranceViewModel");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Classifications");

            migrationBuilder.DropTable(
                name: "Colour");

            migrationBuilder.DropTable(
                name: "Modeels");

            migrationBuilder.DropTable(
                name: "Companys");

            migrationBuilder.DropTable(
                name: "Manufactorers");
        }
    }
}
