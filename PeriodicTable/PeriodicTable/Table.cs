using System;
using System.Linq;
using System.Collections.Generic;

namespace PeriodicTable
{
    //struct stores all necessary information about an atom
    internal struct Atom
    {
        //Number of element
        public int Id { get; private set; }

        //name of atom according to table
        public string Name { get; private set; }

        //its Weight
        public double Weight { get; private set; }

        //how much of oxygen per atom is required to create an oxyd, sort of
        //0 means element isn't combustable
        //negative values mean that element is oxidizer
        public double Valence { get; private set; }

        public Atom(int id, string name, double weight, double valence)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Valence = valence;
        }
    }

    //simple class that recreates periodic table of chemical elements
    public static class Table
    {
        //list stores all elements from the table
        private static readonly List<Atom> PeriodicTable;

        //constructor creates full table of elements
        static Table()
        {
            PeriodicTable = new List<Atom>();
            PeriodicTable.Add(new Atom(1, "H", 1.00794, 0.5));
            PeriodicTable.Add(new Atom(2, "He", 4.002602, 0));
            PeriodicTable.Add(new Atom(3, "Li", 6.941, 0.5));
            PeriodicTable.Add(new Atom(4, "Be", 9.012182, 1.0));
            PeriodicTable.Add(new Atom(5, "B", 10.811, 1.5));
            PeriodicTable.Add(new Atom(6, "C", 12.0107, 2.0));
            PeriodicTable.Add(new Atom(7, "N", 14.0067, 0));
            PeriodicTable.Add(new Atom(8, "O", 15.9994, -1.0));
            PeriodicTable.Add(new Atom(9, "F", 18.9984032, -0.5));
            PeriodicTable.Add(new Atom(10, "Ne", 20.1797, 0));
            PeriodicTable.Add(new Atom(11, "Na", 22.98976928, 0.5));
            PeriodicTable.Add(new Atom(12, "Mg", 24.3050, 1.0));
            PeriodicTable.Add(new Atom(13, "Al", 26.9815386, 1.5));
            PeriodicTable.Add(new Atom(14, "Si", 28.0855, 2.0));
            PeriodicTable.Add(new Atom(15, "P", 30.973762, 0));
            PeriodicTable.Add(new Atom(16, "S", 32.065, 2.0));
            PeriodicTable.Add(new Atom(17, "Cl", 35.453, -0.5));
            PeriodicTable.Add(new Atom(18, "Ar", 39.948, 0));
            PeriodicTable.Add(new Atom(19, "K", 39.0983, 0.5));
            PeriodicTable.Add(new Atom(20, "Ca", 40.078, 1.0));
            PeriodicTable.Add(new Atom(21, "Sc", 44.955912, 1.5));
            PeriodicTable.Add(new Atom(22, "Ti", 47.867, 1.5));
            PeriodicTable.Add(new Atom(23, "V", 50.9415, 1.5));
            PeriodicTable.Add(new Atom(24, "Cr", 51.9961, 1.5));
            PeriodicTable.Add(new Atom(25, "Mn",  54.938045, 1.5));
            PeriodicTable.Add(new Atom(26, "Fe", 55.845, 1.5));
            PeriodicTable.Add(new Atom(27, "Co", 58.933195, 0));
            PeriodicTable.Add(new Atom(28, "Ni", 58.6934, 0));
            PeriodicTable.Add(new Atom(29, "Cu", 63.546, 0));
            PeriodicTable.Add(new Atom(30, "Zn", 65.409, 0));
            PeriodicTable.Add(new Atom(31, "Ga", 69.723, 1.5));
            PeriodicTable.Add(new Atom(32, "Ge", 72.64, 1.5));
            PeriodicTable.Add(new Atom(33, "As", 74.92160, 0));
            PeriodicTable.Add(new Atom(34, "Se", 78.96, 2.0));
            PeriodicTable.Add(new Atom(35, "Br", 79.904, -0.5));
            PeriodicTable.Add(new Atom(36, "Kr", 83.798, 0));
            PeriodicTable.Add(new Atom(37, "Rb", 85.4678, 1.5));
            PeriodicTable.Add(new Atom(38, "Sr", 87.62, 1.5));
            PeriodicTable.Add(new Atom(39, "Y", 88.90585, 1.5));
            PeriodicTable.Add(new Atom(40, "Zr", 91.224, 1.5));
            PeriodicTable.Add(new Atom(41, "Nb", 92.90638, 0));
            PeriodicTable.Add(new Atom(42, "Mo", 95.94, 0));
            PeriodicTable.Add(new Atom(43, "Tc", 98.9063, 0));
            PeriodicTable.Add(new Atom(44, "Ru", 101.07, 0));
            PeriodicTable.Add(new Atom(45, "Rh", 102.90550, 0));
            PeriodicTable.Add(new Atom(46, "Pd", 106.42, 0));
            PeriodicTable.Add(new Atom(47, "Ag", 107.8682, 0));
            PeriodicTable.Add(new Atom(48, "Cd", 112.411, 0));
            PeriodicTable.Add(new Atom(49, "In", 114.818, 1.5));
            PeriodicTable.Add(new Atom(50, "Sn", 118.710, 1.5));
            PeriodicTable.Add(new Atom(51, "Sb", 121.760, 1.5));
            PeriodicTable.Add(new Atom(52, "Te", 127.60, 2.0));
            PeriodicTable.Add(new Atom(53, "I", 126.90447, -0.5));
            PeriodicTable.Add(new Atom(54, "Xe", 131.293, 0));
            PeriodicTable.Add(new Atom(55, "Cs", 132.9054519, 0.5));
            PeriodicTable.Add(new Atom(56, "Ba", 137.327, 1.0));
            PeriodicTable.Add(new Atom(57, "La", 138.90547, 1.5));
            PeriodicTable.Add(new Atom(58, "Ce", 140.116, 1.5));
            PeriodicTable.Add(new Atom(59, "Pr", 140.90765, 1.5));
            PeriodicTable.Add(new Atom(60, "Nd", 144.242, 1.5));
            PeriodicTable.Add(new Atom(61, "Pm", 146.9151, 1.5));
            PeriodicTable.Add(new Atom(62, "Sm", 150.36, 1.5));
            PeriodicTable.Add(new Atom(63, "Eu", 151.964, 1.5));
            PeriodicTable.Add(new Atom(64, "Gd", 157.25, 1.5));
            PeriodicTable.Add(new Atom(65, "Tb", 158.92535, 1.5));
            PeriodicTable.Add(new Atom(66, "Dy", 162.500, 1.5));
            PeriodicTable.Add(new Atom(67, "Ho", 164.93032, 1.5));
            PeriodicTable.Add(new Atom(68, "Er", 167.259, 1.5));
            PeriodicTable.Add(new Atom(69, "Tm", 168.93421, 1.5));
            PeriodicTable.Add(new Atom(70, "Yb", 173.04, 1.5));
            PeriodicTable.Add(new Atom(71, "Lu", 174.967, 1.5));
            PeriodicTable.Add(new Atom(72, "Hf", 178.49, 0));
            PeriodicTable.Add(new Atom(73, "Ta", 180.9479, 0));
            PeriodicTable.Add(new Atom(74, "W", 183.84, 0));
            PeriodicTable.Add(new Atom(75, "Re", 186.207, 0));
            PeriodicTable.Add(new Atom(76, "Os", 190.23, 0));
            PeriodicTable.Add(new Atom(77, "Ir", 192.217, 0));
            PeriodicTable.Add(new Atom(78, "Pt", 195.084, 0));
            PeriodicTable.Add(new Atom(79, "Au", 196.966569, 0));
            PeriodicTable.Add(new Atom(80, "Hg", 200.59, 0));
            PeriodicTable.Add(new Atom(81, "Tl", 204.3833, 0));
            PeriodicTable.Add(new Atom(82, "Pb", 207.2, 0));
            PeriodicTable.Add(new Atom(83, "Bi", 208.98040, 1.5));
            PeriodicTable.Add(new Atom(84, "Po", 208.9824, 1.5));
            PeriodicTable.Add(new Atom(85, "At", 209.9871, 0));
            PeriodicTable.Add(new Atom(86, "Rn", 222.0176, 0));
            PeriodicTable.Add(new Atom(87, "Fr", 223.0197, 0.5));
            PeriodicTable.Add(new Atom(88, "Ra", 226.0254, 1.0));
            PeriodicTable.Add(new Atom(89, "Ac", 227.0278, 1.5));
            PeriodicTable.Add(new Atom(90, "Th", 232.03806, 1.5));
            PeriodicTable.Add(new Atom(91, "Pa", 231.03588, 1.5));
            PeriodicTable.Add(new Atom(92, "U", 238.02891, 1.5));
            PeriodicTable.Add(new Atom(93, "Np", 237.0482, 1.5));
            PeriodicTable.Add(new Atom(94, "Pu", 244.0642, 1.5));
            PeriodicTable.Add(new Atom(95, "Am", 243.0614, 1.5));
            PeriodicTable.Add(new Atom(96, "Cm", 247.0703, 1.5));
            PeriodicTable.Add(new Atom(97, "Bk", 247.0703, 1.5));
            PeriodicTable.Add(new Atom(98, "Cf", 251.0796, 1.5));
            PeriodicTable.Add(new Atom(99, "Es", 252.0829, 1.5));
            PeriodicTable.Add(new Atom(100, "Fm", 257.0951, 1.5));
            PeriodicTable.Add(new Atom(101, "Md", 258.0986, 1.5));
            PeriodicTable.Add(new Atom(102, "No", 259.1009, 1.5));
            PeriodicTable.Add(new Atom(103, "Lr", 266, 1.5));
            PeriodicTable.Add(new Atom(104, "Rf", 267, 1.5));
            PeriodicTable.Add(new Atom(105, "Db", 268, 1.5));
            PeriodicTable.Add(new Atom(106, "Sg", 269, 1.5));
            PeriodicTable.Add(new Atom(107, "Bh", 270, 1.5));
            PeriodicTable.Add(new Atom(108, "Hs", 277, 1.5));
            PeriodicTable.Add(new Atom(109, "Mt", 278, 1.5));
            PeriodicTable.Add(new Atom(110, "Ds", 281, 1.5));
            PeriodicTable.Add(new Atom(111, "Rg", 282, 0.5));
            PeriodicTable.Add(new Atom(112, "Cn", 285, 1.0));
            PeriodicTable.Add(new Atom(113, "Nh", 286, 1.5));
            PeriodicTable.Add(new Atom(114, "Fl", 289, 1.5));
            PeriodicTable.Add(new Atom(115, "Mc", 290, 1.5));
            PeriodicTable.Add(new Atom(116, "Lv", 293, 1.5));
            PeriodicTable.Add(new Atom(117, "Ts", 294, 0));
            PeriodicTable.Add(new Atom(118, "Og", 294, 0));
        }

        //method gets Weight of element named s or throws new exception
        public static double Weight(string s)
        {
            Atom? a = PeriodicTable.First(c => c.Name == s);
            if (a.HasValue)
                return a.Value.Weight;
            else
                throw new Exception("Element " + s + " doesn't exist in periodic table of elements");
        }

        //method gets valence of element
        public static double Valence(string s)
        {
            Atom? a = PeriodicTable.First(c => c.Name == s);
            if (a.HasValue)
                return a.Value.Valence;
            else
                throw new Exception("Element " + s + " doesn't exist in periodic table of elements");
        }
    }
}
