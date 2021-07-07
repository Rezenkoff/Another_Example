using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitor.Persistence.Migrations
{
    public partial class updatetableGoogleAnalytCache : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SesByMonth",
                table: "GoogleAnalitCache",
                newName: "SessionByMonth");

            migrationBuilder.RenameColumn(
                name: "SesByDay",
                table: "GoogleAnalitCache",
                newName: "SessionByDay");

            migrationBuilder.RenameColumn(
                name: "MaxSesCount10Day",
                table: "GoogleAnalitCache",
                newName: "MaxSessionCount10Day");

            migrationBuilder.RenameColumn(
                name: "DateCacheByMonth",
                table: "GoogleAnalitCache",
                newName: "LastUpdateByMonth");

            migrationBuilder.RenameColumn(
                name: "DateCacheByDay",
                table: "GoogleAnalitCache",
                newName: "LastUpdateByDay");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SessionByMonth",
                table: "GoogleAnalitCache",
                newName: "SesByMonth");

            migrationBuilder.RenameColumn(
                name: "SessionByDay",
                table: "GoogleAnalitCache",
                newName: "SesByDay");

            migrationBuilder.RenameColumn(
                name: "MaxSessionCount10Day",
                table: "GoogleAnalitCache",
                newName: "MaxSesCount10Day");

            migrationBuilder.RenameColumn(
                name: "LastUpdateByMonth",
                table: "GoogleAnalitCache",
                newName: "DateCacheByMonth");

            migrationBuilder.RenameColumn(
                name: "LastUpdateByDay",
                table: "GoogleAnalitCache",
                newName: "DateCacheByDay");
        }
    }
}
