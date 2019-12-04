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
            var second = SollPasswords(first);

            return (first.Count.ToString(), second.Count.ToString());
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

        private static List<int> SollPasswords(List<int> passwordPosibilities)
        {
            var matchingPasswords = new List<int>();
            foreach (int password in passwordPosibilities)
            {
                var possibilities = password.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
                if (possibilities.AtleastOneSingleDouble()) matchingPasswords.Add(password);
            }
            return matchingPasswords;
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

        public static bool AtleastOneSingleDouble(this int[] number)
        {
            bool pass= false;
            for (int i = 0; i < number.Length - 1; i++)
            {
                if (number[i] == number[i + 1])
                {
                    if (i != 0 && number[i] != number[i - 1]) { continue; }
                    else if (i - 2 >= 0 && i <= number.Length - 3 && number[i] == number[i + 2]) { continue; }
                    pass = true; 
                }
            }
            return pass;
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
