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

        public IList<Pokemon> GetAllPokemonsWithTypOf(string typName)
        {
            requestValidator.ValidateTyp(typName, context);
            CheckIfPokemonImported();

            IList<Pokemon> pokemonWithTypOf = pokedexRepositorx.findAllPokemonsWithTypOF(typName);
            requestValidator.ValidateFoundPokemon(pokemonWithTypOf);
            return pokemonWithTypOf;
        }

        private void CheckIfPokemonImported()
        {
            requestValidator.ValidateImportedPokemon(context);
        }
    }
}