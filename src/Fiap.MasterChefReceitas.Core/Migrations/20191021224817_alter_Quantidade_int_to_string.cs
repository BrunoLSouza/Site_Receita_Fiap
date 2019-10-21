using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.MasterChefReceitas.Web.Data.Migrations
{
    public partial class alter_Quantidade_int_to_string : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Quantidade",
                table: "Ingredientes",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "Ingredientes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
