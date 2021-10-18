using System.Collections.Generic;
using Pokedex.Interfaces;
using Pokedex.Models;

namespace Pokedex.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokedexRepository pokedexRepositorx;
        private readonly IRequestValidator requestValidator;
        private readonly PokedexDbContext context;


        public PokemonService(IPokedexRepository pokedexRepositorx, IRequestValidator requestValidator, PokedexDbContext context)
        {
            this.pokedexRepositorx = pokedexRepositorx;
            this.requestValidator = requestValidator;
            this.context = context;
        }
        public IList<Pokemon> GetAllPokemons()
        {
            CheckIfPokemonImported();
            return pokedexRepositorx.GetAllPokemons();
        }

        public IList<Pokemon> GetPokemonWithDexNumber(int dexNumber)
        {
            requestValidator.ValidateDexNumber(dexNumber);
            CheckIfPokemonImported();

            IList<Pokemon> pokemonWithDexNumber = pokedexRepositorx.FindPokemonWithDexNumber(dexNumber);
            requestValidator.ValidateFoundPokemon(pokemonWithDexNumber);
            return pokemonWithDexNumber;
        }

        public IList<Pokemon> GetAllPokemonsWithTypeOf(string typName)
        {
            requestValidator.ValidateType(typName, context);
            CheckIfPokemonImported();

            IList<Pokemon> pokemonWithTypeOf = pokedexRepositorx.FindAllPokemonsWithTypeOF(typName);
            requestValidator.ValidateFoundPokemon(pokemonWithTypeOf);
            return pokemonWithTypeOf;
        }

        private void CheckIfPokemonImported()
        {
            requestValidator.ValidateImportedPokemon(context);
        }
    }
}