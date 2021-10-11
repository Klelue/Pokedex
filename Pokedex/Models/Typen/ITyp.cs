using System.Collections.Generic;

namespace Pokedex.Models.Typen
{
    public interface ITyp
    {
        public string name { get;}

        public IEnumerable<ITyp> superEffectiveAgainstTyps { get;}

        public IEnumerable<ITyp> notVeryEffectiveAgainstTyps { get;}

        public IEnumerable<ITyp> noEffectTyps { get;}


    }
}