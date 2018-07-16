using System.Collections.Generic;

namespace Generics
{
	public class Cart<T> : Box<Box<T>> where T : ICountable
	{
		private List<Cart<Box<T>>> CartList;

		public Cart()
		{
			this.CartList = new List<Cart<Box<T>>>();
		}
		//public int Count
		//{
		//	get
		//	{
		//		int cartCount = 0;
		//		foreach(var box in CartList)
		//		{
		//			cartCount += box.Count;
		//		}
		//		return cartCount;
		//	}
		//}
	}
}
