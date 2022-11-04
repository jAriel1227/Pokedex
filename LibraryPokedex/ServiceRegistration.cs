using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Core.Application.Interface.Repositories;
using Pokedex.Infrastructure.Persistence.Context;
using Pokedex.Infrastructure.Persistence.Repositories;

namespace Pokedex.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contextos
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<PokedexContext>(options => options.UseInMemoryDatabase("DBAplication"));
            }
            else
            {
                services.AddDbContext<PokedexContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DBPokedex"),
                j => j.MigrationsAssembly(typeof(PokedexContext).Assembly.FullName)));
            }
            #endregion

            #region Repositorios
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPokemonRepository, PokemonRepository>();
            services.AddTransient<IRegionsRepository, RegionsRepository>();
            services.AddTransient<ITypePokemonRepository, TypePokemonRepository>();
            #endregion
        }
    }
}
