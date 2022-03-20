using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUI : MonoBehaviour
{
	[SerializeField] private Text finalPoint;
	[SerializeField] private Text currentGold;
	[SerializeField] private Text finalGold;

	private PlayerAttribute playerAttribute;

	private void Awake()
	{
		playerAttribute = Utils.GetPlayerAttribute();
		finalPoint.text = string.Format("{0:D8}", playerAttribute.PlayerPoints);
		currentGold.text = string.Format("{0:D3}", 200);
		finalGold.text = string.Format("{0:D3}", 200);
	}
	
}
