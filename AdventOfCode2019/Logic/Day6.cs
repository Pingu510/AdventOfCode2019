using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Logic
{
    public static class Day6
    {
        public static int TotalOrbits()
        {
            var planets = new List<Planet>();
            string[] orbits = Helper.FileHandler.GetPerRow("input_06");
            
            //create planets
            foreach (var planetCombo in orbits)
            {
                string[] planetcombo = planetCombo.Split(")");
                Planet planet = new Planet(planetcombo[1]);
                planet.TmpParent = planetcombo[0];
                planets.Add(planet);
            }

            var com = new Planet("COM", true)
            {
                OrbitsTotals = 0
            };
            planets.Add(com);

            planets.ForEach(x => { FindParent(planets, x); });
            planets.ForEach(x => { CountOrbits(x); });

            int totalOrbits = 0;
            foreach (var item in planets)
            {
                totalOrbits += item.OrbitsTotals;
            }
            return totalOrbits;
        }

        /// <summary>
        /// Finds the parent to the planet and "connects" them
        /// </summary>
        /// <param name="planets"></param>
        /// <param name="planet"></param>
        private static void FindParent(List<Planet> planets, Planet planet)
        {
            Planet p = planets.FirstOrDefault(x => x.Name == planet.TmpParent);
            if (p != null)
            {
                planet.Parent = p;
            }
        }

        /// <summary>
        /// Counts the whole seeries of orbits to the root
        /// </summary>
        /// <param name="planet"></param>
        private static void CountOrbits(Planet planet)
        {
            int totalOrbits = 0;
            Planet orbit = planet;
            while (!orbit.IsRoot)
            {
                totalOrbits++;
                orbit = orbit.Parent;
            }
            planet.OrbitsTotals = totalOrbits;
        }
    }

    public class Planet
    {
        public Planet(string name, bool isRoot = false)
        {
            Name = name;
            IsRoot = isRoot;
        }
        public string Name { get; set; }
        public bool IsRoot { get; set; }
        public string TmpParent { get; set; }
        public Planet Parent { get; set; }
        public int OrbitsTotals { get; set; }
    }
}
