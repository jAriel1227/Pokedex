using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Application.Interface.Repositories;
using Pokedex.Core.Domain.Entities;
using Pokedex.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence.Repositories
{
    public class TypePokemonRepository : GenericRepository<TypePokemon>, ITypePokemonRepository
    {
        private readonly PokedexContext _dbpokedexContext;

        public TypePokemonRepository(PokedexContext dbpokedexContext) : base(dbpokedexContext)
        {
            _dbpokedexContext = dbpokedexContext;
        }
        public async Task<List<TypePokemon>> GetAllExtensiveInclude()
        {
            return await _dbpokedexContext
                .Set<TypePokemon>()
                .Include(t => t.typePokemons)
                .Include(t=> t.typePokemons2)                
                .ToListAsync();
        }
    }
}
