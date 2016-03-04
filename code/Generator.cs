using System.Collections.Generic;
using static System.Math;

namespace EffectiveCSharpSamples.Generator
{
    public static class ArchimedesSpiral
    {
        public static IEnumerable<Point> GenerateSpiral(double branchDistance, int pointsPerRevolution)
        {
            var delta = PI * 2 / pointsPerRevolution;
            var archimedesConstant = branchDistance / (2 * PI);
            var theta = 0.0;

            var spiral = new List<Point>();
            while (theta < PI * 6)
            {
                var x = archimedesConstant * theta * Cos(theta);
                var y = archimedesConstant * theta * Sin(theta);
                theta += delta;
                spiral.Add( new Point(x, y));
            }
            return spiral;
        }
    }
}