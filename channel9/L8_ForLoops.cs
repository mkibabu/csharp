using System;
using System.Text;

// For loop. Used when the number of iterations is defined, finite and known

namespace FotLoops
{
    class Program
    {
        public static void Main(string[] args)
        {
            // simple for loop.
            Console.WriteLine("Simple for loop: Print 1 to 10");
            for(int i = 1; i <= 10; i++)
            {
                Console.Write(i.ToString() + " ");
            }
            Console.WriteLine();


            // for loop with multiple initial statements
            Console.WriteLine("Multiple initial statements:  Print the previous values, doubled");
            for(int i = 1, j = 2; i <= 10; i++)
            {
                Console.Write((i * j) + " ");
            }
            Console.WriteLine();


            // for loop with multiple conditional statements
            Console.WriteLine("Multiple conditions: Print even numbers between 1 and 20, inclusive");
            for(int i = 1; i <= 20 && i % 2 == 0; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();


            // for loop with break
            Console.WriteLine("Break statement: Print only when the number 7 is found.");
            for(int i = 0; i < 10; i++)
            {
                if(i == 7)
                {
                    Console.WriteLine(i.ToString());
                    break;
                }
            }



            // for loop with continue
            Console.WriteLine("Continue: Print all values except 7.");
            for(int i = 0; i < 10; i++)
            {

                if(i == 7)
                {
                    // skip this iteration and move on to the next one
                    continue;
                }
                // all iterations will print this EXCEPT i == 7
                Console.Write(i.ToString() + " ");
            }
            Console.WriteLine();

        }
    }
}
