using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// SUMMARY:
// Class: Allows you to build a reference-type object containing members and
// attributes.
// Struct: Allows you to design value-type objects. Other than not allowing
// class-type inheritance (can implement interfaces only), are declared like
// classes, with struct keyword,
// Interface: Allows you to declare a set of attributes and behaviour that all
// objects implementing them would publicly expose.

// Delegates: Reference-type acting as a handle to a method. Basically, a
// function pointer, common in c/c++. Reasons for it include having maximum
// functgionality at runtime.
namespace L27_DelegatesAndEvents
{

    // declare the delegate.
    public delegate int Comparer (object obj1, object obj2);
    // the delegate is declared to match the method it is meant to refer to,
    // i.e. the delegate handler method that the delegate refers to must take 
    // two parameters and return an int. When you instantiate a delegate, you
    // can associate it with any method that has a compatible signature.

    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Name(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }

        // this is the delagate method handler
        public static int CompareFirstNames(object name1, object name2)
        {
            string n1 = ((Name)name1).FirstName;
            string n2 = ((Name)name1).LastName;

            return string.Compare(n1, n2);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }

    }

    public class SimpleDelegate
    {
        Name[] names;

        public SimpleDelegate()
        {
            names = new Name[]
            {
                new Name("Joe", "Mayo"),
                new Name("John", "Hancock"),
                new Name("Mary", "Poppins"),
                new Name("Jack", "Carter"),
                new Name("Frodo", "Baggins"),
            };
        }

        public void PrintNames()
        {
            Console.WriteLine("Names: \n");

            foreach (Name name in names)
            {
                Console.WriteLine(name.ToString());
            }
        }

        // Observe the delegate parameter
        public void Sort(Comparer compare)
        {
            object temp;
            for (int i = 0; i < names.Length; i++)
            {
                for (int j = i; j < names.Length; j++)
                {
                    // use delegate "compare" just like a normal method, in place
                // of CompareFirstNames. Note that, if we wished, we could  
                    // use it in place of any other comparison method.
                    if (compare(names[i], names[j]) > 0)
                    {
                        temp = names[i];
                        names[i] = names[j];
                        names[j] = (Name)temp;
                    }
                }
            }
        }


        public static void Main (string[] args)
        {
            SimpleDelegate sd = new SimpleDelegate();

            // this is the delegate instantiation. A delegate is created in much
            // the same way as a class (with new) and with the delegate handler
            // method as a parameter.
            Comparer comp = new Comparer(Name.CompareFirstNames);
            Console.WriteLine("\nBefore sort:\n");
            sd.PrintNames();

            // observe the delegate argument.
            sd.Sort(comp);
            // Using the delegate allow sus to pass any method to the Sort 
            // procedure. For isntance, we could easily create a CompareLastNames
            // method in class Names, instantiate a new delegate here (like we
            // did above), and pass that delegate to the Sort class.

            Console.WriteLine("\nAfter sort:\n");
            sd.PrintNames();


            Console.ReadLine();
        }
    }
}
