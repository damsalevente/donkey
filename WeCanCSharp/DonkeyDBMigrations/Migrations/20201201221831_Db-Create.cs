using Microsoft.EntityFrameworkCore.Migrations;

namespace DonkeyDBMigrations.Migrations
{
    public partial class DbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donkeys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Angle = table.Column<double>(type: "REAL", nullable: false),
                    Throttle = table.Column<double>(type: "REAL", nullable: false),
                    TimeStamp = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donkeys", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donkeys");
        }
    }
}
