using System;
using System.Text;

namespace SimpleClass
{
    class Program
    {
        public static void Main (String[] args)
        {
            Car myCar = new Car();

            // Typically, the properties of the object would be set via some
            // // interface, and saved to a file or database
            myCar.Make = "Oldsmobile";
            myCar.Model = "Cutlass Supreme";
            myCar.Color = "Silver";
            myCar.Year = 1986;

            myCar.PrintDetails();
            Console.WriteLine("Its value is {0:C}", GetMarketValue(myCar));

        }

        private static double GetMarketValue(Car car)
        {
            if(car.Year < 1990)
                return 100.00;
            else
                return 150.00;
        }
    }

    class Car
    {
        // Property = attribute of class
        public string Make { get; set;}

        public string Model { get; set; }

        public string Color { get; set; }

        public int Year { get; set; }


        // Method: behaviour of class
        public void PrintDetails()
        {
            Console.WriteLine("My car is a {0} {1} {2} {3}", this.Year, this.Color, this.Make, this.Model);
        }



    }
}
