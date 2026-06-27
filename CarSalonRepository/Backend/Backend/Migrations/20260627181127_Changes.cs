using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Salons_SalonId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_SalonId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Cars",
                table: "Salons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cars",
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
    }
}
