using System.Collections.Generic;
using Pokedex.Database.Abstractions.Entities;
using Pokedex.Database.Contexts;

namespace Pokedex.Abstractions.Validators
{
    public interface IPokemonValidator
    {
        public void ValidateUniquenessForPokemon(IList<Pokemon> pokemons);

        public void ValidateTotal(int total);

        public void ValidatesValues(Pokemon pokemon);

        public Type ValidateTyp(string typeName, PokedexDbContext dbContext);
    }
}