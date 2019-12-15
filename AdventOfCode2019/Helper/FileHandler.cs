using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Helper
{
    public class FileHandler
    {
        private static string ReadFile(string name)
        {
            return File.ReadAllText("./Resources/" + name + ".txt").ToString();
        }

        public static int[] GetInput(string name)
        {
            var input = ReadFile(name);
            string cleanedInput = System.Text.RegularExpressions.Regex.Replace(input, @"\r\n", ",");
            return cleanedInput.Split(",").Select(n => Convert.ToInt32(n)).ToArray();
        }

        public static (string[], string[]) GetDoubleInput(string name)
        {
            string input = ReadFile(name);
            string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            string[] line1 = lines[0].Split(",").ToArray();
            string[] line2 = lines[1].Split(",").ToArray();

            return (line1, line2);
        }

        public static string[] GetPerRow(string fileName)
        {
            var input = File.ReadAllText("./Resources/" + fileName + ".txt");
            string[] rows = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return rows;
        }
    }
}
