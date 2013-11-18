using System;
using L31_TraceFunctions;

//! compile with: /reference: L31_ConditionalMethodsDLL.dll [/d:DEBUG]

namespace L31_TraceClient
{
    public class TraceClient
    {
        public static void Main(string[] args)
        {
            Trace.Message("Main starting");

            if (args.Length == 0)
                Console.WriteLine("No arguments have been passed");
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                Console.WriteLine("Args[{0}] is {1}", i, args[i]);
                }
            }

            Trace.Message("Main ending");
        }
    }
}
