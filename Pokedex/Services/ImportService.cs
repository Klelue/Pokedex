using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokedex.Interfaces;

namespace Pokedex.Services
{
    public class ImportService : IImportService
    {
        private readonly IPokemonEntriesValidator validatorPokemonEntries;

        public ImportService(IPokemonEntriesValidator validatorPokemonEntries)
        {
            this.validatorPokemonEntries = validatorPokemonEntries;
        }
        public void ImportPokemons(IEnumerable<string> importFile)
        {
            throw new NotImplementedException();
        }
    }
}
