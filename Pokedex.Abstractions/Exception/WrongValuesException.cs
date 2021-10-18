namespace Pokedex.Abstractions.Exception
{
    public class WrongValuesException : System.Exception
    {
        public WrongValuesException(string message) : base(message)
        {
        }
    }
}
