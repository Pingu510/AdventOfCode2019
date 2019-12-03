using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Logic
{
    public static class Day3
    {
        public static string CrossTheStreams()
        {
            var massInputs = Helper.FileHandler.GetDoubleInput("input_03");

            var wire1 = new Point(0, 0);
            var wire2 = new Point(0, 0);

            var wire1Positions = new List<Point>();
            var wire2Positions = new List<Point>();

            for (int i = 0; i < massInputs.Item1.Length; i++)
            {
                wire1 = DoStep(wire1, massInputs.Item1[i]);
                wire1Positions.Add(wire1);

                wire2 = DoStep(wire2, massInputs.Item2[i]);
                wire2Positions.Add(wire2);
            }

            //wire1Positions = new List<Point>() { 
            //    new Point(1, 2), 
            //    new Point(2, 3),
            //    new Point(62, 1),
            //    new Point(-12,-13)
            //};

            //wire2Positions = new List<Point>() {
            //    new Point(0, 12),
            //    new Point(3, 3),
            //    new Point(62, 1),
            //    new Point(-11,-13)
            //};

            var x = wire1Positions.Intersect(wire2Positions).ToList(); ;

            return "";
        }

        private static Point DoStep(Point position, string move)
        {
            var steps = Int32.Parse(move.Substring(1));
            switch (move[0])
            {
                case 'U':
                    position.Y += steps;
                    break;
                case 'D':
                    position.Y -= steps;
                    break;
                case 'R':
                    position.X += steps;
                    break;
                case 'L':
                    position.X -= steps;
                    break;
            }
            return position;
        }
    }
}
