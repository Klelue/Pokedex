using System.Collections.Generic;
using Pokedex.Database.Abstractions.Entities;

namespace Pokedex.Database.Abstractions.Resources
{
    public class GeneratedTyps
    {
        private List<Type> typs;

        public GeneratedTyps()
        {
            GenerateTyps();
        }

        public List<Type> GetTyps()
        {
            return typs;
        }

        private void GenerateTyps()
        {
            var normalTyp = new Type("Normal");
            var fireTyp = new Type("Fire");
            var waterTyp = new Type("Water");
            var grassTyp = new Type("Grass");
            var electricTyp = new Type("Electric");
            var iceTyp = new Type("Ice");
            var fightingTyp = new Type("Fighting");
            var poisonTyp = new Type("Poison");
            var groundTyp = new Type("Ground");
            var flyingTyp = new Type("Flying");
            var psychictyp = new Type("Psychic");
            var bugTyp = new Type("Bug");
            var rockTyp = new Type("Rock");
            var ghostTyp = new Type("Ghost");
            var darkTyp = new Type("Dark");
            var dragonTyp = new Type("Dragon");
            var steelTyp = new Type("Steel");
            var fairyTyp = new Type("Fairy");

            normalTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                rockTyp, steelTyp
            };

            normalTyp.noEffectTyps = new List<Type>()
            {
                ghostTyp
            };

            fireTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                fireTyp, waterTyp, rockTyp, dragonTyp
            };

            fairyTyp.superEffectiveAgainstTyps = new List<Type>()
            {
                grassTyp, iceTyp, bugTyp, steelTyp
            };

            waterTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                waterTyp, grassTyp, dragonTyp
            };

            waterTyp.superEffectiveAgainstTyps = new List<Type>()
            {
                fireTyp, groundTyp, rockTyp
            };

            grassTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                fireTyp, grassTyp, poisonTyp, flyingTyp, bugTyp, dragonTyp, steelTyp
            };

            grassTyp.superEffectiveAgainstTyps = new List<Type>()
            {
                groundTyp, rockTyp, waterTyp
            };

            electricTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                grassTyp, electricTyp, dragonTyp
            };

            electricTyp.superEffectiveAgainstTyps = new List<Type>()
            {
                waterTyp, flyingTyp
            };

            electricTyp.noEffectTyps = new List<Type>()
            {
                groundTyp
            };

            iceTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                fireTyp, waterTyp, iceTyp, steelTyp
            };

            iceTyp.superEffectiveAgainstTyps = new List<Type>()
            {
                grassTyp, groundTyp, flyingTyp, dragonTyp
            };

            fightingTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                poisonTyp, flyingTyp,  psychictyp, bugTyp, fairyTyp
            };

            fightingTyp.superEffectiveAgainstTyps = new List<Type>()
            {
                normalTyp, iceTyp, rockTyp, darkTyp, steelTyp
            };

            fightingTyp.noEffectTyps = new List<Type>()
            {
                ghostTyp
            };

            poisonTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                poisonTyp, groundTyp, rockTyp, ghostTyp
            };

            poisonTyp.superEffectiveAgainstTyps = new List<Type>()
            {
                grassTyp, fairyTyp
            };

            poisonTyp.noEffectTyps = new List<Type>()
            {
                steelTyp
            };

            groundTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                grassTyp, bugTyp
            };

            groundTyp.superEffectiveAgainstTyps = new List<Type>()
            {
                fireTyp, electricTyp, poisonTyp, rockTyp, steelTyp
            };

            groundTyp.noEffectTyps = new List<Type>()
            {
                flyingTyp
            };

            flyingTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                electricTyp, rockTyp, steelTyp
            };

            flyingTyp.superEffectiveAgainstTyps = new List<Type>()
            {
                grassTyp, fightingTyp, bugTyp
            };

            psychictyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                psychictyp, steelTyp
            };

            psychictyp.superEffectiveAgainstTyps = new List<Type>()
            {
                fightingTyp, poisonTyp
            };

            psychictyp.noEffectTyps = new List<Type>()
            {
                darkTyp
            };

            bugTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                fireTyp, bugTyp, poisonTyp, flyingTyp, ghostTyp, steelTyp, fairyTyp
            };

            bugTyp.superEffectiveAgainstTyps = new List<Type>()
            {
                grassTyp,  psychictyp, darkTyp
            };

            rockTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                fightingTyp, groundTyp, steelTyp
            };

            rockTyp.superEffectiveAgainstTyps = new List<Type>()
            {
                fireTyp, iceTyp, flyingTyp, bugTyp
            };

            ghostTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                darkTyp, steelTyp
            };

            ghostTyp.superEffectiveAgainstTyps = new List<Type>()
            {
                psychictyp, ghostTyp
            };

            ghostTyp.noEffectTyps = new List<Type>()
            {
                normalTyp
            };

            dragonTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                steelTyp
            };

            dragonTyp.superEffectiveAgainstTyps = new List<Type>()
            {
                dragonTyp
            };

            dragonTyp.noEffectTyps = new List<Type>()
            {
                fairyTyp
            };

            darkTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                fightingTyp, darkTyp, steelTyp, fairyTyp
            };

            darkTyp.superEffectiveAgainstTyps = new List<Type>()
            {
                psychictyp, ghostTyp
            };

            steelTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                waterTyp, grassTyp, steelTyp
            };

            steelTyp.superEffectiveAgainstTyps = new List<Type>()
            {
                iceTyp, rockTyp, fairyTyp
            };

            fairyTyp.notVeryEffectiveAgainstTyps = new List<Type>()
            {
                fireTyp, poisonTyp, steelTyp
            };

            flyingTyp.superEffectiveAgainstTyps = new List<Type>()
            {
                fightingTyp, dragonTyp, darkTyp
            };

            typs = new List<Type>()
            {
                normalTyp, fireTyp, waterTyp, grassTyp, electricTyp, iceTyp, fightingTyp, poisonTyp, groundTyp,
                flyingTyp, psychictyp, bugTyp, rockTyp, ghostTyp, dragonTyp, darkTyp, steelTyp, fairyTyp
            };
        }
    }
}