using System.Collections.Generic;
using Pokedex.Models;

namespace Pokedex.Interfaces
{
    public interface IPokemonService
    {
        public IList<Pokemon> GetAllPokemons();

        public IList<Pokemon> GetPokemonWithDexNumber(int dexNumber);

        public IList<Pokemon> GetAllPokemonsWithTypeOf(string typName);
    }
}