using Microsoft.EntityFrameworkCore.Migrations;

namespace WebEnacal2.Migrations
{
    public partial class CaninoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCanino = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Raza = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    EdadCanina = table.Column<int>(type: "int", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canino", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canino");
        }
    }
}
