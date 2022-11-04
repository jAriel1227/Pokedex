using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels.TypePokemon 
{ 
    public class TypeSaveViewModels
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre del tipo de pokemon...")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
