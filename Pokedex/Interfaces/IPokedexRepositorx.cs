using System.Collections.Generic;
using Pokedex.Models;

namespace Pokedex.Interfaces
{
    public interface IPokedexRepositorx
    {
        List<Pokemon> GetAllPokemons();

        Pokemon FindPokemonWithDexNumber(int nationalDexNumber);

        List<Pokemon> findAllPokemonsWithTypOF(string typName);

        void Save(IEnumerable<Pokemon> pokemons);


    }
}