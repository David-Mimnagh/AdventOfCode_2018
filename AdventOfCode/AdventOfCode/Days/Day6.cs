using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day6 : BaseDay
    {
        string[,] Grid { get; set; }

        void InitGrid()
        {
            Grid = new string[400, 400];
            for (int i = 0; i < 400; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    Grid[i, j] = ".";
                }
            }
        }

        void PrintGrid()
        {
            for (int i = 0; i < 400; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    Console.Write(Grid[i, j]);
                }
                Console.WriteLine(System.Environment.NewLine);
            }
        }

        public void Run()
        {

            InitGrid();
            PrintGrid();
        }
    }
}
