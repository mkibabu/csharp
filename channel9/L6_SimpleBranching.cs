using System;

namespace Branching
{
    class Program
    {

        public static void Main (String[] args)
        {
            Console.WriteLine("Would you prefer door # 1, 2 or 3?");
            string door = Console.ReadLine();
            string message = "";

            // string equality: use ==
            if (door == "1")
            {
                message = "You win a car!";
            }
            else if (door == "2")
            {
                message = "You win a television!";
            }
            else if (door =="3")
            {
                message = "You win a cat!";
            }
            else
            {
                message = "Wrong choice: you lose!";
            }

            Console.WriteLine(message);
        }
    }
}
