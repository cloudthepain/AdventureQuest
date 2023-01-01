using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureQuest.Dice
{
	public class Die
	{
		public int Sides { get; }
		public int LastRolled { get; private set; }
		public Die(int sides)
		{
			if(sides < 2)
			{
				throw new System.ArgumentException($"A die must have more than 2 sides");
			}
			Sides = sides;
			LastRolled= 1;
		}

		public int Roll()
		{
			return LastRolled = Random.Range(1, Sides+1);
		}
	}
}
