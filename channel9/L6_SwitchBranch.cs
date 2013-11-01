using System;

// Simple branch example executed using a switch statement

namespace Switch
{
    class Program
    {

        public static void Main (String[] args)
        {
            Console.WriteLine("Would you prefer door # 1, 2 or 3?");
            string door = Console.ReadLine();
            string message = "";

            // like Java 7 and JS, switch can evaluate strings
            switch (door)
            {
                case "1":
                    message = "You win a car!";
                    break;
                case "2":
                    message = "You win a television!";
                    break;
                case "3":
                    message = "You win a cat!";
                    break;
                default:
                    message = "Wrong choice: you lose!";
                    break;
            }

            Console.WriteLine(message);
        }
    }
}
