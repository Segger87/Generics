using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generics;
using System.Collections.Generic;

namespace Delegates.UnitTest
{
	[TestClass]
	public class DelegatesUnitTest
	{
		[TestMethod]
		public void CounterDelegateFunction_OnlyCountsColoredApples_IsTrue()
		{
			//Arrange
			var expected = 3;
			var differentColorApples = new List<Apple> { new Apple("Red"), new Apple("Green"), new Apple("Red"), new Apple("Green"), new Apple("Red") };
			var actual = new Counter<Apple>(apple => apple.Color == "Red");
			//Act
			foreach (var apple in differentColorApples)
			{
				actual.Add(apple);
			}
			//Assert
			Assert.IsTrue(actual.Count == expected);
		}

		[TestMethod]
		public void CartCount_CountsNumberOfGenericBoxesInTheCart_IsTrue()
		{
			//Arrange
			var expected = 1;
			var boxOfApples = new Box<Apple>();
			boxOfApples.boxes.Add(new Apple("Red"));
			boxOfApples.boxes.Add(new Apple("Green"));

			//Act
			var cart = new Cart<Apple>();
			cart.Add(boxOfApples);

			//Assert
			Assert.IsTrue(cart.boxes.Count == expected);
		}
		[TestMethod]
		public void CountTheNumberOfApples_InsideABoxWhichIsPlacedInACart_IsTrue()
		{
			//Arrange
			var expected = 3;
			var boxOfApples = new Box<Apple>();
			boxOfApples.boxes.Add(new Apple("Red"));
			boxOfApples.boxes.Add(new Apple("Green"));
			boxOfApples.boxes.Add(new Apple("Green"));

			//Act
			var cart = new Cart<Apple>();
			cart.Add(boxOfApples);

			//Assert
			Assert.IsTrue(cart.boxes[0].boxes.Count == expected);
		}

	}
}
