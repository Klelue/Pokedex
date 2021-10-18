using System.Dynamic;
using System.Reflection;
using System.Resources;

namespace Pokedex.Abstractions.Exception
{
    public class NonUniquePokemonException : System.Exception
    {
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("Pokedex.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());

        private string notUniquePokemonNationalDexNumbersAsString { get; }
        public NonUniquePokemonException(string notUniquePokemonNationalDexNumbersAsString):
            base(string.Format(ResourceManager.GetString("NoUniquePokemon") ?? string.Empty, notUniquePokemonNationalDexNumbersAsString))
        {
            this.notUniquePokemonNationalDexNumbersAsString = notUniquePokemonNationalDexNumbersAsString;
        }
    }
}