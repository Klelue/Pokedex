using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Abstractions.Converters;
using Pokedex.Abstractions.Services;

namespace Pokedex.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportController : ControllerBase
    {
        private readonly ICsvToStringConverter csvToStringConverter;
        private readonly IImportService importService;

        public ImportController(ICsvToStringConverter csvToStringConverterm, IImportService importService)
        {
            this.csvToStringConverter = csvToStringConverterm;
            this.importService = importService;
        }
        
        [HttpPost]
        public IActionResult ImportPokemon(IFormFile file)
        {
            IList<string> pokemonsContentFromFile = csvToStringConverter.GetContentFromFile(file);
            importService.ImportPokemons(pokemonsContentFromFile);
            return Ok();
        }
    }
}
