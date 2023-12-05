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
        public void Part1()
        {
            var rows = content.Split("\r\n");

            List<int> numbers = new List<int>();

            var tmpNum = string.Empty;
            var validNum = false;
            var dummyArray = "............................................................................................................................................";

            for (int r = 0; r < rows.Length; r++)
            {
                var preRow = r > 0 ? rows[r - 1].ToArray() : dummyArray.ToArray();
                var nextRow = r != rows.Length - 1 ? rows[r + 1].ToArray() : dummyArray.ToArray();
                var contentArray = rows[r].ToArray();

                for (int i = 0; i < contentArray.Length; i++)
                {
                    if (char.IsDigit(contentArray[i]))
                    {
                        if (char.IsDigit(contentArray[i]))
                        {
                            tmpNum += contentArray[i];
                        }

                        if (i > 0 && isSpecial(contentArray[i - 1]))
                        {
                            validNum = true;
                        }

                        if (i != contentArray.Length - 1 && isSpecial(contentArray[i + 1]))
                        {
                            validNum = true;
                        }

                        if (i > 0 && isSpecial(preRow[i - 1]))
                        {
                            validNum = true;
                        }

                        if (isSpecial(preRow[i]))
                        {
                            validNum = true;
                        }

                        if (i != contentArray.Length - 1 && isSpecial(preRow[i + 1]))
                        {
                            validNum = true;
                        }

                        if (i > 0 && isSpecial(nextRow[i - 1]))
                        {
                            validNum = true;
                        }

                        if (isSpecial(nextRow[i]))
                        {
                            validNum = true;
                        }

                        if (i != contentArray.Length - 1 && isSpecial(nextRow[i + 1]))
                        {
                            validNum = true;
                        }

                    }
                    else if (!char.IsDigit(contentArray[i]) && !string.IsNullOrEmpty(tmpNum) && validNum)
                    {
                        numbers.Add(int.Parse(tmpNum));

                        tmpNum = string.Empty;
                        validNum = false;
                    }
                    else
                    {
                        tmpNum = string.Empty;
                    }

                    if (validNum && i == contentArray.Length - 1)
                    {
                        numbers.Add(int.Parse(tmpNum));

                        tmpNum = string.Empty;
                        validNum = false;
                    }
                }
            }

            foreach (var number in numbers)
                Trace.WriteLine(number.ToString());

            int total = 0;

            foreach (var number in numbers)
                total += number;

            Trace.WriteLine("Total: " + total);
        }

        bool isSpecial(char c)
        {
            return !char.IsDigit(c) && c != '.';
        }

        [TestMethod]
        public void Part2()
        {

        }
    }
}
