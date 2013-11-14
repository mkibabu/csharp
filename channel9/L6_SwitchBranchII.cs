using System;

// Example on switch statements.

namespace SwitchStatements
{
    class Program
    {
        public static void Main (string[] args)
        {
            Console.WriteLine("Type a superhero's name to see his/her nickname!");
            string name = Console.ReadLine();
            string message = "";

            switch(name.Trim().ToLower())
            {
                case "batman":
                    message = "Caped Crusader";
                    break;
                case "superman":
                    message = "Man of Steel";
                    break;
                case "catwoman":
                    message = "The Cat";
                    break;
                case "green lantern":
                    message = "Emerald Knight";
                    break;
                default:
                    message = string.Format("Who? {0}? Are you sure that's a superhero?");
                    break;
            }

            Console.WriteLine(message);

            Console.ReadLine();

        }
    }

}
