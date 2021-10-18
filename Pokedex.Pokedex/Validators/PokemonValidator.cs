using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using Pokedex.Abstractions.Exception;
using Pokedex.Abstractions.Validators;
using Pokedex.Database.Abstractions.Entities;
using Pokedex.Database.Contexts;

namespace Pokedex.Validators
{
    public class PokemonValidator : IPokemonValidator
    {
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("Pokedex.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());


        public void ValidateUniquenessForPokemon(IList<Pokemon> pokemons)
        {
            var notUniquePokemons = pokemons.Where(pokemon =>
                pokemons
                    .Count(p => p.nationalDexNumber == pokemon.nationalDexNumber && p.name.Equals(pokemon.name)) > 1);


            if (notUniquePokemons.Any())
            {
                var notUniquePokemonNationalDexNumbersAsString = string.Join(", ", notUniquePokemons);
                var message = string.Format(
                    ResourceManager.GetString("NoUniquePokemon") ?? string.Empty,
                    notUniquePokemonNationalDexNumbersAsString);
                throw new NonUniquePokemonException(message);
            }
        }

        public void ValidateTotal(int total)
        {
            if (total > Constants.PokemonConstants.MaxTotal || total < Constants.PokemonConstants.MinTotal)
            {
                var message = string.Format(ResourceManager.GetString("TotalOutOfRange") ?? string.Empty, total);
                throw new TotalOutOfRangeException(message);
            }
        }

        //All values together same as total
        public void ValidatesValues(Pokemon pokemon)
        {
            var sumValues = pokemon.attack + pokemon.defense + pokemon.spAttack +
                            pokemon.spDefense + pokemon.speed + pokemon.healthPoints;

            if (sumValues != pokemon.total)
            {
                var message = ResourceManager.GetString("WrongValues");
                throw new WrongValuesException(message);
            }
        }

        public Type ValidateTyp(string typeName, PokedexDbContext dbContext)
        {
            if (typeName.Length > 1)
            {
                var type = dbContext.Type.Find(typeName);
                if (type == null)
                {
                    var message = string.Format(ResourceManager.GetString("WrongType") ?? string.Empty, typeName);
                    throw new WrongTypeException(message);
                }

                return type;
            }

            return null;
        }
    }
}