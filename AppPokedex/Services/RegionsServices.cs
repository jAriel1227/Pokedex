using AutoMapper;
using Pokedex.Core.Application.Interface.Repositories;
using Pokedex.Core.Application.Interface.Services;
using Pokedex.Core.Application.ViewModels.Regions;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Services 
{
    public class RegionsServices : GenericServices<SaveRegionsViewModels,RegionsViewModels,Regions>, IRegionService
    {
        private readonly IRegionsRepository _regionsRepository;
        private readonly IMapper _mapper;
   
        public RegionsServices(IRegionsRepository regionsRepository,
            IMapper mapper) : base(regionsRepository, mapper)
        {
            _regionsRepository = regionsRepository;
            _mapper = mapper;
        }
        public async Task<List<RegionsViewModels>> GetAllViewModelWithInclude()
        {
            var regionList = await _regionsRepository.GetAllExtensiveInclude();

            return _mapper.Map<List<RegionsViewModels>>(regionList);
            
            /*return regionViewModels.Select(regions => new RegionsViewModels
            {
                Id = regions.Id,
                Name = regions.Name,
                Description = regions.Description,
                PKQuantity = regions.pokemons.Count()
            }).ToList();*/
        }      
    }
}
