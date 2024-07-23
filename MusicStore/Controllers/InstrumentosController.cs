using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;
using MusicStore.Models.ViewModel;
using MusicStore.Repositories.Interfaces;

namespace MusicStore.Controllers
{
    public class InstrumentosController : Controller
    {
        private readonly IInstrumentoRepository _instrumentoRepository;

        public InstrumentosController(IInstrumentoRepository instrumentoRepository)
        {
            _instrumentoRepository = instrumentoRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Instrumento> instrumentos;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrWhiteSpace(categoria))
            {
                instrumentos = _instrumentoRepository.instrumentos.OrderBy(l => l.InstrumentoId);
                categoria = "Todos os Instrumentos";
            } else
            {
                instrumentos = _instrumentoRepository.instrumentos
                    .Where(i => i.Categoria.CategoriaNome.Equals(categoria))
                    .OrderBy(c => c.InstrumentoNome);

                categoriaAtual = categoria;
            }

            var instrumentoViewModel = new InstrumentosListViewModel
            {
                Instrumentos = instrumentos,
                CategoriaAtual = categoriaAtual,
            };
            return View(instrumentoViewModel);
        }

        public IActionResult Details(int instrumentoId)
        {
            var instrumento = _instrumentoRepository.instrumentos
                .FirstOrDefault(i => i.InstrumentoId == instrumentoId);
            return View(instrumento);
        } 

        public ViewResult Search(string searchString)
        {
            IEnumerable<Instrumento> instrumentos;
             string categoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(searchString))
            {
                instrumentos = _instrumentoRepository.instrumentos.OrderBy(i => i.InstrumentoId);
                categoriaAtual = "Todos os Instrumentos";
            } else
            {
                string lowerCaseSearchString = searchString.ToLower();
                instrumentos = _instrumentoRepository.instrumentos
                    .Where(i => i.InstrumentoNome.ToLower().Contains(lowerCaseSearchString))
                    .OrderBy(i => i.InstrumentoNome);

                categoriaAtual = instrumentos.Any() ? "Instrumento" : "Nenhum instrumento foi encontrado";
              
            }
            return View("~/Views/Instrumentos/List.cshtml", new InstrumentosListViewModel
            {
                Instrumentos = instrumentos,
                CategoriaAtual = categoriaAtual,
            });
        }
    }
}
