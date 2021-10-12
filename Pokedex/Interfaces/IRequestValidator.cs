using System.Collections.Generic;
using Pokedex.Models;

namespace Pokedex.Interfaces
{
    public interface IRequestValidator
    {
        public void ValidateDexNumber(int number);

        public void ValidateImportedPokemon(PokedexDbContext context);

        public void ValidateFoundPokemon(IList<Pokemon> pokemons);

        public void ValidateTyp(string typName, PokedexDbContext context);
    }
}