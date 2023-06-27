using System;

namespace BOOP_04_05
{
    class Program
    {
        public class CorrectlyNamedClass
        {
            public int PublicField;
            private int _privateField;

            public int PublicOrPrivateProperty { get; set; }
   
            public void PublicOrPrivateMethod(int methodParameters)
            {
                int localVariables = methodParameters;
            }

            private static int s_privateStaticField;
            public static int PublicStaticField;

            public static int PublicOrPrivateStaticProperty { get; set; }

            public static void PublicOrPrivateStaticMethod(int methodParameters)
            {
                int localVariables = methodParameters;
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
