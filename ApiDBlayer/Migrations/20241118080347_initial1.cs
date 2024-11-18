using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDBlayer.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_TruckTypeId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TruckTypeId",
                table: "Users",
                column: "TruckTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_TruckTypeId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TruckTypeId",
                table: "Users",
                column: "TruckTypeId",
                unique: true);
        }
    }
}
