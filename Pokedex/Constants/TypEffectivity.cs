using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using Pokedex.Exception;

namespace Pokedex.Constants
{
    public class TypEffectivity
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

        private static readonly string[] TypNames =
        {
            "Normal", "Fire", "Water", "Grass", "Electric", "Ice", "Fighting", "Poison", "Ground",
            "Flying", "Psychic", "Bug", "Rock", "Ghost", "Dragon", "Dark", "Steel", "Fairy"
        };

        
        private int GetTypIndex(string typName)
        {
            for (int i = 0; i < TypNames.Length; i++)
            {
                if (TypNames[i].Equals(typName))
                {
                    return i;
                }
            }

            string message = string.Format(ResourceManager.GetString("WrongTyp") ?? String.Empty, typName);
            throw new WrongTypException(message);
        }

        private List<string> GetEffectivityList(int typIndex, char kindOfEffectivty)
        {
            List<string> effectivityTyps = new List<string>();

            for (int i = 0; i < EffictivityOfTyps[typIndex].Length; i++)
            {
                char currentEffectivity = EffictivityOfTyps[typIndex][i];

                if (currentEffectivity.Equals(kindOfEffectivty))
                {
                    effectivityTyps.Add(TypNames[i]);
                }
            }

            return effectivityTyps;
        }

        public List<string> GetListOfVeryEffectivityForTypName(string typName)
        {
            int typIndex = GetTypIndex(typName);
            List<string> veryEffectivTyps = GetEffectivityList(typIndex, VeryEffectivity);

            return veryEffectivTyps;
        }

        public List<string> GetListOfLessEffectivityForTypName(string typName)
        {
            int typIndex = GetTypIndex(typName);
            List<string> lessEffectivTyps = GetEffectivityList(typIndex, LessEffectivity);

            return lessEffectivTyps;
        }

        public List<string> GetListOfNoEffectivityForTypName(string typName)
        {
            int typIndex = GetTypIndex(typName);
            List<string> noEffectivTyps = GetEffectivityList(typIndex, NoEffectivity);

            return noEffectivTyps;
        }
    }
    
}