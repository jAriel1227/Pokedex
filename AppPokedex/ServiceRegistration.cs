using Microsoft.Extensions.DependencyInjection;
using Pokedex.Core.Application.Interface.Services;
using Pokedex.Core.Application.Services;
using System.Reflection;

namespace Pokedex.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region Automapp
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #endregion

            #region Servicios
            services.AddTransient<IPokemonService, PokemonServices>();
            services.AddTransient<IRegionService, RegionsServices>();
            services.AddTransient<ITypePokemonServices, TypePokemonServices>();
            #endregion
        }
    }
}
