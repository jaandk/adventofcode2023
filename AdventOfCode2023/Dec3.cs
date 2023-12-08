using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
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
            var rows = content.Split("\r\n").Take(new Range(27, 30)).ToArray();

            int totalnumber = 0;

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
                    if (contentArray[i] == '*')
                    {
                        var range = new Range(i - 1, i + 2);
                        var top = preRow.Take(range).ToList();
                        var current = contentArray.Take(range).ToList();
                        var button = nextRow.Take(range).ToList();

                        var extendenrange = new Range(i - 3, i + 4);
                        var extendentop = preRow.Take(extendenrange).ToList();
                        var extendencurrent = contentArray.Take(extendenrange).ToList();
                        var extendenbutton = nextRow.Take(extendenrange).ToList();


                        //Trace.WriteLine(new string(top.ToArray()));
                        //Trace.WriteLine(new string(current.ToArray()));
                        //Trace.WriteLine(new string(button.ToArray()));
                        //Trace.WriteLine("");

                        if (!isValidMatrix(top.ToList(), current.ToList(), button.ToList()))
                            continue;

                        var topStr = findNumber(top, extendentop);
                        var currentStr = findNumber(current, extendencurrent);
                        var buttonStr = findNumber(button, extendenbutton);

                        List<int> numbers = new List<int>();

                        //if (!string.IsNullOrEmpty(topStr))
                        //{
                        if (int.TryParse(new string(topStr), out int num1))
                            numbers.Add(num1);
                        Trace.WriteLine(topStr + " -- " + new string(extendentop.ToArray()));
                        //}
                        //if (!string.IsNullOrEmpty(currentStr))
                        //{
                        if (int.TryParse(new string(currentStr), out int num2))
                            numbers.Add(num2);
                        Trace.WriteLine(currentStr + " -- " + new string(extendencurrent.ToArray()));
                        //}
                        //if (!string.IsNullOrEmpty(buttonStr))
                        //{
                        if (int.TryParse(new string(buttonStr), out int num3))
                            numbers.Add(num3);
                        Trace.WriteLine(buttonStr + " -- " + new string(extendenbutton.ToArray()));
                        //}

                        Trace.WriteLine("");

                        if (numbers.Count > 1)
                        {
                            var numMultiply = numbers[0] * numbers[1];
                            totalnumber += numMultiply;
                        }

                    }
                }
            }

            Console.WriteLine("Total: " + totalnumber.ToString());
        }

        bool isValidMatrix(List<char> top, List<char> middel, List<char> last)
        {
            bool result;

            List<bool> listResult = new List<bool>();

            if (top.Count(s => s == '.') != 3 && !(char.IsNumber(top[0]) && top[1] == '.' && char.IsNumber(top[2])))
                listResult.Add(true);

            if (middel.Count(s => s == '.') != 2)
                listResult.Add(true);
            if (char.IsNumber(middel[0]) && char.IsNumber(middel[2]))
                listResult.Add(true);

            if (last.Count(s => s == '.') != 3 && !(char.IsNumber(top[0]) && top[1] == '.' && char.IsNumber(top[2])))
                listResult.Add(true);

            return (listResult.Count(s => s == true) > 1);
        }

        string? findNumber(List<char> line, List<char> extended)
        {
            bool anyNumber = !line.Any(s => char.IsNumber(s));
            if (anyNumber)
            {
                return null;
            }

            var number = numberLineV3(extended);



            return number;

        }

        string numberLineV3(List<char> extended)
        {
            string str = new string(extended.ToArray());

            var matches = Regex.Matches(str, "[0-9]+");

            var matchResult = matches.OrderByDescending(s => s.Length).ToList();

            return matchResult.First().Value;
        }

        string numberlineV2(int index, bool forword, List<char> extended, string strAppend)
        {
            StringBuilder str = new StringBuilder();
            str.Append(strAppend);

            if (forword)
            {
                if (char.IsDigit(extended[index + 2]))
                {
                    str.Append(extended[index + 2]);
                    return numberlineV2(++index, true, extended, str.ToString());
                }

                return str.ToString();
            }
            else
            {
                if (index + 2 == 0)
                {
                    if (char.IsDigit(extended[index + 2]))
                    {
                        str.Append(extended[index + 2]);

                    }

                    return numberlineV2(++index, true, extended, str.ToString());
                }
                else if (!char.IsDigit(extended[index + 2]))
                    return numberlineV2(++index, true, extended, str.ToString());

                return numberlineV2(--index, false, extended, str.ToString());
            }
        }

        string numberline(int index, bool forword, List<char> extended)
        {
            StringBuilder str = new StringBuilder();

            if (char.IsDigit(extended[index + 2]) && forword)
            {
                str.Append(extended[index + 2]);
                str.Append(numberline(++index, true, extended));
                return str.ToString();
            }
            else if (char.IsDigit(extended[index + 2]) && index + 2 != 0)
            {
                return numberline(--index, false, extended);
            }
            else if (forword && extended[index + 2] == '.')
            {
                return str.ToString();
            }
            else
            {
                str.Append(numberline(++index, true, extended));
                return str.ToString();
            }

        }
    }
}
