
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Interfaces;


namespace Pokedex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportController : ControllerBase
    {
        private readonly PokedexDbContext context;
        private readonly ICsvToStringConverter csvToStringConverter;
        private readonly IImportService importService;

        public ImportController(PokedexDbContext context, ICsvToStringConverter csvToStringConverterm, IImportService importService)
        {
            this.context = context;
            this.csvToStringConverter = csvToStringConverterm;
            this.importService = importService;
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ImportPokemon(IFormFile file)
        {
            IEnumerable<string> pokemonsContentFromFile = csvToStringConverter.GetContentFromFile(file);
            importService.ImportPokemons(pokemonsContentFromFile);
            return Ok();
        }


    }
}
