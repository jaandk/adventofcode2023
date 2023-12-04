using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    [TestClass]
    public class Dec2
    {

        string[] lines;


        [TestInitialize]
        public void Init()
        {
            lines = File.ReadAllLines("Dec2.txt");
        }


        [TestMethod]
        public void Part1()
        {
            var numberofBalls = new Dictionary<string, int>();
            numberofBalls.Add("red", 12);
            numberofBalls.Add("green", 13);
            numberofBalls.Add("blue", 14);

            int idTotals = 0;

            foreach (var line in lines)
            {
                var split = line.Split(':');
                var splitGame = split[1].Split(";");

                bool isGamePosible = true;

                foreach (var game in splitGame)
                {
                    var games = game.Split(",");

                    foreach (var item in games)
                    {
                        var matchNumber = Regex.Match(item, "[0-9]{1,2}");
                        var matchColor = Regex.Match(item, @"[a-z]+");

                        var tmp1 = numberofBalls[matchColor.Value];

                        if (numberofBalls[matchColor.Value] >= int.Parse(matchNumber.Value))
                        {

                        }
                        else
                        {
                            isGamePosible = false;
                            continue;
                        }

                    }
                }

                if (isGamePosible)
                {
                    idTotals += int.Parse(Regex.Match(split[0], "[0-9]+").Value);
                }

            }

            Trace.WriteLine("Ids Total: " + idTotals);
        }

        [TestMethod]
        public void Part2()
        {
            int overallTotal = 0;

            foreach (var line in lines)
            {
                var split = line.Split(':');
                var splitGame = split[1].Split(";");

                var numberofBalls = new Dictionary<string, int>();
                numberofBalls.Add("red", 0);
                numberofBalls.Add("green", 0);
                numberofBalls.Add("blue", 0);

                int total = 0;

                foreach (var game in splitGame)
                {
                    var games = game.Split(",");

                    foreach (var item in games)
                    {
                        var matchNumber = Regex.Match(item, "[0-9]{1,2}");
                        var matchColor = Regex.Match(item, @"[a-z]+");

                        if (numberofBalls[matchColor.Value] < int.Parse(matchNumber.Value))
                        {
                            numberofBalls[matchColor.Value] = int.Parse(matchNumber.Value);
                        }
                    }
                }

                foreach (var ball in numberofBalls)
                {
                    if (ball.Value > 0)
                    {

                        if (total == 0)
                        {
                            total = ball.Value;
                        }
                        else
                        {
                            total = total * ball.Value;
                        }

                    }
                }

                overallTotal += total;
            }

            Trace.WriteLine("Total: " + overallTotal);
        }
    }
}