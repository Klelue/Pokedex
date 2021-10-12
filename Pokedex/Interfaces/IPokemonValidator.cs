
using System.Collections.Generic;
using Pokedex.Models;

namespace Pokedex.Interfaces
{
    public interface IPokemonValidator
    {
        public void ValidateUniquenessForPokemon(IList<Pokemon> pokemons);

        public void ValidateTotal(int total);

        public void ValidatesValues(Pokemon pokemon);

        public Typ ValidateTyp(string typ, PokedexDbContext dbContext);
    }
}