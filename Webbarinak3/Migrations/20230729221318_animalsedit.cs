using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webbarinak3.Migrations
{
    /// <inheritdoc />
    public partial class animalsedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "talepDurumu",
                table: "Animals",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "talepDurumu",
                table: "Animals");
        }
    }
}
