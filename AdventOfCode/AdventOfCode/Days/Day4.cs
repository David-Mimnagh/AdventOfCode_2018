using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
   public class TimeLog
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int TimeHour { get; set; }
        public int TimeMinute { get; set; }
        public DateTime MessageDateTime { get; set; }
        public string Message { get; set; }
    }

    public class Day4
    {
        public string[] PuzzleInput { get; set; }
        public List<TimeLog> Records { get; set; }
        public List<string> guardRecords { get; set; }

        void PrintBaseTable()
        {
            Console.WriteLine("Date\tID\tMinute");
            var HoursString = "";
            var MinutesString = ""; 
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    HoursString += i.ToString();
                    MinutesString += j.ToString();
                }
            }
            Console.WriteLine("    \t  \t" + HoursString);
            Console.WriteLine("    \t  \t" + MinutesString);
        }

        void GetPuzzleTimeLog()
        {
           Records = new List<TimeLog>();
            foreach (var line in PuzzleInput)
            {
                var message = line.Substring(line.IndexOf("]") + 1).Trim();
                var dateTime = line.Replace(" " + message, String.Empty);
                dateTime = dateTime.Replace("[", String.Empty).Replace("]", String.Empty);
                var date = dateTime.Substring(0, dateTime.IndexOf(" "));
                dateTime = dateTime.Replace(date, String.Empty).Trim();
                var dateArr = date.Split('-');
                var year = Convert.ToInt32(dateArr[0]);
                var month = Convert.ToInt32(dateArr[1]);
                var day = Convert.ToInt32(dateArr[2]);
                var time = dateTime.Split(':');
                var hour = Convert.ToInt32(time[0]);
                var minute = Convert.ToInt32(time[1]);
                var dt = new DateTime(year, month, day, hour, minute, 0);
                Records.Add(new TimeLog {Year = year, Month = month, Day = day, TimeHour = hour, TimeMinute = minute, Message = message, MessageDateTime = dt });
                Records = Records.OrderBy(r => r.MessageDateTime).ToList();
            }
        }

        void ParseRecords()
        {
            var currentLineString = "";
            var fellAsleepAt = "";
            var wokeUpAt = "";
            guardRecords = new List<string>();
            var currentLine = 0;
            
            foreach (var r in Records)
            {
                //TODO: PROBLEM IF THE GUARD WAKES UP AND FALLS ASLEEP AGAIN.

                if (r.Message.Contains("Guard") || currentLine == Records.Count-1) // start of new line
                {
                    if (r.Message.Contains("asleep")) // means currently awake
                    {
                        fellAsleepAt += (fellAsleepAt.Length == 0) ? r.TimeMinute.ToString() : ("&" + r.TimeMinute.ToString());
                    }

                    if (r.Message.Contains("wakes")) // means currently asleep
                    {
                        wokeUpAt += (wokeUpAt.Length == 0) ? r.TimeMinute.ToString() : ("&" + r.TimeMinute.ToString());
                    }
                    if (fellAsleepAt.Length > 0 && wokeUpAt.Length > 0) // onto next guard
                    {
                        var timestring = "";

                        for (int i = 0; i < 60; i++)
                        {
                            var currentlyAsleep = false;
                            if(fellAsleepAt.Contains("&"))
                            {
                                var fellAsleepAtTimes = fellAsleepAt.Split('&');
                                var wokenAtTimes = wokeUpAt.Split('&');
                                for (int j = 0; j < fellAsleepAtTimes.Length; j++)
                                {
                                    if(i >= Convert.ToInt32(fellAsleepAtTimes[j]))
                                    {
                                        if (i < Convert.ToInt32(wokenAtTimes[j]))
                                            currentlyAsleep = true;
                                    }
                                }
                            }
                            else
                            {
                                if(i>= Convert.ToInt32(fellAsleepAt))
                                {
                                    if (i < Convert.ToInt32(wokeUpAt))
                                        currentlyAsleep = true;
                                }
                            }
                            if(!currentlyAsleep) // not fallen asleep yet
                            {
                                timestring += ".";
                            }
                            else 
                            {
                                timestring += "#";
                            }
                        }
                        currentLineString += timestring;
                        guardRecords.Add(currentLineString);
                        fellAsleepAt = "";
                       wokeUpAt = "";
                    }
                    var guardId = "";
                    if (r.Message.Contains("Guard"))
                        guardId = r.Message.Substring(r.Message.IndexOf("#"), r.Message.IndexOf(" begin") - " begin".Length);
                    else
                    {
                        //r.Month + "-" + r.Day + "\t" + guardId + "\t";
                        guardId = currentLineString.Split('\t')[1];
                    }

                    if (currentLineString.Length > 0)
                    {
                        if (currentLineString.Last().ToString() != ".")
                        {
                            if (currentLineString.Last().ToString() != "#")
                            {
                                for (int i = 0; i < 60; i++)
                                {
                                    currentLineString += ".";
                                }
                            }
                        }
                    }
                    Console.WriteLine(currentLineString);
                    currentLineString = "";
                    currentLineString += r.Month + "-" + r.Day + "\t" + guardId + "\t";
                }

                if(r.Message.Contains("asleep")) // means currently awake
                {
                    fellAsleepAt += (fellAsleepAt.Length == 0) ? r.TimeMinute.ToString() : ("&"+r.TimeMinute.ToString());
                }

                if (r.Message.Contains("wakes")) // means currently asleep
                {
                    wokeUpAt += (wokeUpAt.Length == 0) ? r.TimeMinute.ToString() : ("&" + r.TimeMinute.ToString());
                }
                currentLine++;
            }

            List<Tuple<int, List<int>>> guardRecordOverall = new List<Tuple<int, List<int>>>();
            foreach (var guardRec in guardRecords)
            {
                var guardRecArr = guardRec.Split('\t');
                var guardID = Convert.ToInt32(guardRecArr[1].Replace("#", String.Empty));
                List<int> minuteSleeping = new List<int>();
                for (int i = 0; i < 60; i++)
                {
                    string listString = guardRecArr[2];
                   
                    if (listString[i] == '#')
                        minuteSleeping.Add(i);
                }
                guardRecordOverall.Add(new Tuple<int, List<int>>(guardID, minuteSleeping));
            }
            guardRecordOverall = guardRecordOverall.OrderBy(g => g.Item1).ToList();
            
            var copy = guardRecordOverall.GroupBy(g => g.Item1);
            List<Tuple<int, List<int>>> minuteCount = new List<Tuple<int, List<int>>>();
            for (int i = 0; i < copy.Count(); i++)
            {
                var listofstuff = copy.ElementAt(i); // this is what I want
                List<int> minutesSlept = new List<int>();
                var currentId = 0;
                foreach (var item in listofstuff)
                {
                        currentId = item.Item1;
                        minutesSlept = minutesSlept.Concat(item.Item2).ToList();
                }
                minuteCount.Add(new Tuple<int, List<int>>(currentId, minutesSlept));

            }
            var another = new List<Tuple<int, int, int>>(); //id, most common minute, occurences
            //Part1
            //foreach (var mc in minuteCount)
            //{
            //    var groupedMinutes = mc.Item2.GroupBy(x => x).ToList(); // group all of the minutes
            //    var mostCommonMinute = groupedMinutes.OrderByDescending(x => x.Count()).First().Key;
            //    var totalSleptFor = 0;
            //    totalSleptFor = mc.Item2.Count;
            //    another.Add(new Tuple<int, int, int>(mc.Item1,totalSleptFor, mostCommonMinute));
            //}

            //Part2
            foreach (var mc in minuteCount)
            {
                var groupedMinutes = mc.Item2.GroupBy(x => x).ToList(); // group all of the minutes
                var mostCommonMinute = groupedMinutes.OrderByDescending(x => x.Count()).First();
                var totalSleptFor = 0;
                totalSleptFor = mc.Item2.Count;

                another.Add(new Tuple<int, int, int>(mc.Item1, mostCommonMinute.Key, mostCommonMinute.Count()));
            }


            //var answer = another.OrderByDescending(a => a.Item2).ToList().First(); // part 1
            var answer = another.OrderByDescending(a => a.Item3).ToList().First(); // part 1
            var multiplaction = answer.Item1 * answer.Item2;
            Console.WriteLine("ANSWER: " + multiplaction.ToString());
        }

        public void CompletePartOne()
        {
            PrintBaseTable();
            GetPuzzleTimeLog();
            ParseRecords();
        }

    }
}
