
namespace Pokedex.Abstractions.Exception
{
    public class TotalOutOfRangeException : System.Exception
    {
        public TotalOutOfRangeException(string message) : base(message)
        {
        }
    }
}