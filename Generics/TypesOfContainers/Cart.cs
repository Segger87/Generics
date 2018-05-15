using System.Collections.Generic;

namespace Generics
{
	class Cart<T> : ICountable
	{
		public List<Box<T>> _cart = new List<Box<T>>();
		public int Count
		{
			get
			{
				int _cartCount = 0;
				foreach(var box in _cart)
				{
					_cartCount += box.Count;
				}
				return _cartCount;
			}
		}
	}
}
