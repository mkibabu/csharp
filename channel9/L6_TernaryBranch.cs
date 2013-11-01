using System;

namespace Ternary
{
    class Program
    {

        public static void Main (String[] args)
        {
            Console.WriteLine("Would you prefer door # 1 or # 2?");

            string door = Console.ReadLine();

            // string equality: use ==
            string message = (door == "1") ? "car!" : "television!";

            Console.WriteLine("You win a {0}!", message);
        }
    }
}
