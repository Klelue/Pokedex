using System.Collections.Generic;

namespace Pokedex.Interfaces
{
    public interface IImportService
    {
        void ImportPokemons(IEnumerable<string> importFile);
    }
}