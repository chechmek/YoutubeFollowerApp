using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLibrary.Migrations
{
    public partial class StatisticsAddedInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistic",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChannelId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    VideosCount = table.Column<int>(type: "int", nullable: false),
                    SubscriberCount = table.Column<int>(type: "int", nullable: false),
                    ChannelSnippetId = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistic", x => x.Date);
                    table.ForeignKey(
                        name: "FK_Statistic_Channels_ChannelSnippetId",
                        column: x => x.ChannelSnippetId,
                        principalTable: "Channels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statistic_ChannelSnippetId",
                table: "Statistic",
                column: "ChannelSnippetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistic");
        }
    }
}
