using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Globalization;

namespace PeriodicTable
{
    //class contains list of chemical substances taken from file
    public static class Explosives
    {
        //list of explosives
        public static List<ChemicalSubstance> ChemicalSubstances;

        //path to file
        private static string FileName;

        //container of methods for work with files
        private static InputTable inputTable;

        //constructor reads file and writes data into ChemicalSubstances
        static Explosives()
        {
            //all information about explosives we get form Table            
            FileName = "Table";
            //get current culture
            CultureInfo curCult = System.Threading.Thread.CurrentThread.CurrentUICulture;

            //create both russian and english files at once
            inputTable = new InputTable(FileName);
            inputTable.CreateTable("ru-RU");
            inputTable.CreateTable("en-US");

            //create list of chemical substances
            ChemicalSubstances = new List<ChemicalSubstance>();
            CreateList(curCult);
        }

        //recreate list of chemical substances after changing culture
        public static void CreateList(CultureInfo curCult)
        {
            //clear list first
            ChemicalSubstances.Clear();
            //russian language or default english one
            var bufName = (curCult.Name == "ru-RU") ? curCult.Name : "en-US";
            var fileName = FileName + "." + bufName + ".txt";
            //buffer for text file
            var inputStrings = new List<string>();

            //read substances from file into strings
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
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

        //get explosive by name
        public static bool TryGetValue(string name, out ChemicalSubstance value)
        {
            if (ChemicalSubstances.Count(c => c.Name == name) > 0)
            {
                value = ChemicalSubstances.Where(c => c.Name == name).ElementAt(0);
                return true;
            }
            else
                throw new Exception(Localization.GetString("NoSubstance") + name);
        }

        //restore file of explosives to default
        public static void RestoreTable(CultureInfo curCult)
        {
            //delete old file (maybe it would be better to rewrite)
            var bufName = (curCult.Name == "ru-RU") ? curCult.Name : "en-US";
            var fileName = FileName + "." + bufName + ".txt";
            File.Delete(fileName);
            //create new one
            inputTable.CreateTable(bufName);
            //update list
            CreateList(curCult);
        }

        //remove element from file
        public static void RemoveElement(CultureInfo curCult, string elementName)
        {
            var bufName = (curCult.Name == "ru-RU") ? curCult.Name : "en-US";
            var path = FileName + "." + bufName + ".txt";
            //rewrite all file, but without string that contains elementName
            var remove = File.ReadAllLines(path, Encoding.Default).Where(s => !s.Contains(elementName));
            File.WriteAllLines(path, remove, Encoding.Default);
            //recreate list of explosives
            CreateList(curCult);
        }

        //add element that has (name, balance) structure to file 
        public static void AddElementBalance(CultureInfo curCult, string elementName, double balance)
        {
            var bufName = (curCult.Name == "ru-RU") ? curCult.Name : "en-US";
            var path = FileName + "." + bufName + ".txt";
            using (StreamWriter sr = new StreamWriter(path, true, Encoding.Default))
            {
                sr.WriteLine(elementName + "\t" + balance.ToString(curCult));
            }
            ChemicalSubstances.Add(new ChemicalSubstance(elementName, balance));
        }

        //add element that has (name, formula) structure to file        
        public static void AddElementFormula(CultureInfo curCult, string elementName, string formula)
        {
            //we assume that everything else is correct
            var bufName = (curCult.Name == "ru-RU") ? curCult.Name : "en-US";
            var path = FileName + "." + bufName + ".txt";
            using (StreamWriter sr = new StreamWriter(path, true, Encoding.Default))
            {
                sr.WriteLine(elementName + "\t" + formula);
            }
            ChemicalSubstances.Add(new ChemicalSubstance(elementName, formula));
        }

        //calculation of part of 3 components
        public static void GetResult(double b1, double b2,double b3, double d, out double x, out double y, out double z)
        {
            //third component dose
            z = d;
            //first component dose
            x = ((100F - d) * b2 + d * b3) / (b2 - b1);
            //second component dose
            y = (100F - d - x);            
        }
    }
}
