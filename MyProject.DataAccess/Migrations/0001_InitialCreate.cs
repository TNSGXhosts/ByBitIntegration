using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.DataAccess.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Klines",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Symbol = table.Column<string>(nullable: false),
                Interval = table.Column<string>(nullable: false),
                StartTime = table.Column<long>(nullable: false),
                Open = table.Column<decimal>(nullable: false),
                High = table.Column<decimal>(nullable: false),
                Low = table.Column<decimal>(nullable: false),
                Close = table.Column<decimal>(nullable: false),
                Volume = table.Column<decimal>(nullable: false),
                Turnover = table.Column<decimal>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Klines", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Klines_Symbol_Interval_StartTime",
            table: "Klines",
            columns: new[] { "Symbol", "Interval", "StartTime" },
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Klines");
    }
}
