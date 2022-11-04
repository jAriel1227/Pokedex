using Pokedex.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interface.Repositories
{
    public interface IPokemonRepository : IGenericRepository<Pokemon>
    {
        Task<List<Pokemon>> GetAllExtensiveInclude();
    }
}
