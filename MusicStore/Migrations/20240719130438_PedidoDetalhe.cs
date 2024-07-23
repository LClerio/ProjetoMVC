using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStore.Migrations
{
    /// <inheritdoc />
    public partial class PedidoDetalhe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalhe_Instrumentos_InstrumentoId",
                table: "PedidoDetalhe");

            migrationBuilder.DropColumn(
                name: "LancheID",
                table: "PedidoDetalhe");

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentoId",
                table: "PedidoDetalhe",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalhe_Instrumentos_InstrumentoId",
                table: "PedidoDetalhe",
                column: "InstrumentoId",
                principalTable: "Instrumentos",
                principalColumn: "InstrumentoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoDetalhe_Instrumentos_InstrumentoId",
                table: "PedidoDetalhe");

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentoId",
                table: "PedidoDetalhe",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LancheID",
                table: "PedidoDetalhe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoDetalhe_Instrumentos_InstrumentoId",
                table: "PedidoDetalhe",
                column: "InstrumentoId",
                principalTable: "Instrumentos",
                principalColumn: "InstrumentoId");
        }
    }
}
