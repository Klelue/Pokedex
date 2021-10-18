using System.Reflection;
using System.Resources;

namespace Pokedex.Abstractions.Exception
{
    public class WrongValuesException : System.Exception
    {
        private static readonly ResourceManager ResourceManager =
            new ResourceManager("Pokedex.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());


        public WrongValuesException() : base( ResourceManager.GetString("WrongValues"))
        {
        }
    }
}
