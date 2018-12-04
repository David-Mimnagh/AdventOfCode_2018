using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day2
    {
        public string[] PuzzleInput { get; set; }
        public int TwoLetterCount { get; set; }
        public int ThreeLetterCount { get; set; }
        public int Checksum { get; set; }
        public string CorrectID { get; set; }

        public void GetLetterCount_Part1()
        {
            var currentCharList = new List<char>();
            var ThreeAdded = false;
            var TwoAdded = false;
            foreach (var line in PuzzleInput)
            {
                currentCharList = new List<char>();
                ThreeAdded = false;
                TwoAdded = false;
                foreach (var c in line)
                {
                   currentCharList.Add(c);
                }
                var group = currentCharList.GroupBy(i => i);
                group = group.OrderBy(g => g.Count());

                foreach (var g in group)
                {
                    if (g.Count() == 3 && !ThreeAdded)
                    {
                        ThreeLetterCount++;
                        ThreeAdded = true;
                    }
                    else if (g.Count() == 2 && !TwoAdded)
                    {
                        TwoLetterCount++;
                        TwoAdded = true;
                    }
                }
            }
        }

        string[] GetStringArray(string s)
        {
            List<string> sArr = new List<string>();
            foreach (var c in s)
            {
                sArr.Add(c.ToString());
            }
            return sArr.ToArray();
        }
        public void GetCommonChars_Part2()
        {
            var currentStringList = new List<string>();
            foreach (var line in PuzzleInput)
            {
                var lineArr = GetStringArray(line);
                foreach (var s in currentStringList)
                {
                    var strArr = GetStringArray(s);
                    var commonChars = new List<int>();
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        if(strArr[i] != lineArr[i])
                        {
                            commonChars.Add(i);
                        }
                    }

                    if (commonChars.Count == 1)
                    {
                        strArr[commonChars[0]] = "";
                        CorrectID = String.Join("", strArr);
                    }
                }
                currentStringList.Add(line);
            }
        }

        public void GetChecksum()
        {
            //GetLetterCount_Part1();
            //Checksum = TwoLetterCount * ThreeLetterCount;
            GetCommonChars_Part2();
            Console.WriteLine("Correct ID: " + CorrectID);
        }

    }
}
