using Microsoft.EntityFrameworkCore;
using MusicStore.context;

namespace MusicStore.Models
{
    public class CarrinhoCompra
    {

        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //define uma sessão
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso context
            var context = services.GetService<AppDbContext>();

            //obtem ou gere o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o ID do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o context e o ID atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }
        public void AdicionarAoCarrinho(Instrumento instrumento)
        {
            var carrinhoCompraitem =
                _context.CarrinhoCompraItens.SingleOrDefault(
                    s => s.Instrumento.InstrumentoId == instrumento.InstrumentoId &&
                    s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraitem == null)
            {
                carrinhoCompraitem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Instrumento = instrumento,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraitem);
            } else
            {
                carrinhoCompraitem.Quantidade++;
            }
            _context.SaveChanges();
        }
        public void RemoverDoCarrinho(Instrumento instrumento)
        {
            var carrinhoCompraItem =
                _context.CarrinhoCompraItens.SingleOrDefault(
                    s => s.Instrumento.InstrumentoId == instrumento.InstrumentoId &&
                    s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                } else
                {
                    _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }
            _context.SaveChanges();
        }
        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItens ?? (CarrinhoCompraItens =
                                          _context.CarrinhoCompraItens
                                          .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                                          .Include(s => s.Instrumento)
                                          .ToList());

        }
        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompraItens
                                           .Where(c => c.CarrinhoCompraId == CarrinhoCompraId);

            _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }
        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompraItens
                                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                                .Select(c => c.Instrumento.Preco * c.Quantidade).Sum();
            return total;
        }
    }
}
