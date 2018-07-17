using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generics;
using System.Collections.Generic;
using System;

namespace Delegates.UnitTest
{
	[TestClass]
	public class DelegatesUnitTest
	{
		[TestMethod]
		public void CounterDelegateFunction_OnlyCountsSpecifiedColoredApples_IsTrue()
		{
			//Arrange
			var expected = 3;
			var differentColorApples = new List<Apple> { new Apple("Red"), new Apple("Green"), new Apple("Red"), new Apple("Green"), new Apple("Red") };
			var counter = new Counter<Apple>(apple => apple.Color == "Red");

			//Act
			differentColorApples.ForEach(counter.Add);
			var actual = counter.Count;
			
			//Assert
			Assert.IsTrue(expected == actual);
		}

		[TestMethod]
		public void CartCount_CountsNumberOfGenericBoxesInTheCart_IsTrue()
		{
			//Arrange
			var expected = 2;
			var boxOfApples = new Box<Apple>();
			boxOfApples.boxes.Add(new Apple("Red"));
			boxOfApples.boxes.Add(new Apple("Green"));
			var secondBoxOfApples = new Box<Apple>();
			secondBoxOfApples.Add(new Apple("Green"));
			secondBoxOfApples.Add(new Apple("Green"));
			secondBoxOfApples.Add(new Apple("Green"));

			//Act
			var cart = new Cart<Apple>();
			cart.Add(boxOfApples);
			cart.Add(secondBoxOfApples);
			var actual = cart.boxes.Count;

			//Assert
			Assert.IsTrue(expected == actual);
		}
		[TestMethod]
		public void ExpectedCountOfApples_And_ActualCountOfApples_InsideABox_PlacedInACart_AreEqual()
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
			var actual = cart.boxes[0].boxes.Count;

			//Assert
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public void DefaultCounterConstructor_ReturnsACountOfApples_AreEqual()
		{
			//Arrange
			var expected = 5;
			var expectedBunchOfApples = new List<Apple> { new Apple("Red"), new Apple("Red"), new Apple("Green"), new Apple("Red"), new Apple("Green") };
			var counter = new Counter<Apple>();

			//Act
			expectedBunchOfApples.ForEach(counter.Add);
			var actual = counter.Count;

			//Assert
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public void DefaultCounterConstructor_ReturnsACountOfBanannas_AreEqual()
		{
			//Arrange
			var expected = 18; //Bananas are in bunches of 6
			var expectedBunchOfBananas = new List<Banana> { new Banana(), new Banana(), new Banana() };
			var counter = new Counter<Banana>();

			//Act
			expectedBunchOfBananas.ForEach(counter.Add);
			var actual = counter.Count;

			//Assert
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public void CounterOfTypeICountable_CanCountAnyTypeOfFruit_IsTrue()
		{
			//Arrange
			var expected = 17; 
			var counter = new Counter<ICountable>();
			var expectedBunchOfApples = new List<Apple> { new Apple("Red"), new Apple("Red"), new Apple("Green"), new Apple("Red"), new Apple("Green") };
			var expectedBunchOfBananas = new List<Banana> { new Banana(), new Banana() };

			//Act
			expectedBunchOfApples.ForEach(counter.Add);
			expectedBunchOfBananas.ForEach(counter.Add);
			var actual = counter.Count;

			//Assert
			Assert.IsTrue(expected == actual);
		}

		[TestMethod]

		public void AppleCountersPrintResultMethod_BananaCountersPrintResult_AreNotTheSame()
		{
			//Arrange
			var differentColorApples = new List<Apple> { new Apple("Red"), new Apple("Green"), new Apple("Red"), new Apple("Green"), new Apple("Red") };
			var bunchesOfBananas = new List<Banana> { new Banana(), new Banana(), new Banana() };

			var delegateCounterRed = new Counter<Apple>(a => a.Color == "Red");
			differentColorApples.ForEach(delegateCounterRed.Add);

			var delegatesCounterBanana = new Counter<Banana>();
			bunchesOfBananas.ForEach(delegatesCounterBanana.Add);
			
			//Act
			var apple = delegateCounterRed.PrintResult();
			var banana = delegatesCounterBanana.PrintResult();

			//Assert
			Assert.AreNotEqual(apple, banana);
		}

		[TestMethod]

		public void ExpectedString_MatchesTheAppleCounterPrintString_AreEqual()
		{
			//Arrange
			
			var differentColorApples = new List<Apple> { new Apple("Red"), new Apple("Green"), new Apple("Red"), new Apple("Green"), new Apple("Red") };
			var appleCounter = new Counter<Apple>();
			differentColorApples.ForEach(appleCounter.Add);

			var expected = $"There are {appleCounter.Count} apples";

			//Act
			var actual = appleCounter.PrintResult();

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
