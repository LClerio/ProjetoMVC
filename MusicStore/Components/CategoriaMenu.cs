using Microsoft.AspNetCore.Mvc;
using MusicStore.Repositories.Interfaces;

namespace MusicStore.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _CategoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepositories)
        {
            _CategoriaRepository = categoriaRepositories;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _CategoriaRepository.Categorias.OrderBy(p => p.CategoriaNome);
            return View(categorias);
        }
    }
}
