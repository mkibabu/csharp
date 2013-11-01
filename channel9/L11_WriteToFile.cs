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
            string path = "l11Output";

            // delete the file if it exists
            if(File.Exists(path))
            {
                File.Delete(path);
            }

            // Example 1# Write an array to a new file
            string[] lines = {"These lines written using WriteAllLines(path, array)", "Second line", "Third line"};
            // WriteAllLines() creates a file, writes all the contents of a
            // collection to it, and closes the file.
            File.WriteAllLines(path, lines);

            // Example 2: Append to file using WriteAllLines
            string[] lines1 = {"These lines written using AppendAllLines(path, array)", "Appended line", "Other appended line"};
            File.AppendAllText(path, lines1);
        }
    }
}
