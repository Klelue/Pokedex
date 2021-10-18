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
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("Pokedex.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());

        public void ValidateDexNumber(int number)
        {
            if (number < PokemonConstants.MinPokedexNumber || number > PokemonConstants.MaxPokedexNumber)
            {
                var message = string.Format(ResourceManager.GetString("DexNumberOutOfRange") ?? string.Empty,
                    PokemonConstants.MinPokedexNumber, PokemonConstants.MaxPokedexNumber);
                throw new DexNumberOutOfRangeException(message);
            }
        }

        public void ValidateImportedPokemon(PokedexDbContext context)
        {
            if (!context.Pokemon.Any())
            {
                var message = ResourceManager.GetString("NotImported");
                throw new PokemonNotImportedException(message);
            }
        }

        public void ValidateFoundPokemon(IList<Pokemon> pokemons)
        {
            if (!pokemons.Any())
            {
                var message = ResourceManager.GetString("NotFound");
                throw new PokemonNotFoundException(message);
            }
        }

        public void ValidateType(string typeName, PokedexDbContext context)
        {
            Type type = context.Type.Find(typeName);
            if (type == null)
            {
                var message = string.Format(ResourceManager.GetString("WrongType") ?? String.Empty, typeName);
                throw new WrongTypeException(message);
            }
        }

    }
}