using System;
using System.Text;
using System.IO;

// Read from a file
// NOTE: In vs2012, select the text file, select the Properties window, and
// under Copy to Output Dirrectory", select "Copy if Newer"
namespace ReadTextFile
{
    class Program
    {
        public static void Main(string[] args)
        {
            // file name
            string path = "l11_InputFile";

            // exit if it doesn't exist
            if(! File.Exists(path))
            {
                Console.WriteLine("File {0} missing! Create it and write some text to it!", path);
                // equivalent to Java's System.Exit
                Environment.Exit(1);
            }
            // think of StreamReader as a straw that sucks up one line at a time
            StreamReader sr = new StreamReader(path);
            string line = "";

            // use shorthand read-from-file if statement. Remember, null != ""
            while( (line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }

            sr.Close();
        }
    }
}
