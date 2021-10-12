namespace Pokedex.Exception
{
    public class PokemonNotImportedException : System.Exception
    {
        public PokemonNotImportedException(string message) : base(message)
        {
        }
    }
}