using System;
using System.Text;

// Enums are strongly-types constants; essentially, unique types that allow us
// to assign symbolic names to integral values. Being strongly types, all
// assignments from integral to enum types must be explicitly typecast.

// Whenever a program requires using a fixed set of numbers, consider using an
// enum for them. That way, rather than using the numbers 0, 1, 2, etc in a 
// switch statement, the code has more meaningful menum names instead. By
// default, the first enum member has the value 0, the next 1, etc. For instance:
// enum CoffeeSize { Small, Medium, Large };    // Small  = 0, Medium= 1, etc
// This value can be explicitly set, usually by changing the value of the first
// enum member tot he first value in the desired range. Note that enum values
// can be any integral type except char; the default just happens to be int:
// enum CoffeeSize : byte { Small = 1, Medium, Large }

namespace L19_MoreEnums
{
    // the enum,, representing various machine states
    public enum MachineState : byte
    {
        PowerOff = 0,
        Hibernate = 5,
        Sleep = 10,
        Run = Sleep + 5
    }

    class EnumEx
    {

        // explicit cast of int to enum
        public bool GetEnumFromUser()
        {
            Console.WriteLine("\n----------------------------------------------");
            Console.Write(@"
        0  - PowerOff
        5  - Hibernate
        10 - Sleep
        15 - Run
Please enter a desired machine state (0, 5, 10, 15)");
            Console.WriteLine();

            // parse user value
            string input = Console.ReadLine();
            byte value;
            if (Byte.TryParse(input, out value))
            {
                // turn the int into a MachineState, by casting. Find out if
                // this is meant to be an improvement on Enum.Tryparse<Enum>()
                MachineState ms;
                if (Enum.IsDefined(typeof(MachineState), value))
                {
                    ms = (MachineState)value;
                }
                else
                {
                    // you used a goto statement. All the java within weeps.
                    goto error;
                }
                switch (ms)
                {
                    case MachineState.PowerOff:
                        Console.WriteLine("Machine will now power off. Byebye!");
                        break;
                    case MachineState.Hibernate:
                        Console.WriteLine("Hibernate mode activated. Byebye!");
                        break;
                    case MachineState.Sleep:
                        Console.WriteLine("Sleep sleep sleepity snore!");
                        break;
                    case MachineState.Run:
                        Console.WriteLine("Work? Really? Why?!?");
                        break;
                    default:
                        // this can't ever be called, actually.
                        Console.WriteLine("No such state exists!");
                        break;
                }

                return true;
            }
            error:
            {
                Console.WriteLine("This machine does not have Super Cow powers.\nEnter a valid number, please!");
                return false;
            }

            Console.WriteLine();
        }

        // List enum members by name
        public void ListEnumMembersByName()
        {
            Console.WriteLine("\n--------------\nMachine States by name:");
            // Get all member names of the MachineState enum, and display their
            // numeric values.
            foreach (string state in Enum.GetNames(typeof(MachineState)))
            {
                Console.WriteLine("Machine State: {0} - Value: {1}",
                    state, (byte)Enum.Parse(typeof(MachineState), state));
            }
        }

        // List enum members by value
        public void ListEnumMembersByValue()
        {
            Console.WriteLine("\n--------------\nMachine States by value:");
            // Get all numeric values of the MachineState enum, figure out the
            // corresponding string name, and display.
            foreach (byte value in Enum.GetValues(typeof(MachineState)))
            {
                Console.WriteLine("Machine State Value: {0}: - Name: {1}",
                    value, Enum.GetName(typeof(MachineState), value));
            }

        }

        public static void Main(string[] args)
        {
            EnumEx ex = new EnumEx();

            // List the current enum states
            ex.ListEnumMembersByName();

            // List enum stattes by value
            ex.ListEnumMembersByValue();

            // ask user for a state. Have the system keep asking until a valid
            // value is entered.
            while (!ex.GetEnumFromUser()) ;

            Console.ReadLine();
        }
    }
}
