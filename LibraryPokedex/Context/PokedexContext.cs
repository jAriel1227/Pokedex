using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Domain.Common;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence.Context
{
    public class PokedexContext :   DbContext
    {
        public PokedexContext(DbContextOptions<PokedexContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Regions> Region { get; set; }
        public DbSet<TypePokemon> TypePokemons { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedTime = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultPokedexUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LasModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultPokedexUser";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            #region "Table"
            modelBuilder.Entity<Pokemon>()
                .ToTable("Pokemones");
            modelBuilder.Entity<Regions>()
                .ToTable("Regiones");
            modelBuilder.Entity<TypePokemon>()
                .ToTable("Tipos_Pokemones");
            #endregion

            #region "Primarykey"
            modelBuilder.Entity<Pokemon>()
                .HasKey(pokemon=> pokemon.Id);
            modelBuilder.Entity<Regions>()
                .HasKey(region => region.Id);
            modelBuilder.Entity<TypePokemon>()
                .HasKey(typePokemon => typePokemon.Id);
            #endregion

            #region "Relaciones"
            modelBuilder.Entity<Regions>()
                .HasMany<Pokemon>(region => region.pokemons)
                .WithOne(pokemon => pokemon.Regions)
                .HasForeignKey(pokemon=> pokemon.IDRegions);

            modelBuilder.Entity<TypePokemon>()
                .HasMany<Pokemon>(typePokemon => typePokemon.typePokemons)
                .WithOne(pokemon => pokemon.TypePokemon)
                .HasForeignKey(pokemon => pokemon.IDType1Pokemon);

            modelBuilder.Entity<TypePokemon>()
                .HasMany<Pokemon>(typePokemon => typePokemon.typePokemons2)
                .WithOne(pokemon => pokemon.Type2Pokemon)
                .HasForeignKey(pokemon => pokemon.IDType2Pokemon);
            #endregion

            #region "Configuaciones de requerimientos"
            #region 
            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.ImageUrl)
                .IsRequired();
            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.IDType1Pokemon)
                .IsRequired();
            #endregion
            #region
            modelBuilder.Entity<TypePokemon>()
                .Property(pokemon => pokemon.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<TypePokemon>()
                .Property(pokemon => pokemon.Description)
                .IsRequired()
                .HasMaxLength(360);
            #endregion
            #region
            modelBuilder.Entity<Regions>()
                .Property(pokemon => pokemon.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Regions>()
                .Property(pokemon => pokemon.Description)
                .IsRequired()
                .HasMaxLength(360);
            #endregion
            #endregion
        }
    }
}
