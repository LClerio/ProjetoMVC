using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;
using MusicStore.Models.ViewModel;
using MusicStore.Repositories.Interfaces;

namespace MusicStore.Controllers
{
    [Authorize]
    public class CarrinhoCompraController : Controller
    {

        private readonly IInstrumentoRepository _instrumentoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IInstrumentoRepository instrumentoRepository,
            CarrinhoCompra carrinhoCompra)
        {
            _instrumentoRepository = instrumentoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        public IActionResult AdicionarItemNoCarrinhoCompra(int instrumentoId)
        {
            var insturmentoSelecionado = _instrumentoRepository.instrumentos
                                         .FirstOrDefault(p => p.InstrumentoId == instrumentoId);

            if (insturmentoSelecionado != null)
                _carrinhoCompra.AdicionarAoCarrinho(insturmentoSelecionado);

            return RedirectToAction("Index");
        }
        public IActionResult RemoverItemDoCarrinhoCompra(int instrumentoId)
        {
            var intrumentoSelecionado = _instrumentoRepository.instrumentos
                                        .FirstOrDefault(p => p.InstrumentoId == instrumentoId);

            if (intrumentoSelecionado != null)
                _carrinhoCompra.RemoverDoCarrinho(intrumentoSelecionado);

            return RedirectToAction("Index");
        }

    }
}
