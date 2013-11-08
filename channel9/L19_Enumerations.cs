using System;

// Example on enumerations.

namespace EnumerationsExample
{
    class Program
    {
        public static void Main (string[] args)
        {
            // ConsoleColor is an example of an enum
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Is this text red?");

            Console.WriteLine("Type a superhero to see their nickname");
            string value = Console.ReadLine();
            string message = " ";

            // Create the super hero.
            SuperHero theHero;
            // tuen the string input into a superhero
            if(Enum.TryParse<SuperHero>(value, true, out theHero))
            {
                switch(theHero)
                {
                    case SuperHero.Batman:
                        message = "Caped Crusader";
                        break;
                    case SuperHero.Superman:
                        message = "Man of Steel";
                        break;
                    case SuperHero.Catwoman:
                        message = "The Cat";
                        break;
                    case SuperHero.GreenLantern:
                          message = "Emerald Knight";
                          break;
                    default:
                          message = "No idea who that is....";
                          break;
                }
            }
            else
            {
                message = "That's definitely not a superhero!";
            }

            Console.WriteLine(message);


            Console.ReadLine();
        }
    }

    enum SuperHero
    {
        Batman,
        Superman,
        Catwoman,
        GreenLantern
    }

}
