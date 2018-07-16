

using System;
using System.Collections.Generic;

namespace Generics
{

	public class Counter<T> where T : ICountable
	{
		public int Count { get; set; }
		//public int RedAppleCount { get; set; }
		public Func<T, bool>ShouldItBeCounted;

		public Counter(Func<T, bool> shouldItBeCounted)
		{
			ShouldItBeCounted = shouldItBeCounted;
		}

		public Counter() : this(color => true)
		{

		}
		//public delegate int isItRed(List<Apple> apple);

		public void Add(T item)
		{
			if (ShouldItBeCounted(item))
			{
				Count += item.Count;
			}
		}
		//public void AddRedApples(T item)
		//{
		//	RedAppleCount += item.Count;
		//}
	}
}