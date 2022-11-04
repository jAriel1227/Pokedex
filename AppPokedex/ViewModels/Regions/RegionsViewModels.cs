using Pokedex.Core.Application.ViewModels.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels.Regions
{
    public class RegionsViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PKQuantity { get; set; }

        public ICollection<PokemonViewModels> pokemons { get; set; }
    }
}
