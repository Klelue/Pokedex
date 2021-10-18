namespace Pokedex.Abstractions.Exception
{
    public class DexNumberOutOfRangeException : System.Exception
    {
        public DexNumberOutOfRangeException(string message) : base(message)
        {
        }
    }
}