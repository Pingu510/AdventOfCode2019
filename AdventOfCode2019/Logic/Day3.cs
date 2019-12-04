using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Logic
{
    public static class Day3
    {
        struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public static Tuple<string, string> CrossTheStreams()
        {
            var massInputs = Helper.FileHandler.GetDoubleInput("input_03");
            
            var wire1Positions = PerformAllSteps(massInputs.Item1);
            var wire2Positions = PerformAllSteps(massInputs.Item2);

            string closest = CalculateClosestIntersection(wire1Positions.Intersect(wire2Positions).ToList());

            string closestStepIntersection = CalculateClosestIntersectionStep(wire1Positions, wire2Positions);

            return new Tuple<string, string>(closest, closestStepIntersection);
        }

        private static List<Point> PerformAllSteps(string[] inputs)
        {
            var wire = new Point();
            var wirePositions = new List<Point>();

            for (int i = 0; i < inputs.Length; i++)
            {
                var range = DoStep(wire, inputs[i]);
                wirePositions.AddRange(range);
                wire = wirePositions.Last();
            }
            return wirePositions;
        }

        private static List<Point> DoStep(Point position, string move)
        {
            List<Point> positions = new List<Point>();
            var steps = Int32.Parse(move.Substring(1));
            for (int i = 0; i < steps; i++)
            {
                switch (move[0])
                {
                    case 'U':
                        position.Y++;
                        break;
                    case 'D':
                        position.Y--;
                        break;
                    case 'R':
                        position.X++;
                        break;
                    case 'L':
                        position.X--;
                        break;
                }
                positions.Add(position);
            }
            return positions;
        }

        private static string CalculateClosestIntersection(List<Point> intersectingPoints)
        {
            int closest = int.MaxValue;

            foreach (Point position in intersectingPoints)
            {
                int distance = Math.Abs(position.X) + Math.Abs(position.Y);
                if (distance < closest) closest = distance;
            }
            return closest.ToString();
        }

        private static string CalculateClosestIntersectionStep(List<Point> wire1, List<Point> wire2)
        {
            var intersections = wire1.Intersect(wire2);
            var minSteps = Int32.MaxValue;
            foreach (var intersection in intersections)
            {
                int combinedSteps = wire1.IndexOf(intersection) + wire2.IndexOf(intersection);
                if (combinedSteps < minSteps) minSteps = combinedSteps;
            }
            minSteps += 2;
            return minSteps.ToString();
        }
    }
}
