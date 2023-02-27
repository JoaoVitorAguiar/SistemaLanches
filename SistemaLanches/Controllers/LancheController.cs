using Microsoft.AspNetCore.Mvc;
using SistemaLanches.Models;
using SistemaLanches.Repositories;
using SistemaLanches.Repositories.Interfaces;
using SistemaLanches.ViewModels;

namespace SistemaLanches.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lacheRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public LancheController(ILancheRepository lacheRepository)
        {
            _lacheRepository = lacheRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lacheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lacheRepository.Lanches
                        .Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                        .OrderBy(l => l.LancheNome);
                }
                else
                {
                    lanches = _lacheRepository.Lanches
                       .Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
                       .OrderBy(l => l.LancheNome);
                }
                categoriaAtual = categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lanchesListViewModel);
        }
    }
}
