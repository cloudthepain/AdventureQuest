using AdventureQuest.Dice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureQuest.UI
{
	[RequireComponent(typeof(DieController))]
	public class DieButton : MonoBehaviour
	{
		[field: SerializeField]
		public string ButtonLabel { get; private set; } = string.Empty;
		void Start()
		{
			if(ButtonLabel == string.Empty)
			{
				DieController dieController = GetComponent<DieController>();
				int sides = dieController.Sides;
				ButtonLabel = $"d{sides}";
			}
		}
	}
}
