using System;

// Example on scope and accessibility modifiers
namespace ScopeExample
{
    class Program
    {
        private static string k = "kkkk";

        public static void Main (string[] args)
        {

            string j = "jjjj";
            Console.WriteLine("Before loop, j and k: {0} {1}", j, k);

            for (int i = 0; i < 10; i++)
            {
                j = i.ToString();
                k = i.ToString();
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // the variable i is not visible here; line below throws an error
            // Console.WriteLine(i);

            // The variables j and k, however, are accessible.
            Console.WriteLine("Can still access j and k outside the for: {0} {1}", j, k);

            // k can also be accesed by other methods, since it has instance scope
            helperMethod();

            // Testing private methods
            TestScope ts = new TestScope();
            ts.DoSomething();


            Console.ReadLine();

        }

        private static void helperMethod()
        {
            Console.WriteLine("Calling the instance variable k from a helper method: {0}.", k);
        }

    }

    class TestScope
    {
        public void DoSomething()
        {
            Console.WriteLine("TestScope's public DoSomeThing() called");
            helperMethod();
        }

        private void helperMethod()
        {
            Console.WriteLine("Using helper method! Wheeee!!");
        }
    }

}
