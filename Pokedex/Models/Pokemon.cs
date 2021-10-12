using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class Pokemon
    {
        [Key] public int nationalDexNumber { get; set; }

        [Key] public string name { get; set; }

        public Typ type1 { get; set; }

        public Typ type2 { get; set; }

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