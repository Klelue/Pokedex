using Microsoft.AspNetCore.Http;

namespace Pokedex.Interfaces
{
    public interface IFileValidator
    {
        void ValidateFile(IFormFile inputFile);
    }
}