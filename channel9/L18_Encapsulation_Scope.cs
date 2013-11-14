using System;

// Let a type be a class/struct.interface, and a type member be a member 
// (method or variable) of a class, or a nested class.
// Type member access modifiers and what code can access the types.
// private - only members within the containing class or struct. Default for classes,
// so are only available within the same namespace (really? Yes. Tested).
// protected - within containing class/struct, and types derived from containing class
// public -  available anywhere, without restriction
// [NOTE: These first three are Java-like]
// [NOTE: An assembly is a collection of related code with one executable (Main) method,
// e.g. a single project. Note that a solution could have multiple projects]
// internal - within containing assembly and namespace. Default for class members.
// protected internal - available to containing assembly and derived classes.

// Given that a type = a class, interface, delegate, struct or enum, then types
// have only two access modifiers: public and internal. Default is internal (i.e.
// within assembly or namespace only).

// The example below only does scope; no accessibility example is included.

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
