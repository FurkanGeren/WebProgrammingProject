using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webbarinak3.Migrations
{
    /// <inheritdoc />
    public partial class request2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Animals_AnimalID",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_AnimalID",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "talepDurumu",
                table: "Animals");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "Requests",
                newName: "Yasi");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Requests",
                newName: "Turu");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Requests",
                newName: "SaglikDurumu");

            migrationBuilder.AddColumn<string>(
                name: "Cinsi",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cinsi",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "Yasi",
                table: "Requests",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Turu",
                table: "Requests",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "SaglikDurumu",
                table: "Requests",
                newName: "email");

            migrationBuilder.AddColumn<int>(
                name: "talepDurumu",
                table: "Animals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_AnimalID",
                table: "Requests",
                column: "AnimalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Animals_AnimalID",
                table: "Requests",
                column: "AnimalID",
                principalTable: "Animals",
                principalColumn: "AnimalID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
