using Microsoft.AspNetCore.Mvc.Rendering;
using Pokedex.Core.Application.ViewModels.Regions;
using Pokedex.Core.Application.ViewModels.TypePokemon;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pokedex.Core.Application.ViewModels.Pokemon
{
    public class SavePkViewModels
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre del Pokemon...")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe colocar el Url de la imagen...")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Seleccione una region...")]
        public int IDRegions { get; set; }     
             
        [Required(ErrorMessage = "Seleccione el tipo primario...")]
        public int IDType1Pokemon { get; set; }    

        public int IDType2Pokemon { get; set; }        

        //List Regions and Types        
        public List<RegionsViewModels> Regiones { get; set; }        
        public List<TypePokemonViewModels> Tipos { get; set; }
    }
}
