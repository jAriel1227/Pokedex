using AutoMapper;
using Pokedex.Core.Application.Interface.Repositories;
using Pokedex.Core.Application.Interface.Services;
using Pokedex.Core.Application.ViewModels.Pokemon;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Services
{
    public class PokemonServices : GenericServices<SavePkViewModels, PokemonViewModels, Pokemon>, IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IRegionsRepository _regionsRepository;
        private readonly ITypePokemonRepository _typePokemonRepository;
        private readonly IMapper _mapper;

        public PokemonServices(IPokemonRepository pokemonRepository, 
            IRegionsRepository regionsRepository,
            ITypePokemonRepository typePokemonRepository,
            IMapper mapper) : base (pokemonRepository, mapper)
        {
            _pokemonRepository = pokemonRepository;
            _regionsRepository = regionsRepository;
            _typePokemonRepository = typePokemonRepository;
            _mapper = mapper;
        }
        public async Task<List<PokemonViewModels>> GetAllViewModelWithInclude()
        {
            var pokemonList = await _pokemonRepository.GetAllExtensiveInclude();

            return _mapper.Map<List<PokemonViewModels>>(pokemonList);

            /* return pokemonViewModels.Select(pokemon => new PokemonViewModels
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImageUrl = pokemon.ImageUrl,
                NamePrimario = pokemon.TypePokemon.Name,
                NameSecundario = pokemon.Type2Pokemon.Name,
                Region = pokemon.Regions.Name
            }).ToList();*/
        }
        //filtrar por nombre de pokemon
        public async Task<List<PokemonViewModels>> GetAllName(string name)
        {
            var response = await GetAllViewModelWithInclude();

            var busqueda = response.Select(pokemon => new
            {
                Name = $"{pokemon.Name}",
                pokemon.Id,
                pokemon.ImageUrl,
                pokemon.NamePrimario,
                pokemon.NameSecundario,
                pokemon.Region
            }).Where(j => j.Name.Trim().ToLower().Contains(name.Trim().ToLower())).ToList();

            return busqueda.Select(pokemon => new PokemonViewModels
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImageUrl = pokemon.ImageUrl,
                NamePrimario = pokemon.NamePrimario,
                NameSecundario = pokemon.NameSecundario,
                Region = pokemon.Region
            }).ToList();
        }
        //Metodo para filtrar por regiones, tomando su ID.
        public async Task<List<PokemonViewModels>> GetAllViewModelWithFilters(FilterPokemonViewModel filters)
        {
            var listVm = await GetAllViewModelWithInclude();

            var newList = new List<PokemonViewModels>();

            if (filters.RegionId != null && filters.RegionId.Count > 0)
            {
                foreach (int Id in filters.RegionId)
                {
                    var pk = listVm.Where(x => x.IDRegions == Id).ToList();

                    foreach (PokemonViewModels item in pk)
                    {
                        newList.Add(item);
                    }
                }
            }
            else
            {
                return listVm; //Por si el filtro viene vacio o null
            }

            return newList; //Retornara si encuentra a travez del filtro

            #region Filtro por una o mas regiones...            
            /*var listVm = pokemonViewModels.Select(pokemon => new PokemonViewModels
             {
                 Id = pokemon.Id,
                 Name = pokemon.Name,
                 ImageUrl = pokemon.ImageUrl,
                 NamePrimario = pokemon.TypePokemon.Name,
                 NameSecundario = pokemon.Type2Pokemon.Name,
                 Region = pokemon.Regions.Name,
                 IDRegions = pokemon.Regions.Id
             }).ToList();

            var newList = new List<PokemonViewModels>();

            if (filters.RegionId != null && filters.RegionId.Count > 0)
            {
                foreach (int Id in filters.RegionId)
                {
                    var pk = listVm.Where(x => x.IDRegions == Id).ToList();

                    foreach (PokemonViewModels item in pk)
                    {
                        newList.Add(item);
                    }
                }
            }*/
            #endregion

            #region "Filtro basico"
            /*
            * var listVm = pokemonViewModels.Select(pokemon => new PokemonViewModels
             {
                 Id = pokemon.Id,
                 Name = pokemon.Name,
                 ImageUrl = pokemon.ImageUrl,
                 NamePrimario = pokemon.TypePokemon.Name,
                 NameSecundario = pokemon.Type2Pokemon.Name,
                 Region = pokemon.Regions.Name,
                 IDRegions = pokemon.Regions.Id
             }).ToList();

            * if(filters.RegionId != null) Filtro basico
            {
               listVm = listVm.Where(pk => pk.IDRegions == filters.RegionId.Value).ToList();
            }*/
            #endregion
        }       
    }
}
