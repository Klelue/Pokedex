using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedex.Database.Abstractions.Entities
{
    public class Type
    {
        public Type(string typeName)
        {
            this.typeName = typeName;
        }

        [Key]
        public string typeName { get; set; }

        [NotMapped]
        public List<Type> superEffectiveAgainstTyps { get; set; }

        [NotMapped]
        public List<Type> notVeryEffectiveAgainstTyps { get; set; }

        [NotMapped]
        public List<Type> noEffectTyps { get; set; }
    }
}
