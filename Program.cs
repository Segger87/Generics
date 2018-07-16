using System;
using System.Collections.Generic;

namespace Generics
{
	class Program
	{
		static void Main(string[] args)
		{

			// Some things to count
			var differentColorApples = new List<Apple> { new Apple("Red"), new Apple("Green"), new Apple("Red"), new Apple("Green"), new Apple("Red") };
			var boxOfApples = new Box<Apple>();
			boxOfApples.boxes.Add(new Apple("Red"));
			boxOfApples.boxes.Add(new Apple("Green"));
			var boxOfApples2 = new Box<Apple>();
			boxOfApples2.boxes.Add(new Apple("Red"));
			boxOfApples2.boxes.Add(new Apple("Green"));
			boxOfApples2.boxes.Add(new Apple("Green"));
			var cart = new Cart<Apple>();
			cart.Add(boxOfApples);
			cart.Add(boxOfApples2);
			//cart.CartList.Add(boxOfApples);

			for (var i = 0; i < cart.boxes.Count; i++)
			{
				Console.WriteLine($"There are {cart.boxes[i].boxes.Count} apples in the box, inside the cart.");		
			}

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
			//	Counter<Apple>.isItRed red = new Counter<Apple>.isItRed(Apple.CountRed);

			var genericsCounter = new Counter<Apple>(apple => apple.Color == "Red");

			foreach (var apple in differentColorApples)
			{
				genericsCounter.Add(apple);
			}
			//var howManyRed = red(differentColorApples);
			Console.WriteLine($"There are {genericsCounter.Count} Red Apples"); //should return 3

			var genericsCounterGreen = new Counter<Apple>(a => a.Color == "Green");

			foreach (var apple in differentColorApples)
			{
				genericsCounterGreen.Add(apple);
			}
			Console.WriteLine($"There are {genericsCounterGreen.Count} Green Apples "); //should return 3
																							   // testing different types

			var bunchOfBananas = new List<Banana> { new Banana(), new Banana() };
			var boxOfBananas = new Box<Banana>();
			var bananaCart = new Cart<Banana>();
			bananaCart.Add(boxOfBananas);
			var bananaCounter = new Counter<Banana>();
			bunchOfBananas.ForEach(boxOfBananas.boxes.Add);
			bunchOfBananas.ForEach(bananaCounter.Add);

			Console.WriteLine(String.Format("There are {0} boxes of Apples in the Cart ", cart.boxes.Count));
			Console.WriteLine(String.Format("There are {0} bunches of Bananas in the box ", boxOfBananas.boxes.Count));
			Console.WriteLine(String.Format("There are {0} individual Bananas in the box ", bananaCounter.Count));
			Console.WriteLine(String.Format("There are {0} Boxes of Bananas in the crate ", bananaCart.Count));
			Console.ReadLine();
		}
	}
}
