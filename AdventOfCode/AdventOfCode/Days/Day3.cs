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
                    Console.Write(Grid[i, j]);
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
        void CompleteInstructions()
        {
            foreach (var inst in Instructions)
            {
                Grid[inst.Y, inst.X] = inst.ID.ToString();

                for (int i = 0; i < inst.W; i++)
                {
                    for (int j = 0; j < inst.H; j++)
                    {

                    }
                }
            }       
        }
        public void CompletePart_1()
        {
            GridSize = 25;
            ReadInstructions();
            PrepGrid();
            CompleteInstructions();
            PrintGrid();
        }
    }
}
