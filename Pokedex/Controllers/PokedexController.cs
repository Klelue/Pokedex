using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokedex.Interfaces;
using Pokedex.Models;

namespace Pokedex.Controllers
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

        [HttpGet("{number}")]
        public Pokemon Get(int number)
        {
            return pokemonService.GetPokemonWithDexNumber(number);
        }

        [HttpGet("{typName}")]
        public IEnumerable<Pokemon> Get(string typName)
        {
            return pokemonService.GetAllPokemonsWithTypOf(typName);
        }
    }
}
