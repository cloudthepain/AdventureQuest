using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureQuest.Dice
{
	public class DieController : MonoBehaviour
	{
		[field: SerializeField]
		public int Sides { get; private set; } = 6;
		private Die _die;

		void Start()
		{
			_die = new Die(Sides);
		}
		public void Roll()
		{
			_die.Roll();
			Debug.Log($"Rolled a {_die.LastRolled}");
		}
	}
}
