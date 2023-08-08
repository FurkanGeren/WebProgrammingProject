using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webbarinak3.Migrations
{
    /// <inheritdoc />
    public partial class request3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requests2",
                columns: table => new
                {
                    Request2ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Turu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cinsi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaglikDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests2", x => x.Request2ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests2");
        }
    }
}
