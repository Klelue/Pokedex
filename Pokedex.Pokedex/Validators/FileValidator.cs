using System.Reflection;
using System.Resources;
using Microsoft.AspNetCore.Http;
using Pokedex.Abstractions.Exception;
using Pokedex.Abstractions.Validators;

namespace Pokedex.Validators
{
    public class FileValidator : IFileValidator
    {
        private static readonly ResourceManager resourceManager =
            new ResourceManager("Pokedex.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());

        public void ValidateFile(IFormFile inputFile)
        {
            const string ContentType = "text/csv";

            if (inputFile == null)
            {
                string message = string.Format(
                    resourceManager.GetString("NoFile") ?? string.Empty,
                    ContentType);
                throw new InvalidCsvDataException(message);
            }

            if (inputFile.Length == 0)
            {
                string message = resourceManager.GetString("NoDataInFile");
                throw new InvalidCsvDataException(message);
            }
        }
    }
}
