using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Pokedex.Abstractions.Converters
{
    public interface ICsvToStringConverter
    {
        List<string> GetContentFromFile(IFormFile csvFile);
    }
}