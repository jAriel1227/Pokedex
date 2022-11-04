using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pokedex.Core.Domain.Entities;

namespace Pokedex.Core.Application.Interface.Repositories
{
    public interface ITypePokemonRepository : IGenericRepository<TypePokemon>
    {
        Task<List<TypePokemon>> GetAllExtensiveInclude();
    }
}
