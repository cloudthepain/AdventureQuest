using UnityEngine;

namespace AdventureQuest.Dice
{
	public class DiceGroup
	{
		Die[] _dice;
		public int Amount => _dice.Length;
		public int Sides => _dice[0].Sides;
		public int Min => Amount;
		public int Max => Sides * Amount;

		public DiceGroup(int amount, int sides)
		{
			if (amount < 1) throw new System.ArgumentException($"DiceGroup must contain at least one dice but was {amount}!");
			if (sides < 2) throw new System.ArgumentException($"DiceGroup must contain at least two sides but was {sides}");

			_dice = new Die[amount];
			for (int i = 0; i < amount; i++)
			{
				_dice[i] = new Die(sides);
			}
		}

		public int Roll()
		{
			int sum = 0;
			for(int i = 0; i < _dice.Length;i++) 
			{
				_dice[i].Roll();
				sum += _dice[i].LastRolled;
			}
			return sum;
		}
	}
}
