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
            // think of StreamReader as a straw that sucks up one line at a time
            StreamReader sr = new StreamReader("l11_InputFile");
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
