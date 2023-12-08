using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    [TestClass]
    public class Dec8
    {
        string[] content;

        [TestInitialize]
        public void Init()
        {
            content = File.ReadAllLines("Dec8.txt");
        }

        [TestMethod]
        public void Part1()
        {
            var instrictions = content[0].ToCharArray();
            var parts = new Dictionary<string, (string, string)>();

            for (int i = 2; i < content.Length; i++)
            {
                parts.Add(content[i][0..3], (content[i][7..10], content[i][12..15]));
            }

            int iterations = 0;
            var curretKey = "AAA";
            for (int i = 0; i < instrictions.Length; i++)
            {
                if (instrictions[i] == 'L')
                    curretKey = parts[curretKey].Item1;
                else
                    curretKey = parts[curretKey].Item2;

                iterations++;

                if (i == instrictions.Length - 1)
                    i = -1;

                if (curretKey == "ZZZ")
                    break;
            }

            Trace.WriteLine("Total: " + iterations);
        }

        [TestMethod]
        public void Part2()
        {
            var instrictions = content[0].ToCharArray();
            var parts = new Dictionary<string, (string, string)>();

            for (int i = 2; i < content.Length; i++)
            {
                parts.Add(content[i][0..3], (content[i][7..10], content[i][12..15]));
            }


            //var testIterations = new Dictionary<int, List<int>>();
            var testIterations = new Dictionary<int, long>();

            var currentKeys = parts.Keys.Where(s => s.EndsWith('A')).Select(s => s).ToList();
            int iterations = 0;

            for (int i = 0; i < instrictions.Length; i++)
            {
                for (int j = 0; j < currentKeys.Count; j++)
                {
                    if (instrictions[i] == 'L')
                        currentKeys[j] = parts[currentKeys[j]].Item1;
                    else
                        currentKeys[j] = parts[currentKeys[j]].Item2;

                }


                iterations++;

                if (i == instrictions.Length - 1)
                    i = -1;

                for (int j = 0; j < currentKeys.Count; j++)
                {
                    if (currentKeys[j].EndsWith('Z') && !testIterations.ContainsKey(j))
                        testIterations.Add(j, iterations);
                }

                if (testIterations.Count == 6)
                {
                    break;
                }


            }

            var total = MathNet.Numerics.Euclid.LeastCommonMultiple(testIterations.Select(s => s.Value).ToList());

            Trace.WriteLine("Total: " + total);

        }
    }
}
