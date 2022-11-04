using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Application.Interface.Repositories;
using Pokedex.Core.Domain.Entities;
using Pokedex.Infrastructure.Persistence.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence.Repositories
{
    public class RegionsRepository : GenericRepository<Regions>, IRegionsRepository
    {
        private readonly PokedexContext _dbpokedexContext;

        public RegionsRepository(PokedexContext dbpokedexContext) : base(dbpokedexContext)
        {
            _dbpokedexContext = dbpokedexContext;
        }
        public async Task<List<Regions>> GetAllExtensiveInclude()
        {
            return await _dbpokedexContext
                .Set<Regions>()
                .Include(r => r.pokemons)
                .ToListAsync();
        }
    }
}
