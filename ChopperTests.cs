using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace KarateChopKataOne
{
	[TestFixture]
	public class ChopperTests
	{
		[Test]
		public void CanInstantiateTest()
		{
			Chopper c = new Chopper();

			Assert.That(c, Is.Not.Null);
		}

		[Test]
		public void EmptyListAlwaysReturnsNegativeOneTest()
		{
			List<int> emptyList = new List<int>();
			int numberToFind = 42;
			Chopper c = new Chopper();

			int returnedIndex = c.FindIndexOfTarget(numberToFind, emptyList);

			Assert.That(returnedIndex, Is.EqualTo(-1));
		}

		[Test]
		public void ListOfOneItemThatContainsInputReturnsIndexOfZeroTest()
		{
			List<int> oneItemList = new List<int> { 42 };
			int numberToFind = 42;
			Chopper c = new Chopper();

			int returnedIndex = 
				c.FindIndexOfTarget(numberToFind, oneItemList);

			Assert.That(returnedIndex, Is.EqualTo(0));
		}

		[Test]
		public void ListOfOneItemThatDoesNotContainInputReturnsNegOneTest()
		{
			List<int> oneItemList = new List<int> { 42 };
			int numberToFind = 41;
			Chopper c = new Chopper();

			int returnedIndex =
				c.FindIndexOfTarget(numberToFind, oneItemList);

			Assert.That(returnedIndex, Is.EqualTo(-1));
		}

		[Test]
		public void CanSplitEvenNumberedListInHalfTest()
		{
			List<int> evenNumberedList = new List<int> { 2, 4, 6, 8 };
			List<int> topHalf = null;
			List<int> bottomHalf = null;
			Chopper c = new Chopper();

			c.SplitListInHalf(
				evenNumberedList, 
				out topHalf, 
				out bottomHalf);

			Assert.That(topHalf, Is.Not.Null);
			Assert.That(topHalf.Count, Is.EqualTo(2));
			Assert.That(topHalf, 
				Is.EqualTo(new List<int> { 2, 4 }));
			Assert.That(bottomHalf, Is.Not.Null);
			Assert.That(bottomHalf.Count, Is.EqualTo(2));
			Assert.That(bottomHalf, 
				Is.EqualTo(new List<int> { 6, 8 }));
		}

		[Test]
		public void CanSplitOddNumberedListInHalfWithTopHavingOneFewerTest()
		{
			List<int> oddNumberedList = new List<int> { 2, 4, 6 };
			List<int> topHalf = null;
			List<int> bottomHalf = null;
			Chopper c = new Chopper();

			c.SplitListInHalf(
				oddNumberedList,
				out topHalf,
				out bottomHalf);

			Assert.That(topHalf, Is.Not.Null);
			Assert.That(topHalf.Count, Is.EqualTo(1));
			Assert.That(topHalf[0], Is.EqualTo(2));
			Assert.That(bottomHalf, Is.Not.Null);
			Assert.That(bottomHalf.Count, Is.EqualTo(2));
			Assert.That(bottomHalf, 
				Is.EqualTo(new List<int> { 4, 6 }));
		}
	}
}
