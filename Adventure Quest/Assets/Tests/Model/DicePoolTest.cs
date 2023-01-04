using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System;

namespace AdventureQuest.Dice
{

	public class DicePoolTest
	{

		[Test, Timeout(5000), Description("Tests that the Constructor doesn't allow a null array.")]
		public void ConstructorFailsOnNullArray()
		{
			Assert.Throws<System.ArgumentNullException>(() => new DicePool(null));
		}

		[Test, Timeout(5000), Description("Tests that the Constructor doesn't allow an empty array.")]
		public void ConstructorFailsOnEmptyArray()
		{
			DiceGroup[] emptyArray = { };
			Assert.Throws<System.ArgumentException>(() => new DicePool(emptyArray));
		}

		[Test, Timeout(5000), Description("Tests that the Constructor doesn't allow any null DiceGroups.")]
		public void ConstructorFailsOnNullDiceGroup()
		{
			DiceGroup[] arrayWithNull = { new DiceGroup(3, 6), null, new DiceGroup(2, 4) };
			Assert.Throws<System.NullReferenceException>(() => new DicePool(arrayWithNull));

			DiceGroup[] arrayWithNull2 = { new DiceGroup(3, 6), new DiceGroup(2, 4), new DiceGroup(1, 20), null };
			Assert.Throws<System.NullReferenceException>(() => new DicePool(arrayWithNull2));

			DiceGroup[] arrayWithNull3 = { null, new DiceGroup(2, 4) };
			Assert.Throws<System.NullReferenceException>(() => new DicePool(arrayWithNull3));
		}

		[Test, Timeout(5000), Description("Tests the Min and Max properties")]
		public void TestMinMax()
		{

			DicePool pool1d20 = new(new DiceGroup[] { new DiceGroup(1, 20) });
			Assert.AreEqual(1, pool1d20.Min);
			Assert.AreEqual(20, pool1d20.Max);

			DicePool pool2d41d6 = new(new DiceGroup[] { new DiceGroup(2, 4), new DiceGroup(1, 6) });
			Assert.AreEqual(3, pool2d41d6.Min);
			Assert.AreEqual(14, pool2d41d6.Max);

			DicePool pool1d61d41d8 = new(new DiceGroup[] { new DiceGroup(1, 6), new DiceGroup(2, 4), new DiceGroup(1, 8) });
			Assert.AreEqual(4, pool1d61d41d8.Min);
			Assert.AreEqual(22, pool1d61d41d8.Max);
		}

		[Test, Timeout(5000), Description("Tests the DiceFormat property")]
		public void TestDiceFormat()
		{
			DicePool pool1d20 = new(new DiceGroup[] { new DiceGroup(1, 20) });
			Assert.AreEqual("1d20", pool1d20.DiceFormat);

			DicePool pool2d41d6 = new(new DiceGroup[] { new DiceGroup(2, 4), new DiceGroup(1, 6) });
			Assert.AreEqual("2d4 + 1d6", pool2d41d6.DiceFormat);

			DicePool pool1d62d41d8 = new(new DiceGroup[] { new DiceGroup(1, 6), new DiceGroup(2, 4), new DiceGroup(1, 8) });
			Assert.AreEqual("1d6 + 2d4 + 1d8", pool1d62d41d8.DiceFormat);
		}


	}
}
