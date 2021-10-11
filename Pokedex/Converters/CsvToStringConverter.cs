using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Pokedex.Interfaces;

namespace Pokedex.Converters
{
    public class CsvToStringConverter : ICsvToStringConverter
    {
        private readonly IFileValidator fileValidator;

        public CsvToStringConverter(IFileValidator fileValidator)
        {
            this.fileValidator = fileValidator;
        }

        public List<string> GetContentFromFile(IFormFile csvFile)
        {
            fileValidator.ValidateFile(csvFile);
            List<string> content = new List<string>();
            using StreamReader reader = new StreamReader(csvFile.OpenReadStream());
            while (!reader.EndOfStream)
            {
                content.Add(reader.ReadLine());
            }

            return content;
        }

    }
}