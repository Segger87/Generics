using System;
using System.Collections.Generic;

namespace Generics
{
	class Program
	{
		static void Main(string[] args)
		{

			// Some things to count
			var differentColorApples = new List<Apple> { new Apple("Red"), new Apple("Green"), new Apple("Red") };
			var boxOfApples = new Box<Apple>();
			boxOfApples.items.Add(new Apple("Red"));
			boxOfApples.items.Add(new Apple("Green"));
			var cart = new Cart<Apple>();
			 cart._cart.Add(boxOfApples);
			// Some counters
			var appleCounter = new Counter<Apple>();
			differentColorApples.ForEach(appleCounter.Add);
			Console.WriteLine(appleCounter.Count); // Should be 3
			var cartCounter = new Counter<Cart<Apple>>();
			cartCounter.Add(cart);
			Console.WriteLine(cartCounter.Count); // Should be 2 (number of apples in the cart in total)
			var anythingCounter = new Counter<ICountable>();
			differentColorApples.ForEach(anythingCounter.Add);
			anythingCounter.Add(cart);
			Console.WriteLine(anythingCounter.Count); // Should be 5 - sum of the above


			//the IsItRed delegate points to the CountRed function, which determines if the apple color is red, and counts accordingly
			Counter<Apple>.isItRed red = new Counter<Apple>.isItRed(Apple.CountRed);
			var howManyRed = red(differentColorApples);
			Console.WriteLine($"There are {howManyRed} Red Apples"); //should return 2

			// testing different types

			var bunchOfBananas = new List<Banana> { new Banana(), new Banana() };
			var boxOfBananas = new Box<Banana>();
			var bananaCart = new Cart<Banana>();
			bananaCart._cart.Add(boxOfBananas);
			var bananaCounter = new Counter<Banana>();
			bunchOfBananas.ForEach(boxOfBananas.items.Add);
			bunchOfBananas.ForEach(bananaCounter.Add);

			
			
			

			Console.WriteLine(String.Format("There are {0} bunches of Bananas in the box ", boxOfBananas.items.Count));

			Console.WriteLine(String.Format("There are {0} individual Bananas in the box ", bananaCounter.Count));

			Console.WriteLine(String.Format("There are {0} Boxes of Bananas in the crate ", bananaCart.Count));
			Console.ReadLine();
		}
	}
}
