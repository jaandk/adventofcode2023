using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    [TestClass]
    public class Dec3
    {
        string content;

        [TestInitialize]
        public void Init()
        {
            content = File.ReadAllText("Dec3.txt");
        }

        [TestMethod]
        public void Part1() // Work in progress
        {
            int total = 0;
            var matches = Regex.Matches(content, ".[0-9]+.");

            foreach (Match match in matches)
            {

                if (Regex.IsMatch(match.Value, @"\.[0-9]+\."))
                {
                    Trace.WriteLine("No Match "+match.Value);
                    continue;
                }
                else
                {
                    Trace.WriteLine("Match: "+match.Value);
                    var number = Regex.Match(match.Value, "[0-9]+");
                    total += int.Parse(number.Value);
                }

            }

            Trace.WriteLine("Total: " + total);
        }

    }
}
