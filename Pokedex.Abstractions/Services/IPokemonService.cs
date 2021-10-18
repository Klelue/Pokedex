using System.Collections.Generic;
using Pokedex.Database.Abstractions.Entities;

namespace Pokedex.Abstractions.Services
{
    public interface IPokemonService
    {
        public IList<Pokemon> GetAllPokemons();

        public IList<Pokemon> GetPokemonWithDexNumber(int dexNumber);

        public IList<Pokemon> GetAllPokemonsWithTypeOf(string typName);
    }
}