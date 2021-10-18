namespace Pokedex.Abstractions.Exception
{
    public class WrongTypeException : System.Exception
    {
        public WrongTypeException(string message) : base(message)
        {
        }
    }
}