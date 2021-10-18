using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pokedex.Database.Abstractions.Entities;
using Pokedex.Database.Abstractions.Resources;

namespace Pokedex.Database.Contexts
{
    public class PokedexDbContext : DbContext
    {
        public PokedexDbContext(DbContextOptions<PokedexDbContext> options) : base(options)
        {
        }

        public DbSet<Pokemon> Pokemon { get; set; }

        public DbSet<Type> Type { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=PokedexDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>().HasKey(pokemon => new {pokemon.nationalDexNumber, pokemon.name});
            GeneratedTyps generaterTyps = new GeneratedTyps();
            List<Type> typs = generaterTyps.GetTyps();
            foreach (var typ in typs)
            {
                modelBuilder.Entity<Type>().HasData(typ);
            }
            
            modelBuilder.Entity<Type>().HasKey(typ => typ.typeName);
        }


    }
}


