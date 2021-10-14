using Pokedex.Exception;
using Pokedex.Interfaces;
using Pokedex.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;



namespace Pokedex.Validators
{
    public class PokemonValidator : IPokemonValidator
    {
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("Pokedex.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());


        public void ValidateUniquenessForPokemon(IList<Pokemon> pokemons)
        {
            IEnumerable<Pokemon> notUniquePokemons = pokemons.Where(pokemon =>
                pokemons
                    .Count(p => p.nationalDexNumber == pokemon.nationalDexNumber && p.name.Equals(pokemon.name)) > 1);
            

            if (notUniquePokemons.Any())
            {
                string notUniquePokemonNationalDexNumbersAsString = string.Join(", ", notUniquePokemons);
                string message = string.Format(
                        ResourceManager.GetString("NoUniquePokemon") ?? string.Empty,
                    notUniquePokemonNationalDexNumbersAsString);
                throw new NonUniquePokemonException(message);
            }
        }

        public void ValidateTotal(int total)
        {
            if (total > Constants.PokemonConstants.MaxTotal || total < Constants.PokemonConstants.MinTotal)
            {
                string message = string.Format(ResourceManager.GetString("TotalOutOfRange") ?? string.Empty, total);
                throw new TotalOutOfRangeException(message);
            }
        }

        //All values together same as total
        public void ValidatesValues(Pokemon pokemon)
        {
            int sumValues = pokemon.attack + pokemon.defense + pokemon.spAttack + 
                            pokemon.spDefense + pokemon.speed + pokemon.healthPoints;

            if (sumValues != pokemon.total)
            {
                string message = ResourceManager.GetString("WrongValues");
                throw new WrongValuesException(message);
            }
        }

        public Typ ValidateTyp(string typName, PokedexDbContext dbContext)
        {
            if (typName.Length > 1)
            {
                Typ typ = dbContext.Typ.Find(typName);
                if (typ == null)
                {
                    string message = string.Format(ResourceManager.GetString("WrongTyp") ?? string.Empty, typName);
                    throw new WrongTypException(message);
                }

                return typ;
            }

            return null;
        }
    }
}