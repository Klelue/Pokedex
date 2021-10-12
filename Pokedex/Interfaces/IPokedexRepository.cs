using System.Collections.Generic;
using Pokedex.Models;

namespace Pokedex.Interfaces
{
    public interface IPokedexRepository
    {
        List<Pokemon> GetAllPokemons();

        List<Pokemon> FindPokemonWithDexNumber(int nationalDexNumber);

        List<Pokemon> findAllPokemonsWithTypOF(string typName);

        void Save(IEnumerable<Pokemon> pokemons);


    }
}