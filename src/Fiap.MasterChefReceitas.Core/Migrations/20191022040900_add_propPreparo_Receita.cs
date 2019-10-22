using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.MasterChefReceitas.Web.Data.Migrations
{
    public partial class add_propPreparo_Receita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Preparos");

            migrationBuilder.AddColumn<string>(
                name: "Preparo",
                table: "Receitas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preparo",
                table: "Receitas");

            migrationBuilder.CreateTable(
                name: "Preparos",
                columns: table => new
                {
                    IdPreparo = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdReceita = table.Column<long>(nullable: false),
                    Instrucoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preparos", x => x.IdPreparo);
                    table.ForeignKey(
                        name: "FK_Preparos_Receitas_IdReceita",
                        column: x => x.IdReceita,
                        principalTable: "Receitas",
                        principalColumn: "IdReceita",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Preparos_IdReceita",
                table: "Preparos",
                column: "IdReceita",
                unique: true);
        }
    }
}
