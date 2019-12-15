using System;

namespace AdventOfCode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Santa!");
            //Day5();
            Day6();

            Console.ReadKey();
        }

        static void Day1()
        {
            var fuel = Logic.Day1.CalculateFuelModules();
            Console.WriteLine("1.1. The spacecraft will need {0} amounts of fuel for it's modules.", fuel);// 3279287

            fuel = Logic.Day1.CalculateTotalFuelModules();
            Console.WriteLine("1.2. But the weight of that fuel requires more fuel, so the total amount is {0} fuel.", fuel);
        }

        static void Day2()
        {
            int[] input = Logic.Day2.ResetComputer(12, 2);
            Console.WriteLine("2.1. Computer output was {0}.", Logic.Day2.RunComupter(input));

            int[] startValues = Logic.Day2.CalculateStartValues(19690720);
            Console.WriteLine("2.2. Computer noun was {0} and verb was {1} which totals in {2}.", startValues[0], startValues[1], (100 * startValues[0] + startValues[1]));
        }

        static void Day3()
        {
            var result = Logic.Day3.CrossTheStreams();
            Console.WriteLine("3.1. Found the closest intersection, it was {0}", result.Item1);
            Console.WriteLine("3.2. The closest one step wise was {0}", result.Item2);
        }
        
        static void Day4()
        {
            var result = Logic.Day4.CodeCracking();
            Console.WriteLine("4.1. After the elves description there was {0} matching passwords.", result.Item1);
            Console.WriteLine("4.2. Luckilly they narrowed it down to {0} solutions.", result.Item2);
        }

        static void Day5()
        {
            var result = Logic.Day5.Test();
            Console.WriteLine("5.1. {0}", result);
        }
        static void Day6()
        {
            var result = Logic.Day6.CalculateTravelPaths();
            Console.WriteLine("6.1. The star map whows that theres a total of {0} orbits.", result.Item1);
            Console.WriteLine("6.2. Between me and Santa there is {0} orbits.", result.Item2);
        }
    }
}
