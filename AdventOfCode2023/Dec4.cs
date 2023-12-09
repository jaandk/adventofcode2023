using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    //for (int j = 1; j < winners.Count() + 1; j++)
                    //{
                    //    total += Math.Pow(2, j);

                    //}
                    total += Math.Pow(2, winners.Count()) * 0.5;

                }
            }

            Trace.WriteLine("Total: " + total);
        }
    }
}
