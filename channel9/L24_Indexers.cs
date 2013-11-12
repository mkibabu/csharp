using System;

// Indexers allow instances of a class or struct to be accessed much like an
// array. They much resemble properties, but their accessors take parameters.
// Thye allow one the indep[endence to manage their program internals as wished,
// yet maintain consistently indexer how they are accessed ny the outside world.

// INdexers can be used in interfaces, but like methos stubs, have no
// implementation, and no modifiers.

namespace L24_Indexers
{
    public interface ISomeInterface
    {
        // indexer declaration
        string this[int index]
        {
            get;
            set;
        }

        string this[string str]
        {
            get;
            set;
        }
    }

    public class IntIndexer : ISomeInterface
    {
        // Create a private array that end-users can't see
        private string[] data;

        private int size;

        // constructor; takes private array size as parameter
        public IntIndexer(int size)
        {
            this.size = size;
            data = new string[size];

            for (int i = 0; i < size; i++)
            {
                data[i] = "empty";
            }
        }

        // the indexer, as this[int index]. An indexer is implemented in the
        // the same way as a Property, but has a return type

        public string this[int index]
        {
            // Note that we could add any logic, including error-checking, into
            // the get and set portions of the indexer.
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }

        // the overloaded indexer, taking a string value.
        // Overloaded indexer, taking a string
        public string this[string contentString]
        {
            // returns the number of times contentString occurs in the array.
            get
            {
                int count = 0;
                for (int i = 0; i < size; i++)
                {
                    if (data[i] == contentString)
                        count++;
                }
                return count.ToString();
            }

            // replaces all occurences of contentString with the new value.
            set
            {
                for (int i = 0; i < size; i++)
                {
                    if (data[i] == contentString)
                    {
                        data[i] = value;
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            int size = 10;
            IntIndexer mint = new IntIndexer(size);

            // The inner data structure is an array, and at this point, the user
            // has no need to (and probably doesn't) know this; however, array-based
            // index access is easy, and the indexer allows controlled access to
            // the inner variables.
            mint[9] = "niner niner niner";
            mint[3] = "three little piggies";
            mint[5] = "five for fighting";

            // change all empty fields from "empty" to some other value
            string emptyHolder = "ha ha ha!";
            mint["empty"] = emptyHolder;

            Console.WriteLine("\nIndexer output:\n");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("mint[{0}]: {1}", i, mint[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Number of \"{0}\" entries: {1}", emptyHolder, mint[emptyHolder]);

            Console.ReadLine();
        }
    }
}