using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monitor.Persistence.Migrations
{
    public partial class AddPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MontlySalesInfo",
                table: "MontlySalesInfo");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MontlySalesInfo",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MontlySalesInfo",
                table: "MontlySalesInfo",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MontlySalesInfo",
                table: "MontlySalesInfo");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MontlySalesInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MontlySalesInfo",
                table: "MontlySalesInfo",
                columns: new[] { "Year", "Month" });
        }
    }
}
