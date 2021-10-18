using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pokedex.Database.Abstractions.Entities;
using Pokedex.Database.Abstractions.Repositories;
using Pokedex.Database.Contexts;

namespace Pokedex.Database.Repositories
{
    public class PokedexRepository : IPokedexRepository
    {
        private readonly PokedexDbContext dbContext;

        public PokedexRepository(PokedexDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Pokemon> GetAllPokemons()
        { 
            return dbContext.Pokemon .Include(pokemon => pokemon.type1).Include(p => p.type2).ToList();
        }

        public List<Pokemon> FindPokemonWithDexNumber(int nationalDexNumber)
        {
            return dbContext.Pokemon.Where(pokemon => pokemon.nationalDexNumber.Equals(nationalDexNumber))
                .Include(pokemon => pokemon.type1).Include(p => p.type2).ToList();
        }

        public List<Pokemon> FindAllPokemonsWithTypeOF(string typeName)
        {
            return dbContext.Pokemon.Where(pokemon => pokemon.type1.typeName.Equals(typeName) || pokemon.type2.typeName.Equals(typeName))
                .Include(pokemon => pokemon.type1).Include(p => p.type2).ToList();
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