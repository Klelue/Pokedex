using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Pokedex.Abstractions.Exception
{
    public class NoIntException : System.Exception
    {
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("Pokedex.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());

        private string whatToParse { get; }
        private string value { get; }
        public NoIntException(string value, string whatToParse) : base(string.Format(ResourceManager.GetString("NoInt") ?? string.Empty, value, whatToParse))
        {
            this.value = value;
            this.whatToParse = whatToParse;
        }
    }
}