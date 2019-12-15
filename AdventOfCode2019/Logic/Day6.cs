using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Logic
{
    public static class Day6
    {
        public static (int,int) CalculateTravelPaths()
        {
            var planets = new List<Planet>();
            string[] orbits = Helper.FileHandler.GetPerRow("input_06");

            int totalOrbits = TotalOrbits(planets, orbits);
            int minTravelPath = CalculateMinDistanceToSanta(planets);

            return (totalOrbits, minTravelPath);
        }

        /// <summary>
        /// Calculate how many orbits there are in total
        /// </summary>
        /// <param name="planets"></param>
        /// <param name="orbits"></param>
        /// <returns></returns>
        private static int TotalOrbits(List<Planet> planets, string[] orbits)
        {
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
    
        private static int CalculateMinDistanceToSanta(List<Planet> planets)
        {
            var youParent = planets.FirstOrDefault(x => x.Name == "YOU").Parent;
            var sanParent = planets.FirstOrDefault(x => x.Name == "SAN").Parent;
            var roots = FindCommonRoots(youParent, sanParent);
            var minPath = FindSmallestRoot(roots, youParent, sanParent);
            return minPath;
        }

        private static List<Planet> FindCommonRoots(Planet youP, Planet sanP)
        {
            var youOrbits = FindAllOrbitsFor(youP);
            var sanOrbits = FindAllOrbitsFor(sanP);
            return youOrbits.Intersect(sanOrbits).ToList();
        }

        private static List<Planet> FindAllOrbitsFor(Planet planet)
        {
            var orbits = new List<Planet>();
            Planet orbit = planet;
            while (!orbit.IsRoot)
            {
                orbits.Add(orbit);
                orbit = orbit.Parent;
            }
            return orbits;
        }

        private static int FindSmallestRoot(List<Planet> roots, Planet youP, Planet sanP)
        {
            int minPath = Int32.MaxValue;
            foreach (var root in roots)
            {
                root.IsRoot = true;
                CountOrbits(youP);
                CountOrbits(sanP);
                if (minPath > (youP.OrbitsTotals + sanP.OrbitsTotals))
                {
                    minPath = youP.OrbitsTotals + sanP.OrbitsTotals;
                }
            }
            return minPath;
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
