using System;

namespace AdventOfCode2019.Logic
{
    public static class DayOne
    {
        public static int CalculateAllFuelModules(int[] massInputs)
        {
            int totalFuel = 0;
            for (int i = 0; i < massInputs.Length; i++)
            {
                //totalFuel += CalculateFuel(massInputs[i]);
                totalFuel += RecursiveCalculateFuel(massInputs[i]);
            }
            return totalFuel;
        }

        private static int CalculateFuel(double mass)
        {
            try
            {
                return Convert.ToInt32(Math.Floor(mass / 3.0) - 2);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private static int RecursiveCalculateFuel(int mass)
        {
            mass = Convert.ToInt32(Math.Floor(mass / 3.0) - 2);
            if (mass < 0) return 0;
            return mass += RecursiveCalculateFuel(mass);
        }
    }
}
