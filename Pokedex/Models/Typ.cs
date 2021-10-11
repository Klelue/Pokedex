using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class Typ
    {
        public Typ(string name)
        {
            this.name = name;
        }

        [Key]
        public string name { get; set; }

        public List<Typ> superEffectiveAgainstTyps { get; set; }

        public List<Typ> notVeryEffectiveAgainstTyps { get; set; }

        public List<Typ> noEffectTyps { get; set; }
    }
}
