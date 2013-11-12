using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Properties combine the protection of controlled access with the convenience
// of accessing a property like a field. With a property, Java-like setters and
// getters are unnecessary, though any accompanying logic and error-checking
// are still possible.

namespace L26_Properties
{
    public class Customer
    {
        // Properties may have a backing instance variable, if some logic is to be
        // performed with the variable.
        
        // private backing variable
        private string name;
        // public property controlling access to the private property
        public string Name
        {
            get 
            {
                return name;
            }

            set
            {
                if (value.Trim() == string.Empty)
                {
                    Console.WriteLine("Invalid name entry. Ensure the name value set properly");
                    Console.WriteLine("You entered: {0}", value);
                    Console.WriteLine("Current name remains {0}", name);
                }
                else
                {
                    name = value;
                }
            }
        }
        // Properties may also be read only or write only, by not implementing
        // either the set or get method, as desired. Alternatively, if the values
        // are to be accessed internally, make the non-publicly-desired accessor
        // private. In the example below, we want to implement a readonly property
        // without using a readonly backing variable.
        public int ID { get; private set; }

        // Also, since .NET 3.5, if no backing variable logic is needed, 
        // the variable itself can be left out. This is known as an
        // auto-implemented property. Creating, naming and maintaining the
        // backing property are left to the compiler.
        public string FavStore { get; set; }
        public double TotalPurchases { get; set; }


        // Constructor.
        // Within the class, even if a property has a backing variable, its best
        // to default to accessing fields via their properties rather than doing
        // it directly.
        public Customer(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }


        public override string ToString()
        {
            return string.Format("Name: {0}\nID: {1}\nFavorite store: {2}\nTotal purchases: {3:C}",
                this.Name, this.ID, this.FavStore, this.TotalPurchases);
        }

        public static void Main (string[] args)
        {
            // since ID is readonly, the line below won't work
            // Customer cus = new Customer() { Name = "Gus Ferrote", ID = 12345 };

            Customer cus = new Customer(12345, "Gus Ferrote");
            // set a property
            cus.FavStore = "Harris Teeter";
            cus.TotalPurchases = 50;
            Console.WriteLine(cus.ToString());

            // see how the name property works
            cus.Name = "";
            // int properties support arithmetic operations
            cus.TotalPurchases += 13.30;
            Console.WriteLine(cus.ToString());


            Console.ReadLine();
        } 
        
    }
}
