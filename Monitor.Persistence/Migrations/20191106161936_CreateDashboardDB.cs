using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitor.Persistence.Migrations
{
    public partial class CreateDashboardDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MontlySalesInfo",
                columns: table => new
                {
                    Year = table.Column<short>(nullable: false),
                    Month = table.Column<short>(nullable: false),
                    PlannedSalesSumm = table.Column<decimal>(nullable: false),
                    ActualSalesSumm = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MontlySalesInfo", x => new { x.Year, x.Month });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MontlySalesInfo");
        }
    }
}
