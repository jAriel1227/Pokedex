using Pokedex.Core.Application.ViewModels.Regions;
using Pokedex.Core.Application.ViewModels.TypePokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels.Pokemon
{
    public class PokemonViewModels
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Region { get; set; }

        public int IDRegions { get; set; }

        public int? IDType1Pokemon { get; set; }

        public int? IDType2Pokemon { get; set; }

        public string NamePrimario  { get; set; }
        public string NameSecundario { get; set; }

        //
        public RegionsViewModels Regions { get; set; }

        public TypePokemonViewModels TypePokemon { get; set; }

        public TypePokemonViewModels Type2Pokemon { get; set; }
    }
}
