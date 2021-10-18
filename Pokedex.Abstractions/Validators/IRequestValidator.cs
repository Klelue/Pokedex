using System.Collections.Generic;
using Pokedex.Database.Abstractions.Entities;
using Pokedex.Database.Contexts;

namespace Pokedex.Abstractions.Validators
{
    public interface IRequestValidator
    {
        public void ValidateDexNumber(int number);

        public void ValidateImportedPokemon(PokedexDbContext context);

        public void ValidateFoundPokemon(IList<Pokemon> pokemons);

        public void ValidateType(string typeName, PokedexDbContext context);
    }
}