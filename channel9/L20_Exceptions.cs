using System;
using System.IO;

// Example on exception handling


namespace ExceptionHandling
{
    class Program
    {
        public static void Main (string[] args)
        {

            StreamReader sr = null;

            try
            {
                // give the reader an incorrect filename.
                sr = new StreamReader("/path/NoSuchFile.out");
                string line = "";

                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

                sr.Close();

            }
            // start with more specific exceptions and generalize further along
            catch (FileNotFoundException e)
            {
                Console.WriteLine("The specific file you were looking for could not be found");
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("The file's parent directory could not be found");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("We experienceed a problem. Sorry!");
                Console.WriteLine(e.Message);
            }
            // the finally block runs whether or not an exception is found.
            // Typically used for cleanup
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }

            Console.ReadLine();
        }
    }

}
