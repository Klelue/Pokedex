namespace Pokedex.Abstractions.DTOs
{
    public class PokemonDto
    {
        public int nationalDexNumber { get; set; }

        public string name { get; set; }

        public TypeDto type1 { get; set; }

        public TypeDto type2 { get; set; }

        public int total { get; set; }

        public int healthPoints { get; set; }

        public int attack { get; set; }

        public int defense { get; set; }

        public int spAttack { get; set; }

        public int spDefense { get; set; }

        public int speed { get; set; }

        public int generation { get; set; }

        public bool legendary { get; set; }
    }
}