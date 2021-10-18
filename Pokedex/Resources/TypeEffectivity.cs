using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using Pokedex.Exception;

namespace Pokedex.Constants
{
    public class TypeEffectivity
    {

        private static readonly ResourceManager ResourceManager =
            new ResourceManager("Pokedex.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());

        private static readonly char NoramlEffectivity = '.';
        private static readonly char VeryEffectivity = '+';
        private static readonly char NoEffectivity = 'x';
        private static readonly char LessEffectivity = '-';

        private static readonly string[] EffictivityOfTyps =
        {
            "............-x....",
            ".--+.+.....+-.-.+.",
            ".+--....+...+.-...",
            ".-+-...-+-.-+.-.-.",
            "..+--...x+....-...",
            ".--+.-..++....+.-.",
            "+....+.-.---+x.++-",
            ".+.-+..+.x.-+...+.",
            "...+-.+....+-...-.",
            "......++..-....x-.",
            ".-.+..--.-+..-.+--",
            ".+...+-.-+.+....-.",
            "x.........+..+.--.",
            "..............+.-x",
            "......-...+..+.---",
            ".--..+......+...-+",
            ".-....+-......++-."
        };

        private static readonly string[] TypeNames =
        {
            "Normal", "Fire", "Water", "Grass", "Electric", "Ice", "Fighting", "Poison", "Ground",
            "Flying", "Psychic", "Bug", "Rock", "Ghost", "Dragon", "Dark", "Steel", "Fairy"
        };

        
        private int GetTypIndex(string typName)
        {
            for (int i = 0; i < TypeNames.Length; i++)
            {
                if (TypeNames[i].Equals(typName))
                {
                    return i;
                }
            }

            string message = string.Format(ResourceManager.GetString("WrongType") ?? String.Empty, typName);
            throw new WrongTypeException(message);
        }

        private List<string> GetEffectivityList(int typeIndex, char kindOfEffectivty)
        {
            List<string> effectivityTyps = new List<string>();

            for (int i = 0; i < EffictivityOfTyps[typeIndex].Length; i++)
            {
                char currentEffectivity = EffictivityOfTyps[typeIndex][i];

                if (currentEffectivity.Equals(kindOfEffectivty))
                {
                    effectivityTyps.Add(TypeNames[i]);
                }
            }

            return effectivityTyps;
        }

        public List<string> GetListOfVeryEffectivityForTyepName(string typeName)
        {
            int typeIndex = GetTypIndex(typeName);
            List<string> veryEffectivTyps = GetEffectivityList(typeIndex, VeryEffectivity);

            return veryEffectivTyps;
        }

        public List<string> GetListOfLessEffectivityForTypeName(string typeName)
        {
            int typeIndex = GetTypIndex(typeName);
            List<string> lessEffectivTyps = GetEffectivityList(typeIndex, LessEffectivity);

            return lessEffectivTyps;
        }

        public List<string> GetListOfNoEffectivityForTypeName(string typeName)
        {
            int typeIndex = GetTypIndex(typeName);
            List<string> noEffectivTyps = GetEffectivityList(typeIndex, NoEffectivity);

            return noEffectivTyps;
        }
    }
    
}