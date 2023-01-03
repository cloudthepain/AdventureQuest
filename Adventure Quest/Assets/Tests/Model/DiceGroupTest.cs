using NUnit.Framework;

namespace AdventureQuest.Dice
{
	public class DiceGroupTest
	{

		[Test, Timeout(5000), Description("Tests the DiceGroup(amoutn, sides) Constructor")]
		public void TestConstructor()
		{
			DiceGroup group3d6 = new(3, 6);
			Assert.AreEqual(3, group3d6.Amount);
			Assert.AreEqual(6, group3d6.Sides);
			Assert.AreEqual(3, group3d6.Min);
			Assert.AreEqual(18, group3d6.Max);

			DiceGroup group1d20 = new(1, 20);
			Assert.AreEqual(1, group1d20.Amount);
			Assert.AreEqual(20, group1d20.Sides);
			Assert.AreEqual(1, group1d20.Min);
			Assert.AreEqual(20, group1d20.Max);
		}

		[Test, Timeout(5000), Description("Tests the DiceGroup Constructor validates parameters")]
		public void TestConstructorArgumentException()
		{
			Assert.Throws<System.ArgumentException>(() => new DiceGroup(0, 6));
			Assert.Throws<System.ArgumentException>(() => new DiceGroup(-1, 6));
			Assert.Throws<System.ArgumentException>(() => new DiceGroup(3, 1));
			Assert.Throws<System.ArgumentException>(() => new DiceGroup(3, -1));
			Assert.Throws<System.ArgumentException>(() => new DiceGroup(1, 0));
		}
		[Test, Timeout(5000), Description("Tests the result of rolling a 3d6 10,000 times.")]
		public void TestRoll3d6()
		{
			DiceGroup group3d6 = new(3, 6);

			// Roll the die pool 1000 times ensuring the bounds
			int[] values = new int[10_000];
			for (int i = 0; i < 10_000; i++)
			{
				int result = group3d6.Roll();
				Assert.LessOrEqual(result, group3d6.Max);
				Assert.GreaterOrEqual(result, group3d6.Min);
				values[i] = result;
			}

			// Result should contain all values from 3 to 18
			for (int i = group3d6.Min; i <= group3d6.Max; i++)
			{
				Assert.Contains(i, values);
			}
		}

		[Test, Timeout(5000), Description("Tests the result of rolling a 4d4 10,000 times.")]
		public void TestRoll2d4()
		{
			DiceGroup group2d4 = new(2, 4);

			// Roll the die pool 1000 times ensuring the bounds
			int[] values = new int[10_000];
			for (int i = 0; i < 10_000; i++)
			{
				int result = group2d4.Roll();
				Assert.LessOrEqual(result, group2d4.Max);
				Assert.GreaterOrEqual(result, group2d4.Min);
				values[i] = result;
			}

			// Result should contain all values from 3 to 18
			for (int i = group2d4.Min; i <= group2d4.Max; i++)
			{
				Assert.Contains(i, values);
			}
		}

	}
}

