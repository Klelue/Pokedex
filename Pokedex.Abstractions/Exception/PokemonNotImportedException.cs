namespace Pokedex.Abstractions.Exception
{
    public class PokemonNotImportedException : System.Exception
    {
        public PokemonNotImportedException(string message) : base(message)
        {
        }
    }
}