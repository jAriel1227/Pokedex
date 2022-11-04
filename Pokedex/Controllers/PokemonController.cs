using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Pokedex.Core.Application.Interface.Services;
using Pokedex.Core.Application.ViewModels.Pokemon;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonServices;
        private readonly IRegionService _regionsServices;
        private readonly ITypePokemonServices _typePokemon; 
        public PokemonController(IPokemonService pokemonService,
            IRegionService regionService,
            ITypePokemonServices typePokemonServices)
        {
            _pokemonServices = pokemonService;
            _regionsServices = regionService;
            _typePokemon = typePokemonServices;
        }
        public async Task<IActionResult> Index()
        {       
          return View(await _pokemonServices.GetAllViewModelWithInclude());
        }

        public async Task<IActionResult> Crear()
        {
            SavePkViewModels vm = new();
            vm.Regiones = await _regionsServices.GetAllViewModel();
            vm.Tipos = await _typePokemon.GetAllViewModel();

            return View("SavePK", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(SavePkViewModels vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Regiones = await _regionsServices.GetAllViewModel();
                vm.Tipos = await _typePokemon.GetAllViewModel();

                return View("SavePK", vm);
            }
            
            await _pokemonServices.Add(vm);

            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }
        public async Task<IActionResult> Editar(int id)
        {
            SavePkViewModels vm = await _pokemonServices.GetByIdSaveViewModel(id);
            vm.Regiones = await _regionsServices.GetAllViewModel();
            vm.Tipos = await _typePokemon.GetAllViewModel();

            return View("SavePK", vm );
        }

        [HttpPost]
        public async Task<IActionResult> Editar(SavePkViewModels vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Regiones = await _regionsServices.GetAllViewModel();
                vm.Tipos = await _typePokemon.GetAllViewModel();
                return View("SavePK", vm);
            }
            
            await _pokemonServices.Update(vm, vm.Id);

            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }
        public async Task<IActionResult> Eliminar(int id)
        {
            return View("Delete", await _pokemonServices.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> EliminarP(int id)
        {
            await _pokemonServices.Delete(id);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }
    }
}
