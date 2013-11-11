using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// LINQ uses SQL-like syntax in collections

namespace Collections_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // PART 1 OF A LINQ QUERY OPERATION:
            // OBTAIN THE DATA SOURCE

            // create a list of cars
            List<Car> carList = new List<Car>()
            {
                new Car {Make = "BMW", Model = "550i", Color = CarColor.Blue, StickerPrice = 55000, Year = 2009},
                new Car {Make = "BMW", Model = "Mille Maglia", Color = CarColor.Red, StickerPrice = 40000, Year = 1968},
                new Car {Make = "BMW", Model = "Typ110", Color = CarColor.White, StickerPrice = 33520, Year = 2010},
                new Car {Make = "BMW", Model = "E32", Color = CarColor.Black, StickerPrice = 18750, Year = 1999},
                new Car {Make = "Toyota", Model = "Camry", Color = CarColor.White, StickerPrice = 23700, Year = 2011},
                new Car {Make = "Nissan", Model = "Altima", Color = CarColor.Red, StickerPrice = 17500, Year = 2000},
                new Car {Make = "Honda", Model = "Accord", Color = CarColor.Black, StickerPrice = 30250, Year = 2013},
                new Car {Make = "Mercedes", Model = "Benz", Color = CarColor.White, StickerPrice = 45650, Year = 1993},
                new Car {Make = "Mitsubishi", Model = "Galant", Color = CarColor.Black, StickerPrice = 54650, Year = 2013},
                new Car {Make = "Honda", Model = "Accord", Color = CarColor.Black, StickerPrice = 7850, Year = 1992},
            };
            
            Console.WriteLine("Here are all the cars:");
            foreach (var car in carList)
            {
                Console.WriteLine(car.ToString());
            }
            Console.WriteLine();

            // PART 2 OF A LINQ QUERY OPERATION:
            // CREATE THE QUERY


            // The following three queries filter the number of rows, i.e. from
            // the whole collection , they return the whole of the rows that
            // match the query (think of the collection as a table, with each
            // row being an object and each column being a property of that
            // object.

            // linq query format:
            // from one_instance in a_larger_collection
            // where the_instance_has_some_property
            // [ && / || some_other_criteria_is_met]
            // select that_instance_and add_to_collection

            ///////////////////////////////////////////////
            // NOTE:
            // THE RETURNED VARIABLE IS SAVED USING THE var KEYWORD.
            // ALWAYS USE THIS!
            // QUERY MIGHT DYNAMICALLY CREATE ANONYMOUS TYPES (READ ON FOR A 
            // MORE IN-DEPTH EXPLANATION)
            ///////////////////////////////////////////////

            // write a linq statement to retrieve all BMWs
            var bmws = from car in carList
                       where car.Make == "BMW"
                       select car;

            Console.WriteLine("Here are all the BMWs:");
            foreach (var car in bmws)
            {
                Console.WriteLine(car.ToString());
            }
            Console.WriteLine();


            // select all pre-2005 white cars
            var whitePre05 = from thisCar in carList
                             where thisCar.Year < 2005
                             && thisCar.Color == CarColor.White
                             select thisCar;

            Console.WriteLine("Here are all white pre-2005 cars:");
            foreach (Car car in whitePre05)
            {
                Console.WriteLine(car.ToString());
            }
            Console.WriteLine();

            // The following query filters the number of columns, i.e. it
            // returns specific variables of the objects that match the
            // query. This is known as PROJECTION. Since only part of the matching
            // objects' variables are returned, the query can be thought of
            // as returning a new kind of object, i.e. an anonymous object.
            // THIS IS THE REASON WE USE THE var KEYWORD. Let the C# compiler
            // determine a type

            // if a query returns only specific data about a car, then the
            // collection returned is no longer a collection of cars but rather
            // a collection of a new kind of dynamically-created anonymous
            // object. For instance:
            // Return the make, year and model of all post-2009 cars
            var newCars = from car in carList
                          where car.Year > 2009
                          select new { car.Make, car.Model, car.Year };

            Console.WriteLine("Here are the make, model and year of all post-2009 cars:");
            foreach (var car in newCars)
            {
                Console.WriteLine("{0} {1} - {2}", car.Make, car.Model, car.Year);
            }
            Console.WriteLine();

            // sort
            var ascOrderedCars = from car in carList
                              orderby car.Year ascending
                              select car;

            Console.WriteLine("Here is a list of all cars, sorted by year, ASCENDING:");
            foreach (var car in ascOrderedCars)
            {
                Console.WriteLine(car.YearToString());
            }
            Console.WriteLine();
            
            
            var descOrderedCars = from car in carList
                              orderby car.Year descending
                              select car;

            Console.WriteLine("Here is a list of all cars, sorted by year, DESCENDING:");
            foreach (var car in descOrderedCars)
            {
                Console.WriteLine(car.YearToString());
            }
            Console.WriteLine(); 
            
            
            // sorted and grouped by make
            //var groupedCars = from car in carList
            //                  orderby car.Year
            //                  group by car.Make
            //                  select car;

            //Console.WriteLine("Here is a list of all cars, sorted by year, groupled by make:");
            //foreach (var car in groupedCars)
            //{
            //    Console.WriteLine(car.YearToString());
            //}
            //Console.WriteLine();

            // there exists a more method-based syntax for queries as well, i.e.
            // Select all BMWs from the year 2000

            var _bmws = carList.Where(car => car.Year == 2010).Where(car => car.Make == "BMW");
            Console.WriteLine("Here are all the 2010 BMWs, selected using the method syntax:");
            foreach (var car in _bmws)
            {
                Console.WriteLine(car.ToString());
            }
            Console.WriteLine();

            var _orderedCarsMeth = carList.Where(car => car.Year < 1995).OrderBy(p => p.Year);
            Console.WriteLine("Here are all the pre-1995 cars, ordered by year, selected using the method syntax:");
            foreach (var car in _orderedCarsMeth)
            {
                Console.WriteLine(car.ToString());
            }
            Console.WriteLine();            
            
            // Linq has a summation method as well, i.e.
            var hondaSum = carList.Where(car => car.Make == "Honda").Sum(p => p.StickerPrice);
            Console.WriteLine("Total honda inventory value: {0:C}", hondaSum);
            
            Console.ReadLine();

        }
    }

    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public CarColor Color { get; set; }
        public int StickerPrice { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return string.Format("This {0} {1} {2} {3} has an asking price of {4:C}",
                this.Color, this.Year, this.Make, this.Model, this.StickerPrice);
        }

        public string YearToString()
        {
            return string.Format("{0} - {1} {2} {3}, {4:C}",
                this.Year, this.Color, this.Make, this.Model, this.StickerPrice);
        }

        public Boolean isClassic()
        {
            return this.Year < 1985;
        }
    }

    enum CarColor
    {
        Blue,
        Red,
        White,
        Black
    };
}
