using System;

namespace AdventOfCode2019.Logic
{
    public static class Day1
    {
        // Only for modules (task 1)
        public static int CalculateFuelModules()
        {
            int[] massInputs = Helper.FileHandler.GetInput("input_01");
            int totalFuel = 0;
            for (int i = 0; i < massInputs.Length; i++)
            {
                totalFuel += CalculateFuel(massInputs[i]);
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

        // Modules + fuel (task 2)
        public static int CalculateTotalFuelModules()
        {
            int[] massInputs = Helper.FileHandler.GetInput("input_01");
            int totalFuel = 0;
            for (int i = 0; i < massInputs.Length; i++)
            {
                //totalFuel += CalculateFuel(massInputs[i]);
                totalFuel += RecursiveCalculateFuel(massInputs[i]);
            }
            return totalFuel;
        }

        private static int RecursiveCalculateFuel(int mass)
        {
            mass = Convert.ToInt32(Math.Floor(mass / 3.0) - 2);
            if (mass < 0) return 0;
            return mass += RecursiveCalculateFuel(mass);
        }
    }
}
