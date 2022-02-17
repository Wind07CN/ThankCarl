using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSceneMainUIController : MonoBehaviour
{

	private PlayerAttribute playerAttribute;
	[SerializeField] private GameObject playerLevelIndicator;

	public void InitMainUI(PlayerAttribute player)
	{
		playerAttribute = player;
		SetLevelIndicatorUI();
	}

	public void SetLevelIndicatorUI()
	{
		playerLevelIndicator.GetComponent<Text>().text = "Lv." + playerAttribute.Level;
	}
}
