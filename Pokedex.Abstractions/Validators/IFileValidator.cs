using Microsoft.AspNetCore.Http;

namespace Pokedex.Abstractions.Validators
{
    public interface IFileValidator
    {
        void ValidateFile(IFormFile inputFile);
    }
}