using AdventureQuest.Dice;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AdventureQuest.UI
{
	[RequireComponent(typeof(DieController))]
	public class DieButton : MonoBehaviour
	{
		[field: SerializeField]
		public string ButtonLabel { get; private set; } = string.Empty;

		[field: SerializeField]
		public UnityEvent<string> OnLabelChange { get; private set; }

		void Start()
		{
			if(ButtonLabel == string.Empty)
			{
				DieController dieController = GetComponent<DieController>();
				int sides = dieController.Sides;
				ButtonLabel = $"d{sides}";
			}
			DieButton dieButton= GetComponent<DieButton>();
			OnLabelChange.Invoke(ButtonLabel);
		}
	}
}
