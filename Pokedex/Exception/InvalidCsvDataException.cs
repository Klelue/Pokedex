namespace Pokedex
{
    using System;

    public class InvalidCsvDataException : Exception
    {
        public InvalidCsvDataException(string message)
            : base(message)
        {
        }
    }
}
