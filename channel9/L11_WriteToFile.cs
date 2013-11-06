using System;
using System.IO;
using System.Collections.Generic;

// Writing to a file. Example taken from MSDN site, to augment channel9 lesson
// on file IO

namespace  WriteToFile
{
    class Program
    {
        public static void Main(string[] args)
        {
            // get the file name
            string path = "l11Output.out";

            // delete the file if it exists
            if(File.Exists(path))
            {
                File.Delete(path);
            }

            // Example 1# Write an array to a new file
            string[] lines = {"These lines written using WriteAllLines(path, array)", "Second line", "Third line"};
            // WriteAllLines creates a file, writes all the contents of a
            // collection to it, and closes the file.
            File.WriteAllLines(path, lines);

            // Example 2: Append to file using AppendAllLines
            string[] lines1 = {"These lines written using AppendAllLines(path, array)", "Appended line", "Other appended line"};
			// AppendAllLines opens a file, writes all the contents of a
			// collection to it, and closes the file
            File.AppendAllLines(path, lines1);
			
			// Example 3: Write one string to a text file.
			// WriteAllText(path, text) creates the file and writes text to it.
			// If path exists, the file is overwritten.
			// Commented out to keep previous writes
			
			// string text = "This single line of text was written using WriteText(path, text)";
			// File.WriteAllText(path, text);
			
			
			// Example 4: Write only some strings in an array to a file.
			// Twist; combine the two arrays above by appending lines1 to the
			// end of lines. Then iterate N/2 times (where N = length of new
			// array) and in each iteration, pick a random value x in [0, N-1]
			// and append newArray[x] to the file.
			
			// lines1.CopyTo(lines, (lines.Length - 1) );
			// CopyTo won't work; uncaught exception (destination array not
			// long enough)
			
			// Workaround: create an empty list, add both arrays as ranges,
			// then call ToArray() on the list.
			
			///////////////////////////////////////////////////////////////////
			// var list = new List <string>();
			// list.AddRange(lines);
			// list.AddRange(lines1);
			// lines = list.ToArray();
			///////////////////////////////////////////////////////////////////
			
			// Note that the internal implementation calls Array.Copy. It'd be
			// faster to call this manually, rather than use AddRange() and
			// ToString(), i.e:
			
			string[] combined = new string[lines.Length + lines1.Length];
			// for the first Copy() call, since combined is empty, call
			// Array.Copy(source, destination, numElemsToCopy);
			Array.Copy(lines, combined, lines.Length);
			// for the second copy, since combined now has some contents, call
			// Array.Copy(source, sourceIndex, destination, destinationIndex, numElemsToCopy);
			Array.Copy(lines1, 0, combined, lines.Length, lines1.Length);
			
			// Confirm:			
			// foreach(string s in combined)
			// {
			// 	Console.WriteLine(s);
			// }
			
			// Alternative; use Buffer.BlockCopy(). Copies a specified number of 
			// bytes from a source array to a destination array, starting at a
			// particular offset. Has more opportunity for error, and is mostly
			// used where performance is an issue, since it appears to be at
			// least marginally fastewr than Array.Copy().
			
			// get a random number generator
			Random rand = new Random();
			// WriteLine(text) appends the text to the file. Note that
			// while the previous values were File class methods, WriteLine
			// is a StreamWriter instance method.
			// Constructor: new StreamWriter("path/to/file", boolean ? append : overwrite)
			
			// the using statement automatically closes the stream and calls
			// IDisposable.Dispose on the stream object
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
			{
				file.WriteLine("The lines below are randomly selected and written using WriteLine(text)");
				for(int ctr = 0, times = combined.Length/2; ctr <= times; ctr++)
				{
					// get a random number in [0, combined.Length - 1]
					int toPrint = rand.Next(combined.Length);
					// write the line at combined[toPrint]  to file.
					file.WriteLine(combined[toPrint]);
				}
			}
			
			Console.WriteLine("Hit any key to quit.");
			Console.ReadLine();
        }
    }
}
