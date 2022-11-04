using AutoMapper;
using Pokedex.Core.Application.ViewModels.Pokemon;
using Pokedex.Core.Application.ViewModels.Regions;
using Pokedex.Core.Application.ViewModels.TypePokemon;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Pokemon, PokemonViewModels>()
               .ForMember(x => x.NamePrimario, opt => opt.MapFrom(p=> p.TypePokemon.Name))
               .ForMember(x => x.NameSecundario, opt => opt.MapFrom(p=> p.Type2Pokemon.Name)) 
               .ForMember(x => x.Region, opt => opt.MapFrom(p=> p.Regions.Name))
               .ReverseMap()              
               .ForMember(x => x.CreatedTime, opt => opt.Ignore())
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.LasModified, opt => opt.Ignore())
               .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Pokemon, SavePkViewModels>()
               .ForMember(x => x.Regiones, opt => opt.Ignore())
               .ForMember(x => x.Tipos, opt => opt.Ignore())              
               .ReverseMap()
               .ForMember(x => x.Regions, opt => opt.Ignore())
               .ForMember(x => x.TypePokemon, opt => opt.Ignore())
               .ForMember(x => x.Type2Pokemon, opt => opt.Ignore())
               .ForMember(x => x.CreatedTime, opt => opt.Ignore())
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.LasModified, opt => opt.Ignore())
               .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Regions, RegionsViewModels>()
               .ForMember(x => x.PKQuantity, opt => opt.MapFrom(pt => pt.pokemons.Count))
               .ReverseMap()               
               .ForMember(x => x.CreatedTime, opt => opt.Ignore())
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.LasModified, opt => opt.Ignore())
               .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Regions, SaveRegionsViewModels>()              
               .ReverseMap()
               .ForMember(x => x.pokemons, opt => opt.Ignore())
               .ForMember(x => x.CreatedTime, opt => opt.Ignore())
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.LasModified, opt => opt.Ignore())
               .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<TypePokemon, TypePokemonViewModels>()
              .ForMember(x => x.PKQuantity, opt => opt.MapFrom(pt => pt.typePokemons.Count))
              .ForMember(x => x.PkQuantity2, opt => opt.MapFrom(pt => pt.typePokemons2.Count))
              .ReverseMap()              
              .ForMember(x => x.CreatedTime, opt => opt.Ignore())
              .ForMember(x => x.CreatedBy, opt => opt.Ignore())
              .ForMember(x => x.LasModified, opt => opt.Ignore())
              .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<TypePokemon, TypeSaveViewModels>()
               .ReverseMap()
               .ForMember(x => x.typePokemons, opt => opt.Ignore())
              .ForMember(x => x.typePokemons2, opt => opt.Ignore())
               .ForMember(x => x.CreatedTime, opt => opt.Ignore())
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.LasModified, opt => opt.Ignore())
               .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());
        }
    }
}
