namespace Pokedex.Exception
{
    public class PokemonNotFoundException : System.Exception
    {
        public PokemonNotFoundException(string message) : base(message)
        {
        }
    }
}