using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PeriodicTable
{
    //localization stuff, similar to resources
    //at first, I was thinking to add resources to library, but it seems unnecessary
    //it's used in both OxygenBalance, ChemicalSubstance and Explosives files
    static class Localization
    {
        //russian
        private static Dictionary<string, string> LocalRus;

        //english
        private static Dictionary<string, string> LocalEng;

        //the one we work with
        private static Dictionary<string, string> Local;

        static Localization()
        {
            LocalRus = new Dictionary<string, string>()
            {
                { "Weight", "Молекулярная масса" },
                { "OxygenBalance", "Кислородный баланс" },
                { "NoSubstance", "Не удалось найти химическое вещество под названием " }
            };

            LocalEng = new Dictionary<string, string>()
            {
                { "Weight", "Weight" },
                { "OxygenBalance", "Oxygen Balance" },
                { "NoSubstance", "There's no such chemical substance named " }
            };

            Local = new Dictionary<string, string>();
        }

        //indexator with culture switch
        public static string GetString(string index)
        {
            //clear working dictionary
            //check culture
            //set new working dictionary                
            if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "ru-RU")
            {
                Local = LocalRus;
            }
            else
            {
                Local = LocalEng;
            }
            //try get value
            if (Local.TryGetValue(index, out string value))
                return value;
            else
                throw new Exception("Can't get element " + index); 
        }
    }
}
