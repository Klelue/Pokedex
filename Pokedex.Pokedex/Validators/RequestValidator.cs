using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using Pokedex.Abstractions.Exception;
using Pokedex.Abstractions.Validators;
using Pokedex.Constants;
using Pokedex.Database.Abstractions.Entities;
using Pokedex.Database.Contexts;
using Type = Pokedex.Database.Abstractions.Entities.Type;

namespace Pokedex.Validators
{
    public class RequestValidator : IRequestValidator
    {
        public void ValidateDexNumber(int number)
        {
            if (number < PokemonConstants.MinPokedexNumber || number > PokemonConstants.MaxPokedexNumber)
            {
                throw new DexNumberOutOfRangeException(PokemonConstants.MinPokedexNumber, PokemonConstants.MaxPokedexNumber);
            }
        }

        public void ValidateImportedPokemon(PokedexDbContext context)
        {
            if (!context.Pokemon.Any())
            { 
                throw new PokemonNotImportedException();
            }
        }

        public void ValidateFoundPokemon(IList<Pokemon> pokemons)
        {
            if (!pokemons.Any())
            {
                throw new PokemonNotFoundException();
            }
        }

        public void ValidateType(string typeName, PokedexDbContext context)
        {
            Type type = context.Type.Find(typeName);
            if (type == null)
            {
                throw new WrongTypeException(typeName);
            }
        }

    }
}