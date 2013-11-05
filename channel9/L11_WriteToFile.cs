using System;
using System.IO;

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
			string text = "This single line of text was written using WriteText(path, text)";
			// WriteAllText(path, text) creates the file and writes text to it.
			// If path exists, the file is overwritten.
			// Commented out to keep previous writes
			
			// File.WriteAllText(path, text);
			
			
			// Example 4: Write only some strings in an array to a file.
			// Twist; combine the two arrays above (line and line1). Then
			// iterate N/2 times (where N = length of new array)
			
			
			
			Console.WriteLine("Hit any key to quit.");
			Console.ReadLine();
        }
    }
}
