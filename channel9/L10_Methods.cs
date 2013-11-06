using System;

// Methods and Overloading
namespace Methods
{
	class Program
	{
		private static string superSecretFormula()
		{
			return "Hello world!";
		}
		
		private static string superSecretFormula(string name)
		{
			return String.Format("Hello world, {0}!", name);
		}
		
		public static void Main(string[] args)
		{
			string myValue = superSecretFormula();
			Console.WriteLine(myValue);
			
			myValue = superSecretFormula("Bob");
			Console.WriteLine(myValue);
			
			Console.WriteLine(superSecretFormula("Steve"));
			
			
			
			Console.ReadLine();
		}
	}
}