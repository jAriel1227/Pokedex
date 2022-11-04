using Pokedex.Core.Application.ViewModels.Pokemon;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interface.Services
{
    public interface IPokemonService : IGenericService<SavePkViewModels,
        PokemonViewModels, Pokemon>
    {
        Task<List<PokemonViewModels>> GetAllViewModelWithFilters(FilterPokemonViewModel filters); 
        Task<List<PokemonViewModels>> GetAllName(string name);
        Task<List<PokemonViewModels>> GetAllViewModelWithInclude();
    }
}
