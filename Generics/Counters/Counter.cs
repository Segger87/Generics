

using System;

namespace Generics
{
	public class Counter<T> where T : ICountable
	{
		public int Count { get; set; }
		public Func<T, bool> ShouldItBeCounted;

		public Counter(Func<T, bool> shouldItBeCounted)
		{
			ShouldItBeCounted = shouldItBeCounted;
		}

		public Counter() : this(color => true)
		{

		}

		public void Add(T item)
		{
			if (ShouldItBeCounted(item))
			{
				Count += item.Count;
			}
		}

		public string PrintResult()
		{
			if (this is Counter<Apple>)
			{
				return $"There are {Count} apples";
			}
			if (this is Counter<Banana>)
			{
				return $"There are {Count} Bananas";
			}
			return "";
		}
	}
}