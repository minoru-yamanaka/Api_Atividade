using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaAPI.Migrations
{
    /// <inheritdoc />
    public partial class InicioAplicacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                // O nome da tabela é "Servico" para corresponder à sua classe de modelo.
                name: "Servico",
                columns: table => new
                {
                    // Coluna Id: Chave primária que se auto-incrementa.
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),

                    // Coluna Nome: Corresponde à propriedade Nome.
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),

                    // Coluna Preco: Corresponde à propriedade Preco.
                    // O tipo "decimal(18,2)" é o ideal para valores monetários no SQL Server.
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),

                    // Coluna Descricao: Corresponde à propriedade Descricao.
                    // É "nullable: true" porque não tem o atributo [Required] no seu modelo.
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
