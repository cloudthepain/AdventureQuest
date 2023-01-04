using PlasticPipe.Server;
using System.Linq;
using UnityEngine;

namespace AdventureQuest.Dice
{
	public class DicePool
	{
		private readonly DiceGroup[] _dice;
		public string DiceFormat => string.Join(" + ",DiceGroupStrings());
		public int Min {
			get
			{
				int min = 0;
				foreach (DiceGroup group in _dice)
				{
					min += group.Min;
				}
				return min;
			}
		}
		public int Max { get
			{
				int max = 0;
				foreach (DiceGroup group in _dice)
				{
					max += group.Max;
				}
				return max;
			}
		}

		public DicePool(DiceGroup[] diceGroups)
		{

			if (diceGroups == null) throw new System.ArgumentNullException("Dice group must contain a value but contained null");
			if(diceGroups.Length < 1) throw new System.ArgumentException($"Dice group must be greater than was but was {diceGroups.Length}");
			_dice = diceGroups;
			for (int i = 0; i < diceGroups.Length; i++)
			{
				if (diceGroups[i] == null) throw new System.NullReferenceException("Dice group must contain a value but contained null");
			}
		}

		private string[] DiceGroupStrings()
		{
			string[] groups = new string[_dice.Length];
			for (int i = 0; i < _dice.Length; i++)
			{
				DiceGroup group = _dice[i];
				groups[i] = $"{group.Amount}d{group.Sides}";
			}
			return groups;
		}


	}


}