using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talent.Migrations
{
    public partial class ServiceUnitv10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceUnits",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    LicenseID = table.Column<Guid>(type: "uuid", nullable: false),
                    Certificate = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DateOfFound = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Telephone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
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
                    table.PrimaryKey("PK_ServiceUnits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiceUnits_FileAttachments_LicenseID",
                        column: x => x.LicenseID,
                        principalTable: "FileAttachments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceUnitDocuments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceUnitID = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceUnitDocuments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiceUnitDocuments_FileAttachments_FileId",
                        column: x => x.FileId,
                        principalTable: "FileAttachments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceUnitDocuments_ServiceUnits_ServiceUnitID",
                        column: x => x.ServiceUnitID,
                        principalTable: "ServiceUnits",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUnitDocuments_FileId",
                table: "ServiceUnitDocuments",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUnitDocuments_ServiceUnitID",
                table: "ServiceUnitDocuments",
                column: "ServiceUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUnits_LicenseID",
                table: "ServiceUnits",
                column: "LicenseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceUnitDocuments");

            migrationBuilder.DropTable(
                name: "ServiceUnits");
        }
    }
}
