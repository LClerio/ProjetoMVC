using Microsoft.AspNetCore.Mvc;
using MusicStore.Models.ViewModel;
using MusicStore.Repositories.Interfaces;
using System.Diagnostics;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInstrumentoRepository _instrumentoRepository;

        public HomeController(IInstrumentoRepository instrumentoRepository)
        {
            _instrumentoRepository = instrumentoRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                InstrumentosDestaque = _instrumentoRepository.Destaque
            };
            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
