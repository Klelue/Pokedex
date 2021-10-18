using System.Collections.Generic;
using Pokedex.Abstractions.Parsers;
using Pokedex.Abstractions.Services;
using Pokedex.Abstractions.Validators;
using Pokedex.Database.Abstractions.Entities;
using Pokedex.Database.Abstractions.Repositories;
using Pokedex.Database.Contexts;

namespace Pokedex.Services
{
    public class ImportService : IImportService
    {
        private readonly IPokemonValidator validatorPokemon;
        private readonly IPokedexRepository pokedexRepository;
        private readonly IStringToPokemonParser stringToPokemonParser;
        private readonly PokedexDbContext dbContext;

        public ImportService(IPokemonValidator validatorPokemon, IPokedexRepository pokedexRepository,
            IStringToPokemonParser stringToPokemonParser, PokedexDbContext dbContext)
        {
            this.validatorPokemon = validatorPokemon;
            this.pokedexRepository = pokedexRepository;
            this.stringToPokemonParser = stringToPokemonParser;
            this.dbContext = dbContext;
        }

        public void ImportPokemons(IList<string> importFile)
        {
            var pokemons = createPokemons(importFile);
            validatorPokemon.ValidateUniquenessForPokemon(pokemons);
            pokedexRepository.Save(pokemons);
        }

        private List<Pokemon> createPokemons(IList<string> importFile)
        {
            var pokemons = new List<Pokemon>();
            foreach (var pokemonAsString in importFile)
            {
                var pokemon = stringToPokemonParser.ParseStringToPokemon(pokemonAsString, validatorPokemon, dbContext);
                pokemons.Add(pokemon);
            }

            return pokemons;
        }
    }
}