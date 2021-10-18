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
        public void ValidateUniquenessForPokemon(IList<Pokemon> pokemons)
        {
            var notUniquePokemons = pokemons.Where(pokemon =>
                pokemons
                    .Count(p => p.nationalDexNumber == pokemon.nationalDexNumber && p.name.Equals(pokemon.name)) > 1);


            if (notUniquePokemons.Any())
            {
                var notUniquePokemonNationalDexNumbersAsString = string.Join(", ", notUniquePokemons);
                throw new NonUniquePokemonException(notUniquePokemonNationalDexNumbersAsString);
            }
        }

        public void ValidateTotal(int total)
        {
            if (total > Constants.PokemonConstants.MaxTotal || total < Constants.PokemonConstants.MinTotal)
            {
                throw new TotalOutOfRangeException(total);
            }
        }

        //All values together same as total
        public void ValidatesValues(Pokemon pokemon)
        {
            var sumValues = pokemon.attack + pokemon.defense + pokemon.spAttack +
                            pokemon.spDefense + pokemon.speed + pokemon.healthPoints;

            if (sumValues != pokemon.total)
            {
                throw new WrongValuesException();
            }
        }

        public Type ValidateTyp(string typeName, PokedexDbContext dbContext)
        {
            if (typeName.Length > 1)
            {
                var type = dbContext.Type.Find(typeName);
                if (type == null)
                {
                    throw new WrongTypeException(typeName);
                }
                return type;
            }
            return null;
        }
    }
}