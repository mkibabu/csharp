using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// While classes are reference types, structs are value types. Reference types
// are used to represent objects, and usually hold a reference to that object.
// Value types, on the other hand, are akin to primitive types in Java, and
// hold the actual value itself rather than a pointer/reference to it. Thus
// copying a reference ttype only creates a copy of the reference (both will
// point to the same object), while copying a struct will create a separate
// instance of the value type.
// All built-in primitive types are structs.

namespace L25_Structs
{
    // structs cannot inherit from other classes or structs, but can implement
    // interfaces.

    interface IShape
    {
        // while the inclination is to set the setters as private (area and 
        // perimeter are computed values), accessibility modifiers cannot be
        // used on accessors within an interface. Therefore, let them be readonly
        // properties.

        double Perimeter { get;}
        double Area { get;}

        // structs can implement methods too
        IShape Add(IShape shape);
    }

    // create a simple struct
    struct Rectangle : IShape
    {
        public int Length { get; set; }
        public int Width { get; set; }
        
        // implement inherited interface properties
        public double Perimeter
        {
            get { return getPerimiter(); }
        }

        public double Area
        {
            get { return getArea(); }
        }

        // implement the interface Add method
        public IShape Add(IShape rect)
        {
            Console.WriteLine("Adding this triangle to our original one:");
            Console.WriteLine(rect.ToString());

            // "fluent interface" 
            return this = new Rectangle()
            {
                    Width = (this.Width + ((Rectangle)rect).Width), 
                    Length = (this.Length + ((Rectangle)rect).Length)
            };
        }

        public override string ToString()
        {
            return string.Format("{0} : {1} - Area: {2}, Perimeter: {3}", 
                this.Length, this.Width, this.Area, this.Perimeter);


        }
        
        // structs can have private methods as well
        private int getArea()
        {
            return Width * Length;
        }

        private int getPerimiter()
        {
            return  (2 * (Length + Width));
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle() { Length = 8, Width = 5 };

            Console.WriteLine(rect.ToString());
            
            rect.Add(new Rectangle()
            {
                Width = 3,
                Length = 15
            });

            Console.WriteLine(rect.ToString());
            
            
            Console.ReadLine();
        }
    }
}
