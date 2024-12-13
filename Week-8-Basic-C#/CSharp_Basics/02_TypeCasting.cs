using System;

namespace CSharp_Basic
{
	public class TypeCasting
	{
		public static void TypeCastingMethod()
		{

			// explicit type casting
			double var = 65.4F;
			int intVar = Convert.ToInt32(var);
			char charVar = Convert.ToChar(intVar);

			Console.WriteLine(var + " " + intVar + " " + charVar);

			// implicit type promotion
			double b = intVar;
			Console.WriteLine("Sum is : " + (intVar + b));

		}
	}
}
