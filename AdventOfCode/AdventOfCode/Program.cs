using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        const int DAYNUMBER = 1;
        const string BASEPATH = @"C:\Projects\Personal\AoC\AdventOfCode\AdventOfCode\Files\day";


        static string[] ReadFileInput()
        {
            var currPath = BASEPATH + (DAYNUMBER.ToString() + ".txt");
            var input = System.IO.File.ReadAllLines(currPath);
            return input;
        }

        static void Main(string[] args)
        {
            Day1 d1 = new Day1();
            d1.PuzzleInput = ReadFileInput();
            d1.CalculateFreq_Part2();
            Console.ReadLine();
        }
    }
}
