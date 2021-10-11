using System;
using System.Collections.Generic;
using System.Linq;
using Pokedex.Interfaces;
using Pokedex.Models;

namespace Pokedex.Services
{
    public class ImportService : IImportService
    {
        private readonly IPokemonValidator validatorPokemon;
        private readonly IPokedexRepository pokedexRepository;
        private readonly IStringToPokemonParser stringToPokemonParser;
        private readonly PokedexDbContext dbContext;

        public ImportService(IPokemonValidator validatorPokemon, IPokedexRepository pokedexRepository, IStringToPokemonParser stringToPokemonParser, PokedexDbContext dbContext)
        {
            this.validatorPokemon = validatorPokemon;
            this.pokedexRepository = pokedexRepository;
            this.stringToPokemonParser = stringToPokemonParser;
            this.dbContext = dbContext;
        }
        public void ImportPokemons(IEnumerable<string> importFile)
        {
            List<Pokemon> pokemons = createPokemons(importFile);
            validatorPokemon.ValidateUniquenessForPokemon(pokemons);
            pokedexRepository.Save(pokemons);

        }

        private List<Pokemon> createPokemons(IEnumerable<string> importFile)
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            foreach (string pokemonAsString in importFile)
            {
                Pokemon pokemon = stringToPokemonParser.ParseStringToPokemon(pokemonAsString, validatorPokemon, dbContext);
                pokemons.Add(pokemon);
            }

            return pokemons;
        }


    }
}
