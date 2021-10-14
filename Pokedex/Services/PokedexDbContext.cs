using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pokedex.Models;
using Pokedex.Resources;

namespace Pokedex
{
    public class PokedexDbContext : DbContext
    {
        public PokedexDbContext(DbContextOptions<PokedexDbContext> options) : base(options)
        {
        }

        public DbSet<Pokemon> Pokemon { get; set; }

        public DbSet<Typ> Typ { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=PokedexDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>().HasKey(pokemon => new {pokemon.nationalDexNumber, pokemon.name});
            GeneratedTyps generaterTyps = new GeneratedTyps();
            List<Typ> typs = generaterTyps.GetTyps();
            foreach (var typ in typs)
            {
                modelBuilder.Entity<Typ>().HasData(typ);
            }
            
            modelBuilder.Entity<Typ>().HasKey(typ => typ.typName);
        }


    }
}


