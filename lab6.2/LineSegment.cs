using System;
namespace lab6._2
{
    internal class LineSegment
    {
        private double start;
        private double end;

        public LineSegment(double x, double y)
        {
            start = Math.Min(x, y);
            end = Math.Max(x, y);
        }

        public bool IntoSegment(double number)
        {
            return number >= start && number <= end;
        }

        public override string ToString()
        {
            return $"LineSegment start: {start}, end: {end}";
        }
    }
}
