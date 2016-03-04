namespace  EffectiveCSharpSamples.Generator
{
    public class Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        double X { get; }
        double Y { get; }

        public override string ToString()
        {
            return $"{{ {X:F2}, {Y:F2} }}";
        }
    }
}