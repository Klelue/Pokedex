using System.Collections.Generic;

namespace Pokedex.Models.Typen
{
    public class FireTyp : ITyp
    {
        public FireTyp()
        {
            name = "firetyp";
            superEffectiveAgainstTyps = new List<ITyp>()
            {
               // grassTyp, iceTyp, bugTyp, steelTyp
            };
            notVeryEffectiveAgainstTyps = new List<ITyp>()
            {
                new FireTyp() //, waterTyp, rockTyp, dragonTyp
            };

        }
        public string name { get; }
        public IEnumerable<ITyp> superEffectiveAgainstTyps { get; }
        public IEnumerable<ITyp> notVeryEffectiveAgainstTyps { get; }
        public IEnumerable<ITyp> noEffectTyps { get; }
    }
}