using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStore.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias (CategoriaINome, Resumo)" +
                " VALUES ('Guitarra', ' Instrumento de cordas, geralmente com seis cordas, tocado com dedos ou palheta. Popular no rock, pop, jazz e blues. Pode ser acústica ou elétrica.')");

            migrationBuilder.Sql("INSERT INTO Categorias (CategoriaINome, Resumo) " +
                "VALUES ('Contrabaixo', 'Maior e mais grave instrumento de cordas, com quatro ou cinco cordas. Fundamental no jazz, rock, funk e música clássica.')");

            migrationBuilder.Sql("INSERT INTO Categorias (CategoriaINome, Resumo) " +
                "VALUES ('Teclado', 'Instrumento eletrônico com teclas, capaz de reproduzir diversos sons. Usado em muitos gêneros musicais, tanto ao vivo quanto em estúdios.\r\n\r\n\r\n\r\n\r\n\r\n\r\n')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");

        }
    }
}
