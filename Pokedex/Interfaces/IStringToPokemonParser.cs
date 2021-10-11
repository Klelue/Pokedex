using System.Collections.Generic;
using Pokedex.Models;

namespace Pokedex.Interfaces
{
    public interface IStringToPokemonParser
    {
        public Pokemon ParseStringToPokemon(string stringValue, IPokemonValidator pokemonValidator,
            PokedexDbContext dbContext);

    }
}