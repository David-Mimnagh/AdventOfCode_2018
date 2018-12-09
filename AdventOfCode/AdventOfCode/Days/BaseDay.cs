using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public abstract class BaseDay
    {
        public string[] PuzzleInput{ get; set; }

        public void Initialise(string[] input)
        {
            PuzzleInput = input;
        }
        
    }
}
