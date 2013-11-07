using System;
using System.Text;

namespace MoreClasses
{
    class Program
    {
        public static void Main (String[] args)
        {
            Car myCar = new Car();

            // Typically, the properties of the object would be set via some
            // // interface, and saved to a file or database
            myCar.Make = "Toyota";
            myCar.Model = "Camry";
            myCar.Color = "White";
            myCar.OriginalPrice = 35000;
            myCar.Year = 2007;

            // before calling doByValue
            myCar.PrintDetails();
            Console.WriteLine("Its value is {0:C}", getMarketValue(myCar));


            // call doByValue
            doByValue(myCar);
            // after calling doByValue
            myCar.PrintDetails();
            Console.WriteLine("Its value is {0:C}", getMarketValue(myCar));


            // call doByRef
            doByRef(ref myCar);
            // after calling doByValue
            myCar.PrintDetails();
            Console.WriteLine("Its value is {0:C}", getMarketValue(myCar));


        }


        // Here, car is passed by value. Changes made to it are NOT persistent

        private static double getMarketValue(Car car)
        {
            double carValue = ( ( (double)DateTime.Now.Year - (double)car.Year ) / 10) * car.OriginalPrice;

            return carValue;
        }

        // Here, again, car is passed by value, i.e. only a copy of the
        // reference is passed in.
        public static void doByValue(Car car)
        {
            car = new Car();
            car.Make = "BMW";
        }

        // Here, we pass the car by reference. Changes are persistent.
        private static void doByRef(ref Car car)
        {
            car = new Car();
            car.Make = "Audi";
        }
    }

    class Car
    {
        // Property = attribute of class
        public string Make { get; set;}

        public string Model { get; set; }

        public string Color { get; set; }

        public int OriginalPrice { get; set; }

        public int Year { get; set; }


        // Method: behaviour of class
        public void PrintDetails()
        {
            Console.WriteLine("My car is a {0} {1} {2} {3}", this.Year, this.Color, this.Make, this.Model);
        }



    }
}
