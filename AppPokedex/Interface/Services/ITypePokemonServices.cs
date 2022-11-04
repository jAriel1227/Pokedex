using Pokedex.Core.Application.ViewModels.TypePokemon;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interface.Services
{
    public interface ITypePokemonServices : IGenericService<TypeSaveViewModels,
        TypePokemonViewModels, TypePokemon>
    {
        Task<List<TypePokemonViewModels>> GetAllViewModelWithInclude();
    }
}
