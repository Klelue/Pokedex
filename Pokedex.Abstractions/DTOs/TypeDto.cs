using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedex.Abstractions.DTOs
{
    public class TypeDto
    {
        public TypeDto(string typeName)
        {
            this.typeName = typeName;
        }

        public string typeName { get; set; }

        [NotMapped]
        public List<TypeDto> superEffectiveAgainstTyps { get; set; }

        [NotMapped]
        public List<TypeDto> notVeryEffectiveAgainstTyps { get; set; }

        [NotMapped]
        public List<TypeDto> noEffectTyps { get; set; }
    }
}
