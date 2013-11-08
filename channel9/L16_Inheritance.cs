using System;

// Inheritance examples

namespace Inheritance
{
    class Program
    {
        public static void Main (String[] args)
        {
            Car myCar = new Car();
            myCar.Make = "Toyota";
            myCar.Model = "Camry";
            myCar.Year = 2007;
            myCar.Color = "white";
            myCar.Doors = 4;

            myCar.PrintDetails();

            someMethod(myCar);

            Truck myTruck = new Truck();

            myTruck.Make = "Ford";
            myTruck.Model = "Ranger";
            myTruck.Year = 2000;
            myTruck.Color = "purple";
            myTruck.TowingCapacity = 12000;

            myTruck.PrintDetails();

            someMethod(myTruck);

            Console.ReadLine();
        }

        private static void someMethod(Vehicle veh)
        {
            Console.WriteLine("From someMethods, called by the {0} {1} {2}.", veh.Color, veh.Make, veh.Model);
        }
    }

    abstract class Vehicle
    {
        // Abstract classes can define properties
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }


        // The abstract keyword means that any class that inherits from this
        // class has to implement the methods defined here. Note that one
        // cannot define an object of an abstract class using new(), but a
        // method can take an abstract type as a parameter (see someMethod above)
        public abstract void PrintDetails();
    }

    // Class car inherits from Vehicle. If we don't want any other class to
    // inherit from Car, we mark it sealed. Analogous to final in Java.
    sealed class Car : Vehicle
    {
        // Add a property unique to cars
        public int Doors { get; set; }

        // Whether we're inheriting from a concrete class or from an abstract
        // class, the override keyword must be used
        public override void PrintDetails()
        {
            Console.WriteLine("This is a {0} {1}-door {2} {3} {4}.", this.Color, this.Doors, this.Year, this.Make, this.Model);
        }
    }

    // class Truck inherits from Vehicle
    class Truck : Vehicle
    {
        // Add a property unique to trucks
        public int TowingCapacity { get; set; }


        // Whether we're inheriting from a concrete class or from an abstract
        // class, the override keyword must be used
        public override void PrintDetails()
        {
            Console.WriteLine("This {0} {1} {2} {3} has a {4}-lb towing capscity.",
                    this.Color, this.Year, this.Make, this.Model, this.TowingCapacity);
        }


    }

}
