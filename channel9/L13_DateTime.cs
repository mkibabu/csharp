using System;

// DateTime examples

namespace DatesAndTimes
{
    class Program
    {
        public static void Main (string[] args)
        {
            // get system date and time, in mm/[d]d/yyyy hh:mm:ss {P|A}M
            DateTime dt = DateTime.Now;
            Console.WriteLine("Current date and time: {0}", dt.ToString());

            // Get parts of the date or time
            Console.WriteLine("Hour: {0}", dt.Hour);
            Console.WriteLine("Day of the month: {0}", dt.Day);
            Console.WriteLine("Day of the week: {0}", dt.DayOfWeek);
            Console.WriteLine("Time: {0}", dt.TimeOfDay);

            // DateTime math is possible too
            Console.WriteLine("Add 3 days to current date: {0}", dt.AddDays(3).ToShortDateString());
            Console.WriteLine("Add 6 hours to current time: {0}", dt.AddHours(6).ToShortTimeString());
            Console.WriteLine("Subtract 4.5 hours from current time: {0}", dt.AddHours(-4.5).ToShortTimeString());

            // Past date
            // DateTime birthDate = new DateTime(1984, 8, 15);  // works
            DateTime birthDate = DateTime.Parse("08/15/1984");

            // Time durations use a TimeSpan object
            TimeSpan age = DateTime.Now.Subtract(birthDate);
            Console.WriteLine("You are " + age.TotalDays + " days old");

            Console.ReadLine();
        }
    }
}
