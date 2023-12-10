using System.Diagnostics;

namespace AdventOfCode2023
{
    [TestClass]
    public class Dec4
    {
        string[] lines;


        [TestInitialize]
        public void Init()
        {
            lines = File.ReadAllLines("Dec4.txt");
        }

        [TestMethod]
        public void Part1()
        {
            double total = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                var cards = lines[i].Split('|')[0].Substring(10).Split(' ').Where(s => !string.IsNullOrEmpty(s));
                var numbers = lines[i].Split('|')[1].Split(' ').Where(s => !string.IsNullOrEmpty(s));

                var winners = numbers.Where(s => cards.Contains(s));

                if (winners.Any())
                {
                    total += Math.Pow(2, winners.Count()) * 0.5;
                }
            }

            Trace.WriteLine("Total: " + total);
        }
    }
}
