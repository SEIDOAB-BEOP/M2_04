using System;

namespace BOOP_04_06
{
    class Program
    {
        public struct Point
        {
            public long X, Y;
        }
        public struct Rectangle
        {
            public Point BottomLeft, TopRight;

            public long Width() { return Math.Abs(TopRight.X - BottomLeft.X); }
            public long Height() => Math.Abs(TopRight.Y - BottomLeft.Y);
            public void GetACD(out long area, out long circumference, out double diagonal)
            {
                area = Width() * Height();
                circumference = 2 * Width() + 2 * Height();
                diagonal = Math.Sqrt(Width() * Width() + Height() + Height());
            }
            public (long, long, double) GetACD()
            {
                long area = Width() * Height();
                long circumference = 2 * Width() + 2 * Height();
                double diagonal = Math.Sqrt(Width() * Width() + Height() + Height());

                return (area, circumference, diagonal);
            }
        }
        static void Main(string[] args)
        {
            //Create an array of Rectangles
            Rectangle[] myRectangles = {
                new Rectangle { BottomLeft = new Point { X = 0, Y = 0}, TopRight = new Point { X = 100, Y = 100}},
                new Rectangle { BottomLeft = new Point { X = 5, Y = 15}, TopRight = new Point { X = 150, Y = 50}},
                new Rectangle { BottomLeft = new Point { X = 5, Y = 0}, TopRight = new Point { X = 75, Y = 200}},
                new Rectangle { BottomLeft = new Point { X = 45, Y = 5}, TopRight = new Point { X = 5, Y = 15}}
            };

            // Non DRY Solution
            //Find largest Area
            long maxArea = long.MinValue;
            foreach (var r in myRectangles)
            {
                r.GetACD(out long area, out long _, out _);
                if (area > maxArea)
                    maxArea = area;
            }
            Console.WriteLine($"Max area: {maxArea}");

            //Find largest Circumference
            long maxCirc = long.MinValue;
            foreach (var r in myRectangles)
            {
                r.GetACD(out long _, out long circ, out _);
                if (circ > maxCirc)
                    maxCirc = circ;
            }
            Console.WriteLine($"Max circumference: {maxCirc}");

            //Find largest Diagonal
            double maxDiag = double.MinValue;
            foreach (var r in myRectangles)
            {
                r.GetACD(out long _, out long _, out double diag);
                if (diag > maxDiag)
                    maxDiag = diag;
            }
            Console.WriteLine($"Max circumference: {maxDiag:F2}");
        }
    }
}
