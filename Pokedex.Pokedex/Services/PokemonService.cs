using System.Collections.Generic;
using Pokedex.Abstractions.Services;
using Pokedex.Abstractions.Validators;
using Pokedex.Database.Abstractions.Entities;
using Pokedex.Database.Abstractions.Repositories;
using Pokedex.Database.Contexts;

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