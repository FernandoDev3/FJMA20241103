using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FJMA20241103.Migrations
{
    public partial class migra1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    idAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marca = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    modelo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    anio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Autos__D8600DCF80AA0115", x => x.idAuto);
                });

            migrationBuilder.CreateTable(
                name: "ComponenteCarro",
                columns: table => new
                {
                    idComponente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idAuto = table.Column<int>(type: "int", nullable: true),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Componen__001F4C930631F843", x => x.idComponente);
                    table.ForeignKey(
                        name: "FK__Component__idAut__398D8EEE",
                        column: x => x.idAuto,
                        principalTable: "Autos",
                        principalColumn: "idAuto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponenteCarro_idAuto",
                table: "ComponenteCarro",
                column: "idAuto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponenteCarro");

            migrationBuilder.DropTable(
                name: "Autos");
        }
    }
}
