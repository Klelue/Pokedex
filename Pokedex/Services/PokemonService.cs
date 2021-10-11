using System.Collections.Generic;
using Pokedex.Interfaces;
using Pokedex.Models;

namespace Pokedex.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokedexRepositorx pokedexRepositorx;

        public PokemonService(IPokedexRepositorx pokedexRepositorx)
        {
            this.pokedexRepositorx = pokedexRepositorx;
        }
        public IEnumerable<Pokemon> GetAllPokemons()
        {
            return pokedexRepositorx.GetAllPokemons();
        }

        public Pokemon GetPokemonWithDexNumber(int dexNumber)
        {
           return pokedexRepositorx.FindPokemonWithDexNumber(dexNumber);
        }

        public IEnumerable<Pokemon> GetAllPokemonsWithTypOf(string typName)
        {
            return pokedexRepositorx.findAllPokemonsWithTypOF(typName);
        }
    }
}