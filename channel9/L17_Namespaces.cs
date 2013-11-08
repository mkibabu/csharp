using System;
using System.IO;
// include our custom library. Use the namespace, not the file (dll) name.
using MichaelDLL;
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
}

