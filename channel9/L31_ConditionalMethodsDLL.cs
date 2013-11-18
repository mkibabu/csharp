using System;
using System.Diagnostics;

//! Compile with: /target:library /d:DEBUG

// Conditional methods allow developers to create methods whose calls are placed
// in code and either included or excluded during compilation based on a
// preprocessing symbol. For instance, assertion/debugging code can be included
// or excluded based on whther or not a preprocessing identifer is included. This
// identifier can be added using #define within the code, or by using the C#
// command line via the /define optoin (/d).

namespace L31_TraceFunctions
{
    // creates the conditional method
    public class Trace
    {
        // Mark the method as being conditional. The attribute takes the 
        // preprocessing identifier as a parameter. The identifier detgermines
        // whether the method call is included when clients are compiled.
        [Conditional("DEBUG")]
        public static void Message(string traceMessage)
        {
            Console.WriteLine("[TRACE] - " + traceMessage);
        }
    }
   
}
