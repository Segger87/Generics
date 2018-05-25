
using System;
using System.Collections.Generic;

namespace Generics
{

	class Counter<T> where T : ICountable
	{
		public int Count { get; set; }
		public int RedAppleCount { get; set; }

		public delegate int isItRed(List<Apple> apple);

		public void Add(T item)
		{
			
			Count += item.Count;
		}
		public void AddRedApples(T item)
		{
			RedAppleCount += item.Count;
		}
		
	}
}