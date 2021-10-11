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
            GeneratedTyps typs = new GeneratedTyps();
            modelBuilder.Entity<Typ>().HasData(typs.GetTyps());
        }


    }
}


