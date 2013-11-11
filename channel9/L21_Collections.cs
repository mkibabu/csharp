using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;

// Using collections; adv. over arrays = adaptable size, adaptable logic, 

namespace L21_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car();
            car1.Make = "Oldsmobile";
            car1.Model = "Cutlas Supreme";

            Car car2 = new Car();
            car2.Make = "Geo";
            car2.Model = "Prism";

            Book book1 = new Book();
            book1.Author = "Mark Twain";
            book1.Title = "Huckleberry Finn";
            book1.ISBN = "0-000-00000-0";

            /* OLD COLLECTIONS FRAMEWORKS, SANS COLLECTIONS */

            // ArrayList properties (compared to Java)
            // not synced (same)
            // dynamically grows in size (same),
            // but can be explicitly curtailed via Capacity property (has Capacity variable)
            // maintains insertion order (same)
            // can access items by index (same)
            ArrayList bcList = new ArrayList();
            bcList.Add(car1);
            bcList.Add(car2);
            bcList.Add(book1);

            // They store everything as an object, however (unless parameterized)
            foreach (object obj in bcList)
            {
                if(obj is Car)
                    Console.WriteLine (((Car)obj).Make);
                else
                    Console.WriteLine(((Book)obj).Title);
            }

            // ListDictionary: appears to be HashMap-like, taking
            // key-value pairs and storing things as objects
            ListDictionary bcListD = new ListDictionary();

            bcListD.Add(car1.Make, car1);
            bcListD.Add(car2.Make, car2);
            bcListD.Add(book1.Author, book1);

            // can access objeccts by key
            Console.WriteLine(((Car)bcListD["Geo"]).Model);

            // but sine it doesn't use generics os strong typing, we can easily
            // break it by casting the objects as something else. For instance,
            // the line below throws an InvalidCastException
            // Console.WriteLine(((Car)bcListD["Mark Twain"]).Model);
            

            /* NEW COLLECTIONS, WITH SUPPORT FOR GENERICS */
            // Found in System.Colelctions.Generic, automagically added to "using"
            // portion above


            // List is akin to ArrayList
            List<Car> genCars = new List<Car>();
            genCars.Add(car1);
            genCars.Add(car2);
            // this throws an error
            // genCars.Add(book1);
            
            // no casting is required
            foreach (Car car in genCars)
            {
                Console.WriteLine(car.Make);
            }

            // Dictionary is akin to HashMap
            Dictionary<String, Car> carDict = new Dictionary<string, Car>();
            carDict.Add(car1.Make, car1);
            carDict.Add(car2.Make, car2);

            // no casting needed
            Console.WriteLine(carDict["Geo"].Model);


            // initializing an array can be done as follows:
            int[] arrint = { 1, 2, 3, 4 };

            // this is known as an object initializer. Thinking of objects as merely
            // a collection of key-value pairs of properties and their corresponding
            // values, we can use the same syntax with objects, i.e.
            Car car3 = new Car() { Make = "Toyota", Model = "Camry" };
            Car car4 = new Car() { Make = "Nissan", Model = "Altima" };
            Car car5 = new Car() { Make = "Nissan", Model = "Sentra" };

            // Collection initializers are the equivalent code for collections.
            List<Car> carList = new List<Car>()
            {
                new Car() {Make = "BMW", Model = "745-i"},  // notice the commas at the end
                new Car() {Make = "Honda", Model = "Accord"},
                new Car() {Make = "Audi", Model = "A1"} // except for the last entry
            };

            // check if the dictionary allows duplicate keys with different values.
            // Both car4 and car5 are Nissans.
            carDict.Add(car4.Make, car4);
            // carDict.Add(car5.Make, car5);
            // Nope. ArgumentException thrown, since item with same key is already present

            // To iterate through a Dictionary, use the KeyValuePair object;
            // alternatively, use var, if you hate programmers
            foreach (KeyValuePair <string, Car> item in carDict)
            {
                Console.WriteLine(item);
            }

            // check if lists allow duplicate entries.
            carList.Add(new Car() { Make = "Honda", Model = "Accord" });

            foreach (Car car in carList)
            {
                Console.WriteLine(car);
            }

            Console.ReadLine();
        }
    }

    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }

        public override string ToString()
        {
            return string.Format("Make: {0} Model: {1}", this.Make, this.Model);
        }
    }

    class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }

        public override string ToString()
        {
            return string.Format("Title: {0} Author: {1}", this.Title, this.Author);
        }
    }
}
