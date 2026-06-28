using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarIds",
                table: "Salons");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SalonId",
                table: "Cars",
                column: "SalonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Salons_SalonId",
                table: "Cars",
                column: "SalonId",
                principalTable: "Salons",
                principalColumn: "SalonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Salons_SalonId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_SalonId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "CarIds",
                table: "Salons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
