using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitor.Persistence.Migrations
{
    public partial class AddSessionByDayWeekAgoField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SessionByDayWeekAgo",
                table: "GoogleAnalitCache",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionByDayWeekAgo",
                table: "GoogleAnalitCache");
        }
    }
}
