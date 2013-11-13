using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L27_MoreDelegates
{
    public delegate int Comparer(object obj1, object obj2);

    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int ID { get; set; }
        int Age { get; set; }

        bool Equals(object obj);
    }


    public class Student : IPerson
    {

        public string FirstName  { get; set; }
       
        public string LastName  { get; set; }
       
        public int ID { get; set; }

        public int Age { get; set; }

        public Classification Cls { get; set; }

        // Constructor.
        // Make the classification integer parameter optional, by using the
        // optional parameter declaration format, i.e:
        // type varName = defaultVal
        // Convention demands optional params be last in the list, unless the
        // method takes a variable number of arguments, in which case the 
        // params type[] argsList declaration is lst.
        public Student(string fName, string lName, int id, int age, int cls = 0)
        {
            FirstName = fName;
            LastName = lName;
            ID = id;
            Age = age;
            // attempt to convert the string classification into a Classification
            // enum member.
            Classification c;
            if(Enum.TryParse<Classification>(cls.ToString(), false, out c))
                Cls = c;
            else
                Cls = Classification.Unknown;
        }
        public bool Equals(object obj)
        {
            return
            (
                this.FirstName.Equals( ( (Student) obj ).FirstName ) &&
                this.LastName.Equals( ( (Student) obj ).LastName ) &&
                this.Cls.Equals( ( (Student) obj ).Cls ) &&
                this.ID.Equals( ( (Student) obj ).ID ) &&
                this.Age.Equals( ( (Student) obj).Age)
            );
        }

        public override string ToString()
        {
            return string.Format("Type: {0} - Name: {1} {2} - ID #: {3} - Age: {4} yrs - Classification: {5}",
                this.GetType().Name, this.FirstName, this.LastName, this.ID, this.Age, this.Cls);
        }

    }

    public class Employee : IPerson
    {

        public string FirstName  { get; set; }
       
        public string LastName  { get; set; }
       
        public int ID { get; set; }

        public int Age { get; set; }

        public Department Dept { get; set; }

        // Constructor.
        // Make the Department integer parameter optional, by using the
        // optional parameter declaration format, i.e:
        // type varName = defaultVal
        // Convention demands optional params be last in the list, unless the
        // method takes a variable number of arguments, in which case the 
        // params type[] argsList declaration is lst.
        public Employee (string fName, string lName, int id, int age, int dept = 0)
           
        {
            FirstName = fName;
            LastName = lName;
            ID = id;
            Age = age;
            // attempt to convert the int dept into a Department enum member.
            Department c;
            if(Enum.TryParse<Department>(dept.ToString(), false, out c))
                Dept = c;
            else
                Dept = Department.Unknown;
        }
        public bool Equals(object obj)
        {
            return
            (
                this.FirstName.Equals( ( (Employee) obj ).FirstName ) &&
                this.LastName.Equals( ( (Employee) obj ).LastName ) &&
                this.Dept.Equals( ( (Employee) obj ).Dept ) &&
                this.ID.Equals( ( (Employee) obj ).ID ) &&
                this.Age.Equals( ( (Employee) obj).Age)
            );
        }

        public override string ToString()
        {
            return string.Format("Type: {0} - Name: {1} {2} - ID #: {3} - Age: {4} yrs - Department: {5}",
                this.GetType().Name, this.FirstName, this.LastName, this.ID, this.Age, this.Dept);
        }

    }

    
    class Manipulator
    {
        IPerson[] persons;

        public Manipulator()
        {
            persons = new IPerson[]
            {
                new Student ("Ryan", "Finnegan", 6598, 19, 2),
                new Student ("Alicia", "Jones", 3501, 25, 3),
                new Student ("Felix", "Darby", 1563, 38, 1),
                new Student ("Michelle", "Brown", 5436, 33, 1),
                new Student ("Sam", "Shields", 9865, 21, 4),
                new Student ("Jane", "Blaylock", 3408, 21),
                new Employee ("Florence", "Welch", 6354, 56, 2),
                new Employee ("Janelle", "Monae", 1239, 45, 3),
                new Employee ("Freddie", "Mercury", 5684, 32, 1),
                new Employee ("Kimberly", "Hadley", 9820, 19, 0),
                new Employee ("Rod", "Stewart", 4013, 28, 4),
            };
        }
        public static int CompareFirstName(object obj1, object obj2)
        {
            return string.Compare(((IPerson)obj1).FirstName, ((IPerson)obj2).FirstName);
        }

        public static int CompareLastName(object obj1, object obj2)
        {
            return string.Compare(((IPerson)obj1).LastName, ((IPerson)obj2).LastName);
        }
        
        public static int CompareID(object obj1, object obj2)
        {
            return ( (IPerson)obj1).ID.CompareTo( ( (IPerson)obj2).ID );
        }

        public static int CompareAge(object obj1, object obj2)
        {
            return ( (IPerson)obj1).Age.CompareTo( ( (IPerson)obj2).Age );
        }


        // the sort method, that takes a delegate
        public void Sort(Comparer compare)
        {
            object temp;
            for (int i = 0; i < persons.Length; i++)
            {
                for (int j = i; j < persons.Length; j++)
                {
                    if (compare(persons[i], persons[j]) > 0)
                    {
                        temp = persons[i];
                        persons[i] = persons[j];
                        persons[j] = (IPerson)temp;
                    }
                }
            }
        }


        public void PrintDetails(string prompt)
        {
            Console.WriteLine("\n{0}:\n", prompt);
            foreach (IPerson person in persons)
            {
                Console.WriteLine(person.ToString());
            }
            Console.WriteLine("*****************************");
        }
        
        static void Main(string[] args)
        {
            Manipulator man = new Manipulator();

            // print out the people within the list
            man.PrintDetails("Here are the list's original contents");
           
 

            // Instantiate a delegate to sort by first name
            Comparer comp = new Comparer(Manipulator.CompareFirstName);
            man.Sort(comp);
            man.PrintDetails("List contents, sorted by first name");

            // CONSIDER DOING THE PARTS BELOW IN A LOOP. MIGHT INVOLVE SOME
            // SORT OF REFLECTION, MAYBE?

            // sort by last name
            comp = new Comparer(Manipulator.CompareLastName);
            man.Sort(comp);
            man.PrintDetails("List contents, sorted by last name");

            // sort by age
            comp = new Comparer(Manipulator.CompareAge);
            man.Sort(comp);
            man.PrintDetails("List contents, sorted by age");

            // sort by ID
            comp = new Comparer(Manipulator.CompareID);
            man.Sort(comp);
            man.PrintDetails("List contents, sorted by ID"); 

            Console.ReadLine();
        }
    }

    public enum Classification
    {
        Freshman = 1,
        Sophomore = 2,
        Junior = 3,
        Senior = 4,
        Unknown = 0
    }
    public enum Department
    {
        Engineering = 1,
        Marketing = 2,
        Janitorial = 3,
        Purchasing = 4,
        Unknown = 0
    }
}
