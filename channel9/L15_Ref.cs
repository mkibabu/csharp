using System;

// Examples of using reference on primitive types

namespace RefPrimitive
{
    class Program
    {
        public static void Main(string[] args)
        {
            int i = 0;
            Console.WriteLine("Initial: {0}", i);

            doByValue(i);
            Console.WriteLine("After doByValue: {0}:", i);

            doByReference(ref i);
            Console.WriteLine("After doByReference: {0}", i);

        }


        private static void doByValue(int j)
        {
            j += 1;
        }

        private static void doByReference(ref int k)
        {
            k += 1;
        }
    }
}
