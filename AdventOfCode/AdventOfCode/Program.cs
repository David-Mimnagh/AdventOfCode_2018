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
        const int DAYNUMBER = 1;
        const string BASEPATH = @"..\..\Files\day";


        static string[] ReadFileInput()
        {
            var currPath = BASEPATH + (DAYNUMBER.ToString() + ".txt");
            var input = System.IO.File.ReadAllLines(currPath);
            return input;
        }

        static void Main(string[] args)
        {
            //Day1 d1 = new Day1(ReadFileInput());
            //d1.Initialise(ReadFileInput());
            //d1.CalculateFreq_Part2();

            //Day2 d2 = new Day2(ReadFileInput());
            //d2.Initialise(ReadFileInput());
            //d2.GetChecksum();

            //Day3 d3 = new Day3(ReadFileInput());
            //d3.Initialise(ReadFileInput());
            //d3.CompletePart_1();

            //Day4 d4 = new Day4(ReadFileInput());
            //d4.Initialise(ReadFileInput());
            //d4.CompletePartOne();

            //Day5 d5 = new Day5(ReadFileInput());
            //d5.Initialise(ReadFileInput());
            //d5.Run();

            Day6 d6 = new Day6();
            d6.Initialise(ReadFileInput());
            d6.Run();

            Console.ReadLine();
        }
    }
}
