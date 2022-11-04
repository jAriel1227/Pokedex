using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interface.Services;
using Pokedex.Core.Application.ViewModels.Pokemon;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPokemonService _pokemonServices;
        private readonly IRegionService _RegionServices;

        public HomeController(IPokemonService pokemonService, IRegionService regionService)
        {
            _pokemonServices = pokemonService;
            _RegionServices = regionService;
        }

        public async Task<IActionResult> Index()
        {
           ViewBag.Region = await _RegionServices.GetAllViewModel();
           return View(await _pokemonServices.GetAllViewModelWithInclude());
        }

        [HttpPost]
        public async Task<IActionResult> Buscar(string name)
        {
            ViewBag.Region = await _RegionServices.GetAllViewModel();

            if (string.IsNullOrEmpty(name))
            {
                return RedirectToAction("Index");
            }

            var response = await _pokemonServices.GetAllName(name);
            return View("Index", response);
        }

        [HttpPost]
        public async Task<IActionResult> RegionFilter(FilterPokemonViewModel vm)
        {
            ViewBag.Region =  await _RegionServices.GetAllViewModel();
            return View("Index", await _pokemonServices.GetAllViewModelWithFilters(vm));
        }
    }
}
