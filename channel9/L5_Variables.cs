using System;
using System.Text;

namespace Variabes
{
    class Program
    {
        public static void Main(String [] args)
        {
            int x, y;
            x = 7;
            y = x + 3;
            Console.WriteLine(y);

            // C# has a JS-like var keyword, with implicit type and local scope.
            // Unlike JS's var, however, a variable's can't be changed to a value
            // of a different type

            var name = "FirstName LastName";
            Console.WriteLine("Implicit type of value with var is "
                + name.GetType() );

            // The + operator performs implicit type conversion when string
            // concatenation occurs, i.e.
            Console.WriteLine("Implicit type conversion of variable x: " +
                name + x);
            // Akin to having x.ToString() called before concatenation. Best
            // not to rely on this; always do explicit type conversion.

            // Example of explicit type conversion;
            string z = "45";
            int a = x + int.Parse(z);
            Console.WriteLine("Explicit type conversion, using int.Parse(): " + a);

        }
    }
}
