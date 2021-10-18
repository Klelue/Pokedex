using System.Collections.Generic;

namespace Pokedex.Abstractions.Services
{
    public interface IImportService
    {
        void ImportPokemons(IList<string> importFile);
    }
}