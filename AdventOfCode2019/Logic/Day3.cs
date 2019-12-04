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

        public static string CrossTheStreams()
        {
            var massInputs = Helper.FileHandler.GetDoubleInput("input_03");
            var wire1Positions = PerformAllSteps(massInputs.Item1);
            var wire2Positions = PerformAllSteps(massInputs.Item2);

            return CalculateClosestIntersection(wire1Positions.Intersect(wire2Positions).ToList());
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

        private static string CalculateClosestIntersection(List<Point> intersectingWire)
        {
            int closest = int.MaxValue;

            foreach (Point position in intersectingWire)
            {
                int distance = Math.Abs(position.X) + Math.Abs(position.Y);
                if (distance < closest) closest = distance;
            }
            return closest.ToString();
        }
    }
}
