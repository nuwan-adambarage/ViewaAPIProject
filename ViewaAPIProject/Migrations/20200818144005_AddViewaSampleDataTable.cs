using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ViewaAPIProject.Migrations
{
    public partial class AddViewaSampleDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ViewaSamples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignName = table.Column<string>(nullable: true),
                    EventType = table.Column<string>(nullable: true),
                    AppUserId = table.Column<int>(nullable: false),
                    AppUserGender = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    AppDeviceType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewaSamples", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ViewaSamples");
        }
    }
}
