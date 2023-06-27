using System;

namespace BOOP_04_01
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

            //Instance Methods 
            //Normal syntax
            public long Width() { return Math.Abs(TopRight.X - BottomLeft.X); }

            // Expression bodied syntax
            public long Height() => Math.Abs(TopRight.Y - BottomLeft.Y);

            //string is returned that can be printed out.
            public string ToString (bool printArea = false)
            {
                string sRet = $"Rectangle:\nHeight: {Height(),10}\nWidth:  {Width(),10}";

                if (printArea)
                    sRet = sRet + $"\nArea:   {Width() * Height(),10}";

                return sRet;
            }

            //Static Methods
            public static long Area(long width, long height) => width * height;
            public static void GetACD(long width, long height,
                out long area, out long circumference, out double diagonal)
            {
                area = width * height;
                circumference = 2 * width + 2 * height;
                diagonal = Math.Sqrt(width * width + height + height);
            }

        }

        static void Main(string[] args)
        {
            Rectangle r1 = new Rectangle
            {
                BottomLeft = new Point { X = 0, Y = 0 },
                TopRight = new Point { X = 100, Y = 100 }
            };

            //Print the rectangle
            Console.WriteLine(r1.ToString());
            Console.WriteLine(r1.ToString(printArea:true));

            //Get the diagonal
            Rectangle.GetACD(150, 75, out _, out _, out double diagonal);
            Console.WriteLine($"{diagonal:F2}");  // 150.50
        }
    }
}
//Exercises:
//1.    Open your project DeckOfCards. 
//2.    In the type PlayingCard , declare a private method, FaceOrValue that has a return type string.
//      In the FaceOrValue write code using switch to return "Face" if the card is Ace, Knight, Queen, King.
//      Otherwise return Value. Switch  example you can find in BOOP_02_16
//3.    In the type PlayingCard , declare a private method, BlackOrRed that has a return type string.
//      "Black" should be returned if the Color is Spades or Clubs. Otherwise "Red"
//3.    In the type PlayingCard, write a public method PrintOut() that return a string that can be used to print out a variable of the type.
//      Try to use an expression bodied syntax. 
//      For example
//      - Ace of Spade should be printed: Ace of Spades, a Black Face card
//      - King of Heart should be printed: King of Hearts, a Red Face card
//      - Two of Club should be printed: Two of Clubs, a Black Value card
//4.    Use a foreach-loop to print out every card in the array cardDeck2 created in BOOP_03_10.6

