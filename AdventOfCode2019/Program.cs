using System;

namespace AdventOfCode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Santa!");
            Day1();
            Day2();
            Day3();


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
            Console.WriteLine("3.1. Found the closest intersection, it was {0}", result);
        }
    }
}
