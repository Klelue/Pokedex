using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Pokedex.Interfaces
{
    public interface ICsvToStringConverter
    {
        List<string> GetContentFromFile(IFormFile csvFile);
    }
}