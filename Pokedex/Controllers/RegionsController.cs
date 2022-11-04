using LibraryPokedex;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interface.Services;
using Pokedex.Core.Application.ViewModels.Regions;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class RegionsController : Controller
    {

        private readonly IRegionService _regionsServices;

        public RegionsController(IRegionService regionService)
        {
            _regionsServices = regionService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _regionsServices.GetAllViewModelWithInclude());
        }
        public IActionResult Crear()
        {
            return View("SaveRegions", new SaveRegionsViewModels());
        }

        [HttpPost]
        public async Task<IActionResult> Crear(SaveRegionsViewModels vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegions", vm);
            }

            await _regionsServices.Add(vm);
            return RedirectToRoute(new { controller = "Regions", action = "Index" });
        }
        public async Task<IActionResult> Editar(int id)
        {
            
            return View("SaveRegions", await _regionsServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult>Editar(SaveRegionsViewModels vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegions", vm);
            }

            await _regionsServices.Update(vm,vm.Id);
            return RedirectToRoute(new { controller = "Regions", action = "Index" });
        }
        public async Task<IActionResult> Eliminar(int id)
        {
            return View("Delete", await _regionsServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> EliminarR(int id)
        {
            await _regionsServices.Delete(id);

            return RedirectToRoute(new { controller = "Regions", action = "Index" });
        }

    }  
}
