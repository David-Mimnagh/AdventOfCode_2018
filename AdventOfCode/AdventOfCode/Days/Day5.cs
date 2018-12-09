using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day5 : BaseDay
    {
        public int Answer { get; set; }


        public void CompletePartOne(string input)
        {
            var resultingString = input;
            for (int i = 0; i < resultingString.Length; i++)
            {
                var currentCharacter = resultingString[i];
                if(i+1 < resultingString.Length)//can compare with next
                {
                    var nextChar = resultingString[i + 1];
                    if(currentCharacter.ToString().ToLower() == nextChar.ToString().ToLower())//make sure they are thesame
                    {
                        bool matching = false;
                        if(char.IsLower(currentCharacter) && char.IsUpper(nextChar)) //matching polymer
                            matching = true;
                        if (char.IsUpper(currentCharacter) && char.IsLower(nextChar)) //matching polymer
                            matching = true;

                        if(matching)
                        {
                            StringBuilder sb = new StringBuilder(resultingString);
                            sb[i] = Convert.ToChar(" ");
                            sb[i + 1] = Convert.ToChar(" ");
                            resultingString = sb.ToString();
                            resultingString = resultingString.Replace(" ", String.Empty);
                            i = -1;
                            continue;
                        }
                    }
                }

            }
            //Console.WriteLine("AnswerString: " + resultingString);
            Answer = resultingString.Length;
            //Console.WriteLine("Units Remaining: " + resultingString.Length);

        }

        public void CompletePartTwo()
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            var copyPuzzleInput = PuzzleInput[0];
            List<Tuple<string, int>> results = new List<Tuple<string, int>>();
            for (int i = 0; i < alphabet.Length; i++)
            {
                var currentAlphabetLetter = alphabet[i].ToString().ToLower();
                var regexString = "[" + currentAlphabetLetter + currentAlphabetLetter.ToUpper() + "]";
                copyPuzzleInput = PuzzleInput[0];
                copyPuzzleInput = Regex.Replace(copyPuzzleInput, regexString, "");
                CompletePartOne(copyPuzzleInput);
                results.Add(new Tuple<string, int>(currentAlphabetLetter, Answer));
            }

            var sortedList = results.OrderBy(x => x.Item2);
            Console.WriteLine("Letter: " + sortedList.First().Item1);
            Console.WriteLine("ShortestLength: " + sortedList.First().Item2);
        }

        public void Run()
        {
            //CompletePartOne(PuzzleInput[0]);
            CompletePartTwo();
        }
    }
}
