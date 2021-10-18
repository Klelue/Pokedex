using System.Reflection;
using System.Resources;

namespace Pokedex.Abstractions.Exception
{
    public class PokemonNotImportedException : System.Exception
    {
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("Pokedex.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
        public PokemonNotImportedException() : base(ResourceManager.GetString("NotImported"))
        {
        }
    }
}