namespace Pokedex.Abstractions.Exception
{
    public class NonUniquePokemonException : System.Exception
    {
        public NonUniquePokemonException(string message): base(message)
        {
        }
    }
}