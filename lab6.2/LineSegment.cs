using System;
namespace lab6._2
{
    internal class LineSegment
    {
        private double start;
        private double end;

        public LineSegment(double start2, double end2)
        {
            start = Math.Min(start2, end2);
            end = Math.Max(start2, end2);
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
