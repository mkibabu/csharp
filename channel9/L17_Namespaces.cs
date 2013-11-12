using System;
using System.IO;

// Namespaces help avoid name clashes, and do NOT correspond to physical program
// structure (unlike packages in Java). They thus separate the logical structure
// from the physical structure.

// include our custom library. Use the namespace, not the file (dll) name.
using MichaelDLL;
// One can use aliases as well, if they want to shorten long namespace names,
// e.g. the line below would be a shortcut for the ControlKeyState namespace, if
// we needed to use it.
// using shorterName = System.Console.ControlKeyState;

// compile as follows: csc /reference:libraryName.dll L17_Namespaces.cs

// All classes are organized into namespaces; think of them as surnames of
// the classes within. There's thousands of classes with similar names;
// namespaces make them unique.
// Default namespace is the name of the project. This can be changed.
// To avoid using qualified names, use the using statement, as above. Remove
// unused using statements to help reduce clutter.
namespace NameSpacesAndAssemblies
{

    class Program
    {
        public static void Main (String[] args)
        {
            // one way to use them is to declare their full qualified name.
            // System.IO.StreamReader sr = new System.IO.StreamReader();

            // alternatively, we can add using System.IO above, and use this:
            // StreamReader sr = new StreamReader();

            // sometimes, however, there may be conflicting using statements,
            // i.e. two namespaces might have the same class defined. In that
            // case, user the full qualified name.

            // Refer to the class within the custom namespace.
            Michael mDLL = new Michael();
            Console.WriteLine(mDLL.Lookup("http://www.learnvisualstudio.net"));

            Console.ReadLine();
        }
    }

    // Namespaces can be arranged in a hierachical manner, by having one namesspace
    // within another. Start with the more general namespace, and get more and
    // more specific as you go deeper.
    namespace MoreSpecificNameSpace
    {
        class ClassInNestedNameSpace
        {
            // class definition
        }
    }

}

// ONe can use the dot notation to refer to nested namespaces
namespace NameSpacesAndAssemblies.OtherNestedNameSpace
{
    class ClassInNestedNameSpaceToo
    {
        // class definitaion here
    }
}

