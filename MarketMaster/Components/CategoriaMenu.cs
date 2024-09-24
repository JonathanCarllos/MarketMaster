using MarketMaster.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketMaster.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaMenu(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _repository.Categorias.OrderBy(c => c.Nome);
            return View(categorias);
        }
    }
}
