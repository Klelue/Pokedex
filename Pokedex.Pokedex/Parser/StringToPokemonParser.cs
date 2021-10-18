using System;
using System.Reflection;
using System.Resources;
using Pokedex.Abstractions.Exception;
using Pokedex.Abstractions.Parsers;
using Pokedex.Abstractions.Validators;
using Pokedex.Constants;
using Pokedex.Database.Abstractions.Entities;
using Pokedex.Database.Contexts;

namespace Pokedex.Parser
{
    public class StringToPokemonParser : IStringToPokemonParser
    {
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("Pokedex.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());

        public Pokemon ParseStringToPokemon(string stringValue, IPokemonValidator pokemonValidator,
            PokedexDbContext dbContext)
        {
            var valuesList = stringValue.Split(PokemonConstants.PokemonValuesSeperator);
            var pokemon = new Pokemon();
            pokemon.nationalDexNumber = TryToParseToInt(valuesList[0], "nationalDexNumber");
            pokemon.name = valuesList[1];
            pokemon.type1 = pokemonValidator.ValidateTyp(valuesList[2], dbContext);
            pokemon.type2 = pokemonValidator.ValidateTyp(valuesList[3], dbContext);
            var total = TryToParseToInt(valuesList[4], "total");
            pokemonValidator.ValidateTotal(total);
            pokemon.total = total;
            pokemon.healthPoints = TryToParseToInt(valuesList[5], "health points");
            pokemon.attack = TryToParseToInt(valuesList[6], "attack");
            pokemon.defense = TryToParseToInt(valuesList[7], "defense");
            pokemon.spAttack = TryToParseToInt(valuesList[8], "spAttack");
            pokemon.spDefense = TryToParseToInt(valuesList[9], "spDefense");
            pokemon.speed = TryToParseToInt(valuesList[10], "speed");
            pokemonValidator.ValidatesValues(pokemon);
            pokemon.generation = TryToParseToInt(valuesList[11], "generation");
            pokemon.legendary = TryToParseToBool(valuesList[12]);
            return pokemon;
        }

        private int TryToParseToInt(string value, string whatToParse)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                var message = string.Format(ResourceManager.GetString("NoInt") ?? string.Empty, value, whatToParse);
                throw new NoIntException(message);
            }
        }

        private bool TryToParseToBool(string value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                var message = ResourceManager.GetString("NoBool");
                throw new NoBoolException(message);
            }
        }
    }
}