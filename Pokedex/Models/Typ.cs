using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedex.Models
{
    public class Typ
    {
        public Typ(string typName)
        {
            this.typName = typName;
        }

        [Key]
        public string typName { get; set; }

        [NotMapped]
        public List<Typ> superEffectiveAgainstTyps { get; set; }

        [NotMapped]
        public List<Typ> notVeryEffectiveAgainstTyps { get; set; }

        [NotMapped]
        public List<Typ> noEffectTyps { get; set; }
    }
}
