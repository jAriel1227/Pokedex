using AutoMapper;
using Pokedex.Core.Application.Interface.Repositories;
using Pokedex.Core.Application.Interface.Services;
using Pokedex.Core.Application.ViewModels.TypePokemon;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Services
{
    public class TypePokemonServices : 
        GenericServices<TypeSaveViewModels, TypePokemonViewModels, TypePokemon>, ITypePokemonServices
    {
        private readonly ITypePokemonRepository _TypePokemonrepository;
        private readonly IMapper _mapper;
        public TypePokemonServices(ITypePokemonRepository typePokemonRepository,
            IMapper mapper) : base(typePokemonRepository, mapper)
        {
            _TypePokemonrepository = typePokemonRepository;
            _mapper = mapper;
        }

        public async Task<List<TypePokemonViewModels>> GetAllViewModelWithInclude()
        {
            var typeList = await _TypePokemonrepository.GetAllExtensiveInclude();

            TypePokemonViewModels vm = new();          

            return _mapper.Map<List<TypePokemonViewModels>>(typeList);
            
            /*return typeViewModels.Select(type => new TypePokemonViewModels
            {
                Id = type.Id,
                Name = type.Name,
                Description = type.Description,
                PKQuantity = type.typePokemons.Count()               
            }).ToList();*/
        } 
    }
}
