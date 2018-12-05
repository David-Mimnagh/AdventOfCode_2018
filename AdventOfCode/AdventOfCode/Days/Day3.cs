using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    class Instruction
    {
        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }
    }


    public class Day3
    {
        public string[] PuzzleInput { get; set; }
        string[,] Grid { get; set; }

        int GridSize { get; set; }

        int ClaimCount { get; set; }

        List<Instruction> Instructions = new List<Instruction>();

        void ReadInstructions()
        {
            foreach (var line in PuzzleInput)
            {
                var splitSections = line.Split(' ');
                var id = Convert.ToInt32(splitSections[0].Replace("#", ""));
                var xy = splitSections[2].Replace(":", "").Split(',');
                var wh = splitSections[3].Split('x');

                Instructions.Add(new Instruction { ID = id, X = Convert.ToInt32(xy[0]), Y = Convert.ToInt32(xy[1]), W = Convert.ToInt32(wh[0]), H = Convert.ToInt32(wh[1]) });
            }
        }

        void PrepGrid()
        {
            Grid = new string[GridSize, GridSize];
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Grid[i, j] = ".";
                }
            }
        }

        void PrintGrid()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Console.Write(Grid[j,i]);
                    Console.Write("  ");
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
        void CompleteInstructions()
        {
            var IDNotOverLapped = 0;
            foreach (var inst in Instructions)
            {
                var overlapped = false;
                if (Grid[inst.X, inst.Y] == ".")
                {
                    Grid[inst.X, inst.Y] = inst.ID.ToString();
                }
                else
                {
                    overlapped = true;
                    Grid[inst.X, inst.Y] = "X";
                }

                for (int i = inst.X; i < (inst.X + inst.W); i++)
                {
                    for (int j = inst.Y; j < (inst.Y + inst.H); j++)
                    {
                        var newMarker = inst.ID.ToString();
                        if(Grid[i, j] != inst.ID.ToString())
                        {
                            if (Grid[i, j] != ".")
                            {
                                newMarker = "X";
                            }
                        }

                        Grid[i, j] = newMarker;
                    }
                }
            }       
        }

        void CheckClaims()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (Grid[i, j] == "X")
                        ClaimCount++;
                }
            }
        }
        public void CompletePart_1()
        {
            GridSize = 1000;
            ReadInstructions();
            PrepGrid();
            CompleteInstructions();
            //PrintGrid();
            CheckClaims();
            Console.WriteLine("Claims: " + ClaimCount);
        }
    }
}
