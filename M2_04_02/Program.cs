using System;

namespace BOOP_04_02
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

            public void GetACD (out long area, out long circumference, out double diagonal)
            {
                area = Width() * Height();
                circumference = 2 * Width() + 2 * Height();
                diagonal = Math.Sqrt(Width() * Width() + Height() + Height());
            }

            // Instance constructor
            public Rectangle(long x, long y, long width = 10, long height = 100)
            {
                BottomLeft = new Point { X = x, Y = y };
                TopRight = new Point { X = x + width, Y = y + height };

                NrRectInstances++;
            }
            public void Print(bool printACD = false)
            {
                Console.WriteLine();
                Console.WriteLine($"X:      {BottomLeft.X,10}");
                Console.WriteLine($"Y:      {BottomLeft.Y,10}");
                Console.WriteLine($"Height: {Height(),10}");
                Console.WriteLine($"Width:  {Width(),10}");

                if (printACD)
                {
                    GetACD(out long area, out long circumf, out double diag);
                    Console.WriteLine($"Area:            {area,10}");
                    Console.WriteLine($"Circumference:   {circumf,10}");
                    Console.WriteLine($"Diagonal:        {diag,10:F2}");
                }
            }
            
            //statics
            public static int NrRectInstances = 0;
        }

        static void Main(string[] args)
        {
            // create rectangle instance with defaults
            Rectangle r1 = new Rectangle(0,0);
            r1.Print(printACD: true);

            // create new rectangle with different width
            Rectangle r2 = new Rectangle(10, 10, width: 200);
            r2.Print();

            //get area only, discard out parameters circumference and diagonal
            r2.GetACD(out long area, out _, out _);
            Console.WriteLine($"\nr2 Area:   {area,10}");

            // See how static variable NrRectInstances has changed
            Console.WriteLine($"\nNr of rectangle instances: {Rectangle.NrRectInstances}");
        }
    }
}
//Exercises:
//1.    In above code add an instance contructor to the type Reactangle that takes 3 parameters of type long, x, y and side and initiates an instace to a square.
//      Create two instances of Rectangle using the two differnt constructors.
//2.    In your project DeckOfCards, in the type PlayingCard write an instance constructor to that takes two parameters (Color and Value) of types
//      PlayingCardColor and PlayingCardValue. Use the constructor to initialize the instance of PlayingCard with the Color and Value. 
