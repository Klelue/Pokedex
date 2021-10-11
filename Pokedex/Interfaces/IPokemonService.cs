using System.Collections.Generic;
using Pokedex.Models;

namespace Pokedex.Interfaces
{
    public interface IPokemonService
    {
        public IEnumerable<Pokemon> GetAllPokemons();

        public Pokemon GetPokemonWithDexNumber(int dexNumber);

        public IEnumerable<Pokemon> GetAllPokemonsWithTypOf(string typName);
    }
}