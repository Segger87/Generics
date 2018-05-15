using System;
using System.Collections.Generic;

namespace Generics
{
	class Program
	{
		static void Main(string[] args)
		{

			// Some things to count
			var someApples = new List<Apple> { new Apple(), new Apple(), new Apple() };
			var boxOfApples = new Box<Apple>();
			boxOfApples.items.Add(new Apple());
			boxOfApples.items.Add(new Apple());
			var cart = new Cart<Apple>();
			 cart._cart.Add(boxOfApples);
			// Some counters
			var appleCounter = new Counter<Apple>();
			someApples.ForEach(appleCounter.Add);
			Console.WriteLine(appleCounter.Count); // Should be 3
			var cartCounter = new Counter<Cart<Apple>>();
			cartCounter.Add(cart);
			Console.WriteLine(cartCounter.Count); // Should be 2 (number of apples in the cart in total)
			var anythingCounter = new Counter<ICountable>();
			someApples.ForEach(anythingCounter.Add);
			anythingCounter.Add(cart);
			Console.WriteLine(anythingCounter.Count); // Should be 5 - sum of the above
			

			// testing different types

			var bunchOfBananas = new List<Banana> { new Banana(), new Banana() };
			var boxOfBananas = new Box<Banana>();
			var bananaCounter = new Counter<Banana>();
			bunchOfBananas.ForEach(boxOfBananas.items.Add);
			bunchOfBananas.ForEach(bananaCounter.Add);

			Console.WriteLine(String.Format("There are {0} bunches of Bananas in the box ", boxOfBananas.items.Count));

			Console.WriteLine(String.Format("There are {0} individual Bananas in the box ", bananaCounter.Count));
			Console.ReadLine();
		}
	}
}
