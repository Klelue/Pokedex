
using System.Reflection;
using System.Resources;

namespace Pokedex.Abstractions.Exception
{
    public class TotalOutOfRangeException : System.Exception
    {
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("Pokedex.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());

        private int total { get; }
        public TotalOutOfRangeException(int total) : base( string.Format(ResourceManager.GetString("TotalOutOfRange") ?? string.Empty, total))
        {
            this.total = total;
        }
    }
}