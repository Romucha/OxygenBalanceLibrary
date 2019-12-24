using System;
using System.Collections.Generic;
using System.Text;

namespace PeriodicTable
{
    //class contains information about a single chemical substance
    class ChemicalSubstance : OxygenBalance
    {
        //name of chemical substance
        public string Name { get; private set; }

        //oxygen balance of chemical substance
        public double Balance { get; private set; }

        //this constructor is used when we know formula of substance
        public ChemicalSubstance(string name, string formula) : base(formula)
        {
            Name = name;
            Balance = GetOxygenBalance();
        }

        //this constructor is used when formula isn't given
        public ChemicalSubstance(string name, double balance) : base("")
        {
            Name = name;
            Balance = balance;
        }

        public override string ToString()
        {
            if (Weight != 0.0)
                return Name + "\n" + base.ToString() + "\n";
            else
                return Name + "\nOxygenBalance = " + $"{Balance * 100.0:f4}" + " %\n";
        }
    }
}
