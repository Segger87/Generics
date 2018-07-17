using System;
using System.Collections.Generic;

namespace Generics
{
	class Program
	{
		static void Main(string[] args)
		{
			var p = new Program();
			p.Execute();																				
		}

		private void Execute()
		{
			var differentColorApples = new List<Apple> { new Apple("Red"), new Apple("Green"), new Apple("Red"), new Apple("Green"), new Apple("Red") };
			var bunchesOfBananas = new List<Banana> { new Banana(), new Banana(), new Banana() };

			var delegateCounterRed = new Counter<Apple>(apple => apple.Color == "Red");
			differentColorApples.ForEach(delegateCounterRed.Add);
			var redResult = delegateCounterRed.PrintResult();
			Console.WriteLine(redResult);

			var delegatesCounterGreen = new Counter<Apple>(a => a.Color == "Green");
			differentColorApples.ForEach(delegatesCounterGreen.Add);
			var greenResult = delegatesCounterGreen.PrintResult();
			Console.WriteLine(greenResult);

			var delegatesCounterBanana = new Counter<Banana>();
			bunchesOfBananas.ForEach(delegatesCounterBanana.Add);
			var bananaResult = delegatesCounterBanana.PrintResult();
			Console.WriteLine(bananaResult);

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

			for (var i = 0; i < cart.boxes.Count; i++)
			{
				Console.WriteLine($"There are {cart.boxes[i].boxes.Count} apples in the box, inside the cart.");
			}		
		}
	}
}
