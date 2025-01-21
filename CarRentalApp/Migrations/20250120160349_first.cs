using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalApp.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
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
                name: "Trafficreports",
                columns: table => new
                {
                    TrafficreportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrafficreportName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trafficreports", x => x.TrafficreportId);
                });

            migrationBuilder.CreateTable(
                name: "userAccounts",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAccounts", x => x.userId);
                    table.ForeignKey(
                        name: "FK_userAccounts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
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
                    BDPolicyNumber = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EDPolicyNumber = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhothPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.InsuranceId);
                    table.ForeignKey(
                        name: "FK_Insurances_Companys_CompanyId",
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
                name: "Accidents",
                columns: table => new
                {
                    AccidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    TrafficreportId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    AccidentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccidentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriveLicence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverNameOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriveLicenceOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverIdentityOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverCompanyOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccidentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accidents", x => x.AccidentId);
                    table.ForeignKey(
                        name: "FK_Accidents_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accidents_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accidents_Trafficreports_TrafficreportId",
                        column: x => x.TrafficreportId,
                        principalTable: "Trafficreports",
                        principalColumn: "TrafficreportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Insurances_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurances",
                        principalColumn: "InsuranceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    ManufactorerId = table.Column<int>(type: "int", nullable: false),
                    ModeelId = table.Column<int>(type: "int", nullable: false),
                    classificationId = table.Column<int>(type: "int", nullable: false),
                    ChassisNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yearfmanufacture = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ColourId = table.Column<int>(type: "int", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BDFormNumber = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EDFormNumber = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BDCheckNumber = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EDCheckNumber = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CartNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EDCartNumber = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccidenStatus = table.Column<int>(type: "int", nullable: false),
                    InsuraceStatus = table.Column<int>(type: "int", nullable: false),
                    ClaimStatus = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "accidentAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccidentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accidentAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accidentAttachments_Accidents_AccidentId",
                        column: x => x.AccidentId,
                        principalTable: "Accidents",
                        principalColumn: "AccidentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accidentPicAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccidentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accidentPicAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accidentPicAttachments_Accidents_AccidentId",
                        column: x => x.AccidentId,
                        principalTable: "Accidents",
                        principalColumn: "AccidentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estimations",
                columns: table => new
                {
                    EstimationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstimationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccidentId = table.Column<int>(type: "int", nullable: false),
                    EstimationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimationSide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimationAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimations", x => x.EstimationId);
                    table.ForeignKey(
                        name: "FK_Estimations_Accidents_AccidentId",
                        column: x => x.AccidentId,
                        principalTable: "Accidents",
                        principalColumn: "AccidentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carClaim",
                columns: table => new
                {
                    carClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccidentId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    carClaimNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimationId = table.Column<int>(type: "int", nullable: false),
                    ClaimAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClaimDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClaimStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carClaim", x => x.carClaimId);
                    table.ForeignKey(
                        name: "FK_carClaim_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_carClaim_Estimations_EstimationId",
                        column: x => x.EstimationId,
                        principalTable: "Estimations",
                        principalColumn: "EstimationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimAttachments_carClaim_carClaimId",
                        column: x => x.carClaimId,
                        principalTable: "carClaim",
                        principalColumn: "carClaimId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carClaimId = table.Column<int>(type: "int", nullable: false),
                    StatusCode = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimStatuses_carClaim_carClaimId",
                        column: x => x.carClaimId,
                        principalTable: "carClaim",
                        principalColumn: "carClaimId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accidentAttachments_AccidentId",
                table: "accidentAttachments",
                column: "AccidentId");

            migrationBuilder.CreateIndex(
                name: "IX_accidentPicAttachments_AccidentId",
                table: "accidentPicAttachments",
                column: "AccidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_BranchId",
                table: "Accidents",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_CompanyId",
                table: "Accidents",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accidents_TrafficreportId",
                table: "Accidents",
                column: "TrafficreportId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_InsuranceId",
                table: "Attachments",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_carClaim_CompanyId",
                table: "carClaim",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_carClaim_EstimationId",
                table: "carClaim",
                column: "EstimationId");

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
                name: "IX_ClaimAttachments_carClaimId",
                table: "ClaimAttachments",
                column: "carClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimStatuses_carClaimId",
                table: "ClaimStatuses",
                column: "carClaimId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estimations_AccidentId",
                table: "Estimations",
                column: "AccidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_CompanyId",
                table: "Insurances",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Modeels_ManufactorerId",
                table: "Modeels",
                column: "ManufactorerId");

            migrationBuilder.CreateIndex(
                name: "IX_userAccounts_BranchId",
                table: "userAccounts",
                column: "BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accidentAttachments");

            migrationBuilder.DropTable(
                name: "accidentPicAttachments");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "ClaimAttachments");

            migrationBuilder.DropTable(
                name: "ClaimStatuses");

            migrationBuilder.DropTable(
                name: "userAccounts");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "Classifications");

            migrationBuilder.DropTable(
                name: "Colour");

            migrationBuilder.DropTable(
                name: "Modeels");

            migrationBuilder.DropTable(
                name: "carClaim");

            migrationBuilder.DropTable(
                name: "Manufactorers");

            migrationBuilder.DropTable(
                name: "Estimations");

            migrationBuilder.DropTable(
                name: "Accidents");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Companys");

            migrationBuilder.DropTable(
                name: "Trafficreports");
        }
    }
}
