using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models
{
    public class PedidoDetalhe
    {
        public int PedidoDetalheId { get; set; }
        public int PedidoId { get; set; }
        public int InstrumentoId { get; set; }
        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        public virtual Instrumento Instrumento { get; set; }
        public virtual Pedido Pedido { get; set; }
    }

}
