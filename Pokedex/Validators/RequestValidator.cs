using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using Pokedex.Constants;
using Pokedex.Exception;
using Pokedex.Interfaces;
using Pokedex.Models;

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

        public void ValidateTyp(string typName, PokedexDbContext context)
        {
            Typ typ = context.Typ.Find(typName);
            if (typ == null)
            {
                var message = string.Format(ResourceManager.GetString("WrongTyp") ?? String.Empty, typName);
                throw new WrongTypException(message);
            }
        }

    }
}