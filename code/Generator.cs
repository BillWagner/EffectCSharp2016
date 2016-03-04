using System;
using System.Collections.Generic;
using static System.Math;

namespace EffectiveCSharpSamples.Generator
{
    public static class ArchimedesSpiral
    {
        public static IEnumerable<Point> GenerateSpiral(double branchDistance, int pointsPerRevolution)
        {
            if (pointsPerRevolution == 0)
                throw new ArgumentOutOfRangeException(nameof(pointsPerRevolution), 
                "points per revolution cannot be 0");
            if (pointsPerRevolution < 0)
                throw new ArgumentOutOfRangeException(nameof(pointsPerRevolution),
                "points per revolution cannot be negative");
            
            if (!(branchDistance > 0))
                throw new ArgumentOutOfRangeException(nameof(branchDistance),
                "branch distance must be positive");
            
            return GenerateSpiralImpl(branchDistance, pointsPerRevolution);
        }
        
        private static IEnumerable<Point> GenerateSpiralImpl(double branchDistance, int pointsPerRevolution)
        {
            var delta = PI * 2 / pointsPerRevolution;
            var archimedesConstant = branchDistance / (2 * PI);
            var theta = 0.0;

            while (theta < PI * 6)
            {
                var x = archimedesConstant * theta * Cos(theta);
                var y = archimedesConstant * theta * Sin(theta);
                theta += delta;
                yield return new Point(x, y);
            }
        }
    }
}