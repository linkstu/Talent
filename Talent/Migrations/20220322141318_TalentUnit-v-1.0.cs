using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talent.Migrations
{
    public partial class TalentUnitv10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TalentUnits",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CategoryID = table.Column<Guid>(type: "uuid", nullable: false),
                    LicenseID = table.Column<Guid>(type: "uuid", nullable: false),
                    Certificate = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DateOfFound = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Telephone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Legal = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LegalMobile = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Manager = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ManagerMobile = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ManagerPassword = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DateOfRegister = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AcceptanceComments = table.Column<string>(type: "text", nullable: true),
                    DateOfAcceptance = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VerifyComments = table.Column<string>(type: "text", nullable: true),
                    DateOfVerify = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreateBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentUnits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TalentUnits_FileAttachments_LicenseID",
                        column: x => x.LicenseID,
                        principalTable: "FileAttachments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TalentUnits_IndustryCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "IndustryCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TalentUnitDocuments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    TalentUnitID = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentUnitDocuments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TalentUnitDocuments_FileAttachments_FileId",
                        column: x => x.FileId,
                        principalTable: "FileAttachments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TalentUnitDocuments_TalentUnits_TalentUnitID",
                        column: x => x.TalentUnitID,
                        principalTable: "TalentUnits",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TalentUnitDocuments_FileId",
                table: "TalentUnitDocuments",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_TalentUnitDocuments_TalentUnitID",
                table: "TalentUnitDocuments",
                column: "TalentUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentUnits_CategoryID",
                table: "TalentUnits",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TalentUnits_LicenseID",
                table: "TalentUnits",
                column: "LicenseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TalentUnitDocuments");

            migrationBuilder.DropTable(
                name: "TalentUnits");
        }
    }
}
