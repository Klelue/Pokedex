namespace Pokedex.Exception
{
    public class WrongTypException : System.Exception
    {
        public WrongTypException(string message) : base(message)
        {
        }
    }
}