using Pokedex.Core.Application.ViewModels.Regions;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interface.Services
{
    public interface IRegionService : IGenericService<SaveRegionsViewModels,
        RegionsViewModels, Regions>
    {
        Task<List<RegionsViewModels>> GetAllViewModelWithInclude();
    }
}
