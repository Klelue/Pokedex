using Pokedex.Abstractions.Validators;
using Pokedex.Database.Abstractions.Entities;
using Pokedex.Database.Contexts;

namespace Pokedex.Abstractions.Parsers
{
    public interface IStringToPokemonParser
    {
        public Pokemon ParseStringToPokemon(string stringValue, IPokemonValidator pokemonValidator,
            PokedexDbContext dbContext);

    }
}