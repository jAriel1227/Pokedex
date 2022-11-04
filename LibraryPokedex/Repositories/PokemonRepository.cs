using Pokedex.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Pokedex.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Core.Application.Interface.Repositories;

namespace Pokedex.Infrastructure.Persistence.Repositories
{
    public class PokemonRepository : GenericRepository<Pokemon>, IPokemonRepository
    {
        private readonly PokedexContext _dbpokedexContext;

        public PokemonRepository(PokedexContext dbpokedexContext) : base(dbpokedexContext)
        {
            _dbpokedexContext = dbpokedexContext;
        }   
        public async Task<List<Pokemon>> GetAllExtensiveInclude()
        {
            return await _dbpokedexContext
                .Set<Pokemon>()
                .Include(p => p.Regions)
                .Include(p => p.TypePokemon)
                .Include(p => p.Type2Pokemon)
                .ToListAsync();
        }
    }
}
