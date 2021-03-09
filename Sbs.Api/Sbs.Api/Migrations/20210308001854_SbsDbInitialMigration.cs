using Microsoft.EntityFrameworkCore.Migrations;

namespace Sbs.Api.Migrations
{
    public partial class SbsDbInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dictionary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordType = table.Column<int>(type: "int", nullable: false),
                    Word = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LoginName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dictionary",
                columns: new[] { "Id", "Word", "WordType" },
                values: new object[,]
                {
                    { 12, "England", 1 },
                    { 22, "Portugal", 2 },
                    { 21, "Luxemburg", 2 },
                    { 20, "Continent", 2 },
                    { 19, "America", 2 },
                    { 18, "Australia", 2 },
                    { 17, "Armsterdam", 2 },
                    { 16, "London", 1 },
                    { 15, "Delhi", 1 },
                    { 14, "Cyprus", 1 },
                    { 13, "Scotland", 1 },
                    { 23, "Argentina", 2 },
                    { 24, "Switzerland", 2 },
                    { 10, "Germany", 1 },
                    { 9, "Denmark", 1 },
                    { 8, "Poole", 0 },
                    { 7, "Texas", 0 },
                    { 6, "Vienna", 0 },
                    { 5, "Paris", 0 },
                    { 4, "Asia", 0 },
                    { 3, "France", 0 },
                    { 2, "India", 0 },
                    { 1, "Italy", 0 },
                    { 11, "Munich", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "LoginName", "Name", "Password" },
                values: new object[] { 1, "3", "r", "Rit", "pass" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dictionary");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
