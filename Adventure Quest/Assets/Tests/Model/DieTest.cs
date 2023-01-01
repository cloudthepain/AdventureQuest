using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AdventureQuest.Dice;
using UnityEditor.VersionControl;

public class DieTestScript
{
	public class DieTest
	{
		[Test, Timeout(5000), Description("Tests the Die Constructor")]

		public void TestDieThrowsIllegalArgument()
		{
			Assert.Throws<System.ArgumentException>(() => new Die(1));
			Assert.Throws<System.ArgumentException>(() => new Die(0));
			Assert.Throws<System.ArgumentException>(() => new Die(-1));
			Assert.Throws<System.ArgumentException>(() => new Die(-10));
			Assert.Throws<System.ArgumentException>(() => new Die(-50));
		}

		[Test, Timeout(5000), Description("Tests that a Die must be constructed with at least 2 sides")]
		public void TestDieConstructor() 
		{
			Die d6 = new(6);
			Assert.AreEqual(6, d6.Sides);
			Assert.AreEqual(1, d6.LastRolled);

			Die d4 = new(4);
			Assert.AreEqual(4, d4.Sides);
			Assert.AreEqual(1, d4.LastRolled);

		}
		[Test, Timeout(5000), Description("Tests that a Die must be constructed with at least 2 sides")]
		public void TestDieRoll() 
		{
			Die d6 = new(6);
			Assert.AreEqual(1, d6.LastRolled);
			Assert.AreEqual(6, d6.Sides);

			List<int> values = new();
			for(int i= 0; i< 1000; i++)
			{
				int result = d6.Roll();
				Assert.AreEqual(result, d6.LastRolled);
				Assert.LessOrEqual(result, 6);
				Assert.GreaterOrEqual(result, 1);
				values.Add(result);
			}

			Assert.Contains(1, values);
			Assert.Contains(2, values);
			Assert.Contains(3, values);
			Assert.Contains(4, values);
			Assert.Contains(5, values);
			Assert.Contains(6, values);

		}

		[Test, Timeout(5000), Description("Tests rolling a 12 sided die 1,000 times.")]
		public void Test12SidedDie()
		{
			// Construct a 12 sided die
			Die d12 = new(12);

			// Before rolling, the die should have a 1 on its face
			Assert.AreEqual(1, d12.LastRolled);

			// A 6 sided die should have 6 sides
			Assert.AreEqual(12, d12.Sides);

			// Roll this die 1,000 times and make sure it is always a value
			// between 1 and 12.
			List<int> values = new();
			for (int i = 0; i < 1_000; i++)
			{
				int result = d12.Roll();
				Assert.AreEqual(result, d12.LastRolled);
				Assert.LessOrEqual(result, 12);
				Assert.GreaterOrEqual(result, 1);
				values.Add(result);
			}

			// Check that each result was rolled
			Assert.Contains(1, values);
			Assert.Contains(2, values);
			Assert.Contains(3, values);
			Assert.Contains(4, values);
			Assert.Contains(5, values);
			Assert.Contains(6, values);
			Assert.Contains(7, values);
			Assert.Contains(8, values);
			Assert.Contains(9, values);
			Assert.Contains(10, values);
			Assert.Contains(11, values);
			Assert.Contains(12, values);
		}

	}
}
