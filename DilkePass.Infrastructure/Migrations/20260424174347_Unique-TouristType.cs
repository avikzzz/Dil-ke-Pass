using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DilkePass.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UniqueTouristType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TouristTypeCode",
                table: "TouristTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TouristTypes_TouristTypeCode",
                table: "TouristTypes",
                column: "TouristTypeCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TouristTypes_TouristTypeCode",
                table: "TouristTypes");

            migrationBuilder.AlterColumn<string>(
                name: "TouristTypeCode",
                table: "TouristTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
