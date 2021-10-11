namespace Pokedex.Exception
{
    public class NonUniquePokemonException : System.Exception
    {
        public NonUniquePokemonException(string message): base(message)
        {
        }
    }
}