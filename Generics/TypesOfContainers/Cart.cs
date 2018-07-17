using System.Collections.Generic;

namespace Generics
{
	public class Cart<T> : Box<Box<T>> where T : ICountable
	{
		private readonly List<Cart<Box<T>>> CartList;

		public Cart()
		{
			this.CartList = new List<Cart<Box<T>>>();
		}
	}
}
