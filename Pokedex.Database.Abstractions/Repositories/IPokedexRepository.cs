using System.Collections.Generic;
using Pokedex.Database.Abstractions.Entities;

namespace Pokedex.Database.Abstractions.Repositories
{
    public interface IPokedexRepository
    {
        List<Pokemon> GetAllPokemons();

        List<Pokemon> FindPokemonWithDexNumber(int nationalDexNumber);

        List<Pokemon> FindAllPokemonsWithTypeOF(string typeName);

        void Save(IEnumerable<Pokemon> pokemons);


    }
}