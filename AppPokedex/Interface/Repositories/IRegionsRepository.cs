using Microsoft.AspNetCore.Mvc.Rendering;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interface.Repositories
{
    public interface IRegionsRepository : IGenericRepository<Regions>
    {
        Task<List<Regions>> GetAllExtensiveInclude();
    }
}
