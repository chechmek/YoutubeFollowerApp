using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLibrary.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cocktails",
                table: "Cocktails");

            migrationBuilder.RenameTable(
                name: "Cocktails",
                newName: "Channels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Channels",
                table: "Channels",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Channels",
                table: "Channels");

            migrationBuilder.RenameTable(
                name: "Channels",
                newName: "Cocktails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cocktails",
                table: "Cocktails",
                column: "Id");
        }
    }
}
