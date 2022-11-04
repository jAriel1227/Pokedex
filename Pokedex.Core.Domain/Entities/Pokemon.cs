using Pokedex.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Domain.Entities

{
    public class Pokemon : AuditableBaseEntity
    {

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        //Llave foranea
        public int IDRegions { get; set; }

        public int? IDType1Pokemon { get; set; }

        public int? IDType2Pokemon { get; set; }


        //Propiedad de navegación
        public Regions Regions { get; set; }

        public TypePokemon TypePokemon { get; set; }

        public TypePokemon Type2Pokemon { get; set; }

    }
}
