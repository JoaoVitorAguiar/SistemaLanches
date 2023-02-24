using Microsoft.AspNetCore.Mvc;
using SistemaLanches.Repositories.Interfaces;
using SistemaLanches.ViewModels;

namespace SistemaLanches.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lacheRepository;

        public LancheController(ILancheRepository lacheRepository)
        {
            _lacheRepository = lacheRepository;
        }

        public IActionResult List()
        {
            // var lanches = _lacheRepository.Lanches;
            // return View(lanches);
            var lancheListViewModel = new LancheListViewModel();
            lancheListViewModel.Lanches = _lacheRepository.Lanches;
            lancheListViewModel.CategoriaAtual = "Categoria Atual";
            return View(lancheListViewModel);
        }
    }
}
