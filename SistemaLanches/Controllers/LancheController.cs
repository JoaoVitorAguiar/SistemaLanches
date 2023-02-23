using Microsoft.AspNetCore.Mvc;
using SistemaLanches.Repositories.Interfaces;

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
            var lanches = _lacheRepository.Lanches;
            return View(lanches);
        }
    }
}
