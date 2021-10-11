namespace Pokedex.Exception
{
    public class InvalidCsvDataException : System.Exception
    {
        public InvalidCsvDataException(string message)
            : base(message)
        {
        }
    }
}
