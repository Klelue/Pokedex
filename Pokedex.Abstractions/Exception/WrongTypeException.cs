using System.Reflection;
using System.Resources;

namespace Pokedex.Abstractions.Exception
{
    public class WrongTypeException : System.Exception
    {
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("Pokedex.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());

        private string typeName { get; }
        public WrongTypeException(string typeName) : base(string.Format(ResourceManager.GetString("WrongType") ?? string.Empty, typeName))
        {
            this.typeName = typeName;
        }
    }
}