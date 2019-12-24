using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace PeriodicTable
{
    //class contains list of chemical substances taken from file
    public static class Explosives
    {
        //list of explosives
        static List<ChemicalSubstance> ChemicalSubstances { get; set; }

        //constructor reads file and writes data into ChemicalSubstances
        static Explosives()
        {
            //all information about explosives we get form Table.txt
            var fileName = "Table.txt";

            InputTable inputTable = new InputTable(fileName);

            ChemicalSubstances = new List<ChemicalSubstance>();
            //buffer for text file
            var inputStrings = new List<string>();

            //read substances from file into strings
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    inputStrings.Add(sr.ReadLine());
                }
                
            }
            inputStrings.Remove(inputStrings.Last());
            //read data from string array and put it into 
            foreach (var i in inputStrings)
            {
                //buffer string array made of split line of text file
                var bufS = new string[2];
                bufS = i.Split('\t');
                //buffer for checking if explosive has chemical formula
                var bufBalance = 0.0;
                //depending on given data
                //we either add an explsoive with name and balance
                //or one with name and formula and calculate oxygen balance within constructor
                if (double.TryParse(bufS[1], out bufBalance))
                {
                    ChemicalSubstances.Add(new ChemicalSubstance(bufS[0], bufBalance));
                }
                else
                {
                    ChemicalSubstances.Add(new ChemicalSubstance(bufS[0], bufS[1]));
                }
            }
        }

        //get output for each element in ChemicalSubstances list
        public static void ViewTable()
        {
            ChemicalSubstances.ForEach(Console.WriteLine);            
        }
    }
}
