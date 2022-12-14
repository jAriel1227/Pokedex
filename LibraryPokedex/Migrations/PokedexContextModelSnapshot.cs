// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokedex.Infrastructure.Persistence.Context;

namespace LibraryPokedex.Migrations
{
    [DbContext(typeof(PokedexContext))]
    partial class PokedexContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pokedex.Core.Domain.Entities.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDRegions")
                        .HasColumnType("int");

                    b.Property<int?>("IDType1Pokemon")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IDType2Pokemon")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LasModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IDRegions");

                    b.HasIndex("IDType1Pokemon");

                    b.HasIndex("IDType2Pokemon");

                    b.ToTable("Pokemones");
                });

            modelBuilder.Entity("Pokedex.Core.Domain.Entities.Regions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(360)
                        .HasColumnType("nvarchar(360)");

                    b.Property<DateTime?>("LasModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Regiones");
                });

            modelBuilder.Entity("Pokedex.Core.Domain.Entities.TypePokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(360)
                        .HasColumnType("nvarchar(360)");

                    b.Property<DateTime?>("LasModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tipos_Pokemones");
                });

            modelBuilder.Entity("Pokedex.Core.Domain.Entities.Pokemon", b =>
                {
                    b.HasOne("Pokedex.Core.Domain.Entities.Regions", "Regions")
                        .WithMany("pokemons")
                        .HasForeignKey("IDRegions")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokedex.Core.Domain.Entities.TypePokemon", "TypePokemon")
                        .WithMany("typePokemons")
                        .HasForeignKey("IDType1Pokemon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokedex.Core.Domain.Entities.TypePokemon", "Type2Pokemon")
                        .WithMany("typePokemons2")
                        .HasForeignKey("IDType2Pokemon");

                    b.Navigation("Regions");

                    b.Navigation("Type2Pokemon");

                    b.Navigation("TypePokemon");
                });

            modelBuilder.Entity("Pokedex.Core.Domain.Entities.Regions", b =>
                {
                    b.Navigation("pokemons");
                });

            modelBuilder.Entity("Pokedex.Core.Domain.Entities.TypePokemon", b =>
                {
                    b.Navigation("typePokemons");

                    b.Navigation("typePokemons2");
                });
#pragma warning restore 612, 618
        }
    }
}
