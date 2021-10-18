using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Abstractions.Services;
using Pokedex.Database.Abstractions.Entities;

namespace Pokedex.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokedexController : Controller
    {
        private readonly IPokemonService pokemonService;

        public PokedexController(IPokemonService pokemonService)
        {
            this.pokemonService = pokemonService;
        }

        [HttpGet]
        public IEnumerable<Pokemon> Get()
        {
            return pokemonService.GetAllPokemons();
        }

        [HttpGet("dexnumber/{number}")]
        public IEnumerable<Pokemon> GetPokemonWithNumber(int number)
        {
            return pokemonService.GetPokemonWithDexNumber(number);
        }

        [HttpGet("typname/{typeName}")]
        public IEnumerable<Pokemon> GetPokemonWithTypName(string typName)
        {
            return pokemonService.GetAllPokemonsWithTypeOf(typName);
        }
    }
}
