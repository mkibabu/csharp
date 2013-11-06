using System;  

// String manipulation
namespace StringExamples
{
	class Program
	{
		public static void Main(string[] args)
		{
			// string str = "Go to your c:\\ drive";
			// string str = "My so called \"life\."";
			// string str = "What if I need \n a new line?";
			
			string str = string.Format("{0}", "Hi there!");
			Console.WriteLine(str);
			
			Console.ReadLine();
		}
	}
}