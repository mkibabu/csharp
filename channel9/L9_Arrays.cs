using System;

// Arrays
namespace Arrays
{
	class Program
	{
		public static void Main()
		{
			// [] = index access operator
			
			// int[] numbers = new int[5];
			// numbers[0] = 4;
			// numbers[1] = 8;
			// numbers[2] = 15;
			// numbers[3] = 16;
			// numbers[4] = 23;
			
			int[] numbers = { 4, 8, 15, 16, 23 };
			
			// iterate over the array
			foreach(int s in numbers)
			{
				Console.Write(s + " ");
			}
			Console.WriteLine();
			
			string[] names = {"Bob", "Steve", "Mary", "Mike"};
			
			foreach(string s in names)
			{
				Console.Write(s + " ");
			}
			Console.WriteLine();
			
			
			// Array.Reverse method
			string text = "Act weird and let them wonder.";
			char[] charText = text.ToCharArray();
			// string.ToCharArray() turns each individual letter into an array
			Array.Reverse(charText);
			foreach(char s in charText)
			{
				Console.Write(s);
			}
			Console.WriteLine();
			
			Console.ReadLine();
		}
	}
}