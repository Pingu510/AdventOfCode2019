using System;
using System.Collections.Generic;
using System.Linq;

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

            while (startValue <= endValue)
            {
                if (startValue.ContainsDouble() && startValue.NoDecrease())
                {
                    possiblePasswords.Add(startValue);
                }
                startValue++;                
            }
            return possiblePasswords;
        }

        private static List<int> SollPasswords(List<int> passwordPosibilities)
        {
            var matchingPasswords = new List<int>();
            foreach (int password in passwordPosibilities)
            {
                if (password.AtleastOneSingleDouble() && password.NoDecrease()) matchingPasswords.Add(password);
            }
            return matchingPasswords;
        }
    }
    public static class ExtensionMethod
    {
        public static bool ContainsDouble(this int number)
        {
            string passcode = number.ToString();
            for (int i = 0; i < passcode.Length - 1; i++)
            {
                if (passcode[i] == passcode[i + 1]) return true;
            }
            return false;
        }

        public static bool AtleastOneSingleDouble(this int number)
        {
            string passcode = number.ToString();
            for (int i = 0; i < passcode.Length - 1; i++)
            {
                int occurance = passcode.Count(x => x == passcode[i + 1]);
                if (passcode[i] == passcode[i + 1] && occurance == 2)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool NoDecrease(this int number)
        {
            string passcode = number.ToString();
            for (int i = 0; i < passcode.Length - 1; i++)
            {
                if (passcode[i] > passcode[i + 1]) return false;
            }
            return true;
        }
    }
}
