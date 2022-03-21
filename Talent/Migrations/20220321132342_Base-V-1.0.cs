using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talent.Migrations
{
    public partial class BaseV10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ImageID = table.Column<Guid>(type: "uuid", nullable: false),
                    SortIndex = table.Column<int>(type: "integer", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreateBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Banners_FileAttachments_ImageID",
                        column: x => x.ImageID,
                        principalTable: "FileAttachments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndustryCategories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    SortIndex = table.Column<int>(type: "integer", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreateBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "integer", maxLength: 100, nullable: false),
                    LimitedValuation = table.Column<decimal>(type: "numeric", nullable: false),
                    LimitedCount = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    SortIndex = table.Column<int>(type: "integer", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreateBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banners_ImageID",
                table: "Banners",
                column: "ImageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "IndustryCategories");

            migrationBuilder.DropTable(
                name: "ServiceCategories");
        }
    }
}
