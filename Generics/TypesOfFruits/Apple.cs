using System;
using System.Collections.Generic;

namespace Generics
{
	public class Apple : ICountable
	{
		public string Color { get; }
		public Apple(string color) => Color = color;

		//public static int CountRed(List<Apple> apple)
		//{
		//	Counter<Apple> app = new Counter<Apple>();

		//	foreach (var a in apple)
		//	{
		//		if (a.Color == "Red")
		//		{
		//			app.AddRedApples(a);
		//		}
		//	}
		//	return app.RedAppleCount;
		//}


		public int Count
		{
			get
			{
				return 1;
			}
		}
	}
}