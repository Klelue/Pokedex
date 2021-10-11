﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pokedex.Interfaces;
using Pokedex.Models;

namespace Pokedex.Repositories
{
    public class PokedexRepository : IPokedexRepositorx
    {
        private readonly PokedexDbContext dbContext;

        public PokedexRepository(PokedexDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Pokemon> GetAllPokemons()
        { 
            return dbContext.Pokemon.ToList();
        }

        public Pokemon FindPokemonWithDexNumber(int nationalDexNumber)
        {
            return dbContext.Pokemon.FirstOrDefault(pokemon => pokemon.nationalDexNumber.Equals(nationalDexNumber));
        }

        public List<Pokemon> findAllPokemonsWithTypOF(string typName)
        {
            return dbContext.Pokemon.Where(pokemon => pokemon.type1.name.Equals(typName) || pokemon.type2.name.Equals(typName)).ToList();
        }

        public void Save(IEnumerable<Pokemon> pokemons)
        {
            dbContext.Pokemon.RemoveRange(dbContext.Pokemon);
            foreach (var pokemon in pokemons)
            {
                dbContext.Add(pokemon);
            }

            dbContext.SaveChanges();
        }
    }
}