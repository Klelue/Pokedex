using System.Reflection;
using System.Resources;

namespace Pokedex.Abstractions.Exception
{
    public class NoBoolException : System.Exception
    {
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("Pokedex.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());
        public NoBoolException() : base(ResourceManager.GetString("NoBool"))
        {
        }
    }
}