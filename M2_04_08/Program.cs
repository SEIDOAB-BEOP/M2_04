using System;

namespace BOOP_04_08
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

            // Good DRY Solution
            (long maxArea, long maxCirc, double maxDiag) = GetMaxACD(myRectangles);
            Console.WriteLine($"Max area: {maxArea}");
            Console.WriteLine($"Max circumference: {maxCirc}");
            Console.WriteLine($"Max diagonal: {maxDiag:F2}");

            Console.WriteLine();
            (long minArea, long minCirc, double minDiag) = GetMinACD(myRectangles);
            Console.WriteLine($"Min area: {minArea}");
            Console.WriteLine($"Min circumference: {minCirc}");
            Console.WriteLine($"Min diagonal: {minDiag:F2}");

        }

        // Good DRY Solution, where the maximum ACD are encapsulated in a method and can be reused in the code.
        private static (long maxArea, long maxCirc, double maxDiag) GetMaxACD(Rectangle[] myRectangles)
        {
            //Find largest Area, Cirumference, Diagonal
            long maxArea = long.MinValue;
            long maxCirc = long.MinValue;
            double maxDiag = double.MinValue;
            foreach (var r in myRectangles)
            {
                r.GetACD(out long area, out long circ, out double diag);
                if (area > maxArea)
                    maxArea = area;
                if (circ > maxCirc)
                    maxCirc = circ;
                if (diag > maxDiag)
                    maxDiag = diag;
            }
            return (maxArea, maxCirc, maxDiag);
        }
        private static (long minArea, long minCirc, double minDiag) GetMinACD(Rectangle[] myRectangles)
        {
            //Find largest Area, Cirumference, Diagonal
            long minArea = long.MaxValue;
            long minCirc = long.MaxValue;
            double minDiag = double.MaxValue;
            foreach (var r in myRectangles)
            {
                r.GetACD(out long area, out long circ, out double diag);
                if (area < minArea)
                    minArea = area;
                if (circ < minCirc)
                    minCirc = circ;
                if (diag < minDiag)
                    minDiag = diag;
            }
            return (minArea, minCirc, minDiag);
        }
    }

    //Excercise:
    // 1.   Write code to find the smallest area, circumference and diagonal according to DRY design pattern
    // 2.   Challange:
    //      In project DeckOfCards, write code according to DRY that finds a playingCard of specific Color and Value
    //      in cardDeck2. index in CardDeck2 should be identified.
    //      Hint: creating a static method in class Program that is called FindCard is a good approach.
    //      Parameters color, value and the deck of cards are passed into FindCard
}
