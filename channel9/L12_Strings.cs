using System; 
using System.Text;

// String manipulation
namespace StringExamples
{
	class Program
	{
		public static void Main(string[] args)
		{
			// Escape sequences
			// string str = "Go to your c:\\ drive";
			// string str = "My so called \"life\."";
			// string str = "What if I need \n a new line?";
			
			// string.Format
			// string str = string.Format("{0}", "Hi there!");
			// string str = string.Format("Make: {0} (Model: {1})", "BMW", "745li");
			
			// NUMERICAL FORMATTING: Note that the values to formart must be numbers, not strings
			
			// currency: use {arg:C} -> uses currency of operating system's language preference
			string str = string.Format("{0:C}", 123.45);
			Console.WriteLine(str);
			// human-friendly numbers: use {arg:N} -> shows numbers in a,bcd,efg.hi format
			str = string.Format("{0:N}", 123456789);
			Console.WriteLine(str);
			// display decimal value as percentage: use {arg:P}
			str = string.Format("{0:P}", 1.23);
			Console.WriteLine(str);
			// phone number format: use {arg: [pound signs]}, where ]pound signs] is a series of #
			// with each representing a single digit.
			str = string.Format("Phone number: {0:(###) ###-####}", 1234567890);
			Console.WriteLine(str);
			// the # sign is used to create custom formatting.
			str = string.Format("SS number: {0:###-##-####}", 123456789);
			Console.WriteLine(str);
			
			// String concatenation: can use + -> takes up memory. Use 
			// StringBuilder instead
			StringBuilder strB = new StringBuilder();
			for (int i = 1; i <= 100; i++)
			{
				strB.Append("--");
				
				if(i < 10)
					strB.Append(" ");
					
				strB.Append(i);
					
				if ( i % 10 == 0 ) 
					strB.Append("\n");
			}
			Console.WriteLine(strB);
			
			
			// String manipulation examples.
			str = "		It's better to be lucky than good.  ";
			// start at position 5, and select the next 12 characters
			Console.WriteLine(str.Substring(5, 12));
			// note that the string is preceded by 2 tabs. Always trim before
			// getting a substring. We combine two expressions here, because
			// I'm lazy.
			Console.WriteLine((str = str.Trim()).Substring(5, 12));
			// to upper case
			Console.WriteLine(str.ToUpper());
			// replace
			Console.WriteLine(str.Replace(" ", "_"));
			
			
			Console.ReadLine();
		}
	}
}