using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

//main goal is to calculate oxygen balance of given molecula
/*
 * Alogorythm is:
    1. We read molecula from console input
    2. Create new Molecula object where we calculate quantity of each atom in the molecula
    3. Calculate its oxygen balance
*/

namespace PeriodicTable
{
    //class contains all necessary information to claculate oxygen balance of molecula
    public class OxygenBalance
    {
        //struct stores all necessary information and methods to calculate oxygen balance
        //storage of quantity of each atom in molecula
        private protected Dictionary<string, int> Atoms;

        //stroge of initial input
        private protected string Input;

        //Weight of molecula
        private protected double Weight;

        //constructor
        public OxygenBalance(string s)
        {
            //we don't need this if substance has no formula
            if (s == null)
            {
                Atoms = null;
                Input = null;
                Weight = 0.0;
            }
            else
            {
                Input = s;
                Atoms = new Dictionary<string, int>();
                Weight = 0.0;
                //formating input to use regex stuff later
                for (var i = 1; i < s.Length; i++)
                {
                    //check cases like H2, C25 etc.
                    if (char.IsDigit(s[i]))
                    {
                        //check if it's like C25
                        if (char.IsDigit(s[i - 1]) || (i < s.Length - 1 && char.IsDigit(s[i + 1])))
                        {
                            //do nothing
                            continue;
                        }
                        //check if it's like H2
                        else
                        {
                            //turn it into H02
                            s = s.Insert(i, "0");
                        }
                    }
                    else if (!char.IsLower(s[i]))
                    {
                        //check cases like CO, NaS etc.
                        if (char.IsLetter(s[i - 1]) || s[i - 1] == ')')
                        {
                            //turn it into C01O, Na01S
                            s = s.Insert(i, "01");
                        }
                    }
                }
                //since final element of string is untouched by cicle we have to make final check
                //and if it's anything but digit we add 01 to the string
                if (s.Length != 0 && !char.IsDigit(s.Last()))
                {
                    s += "01";
                }
                //removing brackets and multiplying everything inside them
                if (s.Contains('('))
                {
                    var j = 0;
                    //there can be a lot of couples of brackets
                    //we go through whole string by moving pointer j
                    while (j < s.Length)
                    {
                        var openingBracketIndex = s.IndexOf('(', j);
                        if (openingBracketIndex < 0)
                            break;
                        var closingBracketIndex = s.IndexOf(')', j);
                        var multiplier = int.Parse(s.Substring(closingBracketIndex + 1, 2));
                        for (var i = openingBracketIndex; i < closingBracketIndex; i++)
                        {
                            //we take number after bracket and multiply everything inside bracket
                            if (char.IsDigit(s[i]) && char.IsDigit(s[i + 1]))
                            {
                                var multipliedNumber = int.Parse(s.Substring(i, 2)) * multiplier;
                                var sMultipliedNumber = string.Format("{0:d2}", multipliedNumber);
                                s = s.Remove(i, 2);
                                s = s.Insert(i, sMultipliedNumber);
                            }
                        }
                        //remove brackets
                        s = s.Remove(openingBracketIndex, 1);
                        s = s.Remove(closingBracketIndex - 1, 3);
                        j += openingBracketIndex + 1;
                    }
                }
                CalculateMolecula(s);
                foreach (var a in Atoms)
                    Weight += Table.Weight(a.Key) * a.Value;
            }
        }

        //method reads molecula using RegEx and puts necessary values into dictionary Atoms
        private void CalculateMolecula(string s)
        {
            //for example, Na20 or C2
            var PatternXx00 = @"([A-Z][a-z]?\d{2})";
            for (int i = 0; i < s.Length;)
            {
                //we take substring
                var subString = s.Substring(i, (s.Length - i < 4) ? s.Length - i : 4);

                var l = subString.Length;

                //and check if it matches pattern
                if (Regex.IsMatch(subString, PatternXx00))
                {
                    //it happens that we can take extra letter from initial string
                    if (char.IsLetter(subString.Last()))
                    {
                        //so we remove last letter
                        subString = subString.Remove(l - 1);
                        i += 3;
                    }
                    else
                    {
                        i += 4;
                    }
                    //read atom and its quantity in molecula and fill dicitonary
                    var sNumber = int.Parse(subString.Substring(subString.Length - 2));
                    var sAtom = subString.Remove(subString.Length - 2);
                    var buf = 0;
                    //if we see the atom for the first time we add it to dictionary
                    if (!Atoms.TryGetValue(sAtom, out buf))
                    {
                        Atoms.Add(sAtom, 0);
                    }
                    Atoms[sAtom] += sNumber;
                }
                //if subtring doesn't match regular expression we throw new excpetion
                else
                    throw new Exception();
            }
        }

        //Consider every combustible element
        public double GetOxygenBalance()
        {
            //after some purely scientific research formula transforms into:
            //(- sum(E * V)) * 1600 / M
            //where
            //E is quantity of atoms
            //V is their valence
            //M is Weight of molecula           

            var S = 0.0;
            foreach (var m in Atoms)
            {
                //Console.WriteLine(m.Key + " " + m.Value + " " + Table.Valence(m.Key));
                S += m.Value * Table.Valence(m.Key);
            }
            //simply calculate oxygen balance according to formula
            return (-S) * 1600.0 / Weight;
        }

        //print formula, name and quantity of each atom, weight and oxygen balance
        public override string ToString()
        {
            var output = "";

            output += Input + "\n";
            output += "Atoms:\n";
            foreach (var a in Atoms)
            {
                output += a.Key + " " + a.Value + " " + Table.Weight(a.Key) + "\n";
            }

            output += "Weight = " + $"{Weight:f4}" + "\n";
            output += "Oxygen Balance = " + $"{GetOxygenBalance():f4}" + " %";

            return output;
        }
    }
}
