using Pokedex.Core.Application.ViewModels.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels.TypePokemon
{
    public class TypePokemonViewModels
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PKQuantity { get; set; }
        public int PkQuantity2 { get; set; }
        public ICollection<PokemonViewModels> typePokemons { get; set; }
        public ICollection<PokemonViewModels> typePokemons2 { get; set; }
    }
}
