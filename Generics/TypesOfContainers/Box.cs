using System.Collections.Generic;

namespace Generics
{
	public class Box<T>: ICountable where T :  ICountable
	{
		public List<T> boxes = new List<T>();

		public void Add(T item)
		{
			boxes.Add(item);
		}
		public int Count
		{
			get
			{
				return boxes.Count;
			}
		}
	}
}
