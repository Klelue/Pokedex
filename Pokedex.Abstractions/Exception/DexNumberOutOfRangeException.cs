using System.Reflection;
using System.Resources;

namespace Pokedex.Abstractions.Exception
{
    public class DexNumberOutOfRangeException : System.Exception
    {
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("Pokedex.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());

        private int minPokedexNumber { get; }
        private int maxPokedexNumber { get; }
        public DexNumberOutOfRangeException(int minPokedexNumber, int maxPokedexNumber) :
            base(string.Format(ResourceManager.GetString("DexNumberOutOfRange") ?? string.Empty, minPokedexNumber, maxPokedexNumber))
        {
            this.minPokedexNumber = minPokedexNumber;
            this.maxPokedexNumber = maxPokedexNumber;
        }
    }
}