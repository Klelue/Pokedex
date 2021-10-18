namespace Pokedex.Abstractions.Exception
{
    public class InvalidCsvDataException : System.Exception
    {
        public InvalidCsvDataException(string message)
            : base(message)
        {
        }
    }
}
