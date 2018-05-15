using System.Collections.Generic;

namespace Generics
{
	class Box<T> : ICountable
	{
		public List<T> items = new List<T>();

		public int Count
		{
			get
			{
				return items.Count;
			}
		}
	}
}
