using System.Reflection;
using System.Resources;

namespace Pokedex.Abstractions.Exception
{
    public class PokemonNotFoundException : System.Exception
    {
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("Pokedex.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
        public PokemonNotFoundException() : base(ResourceManager.GetString("NotFound"))
        {
        }
    }
}