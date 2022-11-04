using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interface.Services;
using Pokedex.Core.Application.ViewModels.TypePokemon;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class TypePokemonController : Controller
    {
        private readonly ITypePokemonServices _typePokemonServices;

        public TypePokemonController(ITypePokemonServices typePokemonServices)
        {
            _typePokemonServices = typePokemonServices;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _typePokemonServices.GetAllViewModelWithInclude());
        }
        public IActionResult Crear()
        {
            return View("SaveType", new TypeSaveViewModels());
        }

        [HttpPost]
        public async Task<IActionResult> Crear(TypeSaveViewModels vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveType", vm);
            }

            await _typePokemonServices.Add(vm);
            return RedirectToRoute(new { controller = "TypePokemon", action = "Index" });
        }
        public async Task<IActionResult> Editar(int id)
        {
            return View("SaveType", await _typePokemonServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Editar(TypeSaveViewModels vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveType", vm);
            }

            await _typePokemonServices.Update(vm,vm.Id);
            return RedirectToRoute(new { controller = "TypePokemon", action = "Index" });
        }
        public async Task<IActionResult> Eliminar(int id)
        {
            return View("Delete", await _typePokemonServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> EliminarT(int id)
        {
            await _typePokemonServices.Delete(id);

            return RedirectToRoute(new { controller = "TypePokemon", action = "Index" });
        }
    }
}
