using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Logic
{
    public class Day4
    {
        private static string _input = "234208 - 765869";
        public static (string, string) CodeCracking()
        {
            var first = FindPasswordPossibilities();


            return (first.Count.ToString(), "");
        }

        private static List<int> FindPasswordPossibilities()
        {
            string[] nums = _input.Split(" - ");
            var possiblePasswords = new List<int>();
            int startValue = Int32.Parse(nums[0]);
            int endValue = Int32.Parse(nums[1]);
            int[] currentNumber = nums[0].ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();

            while (startValue <= endValue)
            {
                if (currentNumber.ContainsDouble() && currentNumber.IncreasingNumbers())
                {
                    possiblePasswords.Add(startValue);
                }
                startValue++;
                for (int i = 5; i >= 0; i--)
                {
                    if (currentNumber[i] < 9)
                    {
                        currentNumber[i]++;
                        break;
                    }
                    currentNumber[i] = 0;
                }
            }
            return possiblePasswords;
        }
    }
    public static class ExtensionMethod
    {
        public static bool ContainsDouble(this int[] number)
        {
            for (int i = 0; i < number.Length - 1; i++)
            {
                if (number[i] == number[i + 1]) return true;
            }
            return false;
        }

        public static bool IncreasingNumbers(this int[] number)
        {
            for (int i = 0; i < number.Length - 1; i++)
            {
                if (number[i] > number[i + 1]) return false;
            }
            return true;
        }
    }
}
