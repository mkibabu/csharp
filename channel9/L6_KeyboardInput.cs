using System;

// Simple keyboard input example

namespace KeyboardInput
{
    class Program
    {

        public static void Main (String[] args)
        {
            Console.WriteLine("Please enter a value: ");
            string userValue = Console.ReadLine();
            Console.WriteLine("You entered: " + userValue);
        }
    }
}
