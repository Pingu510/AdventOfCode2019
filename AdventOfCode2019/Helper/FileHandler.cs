using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Helper
{
    public class FileHandler
    {
        public static int[] GetInput(string name)
        {
            var input = File.ReadAllText("./Resources/" + name + ".txt").ToString();
            string cleanedInput = System.Text.RegularExpressions.Regex.Replace(input, @"\r\n", ",");
            return cleanedInput.Split(",").Select(n => Convert.ToInt32(n)).ToArray();            
        }
    }
}
