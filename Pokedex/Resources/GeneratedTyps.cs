using Pokedex.Models;
using System.Collections.Generic;

namespace Pokedex.Resources
{
    public class GeneratedTyps
    {
        private List<Typ> typs;

        public GeneratedTyps()
        {
            GenerateTyps();
        }

        public List<Typ> GetTyps()
        {
            return typs;
        }

        private void GenerateTyps()
        {
            var normalTyp = new Typ("Normal");
            var fireTyp = new Typ("Fire");
            var waterTyp = new Typ("Water");
            var grassTyp = new Typ("Grass");
            var electricTyp = new Typ("Electric");
            var iceTyp = new Typ("Ice");
            var fightingTyp = new Typ("Fighting");
            var poisonTyp = new Typ("Poison");
            var groundTyp = new Typ("Ground");
            var flyingTyp = new Typ("Flying");
            var psychictyp = new Typ("Psychic");
            var bugTyp = new Typ("Bug");
            var rockTyp = new Typ("Rock");
            var ghostTyp = new Typ("Ghost");
            var darkTyp = new Typ("Dark");
            var dragonTyp = new Typ("Dragon");
            var steelTyp = new Typ("Steel");
            var fairyTyp = new Typ("Fairy");

            normalTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                rockTyp, steelTyp
            };

            normalTyp.noEffectTyps = new List<Typ>()
            {
                ghostTyp
            };

            fireTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                fireTyp, waterTyp, rockTyp, dragonTyp
            };

            fairyTyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                grassTyp, iceTyp, bugTyp, steelTyp
            };

            waterTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                waterTyp, grassTyp, dragonTyp
            };

            waterTyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                fireTyp, groundTyp, rockTyp
            };

            grassTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                fireTyp, grassTyp, poisonTyp, flyingTyp, bugTyp, dragonTyp, steelTyp
            };

            grassTyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                groundTyp, rockTyp, waterTyp
            };

            electricTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                grassTyp, electricTyp, dragonTyp
            };

            electricTyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                waterTyp, flyingTyp
            };

            electricTyp.noEffectTyps = new List<Typ>()
            {
                groundTyp
            };

            iceTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                fireTyp, waterTyp, iceTyp, steelTyp
            };

            iceTyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                grassTyp, groundTyp, flyingTyp, dragonTyp
            };

            fightingTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                poisonTyp, flyingTyp,  psychictyp, bugTyp, fairyTyp
            };

            fightingTyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                normalTyp, iceTyp, rockTyp, darkTyp, steelTyp
            };

            fightingTyp.noEffectTyps = new List<Typ>()
            {
                ghostTyp
            };

            poisonTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                poisonTyp, groundTyp, rockTyp, ghostTyp
            };

            poisonTyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                grassTyp, fairyTyp
            };

            poisonTyp.noEffectTyps = new List<Typ>()
            {
                steelTyp
            };

            groundTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                grassTyp, bugTyp
            };

            groundTyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                fireTyp, electricTyp, poisonTyp, rockTyp, steelTyp
            };

            groundTyp.noEffectTyps = new List<Typ>()
            {
                flyingTyp
            };

            flyingTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                electricTyp, rockTyp, steelTyp
            };

            flyingTyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                grassTyp, fightingTyp, bugTyp
            };

            psychictyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                psychictyp, steelTyp
            };

            psychictyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                fightingTyp, poisonTyp
            };

            psychictyp.noEffectTyps = new List<Typ>()
            {
                darkTyp
            };

            bugTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                fireTyp, bugTyp, poisonTyp, flyingTyp, ghostTyp, steelTyp, fairyTyp
            };

            bugTyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                grassTyp,  psychictyp, darkTyp
            };

            rockTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                fightingTyp, groundTyp, steelTyp
            };

            rockTyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                fireTyp, iceTyp, flyingTyp, bugTyp
            };

            ghostTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                darkTyp, steelTyp
            };

            ghostTyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                psychictyp, ghostTyp
            };

            ghostTyp.noEffectTyps = new List<Typ>()
            {
                normalTyp
            };

            dragonTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                steelTyp
            };

            dragonTyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                dragonTyp
            };

            dragonTyp.noEffectTyps = new List<Typ>()
            {
                fairyTyp
            };

            darkTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                fightingTyp, darkTyp, steelTyp, fairyTyp
            };

            darkTyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                psychictyp, ghostTyp
            };

            steelTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                waterTyp, grassTyp, steelTyp
            };

            steelTyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                iceTyp, rockTyp, fairyTyp
            };

            fairyTyp.notVeryEffectiveAgainstTyps = new List<Typ>()
            {
                fireTyp, poisonTyp, steelTyp
            };

            flyingTyp.superEffectiveAgainstTyps = new List<Typ>()
            {
                fightingTyp, dragonTyp, darkTyp
            };

            typs = new List<Typ>()
            {
                normalTyp, fireTyp, waterTyp, grassTyp, electricTyp, iceTyp, fightingTyp, poisonTyp, groundTyp,
                flyingTyp, psychictyp, bugTyp, rockTyp, ghostTyp, dragonTyp, darkTyp, steelTyp, fairyTyp
            };
        }
    }
}