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
                    Trace.WriteLine("No Match " + match.Value);
                    continue;
                }
                else
                {
                    Trace.WriteLine("Match: " + match.Value);
                    var number = Regex.Match(match.Value, "[0-9]+");
                    total += int.Parse(number.Value);
                }

            }

            Trace.WriteLine("Total: " + total);
        }

        [TestMethod]
        public void RegextTest1()
        {
            var pattern1 = @"([0-9]+)(?!\.)";
            var pattern2 = @"(?<!\.)([0-9]+)";
            var pattern3 = @"(?<!\.)([0-9]+)([0-9]+)(?!\.)";

            var matches1 = Regex.Matches(content, pattern1);
            var matches2 = Regex.Matches(content, pattern2);
            var matches3 = Regex.Matches(content, pattern3);

            var matches = Regex.Matches(content, ".[0-9]+.");

            for (int i = 0; i < 30; i++)
            {
                Trace.WriteLine("Org: " + matches[i].Value + " Pat1: " + matches1[i].Value + " Pat2: " + matches2[i].Value + " Pat3: " + matches3[i].Value);
            }
        }

    }
}
