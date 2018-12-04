using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Days;

namespace AdventOfCode
{
    class Program
    {
        const int DAYNUMBER = 3;
        const string BASEPATH = @"C:\Projects\Personal\AoC\AdventOfCode\AdventOfCode\Files\day";


        static string[] ReadFileInput()
        {
            var currPath = BASEPATH + (DAYNUMBER.ToString() + ".txt");
            var input = System.IO.File.ReadAllLines(currPath);
            return input;
        }

        static void Main(string[] args)
        {
            //Day1 d1 = new Day1();
            //d1.PuzzleInput = ReadFileInput();
            //d1.CalculateFreq_Part2();

            //Day2 d2 = new Day2();
            //d2.PuzzleInput = ReadFileInput();
            //d2.GetChecksum();

            Day3 d3 = new Day3();
            d3.PuzzleInput = ReadFileInput();
            d3.CompletePart_1();





            Console.ReadLine();
        }
    }
}
