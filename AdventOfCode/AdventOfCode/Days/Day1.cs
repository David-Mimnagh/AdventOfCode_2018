using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day1 : BaseDay
    {
        public Day1(string[] input)
        {
            PuzzleInput = input;
        }
        public string[] PuzzleInput { get; set; }
        public List<int> SeenFrequencies { get; set; }
        public bool FoundMatch { get; set; }
        public int CurrentFreq { get; set; }
        public void CalculateFreq_Part1()
        {
            CurrentFreq = 0;
            
            foreach (var pI in PuzzleInput)
            {
                CurrentFreq -= (Convert.ToInt32(pI) * -1);
            }
            Console.WriteLine("Answer: " + CurrentFreq.ToString());
        }
        public void CalculateFreq_Part2()
        {
            CurrentFreq = 0;
            SeenFrequencies = new List<int>();
            SeenFrequencies.Add(CurrentFreq);
            while (!FoundMatch)
            {
                foreach (var pI in PuzzleInput)
                {
                    CurrentFreq -= (Convert.ToInt32(pI) * -1);
                    if (!SeenFrequencies.Contains(CurrentFreq))
                        SeenFrequencies.Add(CurrentFreq);
                    else
                    {
                        FoundMatch = true;
                        Console.WriteLine("FOUND FIRST MATCH: " + CurrentFreq.ToString());
                        break;
                    }
                }
            }
        }
    }
}
